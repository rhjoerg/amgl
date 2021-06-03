
namespace amgl.ui
{
    partial class InstallPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameLabel = new System.Windows.Forms.Label();
            this.InstallGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameLabel
            // 
            this.GameLabel.Location = new System.Drawing.Point(10, 10);
            this.GameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(580, 30);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "AMGL - Game";
            this.GameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstallGameButton
            // 
            this.InstallGameButton.Location = new System.Drawing.Point(10, 50);
            this.InstallGameButton.Margin = new System.Windows.Forms.Padding(0);
            this.InstallGameButton.Name = "InstallGameButton";
            this.InstallGameButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.InstallGameButton.Size = new System.Drawing.Size(120, 30);
            this.InstallGameButton.TabIndex = 1;
            this.InstallGameButton.Text = "Install";
            this.InstallGameButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.InstallGameButton.UseVisualStyleBackColor = true;
            // 
            // InstallPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InstallGameButton);
            this.Controls.Add(this.GameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InstallPanel";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label GameLabel;
        public System.Windows.Forms.Button InstallGameButton;
    }
}
