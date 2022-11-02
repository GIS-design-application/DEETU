namespace DEETU.Source.Window
{
    partial class CrsTransferForm
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
            this.okButton = new Sunny.UI.UIButton();
            this.cancelButton = new Sunny.UI.UIButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.targetCrsTest = new Sunny.UI.UITextBox();
            this.sourceCrsText = new Sunny.UI.UITextBox();
            this.chooseCrsButton = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(2, 161);
            this.pnlBtm.Size = new System.Drawing.Size(509, 1);
            this.pnlBtm.Style = Sunny.UI.UIStyle.Custom;
            this.pnlBtm.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.okButton.Location = new System.Drawing.Point(328, 126);
            this.okButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 35);
            this.okButton.Style = Sunny.UI.UIStyle.Custom;
            this.okButton.TabIndex = 0;
            this.okButton.Text = "确认";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cancelButton.Location = new System.Drawing.Point(422, 126);
            this.cancelButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 35);
            this.cancelButton.Style = Sunny.UI.UIStyle.Custom;
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "取消";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.targetCrsTest, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sourceCrsText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chooseCrsButton, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 71);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // targetCrsTest
            // 
            this.targetCrsTest.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.targetCrsTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetCrsTest.FillColor = System.Drawing.Color.White;
            this.targetCrsTest.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.targetCrsTest.Location = new System.Drawing.Point(4, 40);
            this.targetCrsTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetCrsTest.Maximum = 2147483647D;
            this.targetCrsTest.Minimum = -2147483648D;
            this.targetCrsTest.MinimumSize = new System.Drawing.Size(1, 1);
            this.targetCrsTest.Name = "targetCrsTest";
            this.targetCrsTest.Padding = new System.Windows.Forms.Padding(5);
            this.targetCrsTest.Size = new System.Drawing.Size(459, 29);
            this.targetCrsTest.Style = Sunny.UI.UIStyle.Custom;
            this.targetCrsTest.TabIndex = 2;
            this.targetCrsTest.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sourceCrsText
            // 
            this.sourceCrsText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sourceCrsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceCrsText.FillColor = System.Drawing.Color.White;
            this.sourceCrsText.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.sourceCrsText.Location = new System.Drawing.Point(4, 5);
            this.sourceCrsText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sourceCrsText.Maximum = 2147483647D;
            this.sourceCrsText.Minimum = -2147483648D;
            this.sourceCrsText.MinimumSize = new System.Drawing.Size(1, 1);
            this.sourceCrsText.Name = "sourceCrsText";
            this.sourceCrsText.Padding = new System.Windows.Forms.Padding(5);
            this.sourceCrsText.Size = new System.Drawing.Size(459, 29);
            this.sourceCrsText.Style = Sunny.UI.UIStyle.Custom;
            this.sourceCrsText.TabIndex = 0;
            this.sourceCrsText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chooseCrsButton
            // 
            this.chooseCrsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseCrsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseCrsButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chooseCrsButton.Location = new System.Drawing.Point(470, 38);
            this.chooseCrsButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.chooseCrsButton.Name = "chooseCrsButton";
            this.chooseCrsButton.Size = new System.Drawing.Size(30, 30);
            this.chooseCrsButton.Style = Sunny.UI.UIStyle.Custom;
            this.chooseCrsButton.Symbol = 61761;
            this.chooseCrsButton.TabIndex = 4;
            this.chooseCrsButton.Click += new System.EventHandler(this.chooseCrsButton_Click);
            // 
            // CrsTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 164);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CrsTransferForm";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "坐标参照系转换";
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton okButton;
        private Sunny.UI.UIButton cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UITextBox targetCrsTest;
        private Sunny.UI.UITextBox sourceCrsText;
        private Sunny.UI.UISymbolButton chooseCrsButton;
    }
}