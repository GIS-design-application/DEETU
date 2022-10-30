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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeTableForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("表单模式");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("表格模式");
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.formPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.featureList = new System.Windows.Forms.ListView();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.detailTable = new System.Windows.Forms.TableLayoutPanel();
            this.gridPage = new System.Windows.Forms.TabPage();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.Header = new Sunny.UI.UINavBar();
            this.navBarImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveEditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.reloadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CutToolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.copyStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addFeatureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeFeatureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addFieldStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeSelectToolStripButton = new System.Windows.Forms.ToolStripButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gridPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(2, 63);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(796, 352);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            // 
            // formPage
            // 
            this.formPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.formPage.Controls.Add(this.splitContainer1);
            this.formPage.Location = new System.Drawing.Point(0, 40);
            this.formPage.Name = "formPage";
            this.formPage.Size = new System.Drawing.Size(796, 312);
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
            this.splitContainer1.Panel1.Controls.Add(this.featureList);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detailTable);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(796, 312);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 0;
            // 
            // featureList
            // 
            this.featureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featureList.HideSelection = false;
            this.featureList.Location = new System.Drawing.Point(0, 0);
            this.featureList.Name = "featureList";
            this.featureList.Size = new System.Drawing.Size(224, 312);
            this.featureList.SmallImageList = this.smallImageList;
            this.featureList.TabIndex = 0;
            this.featureList.UseCompatibleStateImageBehavior = false;
            this.featureList.View = System.Windows.Forms.View.SmallIcon;
            this.featureList.SelectedIndexChanged += new System.EventHandler(this.featureList_SelectedIndexChanged);
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "unselected.bmp");
            this.smallImageList.Images.SetKeyName(1, "selected.bmp");
            // 
            // detailTable
            // 
            this.detailTable.AutoScroll = true;
            this.detailTable.ColumnCount = 2;
            this.detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detailTable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.detailTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailTable.Location = new System.Drawing.Point(0, 0);
            this.detailTable.Name = "detailTable";
            this.detailTable.RowCount = 2;
            this.detailTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.detailTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.detailTable.Size = new System.Drawing.Size(568, 312);
            this.detailTable.TabIndex = 0;
            // 
            // gridPage
            // 
            this.gridPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.gridPage.Controls.Add(this.uiDataGridView1);
            this.gridPage.Location = new System.Drawing.Point(0, 40);
            this.gridPage.Name = "gridPage";
            this.gridPage.Size = new System.Drawing.Size(796, 312);
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
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 0);
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
            this.uiDataGridView1.Size = new System.Drawing.Size(796, 312);
            this.uiDataGridView1.TabIndex = 0;
            // 
            // Header
            // 
            this.Header.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Header.ImageList = this.navBarImageList;
            this.Header.Location = new System.Drawing.Point(2, 413);
            this.Header.Name = "Header";
            this.Header.NodeInterval = 20;
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "formNode";
            treeNode1.Text = "表单模式";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "gridNode";
            treeNode2.Text = "表格模式";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.Header.NodeSize = new System.Drawing.Size(80, 35);
            this.Header.Size = new System.Drawing.Size(796, 35);
            this.Header.TabControl = this.uiTabControl1;
            this.Header.TabIndex = 1;
            this.Header.Text = "uiNavBar1";
            this.Header.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.Header_MenuItemClick);
            // 
            // navBarImageList
            // 
            this.navBarImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.navBarImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.navBarImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripButton,
            this.saveEditToolStripButton,
            this.reloadToolStripButton,
            this.toolStripSeparator1,
            this.CutToolStripButton4,
            this.copyStripButton,
            this.pasteToolStripButton,
            this.addFeatureToolStripButton,
            this.removeFeatureToolStripButton,
            this.toolStripSeparator2,
            this.addFieldStripButton,
            this.removeToolStripButton,
            this.toolStripSeparator3,
            this.selectAllToolStripButton,
            this.removeSelectToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(2, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editToolStripButton.Text = "开始编辑";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // saveEditToolStripButton
            // 
            this.saveEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveEditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveEditToolStripButton.Image")));
            this.saveEditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveEditToolStripButton.Name = "saveEditToolStripButton";
            this.saveEditToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveEditToolStripButton.Text = "保存编辑";
            this.saveEditToolStripButton.ToolTipText = "保存编辑";
            this.saveEditToolStripButton.Click += new System.EventHandler(this.saveEditToolStripButton_Click);
            // 
            // reloadToolStripButton
            // 
            this.reloadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("reloadToolStripButton.Image")));
            this.reloadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadToolStripButton.Name = "reloadToolStripButton";
            this.reloadToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.reloadToolStripButton.Text = "重新加载";
            this.reloadToolStripButton.ToolTipText = "重新加载";
            this.reloadToolStripButton.Click += new System.EventHandler(this.reloadToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CutToolStripButton4
            // 
            this.CutToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CutToolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("CutToolStripButton4.Image")));
            this.CutToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutToolStripButton4.Name = "CutToolStripButton4";
            this.CutToolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.CutToolStripButton4.Text = "剪切选中行";
            // 
            // copyStripButton
            // 
            this.copyStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyStripButton.Image")));
            this.copyStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyStripButton.Name = "copyStripButton";
            this.copyStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyStripButton.Text = "复制选中行";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "粘贴";
            // 
            // addFeatureToolStripButton
            // 
            this.addFeatureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFeatureToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addFeatureToolStripButton.Image")));
            this.addFeatureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFeatureToolStripButton.Name = "addFeatureToolStripButton";
            this.addFeatureToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addFeatureToolStripButton.Text = "添加要素";
            this.addFeatureToolStripButton.Click += new System.EventHandler(this.addFeatureToolStripButton_Click);
            // 
            // removeFeatureToolStripButton
            // 
            this.removeFeatureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeFeatureToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeFeatureToolStripButton.Image")));
            this.removeFeatureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeFeatureToolStripButton.Name = "removeFeatureToolStripButton";
            this.removeFeatureToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeFeatureToolStripButton.Text = "删除要素";
            this.removeFeatureToolStripButton.Click += new System.EventHandler(this.removeFeatureToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // addFieldStripButton
            // 
            this.addFieldStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFieldStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addFieldStripButton.Image")));
            this.addFieldStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFieldStripButton.Name = "addFieldStripButton";
            this.addFieldStripButton.Size = new System.Drawing.Size(23, 22);
            this.addFieldStripButton.Text = "添加字段";
            this.addFieldStripButton.Click += new System.EventHandler(this.addFieldStripButton_Click);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripButton.Image")));
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeToolStripButton.Text = "删除字段";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // selectAllToolStripButton
            // 
            this.selectAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectAllToolStripButton.Image")));
            this.selectAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectAllToolStripButton.Name = "selectAllToolStripButton";
            this.selectAllToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.selectAllToolStripButton.Text = "全选";
            this.selectAllToolStripButton.Click += new System.EventHandler(this.selectAllToolStripButton_Click);
            // 
            // removeSelectToolStripButton
            // 
            this.removeSelectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeSelectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeSelectToolStripButton.Image")));
            this.removeSelectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeSelectToolStripButton.Name = "removeSelectToolStripButton";
            this.removeSelectToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeSelectToolStripButton.Text = "取消选中";
            this.removeSelectToolStripButton.Click += new System.EventHandler(this.removeSelectToolStripButton_Click);
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
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.uiTabControl1);
            this.Name = "AttributeTableForm";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.Text = "AttributeTableForm";
            this.uiTabControl1.ResumeLayout(false);
            this.formPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gridPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.geoMapLayerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage formPage;
        private System.Windows.Forms.TabPage gridPage;
        private Sunny.UI.UINavBar Header;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripButton saveEditToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CutToolStripButton4;
        private System.Windows.Forms.ToolStripButton copyStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripButton removeFeatureToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton addFieldStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripButton selectAllToolStripButton;
        private System.Windows.Forms.ToolStripButton removeSelectToolStripButton;
        private System.Windows.Forms.ToolStripButton reloadToolStripButton;
        private System.Windows.Forms.ToolStripButton addFeatureToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList navBarImageList;
    }
}