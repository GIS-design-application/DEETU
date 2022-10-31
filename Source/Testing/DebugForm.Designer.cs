namespace DEETU.Testing
{
    partial class DebugForm
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
            this.logging = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logging
            // 
            this.logging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logging.Location = new System.Drawing.Point(0, 0);
            this.logging.Multiline = true;
            this.logging.Name = "logging";
            this.logging.ReadOnly = true;
            this.logging.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logging.Size = new System.Drawing.Size(463, 450);
            this.logging.TabIndex = 0;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.logging);
            this.Name = "DebugForm";
            this.Text = "Debug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox logging;
    }
}