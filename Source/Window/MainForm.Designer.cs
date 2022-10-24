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
            this.geoMap = new Map.GeoMapControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMapScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLoadLayerFile = new System.Windows.Forms.Button();
            this.btnFullExtent = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnPan = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnSimpleRender = new System.Windows.Forms.Button();
            this.btnUniqueValue = new System.Windows.Forms.Button();
            this.btnClassBreaks = new System.Windows.Forms.Button();
            this.btnShowLabela = new System.Windows.Forms.Button();
            this.btnMovePolygon = new System.Windows.Forms.Button();
            this.btnSketchPolygon = new System.Windows.Forms.Button();
            this.btnEndPart = new System.Windows.Forms.Button();
            this.btnEditPolygon = new System.Windows.Forms.Button();
            this.btnEndEdit = new System.Windows.Forms.Button();
            this.btnEndSketch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSHPLoad = new System.Windows.Forms.Button();
            this.btnDatabaseLoad = new System.Windows.Forms.Button();
            this.btnDatabaseSave = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCoordinate,
            this.tssMapScale});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1804);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 35, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2282, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssCoordinate
            // 
            this.tssCoordinate.AutoSize = false;
            this.tssCoordinate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssCoordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssCoordinate.Name = "tssCoordinate";
            this.tssCoordinate.Size = new System.Drawing.Size(200, 13);
            this.tssCoordinate.Text = "toolStripStatusLabel1";
            // 
            // tssMapScale
            // 
            this.tssMapScale.AutoSize = false;
            this.tssMapScale.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssMapScale.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssMapScale.IsLink = true;
            this.tssMapScale.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tssMapScale.Name = "tssMapScale";
            this.tssMapScale.Size = new System.Drawing.Size(200, 13);
            this.tssMapScale.Text = "tssMapScale";
            // 
            // btnLoadLayerFile
            // 
            this.btnLoadLayerFile.Location = new System.Drawing.Point(80, 40);
            this.btnLoadLayerFile.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnLoadLayerFile.Name = "btnLoadLayerFile";
            this.btnLoadLayerFile.Size = new System.Drawing.Size(188, 58);
            this.btnLoadLayerFile.TabIndex = 0;
            this.btnLoadLayerFile.Text = "载入图层";
            this.btnLoadLayerFile.UseVisualStyleBackColor = true;
            this.btnLoadLayerFile.Click += new System.EventHandler(this.btnLoadLayerFile_Click);
            // 
            // btnFullExtent
            // 
            this.btnFullExtent.Location = new System.Drawing.Point(80, 150);
            this.btnFullExtent.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnFullExtent.Name = "btnFullExtent";
            this.btnFullExtent.Size = new System.Drawing.Size(188, 58);
            this.btnFullExtent.TabIndex = 1;
            this.btnFullExtent.Text = "全范围显示";
            this.btnFullExtent.UseVisualStyleBackColor = true;
            this.btnFullExtent.Click += new System.EventHandler(this.btnFullExtent_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(80, 260);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(188, 58);
            this.btnZoomIn.TabIndex = 2;
            this.btnZoomIn.Text = "放大";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(80, 370);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(188, 58);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "缩小";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnPan
            // 
            this.btnPan.Location = new System.Drawing.Point(80, 480);
            this.btnPan.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnPan.Name = "btnPan";
            this.btnPan.Size = new System.Drawing.Size(188, 58);
            this.btnPan.TabIndex = 4;
            this.btnPan.Text = "漫游";
            this.btnPan.UseVisualStyleBackColor = true;
            this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(80, 590);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(188, 58);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(80, 700);
            this.btnIdentify.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(188, 58);
            this.btnIdentify.TabIndex = 6;
            this.btnIdentify.Text = "查询";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnSimpleRender
            // 
            this.btnSimpleRender.Location = new System.Drawing.Point(80, 810);
            this.btnSimpleRender.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSimpleRender.Name = "btnSimpleRender";
            this.btnSimpleRender.Size = new System.Drawing.Size(188, 58);
            this.btnSimpleRender.TabIndex = 7;
            this.btnSimpleRender.Text = "简单渲染";
            this.btnSimpleRender.UseVisualStyleBackColor = true;
            this.btnSimpleRender.Click += new System.EventHandler(this.btnSimpleRender_Click);
            // 
            // btnUniqueValue
            // 
            this.btnUniqueValue.Location = new System.Drawing.Point(80, 920);
            this.btnUniqueValue.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnUniqueValue.Name = "btnUniqueValue";
            this.btnUniqueValue.Size = new System.Drawing.Size(188, 58);
            this.btnUniqueValue.TabIndex = 8;
            this.btnUniqueValue.Text = "唯一值渲染";
            this.btnUniqueValue.UseVisualStyleBackColor = true;
            this.btnUniqueValue.Click += new System.EventHandler(this.btnUniqueValue_Click);
            // 
            // btnClassBreaks
            // 
            this.btnClassBreaks.Location = new System.Drawing.Point(80, 1030);
            this.btnClassBreaks.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnClassBreaks.Name = "btnClassBreaks";
            this.btnClassBreaks.Size = new System.Drawing.Size(188, 58);
            this.btnClassBreaks.TabIndex = 9;
            this.btnClassBreaks.Text = "分级渲染";
            this.btnClassBreaks.UseVisualStyleBackColor = true;
            this.btnClassBreaks.Click += new System.EventHandler(this.btnClassBreaks_Click);
            // 
            // btnShowLabela
            // 
            this.btnShowLabela.Location = new System.Drawing.Point(80, 1140);
            this.btnShowLabela.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnShowLabela.Name = "btnShowLabela";
            this.btnShowLabela.Size = new System.Drawing.Size(188, 58);
            this.btnShowLabela.TabIndex = 10;
            this.btnShowLabela.Text = "显示注记";
            this.btnShowLabela.UseVisualStyleBackColor = true;
            this.btnShowLabela.Click += new System.EventHandler(this.btnShowLabel_Click);
            // 
            // btnMovePolygon
            // 
            this.btnMovePolygon.Location = new System.Drawing.Point(80, 1250);
            this.btnMovePolygon.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnMovePolygon.Name = "btnMovePolygon";
            this.btnMovePolygon.Size = new System.Drawing.Size(188, 58);
            this.btnMovePolygon.TabIndex = 11;
            this.btnMovePolygon.Text = "移动多边形";
            this.btnMovePolygon.UseVisualStyleBackColor = true;
            this.btnMovePolygon.Click += new System.EventHandler(this.btnMovePolygon_Click);
            // 
            // btnSketchPolygon
            // 
            this.btnSketchPolygon.Location = new System.Drawing.Point(80, 1360);
            this.btnSketchPolygon.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSketchPolygon.Name = "btnSketchPolygon";
            this.btnSketchPolygon.Size = new System.Drawing.Size(188, 58);
            this.btnSketchPolygon.TabIndex = 12;
            this.btnSketchPolygon.Text = "描绘多边形";
            this.btnSketchPolygon.UseVisualStyleBackColor = true;
            this.btnSketchPolygon.Click += new System.EventHandler(this.btnSketchPolygon_Click);
            // 
            // btnEndPart
            // 
            this.btnEndPart.Location = new System.Drawing.Point(80, 1470);
            this.btnEndPart.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEndPart.Name = "btnEndPart";
            this.btnEndPart.Size = new System.Drawing.Size(188, 58);
            this.btnEndPart.TabIndex = 13;
            this.btnEndPart.Text = "结束部分";
            this.btnEndPart.UseVisualStyleBackColor = true;
            this.btnEndPart.Click += new System.EventHandler(this.btnEndPart_Click);
            // 
            // btnEditPolygon
            // 
            this.btnEditPolygon.Location = new System.Drawing.Point(80, 1580);
            this.btnEditPolygon.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEditPolygon.Name = "btnEditPolygon";
            this.btnEditPolygon.Size = new System.Drawing.Size(188, 58);
            this.btnEditPolygon.TabIndex = 14;
            this.btnEditPolygon.Text = "编辑多边形";
            this.btnEditPolygon.UseVisualStyleBackColor = true;
            this.btnEditPolygon.Click += new System.EventHandler(this.btnEditPolygon_Click);
            // 
            // btnEndEdit
            // 
            this.btnEndEdit.Location = new System.Drawing.Point(282, 1580);
            this.btnEndEdit.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEndEdit.Name = "btnEndEdit";
            this.btnEndEdit.Size = new System.Drawing.Size(188, 58);
            this.btnEndEdit.TabIndex = 15;
            this.btnEndEdit.Text = "结束编辑";
            this.btnEndEdit.UseVisualStyleBackColor = true;
            this.btnEndEdit.Click += new System.EventHandler(this.btnEndEdit_Click);
            // 
            // btnEndSketch
            // 
            this.btnEndSketch.Location = new System.Drawing.Point(282, 1470);
            this.btnEndSketch.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEndSketch.Name = "btnEndSketch";
            this.btnEndSketch.Size = new System.Drawing.Size(188, 58);
            this.btnEndSketch.TabIndex = 16;
            this.btnEndSketch.Text = "结束描绘";
            this.btnEndSketch.UseVisualStyleBackColor = true;
            this.btnEndSketch.Click += new System.EventHandler(this.btnEndSketch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDatabaseSave);
            this.panel1.Controls.Add(this.btnDatabaseLoad);
            this.panel1.Controls.Add(this.btnSHPLoad);
            this.panel1.Controls.Add(this.btnEndSketch);
            this.panel1.Controls.Add(this.btnEndEdit);
            this.panel1.Controls.Add(this.btnEditPolygon);
            this.panel1.Controls.Add(this.btnEndPart);
            this.panel1.Controls.Add(this.btnSketchPolygon);
            this.panel1.Controls.Add(this.btnMovePolygon);
            this.panel1.Controls.Add(this.btnShowLabela);
            this.panel1.Controls.Add(this.btnClassBreaks);
            this.panel1.Controls.Add(this.btnUniqueValue);
            this.panel1.Controls.Add(this.btnSimpleRender);
            this.panel1.Controls.Add(this.btnIdentify);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnPan);
            this.panel1.Controls.Add(this.btnZoomOut);
            this.panel1.Controls.Add(this.btnZoomIn);
            this.panel1.Controls.Add(this.btnFullExtent);
            this.panel1.Controls.Add(this.btnLoadLayerFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1782, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 1804);
            this.panel1.TabIndex = 3;
            // 
            // btnSHPLoad
            // 
            this.btnSHPLoad.Location = new System.Drawing.Point(295, 40);
            this.btnSHPLoad.Margin = new System.Windows.Forms.Padding(8);
            this.btnSHPLoad.Name = "btnSHPLoad";
            this.btnSHPLoad.Size = new System.Drawing.Size(188, 58);
            this.btnSHPLoad.TabIndex = 17;
            this.btnSHPLoad.Text = "载入shp";
            this.btnSHPLoad.UseVisualStyleBackColor = true;
            this.btnSHPLoad.Click += new System.EventHandler(this.btnSHPLoad_Click);
            // 
            // btnDatabaseLoad
            // 
            this.btnDatabaseLoad.Location = new System.Drawing.Point(295, 150);
            this.btnDatabaseLoad.Margin = new System.Windows.Forms.Padding(8);
            this.btnDatabaseLoad.Name = "btnDatabaseLoad";
            this.btnDatabaseLoad.Size = new System.Drawing.Size(188, 58);
            this.btnDatabaseLoad.TabIndex = 18;
            this.btnDatabaseLoad.Text = "载入数据库";
            this.btnDatabaseLoad.UseVisualStyleBackColor = true;
            // 
            // btnDatabaseSave
            // 
            this.btnDatabaseSave.Location = new System.Drawing.Point(295, 260);
            this.btnDatabaseSave.Margin = new System.Windows.Forms.Padding(8);
            this.btnDatabaseSave.Name = "btnDatabaseSave";
            this.btnDatabaseSave.Size = new System.Drawing.Size(188, 58);
            this.btnDatabaseSave.TabIndex = 19;
            this.btnDatabaseSave.Text = "存储数据库";
            this.btnDatabaseSave.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2282, 1830);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssCoordinate;
        private System.Windows.Forms.ToolStripStatusLabel tssMapScale;
        private System.Windows.Forms.Button btnLoadLayerFile;
        private System.Windows.Forms.Button btnFullExtent;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnPan;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnSimpleRender;
        private System.Windows.Forms.Button btnUniqueValue;
        private System.Windows.Forms.Button btnClassBreaks;
        private System.Windows.Forms.Button btnShowLabela;
        private System.Windows.Forms.Button btnMovePolygon;
        private System.Windows.Forms.Button btnSketchPolygon;
        private System.Windows.Forms.Button btnEndPart;
        private System.Windows.Forms.Button btnEditPolygon;
        private System.Windows.Forms.Button btnEndEdit;
        private System.Windows.Forms.Button btnEndSketch;
        private System.Windows.Forms.Panel panel1;
        private Map.GeoMapControl geoMap;
        private System.Windows.Forms.Button btnDatabaseSave;
        private System.Windows.Forms.Button btnDatabaseLoad;
        private System.Windows.Forms.Button btnSHPLoad;
    }
}

