
namespace amgl.main
{
    partial class MainForm
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
            this.InstallDirLabel = new System.Windows.Forms.Label();
            this.InstallDirText = new System.Windows.Forms.TextBox();
            this.InstallButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // InstallDirLabel
            // 
            this.InstallDirLabel.Location = new System.Drawing.Point(3, 3);
            this.InstallDirLabel.Margin = new System.Windows.Forms.Padding(0);
            this.InstallDirLabel.Name = "InstallDirLabel";
            this.InstallDirLabel.Padding = new System.Windows.Forms.Padding(3);
            this.InstallDirLabel.Size = new System.Drawing.Size(256, 26);
            this.InstallDirLabel.TabIndex = 0;
            this.InstallDirLabel.Text = "Installation Directory:";
            // 
            // InstallDirText
            // 
            this.InstallDirText.CausesValidation = false;
            this.InstallDirText.Location = new System.Drawing.Point(259, 3);
            this.InstallDirText.Margin = new System.Windows.Forms.Padding(0);
            this.InstallDirText.Name = "InstallDirText";
            this.InstallDirText.ReadOnly = true;
            this.InstallDirText.Size = new System.Drawing.Size(512, 26);
            this.InstallDirText.TabIndex = 1;
            this.InstallDirText.TabStop = false;
            // 
            // InstallButton
            // 
            this.InstallButton.Enabled = false;
            this.InstallButton.Location = new System.Drawing.Point(3, 32);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(256, 256);
            this.InstallButton.TabIndex = 2;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = true;
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(259, 32);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(256, 256);
            this.PlayButton.TabIndex = 3;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(515, 32);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(256, 256);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Location = new System.Drawing.Point(3, 291);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Padding = new System.Windows.Forms.Padding(3);
            this.MessageLabel.Size = new System.Drawing.Size(768, 26);
            this.MessageLabel.TabIndex = 5;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(3, 323);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.ProgressBar.Maximum = 1000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(768, 23);
            this.ProgressBar.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 351);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.InstallDirText);
            this.Controls.Add(this.InstallDirLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMGL Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label InstallDirLabel;
        public System.Windows.Forms.TextBox InstallDirText;
        public System.Windows.Forms.Button InstallButton;
        public System.Windows.Forms.Button PlayButton;
        public System.Windows.Forms.Button ExitButton;
        public System.Windows.Forms.Label MessageLabel;
        public System.Windows.Forms.ProgressBar ProgressBar;
    }
}