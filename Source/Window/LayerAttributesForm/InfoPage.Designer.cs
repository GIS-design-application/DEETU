
namespace DEETU.Source.Window
{
    partial class InfoPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SourceLine = new Sunny.UI.UILine();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.countRichTextBox = new System.Windows.Forms.RichTextBox();
            this.unitRichTextBox = new System.Windows.Forms.RichTextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.extentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.crsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.geometryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.nameRichTextBox = new System.Windows.Forms.RichTextBox();
            this.pathRichTextBox = new System.Windows.Forms.RichTextBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.uiLine1 = new Sunny.UI.UILine();
            this.fieldDataGridView = new Sunny.UI.UIDataGridView();
            this.fieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldRichTextBox = new System.Windows.Forms.RichTextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.PagePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.AutoScroll = true;
            this.PagePanel.Controls.Add(this.fieldRichTextBox);
            this.PagePanel.Controls.Add(this.uiLabel4);
            this.PagePanel.Controls.Add(this.fieldDataGridView);
            this.PagePanel.Controls.Add(this.uiLine1);
            this.PagePanel.Controls.Add(this.tableLayoutPanel1);
            this.PagePanel.Controls.Add(this.SourceLine);
            this.PagePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.PagePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.PagePanel.Size = new System.Drawing.Size(480, 665);
            this.PagePanel.Style = Sunny.UI.UIStyle.Office2010Black;
            // 
            // SourceLine
            // 
            this.SourceLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.SourceLine.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SourceLine.Location = new System.Drawing.Point(0, 0);
            this.SourceLine.MinimumSize = new System.Drawing.Size(2, 2);
            this.SourceLine.Name = "SourceLine";
            this.SourceLine.Size = new System.Drawing.Size(480, 67);
            this.SourceLine.Style = Sunny.UI.UIStyle.Custom;
            this.SourceLine.StyleCustomMode = true;
            this.SourceLine.TabIndex = 0;
            this.SourceLine.Text = "来自数据源的信息";
            this.SourceLine.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 33);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(94, 33);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "路径";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(94, 33);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "名称";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.countRichTextBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.unitRichTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel3, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.extentRichTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.crsRichTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.geometryRichTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.descriptionRichTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameRichTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pathRichTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel13, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel11, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 297);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // countRichTextBox
            // 
            this.countRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.countRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countRichTextBox.Location = new System.Drawing.Point(103, 267);
            this.countRichTextBox.Name = "countRichTextBox";
            this.countRichTextBox.ReadOnly = true;
            this.countRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.countRichTextBox.Size = new System.Drawing.Size(297, 27);
            this.countRichTextBox.TabIndex = 20;
            this.countRichTextBox.Text = "";
            // 
            // unitRichTextBox
            // 
            this.unitRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unitRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unitRichTextBox.Location = new System.Drawing.Point(103, 234);
            this.unitRichTextBox.Name = "unitRichTextBox";
            this.unitRichTextBox.ReadOnly = true;
            this.unitRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.unitRichTextBox.Size = new System.Drawing.Size(297, 27);
            this.unitRichTextBox.TabIndex = 18;
            this.unitRichTextBox.Text = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(3, 264);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(94, 33);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel3.TabIndex = 19;
            this.uiLabel3.Text = "要素数目";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // extentRichTextBox
            // 
            this.extentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extentRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extentRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.extentRichTextBox.Location = new System.Drawing.Point(103, 168);
            this.extentRichTextBox.Name = "extentRichTextBox";
            this.extentRichTextBox.ReadOnly = true;
            this.extentRichTextBox.Size = new System.Drawing.Size(297, 60);
            this.extentRichTextBox.TabIndex = 17;
            this.extentRichTextBox.Text = "";
            // 
            // crsRichTextBox
            // 
            this.crsRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.crsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crsRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.crsRichTextBox.Location = new System.Drawing.Point(103, 135);
            this.crsRichTextBox.Name = "crsRichTextBox";
            this.crsRichTextBox.ReadOnly = true;
            this.crsRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.crsRichTextBox.Size = new System.Drawing.Size(297, 27);
            this.crsRichTextBox.TabIndex = 16;
            this.crsRichTextBox.Text = "";
            // 
            // geometryRichTextBox
            // 
            this.geometryRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.geometryRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geometryRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.geometryRichTextBox.Location = new System.Drawing.Point(103, 102);
            this.geometryRichTextBox.Name = "geometryRichTextBox";
            this.geometryRichTextBox.ReadOnly = true;
            this.geometryRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.geometryRichTextBox.Size = new System.Drawing.Size(297, 27);
            this.geometryRichTextBox.TabIndex = 15;
            this.geometryRichTextBox.Text = "";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.descriptionRichTextBox.Location = new System.Drawing.Point(103, 69);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.ReadOnly = true;
            this.descriptionRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.descriptionRichTextBox.Size = new System.Drawing.Size(297, 27);
            this.descriptionRichTextBox.TabIndex = 14;
            this.descriptionRichTextBox.Text = "";
            // 
            // nameRichTextBox
            // 
            this.nameRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameRichTextBox.Location = new System.Drawing.Point(103, 3);
            this.nameRichTextBox.Name = "nameRichTextBox";
            this.nameRichTextBox.ReadOnly = true;
            this.nameRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.nameRichTextBox.Size = new System.Drawing.Size(297, 27);
            this.nameRichTextBox.TabIndex = 6;
            this.nameRichTextBox.Text = "";
            // 
            // pathRichTextBox
            // 
            this.pathRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pathRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pathRichTextBox.Location = new System.Drawing.Point(103, 36);
            this.pathRichTextBox.Name = "pathRichTextBox";
            this.pathRichTextBox.ReadOnly = true;
            this.pathRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.pathRichTextBox.Size = new System.Drawing.Size(297, 27);
            this.pathRichTextBox.TabIndex = 5;
            this.pathRichTextBox.Text = "";
            // 
            // uiLabel13
            // 
            this.uiLabel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel13.Location = new System.Drawing.Point(3, 231);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(94, 33);
            this.uiLabel13.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel13.TabIndex = 13;
            this.uiLabel13.Text = "单位";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(3, 66);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(94, 33);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "描述";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(3, 99);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(94, 33);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel7.TabIndex = 7;
            this.uiLabel7.Text = "几何图形";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(3, 132);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(94, 33);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel9.TabIndex = 9;
            this.uiLabel9.Text = "坐标参照系";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel11
            // 
            this.uiLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(3, 165);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(94, 66);
            this.uiLabel11.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel11.TabIndex = 11;
            this.uiLabel11.Text = "范围";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(0, 354);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(480, 63);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.StyleCustomMode = true;
            this.uiLine1.TabIndex = 4;
            this.uiLine1.Text = "字段";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // fieldDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.fieldDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.fieldDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fieldDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.fieldDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fieldDataGridView.ColumnHeadersHeight = 32;
            this.fieldDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fieldDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldName,
            this.fieldAlias,
            this.fieldType});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fieldDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.fieldDataGridView.EnableHeadersVisualStyles = false;
            this.fieldDataGridView.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fieldDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.fieldDataGridView.Location = new System.Drawing.Point(3, 423);
            this.fieldDataGridView.Name = "fieldDataGridView";
            this.fieldDataGridView.ReadOnly = true;
            this.fieldDataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.fieldDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fieldDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.fieldDataGridView.RowHeadersWidth = 30;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.fieldDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.fieldDataGridView.RowTemplate.Height = 29;
            this.fieldDataGridView.SelectedIndex = -1;
            this.fieldDataGridView.ShowGridLine = true;
            this.fieldDataGridView.Size = new System.Drawing.Size(474, 230);
            this.fieldDataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.fieldDataGridView.Style = Sunny.UI.UIStyle.Custom;
            this.fieldDataGridView.StyleCustomMode = true;
            this.fieldDataGridView.TabIndex = 5;
            // 
            // fieldName
            // 
            this.fieldName.HeaderText = "字段名";
            this.fieldName.MinimumWidth = 6;
            this.fieldName.Name = "fieldName";
            this.fieldName.ReadOnly = true;
            // 
            // fieldAlias
            // 
            this.fieldAlias.HeaderText = "别名";
            this.fieldAlias.MinimumWidth = 6;
            this.fieldAlias.Name = "fieldAlias";
            this.fieldAlias.ReadOnly = true;
            // 
            // fieldType
            // 
            this.fieldType.HeaderText = "类型";
            this.fieldType.MinimumWidth = 6;
            this.fieldType.Name = "fieldType";
            this.fieldType.ReadOnly = true;
            // 
            // fieldRichTextBox
            // 
            this.fieldRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fieldRichTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fieldRichTextBox.Location = new System.Drawing.Point(112, 391);
            this.fieldRichTextBox.Name = "fieldRichTextBox";
            this.fieldRichTextBox.ReadOnly = true;
            this.fieldRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.fieldRichTextBox.Size = new System.Drawing.Size(297, 26);
            this.fieldRichTextBox.TabIndex = 22;
            this.fieldRichTextBox.Text = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(12, 391);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(102, 26);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiLabel4.TabIndex = 21;
            this.uiLabel4.Text = "字段数";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 700);
            this.Name = "InfoPage";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.Style = Sunny.UI.UIStyle.Office2010Black;
            this.Text = "信息";
            this.PagePanel.ResumeLayout(false);
            this.PagePanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILine SourceLine;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel11;
        private System.Windows.Forms.RichTextBox pathRichTextBox;
        private System.Windows.Forms.RichTextBox countRichTextBox;
        private Sunny.UI.UILabel uiLabel3;
        private System.Windows.Forms.RichTextBox unitRichTextBox;
        private System.Windows.Forms.RichTextBox extentRichTextBox;
        private System.Windows.Forms.RichTextBox crsRichTextBox;
        private System.Windows.Forms.RichTextBox geometryRichTextBox;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.RichTextBox nameRichTextBox;
        private System.Windows.Forms.RichTextBox fieldRichTextBox;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIDataGridView fieldDataGridView;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldType;
    }
}