
namespace DEETU.Source.Window
{
    partial class AnnotationPage
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
            this.fieldComboBox = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.fontTitlePanel = new Sunny.UI.UITitlePanel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.fontColotPicker = new Sunny.UI.UIColorPicker();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.fontButton = new Sunny.UI.UIButton();
            this.fontTextBox = new Sunny.UI.UITextBox();
            this.maskTitlePanel = new Sunny.UI.UITitlePanel();
            this.maskCheckBox = new Sunny.UI.UICheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.maskColorPicker = new Sunny.UI.UIColorPicker();
            this.maskSizeDoubleUpDown = new Sunny.UI.UIDoubleUpDown();
            this.posTitlePanel = new Sunny.UI.UITitlePanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.xOffsetDoubleUpDown = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.yOffsetDoubleUpDown = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.alignmentRadioButtonGroup = new Sunny.UI.UIRadioButtonGroup();
            this.labelPanel = new Sunny.UI.UIPanel();
            this.enableCheckBox = new Sunny.UI.UICheckBox();
            this.PagePanel.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.fontTitlePanel.SuspendLayout();
            this.maskTitlePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.posTitlePanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.labelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.enableCheckBox);
            this.PagePanel.Controls.Add(this.labelPanel);
            this.PagePanel.Size = new System.Drawing.Size(480, 709);
            // 
            // fieldComboBox
            // 
            this.fieldComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldComboBox.FillColor = System.Drawing.Color.White;
            this.fieldComboBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fieldComboBox.Location = new System.Drawing.Point(112, 57);
            this.fieldComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fieldComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.fieldComboBox.Name = "fieldComboBox";
            this.fieldComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.fieldComboBox.Size = new System.Drawing.Size(364, 29);
            this.fieldComboBox.TabIndex = 2;
            this.fieldComboBox.Text = "uiComboBox1";
            this.fieldComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.fieldComboBox.SelectedIndexChanged += new System.EventHandler(this.fieldComboBox_SelectedIndexChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(5, 57);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 29);
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "注记字段";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRichTextBox1.FillColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRichTextBox1.Location = new System.Drawing.Point(0, 25);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiRichTextBox1.Size = new System.Drawing.Size(472, 73);
            this.uiRichTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRichTextBox1.TabIndex = 4;
            this.uiRichTextBox1.Text = "Lorem Ipsum 乱数假文";
            this.uiRichTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTitlePanel1.Controls.Add(this.uiRichTextBox1);
            this.uiTitlePanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.uiTitlePanel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.uiTitlePanel1.Location = new System.Drawing.Point(4, 91);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.uiTitlePanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            this.uiTitlePanel1.ShowCollapse = true;
            this.uiTitlePanel1.Size = new System.Drawing.Size(472, 98);
            this.uiTitlePanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.StyleCustomMode = true;
            this.uiTitlePanel1.TabIndex = 5;
            this.uiTitlePanel1.Text = "文本样例";
            this.uiTitlePanel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.Silver;
            this.uiTitlePanel1.TitleHeight = 25;
            // 
            // fontTitlePanel
            // 
            this.fontTitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontTitlePanel.Controls.Add(this.uiLabel8);
            this.fontTitlePanel.Controls.Add(this.fontColotPicker);
            this.fontTitlePanel.Controls.Add(this.uiLabel7);
            this.fontTitlePanel.Controls.Add(this.fontButton);
            this.fontTitlePanel.Controls.Add(this.fontTextBox);
            this.fontTitlePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.fontTitlePanel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fontTitlePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.fontTitlePanel.Location = new System.Drawing.Point(4, 199);
            this.fontTitlePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fontTitlePanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.fontTitlePanel.Name = "fontTitlePanel";
            this.fontTitlePanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.fontTitlePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            this.fontTitlePanel.ShowCollapse = true;
            this.fontTitlePanel.Size = new System.Drawing.Size(472, 97);
            this.fontTitlePanel.Style = Sunny.UI.UIStyle.Custom;
            this.fontTitlePanel.StyleCustomMode = true;
            this.fontTitlePanel.TabIndex = 6;
            this.fontTitlePanel.Text = "字体";
            this.fontTitlePanel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.fontTitlePanel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.fontTitlePanel.TitleColor = System.Drawing.Color.Silver;
            this.fontTitlePanel.TitleHeight = 25;
            // 
            // uiLabel8
            // 
            this.uiLabel8.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(3, 30);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(90, 29);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 6;
            this.uiLabel8.Text = "字体";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontColotPicker
            // 
            this.fontColotPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontColotPicker.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.fontColotPicker.FillColor = System.Drawing.Color.White;
            this.fontColotPicker.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fontColotPicker.Location = new System.Drawing.Point(96, 63);
            this.fontColotPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fontColotPicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.fontColotPicker.Name = "fontColotPicker";
            this.fontColotPicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.fontColotPicker.Size = new System.Drawing.Size(336, 29);
            this.fontColotPicker.Style = Sunny.UI.UIStyle.Custom;
            this.fontColotPicker.TabIndex = 5;
            this.fontColotPicker.Text = "fontColorPicker";
            this.fontColotPicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.fontColotPicker.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.fontColotPicker.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.fontColotPicker_ValueChanged);
            // 
            // uiLabel7
            // 
            this.uiLabel7.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(4, 63);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(90, 29);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 4;
            this.uiLabel7.Text = "字体颜色";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontButton
            // 
            this.fontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fontButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fontButton.Location = new System.Drawing.Point(440, 30);
            this.fontButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.fontButton.Name = "fontButton";
            this.fontButton.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.fontButton.Size = new System.Drawing.Size(24, 26);
            this.fontButton.Style = Sunny.UI.UIStyle.Custom;
            this.fontButton.TabIndex = 1;
            this.fontButton.Text = "...";
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // fontTextBox
            // 
            this.fontTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fontTextBox.FillColor = System.Drawing.Color.White;
            this.fontTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fontTextBox.Location = new System.Drawing.Point(97, 30);
            this.fontTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fontTextBox.Maximum = 2147483647D;
            this.fontTextBox.Minimum = -2147483648D;
            this.fontTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.fontTextBox.Name = "fontTextBox";
            this.fontTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.fontTextBox.Size = new System.Drawing.Size(336, 29);
            this.fontTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.fontTextBox.TabIndex = 0;
            this.fontTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maskTitlePanel
            // 
            this.maskTitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskTitlePanel.Controls.Add(this.maskCheckBox);
            this.maskTitlePanel.Controls.Add(this.tableLayoutPanel1);
            this.maskTitlePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.maskTitlePanel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maskTitlePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.maskTitlePanel.Location = new System.Drawing.Point(4, 306);
            this.maskTitlePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maskTitlePanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.maskTitlePanel.Name = "maskTitlePanel";
            this.maskTitlePanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.maskTitlePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            this.maskTitlePanel.ShowCollapse = true;
            this.maskTitlePanel.Size = new System.Drawing.Size(472, 148);
            this.maskTitlePanel.Style = Sunny.UI.UIStyle.Custom;
            this.maskTitlePanel.StyleCustomMode = true;
            this.maskTitlePanel.TabIndex = 7;
            this.maskTitlePanel.Text = "描边";
            this.maskTitlePanel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskTitlePanel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.maskTitlePanel.TitleColor = System.Drawing.Color.Silver;
            this.maskTitlePanel.TitleHeight = 25;
            // 
            // maskCheckBox
            // 
            this.maskCheckBox.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.maskCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maskCheckBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.maskCheckBox.Location = new System.Drawing.Point(4, 36);
            this.maskCheckBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.maskCheckBox.Name = "maskCheckBox";
            this.maskCheckBox.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.maskCheckBox.Size = new System.Drawing.Size(150, 29);
            this.maskCheckBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.maskCheckBox.StyleCustomMode = true;
            this.maskCheckBox.TabIndex = 6;
            this.maskCheckBox.Text = "是否使用描边";
            this.maskCheckBox.CheckedChanged += new System.EventHandler(this.maskCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.maskColorPicker, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.maskSizeDoubleUpDown, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 61);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(465, 82);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(94, 39);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "描边颜色";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(3, 39);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(94, 43);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "描边宽度";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maskColorPicker
            // 
            this.maskColorPicker.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.maskColorPicker.FillColor = System.Drawing.Color.White;
            this.maskColorPicker.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.maskColorPicker.Location = new System.Drawing.Point(104, 5);
            this.maskColorPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maskColorPicker.MinimumSize = new System.Drawing.Size(63, 0);
            this.maskColorPicker.Name = "maskColorPicker";
            this.maskColorPicker.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.maskColorPicker.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.maskColorPicker.Size = new System.Drawing.Size(295, 29);
            this.maskColorPicker.Style = Sunny.UI.UIStyle.Office2010Black;
            this.maskColorPicker.StyleCustomMode = true;
            this.maskColorPicker.TabIndex = 9;
            this.maskColorPicker.Text = "uiColorPicker2";
            this.maskColorPicker.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.maskColorPicker.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.maskColorPicker.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.maskColorPicker_ValueChanged);
            // 
            // maskSizeDoubleUpDown
            // 
            this.maskSizeDoubleUpDown.Decimal = 2;
            this.maskSizeDoubleUpDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.maskSizeDoubleUpDown.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.maskSizeDoubleUpDown.Location = new System.Drawing.Point(104, 44);
            this.maskSizeDoubleUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maskSizeDoubleUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.maskSizeDoubleUpDown.Name = "maskSizeDoubleUpDown";
            this.maskSizeDoubleUpDown.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.maskSizeDoubleUpDown.Size = new System.Drawing.Size(164, 29);
            this.maskSizeDoubleUpDown.Style = Sunny.UI.UIStyle.Office2010Black;
            this.maskSizeDoubleUpDown.StyleCustomMode = true;
            this.maskSizeDoubleUpDown.TabIndex = 12;
            this.maskSizeDoubleUpDown.Text = "uiDoubleUpDown1";
            this.maskSizeDoubleUpDown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.maskSizeDoubleUpDown.Value = 0D;
            this.maskSizeDoubleUpDown.ValueChanged += new Sunny.UI.UIDoubleUpDown.OnValueChanged(this.maskSizeDoubleUpDown_ValueChanged);
            // 
            // posTitlePanel
            // 
            this.posTitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.posTitlePanel.Controls.Add(this.tableLayoutPanel2);
            this.posTitlePanel.Controls.Add(this.uiLabel3);
            this.posTitlePanel.Controls.Add(this.alignmentRadioButtonGroup);
            this.posTitlePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.posTitlePanel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.posTitlePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.posTitlePanel.Location = new System.Drawing.Point(4, 464);
            this.posTitlePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.posTitlePanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.posTitlePanel.Name = "posTitlePanel";
            this.posTitlePanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.posTitlePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(144)))), ((int)(((byte)(151)))));
            this.posTitlePanel.ShowCollapse = true;
            this.posTitlePanel.Size = new System.Drawing.Size(472, 240);
            this.posTitlePanel.Style = Sunny.UI.UIStyle.Custom;
            this.posTitlePanel.StyleCustomMode = true;
            this.posTitlePanel.TabIndex = 8;
            this.posTitlePanel.Text = "位置";
            this.posTitlePanel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.posTitlePanel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.posTitlePanel.TitleColor = System.Drawing.Color.Silver;
            this.posTitlePanel.TitleHeight = 25;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.xOffsetDoubleUpDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiLabel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiLabel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.yOffsetDoubleUpDown, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(96, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(272, 60);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // xOffsetDoubleUpDown
            // 
            this.xOffsetDoubleUpDown.Decimal = 2;
            this.xOffsetDoubleUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xOffsetDoubleUpDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.xOffsetDoubleUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xOffsetDoubleUpDown.Location = new System.Drawing.Point(104, 5);
            this.xOffsetDoubleUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xOffsetDoubleUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.xOffsetDoubleUpDown.Name = "xOffsetDoubleUpDown";
            this.xOffsetDoubleUpDown.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.xOffsetDoubleUpDown.Size = new System.Drawing.Size(164, 20);
            this.xOffsetDoubleUpDown.Style = Sunny.UI.UIStyle.Office2010Black;
            this.xOffsetDoubleUpDown.StyleCustomMode = true;
            this.xOffsetDoubleUpDown.TabIndex = 13;
            this.xOffsetDoubleUpDown.Text = "xOffsetDoubleUpDown";
            this.xOffsetDoubleUpDown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xOffsetDoubleUpDown.Value = 0D;
            this.xOffsetDoubleUpDown.ValueChanged += new Sunny.UI.UIDoubleUpDown.OnValueChanged(this.xOffsetDoubleUpDown_ValueChanged);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(3, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(94, 30);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 1;
            this.uiLabel4.Text = "横坐标";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(3, 30);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(94, 30);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 5;
            this.uiLabel6.Text = "纵坐标";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yOffsetDoubleUpDown
            // 
            this.yOffsetDoubleUpDown.Decimal = 2;
            this.yOffsetDoubleUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yOffsetDoubleUpDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.yOffsetDoubleUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yOffsetDoubleUpDown.Location = new System.Drawing.Point(104, 35);
            this.yOffsetDoubleUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.yOffsetDoubleUpDown.MinimumSize = new System.Drawing.Size(100, 0);
            this.yOffsetDoubleUpDown.Name = "yOffsetDoubleUpDown";
            this.yOffsetDoubleUpDown.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.yOffsetDoubleUpDown.Size = new System.Drawing.Size(164, 20);
            this.yOffsetDoubleUpDown.Style = Sunny.UI.UIStyle.Office2010Black;
            this.yOffsetDoubleUpDown.StyleCustomMode = true;
            this.yOffsetDoubleUpDown.TabIndex = 12;
            this.yOffsetDoubleUpDown.Text = "yOffsetDoubleUpDown1";
            this.yOffsetDoubleUpDown.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.yOffsetDoubleUpDown.Value = 0D;
            this.yOffsetDoubleUpDown.ValueChanged += new Sunny.UI.UIDoubleUpDown.OnValueChanged(this.yOffsetDoubleUpDown_ValueChanged);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(3, 35);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(91, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 1;
            this.uiLabel3.Text = "坐标偏移：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // alignmentRadioButtonGroup
            // 
            this.alignmentRadioButtonGroup.ColumnCount = 3;
            this.alignmentRadioButtonGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.alignmentRadioButtonGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alignmentRadioButtonGroup.Items.AddRange(new object[] {
            "TopLeft",
            "TopCenter",
            "TopRight",
            "CenterLeft",
            "CenterCenter",
            "CenterRight",
            "BottomLeft",
            "BottomCenter",
            "BottomRight"});
            this.alignmentRadioButtonGroup.Location = new System.Drawing.Point(0, 97);
            this.alignmentRadioButtonGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alignmentRadioButtonGroup.MinimumSize = new System.Drawing.Size(1, 1);
            this.alignmentRadioButtonGroup.Name = "alignmentRadioButtonGroup";
            this.alignmentRadioButtonGroup.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.alignmentRadioButtonGroup.Size = new System.Drawing.Size(472, 143);
            this.alignmentRadioButtonGroup.Style = Sunny.UI.UIStyle.Custom;
            this.alignmentRadioButtonGroup.TabIndex = 0;
            this.alignmentRadioButtonGroup.Text = "布局";
            this.alignmentRadioButtonGroup.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.alignmentRadioButtonGroup.ValueChanged += new Sunny.UI.UIRadioButtonGroup.OnValueChanged(this.alignmentRadioButtonGroup_ValueChanged);
            // 
            // labelPanel
            // 
            this.labelPanel.Controls.Add(this.posTitlePanel);
            this.labelPanel.Controls.Add(this.uiLabel1);
            this.labelPanel.Controls.Add(this.fontTitlePanel);
            this.labelPanel.Controls.Add(this.maskTitlePanel);
            this.labelPanel.Controls.Add(this.fieldComboBox);
            this.labelPanel.Controls.Add(this.uiTitlePanel1);
            this.labelPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelPanel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelPanel.Location = new System.Drawing.Point(0, -19);
            this.labelPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelPanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(480, 728);
            this.labelPanel.TabIndex = 9;
            this.labelPanel.Text = null;
            this.labelPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.enableCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enableCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.enableCheckBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.enableCheckBox.Location = new System.Drawing.Point(0, 0);
            this.enableCheckBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.enableCheckBox.Size = new System.Drawing.Size(480, 29);
            this.enableCheckBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.enableCheckBox.StyleCustomMode = true;
            this.enableCheckBox.TabIndex = 7;
            this.enableCheckBox.Text = "开启注记";
            this.enableCheckBox.CheckedChanged += new System.EventHandler(this.enableCheckBox_CheckedChanged);
            // 
            // AnnotationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 744);
            this.Name = "AnnotationPage";
            this.Text = "注记";
            this.PagePanel.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.fontTitlePanel.ResumeLayout(false);
            this.maskTitlePanel.ResumeLayout(false);
            this.maskTitlePanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.posTitlePanel.ResumeLayout(false);
            this.posTitlePanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.labelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox fieldComboBox;
        private Sunny.UI.UITitlePanel posTitlePanel;
        private Sunny.UI.UITitlePanel maskTitlePanel;
        private Sunny.UI.UITitlePanel fontTitlePanel;
        private Sunny.UI.UIButton fontButton;
        private Sunny.UI.UITextBox fontTextBox;
        private Sunny.UI.UICheckBox maskCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIColorPicker maskColorPicker;
        private Sunny.UI.UIDoubleUpDown maskSizeDoubleUpDown;
        private Sunny.UI.UIRadioButtonGroup alignmentRadioButtonGroup;
        private Sunny.UI.UICheckBox enableCheckBox;
        private Sunny.UI.UIPanel labelPanel;
        private Sunny.UI.UILabel uiLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UIDoubleUpDown xOffsetDoubleUpDown;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIDoubleUpDown yOffsetDoubleUpDown;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIColorPicker fontColotPicker;
        private Sunny.UI.UILabel uiLabel7;
    }
}