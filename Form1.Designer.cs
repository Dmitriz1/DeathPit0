namespace DeathPitTest
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.ButtonOptions = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.Location = new System.Drawing.Point(30, 55);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(162, 51);
            this.ButtonPlay.TabIndex = 0;
            this.ButtonPlay.Text = "Играть";
            this.ButtonPlay.UseVisualStyleBackColor = true;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // ButtonOptions
            // 
            this.ButtonOptions.Location = new System.Drawing.Point(30, 151);
            this.ButtonOptions.Name = "ButtonOptions";
            this.ButtonOptions.Size = new System.Drawing.Size(162, 51);
            this.ButtonOptions.TabIndex = 1;
            this.ButtonOptions.Text = "Настройки";
            this.ButtonOptions.UseVisualStyleBackColor = true;
            this.ButtonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(30, 245);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(162, 51);
            this.ButtonExit.TabIndex = 2;
            this.ButtonExit.Text = "Выйти из игры";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::DeathPitTest.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(815, 483);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonOptions);
            this.Controls.Add(this.ButtonPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "FormMenu";
            this.Text = "DeathPit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonPlay;
        private System.Windows.Forms.Button ButtonOptions;
        private System.Windows.Forms.Button ButtonExit;
    }
}
