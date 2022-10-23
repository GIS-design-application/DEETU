
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
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.LineColor = System.Drawing.Color.Black;
            this.Aside.Size = new System.Drawing.Size(152, 786);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
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
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "图层属性";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.TitleForeColor = System.Drawing.Color.Black;
            this.Controls.SetChildIndex(this.Aside, 0);
            this.ResumeLayout(false);

        }

        #endregion
    }
}