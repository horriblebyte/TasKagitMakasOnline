using System;
using System.Net;
using System.Text;
using System.Drawing;
using ClientTKM.Utils;
using ClientTKM.Enums;
using ClientTKM.Classes;
using System.Net.Sockets;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ClientTKM.Forms {
    public partial class FrmClient : Form {

        #region Variables
        int MouseX, MouseY;
        bool MoveFlag = false;

        //Socketimizin özellikleri.
        private readonly Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //İstemcinin bağlanacağı ip adresi ve port numarası.
        private readonly IPEndPoint clientIpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1881);

        //Alıcı byte tamponumuz ve boyutu.
        private const int receiveByteBufferLength = 1024;
        private readonly byte[] receiveByteBuffer = new byte[receiveByteBufferLength];
        #endregion

        #region Constructor(s)
        public FrmClient() {
            //Form component'lerini yerleştiriyoruz.
            InitializeComponent();
            //Sunucu ile asenkron bir bağlantı kurmaya çalışıyoruz.
            clientSocket.BeginConnect(clientIpEndPoint, new AsyncCallback(ConnectCallback), null);
        }
        #endregion

        #region Connection
        private void ConnectCallback(IAsyncResult ar) {
            try {
                clientSocket.EndConnect(ar);
                InvokeUI(() => {
                    pnlLoading.Visible = false;
                    pnlWelcome.Visible = true;
                });
                TitleRefresher();
                Sender.Send(string.Format("{0}", (ushort)Opcode.ROOM_CODE), clientSocket);
                Receive();
            } catch {
                InvokeUI(() => {
                    new FrmDialogBox("Bağlantı Hatası", "Sunucu ile bağlantı kurulamadı.\nUygulama kapatılıyor!", "TAMAM");
                });
                Environment.Exit(0);
            }
        }
        #endregion

        #region Async Receiver
        /// <summary>
        /// Sunucudan gelen verileri dinleyen metottur.
        /// </summary>
        public void Receive() {
            if (clientSocket.Connected)
                clientSocket.BeginReceive(receiveByteBuffer, 0, receiveByteBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
        }

        private void ReceiveCallback(IAsyncResult ar) {
            try {
                Socket clientSocket = (Socket)ar.AsyncState;
                int receivedDataLength = clientSocket.EndReceive(ar);
                if (receivedDataLength <= 0) {
                    Environment.Exit(0);
                } else {
                    byte[] localByteBuffer = new byte[receivedDataLength];
                    Array.Copy(receiveByteBuffer, 0, localByteBuffer, 0, receivedDataLength);
                    string receivedData = Encoding.Default.GetString(localByteBuffer, 0, receivedDataLength);
                    //Server'dan gelen veriyi handle edileceği methoda yönlendiriyoruz.
                    HandleReceivedData(receivedData);
                }
                Receive();
            } catch {
                //Mesajı harici thread'den ana thread'e yönlendiriyoruz.
                InvokeUI(() => {
                    new FrmDialogBox("Bağlantı Hatası", "Sunucu ile bağlantı kesildi.\nUygulama kapatılıyor!", "TAMAM");
                });
                Environment.Exit(0);
            }
        }
        #endregion

        #region Data Handler
        private void HandleReceivedData(string receivedData) {
            string[] splittedData = receivedData.Split('\t');
            ushort serverOpcode = ushort.TryParse(splittedData[0], out serverOpcode) ? serverOpcode : (ushort)0;

            if (serverOpcode != 0)
                switch (serverOpcode) {

                    //PLAYER ID GELDİ!
                    case (ushort)Opcode.PLAYER_ID:
                        AllUtils.MyID = splittedData[1];
                        break;

                    //ODA KODU GELDİ!
                    case (ushort)Opcode.ROOM_CODE:
                        SetRoomCode(splittedData[1]);
                        break;

                    //ZATEN BU ODADASINIZ!
                    case (ushort)Opcode.ROOM_IS_SAME:
                        InvokeUI(() => {
                            new FrmDialogBox("Uyarı", "Zaten bu odadasınız.\nFarklı bir oda kodu girin.", "TAMAM");
                        });
                        break;

                    //ODA BULUNAMADI!
                    case (ushort)Opcode.ROOM_NOT_FOUND:
                        InvokeUI(() => {
                            new FrmDialogBox("Uyarı", "Oda bulunamadı.\nFarklı bir oda kodu girin.", "TAMAM");
                        });
                        break;

                    //ODA DOLU!
                    case (ushort)Opcode.ROOM_IS_FULL:
                        InvokeUI(() => {
                            new FrmDialogBox("Uyarı", "Oda dolu.\nFarklı bir oda kodu girin.", "TAMAM");
                        });
                        break;

                    //KAPIŞMA BAŞLADI!
                    case (ushort)Opcode.GAME_STARTED:
                        InvokeUI(() => {
                            GameStarted();
                        });
                        break;

                    //HAMLE KABUL EDİLDİ!
                    case (ushort)Opcode.ATTACK_ACCEPTED:
                        MyAttackAccepted(splittedData[1]);
                        break;

                    //OYUN BİTTİ!
                    case (ushort)Opcode.GAME_END:
                        GameFinished(splittedData[1], splittedData[2], splittedData[3], splittedData[4], splittedData[5]);
                        break;

                    //RAKİP OYUNDAN AYRILDI!
                    case (ushort)Opcode.OPPONENT_IS_LEFT:
                        OpponentIsLeft();
                        break;
                }
        }
        #endregion

        #region Methods
        private void SetRoomCode(string RoomCode) {
            if (txtMyRoomCode.Text == string.Empty)
                Sender.Send(string.Format("{0}\t{1}", (ushort)Opcode.JOIN_ROOM, RoomCode), clientSocket);
            InvokeUI(() => {
                txtMyRoomCode.Text = RoomCode;
            });
        }

        private void GameStarted() {
            pbOpponentAttack.Image = Properties.Resources.Waiting;
            pnlWelcome.Visible = false;
            pnlBattleArea.Visible = false;
            pnlScorePanel.Visible = true;
            pnlChooseAttack.Visible = true;
        }

        private void MyAttackAccepted(string Attack) {
            AllUtils.MyAttack = (AttackType)Convert.ToUInt16(Attack);
            InvokeUI(() => {
                pbMyAttack.Image = AllUtils.GetAttackImageFromCode((ushort)AllUtils.MyAttack);
                lblAttackInfo.Text = string.Format("{0}\nseçildi...", AllUtils.GetAttackNameFromCode((ushort)AllUtils.MyAttack));
                lblGameInfo.Text = "RAKİBİN SEÇİMİ BEKLENİYOR...";
                pnlChooseAttack.Visible = false;
                pnlBattleArea.Visible = true;
                lblAttackInfo.Width = 142;
            });
        }

        private void GameFinished(string WinnerID, string MyScore, string OpponentScore, string OpponentAttack, string AttackComment) {
            AllUtils.OpponentAttack = (AttackType)Convert.ToUInt16(OpponentAttack);
            InvokeUI(() => {
                pbOpponentAttack.Image = AllUtils.GetAttackImageFromCode((ushort)AllUtils.OpponentAttack);
                lblAttackInfo.Width = 438;
                lblAttackInfo.Text = AllUtils.GetAttackCommentaryFromCode(AttackComment);
                SyncScores(Convert.ToInt32(MyScore), Convert.ToInt32(OpponentScore));

                if (WinnerID == string.Empty) {
                    GameEndAnimation(Color.Gray);
                    lblGameInfo.Text = "BERABERE!";
                } else if (WinnerID == AllUtils.MyID) {
                    GameEndAnimation(Color.FromArgb(92, 184, 17));
                    lblGameInfo.Text = "KAZANDINIZ!";
                } else {
                    GameEndAnimation(Color.FromArgb(254, 26, 0));
                    lblGameInfo.Text = "KAYBETTİNİZ...";
                }
            });
        }

        private void OpponentIsLeft() {
            InvokeUI(() => {
                new FrmDialogBox("Uyarı", "Rakip sizden korktu ve kaçtı!", "TAMAM");
                SyncScores(0, 0);
                pnlScorePanel.Visible = false;
                pnlChooseAttack.Visible = false;
                pnlBattleArea.Visible = false;
                pnlWelcome.Visible = true;
            });
        }

        /// <summary>
        /// Oyuncuların skorlarını senkronize eder.
        /// </summary>
        /// <param name="MyScore">Bizim skorumuz</param>
        /// <param name="OpponentScore">Rakibin skoru</param>
        private void SyncScores(int MyScore, int OpponentScore) {
            AllUtils.MyScore = MyScore;
            AllUtils.OpponentScore = OpponentScore;
            lblMyScore.Text = Convert.ToString(AllUtils.MyScore);
            lblOpponentScore.Text = Convert.ToString(AllUtils.OpponentScore);
        }

        /// <summary>
        /// Belirtilen renge göre oyunun bitiş animasyonunu gerçekleştirir.
        /// </summary>
        /// <param name="formColor">Renk</param>
        private async void GameEndAnimation(Color formColor) {
            BackColor = formColor;
            await Task.Delay(3000);
            BackColor = Color.FromArgb(0, 175, 196);
            GameStarted();
        }

        /// <summary>
        /// Form başlığına kullanılan ram oranını yazdırır.
        /// </summary>
        private async void TitleRefresher() {
            while (true) {
                InvokeUI(() => {
                    lblFormTitle.Text = string.Format("Taş Kağıt Makas Client - Kullanılan RAM: {0} KB", GC.GetTotalMemory(true) / 1024);
                });
                await Task.Delay(500);
            }
        }

        /// <summary>
        /// Harici thread'deki Action'u, eğer gerekiyorsa ana thread'e transfer eder.
        /// </summary>
        /// <param name="action">Action</param>
        private void InvokeUI(Action action) {
            if (InvokeRequired)
                Invoke(action);
        }
        #endregion

        #region Form Event'ları

        #region Form Move
        private void Form_MouseDown(object sender, MouseEventArgs e) {
            MoveFlag = true;
            MouseX = Cursor.Position.X - Left;
            MouseY = Cursor.Position.Y - Top;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e) {
            if (MoveFlag) {
                Top = Cursor.Position.Y - MouseY;
                Left = Cursor.Position.X - MouseX;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e) {
            MoveFlag = false;
        }
        #endregion

        private void BtnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void BtnMin_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e) {
            FrmDialogBox dialogBox = new FrmDialogBox("Bilgi", "Uygulama kapatılsın mı?", "EVET", "HAYIR");
            if (dialogBox.DialogResult == DialogResult.OK) {
                //Çıkış yapmak istediğimizi belirten opcode'u gönderiyoruz.
                Sender.Send(string.Format("{0}", (ushort)Opcode.EXIT_APP), clientSocket);
                e.Cancel = false;
            } else
                e.Cancel = true;
        }

        private void BtnJoinRoom_Click(object sender, EventArgs e) {
            if (txtTargetRoomCode.Text == string.Empty) {
                new FrmDialogBox("Uyarı", "Lütfen bir oda kodu giriniz.", "TAMAM");
                txtTargetRoomCode.Select();
            } else if (txtTargetRoomCode.Text.Length < 5) {
                new FrmDialogBox("Uyarı", "Oda kodu en az 5 hane içermelidir.", "TAMAM");
                txtTargetRoomCode.Select();
            } else
                Sender.Send(string.Format("{0}\t{1}", (ushort)Opcode.JOIN_ROOM, txtTargetRoomCode.Text), clientSocket);
        }

        private void LblCredits_Click(object sender, EventArgs e) {
            Process.Start("https://www.github.com/horriblebyte");
        }

        private void BtnAttack_Click(object sender, EventArgs e) {
            Button attackButton = sender as Button;
            switch (attackButton.Name) {
                case "btnRock":
                    Sender.Send(string.Format("{0}\t{1}", (ushort)Opcode.ATTACK_REQUEST, (ushort)AttackType.ROCK), clientSocket);
                    break;
                case "btnPaper":
                    Sender.Send(string.Format("{0}\t{1}", (ushort)Opcode.ATTACK_REQUEST, (ushort)AttackType.PAPER), clientSocket);
                    break;
                case "btnScissors":
                    Sender.Send(string.Format("{0}\t{1}", (ushort)Opcode.ATTACK_REQUEST, (ushort)AttackType.SCISSORS), clientSocket);
                    break;
            }
        }
        #endregion
    }
}