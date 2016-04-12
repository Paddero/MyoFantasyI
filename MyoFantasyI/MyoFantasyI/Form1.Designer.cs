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
            ((System.ComponentModel.ISupportInitialize)(this.characterPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPic)).BeginInit();
            this.SuspendLayout();
            // 
            // isConnectedLbl
            // 
            this.isConnectedLbl.AutoSize = true;
            this.isConnectedLbl.BackColor = System.Drawing.Color.Black;
            this.isConnectedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isConnectedLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.isConnectedLbl.Location = new System.Drawing.Point(175, 587);
            this.isConnectedLbl.Name = "isConnectedLbl";
            this.isConnectedLbl.Size = new System.Drawing.Size(273, 32);
            this.isConnectedLbl.TabIndex = 0;
            this.isConnectedLbl.Text = "Waiting to connect...";
            // 
            // characterPic
            // 
            this.characterPic.Image = global::MyoFantasyI.Properties.Resources.character;
            this.characterPic.Location = new System.Drawing.Point(1539, 660);
            this.characterPic.Name = "characterPic";
            this.characterPic.Size = new System.Drawing.Size(151, 178);
            this.characterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.characterPic.TabIndex = 1;
            this.characterPic.TabStop = false;
            this.characterPic.Visible = false;
            // 
            // howToStartlbl
            // 
            this.howToStartlbl.AutoSize = true;
            this.howToStartlbl.BackColor = System.Drawing.Color.Black;
            this.howToStartlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToStartlbl.ForeColor = System.Drawing.SystemColors.Control;
            this.howToStartlbl.Location = new System.Drawing.Point(290, 353);
            this.howToStartlbl.Name = "howToStartlbl";
            this.howToStartlbl.Size = new System.Drawing.Size(252, 20);
            this.howToStartlbl.TabIndex = 2;
            this.howToStartlbl.Text = "Use gesture Fist to start playing.";
            // 
            // enemyPic
            // 
            this.enemyPic.Location = new System.Drawing.Point(1442, 21);
            this.enemyPic.Name = "enemyPic";
            this.enemyPic.Size = new System.Drawing.Size(151, 189);
            this.enemyPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enemyPic.TabIndex = 3;
            this.enemyPic.TabStop = false;
            this.enemyPic.Visible = false;
            // 
            // playerHP
            // 
            this.playerHP.AutoSize = true;
            this.playerHP.BackColor = System.Drawing.Color.Black;
            this.playerHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerHP.ForeColor = System.Drawing.SystemColors.Control;
            this.playerHP.Location = new System.Drawing.Point(1534, 632);
            this.playerHP.Name = "playerHP";
            this.playerHP.Size = new System.Drawing.Size(79, 25);
            this.playerHP.TabIndex = 4;
            this.playerHP.Text = "Health: ";
            this.playerHP.Visible = false;
            // 
            // enemyHP
            // 
            this.enemyHP.AutoSize = true;
            this.enemyHP.BackColor = System.Drawing.Color.Black;
            this.enemyHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyHP.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyHP.Location = new System.Drawing.Point(1437, 213);
            this.enemyHP.Name = "enemyHP";
            this.enemyHP.Size = new System.Drawing.Size(79, 25);
            this.enemyHP.TabIndex = 5;
            this.enemyHP.Text = "Health: ";
            this.enemyHP.Visible = false;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.BackColor = System.Drawing.Color.Black;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLbl.Location = new System.Drawing.Point(1313, 375);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(112, 25);
            this.statusLbl.TabIndex = 6;
            this.statusLbl.Text = "Your Move.";
            this.statusLbl.Visible = false;
            // 
            // attacklbl
            // 
            this.attacklbl.AutoSize = true;
            this.attacklbl.BackColor = System.Drawing.Color.Black;
            this.attacklbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attacklbl.ForeColor = System.Drawing.SystemColors.Control;
            this.attacklbl.Location = new System.Drawing.Point(1325, 884);
            this.attacklbl.Name = "attacklbl";
            this.attacklbl.Size = new System.Drawing.Size(175, 75);
            this.attacklbl.TabIndex = 7;
            this.attacklbl.Text = "         Attack.\r\n\r\n(Wave-In Gesture)";
            this.attacklbl.Visible = false;
            // 
            // heallbl
            // 
            this.heallbl.AutoSize = true;
            this.heallbl.BackColor = System.Drawing.Color.Black;
            this.heallbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heallbl.ForeColor = System.Drawing.SystemColors.Control;
            this.heallbl.Location = new System.Drawing.Point(1696, 894);
            this.heallbl.Name = "heallbl";
            this.heallbl.Size = new System.Drawing.Size(191, 75);
            this.heallbl.TabIndex = 8;
            this.heallbl.Text = "         Heal Yourself.\r\n\r\n(Wave-Out Gesture)";
            this.heallbl.Visible = false;
            // 
            // timerlbl
            // 
            this.timerlbl.AutoSize = true;
            this.timerlbl.BackColor = System.Drawing.Color.Black;
            this.timerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerlbl.ForeColor = System.Drawing.SystemColors.Control;
            this.timerlbl.Location = new System.Drawing.Point(651, 194);
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
            this.enemyRagelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyRagelbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyRagelbl.Location = new System.Drawing.Point(1599, 93);
            this.enemyRagelbl.Name = "enemyRagelbl";
            this.enemyRagelbl.Size = new System.Drawing.Size(69, 25);
            this.enemyRagelbl.TabIndex = 10;
            this.enemyRagelbl.Text = "Rage: ";
            this.enemyRagelbl.Visible = false;
            // 
            // playerRagelbl
            // 
            this.playerRagelbl.AutoSize = true;
            this.playerRagelbl.BackColor = System.Drawing.Color.Black;
            this.playerRagelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerRagelbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerRagelbl.Location = new System.Drawing.Point(1696, 696);
            this.playerRagelbl.Name = "playerRagelbl";
            this.playerRagelbl.Size = new System.Drawing.Size(69, 25);
            this.playerRagelbl.TabIndex = 11;
            this.playerRagelbl.Text = "Rage: ";
            this.playerRagelbl.Visible = false;
            // 
            // rageAbilitylbl
            // 
            this.rageAbilitylbl.AutoSize = true;
            this.rageAbilitylbl.BackColor = System.Drawing.Color.Black;
            this.rageAbilitylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rageAbilitylbl.ForeColor = System.Drawing.Color.Maroon;
            this.rageAbilitylbl.Location = new System.Drawing.Point(1528, 841);
            this.rageAbilitylbl.Name = "rageAbilitylbl";
            this.rageAbilitylbl.Size = new System.Drawing.Size(165, 175);
            this.rageAbilitylbl.TabIndex = 12;
            this.rageAbilitylbl.Text = "         RAGE.\r\n  Attack and Heal.\r\n\r\n     Sequence\r\n(Fist -> \r\nDouble Tap -> \r\nF" +
    "ingerspread)";
            this.rageAbilitylbl.Visible = false;
            // 
            // playerAtklbl
            // 
            this.playerAtklbl.AutoSize = true;
            this.playerAtklbl.BackColor = System.Drawing.Color.Black;
            this.playerAtklbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerAtklbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerAtklbl.Location = new System.Drawing.Point(1277, 679);
            this.playerAtklbl.Name = "playerAtklbl";
            this.playerAtklbl.Size = new System.Drawing.Size(131, 25);
            this.playerAtklbl.TabIndex = 14;
            this.playerAtklbl.Text = "Max. Attack : ";
            this.playerAtklbl.Visible = false;
            // 
            // playerMagiclbl
            // 
            this.playerMagiclbl.AutoSize = true;
            this.playerMagiclbl.BackColor = System.Drawing.Color.Black;
            this.playerMagiclbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerMagiclbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerMagiclbl.Location = new System.Drawing.Point(1279, 713);
            this.playerMagiclbl.Name = "playerMagiclbl";
            this.playerMagiclbl.Size = new System.Drawing.Size(129, 25);
            this.playerMagiclbl.TabIndex = 15;
            this.playerMagiclbl.Text = "Max. Magic : ";
            this.playerMagiclbl.Visible = false;
            // 
            // playerRageStatuslbl
            // 
            this.playerRageStatuslbl.AutoSize = true;
            this.playerRageStatuslbl.BackColor = System.Drawing.Color.Black;
            this.playerRageStatuslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerRageStatuslbl.ForeColor = System.Drawing.SystemColors.Control;
            this.playerRageStatuslbl.Location = new System.Drawing.Point(1272, 751);
            this.playerRageStatuslbl.Name = "playerRageStatuslbl";
            this.playerRageStatuslbl.Size = new System.Drawing.Size(136, 25);
            this.playerRageStatuslbl.TabIndex = 16;
            this.playerRageStatuslbl.Text = "Rage Threat : ";
            this.playerRageStatuslbl.Visible = false;
            // 
            // enemyRageStatuslbl
            // 
            this.enemyRageStatuslbl.AutoSize = true;
            this.enemyRageStatuslbl.BackColor = System.Drawing.Color.Black;
            this.enemyRageStatuslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyRageStatuslbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyRageStatuslbl.Location = new System.Drawing.Point(1195, 127);
            this.enemyRageStatuslbl.Name = "enemyRageStatuslbl";
            this.enemyRageStatuslbl.Size = new System.Drawing.Size(136, 25);
            this.enemyRageStatuslbl.TabIndex = 19;
            this.enemyRageStatuslbl.Text = "Rage Threat : ";
            this.enemyRageStatuslbl.Visible = false;
            // 
            // enemyMagiclbl
            // 
            this.enemyMagiclbl.AutoSize = true;
            this.enemyMagiclbl.BackColor = System.Drawing.Color.Black;
            this.enemyMagiclbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyMagiclbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyMagiclbl.Location = new System.Drawing.Point(1202, 93);
            this.enemyMagiclbl.Name = "enemyMagiclbl";
            this.enemyMagiclbl.Size = new System.Drawing.Size(129, 25);
            this.enemyMagiclbl.TabIndex = 18;
            this.enemyMagiclbl.Text = "Max. Magic : ";
            this.enemyMagiclbl.Visible = false;
            // 
            // enemyAtklbl
            // 
            this.enemyAtklbl.AutoSize = true;
            this.enemyAtklbl.BackColor = System.Drawing.Color.Black;
            this.enemyAtklbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyAtklbl.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyAtklbl.Location = new System.Drawing.Point(1200, 56);
            this.enemyAtklbl.Name = "enemyAtklbl";
            this.enemyAtklbl.Size = new System.Drawing.Size(131, 25);
            this.enemyAtklbl.TabIndex = 17;
            this.enemyAtklbl.Text = "Max. Attack : ";
            this.enemyAtklbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyoFantasyI.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.enemyRageStatuslbl);
            this.Controls.Add(this.enemyMagiclbl);
            this.Controls.Add(this.enemyAtklbl);
            this.Controls.Add(this.playerRageStatuslbl);
            this.Controls.Add(this.playerMagiclbl);
            this.Controls.Add(this.playerAtklbl);
            this.Controls.Add(this.rageAbilitylbl);
            this.Controls.Add(this.playerRagelbl);
            this.Controls.Add(this.enemyRagelbl);
            this.Controls.Add(this.timerlbl);
            this.Controls.Add(this.heallbl);
            this.Controls.Add(this.attacklbl);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.enemyHP);
            this.Controls.Add(this.playerHP);
            this.Controls.Add(this.enemyPic);
            this.Controls.Add(this.howToStartlbl);
            this.Controls.Add(this.characterPic);
            this.Controls.Add(this.isConnectedLbl);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "Myo Fantasy I";
            ((System.ComponentModel.ISupportInitialize)(this.characterPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPic)).EndInit();
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
    }
}

