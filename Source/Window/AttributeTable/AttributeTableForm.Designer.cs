namespace DEETU.Source.Window
{
    partial class AttributeTableForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("表单模式");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("表格模式");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.formPage = new System.Windows.Forms.TabPage();
            this.gridPage = new System.Windows.Forms.TabPage();
            this.Header = new Sunny.UI.UINavBar();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiListBox1 = new Sunny.UI.UIListBox();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.shapeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visibleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selectableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDirtyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.extentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featuresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedFeaturesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attributeFieldsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rendererDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelRendererDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geoMapLayerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiTabControl1.SuspendLayout();
            this.formPage.SuspendLayout();
            this.gridPage.SuspendLayout();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geoMapLayerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.Controls.Add(this.formPage);
            this.uiTabControl1.Controls.Add(this.gridPage);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 68);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiTabControl1.RightToLeftLayout = true;
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(800, 379);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabPosition = Sunny.UI.UITabControl.UITabPosition.Right;
            this.uiTabControl1.TabVisible = false;
            // 
            // formPage
            // 
            this.formPage.Controls.Add(this.uiListBox1);
            this.formPage.Location = new System.Drawing.Point(0, 0);
            this.formPage.Name = "formPage";
            this.formPage.Size = new System.Drawing.Size(800, 379);
            this.formPage.TabIndex = 0;
            this.formPage.Text = "formPage";
            this.formPage.UseVisualStyleBackColor = true;
            // 
            // gridPage
            // 
            this.gridPage.Controls.Add(this.uiDataGridView1);
            this.gridPage.Location = new System.Drawing.Point(0, 0);
            this.gridPage.Name = "gridPage";
            this.gridPage.Size = new System.Drawing.Size(800, 371);
            this.gridPage.TabIndex = 1;
            this.gridPage.Text = "gridPage";
            this.gridPage.UseVisualStyleBackColor = true;
            // 
            // Header
            // 
            this.Header.Controls.Add(this.uiPanel1);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Header.Location = new System.Drawing.Point(0, 35);
            this.Header.Name = "Header";
            this.Header.NodeInterval = 20;
            treeNode1.Name = "formNode";
            treeNode1.Text = "表单模式";
            treeNode2.Name = "gridNode";
            treeNode2.Text = "表格模式";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.Header.NodeSize = new System.Drawing.Size(80, 35);
            this.Header.Size = new System.Drawing.Size(800, 35);
            this.Header.TabControl = this.uiTabControl1;
            this.Header.TabIndex = 1;
            this.Header.Text = "uiNavBar1";
            this.Header.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.Header_MenuItemClick);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(429, 35);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = "uiPanel1";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiListBox1
            // 
            this.uiListBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiListBox1.FormatString = "";
            this.uiListBox1.Items.AddRange(new object[] {
            "aaa",
            "aaa",
            "aaa"});
            this.uiListBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiListBox1.Location = new System.Drawing.Point(98, 83);
            this.uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox1.Name = "uiListBox1";
            this.uiListBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiListBox1.Size = new System.Drawing.Size(270, 180);
            this.uiListBox1.TabIndex = 0;
            this.uiListBox1.Text = "uiListBox1";
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.AutoGenerateColumns = false;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shapeTypeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.visibleDataGridViewCheckBoxColumn,
            this.selectableDataGridViewCheckBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.isDirtyDataGridViewCheckBoxColumn,
            this.extentDataGridViewTextBoxColumn,
            this.featuresDataGridViewTextBoxColumn,
            this.selectedFeaturesDataGridViewTextBoxColumn,
            this.attributeFieldsDataGridViewTextBoxColumn,
            this.rendererDataGridViewTextBoxColumn,
            this.labelRendererDataGridViewTextBoxColumn,
            this.crsDataGridViewTextBoxColumn});
            this.uiDataGridView1.DataSource = this.geoMapLayerBindingSource;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView1.RowTemplate.Height = 29;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.ShowGridLine = true;
            this.uiDataGridView1.Size = new System.Drawing.Size(240, 150);
            this.uiDataGridView1.TabIndex = 0;
            // 
            // shapeTypeDataGridViewTextBoxColumn
            // 
            this.shapeTypeDataGridViewTextBoxColumn.DataPropertyName = "ShapeType";
            this.shapeTypeDataGridViewTextBoxColumn.HeaderText = "ShapeType";
            this.shapeTypeDataGridViewTextBoxColumn.Name = "shapeTypeDataGridViewTextBoxColumn";
            this.shapeTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // visibleDataGridViewCheckBoxColumn
            // 
            this.visibleDataGridViewCheckBoxColumn.DataPropertyName = "Visible";
            this.visibleDataGridViewCheckBoxColumn.HeaderText = "Visible";
            this.visibleDataGridViewCheckBoxColumn.Name = "visibleDataGridViewCheckBoxColumn";
            // 
            // selectableDataGridViewCheckBoxColumn
            // 
            this.selectableDataGridViewCheckBoxColumn.DataPropertyName = "Selectable";
            this.selectableDataGridViewCheckBoxColumn.HeaderText = "Selectable";
            this.selectableDataGridViewCheckBoxColumn.Name = "selectableDataGridViewCheckBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // isDirtyDataGridViewCheckBoxColumn
            // 
            this.isDirtyDataGridViewCheckBoxColumn.DataPropertyName = "IsDirty";
            this.isDirtyDataGridViewCheckBoxColumn.HeaderText = "IsDirty";
            this.isDirtyDataGridViewCheckBoxColumn.Name = "isDirtyDataGridViewCheckBoxColumn";
            // 
            // extentDataGridViewTextBoxColumn
            // 
            this.extentDataGridViewTextBoxColumn.DataPropertyName = "Extent";
            this.extentDataGridViewTextBoxColumn.HeaderText = "Extent";
            this.extentDataGridViewTextBoxColumn.Name = "extentDataGridViewTextBoxColumn";
            this.extentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // featuresDataGridViewTextBoxColumn
            // 
            this.featuresDataGridViewTextBoxColumn.DataPropertyName = "Features";
            this.featuresDataGridViewTextBoxColumn.HeaderText = "Features";
            this.featuresDataGridViewTextBoxColumn.Name = "featuresDataGridViewTextBoxColumn";
            // 
            // selectedFeaturesDataGridViewTextBoxColumn
            // 
            this.selectedFeaturesDataGridViewTextBoxColumn.DataPropertyName = "SelectedFeatures";
            this.selectedFeaturesDataGridViewTextBoxColumn.HeaderText = "SelectedFeatures";
            this.selectedFeaturesDataGridViewTextBoxColumn.Name = "selectedFeaturesDataGridViewTextBoxColumn";
            // 
            // attributeFieldsDataGridViewTextBoxColumn
            // 
            this.attributeFieldsDataGridViewTextBoxColumn.DataPropertyName = "AttributeFields";
            this.attributeFieldsDataGridViewTextBoxColumn.HeaderText = "AttributeFields";
            this.attributeFieldsDataGridViewTextBoxColumn.Name = "attributeFieldsDataGridViewTextBoxColumn";
            this.attributeFieldsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rendererDataGridViewTextBoxColumn
            // 
            this.rendererDataGridViewTextBoxColumn.DataPropertyName = "Renderer";
            this.rendererDataGridViewTextBoxColumn.HeaderText = "Renderer";
            this.rendererDataGridViewTextBoxColumn.Name = "rendererDataGridViewTextBoxColumn";
            // 
            // labelRendererDataGridViewTextBoxColumn
            // 
            this.labelRendererDataGridViewTextBoxColumn.DataPropertyName = "LabelRenderer";
            this.labelRendererDataGridViewTextBoxColumn.HeaderText = "LabelRenderer";
            this.labelRendererDataGridViewTextBoxColumn.Name = "labelRendererDataGridViewTextBoxColumn";
            // 
            // crsDataGridViewTextBoxColumn
            // 
            this.crsDataGridViewTextBoxColumn.DataPropertyName = "Crs";
            this.crsDataGridViewTextBoxColumn.HeaderText = "Crs";
            this.crsDataGridViewTextBoxColumn.Name = "crsDataGridViewTextBoxColumn";
            // 
            // geoMapLayerBindingSource
            // 
            this.geoMapLayerBindingSource.DataSource = typeof(DEETU.Map.GeoMapLayer);
            // 
            // AttributeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.uiTabControl1);
            this.Name = "AttributeTableForm";
            this.Text = "AttributeTableForm";
            this.uiTabControl1.ResumeLayout(false);
            this.formPage.ResumeLayout(false);
            this.gridPage.ResumeLayout(false);
            this.Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geoMapLayerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage formPage;
        private System.Windows.Forms.TabPage gridPage;
        private Sunny.UI.UINavBar Header;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIListBox uiListBox1;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shapeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDirtyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featuresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedFeaturesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributeFieldsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rendererDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelRendererDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource geoMapLayerBindingSource;
    }
}