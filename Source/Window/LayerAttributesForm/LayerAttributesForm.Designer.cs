
namespace DEETU.Source.Window
{
    partial class LayerAttributesForm
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
            this.okButton = new Sunny.UI.UIButton();
            this.cancelButton = new Sunny.UI.UIButton();
            this.Footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Footer
            // 
            this.Footer.Controls.Add(this.cancelButton);
            this.Footer.Controls.Add(this.okButton);
            this.Footer.Location = new System.Drawing.Point(135, 779);
            this.Footer.Size = new System.Drawing.Size(453, 40);
            this.Footer.StyleCustomMode = true;
            // 
            // Header
            // 
            this.Header.Dock = System.Windows.Forms.DockStyle.None;
            this.Header.Location = new System.Drawing.Point(133, 35);
            this.Header.Size = new System.Drawing.Size(457, 52);
            this.Header.Style = Sunny.UI.UIStyle.Custom;
            // 
            // Aside
            // 
            this.Aside.Location = new System.Drawing.Point(2, 35);
            this.Aside.Size = new System.Drawing.Size(133, 784);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.okButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.okButton.Location = new System.Drawing.Point(268, 3);
            this.okButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(76, 35);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "确认";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancelButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cancelButton.Location = new System.Drawing.Point(374, 3);
            this.cancelButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 35);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "取消";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // LayerAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 821);
            this.ExtendBox = true;
            this.IsMdiContainer = true;
            this.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.Name = "LayerAttributesForm";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "图层属性";
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Aside, 0);
            this.Controls.SetChildIndex(this.Footer, 0);
            this.Footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton cancelButton;
        private Sunny.UI.UIButton okButton;
    }
}