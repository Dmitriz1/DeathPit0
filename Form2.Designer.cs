
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);

            this.labelAmmo = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelHP = new System.Windows.Forms.Label();
            this.labelWeapon = new System.Windows.Forms.Label();
            this.pictureBoxWeapon = new System.Windows.Forms.PictureBox();
            this.pictureBoxHealth1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHealth2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHealth3 = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeapon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHealth1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHealth2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHealth3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Tick += GameTimerEvent;
            this.GameTimer.Interval = 20;
            // 
            // labelAmmo
            // 
            this.labelAmmo.AutoSize = true;
            this.labelAmmo.BackColor = System.Drawing.Color.Transparent;
            this.labelAmmo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAmmo.Location = new System.Drawing.Point(1, 9);
            this.labelAmmo.Name = "labelAmmo";
            this.labelAmmo.Size = new System.Drawing.Size(98, 17);
            this.labelAmmo.TabIndex = 0;
            this.labelAmmo.Text = "Аммуниция: 0";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore.Location = new System.Drawing.Point(119, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(52, 17);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Счет: 0";
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.BackColor = System.Drawing.Color.Transparent;
            this.labelHP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHP.Location = new System.Drawing.Point(196, 9);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(73, 17);
            this.labelHP.TabIndex = 2;
            this.labelHP.Text = "Здоровье:";
            // 
            // labelWeapon
            // 
            this.labelWeapon.AutoSize = true;
            this.labelWeapon.BackColor = System.Drawing.Color.Transparent;
            this.labelWeapon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWeapon.Location = new System.Drawing.Point(491, 9);
            this.labelWeapon.Name = "labelWeapon";
            this.labelWeapon.Size = new System.Drawing.Size(63, 17);
            this.labelWeapon.TabIndex = 3;
            this.labelWeapon.Text = "Оружие:";
            // 
            // pictureBoxWeapon
            // 
            this.pictureBoxWeapon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWeapon.Image = global::DeathPitTest.Properties.Resources.Pistol;
            this.pictureBoxWeapon.Location = new System.Drawing.Point(560, 0);
            this.pictureBoxWeapon.Name = "pictureBoxWeapon";
            this.pictureBoxWeapon.Size = new System.Drawing.Size(62, 33);
            this.pictureBoxWeapon.TabIndex = 4;
            this.pictureBoxWeapon.TabStop = false;
            // 
            // pictureBoxHealth1
            // 
            this.pictureBoxHealth1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHealth1.Image = global::DeathPitTest.Properties.Resources.fullHurt;
            this.pictureBoxHealth1.Location = new System.Drawing.Point(275, 0);
            this.pictureBoxHealth1.Name = "pictureBoxHealth1";
            this.pictureBoxHealth1.Size = new System.Drawing.Size(33, 33);
            this.pictureBoxHealth1.TabIndex = 5;
            this.pictureBoxHealth1.TabStop = false;
            // 
            // pictureBoxHealth2
            // 
            this.pictureBoxHealth2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHealth2.Image = global::DeathPitTest.Properties.Resources.fullHurt;
            this.pictureBoxHealth2.Location = new System.Drawing.Point(314, 0);
            this.pictureBoxHealth2.Name = "pictureBoxHealth2";
            this.pictureBoxHealth2.Size = new System.Drawing.Size(33, 33);
            this.pictureBoxHealth2.TabIndex = 6;
            this.pictureBoxHealth2.TabStop = false;
            // 
            // pictureBoxHealth3
            // 
            this.pictureBoxHealth3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHealth3.Image = global::DeathPitTest.Properties.Resources.fullHurt;
            this.pictureBoxHealth3.Location = new System.Drawing.Point(353, 0);
            this.pictureBoxHealth3.Name = "pictureBoxHealth3";
            this.pictureBoxHealth3.Size = new System.Drawing.Size(33, 33);
            this.pictureBoxHealth3.TabIndex = 7;
            this.pictureBoxHealth3.TabStop = false;
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = global::DeathPitTest.Properties.Resources.HeroPistolUp;
            this.Player.Location = new System.Drawing.Point(275, 124);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(64, 86);
            this.Player.TabIndex = 8;
            this.Player.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(698, 417);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.labelAmmo);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelWeapon);
            this.Controls.Add(this.pictureBoxWeapon);
            this.Controls.Add(this.pictureBoxHealth1);
            this.Controls.Add(this.pictureBoxHealth3);
            this.Controls.Add(this.pictureBoxHealth2);
            this.Controls.Add(this.labelHP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.Text = "DeathPit";
            Load += GameForm_Load;
            KeyDown += GameForm_KeyDown;
            KeyUp += GameForm_KeyUp;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWeapon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHealth1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHealth2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHealth3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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