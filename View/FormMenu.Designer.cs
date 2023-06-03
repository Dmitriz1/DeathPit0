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
            ButtonPlay = new System.Windows.Forms.Button();
            ButtonOptions = new System.Windows.Forms.Button();
            ButtonExit = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ButtonPlay
            // 
            ButtonPlay.Location = new System.Drawing.Point(34, 73);
            ButtonPlay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ButtonPlay.Name = "ButtonPlay";
            ButtonPlay.Size = new System.Drawing.Size(185, 68);
            ButtonPlay.TabIndex = 0;
            ButtonPlay.Text = "Играть";
            ButtonPlay.UseVisualStyleBackColor = true;
            ButtonPlay.Click += ButtonPlay_Click;
            // 
            // ButtonOptions
            // 
            ButtonOptions.Location = new System.Drawing.Point(34, 201);
            ButtonOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ButtonOptions.Name = "ButtonOptions";
            ButtonOptions.Size = new System.Drawing.Size(185, 68);
            ButtonOptions.TabIndex = 1;
            ButtonOptions.Text = "Обучение";
            ButtonOptions.UseVisualStyleBackColor = true;
            ButtonOptions.Click += buttonOptions_Click;
            // 
            // ButtonExit
            // 
            ButtonExit.Location = new System.Drawing.Point(34, 327);
            ButtonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new System.Drawing.Size(185, 68);
            ButtonExit.TabIndex = 2;
            ButtonExit.Text = "Выйти из игры";
            ButtonExit.UseVisualStyleBackColor = true;
            ButtonExit.Click += buttonExit_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new System.Drawing.Size(931, 644);
            Controls.Add(ButtonExit);
            Controls.Add(ButtonOptions);
            Controls.Add(ButtonPlay);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(2192, 1424);
            Name = "FormMenu";
            Text = "DeathPit";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button ButtonPlay;
        private System.Windows.Forms.Button ButtonOptions;
        private System.Windows.Forms.Button ButtonExit;
    }
}
