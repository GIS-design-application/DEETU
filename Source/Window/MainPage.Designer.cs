namespace DEETU.Source.Window
{
	partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("最近使用的图层");
            DEETU.Map.GeoLayers geoLayers1 = new DEETU.Map.GeoLayers();
            this.projectContextMenuStrip = new Sunny.UI.UIContextMenuStrip();
            this.设置工程目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoriteContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.添加一个目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerContextMenuStrip = new Sunny.UI.UIContextMenuStrip();
            this.缩放到图层范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放到选中区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示要素数目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图层重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.移除图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移到顶层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.打开属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换编辑状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.坐标参照系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定义坐标参照系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标参照系转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出为SqliteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出为shapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.特性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.退出DEETUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重做操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.剪切要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按属性值选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按表达式选择ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.按矩形范围选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交叉选择菜单 = new System.Windows.Forms.ToolStripMenuItem();
            this.全包含选择菜单 = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全图显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.缩放至图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放至选中区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.显示所有图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏所有图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开shp图层文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开数据库图层文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fullExtentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomToSelectionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomToLayerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.identifyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectByValueToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.按表达式选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反向选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectByExtentToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.交叉选择 = new System.Windows.Forms.ToolStripMenuItem();
            this.全包含选择 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelSelectionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.FileTreeView = new Sunny.UI.UITreeView();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.layerTreeView = new System.Windows.Forms.TreeView();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.geoMap = new DEETU.Map.GeoMapControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMapScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.spaceToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCrs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.startEditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存当前编辑ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mouseEditToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveItemToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.MoveItemToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditFeatureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddFeatureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditPasteToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.剪切要素ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.复制要素ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.粘贴要素ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PasteUndoToolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.撤销ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.重做ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.projectContextMenuStrip.SuspendLayout();
            this.favoriteContextMenuStrip1.SuspendLayout();
            this.layerContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectContextMenuStrip
            // 
            this.projectContextMenuStrip.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.projectContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.projectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置工程目录ToolStripMenuItem});
            this.projectContextMenuStrip.Name = "projectContextMenuStrip";
            this.projectContextMenuStrip.Size = new System.Drawing.Size(163, 28);
            // 
            // 设置工程目录ToolStripMenuItem
            // 
            this.设置工程目录ToolStripMenuItem.Name = "设置工程目录ToolStripMenuItem";
            this.设置工程目录ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.设置工程目录ToolStripMenuItem.Text = "设置工程目录";
            // 
            // favoriteContextMenuStrip1
            // 
            this.favoriteContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.favoriteContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.favoriteContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加一个目录ToolStripMenuItem});
            this.favoriteContextMenuStrip1.Name = "favoriteContextMenuStrip1";
            this.favoriteContextMenuStrip1.Size = new System.Drawing.Size(163, 28);
            // 
            // 添加一个目录ToolStripMenuItem
            // 
            this.添加一个目录ToolStripMenuItem.Name = "添加一个目录ToolStripMenuItem";
            this.添加一个目录ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.添加一个目录ToolStripMenuItem.Text = "添加一个目录";
            // 
            // layerContextMenuStrip
            // 
            this.layerContextMenuStrip.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.layerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.缩放到图层范围ToolStripMenuItem,
            this.缩放到选中区域ToolStripMenuItem,
            this.显示要素数目ToolStripMenuItem,
            this.图层重命名ToolStripMenuItem,
            this.toolStripSeparator6,
            this.移除图层ToolStripMenuItem,
            this.移到顶层ToolStripMenuItem,
            this.toolStripSeparator7,
            this.打开属性表ToolStripMenuItem,
            this.切换编辑状态ToolStripMenuItem,
            this.toolStripSeparator8,
            this.坐标参照系ToolStripMenuItem,
            this.toolStripSeparator9,
            this.导出ToolStripMenuItem,
            this.toolStripSeparator10,
            this.特性ToolStripMenuItem});
            this.layerContextMenuStrip.Name = "layerContextMenuStrip";
            this.layerContextMenuStrip.Size = new System.Drawing.Size(177, 298);
            // 
            // 缩放到图层范围ToolStripMenuItem
            // 
            this.缩放到图层范围ToolStripMenuItem.Name = "缩放到图层范围ToolStripMenuItem";
            this.缩放到图层范围ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.缩放到图层范围ToolStripMenuItem.Text = "缩放到图层范围";
            // 
            // 缩放到选中区域ToolStripMenuItem
            // 
            this.缩放到选中区域ToolStripMenuItem.Name = "缩放到选中区域ToolStripMenuItem";
            this.缩放到选中区域ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.缩放到选中区域ToolStripMenuItem.Text = "缩放到选中区域";
            // 
            // 显示要素数目ToolStripMenuItem
            // 
            this.显示要素数目ToolStripMenuItem.Name = "显示要素数目ToolStripMenuItem";
            this.显示要素数目ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.显示要素数目ToolStripMenuItem.Text = "显示要素数目";
            // 
            // 图层重命名ToolStripMenuItem
            // 
            this.图层重命名ToolStripMenuItem.Name = "图层重命名ToolStripMenuItem";
            this.图层重命名ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.图层重命名ToolStripMenuItem.Text = "图层重命名";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(173, 6);
            // 
            // 移除图层ToolStripMenuItem
            // 
            this.移除图层ToolStripMenuItem.Name = "移除图层ToolStripMenuItem";
            this.移除图层ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.移除图层ToolStripMenuItem.Text = "移除图层";
            this.移除图层ToolStripMenuItem.Click += new System.EventHandler(this.移除图层ToolStripMenuItem_Click);
            // 
            // 移到顶层ToolStripMenuItem
            // 
            this.移到顶层ToolStripMenuItem.Name = "移到顶层ToolStripMenuItem";
            this.移到顶层ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.移到顶层ToolStripMenuItem.Text = "移到顶层";
            this.移到顶层ToolStripMenuItem.Click += new System.EventHandler(this.移到顶层ToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(173, 6);
            // 
            // 打开属性表ToolStripMenuItem
            // 
            this.打开属性表ToolStripMenuItem.Name = "打开属性表ToolStripMenuItem";
            this.打开属性表ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.打开属性表ToolStripMenuItem.Text = "打开属性表";
            this.打开属性表ToolStripMenuItem.Click += new System.EventHandler(this.打开属性表ToolStripMenuItem_Click);
            // 
            // 切换编辑状态ToolStripMenuItem
            // 
            this.切换编辑状态ToolStripMenuItem.Name = "切换编辑状态ToolStripMenuItem";
            this.切换编辑状态ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.切换编辑状态ToolStripMenuItem.Text = "切换编辑状态";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(173, 6);
            // 
            // 坐标参照系ToolStripMenuItem
            // 
            this.坐标参照系ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.定义坐标参照系ToolStripMenuItem,
            this.坐标参照系转换ToolStripMenuItem});
            this.坐标参照系ToolStripMenuItem.Name = "坐标参照系ToolStripMenuItem";
            this.坐标参照系ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.坐标参照系ToolStripMenuItem.Text = "坐标参照系";
            // 
            // 定义坐标参照系ToolStripMenuItem
            // 
            this.定义坐标参照系ToolStripMenuItem.Name = "定义坐标参照系ToolStripMenuItem";
            this.定义坐标参照系ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.定义坐标参照系ToolStripMenuItem.Text = "定义坐标参照系";
            this.定义坐标参照系ToolStripMenuItem.Click += new System.EventHandler(this.定义坐标参照系ToolStripMenuItem_Click);
            // 
            // 坐标参照系转换ToolStripMenuItem
            // 
            this.坐标参照系转换ToolStripMenuItem.Name = "坐标参照系转换ToolStripMenuItem";
            this.坐标参照系转换ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.坐标参照系转换ToolStripMenuItem.Text = "坐标参照系转换";
            this.坐标参照系转换ToolStripMenuItem.Click += new System.EventHandler(this.坐标参照系转换ToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(173, 6);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出为SqliteToolStripMenuItem,
            this.导出为shapefileToolStripMenuItem});
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 导出为SqliteToolStripMenuItem
            // 
            this.导出为SqliteToolStripMenuItem.Name = "导出为SqliteToolStripMenuItem";
            this.导出为SqliteToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.导出为SqliteToolStripMenuItem.Text = "导出为Sqlite";
            this.导出为SqliteToolStripMenuItem.Click += new System.EventHandler(this.SaveSqliteToolStripMenuItem_Click);
            // 
            // 导出为shapefileToolStripMenuItem
            // 
            this.导出为shapefileToolStripMenuItem.Name = "导出为shapefileToolStripMenuItem";
            this.导出为shapefileToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.导出为shapefileToolStripMenuItem.Text = "导出为图层文件";
            this.导出为shapefileToolStripMenuItem.Click += new System.EventHandler(this.SaveLyrToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(173, 6);
            // 
            // 特性ToolStripMenuItem
            // 
            this.特性ToolStripMenuItem.Name = "特性ToolStripMenuItem";
            this.特性ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.特性ToolStripMenuItem.Text = "特性";
            this.特性ToolStripMenuItem.Click += new System.EventHandler(this.特性ToolStripMenuItem_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 175);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.toolStripSeparator3,
            this.退出DEETUToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建ToolStripMenuItem.Image")));
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开ToolStripMenuItem.Image")));
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存ToolStripMenuItem.Image")));
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("另存为ToolStripMenuItem.Image")));
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.SaveNewProjectToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.CloseProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // 退出DEETUToolStripMenuItem
            // 
            this.退出DEETUToolStripMenuItem.Name = "退出DEETUToolStripMenuItem";
            this.退出DEETUToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.退出DEETUToolStripMenuItem.Text = "退出DEETU";
            this.退出DEETUToolStripMenuItem.Click += new System.EventHandler(this.退出DEETUToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤销操作ToolStripMenuItem,
            this.重做操作ToolStripMenuItem,
            this.toolStripSeparator4,
            this.剪切要素ToolStripMenuItem,
            this.复制要素ToolStripMenuItem,
            this.粘贴要素ToolStripMenuItem,
            this.toolStripSeparator5,
            this.选择ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 撤销操作ToolStripMenuItem
            // 
            this.撤销操作ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("撤销操作ToolStripMenuItem.Image")));
            this.撤销操作ToolStripMenuItem.Name = "撤销操作ToolStripMenuItem";
            this.撤销操作ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.撤销操作ToolStripMenuItem.Text = "撤销操作";
            this.撤销操作ToolStripMenuItem.Click += new System.EventHandler(this.撤销_Click);
            // 
            // 重做操作ToolStripMenuItem
            // 
            this.重做操作ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("重做操作ToolStripMenuItem.Image")));
            this.重做操作ToolStripMenuItem.Name = "重做操作ToolStripMenuItem";
            this.重做操作ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.重做操作ToolStripMenuItem.Text = "重做操作";
            this.重做操作ToolStripMenuItem.Click += new System.EventHandler(this.重做_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(181, 6);
            // 
            // 剪切要素ToolStripMenuItem
            // 
            this.剪切要素ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("剪切要素ToolStripMenuItem.Image")));
            this.剪切要素ToolStripMenuItem.Name = "剪切要素ToolStripMenuItem";
            this.剪切要素ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.剪切要素ToolStripMenuItem.Text = "剪切要素";
            this.剪切要素ToolStripMenuItem.Click += new System.EventHandler(this.剪切要素_Click);
            // 
            // 复制要素ToolStripMenuItem
            // 
            this.复制要素ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("复制要素ToolStripMenuItem.Image")));
            this.复制要素ToolStripMenuItem.Name = "复制要素ToolStripMenuItem";
            this.复制要素ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.复制要素ToolStripMenuItem.Text = "复制要素";
            this.复制要素ToolStripMenuItem.Click += new System.EventHandler(this.复制要素_Click);
            // 
            // 粘贴要素ToolStripMenuItem
            // 
            this.粘贴要素ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("粘贴要素ToolStripMenuItem.Image")));
            this.粘贴要素ToolStripMenuItem.Name = "粘贴要素ToolStripMenuItem";
            this.粘贴要素ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.粘贴要素ToolStripMenuItem.Text = "粘贴要素";
            this.粘贴要素ToolStripMenuItem.Click += new System.EventHandler(this.粘贴要素_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(181, 6);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按属性值选择ToolStripMenuItem,
            this.按表达式选择ToolStripMenuItem1,
            this.按矩形范围选择ToolStripMenuItem});
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.选择ToolStripMenuItem.Text = "选择";
            // 
            // 按属性值选择ToolStripMenuItem
            // 
            this.按属性值选择ToolStripMenuItem.Name = "按属性值选择ToolStripMenuItem";
            this.按属性值选择ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.按属性值选择ToolStripMenuItem.Text = "按属性值选择";
            // 
            // 按表达式选择ToolStripMenuItem1
            // 
            this.按表达式选择ToolStripMenuItem1.Name = "按表达式选择ToolStripMenuItem1";
            this.按表达式选择ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.按表达式选择ToolStripMenuItem1.Text = "按表达式选择";
            // 
            // 按矩形范围选择ToolStripMenuItem
            // 
            this.按矩形范围选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.交叉选择菜单,
            this.全包含选择菜单});
            this.按矩形范围选择ToolStripMenuItem.Name = "按矩形范围选择ToolStripMenuItem";
            this.按矩形范围选择ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.按矩形范围选择ToolStripMenuItem.Text = "按矩形范围选择";
            // 
            // 交叉选择菜单
            // 
            this.交叉选择菜单.Checked = true;
            this.交叉选择菜单.CheckState = System.Windows.Forms.CheckState.Checked;
            this.交叉选择菜单.Name = "交叉选择菜单";
            this.交叉选择菜单.Size = new System.Drawing.Size(136, 22);
            this.交叉选择菜单.Text = "交叉选中";
            this.交叉选择菜单.Click += new System.EventHandler(this.选择模式更改_Click);
            // 
            // 全包含选择菜单
            // 
            this.全包含选择菜单.Name = "全包含选择菜单";
            this.全包含选择菜单.Size = new System.Drawing.Size(136, 22);
            this.全包含选择菜单.Text = "全包含选中";
            this.全包含选择菜单.Click += new System.EventHandler(this.选择模式更改_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.平移ToolStripMenuItem,
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.全图显示ToolStripMenuItem,
            this.toolStripSeparator12,
            this.缩放至图层ToolStripMenuItem,
            this.缩放至选中区域ToolStripMenuItem,
            this.toolStripSeparator11,
            this.显示所有图层ToolStripMenuItem,
            this.隐藏所有图层ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 平移ToolStripMenuItem
            // 
            this.平移ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("平移ToolStripMenuItem.Image")));
            this.平移ToolStripMenuItem.Name = "平移ToolStripMenuItem";
            this.平移ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.平移ToolStripMenuItem.Text = "平移";
            this.平移ToolStripMenuItem.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("放大ToolStripMenuItem.Image")));
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("缩小ToolStripMenuItem.Image")));
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // 全图显示ToolStripMenuItem
            // 
            this.全图显示ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("全图显示ToolStripMenuItem.Image")));
            this.全图显示ToolStripMenuItem.Name = "全图显示ToolStripMenuItem";
            this.全图显示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.全图显示ToolStripMenuItem.Text = "全图显示";
            this.全图显示ToolStripMenuItem.Click += new System.EventHandler(this.btnFullExtent_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(157, 6);
            // 
            // 缩放至图层ToolStripMenuItem
            // 
            this.缩放至图层ToolStripMenuItem.Name = "缩放至图层ToolStripMenuItem";
            this.缩放至图层ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.缩放至图层ToolStripMenuItem.Text = "缩放至图层";
            // 
            // 缩放至选中区域ToolStripMenuItem
            // 
            this.缩放至选中区域ToolStripMenuItem.Name = "缩放至选中区域ToolStripMenuItem";
            this.缩放至选中区域ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.缩放至选中区域ToolStripMenuItem.Text = "缩放至选中区域";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(157, 6);
            // 
            // 显示所有图层ToolStripMenuItem
            // 
            this.显示所有图层ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("显示所有图层ToolStripMenuItem.Image")));
            this.显示所有图层ToolStripMenuItem.Name = "显示所有图层ToolStripMenuItem";
            this.显示所有图层ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.显示所有图层ToolStripMenuItem.Text = "显示所有图层";
            // 
            // 隐藏所有图层ToolStripMenuItem
            // 
            this.隐藏所有图层ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("隐藏所有图层ToolStripMenuItem.Image")));
            this.隐藏所有图层ToolStripMenuItem.Name = "隐藏所有图层ToolStripMenuItem";
            this.隐藏所有图层ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.隐藏所有图层ToolStripMenuItem.Text = "隐藏所有图层";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.图层ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(917, 25);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 图层ToolStripMenuItem
            // 
            this.图层ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开图层ToolStripMenuItem,
            this.打开shp图层文件ToolStripMenuItem,
            this.打开数据库图层文件ToolStripMenuItem});
            this.图层ToolStripMenuItem.Name = "图层ToolStripMenuItem";
            this.图层ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.图层ToolStripMenuItem.Text = "图层";
            // 
            // 打开图层ToolStripMenuItem
            // 
            this.打开图层ToolStripMenuItem.Name = "打开图层ToolStripMenuItem";
            this.打开图层ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.打开图层ToolStripMenuItem.Text = "添加lyr图层文件";
            this.打开图层ToolStripMenuItem.Click += new System.EventHandler(this.btnLoadLayerFile_Click);
            // 
            // 打开shp图层文件ToolStripMenuItem
            // 
            this.打开shp图层文件ToolStripMenuItem.Name = "打开shp图层文件ToolStripMenuItem";
            this.打开shp图层文件ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.打开shp图层文件ToolStripMenuItem.Text = "添加shp图层文件";
            this.打开shp图层文件ToolStripMenuItem.Click += new System.EventHandler(this.打开shp图层文件ToolStripMenuItem_Click);
            // 
            // 打开数据库图层文件ToolStripMenuItem
            // 
            this.打开数据库图层文件ToolStripMenuItem.Name = "打开数据库图层文件ToolStripMenuItem";
            this.打开数据库图层文件ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.打开数据库图层文件ToolStripMenuItem.Text = "添加数据库图层文件";
            this.打开数据库图层文件ToolStripMenuItem.Click += new System.EventHandler(this.打开数据库图层文件ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.panToolStripButton,
            this.zoomInToolStripButton,
            this.zoomOutToolStripButton,
            this.fullExtentToolStripButton,
            this.zoomToSelectionToolStripButton,
            this.zoomToLayerToolStripButton,
            this.refreshToolStripButton,
            this.toolStripSeparator2,
            this.identifyToolStripButton,
            this.selectByValueToolStripDropDownButton,
            this.selectByExtentToolStripDropDownButton,
            this.cancelSelectionToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(378, 27);
            this.toolStrip1.TabIndex = 49;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newToolStripButton.Text = "新建工程";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "打开工程";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "保存工程";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // panToolStripButton
            // 
            this.panToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.panToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("panToolStripButton.Image")));
            this.panToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.panToolStripButton.Name = "panToolStripButton";
            this.panToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.panToolStripButton.Text = "漫游";
            this.panToolStripButton.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // zoomInToolStripButton
            // 
            this.zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInToolStripButton.Image")));
            this.zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInToolStripButton.Name = "zoomInToolStripButton";
            this.zoomInToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.zoomInToolStripButton.Text = "放大";
            this.zoomInToolStripButton.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // zoomOutToolStripButton
            // 
            this.zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutToolStripButton.Image")));
            this.zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutToolStripButton.Name = "zoomOutToolStripButton";
            this.zoomOutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.zoomOutToolStripButton.Text = "缩小";
            this.zoomOutToolStripButton.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // fullExtentToolStripButton
            // 
            this.fullExtentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fullExtentToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fullExtentToolStripButton.Image")));
            this.fullExtentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fullExtentToolStripButton.Name = "fullExtentToolStripButton";
            this.fullExtentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.fullExtentToolStripButton.Text = "全图显示";
            this.fullExtentToolStripButton.Click += new System.EventHandler(this.btnFullExtent_Click);
            // 
            // zoomToSelectionToolStripButton
            // 
            this.zoomToSelectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomToSelectionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomToSelectionToolStripButton.Image")));
            this.zoomToSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomToSelectionToolStripButton.Name = "zoomToSelectionToolStripButton";
            this.zoomToSelectionToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.zoomToSelectionToolStripButton.Text = "缩放到选中区域";
            // 
            // zoomToLayerToolStripButton
            // 
            this.zoomToLayerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomToLayerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomToLayerToolStripButton.Image")));
            this.zoomToLayerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomToLayerToolStripButton.Name = "zoomToLayerToolStripButton";
            this.zoomToLayerToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.zoomToLayerToolStripButton.Text = "缩放到图层";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.refreshToolStripButton.Text = "刷新";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // identifyToolStripButton
            // 
            this.identifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.identifyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("identifyToolStripButton.Image")));
            this.identifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.identifyToolStripButton.Name = "identifyToolStripButton";
            this.identifyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.identifyToolStripButton.Text = "识别";
            this.identifyToolStripButton.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // selectByValueToolStripDropDownButton
            // 
            this.selectByValueToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectByValueToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按表达式选择ToolStripMenuItem,
            this.全部选择ToolStripMenuItem,
            this.反向选择ToolStripMenuItem});
            this.selectByValueToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("selectByValueToolStripDropDownButton.Image")));
            this.selectByValueToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectByValueToolStripDropDownButton.Name = "selectByValueToolStripDropDownButton";
            this.selectByValueToolStripDropDownButton.Size = new System.Drawing.Size(33, 24);
            this.selectByValueToolStripDropDownButton.Text = "按照值选择";
            // 
            // 按表达式选择ToolStripMenuItem
            // 
            this.按表达式选择ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("按表达式选择ToolStripMenuItem.Image")));
            this.按表达式选择ToolStripMenuItem.Name = "按表达式选择ToolStripMenuItem";
            this.按表达式选择ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.按表达式选择ToolStripMenuItem.Text = "按表达式选择";
            this.按表达式选择ToolStripMenuItem.Click += new System.EventHandler(this.btnSelectByExpression_Click);
            // 
            // 全部选择ToolStripMenuItem
            // 
            this.全部选择ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("全部选择ToolStripMenuItem.Image")));
            this.全部选择ToolStripMenuItem.Name = "全部选择ToolStripMenuItem";
            this.全部选择ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.全部选择ToolStripMenuItem.Text = "全部选择";
            this.全部选择ToolStripMenuItem.Click += new System.EventHandler(this.全部选择ToolStripMenuItem_Click);
            // 
            // 反向选择ToolStripMenuItem
            // 
            this.反向选择ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("反向选择ToolStripMenuItem.Image")));
            this.反向选择ToolStripMenuItem.Name = "反向选择ToolStripMenuItem";
            this.反向选择ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.反向选择ToolStripMenuItem.Text = "反向选择";
            this.反向选择ToolStripMenuItem.Click += new System.EventHandler(this.反向选择ToolStripMenuItem_Click);
            // 
            // selectByExtentToolStripDropDownButton
            // 
            this.selectByExtentToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectByExtentToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.交叉选择,
            this.全包含选择});
            this.selectByExtentToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("selectByExtentToolStripDropDownButton.Image")));
            this.selectByExtentToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectByExtentToolStripDropDownButton.Name = "selectByExtentToolStripDropDownButton";
            this.selectByExtentToolStripDropDownButton.Size = new System.Drawing.Size(33, 24);
            this.selectByExtentToolStripDropDownButton.Text = "按照范围选择";
            // 
            // 交叉选择
            // 
            this.交叉选择.Checked = true;
            this.交叉选择.CheckState = System.Windows.Forms.CheckState.Checked;
            this.交叉选择.Name = "交叉选择";
            this.交叉选择.Size = new System.Drawing.Size(136, 22);
            this.交叉选择.Text = "交叉选中";
            this.交叉选择.Click += new System.EventHandler(this.选择模式更改_Click);
            // 
            // 全包含选择
            // 
            this.全包含选择.Name = "全包含选择";
            this.全包含选择.Size = new System.Drawing.Size(136, 22);
            this.全包含选择.Text = "全包含选中";
            this.全包含选择.Click += new System.EventHandler(this.选择模式更改_Click);
            // 
            // cancelSelectionToolStripButton
            // 
            this.cancelSelectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancelSelectionToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelSelectionToolStripButton.Image")));
            this.cancelSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelSelectionToolStripButton.Name = "cancelSelectionToolStripButton";
            this.cancelSelectionToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cancelSelectionToolStripButton.Text = "取消选择";
            this.cancelSelectionToolStripButton.Click += new System.EventHandler(this.取消选择ToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(917, 511);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 25);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(917, 565);
            this.toolStripContainer1.TabIndex = 54;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(917, 511);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 51;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.uiPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.uiPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(276, 511);
            this.splitContainer2.SplitterDistance = 217;
            this.splitContainer2.TabIndex = 0;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.FileTreeView);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiPanel1.Size = new System.Drawing.Size(276, 217);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = "uiPanel1";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileTreeView
            // 
            this.FileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileTreeView.FillColor = System.Drawing.Color.White;
            this.FileTreeView.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileTreeView.HideSelection = false;
            this.FileTreeView.Location = new System.Drawing.Point(0, 0);
            this.FileTreeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileTreeView.MinimumSize = new System.Drawing.Size(1, 1);
            this.FileTreeView.Name = "FileTreeView";
            treeNode1.ContextMenuStrip = this.projectContextMenuStrip;
            treeNode1.Name = "节点0";
            treeNode1.Text = "工程目录";
            treeNode2.ContextMenuStrip = this.favoriteContextMenuStrip1;
            treeNode2.Name = "节点0";
            treeNode2.Text = "收藏夹";
            treeNode3.Name = "节点1";
            treeNode3.Text = "C:\\";
            this.uiTreeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.uiTreeView2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiTreeView2.SelectedNode = null;
            this.uiTreeView2.Size = new System.Drawing.Size(276, 202);
            this.uiTreeView2.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiTreeView2.TabIndex = 0;
            this.uiTreeView2.Text = "uiTreeView2";
            this.uiTreeView2.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.layerTreeView);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 0);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiPanel2.Size = new System.Drawing.Size(276, 290);
            this.uiPanel2.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiPanel2.TabIndex = 0;
            this.uiPanel2.Text = "uiPanel2";
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layerTreeView
            // 
            this.layerTreeView.AllowDrop = true;
            this.layerTreeView.CheckBoxes = true;
            this.layerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerTreeView.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layerTreeView.ImageIndex = 0;
            this.layerTreeView.ImageList = this.TreeImages;
            this.layerTreeView.Location = new System.Drawing.Point(0, 0);
            this.layerTreeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layerTreeView.MinimumSize = new System.Drawing.Size(1, 1);
            this.layerTreeView.Name = "layerTreeView";
            this.layerTreeView.SelectedImageIndex = 0;
            this.layerTreeView.SelectedNode = null;
            this.layerTreeView.ShowLines = true;
            this.layerTreeView.ShowNodeToolTips = true;
            this.layerTreeView.Size = new System.Drawing.Size(276, 290);
            this.layerTreeView.Style = Sunny.UI.UIStyle.Office2010Black;
            this.layerTreeView.TabIndex = 0;
            this.layerTreeView.Text = "layerTreeView";
            this.layerTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.layerTreeView_ItemDrag);
            this.layerTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.layerTreeView_NodeMouseClick);
            this.layerTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.layerTreeView_DragDrop);
            this.layerTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.layerTreeView_DragEnter);
            // 
            // TreeImages
            // 
            this.TreeImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.TreeImages.ImageSize = new System.Drawing.Size(16, 16);
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.geoMap);
            this.uiPanel3.Controls.Add(this.statusStrip);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.uiPanel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel3.Location = new System.Drawing.Point(0, 0);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiPanel3.Size = new System.Drawing.Size(637, 511);
            this.uiPanel3.Style = Sunny.UI.UIStyle.Office2010Black;
            this.uiPanel3.TabIndex = 0;
            this.uiPanel3.Text = "MapControl";
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel3.DoubleClick += new System.EventHandler(this.uiPanel3_DoubleClick);
            // 
            // geoMap
            // 
            this.geoMap.BackColor = System.Drawing.Color.White;
            this.geoMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.geoMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geoMap.FlashColor = System.Drawing.Color.Green;
            geoLayers1.FilePath = null;
            this.geoMap.Layers = geoLayers1;
            this.geoMap.Location = new System.Drawing.Point(0, 0);
            this.geoMap.Margin = new System.Windows.Forms.Padding(37120712, 305168164, 37120712, 305168164);
            this.geoMap.Name = "geoMap";
            this.geoMap.SelectionColor = System.Drawing.Color.Cyan;
            this.geoMap.Size = new System.Drawing.Size(637, 489);
            this.geoMap.TabIndex = 0;
            this.geoMap.MapScaleChanged += new DEETU.Map.GeoMapControl.MapScaleChangedHandle(this.geoMap_MapScaleChanged);
            this.geoMap.AfterTrackingLayerDraw += new DEETU.Map.GeoMapControl.AfterTrackingLayerDrawHandle(this.geoMap_AfterTrackingLayerDraw);
            this.geoMap.DoubleClick += new System.EventHandler(this.geoMap_DoubleClick);
            this.geoMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.geoMap_MouseClick);
            this.geoMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.geoMap_MouseDown);
            this.geoMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.geoMap_MouseMove);
            this.geoMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.geoMap_MouseUp);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCoordinate,
            this.tssMapScale,
            this.spaceToolStripStatusLabel,
            this.tssCrs});
            this.statusStrip.Location = new System.Drawing.Point(0, 489);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(637, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "tssMapScale";
            // 
            // tssCoordinate
            // 
            this.tssCoordinate.Name = "tssCoordinate";
            this.tssCoordinate.Size = new System.Drawing.Size(89, 17);
            this.tssCoordinate.Text = "tssCoordinate";
            // 
            // tssMapScale
            // 
            this.tssMapScale.Name = "tssMapScale";
            this.tssMapScale.Size = new System.Drawing.Size(81, 17);
            this.tssMapScale.Text = "tssMapScale";
            // 
            // spaceToolStripStatusLabel
            // 
            this.spaceToolStripStatusLabel.Name = "spaceToolStripStatusLabel";
            this.spaceToolStripStatusLabel.Size = new System.Drawing.Size(409, 17);
            this.spaceToolStripStatusLabel.Spring = true;
            // 
            // tssCrs
            // 
            this.tssCrs.Name = "tssCrs";
            this.tssCrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tssCrs.RightToLeftAutoMirrorImage = true;
            this.tssCrs.Size = new System.Drawing.Size(43, 17);
            this.tssCrs.Text = "tssCrs";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startEditToolStripButton,
            this.保存当前编辑ToolStripButton,
            this.mouseEditToolStripSeparator,
            this.RemoveItemToolStripButton,
            this.MoveItemToolStripButton,
            this.EditFeatureToolStripButton,
            this.AddFeatureToolStripButton,
            this.EditPasteToolStripSeparator,
            this.剪切要素ToolStripButton,
            this.复制要素ToolStripButton,
            this.粘贴要素ToolStripButton,
            this.PasteUndoToolStripSeparator14,
            this.撤销ToolStripButton,
            this.重做ToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(294, 27);
            this.toolStrip2.TabIndex = 50;
            // 
            // startEditToolStripButton
            // 
            this.startEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startEditToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("startEditToolStripButton.Image")));
            this.startEditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startEditToolStripButton.Name = "startEditToolStripButton";
            this.startEditToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.startEditToolStripButton.Text = "开始编辑";
            this.startEditToolStripButton.Click += new System.EventHandler(this.开始编辑_Click);
            // 
            // 保存当前编辑ToolStripButton
            // 
            this.保存当前编辑ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存当前编辑ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存当前编辑ToolStripButton.Image")));
            this.保存当前编辑ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存当前编辑ToolStripButton.Name = "保存当前编辑ToolStripButton";
            this.保存当前编辑ToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.保存当前编辑ToolStripButton.Text = "保存当前编辑";
            // 
            // mouseEditToolStripSeparator
            // 
            this.mouseEditToolStripSeparator.Name = "mouseEditToolStripSeparator";
            this.mouseEditToolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // RemoveItemToolStripButton
            // 
            this.RemoveItemToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveItemToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveItemToolStripButton.Image")));
            this.RemoveItemToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveItemToolStripButton.Name = "RemoveItemToolStripButton";
            this.RemoveItemToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.RemoveItemToolStripButton.Text = "删除所选要素";
            this.RemoveItemToolStripButton.Click += new System.EventHandler(this.RemoveItemToolStripButton_Click);
            // 
            // MoveItemToolStripButton
            // 
            this.MoveItemToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveItemToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("MoveItemToolStripButton.Image")));
            this.MoveItemToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveItemToolStripButton.Name = "MoveItemToolStripButton";
            this.MoveItemToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.MoveItemToolStripButton.Text = "移动";
            this.MoveItemToolStripButton.Click += new System.EventHandler(this.btnMovePolygon_Click);
            // 
            // EditFeatureToolStripButton
            // 
            this.EditFeatureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditFeatureToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditFeatureToolStripButton.Image")));
            this.EditFeatureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditFeatureToolStripButton.Name = "EditFeatureToolStripButton";
            this.EditFeatureToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.EditFeatureToolStripButton.Text = "编辑";
            this.EditFeatureToolStripButton.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // AddFeatureToolStripButton
            // 
            this.AddFeatureToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFeatureToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddFeatureToolStripButton.Image")));
            this.AddFeatureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFeatureToolStripButton.Name = "AddFeatureToolStripButton";
            this.AddFeatureToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.AddFeatureToolStripButton.Text = "添加要素";
            this.AddFeatureToolStripButton.Click += new System.EventHandler(this.AddItemToolStripButton_Click);
            // 
            // EditPasteToolStripSeparator
            // 
            this.EditPasteToolStripSeparator.Name = "EditPasteToolStripSeparator";
            this.EditPasteToolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // 剪切要素ToolStripButton
            // 
            this.剪切要素ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.剪切要素ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("剪切要素ToolStripButton.Image")));
            this.剪切要素ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切要素ToolStripButton.Name = "剪切要素ToolStripButton";
            this.剪切要素ToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.剪切要素ToolStripButton.Text = "剪切要素";
            this.剪切要素ToolStripButton.Click += new System.EventHandler(this.剪切要素_Click);
            // 
            // 复制要素ToolStripButton
            // 
            this.复制要素ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.复制要素ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("复制要素ToolStripButton.Image")));
            this.复制要素ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复制要素ToolStripButton.Name = "复制要素ToolStripButton";
            this.复制要素ToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.复制要素ToolStripButton.Text = "复制要素";
            this.复制要素ToolStripButton.Click += new System.EventHandler(this.复制要素_Click);
            // 
            // 粘贴要素ToolStripButton
            // 
            this.粘贴要素ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.粘贴要素ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("粘贴要素ToolStripButton.Image")));
            this.粘贴要素ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.粘贴要素ToolStripButton.Name = "粘贴要素ToolStripButton";
            this.粘贴要素ToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.粘贴要素ToolStripButton.Text = "粘贴要素";
            this.粘贴要素ToolStripButton.Click += new System.EventHandler(this.粘贴要素_Click);
            // 
            // PasteUndoToolStripSeparator14
            // 
            this.PasteUndoToolStripSeparator14.Name = "PasteUndoToolStripSeparator14";
            this.PasteUndoToolStripSeparator14.Size = new System.Drawing.Size(6, 27);
            // 
            // 撤销ToolStripButton
            // 
            this.撤销ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.撤销ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("撤销ToolStripButton.Image")));
            this.撤销ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.撤销ToolStripButton.Name = "撤销ToolStripButton";
            this.撤销ToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.撤销ToolStripButton.Text = "撤销";
            this.撤销ToolStripButton.Click += new System.EventHandler(this.撤销_Click);
            // 
            // 重做ToolStripButton
            // 
            this.重做ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.重做ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("重做ToolStripButton.Image")));
            this.重做ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.重做ToolStripButton.Name = "重做ToolStripButton";
            this.重做ToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.重做ToolStripButton.Text = "重做";
            this.重做ToolStripButton.Click += new System.EventHandler(this.重做_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 590);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "MainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPage_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainPage_KeyUp);
            this.projectContextMenuStrip.ResumeLayout(false);
            this.favoriteContextMenuStrip1.ResumeLayout(false);
            this.layerContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel3.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
		private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
		private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
		private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
		private System.Windows.Forms.ToolStripContentPanel ContentPanel;
		private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private Sunny.UI.UIPanel uiPanel1;
		private Sunny.UI.UIPanel uiPanel2;
		private System.Windows.Forms.TreeView layerTreeView;
		private Sunny.UI.UIPanel uiPanel3;
		private Sunny.UI.UITreeView FileTreeView;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton panToolStripButton;
		private System.Windows.Forms.ToolStripButton zoomInToolStripButton;
		private System.Windows.Forms.ToolStripButton zoomOutToolStripButton;
		private System.Windows.Forms.ToolStripButton fullExtentToolStripButton;
		private System.Windows.Forms.ToolStripButton zoomToSelectionToolStripButton;
		private System.Windows.Forms.ToolStripButton zoomToLayerToolStripButton;
		private System.Windows.Forms.ToolStripButton refreshToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton identifyToolStripButton;
		private System.Windows.Forms.ToolStripDropDownButton selectByValueToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem 按表达式选择ToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton selectByExtentToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem 交叉选择;
		private System.Windows.Forms.ToolStripMenuItem 全包含选择;
		private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		public System.Windows.Forms.ToolStripMenuItem 退出DEETUToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 撤销操作ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 重做操作ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem 剪切要素ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 复制要素ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 粘贴要素ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 按属性值选择ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 按表达式选择ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 按矩形范围选择ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 交叉选择菜单;
		private System.Windows.Forms.ToolStripMenuItem 全包含选择菜单;
		private Sunny.UI.UIContextMenuStrip projectContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem 设置工程目录ToolStripMenuItem;
		private Sunny.UI.UIContextMenuStrip favoriteContextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 添加一个目录ToolStripMenuItem;
		private Sunny.UI.UIContextMenuStrip layerContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem 缩放到图层范围ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 缩放到选中区域ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 显示要素数目ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 图层重命名ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem 移除图层ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 移到顶层ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem 打开属性表ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 切换编辑状态ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem 坐标参照系ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 图层ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 导出为SqliteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 导出为shapefileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem 特性ToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton startEditToolStripButton;
		private System.Windows.Forms.ToolStripButton 保存当前编辑ToolStripButton;
		private System.Windows.Forms.ToolStripButton RemoveItemToolStripButton;
		private System.Windows.Forms.ToolStripButton 剪切要素ToolStripButton;
		private System.Windows.Forms.ToolStripButton 复制要素ToolStripButton;
		private System.Windows.Forms.ToolStripButton 粘贴要素ToolStripButton;
		private System.Windows.Forms.ToolStripButton 撤销ToolStripButton;
		private System.Windows.Forms.ToolStripButton 重做ToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem 平移ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 全图显示ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem 缩放至图层ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 缩放至选中区域ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem 显示所有图层ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 隐藏所有图层ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 定义坐标参照系ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 坐标参照系转换ToolStripMenuItem;
		private Map.GeoMapControl geoMap;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel tssCoordinate;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ImageList TreeImages;
		private System.Windows.Forms.ToolStripStatusLabel tssMapScale;
		private System.Windows.Forms.ToolStripMenuItem 打开图层ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator mouseEditToolStripSeparator;
		private System.Windows.Forms.ToolStripSeparator EditPasteToolStripSeparator;
		private System.Windows.Forms.ToolStripSeparator PasteUndoToolStripSeparator14;
		private System.Windows.Forms.ToolStripButton MoveItemToolStripButton;
		private System.Windows.Forms.ToolStripButton EditFeatureToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem 全部选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反向选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开shp图层文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开数据库图层文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton AddFeatureToolStripButton;
        private System.Windows.Forms.ToolStripButton cancelSelectionToolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel spaceToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssCrs;
    }
}