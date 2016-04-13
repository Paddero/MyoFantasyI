namespace MyoFantasyI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.isConnectedLbl = new System.Windows.Forms.Label();
            this.characterPic = new System.Windows.Forms.PictureBox();
            this.howToStartlbl = new System.Windows.Forms.Label();
            this.enemyPic = new System.Windows.Forms.PictureBox();
            this.playerHP = new System.Windows.Forms.Label();
            this.enemyHP = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.attacklbl = new System.Windows.Forms.Label();
            this.heallbl = new System.Windows.Forms.Label();
            this.timerlbl = new System.Windows.Forms.Label();
            this.enemyRagelbl = new System.Windows.Forms.Label();
            this.playerRagelbl = new System.Windows.Forms.Label();
            this.rageAbilitylbl = new System.Windows.Forms.Label();
            this.playerAtklbl = new System.Windows.Forms.Label();
            this.playerMagiclbl = new System.Windows.Forms.Label();
            this.playerRageStatuslbl = new System.Windows.Forms.Label();
            this.enemyRageStatuslbl = new System.Windows.Forms.Label();
            this.enemyMagiclbl = new System.Windows.Forms.Label();
            this.enemyAtklbl = new System.Windows.Forms.Label();
            this.bufflbl = new System.Windows.Forms.Label();
            this.waveLeftPic = new System.Windows.Forms.PictureBox();
            this.armDownPic = new System.Windows.Forms.PictureBox();
            this.waveRightPic = new System.Windows.Forms.PictureBox();
            this.rageAbilityPic = new System.Windows.Forms.PictureBox();
            this.youWinlbl = new System.Windows.Forms.Label();
            this.youLoselbl = new System.Windows.Forms.Label();
            this.startAgainlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.characterPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveLeftPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armDownPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveRightPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rageAbilityPic)).BeginInit();
            this.SuspendLayout();
            // 
            // isConnectedLbl
            // 
            this.isConnectedLbl.AutoSize = true;
            this.isConnectedLbl.BackColor = System.Drawing.Color.Black;
            this.isConnectedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isConnectedLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.isConnectedLbl.Location = new System.Drawing.Point(761, 992);
            this.isConnectedLbl.Name = "isConnectedLbl";
            this.isConnectedLbl.Size = new System.Drawing.Size(273, 32);
            this.isConnectedLbl.TabIndex = 0;
            this.isConnectedLbl.Text = "Waiting to connect...";
            // 
            // characterPic
            // 
            this.characterPic.Image = global::MyoFantasyI.Properties.Resources.character;
            this.characterPic.Location = new System.Drawing.Point(236, 231);
            this.characterPic.Name = "characterPic";
            this.characterPic.Size = new System.Drawing.Size(232, 249);
            this.characterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.characterPic.TabIndex = 1;
            this.characterPic.TabStop = false;
            this.characterPic.Visible = false;
            // 
            // howToStartlbl
            // 
            this.howToStartlbl.AutoSize = true;
            this.howToStartlbl.BackColor = System.Drawing.Color.Transparent;
            this.howToStartlbl.Font = new System.Drawing.Font("Sitka Subheading", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToStartlbl.ForeColor = System.Drawing.Color.White;
            this.howToStartlbl.Location = new System.Drawing.Point(634, 840);
            this.howToStartlbl.Name = "howToStartlbl";
            this.howToStartlbl.Size = new System.Drawing.Size(669, 58);
            this.howToStartlbl.TabIndex = 2;
            this.howToStartlbl.Text = "To start the game, use Fist Gesture";
            // 
            // enemyPic
            // 
            this.enemyPic.Location = new System.Drawing.Point(1582, 231);
            this.enemyPic.Name = "enemyPic";
            this.enemyPic.Size = new System.Drawing.Size(232, 249);
            this.enemyPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enemyPic.TabIndex = 3;
            this.enemyPic.TabStop = false;
            this.enemyPic.Visible = false;
            // 
            // playerHP
            // 
            this.playerHP.AutoSize = true;
            this.playerHP.BackColor = System.Drawing.Color.Black;
            this.playerHP.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerHP.ForeColor = System.Drawing.Color.Red;
            this.playerHP.Location = new System.Drawing.Point(240, 199);
            this.playerHP.Name = "playerHP";
            this.playerHP.Size = new System.Drawing.Size(87, 29);
            this.playerHP.TabIndex = 4;
            this.playerHP.Text = "Health: ";
            this.playerHP.Visible = false;
            // 
            // enemyHP
            // 
            this.enemyHP.AutoSize = true;
            this.enemyHP.BackColor = System.Drawing.Color.Black;
            this.enemyHP.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyHP.ForeColor = System.Drawing.Color.Red;
            this.enemyHP.Location = new System.Drawing.Point(1578, 199);
            this.enemyHP.Name = "enemyHP";
            this.enemyHP.Size = new System.Drawing.Size(87, 29);
            this.enemyHP.TabIndex = 5;
            this.enemyHP.Text = "Health: ";
            this.enemyHP.Visible = false;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.BackColor = System.Drawing.Color.Transparent;
            this.statusLbl.Font = new System.Drawing.Font("Sitka Subheading", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.White;
            this.statusLbl.Location = new System.Drawing.Point(624, 811);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(216, 53);
            this.statusLbl.TabIndex = 6;
            this.statusLbl.Text = "Your Move.";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.statusLbl.Visible = false;
            // 
            // attacklbl
            // 
            this.attacklbl.AutoSize = true;
            this.attacklbl.BackColor = System.Drawing.Color.Black;
            this.attacklbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attacklbl.ForeColor = System.Drawing.SystemColors.Control;
            this.attacklbl.Location = new System.Drawing.Point(61, 524);
            this.attacklbl.Name = "attacklbl";
            this.attacklbl.Size = new System.Drawing.Size(84, 174);
            this.attacklbl.TabIndex = 7;
            this.attacklbl.Text = "Attack. \r\n\r\n\r\n\r\n\r\n0 Rage";
            this.attacklbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.attacklbl.Visible = false;
            // 
            // heallbl
            // 
            this.heallbl.AutoSize = true;
            this.heallbl.BackColor = System.Drawing.Color.Black;
            this.heallbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heallbl.ForeColor = System.Drawing.SystemColors.Control;
            this.heallbl.Location = new System.Drawing.Point(492, 524);
            this.heallbl.Name = "heallbl";
            this.heallbl.Size = new System.Drawing.Size(72, 174);
            this.heallbl.TabIndex = 8;
            this.heallbl.Text = "Heal.\r\n\r\n\r\n\r\n\r\n1 Rage";
            this.heallbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.heallbl.Visible = false;
            // 
            // timerlbl
            // 
            this.timerlbl.AutoSize = true;
            this.timerlbl.BackColor = System.Drawing.Color.Black;
            this.timerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerlbl.ForeColor = System.Drawing.SystemColors.Control;
            this.timerlbl.Location = new System.Drawing.Point(428, 931);
            this.timerlbl.Name = "timerlbl";
            this.timerlbl.Size = new System.Drawing.Size(104, 25);
            this.timerlbl.TabIndex = 9;
            this.timerlbl.Text = "Time Left: ";
            this.timerlbl.Visible = false;
            // 
            // enemyRagelbl
            // 
            this.enemyRagelbl.AutoSize = true;
            this.enemyRagelbl.BackColor = System.Drawing.Color.Black;
            this.enemyRagelbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyRagelbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyRagelbl.Location = new System.Drawing.Point(1820, 291);
            this.enemyRagelbl.Name = "enemyRagelbl";
            this.enemyRagelbl.Size = new System.Drawing.Size(70, 29);
            this.enemyRagelbl.TabIndex = 10;
            this.enemyRagelbl.Text = "Rage: ";
            this.enemyRagelbl.Visible = false;
            // 
            // playerRagelbl
            // 
            this.playerRagelbl.AutoSize = true;
            this.playerRagelbl.BackColor = System.Drawing.Color.Black;
            this.playerRagelbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerRagelbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerRagelbl.Location = new System.Drawing.Point(474, 291);
            this.playerRagelbl.Name = "playerRagelbl";
            this.playerRagelbl.Size = new System.Drawing.Size(70, 29);
            this.playerRagelbl.TabIndex = 11;
            this.playerRagelbl.Text = "Rage: ";
            this.playerRagelbl.Visible = false;
            // 
            // rageAbilitylbl
            // 
            this.rageAbilitylbl.AutoSize = true;
            this.rageAbilitylbl.BackColor = System.Drawing.Color.Black;
            this.rageAbilitylbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rageAbilitylbl.ForeColor = System.Drawing.Color.Gold;
            this.rageAbilitylbl.Location = new System.Drawing.Point(251, 748);
            this.rageAbilitylbl.Name = "rageAbilitylbl";
            this.rageAbilitylbl.Size = new System.Drawing.Size(196, 174);
            this.rageAbilitylbl.TabIndex = 12;
            this.rageAbilitylbl.Text = "Rage Ability Active!\r\n\r\n\r\n\r\n\r\n5 Rage";
            this.rageAbilitylbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rageAbilitylbl.Visible = false;
            // 
            // playerAtklbl
            // 
            this.playerAtklbl.AutoSize = true;
            this.playerAtklbl.BackColor = System.Drawing.Color.Black;
            this.playerAtklbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerAtklbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerAtklbl.Location = new System.Drawing.Point(7, 349);
            this.playerAtklbl.Name = "playerAtklbl";
            this.playerAtklbl.Size = new System.Drawing.Size(141, 29);
            this.playerAtklbl.TabIndex = 14;
            this.playerAtklbl.Text = "Max. Attack : ";
            this.playerAtklbl.Visible = false;
            // 
            // playerMagiclbl
            // 
            this.playerMagiclbl.AutoSize = true;
            this.playerMagiclbl.BackColor = System.Drawing.Color.Black;
            this.playerMagiclbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerMagiclbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerMagiclbl.Location = new System.Drawing.Point(9, 383);
            this.playerMagiclbl.Name = "playerMagiclbl";
            this.playerMagiclbl.Size = new System.Drawing.Size(137, 29);
            this.playerMagiclbl.TabIndex = 15;
            this.playerMagiclbl.Text = "Max. Magic : ";
            this.playerMagiclbl.Visible = false;
            // 
            // playerRageStatuslbl
            // 
            this.playerRageStatuslbl.AutoSize = true;
            this.playerRageStatuslbl.BackColor = System.Drawing.Color.Black;
            this.playerRageStatuslbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerRageStatuslbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerRageStatuslbl.Location = new System.Drawing.Point(2, 421);
            this.playerRageStatuslbl.Name = "playerRageStatuslbl";
            this.playerRageStatuslbl.Size = new System.Drawing.Size(143, 29);
            this.playerRageStatuslbl.TabIndex = 16;
            this.playerRageStatuslbl.Text = "Rage Threat : ";
            this.playerRageStatuslbl.Visible = false;
            // 
            // enemyRageStatuslbl
            // 
            this.enemyRageStatuslbl.AutoSize = true;
            this.enemyRageStatuslbl.BackColor = System.Drawing.Color.Black;
            this.enemyRageStatuslbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyRageStatuslbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyRageStatuslbl.Location = new System.Drawing.Point(1341, 421);
            this.enemyRageStatuslbl.Name = "enemyRageStatuslbl";
            this.enemyRageStatuslbl.Size = new System.Drawing.Size(143, 29);
            this.enemyRageStatuslbl.TabIndex = 19;
            this.enemyRageStatuslbl.Text = "Rage Threat : ";
            this.enemyRageStatuslbl.Visible = false;
            // 
            // enemyMagiclbl
            // 
            this.enemyMagiclbl.AutoSize = true;
            this.enemyMagiclbl.BackColor = System.Drawing.Color.Black;
            this.enemyMagiclbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyMagiclbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyMagiclbl.Location = new System.Drawing.Point(1347, 383);
            this.enemyMagiclbl.Name = "enemyMagiclbl";
            this.enemyMagiclbl.Size = new System.Drawing.Size(137, 29);
            this.enemyMagiclbl.TabIndex = 18;
            this.enemyMagiclbl.Text = "Max. Magic : ";
            this.enemyMagiclbl.Visible = false;
            // 
            // enemyAtklbl
            // 
            this.enemyAtklbl.AutoSize = true;
            this.enemyAtklbl.BackColor = System.Drawing.Color.Black;
            this.enemyAtklbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyAtklbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyAtklbl.Location = new System.Drawing.Point(1343, 349);
            this.enemyAtklbl.Name = "enemyAtklbl";
            this.enemyAtklbl.Size = new System.Drawing.Size(141, 29);
            this.enemyAtklbl.TabIndex = 17;
            this.enemyAtklbl.Text = "Max. Attack : ";
            this.enemyAtklbl.Visible = false;
            // 
            // bufflbl
            // 
            this.bufflbl.AutoSize = true;
            this.bufflbl.BackColor = System.Drawing.Color.Black;
            this.bufflbl.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bufflbl.ForeColor = System.Drawing.SystemColors.Control;
            this.bufflbl.Location = new System.Drawing.Point(254, 524);
            this.bufflbl.Name = "bufflbl";
            this.bufflbl.Size = new System.Drawing.Size(173, 174);
            this.bufflbl.TabIndex = 20;
            this.bufflbl.Text = "Buff Your Attack.\r\n\r\n\r\n\r\n\r\n1 Rage";
            this.bufflbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bufflbl.Visible = false;
            // 
            // waveLeftPic
            // 
            this.waveLeftPic.Image = global::MyoFantasyI.Properties.Resources.waveLeft;
            this.waveLeftPic.Location = new System.Drawing.Point(48, 561);
            this.waveLeftPic.Name = "waveLeftPic";
            this.waveLeftPic.Size = new System.Drawing.Size(110, 101);
            this.waveLeftPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.waveLeftPic.TabIndex = 21;
            this.waveLeftPic.TabStop = false;
            this.waveLeftPic.Visible = false;
            // 
            // armDownPic
            // 
            this.armDownPic.Image = global::MyoFantasyI.Properties.Resources.armDown;
            this.armDownPic.Location = new System.Drawing.Point(286, 561);
            this.armDownPic.Name = "armDownPic";
            this.armDownPic.Size = new System.Drawing.Size(111, 101);
            this.armDownPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.armDownPic.TabIndex = 22;
            this.armDownPic.TabStop = false;
            this.armDownPic.Visible = false;
            // 
            // waveRightPic
            // 
            this.waveRightPic.Image = global::MyoFantasyI.Properties.Resources.waveRight;
            this.waveRightPic.Location = new System.Drawing.Point(479, 561);
            this.waveRightPic.Name = "waveRightPic";
            this.waveRightPic.Size = new System.Drawing.Size(110, 101);
            this.waveRightPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.waveRightPic.TabIndex = 23;
            this.waveRightPic.TabStop = false;
            this.waveRightPic.Visible = false;
            // 
            // rageAbilityPic
            // 
            this.rageAbilityPic.Image = global::MyoFantasyI.Properties.Resources.rageAbilityPic;
            this.rageAbilityPic.Location = new System.Drawing.Point(173, 784);
            this.rageAbilityPic.Name = "rageAbilityPic";
            this.rageAbilityPic.Size = new System.Drawing.Size(340, 93);
            this.rageAbilityPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rageAbilityPic.TabIndex = 24;
            this.rageAbilityPic.TabStop = false;
            this.rageAbilityPic.Visible = false;
            // 
            // youWinlbl
            // 
            this.youWinlbl.AutoSize = true;
            this.youWinlbl.BackColor = System.Drawing.Color.Transparent;
            this.youWinlbl.Font = new System.Drawing.Font("Sitka Subheading", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youWinlbl.ForeColor = System.Drawing.Color.White;
            this.youWinlbl.Location = new System.Drawing.Point(846, 817);
            this.youWinlbl.Name = "youWinlbl";
            this.youWinlbl.Size = new System.Drawing.Size(284, 87);
            this.youWinlbl.TabIndex = 25;
            this.youWinlbl.Text = "You win!";
            this.youWinlbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.youWinlbl.Visible = false;
            // 
            // youLoselbl
            // 
            this.youLoselbl.AutoSize = true;
            this.youLoselbl.BackColor = System.Drawing.Color.Transparent;
            this.youLoselbl.Font = new System.Drawing.Font("Sitka Subheading", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youLoselbl.ForeColor = System.Drawing.Color.White;
            this.youLoselbl.Location = new System.Drawing.Point(846, 833);
            this.youLoselbl.Name = "youLoselbl";
            this.youLoselbl.Size = new System.Drawing.Size(305, 87);
            this.youLoselbl.TabIndex = 26;
            this.youLoselbl.Text = "You Lose!";
            this.youLoselbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.youLoselbl.Visible = false;
            // 
            // startAgainlbl
            // 
            this.startAgainlbl.AutoSize = true;
            this.startAgainlbl.BackColor = System.Drawing.Color.Transparent;
            this.startAgainlbl.Font = new System.Drawing.Font("Sitka Subheading", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startAgainlbl.ForeColor = System.Drawing.Color.White;
            this.startAgainlbl.Location = new System.Drawing.Point(634, 920);
            this.startAgainlbl.Name = "startAgainlbl";
            this.startAgainlbl.Size = new System.Drawing.Size(669, 58);
            this.startAgainlbl.TabIndex = 27;
            this.startAgainlbl.Text = "To start the game, use Fist Gesture";
            this.startAgainlbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyoFantasyI.Properties.Resources.newBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.startAgainlbl);
            this.Controls.Add(this.youLoselbl);
            this.Controls.Add(this.youWinlbl);
            this.Controls.Add(this.waveLeftPic);
            this.Controls.Add(this.rageAbilityPic);
            this.Controls.Add(this.waveRightPic);
            this.Controls.Add(this.armDownPic);
            this.Controls.Add(this.enemyRageStatuslbl);
            this.Controls.Add(this.enemyMagiclbl);
            this.Controls.Add(this.enemyAtklbl);
            this.Controls.Add(this.playerRageStatuslbl);
            this.Controls.Add(this.playerMagiclbl);
            this.Controls.Add(this.playerAtklbl);
            this.Controls.Add(this.playerRagelbl);
            this.Controls.Add(this.enemyRagelbl);
            this.Controls.Add(this.timerlbl);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.enemyHP);
            this.Controls.Add(this.playerHP);
            this.Controls.Add(this.enemyPic);
            this.Controls.Add(this.howToStartlbl);
            this.Controls.Add(this.characterPic);
            this.Controls.Add(this.isConnectedLbl);
            this.Controls.Add(this.attacklbl);
            this.Controls.Add(this.bufflbl);
            this.Controls.Add(this.heallbl);
            this.Controls.Add(this.rageAbilitylbl);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "Myo Fantasy I";
            ((System.ComponentModel.ISupportInitialize)(this.characterPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveLeftPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armDownPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveRightPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rageAbilityPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label isConnectedLbl;
        private System.Windows.Forms.PictureBox characterPic;
        private System.Windows.Forms.Label howToStartlbl;
        private System.Windows.Forms.PictureBox enemyPic;
        private System.Windows.Forms.Label playerHP;
        private System.Windows.Forms.Label enemyHP;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label attacklbl;
        private System.Windows.Forms.Label heallbl;
        private System.Windows.Forms.Label timerlbl;
        private System.Windows.Forms.Label enemyRagelbl;
        private System.Windows.Forms.Label playerRagelbl;
        private System.Windows.Forms.Label rageAbilitylbl;
        private System.Windows.Forms.Label playerAtklbl;
        private System.Windows.Forms.Label playerMagiclbl;
        private System.Windows.Forms.Label playerRageStatuslbl;
        private System.Windows.Forms.Label enemyRageStatuslbl;
        private System.Windows.Forms.Label enemyMagiclbl;
        private System.Windows.Forms.Label enemyAtklbl;
        private System.Windows.Forms.Label bufflbl;
        private System.Windows.Forms.PictureBox waveLeftPic;
        private System.Windows.Forms.PictureBox armDownPic;
        private System.Windows.Forms.PictureBox waveRightPic;
        private System.Windows.Forms.PictureBox rageAbilityPic;
        private System.Windows.Forms.Label youWinlbl;
        private System.Windows.Forms.Label youLoselbl;
        private System.Windows.Forms.Label startAgainlbl;
    }
}

