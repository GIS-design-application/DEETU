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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("表单模式");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("表格模式");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeTableForm));
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.formPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.detailTable = new System.Windows.Forms.TableLayoutPanel();
            this.featureList = new System.Windows.Forms.ListView();
            this.gridPage = new System.Windows.Forms.TabPage();
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
            this.Header = new Sunny.UI.UINavBar();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.uiTabControl1.SuspendLayout();
            this.formPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gridPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geoMapLayerBindingSource)).BeginInit();
            this.Header.SuspendLayout();
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
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
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
            // 
            // formPage
            // 
            this.formPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.formPage.Controls.Add(this.splitContainer1);
            this.formPage.Location = new System.Drawing.Point(0, 40);
            this.formPage.Name = "formPage";
            this.formPage.Size = new System.Drawing.Size(800, 339);
            this.formPage.TabIndex = 0;
            this.formPage.Text = "formPage";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.detailTable);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.featureList);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(800, 339);
            this.splitContainer1.SplitterDistance = 545;
            this.splitContainer1.TabIndex = 0;
            // 
            // detailTable
            // 
            this.detailTable.AutoScroll = true;
            this.detailTable.ColumnCount = 2;
            this.detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.90842F));
            this.detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.09158F));
            this.detailTable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.detailTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailTable.Location = new System.Drawing.Point(0, 0);
            this.detailTable.Name = "detailTable";
            this.detailTable.RowCount = 2;
            this.detailTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.detailTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.detailTable.Size = new System.Drawing.Size(545, 339);
            this.detailTable.TabIndex = 0;
            // 
            // featureList
            // 
            this.featureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featureList.HideSelection = false;
            this.featureList.Location = new System.Drawing.Point(0, 0);
            this.featureList.Name = "featureList";
            this.featureList.Size = new System.Drawing.Size(251, 339);
            this.featureList.TabIndex = 0;
            this.featureList.UseCompatibleStateImageBehavior = false;
            // 
            // gridPage
            // 
            this.gridPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.gridPage.Controls.Add(this.uiDataGridView1);
            this.gridPage.Location = new System.Drawing.Point(0, 40);
            this.gridPage.Name = "gridPage";
            this.gridPage.Size = new System.Drawing.Size(800, 339);
            this.gridPage.TabIndex = 1;
            this.gridPage.Text = "gridPage";
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
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiPanel1.Size = new System.Drawing.Size(429, 35);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "baseline_zoom_out_map_black_48.png");
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gridPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geoMapLayerBindingSource)).EndInit();
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage formPage;
        private System.Windows.Forms.TabPage gridPage;
        private Sunny.UI.UINavBar Header;
        private Sunny.UI.UIPanel uiPanel1;
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
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel detailTable;
        private System.Windows.Forms.ListView featureList;
    }
}