namespace ClientTKM.Forms {
    partial class FrmClient {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClient));
            this.pnlScorePanel = new System.Windows.Forms.Panel();
            this.lblOpponentScore = new System.Windows.Forms.Label();
            this.lblOpponent = new System.Windows.Forms.Label();
            this.lblMyScore = new System.Windows.Forms.Label();
            this.lblMe = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlMoveForm = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.txtTargetRoomCode = new System.Windows.Forms.TextBox();
            this.lblWelcomeInfo3 = new System.Windows.Forms.Label();
            this.txtMyRoomCode = new System.Windows.Forms.TextBox();
            this.lblWelcomeInfo2 = new System.Windows.Forms.Label();
            this.lblWelcomeInfo1 = new System.Windows.Forms.Label();
            this.pnlCredits = new System.Windows.Forms.Panel();
            this.lblCredits = new System.Windows.Forms.Label();
            this.pnlChooseAttack = new System.Windows.Forms.Panel();
            this.lblChooseWarn = new System.Windows.Forms.Label();
            this.lblGameStarting = new System.Windows.Forms.Label();
            this.pnlBattleArea = new System.Windows.Forms.Panel();
            this.lblAttackInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGameInfo = new System.Windows.Forms.Label();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRock = new System.Windows.Forms.Button();
            this.btnPaper = new System.Windows.Forms.Button();
            this.btnScissors = new System.Windows.Forms.Button();
            this.pbOpponentAttack = new System.Windows.Forms.PictureBox();
            this.pbMyAttack = new System.Windows.Forms.PictureBox();
            this.pnlScorePanel.SuspendLayout();
            this.pnlMoveForm.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            this.pnlCredits.SuspendLayout();
            this.pnlChooseAttack.SuspendLayout();
            this.pnlBattleArea.SuspendLayout();
            this.pnlLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpponentAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyAttack)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScorePanel
            // 
            this.pnlScorePanel.Controls.Add(this.lblOpponentScore);
            this.pnlScorePanel.Controls.Add(this.lblOpponent);
            this.pnlScorePanel.Controls.Add(this.lblMyScore);
            this.pnlScorePanel.Controls.Add(this.lblMe);
            this.pnlScorePanel.Location = new System.Drawing.Point(12, 52);
            this.pnlScorePanel.Name = "pnlScorePanel";
            this.pnlScorePanel.Size = new System.Drawing.Size(669, 78);
            this.pnlScorePanel.TabIndex = 13;
            this.pnlScorePanel.Visible = false;
            // 
            // lblOpponentScore
            // 
            this.lblOpponentScore.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOpponentScore.Location = new System.Drawing.Point(574, 28);
            this.lblOpponentScore.Name = "lblOpponentScore";
            this.lblOpponentScore.Size = new System.Drawing.Size(92, 42);
            this.lblOpponentScore.TabIndex = 24;
            this.lblOpponentScore.Text = "0";
            this.lblOpponentScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOpponent
            // 
            this.lblOpponent.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOpponent.Location = new System.Drawing.Point(574, 2);
            this.lblOpponent.Name = "lblOpponent";
            this.lblOpponent.Size = new System.Drawing.Size(92, 23);
            this.lblOpponent.TabIndex = 23;
            this.lblOpponent.Text = "RAKİP";
            this.lblOpponent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMyScore
            // 
            this.lblMyScore.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMyScore.Location = new System.Drawing.Point(3, 28);
            this.lblMyScore.Name = "lblMyScore";
            this.lblMyScore.Size = new System.Drawing.Size(92, 42);
            this.lblMyScore.TabIndex = 22;
            this.lblMyScore.Text = "0";
            this.lblMyScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMe
            // 
            this.lblMe.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMe.Location = new System.Drawing.Point(3, 1);
            this.lblMe.Name = "lblMe";
            this.lblMe.Size = new System.Drawing.Size(92, 23);
            this.lblMe.TabIndex = 21;
            this.lblMe.Text = "SİZ";
            this.lblMe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(113, 32);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(467, 117);
            this.lblLogo.TabIndex = 17;
            this.lblLogo.Text = "TAŞ KAĞIT MAKAS\r\nONLINE";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlMoveForm
            // 
            this.pnlMoveForm.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlMoveForm.Controls.Add(this.pictureBox2);
            this.pnlMoveForm.Controls.Add(this.pbMin);
            this.pnlMoveForm.Controls.Add(this.pbClose);
            this.pnlMoveForm.Controls.Add(this.lblFormTitle);
            this.pnlMoveForm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlMoveForm.Location = new System.Drawing.Point(0, 0);
            this.pnlMoveForm.Name = "pnlMoveForm";
            this.pnlMoveForm.Size = new System.Drawing.Size(693, 29);
            this.pnlMoveForm.TabIndex = 19;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(3, 1);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(687, 27);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Taş Kağıt Makas Client";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.lblFormTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.lblFormTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcome.Controls.Add(this.btnJoinRoom);
            this.pnlWelcome.Controls.Add(this.txtTargetRoomCode);
            this.pnlWelcome.Controls.Add(this.lblWelcomeInfo3);
            this.pnlWelcome.Controls.Add(this.txtMyRoomCode);
            this.pnlWelcome.Controls.Add(this.lblWelcomeInfo2);
            this.pnlWelcome.Controls.Add(this.lblWelcomeInfo1);
            this.pnlWelcome.Location = new System.Drawing.Point(12, 152);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(669, 296);
            this.pnlWelcome.TabIndex = 21;
            this.pnlWelcome.Visible = false;
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnJoinRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoinRoom.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnJoinRoom.ForeColor = System.Drawing.Color.White;
            this.btnJoinRoom.Location = new System.Drawing.Point(374, 251);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(85, 30);
            this.btnJoinRoom.TabIndex = 20;
            this.btnJoinRoom.TabStop = false;
            this.btnJoinRoom.Text = "KATIL";
            this.btnJoinRoom.UseVisualStyleBackColor = false;
            this.btnJoinRoom.Click += new System.EventHandler(this.BtnJoinRoom_Click);
            // 
            // txtTargetRoomCode
            // 
            this.txtTargetRoomCode.BackColor = System.Drawing.Color.MidnightBlue;
            this.txtTargetRoomCode.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTargetRoomCode.ForeColor = System.Drawing.Color.White;
            this.txtTargetRoomCode.Location = new System.Drawing.Point(215, 250);
            this.txtTargetRoomCode.MaxLength = 5;
            this.txtTargetRoomCode.Name = "txtTargetRoomCode";
            this.txtTargetRoomCode.Size = new System.Drawing.Size(153, 32);
            this.txtTargetRoomCode.TabIndex = 19;
            this.txtTargetRoomCode.TabStop = false;
            this.txtTargetRoomCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWelcomeInfo3
            // 
            this.lblWelcomeInfo3.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcomeInfo3.ForeColor = System.Drawing.Color.Black;
            this.lblWelcomeInfo3.Location = new System.Drawing.Point(3, 188);
            this.lblWelcomeInfo3.Name = "lblWelcomeInfo3";
            this.lblWelcomeInfo3.Size = new System.Drawing.Size(663, 59);
            this.lblWelcomeInfo3.TabIndex = 18;
            this.lblWelcomeInfo3.Text = "Ya da siz onun odasına katılın.";
            this.lblWelcomeInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMyRoomCode
            // 
            this.txtMyRoomCode.BackColor = System.Drawing.Color.MidnightBlue;
            this.txtMyRoomCode.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMyRoomCode.ForeColor = System.Drawing.Color.White;
            this.txtMyRoomCode.Location = new System.Drawing.Point(215, 153);
            this.txtMyRoomCode.Name = "txtMyRoomCode";
            this.txtMyRoomCode.ReadOnly = true;
            this.txtMyRoomCode.Size = new System.Drawing.Size(244, 32);
            this.txtMyRoomCode.TabIndex = 17;
            this.txtMyRoomCode.TabStop = false;
            this.txtMyRoomCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWelcomeInfo2
            // 
            this.lblWelcomeInfo2.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcomeInfo2.ForeColor = System.Drawing.Color.Black;
            this.lblWelcomeInfo2.Location = new System.Drawing.Point(3, 91);
            this.lblWelcomeInfo2.Name = "lblWelcomeInfo2";
            this.lblWelcomeInfo2.Size = new System.Drawing.Size(663, 59);
            this.lblWelcomeInfo2.TabIndex = 16;
            this.lblWelcomeInfo2.Text = "Aşağıdaki kodu, arkadaşınıza gönderin ve odanıza katılmasını bekleyin.";
            this.lblWelcomeInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcomeInfo1
            // 
            this.lblWelcomeInfo1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcomeInfo1.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeInfo1.Location = new System.Drawing.Point(3, 1);
            this.lblWelcomeInfo1.Name = "lblWelcomeInfo1";
            this.lblWelcomeInfo1.Size = new System.Drawing.Size(663, 90);
            this.lblWelcomeInfo1.TabIndex = 15;
            this.lblWelcomeInfo1.Text = "Arkadaşınızı, aranızdaki bu küçük anlaşmazlığı \r\nSocket üzerinden canlı olarak çö" +
    "zmeye davet edin.";
            this.lblWelcomeInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCredits
            // 
            this.pnlCredits.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlCredits.Controls.Add(this.lblCredits);
            this.pnlCredits.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlCredits.Location = new System.Drawing.Point(0, 454);
            this.pnlCredits.Name = "pnlCredits";
            this.pnlCredits.Size = new System.Drawing.Size(693, 29);
            this.pnlCredits.TabIndex = 20;
            // 
            // lblCredits
            // 
            this.lblCredits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCredits.Location = new System.Drawing.Point(209, 1);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(275, 27);
            this.lblCredits.TabIndex = 0;
            this.lblCredits.Text = "Ömer Faruk Acar (@horriblebyte) - 2020";
            this.lblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCredits.Click += new System.EventHandler(this.LblCredits_Click);
            // 
            // pnlChooseAttack
            // 
            this.pnlChooseAttack.BackColor = System.Drawing.Color.Transparent;
            this.pnlChooseAttack.Controls.Add(this.lblChooseWarn);
            this.pnlChooseAttack.Controls.Add(this.lblGameStarting);
            this.pnlChooseAttack.Controls.Add(this.btnRock);
            this.pnlChooseAttack.Controls.Add(this.btnPaper);
            this.pnlChooseAttack.Controls.Add(this.btnScissors);
            this.pnlChooseAttack.Location = new System.Drawing.Point(12, 152);
            this.pnlChooseAttack.Name = "pnlChooseAttack";
            this.pnlChooseAttack.Size = new System.Drawing.Size(669, 296);
            this.pnlChooseAttack.TabIndex = 22;
            this.pnlChooseAttack.Visible = false;
            // 
            // lblChooseWarn
            // 
            this.lblChooseWarn.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblChooseWarn.ForeColor = System.Drawing.Color.Black;
            this.lblChooseWarn.Location = new System.Drawing.Point(3, 217);
            this.lblChooseWarn.Name = "lblChooseWarn";
            this.lblChooseWarn.Size = new System.Drawing.Size(663, 78);
            this.lblChooseWarn.TabIndex = 18;
            this.lblChooseWarn.Text = "Lütfen seçiminizi yapınız...";
            this.lblChooseWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameStarting
            // 
            this.lblGameStarting.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGameStarting.ForeColor = System.Drawing.Color.White;
            this.lblGameStarting.Location = new System.Drawing.Point(3, 1);
            this.lblGameStarting.Name = "lblGameStarting";
            this.lblGameStarting.Size = new System.Drawing.Size(663, 78);
            this.lblGameStarting.TabIndex = 15;
            this.lblGameStarting.Text = "OYUN BAŞLASIN!";
            this.lblGameStarting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBattleArea
            // 
            this.pnlBattleArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlBattleArea.Controls.Add(this.lblAttackInfo);
            this.pnlBattleArea.Controls.Add(this.label3);
            this.pnlBattleArea.Controls.Add(this.lblGameInfo);
            this.pnlBattleArea.Controls.Add(this.pbOpponentAttack);
            this.pnlBattleArea.Controls.Add(this.pbMyAttack);
            this.pnlBattleArea.Location = new System.Drawing.Point(12, 152);
            this.pnlBattleArea.Name = "pnlBattleArea";
            this.pnlBattleArea.Size = new System.Drawing.Size(669, 296);
            this.pnlBattleArea.TabIndex = 25;
            this.pnlBattleArea.Visible = false;
            // 
            // lblAttackInfo
            // 
            this.lblAttackInfo.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAttackInfo.ForeColor = System.Drawing.Color.Black;
            this.lblAttackInfo.Location = new System.Drawing.Point(116, 217);
            this.lblAttackInfo.Name = "lblAttackInfo";
            this.lblAttackInfo.Size = new System.Drawing.Size(142, 78);
            this.lblAttackInfo.TabIndex = 26;
            this.lblAttackInfo.Text = "seçildi...";
            this.lblAttackInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(264, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 78);
            this.label3.TabIndex = 27;
            this.label3.Text = "VS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameInfo
            // 
            this.lblGameInfo.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGameInfo.ForeColor = System.Drawing.Color.White;
            this.lblGameInfo.Location = new System.Drawing.Point(3, 1);
            this.lblGameInfo.Name = "lblGameInfo";
            this.lblGameInfo.Size = new System.Drawing.Size(663, 78);
            this.lblGameInfo.TabIndex = 15;
            this.lblGameInfo.Text = "RAKİBİN SEÇİMİ BEKLENİYOR...";
            this.lblGameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLoading
            // 
            this.pnlLoading.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoading.Controls.Add(this.label1);
            this.pnlLoading.Controls.Add(this.lblConnecting);
            this.pnlLoading.Controls.Add(this.pictureBox1);
            this.pnlLoading.Location = new System.Drawing.Point(12, 152);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(669, 296);
            this.pnlLoading.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 78);
            this.label1.TabIndex = 18;
            this.label1.Text = "Lütfen biraz bekleyin...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConnecting
            // 
            this.lblConnecting.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblConnecting.ForeColor = System.Drawing.Color.White;
            this.lblConnecting.Location = new System.Drawing.Point(3, 1);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(663, 78);
            this.lblConnecting.TabIndex = 15;
            this.lblConnecting.Text = "SUNUCU İLE BAĞLANTI KURULUYOR!";
            this.lblConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::ClientTKM.Properties.Resources.Logo;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pbMin
            // 
            this.pbMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbMin.Image = global::ClientTKM.Properties.Resources.minButton;
            this.pbMin.Location = new System.Drawing.Point(638, 3);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(23, 23);
            this.pbMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMin.TabIndex = 5;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.BtnMin_Click);
            // 
            // pbClose
            // 
            this.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbClose.Image = global::ClientTKM.Properties.Resources.exitButton;
            this.pbClose.Location = new System.Drawing.Point(667, 3);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(23, 23);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 4;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClientTKM.Properties.Resources.Loading;
            this.pictureBox1.Location = new System.Drawing.Point(263, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btnRock
            // 
            this.btnRock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRock.Image = global::ClientTKM.Properties.Resources.Rock;
            this.btnRock.Location = new System.Drawing.Point(115, 82);
            this.btnRock.Name = "btnRock";
            this.btnRock.Size = new System.Drawing.Size(142, 132);
            this.btnRock.TabIndex = 24;
            this.btnRock.UseVisualStyleBackColor = true;
            this.btnRock.Click += new System.EventHandler(this.BtnAttack_Click);
            // 
            // btnPaper
            // 
            this.btnPaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaper.Image = global::ClientTKM.Properties.Resources.Paper;
            this.btnPaper.Location = new System.Drawing.Point(263, 82);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.Size = new System.Drawing.Size(142, 132);
            this.btnPaper.TabIndex = 23;
            this.btnPaper.UseVisualStyleBackColor = true;
            this.btnPaper.Click += new System.EventHandler(this.BtnAttack_Click);
            // 
            // btnScissors
            // 
            this.btnScissors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScissors.Image = global::ClientTKM.Properties.Resources.Scissors;
            this.btnScissors.Location = new System.Drawing.Point(411, 82);
            this.btnScissors.Name = "btnScissors";
            this.btnScissors.Size = new System.Drawing.Size(142, 132);
            this.btnScissors.TabIndex = 22;
            this.btnScissors.UseVisualStyleBackColor = true;
            this.btnScissors.Click += new System.EventHandler(this.BtnAttack_Click);
            // 
            // pbOpponentAttack
            // 
            this.pbOpponentAttack.Image = global::ClientTKM.Properties.Resources.Waiting;
            this.pbOpponentAttack.Location = new System.Drawing.Point(412, 83);
            this.pbOpponentAttack.Name = "pbOpponentAttack";
            this.pbOpponentAttack.Size = new System.Drawing.Size(142, 132);
            this.pbOpponentAttack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbOpponentAttack.TabIndex = 26;
            this.pbOpponentAttack.TabStop = false;
            // 
            // pbMyAttack
            // 
            this.pbMyAttack.Image = global::ClientTKM.Properties.Resources.Scissors;
            this.pbMyAttack.Location = new System.Drawing.Point(116, 83);
            this.pbMyAttack.Name = "pbMyAttack";
            this.pbMyAttack.Size = new System.Drawing.Size(142, 132);
            this.pbMyAttack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMyAttack.TabIndex = 25;
            this.pbMyAttack.TabStop = false;
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(693, 483);
            this.Controls.Add(this.pnlCredits);
            this.Controls.Add(this.pnlMoveForm);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.pnlScorePanel);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.pnlChooseAttack);
            this.Controls.Add(this.pnlWelcome);
            this.Controls.Add(this.pnlBattleArea);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taş Kağıt Makas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClient_FormClosing);
            this.pnlScorePanel.ResumeLayout(false);
            this.pnlMoveForm.ResumeLayout(false);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.pnlCredits.ResumeLayout(false);
            this.pnlChooseAttack.ResumeLayout(false);
            this.pnlBattleArea.ResumeLayout(false);
            this.pnlLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpponentAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyAttack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlScorePanel;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlMoveForm;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Button btnJoinRoom;
        private System.Windows.Forms.TextBox txtTargetRoomCode;
        private System.Windows.Forms.Label lblWelcomeInfo3;
        private System.Windows.Forms.TextBox txtMyRoomCode;
        private System.Windows.Forms.Label lblWelcomeInfo2;
        private System.Windows.Forms.Label lblWelcomeInfo1;
        private System.Windows.Forms.Panel pnlCredits;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Panel pnlChooseAttack;
        private System.Windows.Forms.Label lblChooseWarn;
        private System.Windows.Forms.Label lblGameStarting;
        private System.Windows.Forms.Button btnScissors;
        private System.Windows.Forms.Button btnRock;
        private System.Windows.Forms.Button btnPaper;
        private System.Windows.Forms.Panel pnlBattleArea;
        private System.Windows.Forms.Label lblGameInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbOpponentAttack;
        private System.Windows.Forms.PictureBox pbMyAttack;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblOpponentScore;
        private System.Windows.Forms.Label lblOpponent;
        private System.Windows.Forms.Label lblMyScore;
        private System.Windows.Forms.Label lblMe;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lblAttackInfo;
        private System.Windows.Forms.Panel pnlLoading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

