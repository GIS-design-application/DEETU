
namespace DEETU.Source.Window.LayerAttributes
{
    partial class EditMarkerSymbolPage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.markerColorPicker = new Sunny.UI.UIColorPicker();
            this.sizeDoubleUpDown = new Sunny.UI.UIDoubleUpDown();
            this.markerStyleComboBox = new Sunny.UI.UIComboBox();
            this.ConformButton = new Sunny.UI.UIButton();
            this.CancelButton = new Sunny.UI.UIButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            
            this.Controls.Add(this.ConformButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 6);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 137);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(94, 49);
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
            this.markerColorPicker.Size = new System.Drawing.Size(295, 29);
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
            this.sizeDoubleUpDown.ValueChanged += new Sunny.UI.UIDoubleUpDown.OnValueChanged(this.sizeDoubleUpDown_ValueChanged);
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
            this.markerStyleComboBox.Size = new System.Drawing.Size(295, 29);
            this.markerStyleComboBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.markerStyleComboBox.StyleCustomMode = true;
            this.markerStyleComboBox.TabIndex = 13;
            this.markerStyleComboBox.Text = "uiComboBox1";
            this.markerStyleComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.markerStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.markerStyleComboBox_SelectedIndexChanged);
            // 
            // ConformButton
            // 
            this.ConformButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConformButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ConformButton.Location = new System.Drawing.Point(76, 158);
            this.ConformButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.ConformButton.Name = "ConformButton";
            this.ConformButton.Size = new System.Drawing.Size(111, 44);
            this.ConformButton.TabIndex = 10;
            this.ConformButton.Text = "确定";
            this.ConformButton.Click += new System.EventHandler(this.ConformButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CancelButton.Location = new System.Drawing.Point(230, 158);
            this.CancelButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(111, 44);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "取消";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditMarkerSymbolPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 240);
            this.Name = "EditMarkerSymbolPage";
            this.ShowTitle = false;
            this.Text = "EditUniqueValueSymbolForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIColorPicker markerColorPicker;
        private Sunny.UI.UIDoubleUpDown sizeDoubleUpDown;
        private Sunny.UI.UIComboBox markerStyleComboBox;
        private Sunny.UI.UIButton ConformButton;
        private Sunny.UI.UIButton CancelButton;
    }
}