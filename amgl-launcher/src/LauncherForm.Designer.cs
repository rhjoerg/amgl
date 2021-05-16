namespace amgl_launcher
{
    partial class LauncherForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryLabel = new System.Windows.Forms.Label();
            this.instalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directoryLabel
            // 
            this.directoryLabel.Location = new System.Drawing.Point(13, 13);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(400, 13);
            this.directoryLabel.TabIndex = 0;
            // 
            // instalButton
            // 
            this.instalButton.Location = new System.Drawing.Point(13, 42);
            this.instalButton.Name = "instalButton";
            this.instalButton.Size = new System.Drawing.Size(75, 23);
            this.instalButton.TabIndex = 1;
            this.instalButton.Text = "Install";
            this.instalButton.UseVisualStyleBackColor = true;
            this.instalButton.Click += new System.EventHandler(this.instalButton_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 81);
            this.Controls.Add(this.instalButton);
            this.Controls.Add(this.directoryLabel);
            this.MaximizeBox = false;
            this.Name = "LauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMGL Launcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button instalButton;
    }
}

