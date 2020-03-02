using System;
using System.Windows.Forms;

namespace ClientTKM.Forms {
    public partial class FrmDialogBox : Form {

        #region Değişkenler
        bool MoveFlag = false;
        int MouseX, MouseY;
        #endregion

        #region Yapıcı Methodlar
        /// <summary>
        /// Tek buton içeren bir DialogBox oluşturur. Oluşan buton, "Onaylama" görevi görür.
        /// </summary>
        /// <param name="_titleMessage">DialogBox'un başlığını belirler.</param>
        /// <param name="_dialogMessage">DialogBox'un ana mesajını belirler.</param>
        /// <param name="_acceptButtonText">Onaylama görevi gören butonun yazısını belirler.</param>
        public FrmDialogBox(string _titleMessage, string _dialogMessage, string _acceptButtonText) {
            InitializeComponent();
            lblTitleText.Text = _titleMessage;
            lblDialogText.Text = _dialogMessage;
            btnAccept.Text = _acceptButtonText;
            btnAccept.Visible = true;
            btnAccept.Width = 368;

            btnAccept.Click += btnAccept_Click;

            ShowDialog();
        }

        /// <summary>
        /// Çift buton içeren bir DialogBox oluşturur. Oluşan butonlardan biri "Onaylama" görevi, diğeri ise "Reddetme" görevi görür.
        /// </summary>
        /// <param name="_titleMessage">DialogBox'un başlığını belirler.</param>
        /// <param name="_dialogMessage">DialogBox'un ana mesajını belirler.</param>
        /// <param name="_acceptButtonText">"Onaylama" görevi gören butonun yazısını belirler.</param>
        /// <param name="_declineButtonText">"Reddetme" görevi gören butonun yazısını belirler.</param>
        public FrmDialogBox(string _titleMessage, string _dialogMessage, string _acceptButtonText, string _declineButtonText) {
            InitializeComponent();
            lblTitleText.Text = _titleMessage;
            lblDialogText.Text = _dialogMessage;
            btnAccept.Text = _acceptButtonText;
            btnDecline.Text = _declineButtonText;
            btnAccept.Visible = true;
            btnDecline.Visible = true;

            btnAccept.Click += btnAccept_Click;
            btnDecline.Click += btnDecline_Click;

            ShowDialog();
        }
        #endregion

        #region Tıklama Event'ları
        private void btnAccept_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDecline_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region Form Görsel Event'ları
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

        private void frmDialogBox_Load(object sender, EventArgs e) {
            CenterToParent();
        }

        private void Form_MouseUp(object sender, MouseEventArgs e) {
            MoveFlag = false;
        }
        #endregion
    }
}