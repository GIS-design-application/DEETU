
namespace DEETU.Source.Window
{
    partial class FieldPage
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
            this.fieldDataGridView = new Sunny.UI.UIDataGridView();
            this.addFieldButton = new Sunny.UI.UISymbolButton();
            this.removeFieldButton = new Sunny.UI.UISymbolButton();
            this.editButton = new Sunny.UI.UISymbolButton();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.fieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.uiPanel1);
            this.PagePanel.Controls.Add(this.fieldDataGridView);
            this.PagePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.PagePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.PagePanel.Size = new System.Drawing.Size(480, 565);
            this.PagePanel.Style = Sunny.UI.UIStyle.Office2010Black;
            // 
            // fieldDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.fieldDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.fieldDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.fieldDataGridView.Location = new System.Drawing.Point(4, 53);
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
            this.fieldDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fieldDataGridView.ShowGridLine = true;
            this.fieldDataGridView.Size = new System.Drawing.Size(472, 500);
            this.fieldDataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.fieldDataGridView.Style = Sunny.UI.UIStyle.Custom;
            this.fieldDataGridView.StyleCustomMode = true;
            this.fieldDataGridView.TabIndex = 6;
            // 
            // addFieldButton
            // 
            this.addFieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addFieldButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFieldButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.addFieldButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.addFieldButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.addFieldButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.addFieldButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.addFieldButton.ForeColor = System.Drawing.Color.Black;
            this.addFieldButton.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.addFieldButton.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.addFieldButton.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.addFieldButton.Location = new System.Drawing.Point(3, 3);
            this.addFieldButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.addFieldButton.Name = "addFieldButton";
            this.addFieldButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.addFieldButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.addFieldButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.addFieldButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.addFieldButton.Size = new System.Drawing.Size(30, 30);
            this.addFieldButton.Style = Sunny.UI.UIStyle.Office2010Black;
            this.addFieldButton.Symbol = 61543;
            this.addFieldButton.TabIndex = 7;
            this.addFieldButton.TipsText = "增加一个字段";
            this.addFieldButton.Click += new System.EventHandler(this.addFieldButton_Click);
            // 
            // removeFieldButton
            // 
            this.removeFieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.removeFieldButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFieldButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.removeFieldButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.removeFieldButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.removeFieldButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.removeFieldButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.removeFieldButton.ForeColor = System.Drawing.Color.Black;
            this.removeFieldButton.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.removeFieldButton.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.removeFieldButton.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.removeFieldButton.Location = new System.Drawing.Point(39, 3);
            this.removeFieldButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.removeFieldButton.Name = "removeFieldButton";
            this.removeFieldButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.removeFieldButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.removeFieldButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.removeFieldButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.removeFieldButton.Size = new System.Drawing.Size(30, 30);
            this.removeFieldButton.Style = Sunny.UI.UIStyle.Office2010Black;
            this.removeFieldButton.Symbol = 61544;
            this.removeFieldButton.TabIndex = 8;
            this.removeFieldButton.TipsText = "删除一个字段";
            this.removeFieldButton.Click += new System.EventHandler(this.removeFieldButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.editButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.editButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.editButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.editButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.editButton.ForeColor = System.Drawing.Color.Black;
            this.editButton.ForeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.editButton.ForePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.editButton.ForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.editButton.Location = new System.Drawing.Point(75, 3);
            this.editButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.editButton.Name = "editButton";
            this.editButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.editButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(201)))), ((int)(((byte)(88)))));
            this.editButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.editButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.editButton.Size = new System.Drawing.Size(30, 30);
            this.editButton.Style = Sunny.UI.UIStyle.Office2010Black;
            this.editButton.Symbol = 61508;
            this.editButton.SymbolSize = 30;
            this.editButton.TabIndex = 9;
            this.editButton.TipsText = "开始编辑";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.editButton);
            this.uiPanel1.Controls.Add(this.addFieldButton);
            this.uiPanel1.Controls.Add(this.removeFieldButton);
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(4, 5);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiPanel1.Size = new System.Drawing.Size(472, 40);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiPanel1.TabIndex = 10;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldName
            // 
            this.fieldName.HeaderText = "字段名";
            this.fieldName.Name = "fieldName";
            this.fieldName.ReadOnly = true;
            // 
            // fieldAlias
            // 
            this.fieldAlias.HeaderText = "别名";
            this.fieldAlias.Name = "fieldAlias";
            this.fieldAlias.ReadOnly = true;
            // 
            // fieldType
            // 
            this.fieldType.HeaderText = "类型";
            this.fieldType.Name = "fieldType";
            this.fieldType.ReadOnly = true;
            this.fieldType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FieldPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 600);
            this.Name = "FieldPage";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.Style = Sunny.UI.UIStyle.Office2010Black;
            this.Text = "字段";
            this.PagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView fieldDataGridView;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton addFieldButton;
        private Sunny.UI.UISymbolButton removeFieldButton;
        private Sunny.UI.UISymbolButton editButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldAlias;
        private System.Windows.Forms.DataGridViewComboBoxColumn fieldType;
    }
}