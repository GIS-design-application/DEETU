
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
            this.Footer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.Footer.Location = new System.Drawing.Point(133, 781);
            this.Footer.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.Footer.Size = new System.Drawing.Size(457, 40);
            this.Footer.Style = Sunny.UI.UIStyle.Office2010Black;
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
            this.Aside.Size = new System.Drawing.Size(133, 786);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.okButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.okButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.okButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.okButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.okButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.okButton.ForeColor = System.Drawing.Color.Black;
            this.okButton.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.okButton.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.okButton.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.okButton.Location = new System.Drawing.Point(268, 3);
            this.okButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.okButton.Name = "okButton";
            this.okButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.okButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.okButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.okButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.okButton.Size = new System.Drawing.Size(80, 35);
            this.okButton.Style = Sunny.UI.UIStyle.Office2010Black;
            this.okButton.TabIndex = 0;
            this.okButton.Text = "确认";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancelButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.cancelButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.cancelButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.cancelButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.cancelButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cancelButton.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cancelButton.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cancelButton.Location = new System.Drawing.Point(374, 3);
            this.cancelButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.cancelButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.cancelButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.cancelButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.cancelButton.Size = new System.Drawing.Size(80, 35);
            this.cancelButton.Style = Sunny.UI.UIStyle.Office2010Black;
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "取消";
            // 
            // LayerAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 821);
            this.ExtendBox = true;
            this.IsMdiContainer = true;
            this.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.Name = "LayerAttributesForm";
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