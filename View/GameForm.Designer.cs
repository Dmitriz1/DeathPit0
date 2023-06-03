
namespace DeathPitTest
{
    partial class GameForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            GameTimer = new System.Windows.Forms.Timer(components);
            labelAmmo = new System.Windows.Forms.Label();
            labelScore = new System.Windows.Forms.Label();
            labelHP = new System.Windows.Forms.Label();
            labelWeapon = new System.Windows.Forms.Label();
            pictureBoxWeapon = new System.Windows.Forms.PictureBox();
            pictureBoxHealth1 = new System.Windows.Forms.PictureBox();
            pictureBoxHealth2 = new System.Windows.Forms.PictureBox();
            pictureBoxHealth3 = new System.Windows.Forms.PictureBox();
            Player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWeapon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHealth1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHealth2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHealth3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // labelAmmo
            // 
            labelAmmo.AutoSize = true;
            labelAmmo.BackColor = System.Drawing.Color.Transparent;
            labelAmmo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAmmo.Location = new System.Drawing.Point(1, 9);
            labelAmmo.Name = "labelAmmo";
            labelAmmo.Size = new System.Drawing.Size(98, 17);
            labelAmmo.TabIndex = 0;
            labelAmmo.Text = "Аммуниция: 0";
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.BackColor = System.Drawing.Color.Transparent;
            labelScore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelScore.Location = new System.Drawing.Point(119, 9);
            labelScore.Name = "labelScore";
            labelScore.Size = new System.Drawing.Size(52, 17);
            labelScore.TabIndex = 1;
            labelScore.Text = "Счет: 0";
            // 
            // labelHP
            // 
            labelHP.AutoSize = true;
            labelHP.BackColor = System.Drawing.Color.Transparent;
            labelHP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHP.Location = new System.Drawing.Point(196, 9);
            labelHP.Name = "labelHP";
            labelHP.Size = new System.Drawing.Size(73, 17);
            labelHP.TabIndex = 2;
            labelHP.Text = "Здоровье:";
            // 
            // labelWeapon
            // 
            labelWeapon.AutoSize = true;
            labelWeapon.BackColor = System.Drawing.Color.Transparent;
            labelWeapon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelWeapon.Location = new System.Drawing.Point(491, 9);
            labelWeapon.Name = "labelWeapon";
            labelWeapon.Size = new System.Drawing.Size(63, 17);
            labelWeapon.TabIndex = 3;
            labelWeapon.Text = "Оружие:";
            // 
            // pictureBoxWeapon
            // 
            pictureBoxWeapon.BackColor = System.Drawing.Color.Transparent;
            pictureBoxWeapon.Image = (System.Drawing.Image)resources.GetObject("pictureBoxWeapon.Image");
            pictureBoxWeapon.Location = new System.Drawing.Point(560, 0);
            pictureBoxWeapon.Name = "pictureBoxWeapon";
            pictureBoxWeapon.Size = new System.Drawing.Size(62, 33);
            pictureBoxWeapon.TabIndex = 4;
            pictureBoxWeapon.TabStop = false;
            // 
            // pictureBoxHealth1
            // 
            pictureBoxHealth1.BackColor = System.Drawing.Color.Transparent;
            pictureBoxHealth1.Image = Properties.Resources.fullHurt;
            pictureBoxHealth1.Location = new System.Drawing.Point(275, 0);
            pictureBoxHealth1.Name = "pictureBoxHealth1";
            pictureBoxHealth1.Size = new System.Drawing.Size(33, 33);
            pictureBoxHealth1.TabIndex = 5;
            pictureBoxHealth1.TabStop = false;
            // 
            // pictureBoxHealth2
            // 
            pictureBoxHealth2.BackColor = System.Drawing.Color.Transparent;
            pictureBoxHealth2.Image = Properties.Resources.fullHurt;
            pictureBoxHealth2.Location = new System.Drawing.Point(314, 0);
            pictureBoxHealth2.Name = "pictureBoxHealth2";
            pictureBoxHealth2.Size = new System.Drawing.Size(33, 33);
            pictureBoxHealth2.TabIndex = 6;
            pictureBoxHealth2.TabStop = false;
            // 
            // pictureBoxHealth3
            // 
            pictureBoxHealth3.BackColor = System.Drawing.Color.Transparent;
            pictureBoxHealth3.Image = Properties.Resources.fullHurt;
            pictureBoxHealth3.Location = new System.Drawing.Point(353, 0);
            pictureBoxHealth3.Name = "pictureBoxHealth3";
            pictureBoxHealth3.Size = new System.Drawing.Size(33, 33);
            pictureBoxHealth3.TabIndex = 7;
            pictureBoxHealth3.TabStop = false;
            // 
            // Player
            // 
            Player.BackColor = System.Drawing.Color.Transparent;
            Player.Image = Properties.Resources.HeroPistolUp;
            Player.Location = new System.Drawing.Point(275, 124);
            Player.Name = "Player";
            Player.Size = new System.Drawing.Size(64, 86);
            Player.TabIndex = 8;
            Player.TabStop = false;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GrayText;
            ClientSize = new System.Drawing.Size(698, 417);
            Controls.Add(Player);
            Controls.Add(labelAmmo);
            Controls.Add(labelScore);
            Controls.Add(labelWeapon);
            Controls.Add(pictureBoxWeapon);
            Controls.Add(pictureBoxHealth1);
            Controls.Add(pictureBoxHealth3);
            Controls.Add(pictureBoxHealth2);
            Controls.Add(labelHP);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "GameForm";
            Text = "DeathPit";
            KeyDown += GameForm_KeyDown;
            KeyUp += GameForm_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBoxWeapon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHealth1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHealth2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHealth3).EndInit();
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void GameForm_KeyUp1(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label labelAmmo;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.Label labelWeapon;
        private System.Windows.Forms.PictureBox pictureBoxWeapon;
        private System.Windows.Forms.PictureBox pictureBoxHealth1;
        private System.Windows.Forms.PictureBox pictureBoxHealth2;
        private System.Windows.Forms.PictureBox pictureBoxHealth3;
        private System.Windows.Forms.PictureBox Player;
    }
}