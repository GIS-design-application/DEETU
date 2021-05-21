namespace DEETU
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.geoMap = new DEETU.Map.GeoMapControl();
            this.geoMapControl1 = new DEETU.Map.GeoMapControl();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 318);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(913, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(713, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 318);
            this.panel1.TabIndex = 1;
            // 
            // geoMap
            // 
            this.geoMap.BackColor = System.Drawing.Color.White;
            this.geoMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.geoMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoMap.FlashColor = System.Drawing.Color.Green;
            this.geoMap.Layers = null;
            this.geoMap.Location = new System.Drawing.Point(0, 0);
            this.geoMap.Name = "geoMap";
            this.geoMap.SelectionColor = System.Drawing.Color.Cyan;
            this.geoMap.Size = new System.Drawing.Size(713, 318);
            this.geoMap.TabIndex = 2;
            // 
            // geoMapControl1
            // 
            this.geoMapControl1.BackColor = System.Drawing.Color.White;
            this.geoMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.geoMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoMapControl1.FlashColor = System.Drawing.Color.Green;
            this.geoMapControl1.Layers = null;
            this.geoMapControl1.Location = new System.Drawing.Point(0, 0);
            this.geoMapControl1.Name = "geoMapControl1";
            this.geoMapControl1.SelectionColor = System.Drawing.Color.Cyan;
            this.geoMapControl1.Size = new System.Drawing.Size(713, 318);
            this.geoMapControl1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 340);
            this.Controls.Add(this.geoMapControl1);
            this.Controls.Add(this.geoMap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private Map.GeoMapControl geoMap;
        private Map.GeoMapControl geoMapControl1;
    }
}

