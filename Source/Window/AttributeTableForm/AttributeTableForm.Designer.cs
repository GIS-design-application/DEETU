using System;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode(" ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode(" ");
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.formPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.featureList = new System.Windows.Forms.ListView();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.detailTable = new System.Windows.Forms.TableLayoutPanel();
            this.gridPage = new System.Windows.Forms.TabPage();
            this.featureDataGridView = new Sunny.UI.UIDataGridView();
            this.Header = new Sunny.UI.UINavBar();
            this.navBarImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startEditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.reloadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveEditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addFeatureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeFeatureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addFieldStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeFieldToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeSelectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectByExpressionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiTabControl1.SuspendLayout();
            this.formPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gridPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.featureDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.uiTabControl1.SelectedIndexChanged += new System.EventHandler(this.uiTabControl1_SelectedIndexChanged);
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
            this.gridPage.Controls.Add(this.featureDataGridView);
            this.gridPage.Location = new System.Drawing.Point(0, 40);
            this.gridPage.Name = "gridPage";
            this.gridPage.Size = new System.Drawing.Size(796, 312);
            this.gridPage.TabIndex = 1;
            this.gridPage.Text = "gridPage";
            // 
            // featureDataGridView
            // 
            this.featureDataGridView.AllowUserToAddRows = false;
            this.featureDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.featureDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.featureDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.featureDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.featureDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.featureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.featureDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.featureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featureDataGridView.EnableHeadersVisualStyles = false;
            this.featureDataGridView.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.featureDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.featureDataGridView.Location = new System.Drawing.Point(0, 0);
            this.featureDataGridView.Name = "featureDataGridView";
            this.featureDataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.featureDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.featureDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.featureDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.featureDataGridView.RowTemplate.Height = 29;
            this.featureDataGridView.SelectedIndex = -1;
            this.featureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.featureDataGridView.ShowGridLine = true;
            this.featureDataGridView.Size = new System.Drawing.Size(796, 312);
            this.featureDataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.featureDataGridView.Style = Sunny.UI.UIStyle.Office2010Black;
            this.featureDataGridView.TabIndex = 0;
            this.featureDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.featureDataGridView_CellEndEdit);
            this.featureDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.featureDataGridView_CellValueChanged);
            this.featureDataGridView.SelectionChanged += new System.EventHandler(this.featureDataGridView_SelectionChanged);
            // 
            // Header
            // 
            this.Header.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Header.ImageList = this.navBarImageList;
            this.Header.Location = new System.Drawing.Point(2, 413);
            this.Header.Name = "Header";
            this.Header.NodeInterval = 20;
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "formNode";
            treeNode1.Text = " ";
            treeNode1.ToolTipText = "表单模式";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "gridNode";
            treeNode2.Text = " ";
            treeNode2.ToolTipText = "表格模式";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.Header.NodeSize = new System.Drawing.Size(50, 35);
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
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startEditToolStripButton,
            this.reloadToolStripButton,
            this.toolStripSeparator1,
            this.saveEditToolStripButton,
            this.cutToolStripButton,
            this.copyStripButton,
            this.pasteToolStripButton,
            this.addFeatureToolStripButton,
            this.removeFeatureToolStripButton,
            this.toolStripSeparator2,
            this.addFieldStripButton,
            this.removeFieldToolStripButton,
            this.toolStripSeparator3,
            this.selectAllToolStripButton,
            this.removeSelectToolStripButton,
            this.selectByExpressionToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(2, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startEditToolStripButton
            // 
            this.startEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startEditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("startEditToolStripButton.Image")));
            this.startEditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startEditToolStripButton.Name = "startEditToolStripButton";
            this.startEditToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.startEditToolStripButton.Text = "开始编辑";
            this.startEditToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // reloadToolStripButton
            // 
            this.reloadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("reloadToolStripButton.Image")));
            this.reloadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadToolStripButton.Name = "reloadToolStripButton";
            this.reloadToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.reloadToolStripButton.Text = "重新加载";
            this.reloadToolStripButton.ToolTipText = "重新加载";
            this.reloadToolStripButton.Click += new System.EventHandler(this.reloadToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // saveEditToolStripButton
            // 
            this.saveEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveEditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveEditToolStripButton.Image")));
            this.saveEditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveEditToolStripButton.Name = "saveEditToolStripButton";
            this.saveEditToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveEditToolStripButton.Text = "保存编辑";
            this.saveEditToolStripButton.ToolTipText = "保存编辑";
            this.saveEditToolStripButton.Click += new System.EventHandler(this.saveEditToolStripButton_Click);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cutToolStripButton.Text = "剪切选中行";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // copyStripButton
            // 
            this.copyStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyStripButton.Image")));
            this.copyStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyStripButton.Name = "copyStripButton";
            this.copyStripButton.Size = new System.Drawing.Size(24, 24);
            this.copyStripButton.Text = "复制选中行";
            this.copyStripButton.Click += new System.EventHandler(this.copyStripButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.pasteToolStripButton.Text = "粘贴";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // addFeatureToolStripButton
            // 
            this.addFeatureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFeatureToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addFeatureToolStripButton.Image")));
            this.addFeatureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFeatureToolStripButton.Name = "addFeatureToolStripButton";
            this.addFeatureToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addFeatureToolStripButton.Text = "添加要素";
            this.addFeatureToolStripButton.Click += new System.EventHandler(this.addFeatureToolStripButton_Click);
            // 
            // removeFeatureToolStripButton
            // 
            this.removeFeatureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeFeatureToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeFeatureToolStripButton.Image")));
            this.removeFeatureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeFeatureToolStripButton.Name = "removeFeatureToolStripButton";
            this.removeFeatureToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.removeFeatureToolStripButton.Text = "删除要素";
            this.removeFeatureToolStripButton.Click += new System.EventHandler(this.removeFeatureToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // addFieldStripButton
            // 
            this.addFieldStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFieldStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addFieldStripButton.Image")));
            this.addFieldStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFieldStripButton.Name = "addFieldStripButton";
            this.addFieldStripButton.Size = new System.Drawing.Size(24, 24);
            this.addFieldStripButton.Text = "添加字段";
            this.addFieldStripButton.Click += new System.EventHandler(this.addFieldStripButton_Click);
            // 
            // removeFieldToolStripButton
            // 
            this.removeFieldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeFieldToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeFieldToolStripButton.Image")));
            this.removeFieldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeFieldToolStripButton.Name = "removeFieldToolStripButton";
            this.removeFieldToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.removeFieldToolStripButton.Text = "删除最后一个字段";
            this.removeFieldToolStripButton.Click += new System.EventHandler(this.removeFieldToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // selectAllToolStripButton
            // 
            this.selectAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectAllToolStripButton.Image")));
            this.selectAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectAllToolStripButton.Name = "selectAllToolStripButton";
            this.selectAllToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.selectAllToolStripButton.Text = "全选";
            this.selectAllToolStripButton.Click += new System.EventHandler(this.selectAllToolStripButton_Click);
            // 
            // removeSelectToolStripButton
            // 
            this.removeSelectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeSelectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeSelectToolStripButton.Image")));
            this.removeSelectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeSelectToolStripButton.Name = "removeSelectToolStripButton";
            this.removeSelectToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.removeSelectToolStripButton.Text = "取消选中";
            this.removeSelectToolStripButton.Click += new System.EventHandler(this.removeSelectToolStripButton_Click);
            // 
            // selectByExpressionToolStripButton
            // 
            this.selectByExpressionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectByExpressionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("selectByExpressionToolStripButton.Image")));
            this.selectByExpressionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectByExpressionToolStripButton.Name = "selectByExpressionToolStripButton";
            this.selectByExpressionToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.selectByExpressionToolStripButton.Text = "按表达式选择";
            this.selectByExpressionToolStripButton.Click += new System.EventHandler(this.selectByExpressionToolStripButton_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.featureDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage formPage;
        private System.Windows.Forms.TabPage gridPage;
        private Sunny.UI.UINavBar Header;
        private Sunny.UI.UIDataGridView featureDataGridView;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel detailTable;
        private System.Windows.Forms.ListView featureList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startEditToolStripButton;
        private System.Windows.Forms.ToolStripButton saveEditToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripButton removeFeatureToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton addFieldStripButton;
        private System.Windows.Forms.ToolStripButton removeFieldToolStripButton;
        private System.Windows.Forms.ToolStripButton selectAllToolStripButton;
        private System.Windows.Forms.ToolStripButton removeSelectToolStripButton;
        private System.Windows.Forms.ToolStripButton reloadToolStripButton;
        private System.Windows.Forms.ToolStripButton addFeatureToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList navBarImageList;
        private System.Windows.Forms.ToolStripButton selectByExpressionToolStripButton;
    }
}