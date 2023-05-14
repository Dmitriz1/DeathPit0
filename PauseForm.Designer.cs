namespace DeathPitTest
{
    partial class PauseForm
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
            ContinueButton = new System.Windows.Forms.Button();
            OptionsButton = new System.Windows.Forms.Button();
            ExitButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ContinueButton
            // 
            ContinueButton.Location = new System.Drawing.Point(74, 106);
            ContinueButton.Name = "ContinueButton";
            ContinueButton.Size = new System.Drawing.Size(338, 44);
            ContinueButton.TabIndex = 0;
            ContinueButton.Text = "Продолжить";
            ContinueButton.UseVisualStyleBackColor = true;
            ContinueButton.Click += ContinueButton_Click;
            // 
            // OptionsButton
            // 
            OptionsButton.Location = new System.Drawing.Point(74, 197);
            OptionsButton.Name = "OptionsButton";
            OptionsButton.Size = new System.Drawing.Size(338, 44);
            OptionsButton.TabIndex = 3;
            OptionsButton.Text = "Настройки";
            OptionsButton.UseVisualStyleBackColor = true;
            OptionsButton.Click += OptionsButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new System.Drawing.Point(74, 284);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new System.Drawing.Size(338, 44);
            ExitButton.TabIndex = 4;
            ExitButton.Text = "Выйти в главное меню";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.SystemColors.Window;
            label1.Image = Properties.Resources.bg;
            label1.Location = new System.Drawing.Point(1, -3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 41);
            label1.TabIndex = 5;
            label1.Text = "Пауза";
            // 
            // PauseForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new System.Drawing.Size(480, 404);
            Controls.Add(label1);
            Controls.Add(ExitButton);
            Controls.Add(OptionsButton);
            Controls.Add(ContinueButton);
            Name = "PauseForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
    }
}