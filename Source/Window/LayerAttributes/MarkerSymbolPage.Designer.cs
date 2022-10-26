
namespace DEETU.Source.Window
{
    partial class MarkerSymbolPage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.renderTabControl = new Sunny.UI.UITabControl();
            this.simpleTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.markerColorPicker = new Sunny.UI.UIColorPicker();
            this.sizeDoubleUpDown = new Sunny.UI.UIDoubleUpDown();
            this.markerStyleComboBox = new Sunny.UI.UIComboBox();
            this.uniqueValueTab = new System.Windows.Forms.TabPage();
            this.uniqueDataGridView = new Sunny.UI.UIDataGridView();
            this.uniqueTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uniqueFieldComboBox = new Sunny.UI.UIComboBox();
            this.uniqueColorgradComboBox = new System.Windows.Forms.ComboBox();
            this.classBreakTab = new System.Windows.Forms.TabPage();
            this.uiIntegerUpDown1 = new Sunny.UI.UIIntegerUpDown();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.classDataGridView = new Sunny.UI.UIDataGridView();
            this.classTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.classFieldComboBox = new Sunny.UI.UIComboBox();
            this.classColorgradComboBox = new System.Windows.Forms.ComboBox();
            this.renderMethodCB = new Sunny.UI.UIComboBox();
            this.geoUniqueValueRendererBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.valueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagePanel.SuspendLayout();
            this.renderTabControl.SuspendLayout();
            this.simpleTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.uniqueValueTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniqueDataGridView)).BeginInit();
            this.uniqueTableLayoutPanel.SuspendLayout();
            this.classBreakTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classDataGridView)).BeginInit();
            this.classTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.geoUniqueValueRendererBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.renderMethodCB);
            this.PagePanel.Controls.Add(this.renderTabControl);
            this.PagePanel.Size = new System.Drawing.Size(480, 565);
            // 
            // renderTabControl
            // 
            this.renderTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderTabControl.Controls.Add(this.simpleTab);
            this.renderTabControl.Controls.Add(this.uniqueValueTab);
            this.renderTabControl.Controls.Add(this.classBreakTab);
            this.renderTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.renderTabControl.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.renderTabControl.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.renderTabControl.ItemSize = new System.Drawing.Size(150, 40);
            this.renderTabControl.Location = new System.Drawing.Point(0, 37);
            this.renderTabControl.MainPage = "";
            this.renderTabControl.Name = "renderTabControl";
            this.renderTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.renderTabControl.SelectedIndex = 0;
            this.renderTabControl.Size = new System.Drawing.Size(480, 528);
            this.renderTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.renderTabControl.Style = Sunny.UI.UIStyle.Custom;
            this.renderTabControl.StyleCustomMode = true;
            this.renderTabControl.TabIndex = 0;
            // 
            // simpleTab
            // 
            this.simpleTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.simpleTab.Controls.Add(this.tableLayoutPanel1);
            this.simpleTab.Location = new System.Drawing.Point(0, 40);
            this.simpleTab.Name = "simpleTab";
            this.simpleTab.Size = new System.Drawing.Size(480, 488);
            this.simpleTab.TabIndex = 0;
            this.simpleTab.Text = "simple";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.markerColorPicker, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sizeDoubleUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.markerStyleComboBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 137);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(94, 49);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "标记颜色";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(3, 49);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(94, 39);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "标记大小";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(3, 88);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(94, 49);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 7;
            this.uiLabel7.Text = "标记样式";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // markerColorPicker
            // 
            this.markerColorPicker.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.markerColorPicker.FillColor = System.Drawing.Color.White;
            this.markerColorPicker.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.markerColorPicker.Location = new System.Drawing.Point(104, 5);
            this.markerColorPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.markerColorPicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.markerColorPicker.Name = "markerColorPicker";
            this.markerColorPicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.markerColorPicker.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.markerColorPicker.Size = new System.Drawing.Size(295, 39);
            this.markerColorPicker.Style = Sunny.UI.UIStyle.Office2010Black;
            this.markerColorPicker.StyleCustomMode = true;
            this.markerColorPicker.TabIndex = 8;
            this.markerColorPicker.Text = "uiColorPicker1";
            this.markerColorPicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.markerColorPicker.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.markerColorPicker.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.markerColorPicker_ValueChanged);
            // 
            // sizeDoubleUpDown
            // 
            this.sizeDoubleUpDown.Decimal = 2;
            this.sizeDoubleUpDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.sizeDoubleUpDown.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.sizeDoubleUpDown.Location = new System.Drawing.Point(104, 54);
            this.sizeDoubleUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sizeDoubleUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.sizeDoubleUpDown.Name = "sizeDoubleUpDown";
            this.sizeDoubleUpDown.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.sizeDoubleUpDown.Size = new System.Drawing.Size(164, 29);
            this.sizeDoubleUpDown.Style = Sunny.UI.UIStyle.Office2010Black;
            this.sizeDoubleUpDown.StyleCustomMode = true;
            this.sizeDoubleUpDown.TabIndex = 12;
            this.sizeDoubleUpDown.Text = "uiDoubleUpDown1";
            this.sizeDoubleUpDown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.sizeDoubleUpDown.Value = 0D;
            // 
            // markerStyleComboBox
            // 
            this.markerStyleComboBox.FillColor = System.Drawing.Color.White;
            this.markerStyleComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.markerStyleComboBox.Location = new System.Drawing.Point(104, 93);
            this.markerStyleComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.markerStyleComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.markerStyleComboBox.Name = "markerStyleComboBox";
            this.markerStyleComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.markerStyleComboBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.markerStyleComboBox.Size = new System.Drawing.Size(295, 39);
            this.markerStyleComboBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.markerStyleComboBox.StyleCustomMode = true;
            this.markerStyleComboBox.TabIndex = 13;
            this.markerStyleComboBox.Text = "uiComboBox1";
            this.markerStyleComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.markerStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.markerStyleComboBox_SelectedIndexChanged);
            // 
            // uniqueValueTab
            // 
            this.uniqueValueTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.uniqueValueTab.Controls.Add(this.uniqueDataGridView);
            this.uniqueValueTab.Controls.Add(this.uniqueTableLayoutPanel);
            this.uniqueValueTab.Location = new System.Drawing.Point(0, 40);
            this.uniqueValueTab.Name = "uniqueValueTab";
            this.uniqueValueTab.Size = new System.Drawing.Size(480, 488);
            this.uniqueValueTab.TabIndex = 1;
            this.uniqueValueTab.Text = "unique value";
            // 
            // uniqueDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uniqueDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uniqueDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uniqueDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.uniqueDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uniqueDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uniqueDataGridView.ColumnHeadersHeight = 32;
            this.uniqueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uniqueDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbolCol,
            this.valueCol});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uniqueDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.uniqueDataGridView.EnableHeadersVisualStyles = false;
            this.uniqueDataGridView.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uniqueDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uniqueDataGridView.Location = new System.Drawing.Point(12, 148);
            this.uniqueDataGridView.Name = "uniqueDataGridView";
            this.uniqueDataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uniqueDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.uniqueDataGridView.RowHeadersVisible = false;
            this.uniqueDataGridView.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.uniqueDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uniqueDataGridView.RowTemplate.Height = 29;
            this.uniqueDataGridView.SelectedIndex = -1;
            this.uniqueDataGridView.ShowGridLine = true;
            this.uniqueDataGridView.Size = new System.Drawing.Size(456, 328);
            this.uniqueDataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uniqueDataGridView.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uniqueDataGridView.StyleCustomMode = true;
            this.uniqueDataGridView.TabIndex = 6;
            // 
            // uniqueTableLayoutPanel
            // 
            this.uniqueTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueTableLayoutPanel.AutoSize = true;
            this.uniqueTableLayoutPanel.ColumnCount = 2;
            this.uniqueTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.uniqueTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uniqueTableLayoutPanel.Controls.Add(this.uiLabel8, 0, 2);
            this.uniqueTableLayoutPanel.Controls.Add(this.uiLabel4, 0, 0);
            this.uniqueTableLayoutPanel.Controls.Add(this.uiLabel6, 0, 1);
            this.uniqueTableLayoutPanel.Controls.Add(this.uniqueFieldComboBox, 1, 0);
            this.uniqueTableLayoutPanel.Controls.Add(this.uniqueColorgradComboBox, 1, 1);
            this.uniqueTableLayoutPanel.Location = new System.Drawing.Point(12, 3);
            this.uniqueTableLayoutPanel.Name = "uniqueTableLayoutPanel";
            this.uniqueTableLayoutPanel.RowCount = 3;
            this.uniqueTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.uniqueTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.uniqueTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.uniqueTableLayoutPanel.Size = new System.Drawing.Size(456, 139);
            this.uniqueTableLayoutPanel.TabIndex = 5;
            // 
            // uiLabel8
            // 
            this.uiLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(3, 99);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(94, 40);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 15;
            this.uiLabel8.Text = "默认标记";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(3, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(94, 49);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 2;
            this.uiLabel4.Text = "唯一值字段";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(3, 49);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(94, 50);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 5;
            this.uiLabel6.Text = "颜色渐变";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uniqueFieldComboBox
            // 
            this.uniqueFieldComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uniqueFieldComboBox.FillColor = System.Drawing.Color.White;
            this.uniqueFieldComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uniqueFieldComboBox.Location = new System.Drawing.Point(104, 5);
            this.uniqueFieldComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uniqueFieldComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.uniqueFieldComboBox.Name = "uniqueFieldComboBox";
            this.uniqueFieldComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uniqueFieldComboBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uniqueFieldComboBox.Size = new System.Drawing.Size(348, 39);
            this.uniqueFieldComboBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uniqueFieldComboBox.StyleCustomMode = true;
            this.uniqueFieldComboBox.TabIndex = 13;
            this.uniqueFieldComboBox.Text = "uiComboBox2";
            this.uniqueFieldComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uniqueFieldComboBox.SelectedIndexChanged += new System.EventHandler(this.uniqueFieldComboBox_SelectedIndexChanged);
            // 
            // uniqueColorgradComboBox
            // 
            this.uniqueColorgradComboBox.BackColor = System.Drawing.Color.White;
            this.uniqueColorgradComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uniqueColorgradComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.uniqueColorgradComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uniqueColorgradComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uniqueColorgradComboBox.Location = new System.Drawing.Point(104, 54);
            this.uniqueColorgradComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uniqueColorgradComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.uniqueColorgradComboBox.Name = "uniqueColorgradComboBox";
            this.uniqueColorgradComboBox.Size = new System.Drawing.Size(348, 40);
            this.uniqueColorgradComboBox.TabIndex = 14;
            this.uniqueColorgradComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.UniqueColorComboboxEx_DrawItem);
            // 
            // classBreakTab
            // 
            this.classBreakTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.classBreakTab.Controls.Add(this.uiIntegerUpDown1);
            this.classBreakTab.Controls.Add(this.uiLabel3);
            this.classBreakTab.Controls.Add(this.classDataGridView);
            this.classBreakTab.Controls.Add(this.classTableLayoutPanel);
            this.classBreakTab.Location = new System.Drawing.Point(0, 40);
            this.classBreakTab.Name = "classBreakTab";
            this.classBreakTab.Size = new System.Drawing.Size(480, 488);
            this.classBreakTab.TabIndex = 2;
            this.classBreakTab.Text = "class break";
            // 
            // uiIntegerUpDown1
            // 
            this.uiIntegerUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiIntegerUpDown1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiIntegerUpDown1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiIntegerUpDown1.Location = new System.Drawing.Point(69, 450);
            this.uiIntegerUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiIntegerUpDown1.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown1.Name = "uiIntegerUpDown1";
            this.uiIntegerUpDown1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiIntegerUpDown1.Size = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown1.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiIntegerUpDown1.StyleCustomMode = true;
            this.uiIntegerUpDown1.TabIndex = 10;
            this.uiIntegerUpDown1.Text = "uiIntegerUpDown1";
            this.uiIntegerUpDown1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiIntegerUpDown1.Value = 5;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(12, 450);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(0, 0);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.StyleCustomMode = true;
            this.uiLabel3.TabIndex = 9;
            this.uiLabel3.Text = "类别数";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // classDataGridView
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.classDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.classDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.classDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.classDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.classDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.classDataGridView.ColumnHeadersHeight = 32;
            this.classDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.classDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.classDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.classDataGridView.EnableHeadersVisualStyles = false;
            this.classDataGridView.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.classDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.classDataGridView.Location = new System.Drawing.Point(12, 153);
            this.classDataGridView.Name = "classDataGridView";
            this.classDataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.classDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.classDataGridView.RowHeadersVisible = false;
            this.classDataGridView.RowHeadersWidth = 62;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.classDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.classDataGridView.RowTemplate.Height = 29;
            this.classDataGridView.SelectedIndex = -1;
            this.classDataGridView.ShowGridLine = true;
            this.classDataGridView.Size = new System.Drawing.Size(456, 323);
            this.classDataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.classDataGridView.Style = Sunny.UI.UIStyle.Office2010Black;
            this.classDataGridView.StyleCustomMode = true;
            this.classDataGridView.TabIndex = 8;
            // 
            // classTableLayoutPanel
            // 
            this.classTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classTableLayoutPanel.AutoSize = true;
            this.classTableLayoutPanel.ColumnCount = 2;
            this.classTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.classTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.classTableLayoutPanel.Controls.Add(this.uiLabel11, 0, 2);
            this.classTableLayoutPanel.Controls.Add(this.uiLabel9, 0, 0);
            this.classTableLayoutPanel.Controls.Add(this.uiLabel10, 0, 1);
            this.classTableLayoutPanel.Controls.Add(this.classFieldComboBox, 1, 0);
            this.classTableLayoutPanel.Controls.Add(this.classColorgradComboBox, 1, 1);
            this.classTableLayoutPanel.Location = new System.Drawing.Point(12, 8);
            this.classTableLayoutPanel.Name = "classTableLayoutPanel";
            this.classTableLayoutPanel.RowCount = 3;
            this.classTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.classTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.classTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.classTableLayoutPanel.Size = new System.Drawing.Size(456, 139);
            this.classTableLayoutPanel.TabIndex = 7;
            // 
            // uiLabel11
            // 
            this.uiLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(3, 99);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(94, 40);
            this.uiLabel11.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel11.TabIndex = 15;
            this.uiLabel11.Text = "默认颜色";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(3, 0);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(94, 49);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 2;
            this.uiLabel9.Text = "分类字段";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel10
            // 
            this.uiLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(3, 49);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(94, 50);
            this.uiLabel10.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel10.TabIndex = 5;
            this.uiLabel10.Text = "颜色渐变";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // classFieldComboBox
            // 
            this.classFieldComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classFieldComboBox.FillColor = System.Drawing.Color.White;
            this.classFieldComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.classFieldComboBox.Location = new System.Drawing.Point(104, 5);
            this.classFieldComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.classFieldComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.classFieldComboBox.Name = "classFieldComboBox";
            this.classFieldComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.classFieldComboBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.classFieldComboBox.Size = new System.Drawing.Size(348, 39);
            this.classFieldComboBox.Style = Sunny.UI.UIStyle.Custom;
            this.classFieldComboBox.StyleCustomMode = true;
            this.classFieldComboBox.TabIndex = 13;
            this.classFieldComboBox.Text = "uiComboBox2";
            this.classFieldComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.classFieldComboBox.SelectedIndexChanged += new System.EventHandler(this.classFieldComboBox_SelectedIndexChanged);
            // 
            // classColorgradComboBox
            // 
            this.classColorgradComboBox.BackColor = System.Drawing.Color.White;
            this.classColorgradComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classColorgradComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.classColorgradComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classColorgradComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.classColorgradComboBox.Location = new System.Drawing.Point(104, 54);
            this.classColorgradComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.classColorgradComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.classColorgradComboBox.Name = "classColorgradComboBox";
            this.classColorgradComboBox.Size = new System.Drawing.Size(348, 40);
            this.classColorgradComboBox.TabIndex = 14;
            this.classColorgradComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ClassBreaksComboboxEx_DrawItem);
            // 
            // renderMethodCB
            // 
            this.renderMethodCB.Dock = System.Windows.Forms.DockStyle.Top;
            this.renderMethodCB.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.renderMethodCB.FillColor = System.Drawing.Color.White;
            this.renderMethodCB.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.renderMethodCB.Items.AddRange(new object[] {
            "单一符号",
            "唯一值",
            "分级符号"});
            this.renderMethodCB.Location = new System.Drawing.Point(0, 0);
            this.renderMethodCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.renderMethodCB.MinimumSize = new System.Drawing.Size(63, 0);
            this.renderMethodCB.Name = "renderMethodCB";
            this.renderMethodCB.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.renderMethodCB.Size = new System.Drawing.Size(480, 39);
            this.renderMethodCB.TabIndex = 1;
            this.renderMethodCB.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // geoUniqueValueRendererBindingSource
            // 
            this.geoUniqueValueRendererBindingSource.DataSource = typeof(DEETU.Core.GeoUniqueValueRenderer);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DividerWidth = 1;
            this.dataGridViewButtonColumn1.FillWeight = 30.45685F;
            this.dataGridViewButtonColumn1.HeaderText = "符号";
            this.dataGridViewButtonColumn1.MinimumWidth = 8;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 169.5432F;
            this.dataGridViewTextBoxColumn1.HeaderText = "分类值";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // symbolCol
            // 
            this.symbolCol.DividerWidth = 1;
            this.symbolCol.FillWeight = 30.45685F;
            this.symbolCol.HeaderText = "符号";
            this.symbolCol.MinimumWidth = 8;
            this.symbolCol.Name = "symbolCol";
            this.symbolCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // valueCol
            // 
            this.valueCol.FillWeight = 169.5432F;
            this.valueCol.HeaderText = "唯一值";
            this.valueCol.MinimumWidth = 8;
            this.valueCol.Name = "valueCol";
            // 
            // MarkerSymbolPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(480, 600);
            this.Name = "MarkerSymbolPage";
            this.Text = "符号化";
            this.PagePanel.ResumeLayout(false);
            this.renderTabControl.ResumeLayout(false);
            this.simpleTab.ResumeLayout(false);
            this.simpleTab.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uniqueValueTab.ResumeLayout(false);
            this.uniqueValueTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniqueDataGridView)).EndInit();
            this.uniqueTableLayoutPanel.ResumeLayout(false);
            this.classBreakTab.ResumeLayout(false);
            this.classBreakTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classDataGridView)).EndInit();
            this.classTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.geoUniqueValueRendererBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIComboBox renderMethodCB;
        private Sunny.UI.UITabControl renderTabControl;
        private System.Windows.Forms.TabPage simpleTab;
        private System.Windows.Forms.TabPage uniqueValueTab;
        private System.Windows.Forms.TabPage classBreakTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIColorPicker markerColorPicker;
        private Sunny.UI.UIDoubleUpDown sizeDoubleUpDown;
        private Sunny.UI.UIComboBox markerStyleComboBox;
        private System.Windows.Forms.TableLayoutPanel uniqueTableLayoutPanel;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIDataGridView uniqueDataGridView;
        private Sunny.UI.UIComboBox uniqueFieldComboBox;
        private System.Windows.Forms.ComboBox uniqueColorgradComboBox;
        private Sunny.UI.UIDataGridView classDataGridView;
        private System.Windows.Forms.TableLayoutPanel classTableLayoutPanel;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UIComboBox classFieldComboBox;
        private System.Windows.Forms.ComboBox classColorgradComboBox;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown1;
        private Sunny.UI.UILabel uiLabel3;
        private System.Windows.Forms.BindingSource geoUniqueValueRendererBindingSource;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel11;
        private System.Windows.Forms.DataGridViewImageColumn symbolCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueCol;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}