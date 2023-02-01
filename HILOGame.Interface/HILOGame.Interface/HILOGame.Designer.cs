namespace HILOGame.Interface
{
    partial class HILOGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlayer = new System.Windows.Forms.Button();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.txtPlayer = new System.Windows.Forms.TextBox();
            this.cboGame = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGameDetails = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnAttempt = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpGame = new System.Windows.Forms.GroupBox();
            this.txtNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtMin = new System.Windows.Forms.MaskedTextBox();
            this.txtMax = new System.Windows.Forms.MaskedTextBox();
            this.grpGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlayer
            // 
            this.btnPlayer.Location = new System.Drawing.Point(413, 17);
            this.btnPlayer.Name = "btnPlayer";
            this.btnPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnPlayer.TabIndex = 0;
            this.btnPlayer.Text = "Register";
            this.btnPlayer.UseVisualStyleBackColor = true;
            this.btnPlayer.Click += new System.EventHandler(this.btnPlayer_ClickAsync);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(12, 20);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(77, 15);
            this.lblPlayer.TabIndex = 1;
            this.lblPlayer.Text = "Player Name:";
            // 
            // txtPlayer
            // 
            this.txtPlayer.Location = new System.Drawing.Point(95, 17);
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.Size = new System.Drawing.Size(306, 23);
            this.txtPlayer.TabIndex = 2;
            // 
            // cboGame
            // 
            this.cboGame.FormattingEnabled = true;
            this.cboGame.Location = new System.Drawing.Point(83, 24);
            this.cboGame.Name = "cboGame";
            this.cboGame.Size = new System.Drawing.Size(306, 23);
            this.cboGame.TabIndex = 3;
            this.cboGame.SelectedIndexChanged += new System.EventHandler(this.cboGame_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game:";
            // 
            // txtGameDetails
            // 
            this.txtGameDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGameDetails.Location = new System.Drawing.Point(83, 53);
            this.txtGameDetails.Multiline = true;
            this.txtGameDetails.Name = "txtGameDetails";
            this.txtGameDetails.ReadOnly = true;
            this.txtGameDetails.Size = new System.Drawing.Size(167, 184);
            this.txtGameDetails.TabIndex = 5;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(401, 24);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 6;
            this.btnJoin.Text = "Join Game";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnAttempt
            // 
            this.btnAttempt.Enabled = false;
            this.btnAttempt.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAttempt.Location = new System.Drawing.Point(304, 139);
            this.btnAttempt.Name = "btnAttempt";
            this.btnAttempt.Size = new System.Drawing.Size(126, 42);
            this.btnAttempt.TabIndex = 7;
            this.btnAttempt.Text = "TRY";
            this.btnAttempt.UseVisualStyleBackColor = true;
            this.btnAttempt.Click += new System.EventHandler(this.btnAttempt_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(413, 62);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 54);
            this.btnNewGame.TabIndex = 9;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(19, 66);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description:";
            // 
            // txtGameName
            // 
            this.txtGameName.Location = new System.Drawing.Point(95, 62);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(306, 23);
            this.txtGameName.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Number From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "To:";
            // 
            // grpGame
            // 
            this.grpGame.Controls.Add(this.txtNumber);
            this.grpGame.Controls.Add(this.txtGameDetails);
            this.grpGame.Controls.Add(this.btnAttempt);
            this.grpGame.Controls.Add(this.btnJoin);
            this.grpGame.Controls.Add(this.cboGame);
            this.grpGame.Controls.Add(this.label1);
            this.grpGame.Enabled = false;
            this.grpGame.Location = new System.Drawing.Point(12, 148);
            this.grpGame.Name = "grpGame";
            this.grpGame.Size = new System.Drawing.Size(487, 254);
            this.grpGame.TabIndex = 19;
            this.grpGame.TabStop = false;
            this.grpGame.Text = "Game";
            // 
            // txtNumber
            // 
            this.txtNumber.Enabled = false;
            this.txtNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNumber.Location = new System.Drawing.Point(304, 98);
            this.txtNumber.Mask = "#####";
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(126, 35);
            this.txtNumber.TabIndex = 9;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(95, 93);
            this.txtMin.Mask = "#####";
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(133, 23);
            this.txtMin.TabIndex = 20;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(262, 93);
            this.txtMax.Mask = "#####";
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(139, 23);
            this.txtMax.TabIndex = 21;
            // 
            // HILOGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 414);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.grpGame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGameName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.txtPlayer);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.btnPlayer);
            this.Name = "HILOGame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HILOGame_Load);
            this.grpGame.ResumeLayout(false);
            this.grpGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPlayer;
        private Label lblPlayer;
        private TextBox txtPlayer;
        private ComboBox cboGame;
        private Label label1;
        private TextBox txtGameDetails;
        private Button btnJoin;
        private Button btnAttempt;
        private Button btnNewGame;
        private Label lblDescription;
        private TextBox txtGameName;
        private Label label3;
        private Label label4;
        private GroupBox grpGame;
        private MaskedTextBox txtNumber;
        private MaskedTextBox txtMin;
        private MaskedTextBox txtMax;
    }
}