namespace DEETU.Source.Window
{
    partial class CrsEditForm
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
            this.geoComboBox = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.geoRichText = new Sunny.UI.UIRichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.projectComboBox = new Sunny.UI.UIComboBox();
            this.projectRichText = new Sunny.UI.UIRichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 423);
            this.pnlBtm.Size = new System.Drawing.Size(358, 54);
            // 
            // geoComboBox
            // 
            this.geoComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoComboBox.FillColor = System.Drawing.Color.White;
            this.geoComboBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.geoComboBox.Items.AddRange(new object[] {
            "(空）"});
            this.geoComboBox.Location = new System.Drawing.Point(4, 34);
            this.geoComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.geoComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.geoComboBox.Name = "geoComboBox";
            this.geoComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.geoComboBox.Size = new System.Drawing.Size(346, 26);
            this.geoComboBox.TabIndex = 0;
            this.geoComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.geoComboBox.SelectedIndexChanged += new System.EventHandler(this.geoComboBox_SelectedIndexChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(348, 29);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "地理坐标系";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // geoRichText
            // 
            this.geoRichText.AutoWordSelection = true;
            this.geoRichText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoRichText.FillColor = System.Drawing.Color.White;
            this.geoRichText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.geoRichText.Location = new System.Drawing.Point(4, 70);
            this.geoRichText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.geoRichText.MinimumSize = new System.Drawing.Size(1, 1);
            this.geoRichText.Name = "geoRichText";
            this.geoRichText.Padding = new System.Windows.Forms.Padding(2);
            this.geoRichText.Size = new System.Drawing.Size(346, 113);
            this.geoRichText.TabIndex = 2;
            this.geoRichText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.geoRichText, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.geoComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.projectComboBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.projectRichText, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 377);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 188);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(348, 29);
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "投影坐标系";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // projectComboBox
            // 
            this.projectComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectComboBox.FillColor = System.Drawing.Color.White;
            this.projectComboBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.projectComboBox.Items.AddRange(new object[] {
            "(空）"});
            this.projectComboBox.Location = new System.Drawing.Point(4, 222);
            this.projectComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectComboBox.MinimumSize = new System.Drawing.Size(63, 0);
            this.projectComboBox.Name = "projectComboBox";
            this.projectComboBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.projectComboBox.Size = new System.Drawing.Size(346, 26);
            this.projectComboBox.TabIndex = 3;
            this.projectComboBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.projectComboBox.SelectedIndexChanged += new System.EventHandler(this.projectComboBox_SelectedIndexChanged);
            // 
            // projectRichText
            // 
            this.projectRichText.AutoWordSelection = true;
            this.projectRichText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectRichText.FillColor = System.Drawing.Color.White;
            this.projectRichText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.projectRichText.Location = new System.Drawing.Point(4, 258);
            this.projectRichText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectRichText.MinimumSize = new System.Drawing.Size(1, 1);
            this.projectRichText.Name = "projectRichText";
            this.projectRichText.Padding = new System.Windows.Forms.Padding(2);
            this.projectRichText.Size = new System.Drawing.Size(346, 114);
            this.projectRichText.TabIndex = 5;
            this.projectRichText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CrsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CrsEditForm";
            this.Text = "选择坐标系";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIComboBox geoComboBox;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIRichTextBox geoRichText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox projectComboBox;
        private Sunny.UI.UIRichTextBox projectRichText;
    }
}