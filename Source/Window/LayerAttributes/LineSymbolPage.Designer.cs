﻿
namespace DEETU.Source.Window
{
    partial class LineSymbolPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.renderTabControl = new Sunny.UI.UITabControl();
            this.simpleTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.lineColorPicker = new Sunny.UI.UIColorPicker();
            this.sizeDoubleUpDown = new Sunny.UI.UIDoubleUpDown();
            this.styleComboBox = new Sunny.UI.UIComboBox();
            this.uniqueValueTab = new System.Windows.Forms.TabPage();
            this.uniqueDataGridView = new Sunny.UI.UIDataGridView();
            this.symbolCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.valueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uniqueTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uniqueFieldComboBox = new Sunny.UI.UIComboBox();
            this.uniqueColorgradComboBox = new Sunny.UI.UIComboBox();
            this.classBreakTab = new System.Windows.Forms.TabPage();
            this.uiIntegerUpDown1 = new Sunny.UI.UIIntegerUpDown();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiDataGridView2 = new Sunny.UI.UIDataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.classFieldComboBox = new Sunny.UI.UIComboBox();
            this.classColorgradComboBox = new Sunny.UI.UIComboBox();
            this.renderMethodCB = new Sunny.UI.UIComboBox();
            this.geoUniqueValueRendererBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PagePanel.SuspendLayout();
            this.renderTabControl.SuspendLayout();
            this.simpleTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.uniqueValueTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniqueDataGridView)).BeginInit();
            this.uniqueTableLayoutPanel.SuspendLayout();
            this.classBreakTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lineColorPicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.sizeDoubleUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.styleComboBox, 1, 3);
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
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(94, 49);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "描边颜色";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.uiLabel5.Text = "描边宽度";
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
            this.uiLabel7.Text = "描边样式";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineColorPicker
            // 
            this.lineColorPicker.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.lineColorPicker.FillColor = System.Drawing.Color.White;
            this.lineColorPicker.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lineColorPicker.Location = new System.Drawing.Point(104, 5);
            this.lineColorPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lineColorPicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.lineColorPicker.Name = "lineColorPicker";
            this.lineColorPicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.lineColorPicker.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.lineColorPicker.Size = new System.Drawing.Size(295, 39);
            this.lineColorPicker.Style = Sunny.UI.UIStyle.Office2010Black;
            this.lineColorPicker.StyleCustomMode = true;
            this.lineColorPicker.TabIndex = 9;
            this.lineColorPicker.Text = "uiColorPicker2";
            this.lineColorPicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lineColorPicker.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.lineColorPicker.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.lineColorPicker_ValueChanged);
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
            this.sizeDoubleUpDown.ValueChanged += new Sunny.UI.UIDoubleUpDown.OnValueChanged(this.sizeDoubleUpDown_ValueChanged);
            // 
            // styleComboBox
            // 
            this.styleComboBox.FillColor = System.Drawing.Color.White;
            this.styleComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.styleComboBox.Location = new System.Drawing.Point(104, 93);
            this.styleComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.styleComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.styleComboBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.styleComboBox.Size = new System.Drawing.Size(295, 39);
            this.styleComboBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.styleComboBox.StyleCustomMode = true;
            this.styleComboBox.TabIndex = 13;
            this.styleComboBox.Text = "uiComboBox1";
            this.styleComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.styleComboBox.SelectedIndexChanged += new System.EventHandler(this.styleComboBox_SelectedIndexChanged);
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
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uniqueDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle46;
            this.uniqueDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uniqueDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.uniqueDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle47.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uniqueDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.uniqueDataGridView.ColumnHeadersHeight = 32;
            this.uniqueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uniqueDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbolCol,
            this.valueCol});
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uniqueDataGridView.DefaultCellStyle = dataGridViewCellStyle48;
            this.uniqueDataGridView.EnableHeadersVisualStyles = false;
            this.uniqueDataGridView.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uniqueDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uniqueDataGridView.Location = new System.Drawing.Point(12, 127);
            this.uniqueDataGridView.Name = "uniqueDataGridView";
            this.uniqueDataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle49.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uniqueDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.uniqueDataGridView.RowHeadersVisible = false;
            this.uniqueDataGridView.RowHeadersWidth = 62;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.White;
            this.uniqueDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle50;
            this.uniqueDataGridView.RowTemplate.Height = 29;
            this.uniqueDataGridView.SelectedIndex = -1;
            this.uniqueDataGridView.ShowGridLine = true;
            this.uniqueDataGridView.Size = new System.Drawing.Size(0, 0);
            this.uniqueDataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uniqueDataGridView.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uniqueDataGridView.StyleCustomMode = true;
            this.uniqueDataGridView.TabIndex = 6;
            // 
            // symbolCol
            // 
            this.symbolCol.DividerWidth = 1;
            this.symbolCol.FillWeight = 30.45685F;
            this.symbolCol.HeaderText = "符号";
            this.symbolCol.MinimumWidth = 8;
            this.symbolCol.Name = "symbolCol";
            // 
            // valueCol
            // 
            this.valueCol.FillWeight = 169.5432F;
            this.valueCol.HeaderText = "唯一值";
            this.valueCol.MinimumWidth = 8;
            this.valueCol.Name = "valueCol";
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
            this.uniqueTableLayoutPanel.Size = new System.Drawing.Size(456, 137);
            this.uniqueTableLayoutPanel.TabIndex = 5;
            // 
            // uiLabel8
            // 
            this.uiLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(3, 98);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(94, 39);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 15;
            this.uiLabel8.Text = "默认符号";
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
            this.uiLabel6.Size = new System.Drawing.Size(94, 49);
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
            this.uniqueColorgradComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uniqueColorgradComboBox.FillColor = System.Drawing.Color.White;
            this.uniqueColorgradComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uniqueColorgradComboBox.Location = new System.Drawing.Point(104, 54);
            this.uniqueColorgradComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uniqueColorgradComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.uniqueColorgradComboBox.Name = "uniqueColorgradComboBox";
            this.uniqueColorgradComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uniqueColorgradComboBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uniqueColorgradComboBox.Size = new System.Drawing.Size(348, 39);
            this.uniqueColorgradComboBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uniqueColorgradComboBox.StyleCustomMode = true;
            this.uniqueColorgradComboBox.TabIndex = 14;
            this.uniqueColorgradComboBox.Text = "uiComboBox1";
            this.uniqueColorgradComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // classBreakTab
            // 
            this.classBreakTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.classBreakTab.Controls.Add(this.uiIntegerUpDown1);
            this.classBreakTab.Controls.Add(this.uiLabel3);
            this.classBreakTab.Controls.Add(this.uiDataGridView2);
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
            // uiDataGridView2
            // 
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle41;
            this.uiDataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle42.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle42.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle42;
            this.uiDataGridView2.ColumnHeadersHeight = 32;
            this.uiDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView2.DefaultCellStyle = dataGridViewCellStyle43;
            this.uiDataGridView2.EnableHeadersVisualStyles = false;
            this.uiDataGridView2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiDataGridView2.Location = new System.Drawing.Point(12, 133);
            this.uiDataGridView2.Name = "uiDataGridView2";
            this.uiDataGridView2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle44.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle44;
            this.uiDataGridView2.RowHeadersVisible = false;
            this.uiDataGridView2.RowHeadersWidth = 62;
            dataGridViewCellStyle45.BackColor = System.Drawing.Color.White;
            this.uiDataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle45;
            this.uiDataGridView2.RowTemplate.Height = 29;
            this.uiDataGridView2.SelectedIndex = -1;
            this.uiDataGridView2.ShowGridLine = true;
            this.uiDataGridView2.Size = new System.Drawing.Size(0, 0);
            this.uiDataGridView2.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiDataGridView2.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiDataGridView2.StyleCustomMode = true;
            this.uiDataGridView2.TabIndex = 8;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DividerWidth = 1;
            this.dataGridViewButtonColumn1.FillWeight = 30.45685F;
            this.dataGridViewButtonColumn1.HeaderText = "符号";
            this.dataGridViewButtonColumn1.MinimumWidth = 8;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 169.5432F;
            this.dataGridViewTextBoxColumn1.HeaderText = "分类值";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
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
            this.classTableLayoutPanel.Size = new System.Drawing.Size(426, 137);
            this.classTableLayoutPanel.TabIndex = 7;
            // 
            // uiLabel11
            // 
            this.uiLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(3, 98);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(94, 39);
            this.uiLabel11.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel11.TabIndex = 15;
            this.uiLabel11.Text = "默认符号";
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
            this.uiLabel10.Size = new System.Drawing.Size(94, 49);
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
            this.classFieldComboBox.Size = new System.Drawing.Size(318, 39);
            this.classFieldComboBox.Style = Sunny.UI.UIStyle.Custom;
            this.classFieldComboBox.StyleCustomMode = true;
            this.classFieldComboBox.TabIndex = 13;
            this.classFieldComboBox.Text = "uiComboBox2";
            this.classFieldComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.classFieldComboBox.SelectedIndexChanged += new System.EventHandler(this.classFieldComboBox_SelectedIndexChanged);
            // 
            // classColorgradComboBox
            // 
            this.classColorgradComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classColorgradComboBox.FillColor = System.Drawing.Color.White;
            this.classColorgradComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.classColorgradComboBox.Location = new System.Drawing.Point(104, 54);
            this.classColorgradComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.classColorgradComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.classColorgradComboBox.Name = "classColorgradComboBox";
            this.classColorgradComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.classColorgradComboBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.classColorgradComboBox.Size = new System.Drawing.Size(318, 39);
            this.classColorgradComboBox.Style = Sunny.UI.UIStyle.Custom;
            this.classColorgradComboBox.StyleCustomMode = true;
            this.classColorgradComboBox.TabIndex = 14;
            this.classColorgradComboBox.Text = "uiComboBox3";
            this.classColorgradComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.renderMethodCB.SelectedIndexChanged += new System.EventHandler(this.renderMethodCB_SelectedIndexChanged);
            // 
            // geoUniqueValueRendererBindingSource
            // 
            this.geoUniqueValueRendererBindingSource.DataSource = typeof(DEETU.Core.GeoUniqueValueRenderer);
            // 
            // LineSymbolPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(480, 600);
            this.Name = "LineSymbolPage";
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
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).EndInit();
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
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIColorPicker lineColorPicker;
        private Sunny.UI.UIDoubleUpDown sizeDoubleUpDown;
        private Sunny.UI.UIComboBox styleComboBox;
        private System.Windows.Forms.TableLayoutPanel uniqueTableLayoutPanel;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIDataGridView uniqueDataGridView;
        private Sunny.UI.UIComboBox uniqueFieldComboBox;
        private Sunny.UI.UIComboBox uniqueColorgradComboBox;
        private System.Windows.Forms.DataGridViewButtonColumn symbolCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueCol;
        private Sunny.UI.UIDataGridView uiDataGridView2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TableLayoutPanel classTableLayoutPanel;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UIComboBox classFieldComboBox;
        private Sunny.UI.UIComboBox classColorgradComboBox;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown1;
        private Sunny.UI.UILabel uiLabel3;
        private System.Windows.Forms.BindingSource geoUniqueValueRendererBindingSource;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel11;
    }
}