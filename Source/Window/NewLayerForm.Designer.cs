namespace DEETU.Source.Window
{
    partial class NewLayerForm
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
            this.基本信息 = new Sunny.UI.UIGroupBox();
            this.基本信息网格 = new System.Windows.Forms.TableLayoutPanel();
            this.CrsLabel = new Sunny.UI.UILabel();
            this.GeometryTypeLabel = new Sunny.UI.UILabel();
            this.LayerNameLabel = new Sunny.UI.UILabel();
            this.LayerNameTextBox = new Sunny.UI.UITextBox();
            this.GeometryTypeComboBox = new Sunny.UI.UIComboBox();
            this.坐标系网格 = new System.Windows.Forms.TableLayoutPanel();
            this.PrjCrsComboBox = new Sunny.UI.UIComboBox();
            this.GeoCrsComboBox = new Sunny.UI.UIComboBox();
            this.新建字段 = new Sunny.UI.UIGroupBox();
            this.AddField = new Sunny.UI.UIButton();
            this.新建字段网格 = new System.Windows.Forms.TableLayoutPanel();
            this.字段类型Label = new Sunny.UI.UILabel();
            this.字段名称Label = new Sunny.UI.UILabel();
            this.FieldNameTextBox = new Sunny.UI.UITextBox();
            this.FieldTypeComboBox = new Sunny.UI.UIComboBox();
            this.FieldListDataGrid = new Sunny.UI.UIDataGridView();
            this.字段名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.字段类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmButton = new Sunny.UI.UIButton();
            this.CancelButton = new Sunny.UI.UIButton();
            this.字段列表 = new Sunny.UI.UIGroupBox();
            this.删除Button = new Sunny.UI.UIButton();
            this.基本信息.SuspendLayout();
            this.基本信息网格.SuspendLayout();
            this.坐标系网格.SuspendLayout();
            this.新建字段.SuspendLayout();
            this.新建字段网格.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldListDataGrid)).BeginInit();
            this.字段列表.SuspendLayout();
            this.SuspendLayout();
            // 
            // 基本信息
            // 
            this.基本信息.Controls.Add(this.基本信息网格);
            this.基本信息.Dock = System.Windows.Forms.DockStyle.Top;
            this.基本信息.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.基本信息.Location = new System.Drawing.Point(20, 40);
            this.基本信息.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.基本信息.MinimumSize = new System.Drawing.Size(1, 1);
            this.基本信息.Name = "基本信息";
            this.基本信息.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.基本信息.Size = new System.Drawing.Size(377, 109);
            this.基本信息.TabIndex = 0;
            this.基本信息.Text = "基本信息";
            this.基本信息.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 基本信息网格
            // 
            this.基本信息网格.ColumnCount = 2;
            this.基本信息网格.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.基本信息网格.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.基本信息网格.Controls.Add(this.CrsLabel, 0, 2);
            this.基本信息网格.Controls.Add(this.GeometryTypeLabel, 0, 1);
            this.基本信息网格.Controls.Add(this.LayerNameLabel, 0, 0);
            this.基本信息网格.Controls.Add(this.LayerNameTextBox, 1, 0);
            this.基本信息网格.Controls.Add(this.GeometryTypeComboBox, 1, 1);
            this.基本信息网格.Controls.Add(this.坐标系网格, 1, 2);
            this.基本信息网格.Dock = System.Windows.Forms.DockStyle.Fill;
            this.基本信息网格.Location = new System.Drawing.Point(3, 30);
            this.基本信息网格.Name = "基本信息网格";
            this.基本信息网格.Padding = new System.Windows.Forms.Padding(3);
            this.基本信息网格.RowCount = 3;
            this.基本信息网格.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.基本信息网格.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.基本信息网格.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.基本信息网格.Size = new System.Drawing.Size(371, 76);
            this.基本信息网格.TabIndex = 3;
            // 
            // CrsLabel
            // 
            this.CrsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrsLabel.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CrsLabel.Location = new System.Drawing.Point(6, 49);
            this.CrsLabel.Name = "CrsLabel";
            this.CrsLabel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.CrsLabel.Size = new System.Drawing.Size(103, 24);
            this.CrsLabel.TabIndex = 5;
            this.CrsLabel.Text = "坐标系：";
            this.CrsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GeometryTypeLabel
            // 
            this.GeometryTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeometryTypeLabel.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GeometryTypeLabel.Location = new System.Drawing.Point(6, 26);
            this.GeometryTypeLabel.Name = "GeometryTypeLabel";
            this.GeometryTypeLabel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.GeometryTypeLabel.Size = new System.Drawing.Size(103, 23);
            this.GeometryTypeLabel.TabIndex = 3;
            this.GeometryTypeLabel.Text = "要素类型：";
            this.GeometryTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LayerNameLabel
            // 
            this.LayerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerNameLabel.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LayerNameLabel.Location = new System.Drawing.Point(6, 3);
            this.LayerNameLabel.Name = "LayerNameLabel";
            this.LayerNameLabel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.LayerNameLabel.Size = new System.Drawing.Size(103, 23);
            this.LayerNameLabel.TabIndex = 2;
            this.LayerNameLabel.Text = "图层名称：";
            this.LayerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LayerNameTextBox
            // 
            this.LayerNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LayerNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerNameTextBox.FillColor = System.Drawing.Color.White;
            this.LayerNameTextBox.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LayerNameTextBox.Location = new System.Drawing.Point(112, 3);
            this.LayerNameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.LayerNameTextBox.Maximum = 2147483647D;
            this.LayerNameTextBox.Minimum = -2147483648D;
            this.LayerNameTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.LayerNameTextBox.Name = "LayerNameTextBox";
            this.LayerNameTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.LayerNameTextBox.Size = new System.Drawing.Size(256, 25);
            this.LayerNameTextBox.TabIndex = 1;
            this.LayerNameTextBox.Text = "新建图层1";
            this.LayerNameTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GeometryTypeComboBox
            // 
            this.GeometryTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeometryTypeComboBox.FillColor = System.Drawing.Color.White;
            this.GeometryTypeComboBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GeometryTypeComboBox.Location = new System.Drawing.Point(112, 26);
            this.GeometryTypeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.GeometryTypeComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.GeometryTypeComboBox.Name = "GeometryTypeComboBox";
            this.GeometryTypeComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.GeometryTypeComboBox.Size = new System.Drawing.Size(256, 25);
            this.GeometryTypeComboBox.TabIndex = 4;
            this.GeometryTypeComboBox.Text = "必填";
            this.GeometryTypeComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 坐标系网格
            // 
            this.坐标系网格.ColumnCount = 2;
            this.坐标系网格.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.坐标系网格.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.坐标系网格.Controls.Add(this.PrjCrsComboBox, 1, 0);
            this.坐标系网格.Controls.Add(this.GeoCrsComboBox, 0, 0);
            this.坐标系网格.Dock = System.Windows.Forms.DockStyle.Fill;
            this.坐标系网格.Location = new System.Drawing.Point(112, 49);
            this.坐标系网格.Margin = new System.Windows.Forms.Padding(0);
            this.坐标系网格.Name = "坐标系网格";
            this.坐标系网格.RowCount = 1;
            this.坐标系网格.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.坐标系网格.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.坐标系网格.Size = new System.Drawing.Size(256, 24);
            this.坐标系网格.TabIndex = 6;
            // 
            // PrjCrsComboBox
            // 
            this.PrjCrsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrjCrsComboBox.FillColor = System.Drawing.Color.White;
            this.PrjCrsComboBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PrjCrsComboBox.Location = new System.Drawing.Point(128, 0);
            this.PrjCrsComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrjCrsComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.PrjCrsComboBox.Name = "PrjCrsComboBox";
            this.PrjCrsComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.PrjCrsComboBox.Size = new System.Drawing.Size(128, 25);
            this.PrjCrsComboBox.TabIndex = 6;
            this.PrjCrsComboBox.Text = "投影坐标系";
            this.PrjCrsComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GeoCrsComboBox
            // 
            this.GeoCrsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeoCrsComboBox.FillColor = System.Drawing.Color.White;
            this.GeoCrsComboBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GeoCrsComboBox.Location = new System.Drawing.Point(0, 0);
            this.GeoCrsComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.GeoCrsComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.GeoCrsComboBox.Name = "GeoCrsComboBox";
            this.GeoCrsComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.GeoCrsComboBox.Size = new System.Drawing.Size(128, 25);
            this.GeoCrsComboBox.TabIndex = 5;
            this.GeoCrsComboBox.Text = "地理坐标系";
            this.GeoCrsComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 新建字段
            // 
            this.新建字段.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.新建字段.Controls.Add(this.AddField);
            this.新建字段.Controls.Add(this.新建字段网格);
            this.新建字段.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.新建字段.Location = new System.Drawing.Point(20, 159);
            this.新建字段.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.新建字段.MinimumSize = new System.Drawing.Size(1, 1);
            this.新建字段.Name = "新建字段";
            this.新建字段.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.新建字段.Size = new System.Drawing.Size(377, 122);
            this.新建字段.TabIndex = 4;
            this.新建字段.Text = "新建字段";
            this.新建字段.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddField
            // 
            this.AddField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddField.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddField.Location = new System.Drawing.Point(321, 88);
            this.AddField.MinimumSize = new System.Drawing.Size(1, 1);
            this.AddField.Name = "AddField";
            this.AddField.Size = new System.Drawing.Size(50, 30);
            this.AddField.TabIndex = 4;
            this.AddField.Text = "添加";
            this.AddField.Click += new System.EventHandler(this.AddField_Click);
            // 
            // 新建字段网格
            // 
            this.新建字段网格.ColumnCount = 2;
            this.新建字段网格.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.新建字段网格.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.新建字段网格.Controls.Add(this.字段类型Label, 0, 1);
            this.新建字段网格.Controls.Add(this.字段名称Label, 0, 0);
            this.新建字段网格.Controls.Add(this.FieldNameTextBox, 1, 0);
            this.新建字段网格.Controls.Add(this.FieldTypeComboBox, 1, 1);
            this.新建字段网格.Dock = System.Windows.Forms.DockStyle.Top;
            this.新建字段网格.Location = new System.Drawing.Point(3, 30);
            this.新建字段网格.Name = "新建字段网格";
            this.新建字段网格.Padding = new System.Windows.Forms.Padding(3);
            this.新建字段网格.RowCount = 2;
            this.新建字段网格.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.新建字段网格.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.新建字段网格.Size = new System.Drawing.Size(371, 55);
            this.新建字段网格.TabIndex = 3;
            // 
            // 字段类型Label
            // 
            this.字段类型Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.字段类型Label.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.字段类型Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.字段类型Label.Location = new System.Drawing.Point(6, 27);
            this.字段类型Label.Name = "字段类型Label";
            this.字段类型Label.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.字段类型Label.Size = new System.Drawing.Size(103, 25);
            this.字段类型Label.TabIndex = 3;
            this.字段类型Label.Text = "类型：";
            this.字段类型Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 字段名称Label
            // 
            this.字段名称Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.字段名称Label.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.字段名称Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.字段名称Label.Location = new System.Drawing.Point(6, 3);
            this.字段名称Label.Name = "字段名称Label";
            this.字段名称Label.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.字段名称Label.Size = new System.Drawing.Size(103, 24);
            this.字段名称Label.TabIndex = 2;
            this.字段名称Label.Text = "名称：";
            this.字段名称Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FieldNameTextBox
            // 
            this.FieldNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FieldNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldNameTextBox.FillColor = System.Drawing.Color.White;
            this.FieldNameTextBox.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FieldNameTextBox.Location = new System.Drawing.Point(112, 3);
            this.FieldNameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.FieldNameTextBox.Maximum = 2147483647D;
            this.FieldNameTextBox.Minimum = -2147483648D;
            this.FieldNameTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.FieldNameTextBox.Name = "FieldNameTextBox";
            this.FieldNameTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.FieldNameTextBox.Size = new System.Drawing.Size(256, 25);
            this.FieldNameTextBox.TabIndex = 1;
            this.FieldNameTextBox.Text = "字段1";
            this.FieldNameTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FieldTypeComboBox
            // 
            this.FieldTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldTypeComboBox.FillColor = System.Drawing.Color.White;
            this.FieldTypeComboBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FieldTypeComboBox.Location = new System.Drawing.Point(112, 27);
            this.FieldTypeComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.FieldTypeComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.FieldTypeComboBox.Name = "FieldTypeComboBox";
            this.FieldTypeComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.FieldTypeComboBox.Size = new System.Drawing.Size(256, 25);
            this.FieldTypeComboBox.TabIndex = 4;
            this.FieldTypeComboBox.Text = "选择类型";
            this.FieldTypeComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FieldListDataGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.FieldListDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.FieldListDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.FieldListDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldListDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.FieldListDataGrid.ColumnHeadersHeight = 25;
            this.FieldListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.FieldListDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.字段名称,
            this.字段类型});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldListDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.FieldListDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.FieldListDataGrid.EnableHeadersVisualStyles = false;
            this.FieldListDataGrid.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FieldListDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.FieldListDataGrid.Location = new System.Drawing.Point(3, 30);
            this.FieldListDataGrid.Name = "FieldListDataGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldListDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.FieldListDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.FieldListDataGrid.RowTemplate.Height = 29;
            this.FieldListDataGrid.SelectedIndex = -1;
            this.FieldListDataGrid.ShowGridLine = true;
            this.FieldListDataGrid.Size = new System.Drawing.Size(371, 116);
            this.FieldListDataGrid.TabIndex = 0;
            // 
            // 字段名称
            // 
            this.字段名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.字段名称.HeaderText = "名称";
            this.字段名称.Name = "字段名称";
            // 
            // 字段类型
            // 
            this.字段类型.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.字段类型.HeaderText = "类型";
            this.字段类型.Name = "字段类型";
            this.字段类型.ReadOnly = true;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ConfirmButton.Location = new System.Drawing.Point(201, 500);
            this.ConfirmButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(100, 35);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "确认";
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CancelButton.Location = new System.Drawing.Point(307, 500);
            this.CancelButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 35);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "取消";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // 字段列表
            // 
            this.字段列表.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.字段列表.Controls.Add(this.删除Button);
            this.字段列表.Controls.Add(this.FieldListDataGrid);
            this.字段列表.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.字段列表.Location = new System.Drawing.Point(20, 307);
            this.字段列表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.字段列表.MinimumSize = new System.Drawing.Size(1, 1);
            this.字段列表.Name = "字段列表";
            this.字段列表.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.字段列表.Size = new System.Drawing.Size(377, 185);
            this.字段列表.TabIndex = 5;
            this.字段列表.Text = "字段列表";
            this.字段列表.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 删除Button
            // 
            this.删除Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.删除Button.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.删除Button.Location = new System.Drawing.Point(321, 149);
            this.删除Button.MinimumSize = new System.Drawing.Size(1, 1);
            this.删除Button.Name = "删除Button";
            this.删除Button.Size = new System.Drawing.Size(50, 30);
            this.删除Button.TabIndex = 5;
            this.删除Button.Text = "删除";
            this.删除Button.Click += new System.EventHandler(this.删除Button_Click);
            // 
            // NewLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 550);
            this.Controls.Add(this.字段列表);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.新建字段);
            this.Controls.Add(this.基本信息);
            this.Name = "NewLayerForm";
            this.Padding = new System.Windows.Forms.Padding(20, 40, 20, 20);
            this.Text = "新建图层";
            this.基本信息.ResumeLayout(false);
            this.基本信息网格.ResumeLayout(false);
            this.坐标系网格.ResumeLayout(false);
            this.新建字段.ResumeLayout(false);
            this.新建字段网格.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FieldListDataGrid)).EndInit();
            this.字段列表.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIGroupBox 基本信息;
        private System.Windows.Forms.TableLayoutPanel 基本信息网格;
        private Sunny.UI.UILabel LayerNameLabel;
        private Sunny.UI.UITextBox LayerNameTextBox;
        private Sunny.UI.UILabel GeometryTypeLabel;
        private Sunny.UI.UILabel CrsLabel;
        private Sunny.UI.UIComboBox GeometryTypeComboBox;
        private System.Windows.Forms.TableLayoutPanel 坐标系网格;
        private Sunny.UI.UIComboBox PrjCrsComboBox;
        private Sunny.UI.UIComboBox GeoCrsComboBox;
        private Sunny.UI.UIGroupBox 新建字段;
        private System.Windows.Forms.TableLayoutPanel 新建字段网格;
        private Sunny.UI.UILabel 字段类型Label;
        private Sunny.UI.UILabel 字段名称Label;
        private Sunny.UI.UITextBox FieldNameTextBox;
        private Sunny.UI.UIComboBox FieldTypeComboBox;
        private Sunny.UI.UIButton AddField;
        private Sunny.UI.UIDataGridView FieldListDataGrid;
        private Sunny.UI.UIButton ConfirmButton;
        private Sunny.UI.UIButton CancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn 字段名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 字段类型;
        private Sunny.UI.UIGroupBox 字段列表;
        private Sunny.UI.UIButton 删除Button;
    }
}