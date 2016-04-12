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
            this.characterPic.Location = new System.Drawing.Point(993, 317);
            this.characterPic.Name = "characterPic";
            this.characterPic.Size = new System.Drawing.Size(151, 178);
            this.characterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.characterPic.TabIndex = 1;
            this.characterPic.TabStop = false;
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
            this.enemyPic.Location = new System.Drawing.Point(993, 12);
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
            this.playerHP.Location = new System.Drawing.Point(988, 289);
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
            this.enemyHP.Location = new System.Drawing.Point(988, 204);
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
            this.statusLbl.Location = new System.Drawing.Point(832, 246);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(73, 25);
            this.statusLbl.TabIndex = 6;
            this.statusLbl.Text = "Status.";
            this.statusLbl.Visible = false;
            // 
            // attacklbl
            // 
            this.attacklbl.AutoSize = true;
            this.attacklbl.BackColor = System.Drawing.Color.Black;
            this.attacklbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attacklbl.ForeColor = System.Drawing.SystemColors.Control;
            this.attacklbl.Location = new System.Drawing.Point(854, 521);
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
            this.heallbl.Location = new System.Drawing.Point(1102, 521);
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
            this.enemyRagelbl.Location = new System.Drawing.Point(1150, 84);
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
            this.playerRagelbl.Location = new System.Drawing.Point(1150, 353);
            this.playerRagelbl.Name = "playerRagelbl";
            this.playerRagelbl.Size = new System.Drawing.Size(69, 25);
            this.playerRagelbl.TabIndex = 11;
            this.playerRagelbl.Text = "Rage: ";
            this.playerRagelbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyoFantasyI.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1349, 643);
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
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

