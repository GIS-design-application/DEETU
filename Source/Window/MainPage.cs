using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using DEETU.Map;
using DEETU.Core;
using DEETU.Geometry;
using DEETU.Tool;
using DEETU.IO;
using System.IO;
using System.Drawing.Drawing2D;
using DEETU.Testing;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace DEETU.Source.Window
{
    public partial class MainPage : UIPage
    {
        #region 构造函数
        public MainPage()
        {
            InitializeComponent();
            geoMap.MouseWheel += geoMap_MouseWheel;
            ProjectName = "Untitled";
            LoadRecentUsedFiles();
        }
        #endregion

        #region 字段
        // 选项变量
        private Color mZoomBoxColor = Color.DeepPink; // 放大盒颜色
        private double mZoomBoxWidth = 0.53; // 放大盒的边界宽度
        private Color mSelectBoxColor = Color.DarkGreen; // 选择盒颜色
        private double mSelectBoxWidth = 0.53; // 选择盒边界宽度
        private double mZoomRatioFixed = 2; // 固定缩放系数
        private double mZoomRatioMouseWheel = 1.2; //滑轮缩放系数
        private double mSelectingTolerance = 3;// 单位像素
        private GeoSimpleFillSymbol mSelectingBoxSymbol; // 选择盒的符号
        private GeoSimpleFillSymbol mZoomBoxSymbol; // 放大盒的符号
        private GeoSimpleFillSymbol mMovingPolygonSymbol; // 移动多边形的符号
        private GeoSimpleLineSymbol mMovingPolylineSymbol;
        private GeoSimpleMarkerSymbol mMovingPointSymbol;
        private GeoSimpleFillSymbol mEditingPolygonSymbol; // 编辑多边形的符号
        private GeoSimpleLineSymbol mEditingPolylineSymbol;
        private GeoSimpleMarkerSymbol mEditingPointSymbol;
        private GeoSimpleMarkerSymbol mEditingVertexSymbol; // 编辑手柄符号
        private GeoSimpleMarkerSymbol mEditingVertexHoverSymbol; // 编辑手柄符号:hover
        private GeoSimpleLineSymbol mElasticSymbol; // 橡皮筋符号


        // 与地图操作有关的变量
        private GeoMapOpStyleEnum mMapOpStyle = GeoMapOpStyleEnum.None; // 1: 放大, 2: 缩小, 3: 漫游, 4: 选择, 5: 查询
                                                                        // 6: 移动, 7: 描绘, 8: 编辑
        private PointF mStartMouseLocation; // 拉框时的起点
        private bool mIsInZoomIn = false; // 是否在放大
        private bool mIsInZoomOut = false; // 是否在缩小
        private bool mIsInPan = false; // 是否在漫游 
        private bool mIsInIdentify = false; // 是否在查询
        private bool mIsInSelect = false;
        private bool mIsMovingShapes = false; // 是否正在移动图形
        private bool mIsEditingShapes = false; // 是否正在编辑图形
        private List<GeoGeometry> mMovingGeometries = new List<GeoGeometry>(); // 正在移动的图形集合
        private GeoGeometry mEditingGeometry; // 正在编辑的图形
        private GeoPoint mEditingPoint, mEditingLeftPoint, mEditingRightPoint; // 正在编辑的图形中被鼠标碰到的点
        private List<GeoPoints> mSketchingShape; // 正在描绘的图形, 用一个多点集合存储
        private GeoGeometryTypeConstant mSketchingGeometryType; // 正在描绘的图形的类别
        private bool mIsEditing = false; // 是否处在编辑状态
        private GeoSelectionModeConstant mSelectionMode = GeoSelectionModeConstant.NewSelection;

        // 与界面交互有关的变量
        private TreeNode mCurrentLayerNode;
        private GeoCoordinateReferenceSystem mCrs = new GeoCoordinateReferenceSystem();

        // 与项目相关的变量
        private string mProjectName;
        private bool mIsProjectDirty = false;
        #endregion

        #region 属性
        public string ProjectName
        {
            get { return mProjectName; }
            set 
            {
                if (value != mProjectName)
                    ProjectNameChanged?.Invoke(this, value);
                mProjectName = value;
            }
        }

        public bool IsProjectDirty
        {
            get { return mIsProjectDirty; }
            set
            {
                if (value != mIsProjectDirty)
                    ProjectDirtyChanged?.Invoke(this, value);
                mIsProjectDirty = value;
            }
        }

        #endregion

        #region 窗体和按钮事件处理

        // 装载窗体
        private void MainForm_Load(object sender, EventArgs e)
        {
            // (1) 初始化符号
            InitializeSymbols();
            // (2) 初始化描绘图形
            InitializeSketchingShape();
            // (3) 显示比例尺
            ShowMapScale();
            // 显示坐标系
            ShowCrs();
            // 设置编辑状态
            SetEditing();
            // 设置撤销、重做状态
            CheckUndo();
        }


        private void btnFullExtent_Click(object sender, EventArgs e)
        {
            geoMap.FullExtent();
        }

        private void btnLayerExtent_Click(object sender, EventArgs e)
        {
            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请先选择图层！");
                return;
            }
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            geoMap.LayerExtent(layer);
        }

        private void btnSelectedAreaExtent_Click(object sender, EventArgs e)
        {
            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请先选择图层！");
                return;
            }
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            geoMap.SelectedAreaExtent(layer);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (!ZoomInModeButton.Checked)
            {
                UncheckModeToolStrip();
                UncheckToolStrip();
                this.Cursor = new Cursor("./icons/ZoomOut.ico");
                mMapOpStyle = GeoMapOpStyleEnum.ZoomIn;
                ZoomInModeButton.Checked = true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
                UncheckModeToolStrip();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (!ZoomoutModeButton.Checked)
            {
                UncheckModeToolStrip();
                UncheckToolStrip();
                this.Cursor = new Cursor("./icons/ZoomIn.ico");
                mMapOpStyle = GeoMapOpStyleEnum.ZoomOut;
                ZoomoutModeButton.Checked = true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
                UncheckModeToolStrip();
            }
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.Pan)
            {
                UncheckModeToolStrip();
                UncheckToolStrip();
                this.Cursor = new Cursor("./icons/PanUp.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Pan;
                PanModeButton.Checked = true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
                UncheckModeToolStrip();
            }
        }


        private void btnIdentify_Click(object sender, EventArgs e)
        {
            if (!IdentifyModeButton.Checked)
            {
                UncheckModeToolStrip();
                UncheckToolStrip();
                Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.Identify;
                IdentifyModeButton.Checked = true;
            }
            else
            {
                Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
                UncheckModeToolStrip();
            }
        }

        #region 渲染部分代码(弃用)

        // 简单渲染
        private void btnSimpleRender_Click(object sender, EventArgs e)
        {
            // 查找多边形图层
            GeoMapLayer sLayer = GetSelectableLayer();
            if (sLayer == null)
                return;
            GeoSimpleRenderer sRenderer = new GeoSimpleRenderer();
            GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
            sRenderer.Symbol = sSymbol;
            sLayer.Renderer = sRenderer;
            geoMap.RedrawMap();
        }

        // 唯一值渲染
        private void btnUniqueValue_Click(object sender, EventArgs e)
        {
            // 查找多边形图层
            GeoMapLayer sLayer = GetSelectableLayer();
            if (sLayer == null)
                return;
            // 假定第一个字段名称为"名称"且为字符型

            GeoUniqueValueRenderer sRenderer = new GeoUniqueValueRenderer();
            sRenderer.Field = "名称";
            List<string> sValues = new List<string>();
            int sFeatureCount = sLayer.Features.Count;
            for (int i = 0; i < sFeatureCount; i++)
            {
                string svalue = (string)sLayer.Features.GetItem(i).Attributes.GetItem(0); // 这里使用0 假定第一个就是字符串的名称
                sValues.Add(svalue);
            }
            // 去除重复
            sValues = sValues.Distinct().ToList();
            // 生成符号
            int sValueCount = sValues.Count;
            for (int i = 0; i < sValueCount; i++)
            {
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sRenderer.AddUniqueValue(sValues[i], sSymbol);

            }
            sRenderer.DefaultSymbol = new GeoSimpleFillSymbol();
            sLayer.Renderer = sRenderer;
            geoMap.RedrawMap();
        }

        private void btnClassBreaks_Click(object sender, EventArgs e)
        {
            GeoMapLayer sLayer = GetSelectableLayer();
            if (sLayer == null)
            {
                return;
            }
            // 假设存在"f5"的字段且为单精度浮点型
            GeoClassBreaksRenderer sRenderer = new GeoClassBreaksRenderer();
            sRenderer.Field = "F5";
            List<double> sValues = new List<double>();
            int sFeatureCount = sLayer.Features.Count;
            int sFieldIndex = sLayer.AttributeFields.FindField(sRenderer.Field);
            for (int i = 0; i < sFeatureCount; i++)
            {
                double sValue = (float)sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                sValues.Add(sValue);
            }
            // 获取最小, 最大值, 并分为5级
            double sMinValue = sValues.Min();
            double sMaxValue = sValues.Max();
            for (int i = 0; i < 5; i++)
            {
                double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / 5;
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sRenderer.AddBreakValue(sValue, sSymbol);
            }
            Color sStartColor = Color.FromArgb(255, 255, 192, 192);
            Color sEndColor = Color.Maroon;
            sRenderer.RampColor(sStartColor, sEndColor);
            sRenderer.DefaultSymbol = new GeoSimpleFillSymbol();
            sLayer.Renderer = sRenderer;
            geoMap.RedrawMap();
        }

        private void btnShowLabel_Click(object sender, EventArgs e)
        {
            if (geoMap.Layers.Count == 0)
                return;
            // 获取第一个图层
            GeoMapLayer sLayer = geoMap.Layers.GetItem(0);
            GeoLabelRenderer sLabelRenderer = new GeoLabelRenderer();
            sLabelRenderer.Field = sLayer.AttributeFields.GetItem(0).Name;
            Font sOldFont = sLabelRenderer.TextSymbol.Font;
            sLabelRenderer.TextSymbol.Font = new Font(sOldFont.Name, 12);
            sLabelRenderer.TextSymbol.UseMask = true;
            sLabelRenderer.LabelFeatures = true;
            sLayer.LabelRenderer = sLabelRenderer;
            geoMap.RedrawMap();
        }
        #endregion

        // 移动多边形
        private void btnMovePolygon_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.Move)
            {
                UncheckToolStrip();
                this.Cursor = new Cursor("./icons/EditMove.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Move;
                CheckToolStrip(mMapOpStyle);
            }
            else
            {
                mMapOpStyle = GeoMapOpStyleEnum.Select;
                this.Cursor = new Cursor("./icons/EditSelect.ico");
                UncheckToolStrip();
            }

        }

        // 描绘多边形, 使用additem替代
        // depreciated
        private void btnSketchPolygon_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor("./icons/Cross.ico");
            mMapOpStyle = GeoMapOpStyleEnum.Sketch;
        }

        /// <summary>
        /// 在选择的图层处添加元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemToolStripButton_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.Sketch && GetSelectableLayer() != null)
            // 开始描绘地理要素
            {
                UncheckToolStrip();
                this.Cursor = new Cursor("./icons/Cross.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Sketch;
                mSketchingGeometryType = GetSelectableLayer().ShapeType; // 可以编辑的图层是什么类别就用添加什么类别的多边形
                CheckToolStrip(mMapOpStyle);

                RemoveItemToolStripButton.Enabled = false;
                MoveItemToolStripButton.Enabled = false;
                EditFeatureToolStripButton.Enabled = false;
                startEditToolStripButton.Enabled = false;
                selectionModeStripMenuItem.Enabled = false;
            }
            else
            // 停止描绘地理要素
            {
                btnEndSketch_Click(sender, e);
                CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
                mMapOpStyle = GeoMapOpStyleEnum.Select;
                UncheckToolStrip();

                RemoveItemToolStripButton.Enabled = true;
                MoveItemToolStripButton.Enabled = true;
                EditFeatureToolStripButton.Enabled = true;
                startEditToolStripButton.Enabled = true;
                selectionModeStripMenuItem.Enabled = true;
            }

        }

        /// <summary>
        /// 添加元素下点击鼠标
        /// </summary>
        /// <param name="e"></param>
        private void OnSketch_MouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                // 添加一个点
            {
                // 将屏幕坐标转化为地图坐标并加入描绘图形
                GeoPoint sPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);

                // 在描绘要素的最后一项加一个点
                mSketchingShape.Last().Add(sPoint);

                geoMap.RedrawTrackingShapes();
                // 实现持久图形的绘制
            }
            else if (e.Button == MouseButtons.Right)
            {
                if(mSketchingGeometryType == GeoGeometryTypeConstant.Point)
                {
                    if (mSketchingShape.Count < 2)
                    {
                        return;
                    }
                    mSketchingShape.RemoveAt(mSketchingShape.Count - 2);

                }
                else
                {
                    if (mSketchingShape.Last().Count != 0)
                    // 此时正在编辑一个新的多边形
                    {
                        mSketchingShape.Last().RemoveAt(mSketchingShape.Last().Count - 1);
                    }
                    else if (mSketchingShape.Count < 2)
                        // 不仅没有正在编辑多边形，也没有已经编辑好的多边形
                    {
                        return;
                    }
                    else
                    {
                        mSketchingShape.RemoveAt(mSketchingShape.Count - 2);
                    }
                }


                geoMap.RedrawTrackingShapes();
            }

        }

        // 结束part
        private void btnEndPart_Click(object sender, EventArgs e)
        {
            // 判断是否可以结束:三个点以上
            if (mSketchingShape.Last().Count < 3 && mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolygon)
            {
                return;
            }
            else if (mSketchingShape.Last().Count < 2 && mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolyline)
            {
                return;
            }
            else if (mSketchingGeometryType == GeoGeometryTypeConstant.Point)
            {
                return;
            }
            // 往list中增加一个多点对象 
            GeoPoints sPoints = new GeoPoints();
            mSketchingShape.Add(sPoints);
            geoMap.RedrawTrackingShapes();
        }

        private void btnEndSketch_Click(object sender, EventArgs e)
        {
            GeoMapLayer sLayer = GetSelectableLayer();
            if (sLayer != null)
            {
                sLayer = NewUndo(sLayer);
            }
            if (mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolygon)
            {
                // 结束描绘多边形
                // 检验是否可以结束
                if (mSketchingShape.Last().Count >= 1 && mSketchingShape.Last().Count < 3)
                {
                    return;
                }
                if (mSketchingShape.Last().Count == 0)
                {
                    mSketchingShape.Remove(mSketchingShape.Last());
                }
                // 如果去掉没修改完的, 删掉空的, 用户至少还输入了一个多边形, 那么就加入多边形图层.
                if (mSketchingShape.Count > 0)
                {
                    if (sLayer != null)
                    { // 定义一个复合多边形
                        GeoMultiPolygon sMultipolygon = new GeoMultiPolygon();
                        sMultipolygon.Parts.AddRange(mSketchingShape.ToArray());
                        sMultipolygon.UpdateExtent(); // 记得只要多边形被修改就需要更新多边形的范围
                                                      // 生成要素并加入图层
                        GeoFeature sFeature = sLayer.GetNewFeature();

                        // 将几何图形加入到feature之中, feature加入到图层
                        sFeature.Geometry = sMultipolygon;
                        sLayer.Features.Add(sFeature);
                        sLayer.UpdateExtent(); // 记得图层修改之后也需要更新多边形的范围

                        // 将选择的要素调整为新添加的要素
                        sLayer.ClearSelection();
                        sLayer.SelectedFeatures.Clear();
                        sLayer.SelectedFeatures.Add(sFeature);
                    }
                }
            }
            else if (mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolyline)
            {
                // 结束描绘曲线
                // 检验是否可以结束
                if (mSketchingShape.Last().Count >= 1 && mSketchingShape.Last().Count < 2)
                {
                    return;
                }
                if (mSketchingShape.Last().Count == 0)
                {
                    mSketchingShape.Remove(mSketchingShape.Last());
                }
                // 如果去掉没修改完的, 删掉空的, 用户至少还输入了一条曲线, 那么就加入曲线图层.
                if (mSketchingShape.Count > 0)
                {

                    if (sLayer != null)
                    { // 定义一个复合多边形
                        GeoMultiPolyline sMultiPolyline = new GeoMultiPolyline();
                        sMultiPolyline.Parts.AddRange(mSketchingShape.ToArray());
                        sMultiPolyline.UpdateExtent(); // 记得只要曲线被修改就需要更新多边形的范围
                                                       // 生成要素并加入图层
                        GeoFeature sFeature = sLayer.GetNewFeature();

                        // 将几何图形加入到feature之中, feature加入到图层
                        sFeature.Geometry = sMultiPolyline;
                        sLayer.Features.Add(sFeature);
                        sLayer.UpdateExtent(); // 记得图层修改之后也需要更新多边形的范围
                        sLayer.ClearSelection();
                        sLayer.SelectedFeatures.Clear();
                        sLayer.SelectedFeatures.Add(sFeature);
                    }
                }
            }
            else
            {
                if (mSketchingShape.Last().Count < 1)
                {
                    return;
                }

                if (sLayer != null)
                { // 定义一个复合多边形

                    sLayer.ClearSelection();
                    for (int i = 0; i < mSketchingShape.Last().Count; i++)
                    {
                        var point = mSketchingShape.Last().GetItem(i);
                        var sFeature = sLayer.GetNewFeature();
                        sFeature.Geometry = point;
                        sLayer.Features.Add(sFeature);
                        sLayer.UpdateExtent();

                        sLayer.SelectedFeatures.Add(sFeature);

                    }
                }

            }


            // 初始化描绘图形
            InitializeSketchingShape();
            geoMap.RedrawMap();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle == GeoMapOpStyleEnum.Edit)
            // 如果正在编辑那么直接取消编辑
            {
                mMapOpStyle = GeoMapOpStyleEnum.Select;
                mEditingGeometry = null;
                geoMap.RedrawMap();
                UncheckToolStrip();

                RemoveItemToolStripButton.Enabled = true;
                MoveItemToolStripButton.Enabled = true;
                AddFeatureToolStripButton.Enabled = true;
                startEditToolStripButton.Enabled = true;
                selectionModeStripMenuItem.Enabled = true;
            }
            else
            {
                UncheckToolStrip();

                GeoMapLayer slayer = GetSelectableLayer();
                if (slayer == null)
                {
                    return;
                }

                // 是否具有一个选择要素(不能没有, 不能有多个)
                if (slayer.SelectedFeatures.Count != 1)
                    return;

                // 为撤销重做做准备
                slayer = NewUndo(slayer);


                this.Cursor = new Cursor("./icons/EditMoveVertex.ico");
                mEditingGeometry = slayer.SelectedFeatures.GetItem(0).Geometry;
                mMapOpStyle = GeoMapOpStyleEnum.Edit;
                geoMap.RedrawTrackingShapes();

                CheckToolStrip(mMapOpStyle);

                RemoveItemToolStripButton.Enabled = false;
                MoveItemToolStripButton.Enabled = false;
                AddFeatureToolStripButton.Enabled = false;
                startEditToolStripButton.Enabled = false;
                selectionModeStripMenuItem.Enabled = false;
            }
        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            // 将mEditingGeometry中的多边形放回slayer中
            GeoMapLayer slayer = GetSelectableLayer();
            slayer.SelectedFeatures.GetItem(0).Geometry = mEditingGeometry;

            // 取消编辑多边形
            mEditingGeometry = null;

            mMapOpStyle = GeoMapOpStyleEnum.Select;

            // 重绘
            geoMap.RedrawMap();
        }
        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (geoMap.Layers.FilePath == null)
                SaveNewProject();
            else
            {
                this.ShowWaitForm("保存中，请稍后...");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(geoMap.Layers.FilePath);
                GeoDatabaseIOTools.SaveGeoProject(geoMap.Layers, geoMap.Layers.FilePath);
                IsProjectDirty = false;
                this.HideWaitForm();
            }
        }
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsProjectDirty)
            {
                DialogResult dr = MessageBox.Show("存在未保存的编辑，确定要关闭工程吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                    return;
            }
            geoMap.Layers = new GeoLayers();
            ProjectName = "Untitled";
            IsProjectDirty = true;
            UpdateTreeView();
        }
        private void SaveNewProject()
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "SQLite Database (*.db)|*.db";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ShowWaitForm("保存中，请稍后...");
                //MessageBox.Show(saveFileDialog1.FileName);
                GeoDatabaseIOTools.SaveGeoProject(geoMap.Layers, saveFileDialog1.FileName);
                geoMap.Layers.FilePath = saveFileDialog1.FileName;
                saveFileDialog1.Dispose();
                this.HideWaitForm();
                ProjectName = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                IsProjectDirty = false;
            }

        }
        private void SaveNewProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNewProject();
        }
        private void CloseProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsProjectDirty)
            {
                DialogResult dr = MessageBox.Show("存在未保存的编辑，确定要关闭工程吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                    return;
            }
            geoMap.Layers = new GeoLayers();
            UpdateTreeView();
            ProjectName = "";
            IsProjectDirty = false;
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsProjectDirty)
            {
                DialogResult dr = MessageBox.Show("存在未保存的编辑，确定要关闭工程吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                    return;
            }
            // 获取文件名
            OpenFileDialog sDialog = new OpenFileDialog();
            string sFileName = "";
            if (sDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = sDialog.FileName;
                sDialog.Dispose();
            }
            else
            {
                sDialog.Dispose();
                return;
            }

            try
            {
                geoMap.Layers.Clear();
                this.ShowWaitForm("读取中，请稍后...");
                GeoDatabaseIOTools.LoadGeoProject(geoMap.Layers, sFileName);
                geoMap.Layers.FilePath = sFileName;
                ProjectName = System.IO.Path.GetFileNameWithoutExtension(sFileName);
                if (geoMap.Layers.Count == 1)
                {
                    geoMap.FullExtent();
                }
                else
                {
                    geoMap.FullExtent();
                    geoMap.RedrawMap();
                }
                this.HideWaitForm();
                UpdateTreeView();
                ProjectName = System.IO.Path.GetFileNameWithoutExtension(sFileName);
                IsProjectDirty = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnSelectByExpression_Click(object sender, EventArgs e)
        {
            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请先选择图层！");
                return;
            }
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            SelectedByExpressionForm expressionForm = new SelectedByExpressionForm(layer);
            expressionForm.LayerQuery += ExpressionForm_LayerQuery;
            expressionForm.ShowDialog();

            //string expression = "F2 >= 100"; //"名称 = '青海省'"
            //QueryExpression(expression);
        }

        private void 全部选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请先选择图层！");
                return;
            }
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            for (int i = 0; i < layer.Features.Count; i++)// 实际上实现了一个对于layer.Features的浅复制
            {
                layer.SelectedFeatures.Add(layer.Features.GetItem(i));
            }
            //layer.SelectedFeatures = layer.Features;
            geoMap.RedrawMap();
        }

        private void 取消选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请先选择图层！");
                return;
            }
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            layer.SelectedFeatures.Clear();
            geoMap.RedrawMap();
        }

        private void 反向选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请先选择图层！");
                return;
            }
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            GeoFeatures unselectedFeatures = new GeoFeatures();

            for (int i = 0; i < layer.Features.Count; i++) // shallow copy
            {
                unselectedFeatures.Add(layer.Features.GetItem(i));
            }

            for (int i = 0; i < layer.SelectedFeatures.Count; i++)
            {
                unselectedFeatures.Remove(layer.SelectedFeatures.GetItem(i));
            }
            layer.SelectedFeatures = unselectedFeatures;
            geoMap.RedrawMap();

        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            geoMap.RedrawMap();
        }

        private void 开始编辑_Click(object sender, EventArgs e)
        {

            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请选择图层", false);
                return;
            }

            mIsEditing = !startEditToolStripButton.Checked;

            if (startEditToolStripButton.Checked == false) // 如果没有在编辑
            {
                // 得保证进入选择模式
                UncheckModeToolStrip();
                SelectModeButton.Checked = true;
                mMapOpStyle = GeoMapOpStyleEnum.Select;

                // 编辑按钮组的其他按钮不可以被点击
                UncheckToolStrip();
                this.Cursor = new Cursor("./icons/EditSelect.ico");
                CheckToolStrip(mMapOpStyle);

                IsProjectDirty = true;
            }
            else
            {
                // 保证结束绘制
                if (mMapOpStyle == GeoMapOpStyleEnum.Sketch)
                {
                    btnEndSketch_Click(sender, e);
                    CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
                }
                // 保证结束编辑
                if (mMapOpStyle == GeoMapOpStyleEnum.Edit)
                {
                    mEditingGeometry = null;
                    geoMap.RedrawMap();
                }    

                //btnEndEdit_Click(sender, e);
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.Select;
                UncheckModeToolStrip();
                UncheckToolStrip();
                SelectModeButton.Checked = true;
            }

            SetEditing();

            startEditToolStripButton.Checked = !startEditToolStripButton.Checked;
            CheckUndo();
        }
        #endregion

        #region 地图控件事件处理
        private void geoMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                // 强制进入漫游模式
                tempCursorForPan = this.Cursor;
                OnPan_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.ZoomIn)
            {
                OnZoomIn_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.ZoomOut)
            {
                OnZoomOut_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Pan)
            {
                OnPan_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                OnSelect_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Identify)
            {
                OnIdentify_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Move)
            {
                OnMoveShape_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Sketch)
            {

            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Edit)
            {
                OnEditShape_MouseDown(e);
            }
        }
        private void OnEditShape_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            // 找到鼠标点击后对应的点
            GeoPoint mousePoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);


            if (mEditingGeometry.GetType() == typeof(GeoMultiPolygon))
            {
                GeoMultiPolygon editingPolygon = mEditingGeometry as GeoMultiPolygon; // 目前只考虑选择一个多边形
                                                                                      // 如果鼠标的点并不在多边形附近, 直接放弃
                if (!editingPolygon.GetEnvelope().IsInside(mousePoint, tolerance))
                {
                    return;
                }

                // 遍历所有点集, 查找是否点击了某一个点
                for (int i = 0; i < editingPolygon.Parts.Count; i++)
                {
                    // 对每一个点集判断是否包含鼠标的范围
                    GeoPoints points = editingPolygon.Parts.GetItem(i);
                    if (!points.GetEnvelope().IsInside(mousePoint, tolerance))
                    {
                        continue;
                    }
                    else
                    {
                        // 遍历每一个点
                        for (int j = 0; j < points.Count; j++)
                        {
                            if (GeoMapTools.IsPointOnPoint(points.GetItem(j), mousePoint, tolerance))
                            {
                                mEditingPoint = points.GetItem(j);
                                if (j == 0)
                                {
                                    mEditingLeftPoint = points.GetItem(points.Count - 1);
                                    mEditingRightPoint = points.GetItem(j + 1);
                                }
                                else if (j == points.Count - 1)
                                {
                                    mEditingLeftPoint = points.GetItem(j - 1);
                                    mEditingRightPoint = points.GetItem(0);
                                }
                                else
                                {
                                    mEditingLeftPoint = points.GetItem(j - 1);
                                    mEditingRightPoint = points.GetItem(j + 1);
                                }
                                mIsEditingShapes = true;
                                geoMap.RedrawTrackingShapes();
                                return;
                            }
                        }
                    }
                }
            }
            else if (mEditingGeometry.GetType() == typeof(GeoMultiPolyline))
            {
                GeoMultiPolyline editingPolyline = mEditingGeometry as GeoMultiPolyline;
                // 如果鼠标的点并不在多边形附近, 直接放弃
                if (!editingPolyline.GetEnvelope().IsInside(mousePoint, tolerance))
                {
                    return;
                }

                // 遍历所有点集, 查找是否点击了某一个点
                for (int i = 0; i < editingPolyline.Parts.Count; i++)
                {
                    // 对每一个点集判断是否包含鼠标的范围
                    GeoPoints points = editingPolyline.Parts.GetItem(i);
                    if (!points.GetEnvelope().IsInside(mousePoint, tolerance))
                    {
                        continue;
                    }
                    else
                    {
                        // 遍历每一个点
                        for (int j = 0; j < points.Count; j++)
                        {
                            if (GeoMapTools.IsPointOnPoint(points.GetItem(j), mousePoint, tolerance))
                            {
                                mEditingPoint = points.GetItem(j);
                                if (j == 0)
                                {
                                    mEditingLeftPoint = null;
                                    mEditingRightPoint = points.GetItem(j + 1);
                                }
                                else if (j == points.Count - 1)
                                {
                                    mEditingLeftPoint = points.GetItem(j - 1);
                                    mEditingRightPoint = null;
                                }
                                else
                                {
                                    mEditingLeftPoint = points.GetItem(j - 1);
                                    mEditingRightPoint = points.GetItem(j + 1);
                                }
                                mIsEditingShapes = true;
                                geoMap.RedrawTrackingShapes();
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                GeoPoint point = mEditingGeometry as GeoPoint;
                if (tolerance > GeoMapTools.GetDistance(point.X, point.Y, mousePoint.X, mousePoint.Y))
                {
#if DEBUG
                    Logging = "点击到了嗷" + tolerance.ToString();
#endif
                    mEditingPoint = point;
                    mIsEditingShapes = true;
                    geoMap.RedrawTrackingShapes();
                }

            }







            // 没有找到好奇怪, 应该是多边形在附近但是和点离得也不近, 有点蠢
            return;
        }

        private void OnMoveShape_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            // 查找一个多边形图层
            GeoMapLayer sLayer = GetSelectableLayer();
            if (sLayer == null)
            {
                return;
            }

            // 判断是否有选中的要素
            int sSelFeatureCount = sLayer.SelectedFeatures.Count;
            if (sSelFeatureCount == 0)
                return;
            mMovingGeometries.Clear();
            if (sLayer.ShapeType == GeoGeometryTypeConstant.MultiPolygon)
            {
                for (int i = 0; i < sSelFeatureCount; i++)
                {
                    GeoMultiPolygon sOriPolygon = (GeoMultiPolygon)sLayer.SelectedFeatures
                                                                        .GetItem(i).Geometry;
                    GeoMultiPolygon sDesPolygon = (GeoMultiPolygon)sOriPolygon.Clone();
                    mMovingGeometries.Add(sDesPolygon);
                }
            }

            else if (sLayer.ShapeType == GeoGeometryTypeConstant.MultiPolyline)
            {
                for (int i = 0; i < sSelFeatureCount; i++)
                {
                    GeoMultiPolyline sOriPolyline = (GeoMultiPolyline)sLayer.SelectedFeatures.GetItem(i).Geometry;
                    GeoMultiPolyline sDesPolyline = (GeoMultiPolyline)sOriPolyline.Clone();
                    mMovingGeometries.Add(sDesPolyline);
                }
            }
            else
            {
                for (int i = 0; i < sSelFeatureCount; i++)
                {
                    GeoPoint sOriPoint = (GeoPoint)sLayer.SelectedFeatures.GetItem(i).Geometry;
                    GeoPoint sDesPoint = (GeoPoint)sOriPoint.Clone();
                    mMovingGeometries.Add(sDesPoint);
                }
            }


            mStartMouseLocation = e.Location;
            mIsMovingShapes = true;

        }

        private void OnIdentify_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInIdentify = true;
            }
        }

        private void OnSelect_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInSelect = true;
            }
        }
        // 用于临时记录一下拖拽前的鼠标样式
        private Cursor tempCursorForPan = null;
        private void OnPan_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle)
            {
                this.Cursor = new Cursor("./icons/PanDown.ico");
                mStartMouseLocation = e.Location;
                mIsInPan = true;
            }
        }

        private void OnZoomIn_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInZoomIn = true;
            }
        }

        private void OnZoomOut_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInZoomOut = true;
            }
        }

        private void geoMap_MouseMove(object sender, MouseEventArgs e)
        {
            // 显示屏幕坐标
            ShowCoordinates(e.Location);
            if (e.Button == MouseButtons.Middle)
            {
                OnPan_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.ZoomIn)
            {
                OnZoomIn_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.ZoomOut)
            {
                OnZoomOut_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Pan)
            {
                OnPan_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                OnSelect_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Identify)
            {
                OnIdentify_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Move)
            {
                OnMoveShape_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Sketch)
            {
                OnSketch_MouseMove(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Edit) // 编辑多边形
            {
                OnEditShape_MouseMove(e);
            }
        }

        // 移动一个点, 两边的点都需要移动一下
        private void OnEditShape_MouseMove(MouseEventArgs e)
        {
            if (mIsEditingShapes == false)
            {
                return;
            }
            // 获得此时鼠标位置
            GeoPoint sCurPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            geoMap.Refresh();
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();

#if DEBUG
            //logging = mEditingGeometry.GetType().ToString();
#endif
            if (mEditingGeometry.GetType() != typeof(GeoPoint))
            {
                if (mEditingLeftPoint != null)
                {
                    sDrawingTool.DrawLine(sCurPoint, mEditingLeftPoint, mElasticSymbol);
                }
                if (mEditingRightPoint != null)
                {
                    sDrawingTool.DrawLine(sCurPoint, mEditingRightPoint, mElasticSymbol);

                }
            }
            else
            {
                sDrawingTool.DrawLine(sCurPoint, mEditingPoint, mElasticSymbol);
            }
        }

        private void OnSketch_MouseMove(MouseEventArgs e)
        {

            GeoPoint sCurPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            GeoPoints sLastPart = mSketchingShape.Last();
            if (mSketchingGeometryType == GeoGeometryTypeConstant.Point)
            {
                geoMap.Refresh();
                GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
                sDrawingTool.DrawPoint(sCurPoint, mEditingPointSymbol);
            }
            else if (mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolygon)
            {
                int sPointCount = sLastPart.Count;
                if (sPointCount == 0)
                    return;
                else if (sPointCount == 1)
                {
                    // 只有一个顶点, 那么只绘制一个橡皮筋
                    geoMap.Refresh();
                    GeoPoint sFirstPoint = sLastPart.GetItem(0);
                    GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);
                }
                else

                {
                    // 具有多个顶点, 绘制两条橡皮筋
                    geoMap.Refresh();
                    GeoPoint sFirstPoint = sLastPart.GetItem(0);
                    GeoPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                    GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);
                    sDrawingTool.DrawLine(sLastPoint, sCurPoint, mElasticSymbol);

                }
            }
            else if (mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolyline)
            {
                int sPointCount = sLastPart.Count;
                if (sPointCount == 0)
                    return;
                else if (sPointCount >= 1)
                {
                    // 只有一个顶点, 那么只绘制一个橡皮筋
                    geoMap.Refresh();
                    GeoPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                    GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sLastPoint, sCurPoint, mElasticSymbol);
                }
            }

        }

        private void OnMoveShape_MouseMove(MouseEventArgs e)
        {
            if (mIsMovingShapes == false)
            {
                return;
            }
            // 修改移动图形的坐标
            double sDeltaX = geoMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = geoMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            MoveGeometries(mMovingGeometries, sDeltaX, sDeltaY);

            geoMap.Refresh();
            // 绘制移动图形
            DrawMovingShapes();

            // 重新设置鼠标移动开始位置
            mStartMouseLocation = e.Location;
        }

        private void OnIdentify_MouseMove(MouseEventArgs e)
        {
            if (mIsInIdentify == false)
                return;
            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mSelectingBoxSymbol);
        }

        private void OnSelect_MouseMove(MouseEventArgs e)
        {
            if (mIsInSelect == false)
            {
                return;
            }

            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mSelectingBoxSymbol);
        }

        private void OnPan_MouseMove(MouseEventArgs e)
        {
            if (mIsInPan == false)
            {
                return;
            }
            geoMap.PanMapImageTo(e.Location.X - mStartMouseLocation.X, e.Location.Y - mStartMouseLocation.Y);
        }

        private void OnZoomIn_MouseMove(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
            {
                return;
            }
            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mZoomBoxSymbol);

        }

        private void OnZoomOut_MouseMove(MouseEventArgs e)
        {
            if (mIsInZoomOut == false)
            {
                return;
            }
            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mZoomBoxSymbol);
        }
        private void geoMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                OnPan_MouseUp(e);
                this.Cursor = tempCursorForPan;
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.ZoomIn)
            {
                OnZoomIn_MouseUp(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.ZoomOut)
            {
                OnZoomOut_MouseUp(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Pan)
            {
                OnPan_MouseUp(e);
                this.Cursor = new Cursor("./icons/PanUp.ico");
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                OnSelect_MouseUp(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Identify)
            {
                OnIdentify_MouseUp(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Move)
            {
                OnMoveShape_MouseUp(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Sketch)
            {

            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Edit)
            {
                OnEditShape_MouseUp(e);
            }
        }

        private void OnEditShape_MouseUp(MouseEventArgs e)
        {
            if (mIsEditingShapes == false)
            {
                return;
            }
            mIsEditingShapes = false;
            // 保存目前鼠标指向的点
            GeoPoint sCurPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);

            // 用现在的点替换编辑的点
            mEditingPoint.X = sCurPoint.X;
            mEditingPoint.Y = sCurPoint.Y;


            if (mEditingGeometry.GetType() != typeof(GeoPoint))
            {
                mEditingGeometry.UpdateExtent();
            }

            // 重绘地图
            geoMap.RedrawMap();

        }

        private void OnMoveShape_MouseUp(MouseEventArgs e)
        {
            if (mIsMovingShapes == false)
                return;
            mIsMovingShapes = false;
            GeoMapLayer selectLayer = geoMap.Layers.getSelectableLayer();
            if (mMovingGeometries.Count > 0)
            {
                selectLayer = NewUndo(selectLayer);
            }
            // 做相应的修改数据操作, 不再编写
            for (int i = 0; i < mMovingGeometries.Count; i++)
            {
                GeoGeometry geometry = mMovingGeometries[i];
                GeoFeature feature = geoMap.Layers.getSelectableLayer().SelectedFeatures.GetItem(i);
                feature.Replace(geometry);
            }
            // 就是将正在移动的图形用clone的替换


            // 重新绘制地图
            geoMap.RedrawMap();

            mMovingGeometries.Clear();
        }

        private async void OnIdentify_MouseUp(MouseEventArgs e)
        {
            if (mIsInIdentify == false)
                return;
            mIsInIdentify = false;
            geoMap.Refresh();

            if (geoMap.Layers.Count == 0)
            {
                return;
            }

            GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);
            GeoMapLayer sLayer = GetSelectableLayer();
            if (sLayer == null)
            {
                return;
            }

            GeoFeatures sFeatures = sLayer.SearchByBox(sBox, tolerance, 全包含选择.Checked);
            sLayer.SelectedFeatures.Clear();
            sLayer.SelectedFeatures.AddRange(sFeatures.ToArray());

            DrawIdentifyFlash(sFeatures);
            //ShowIdentifyMessage(sFeatures, sLayer);
            IdentifyForm identifyForm = new IdentifyForm(sLayer);
            if (sLayer.SelectedFeatures.Count > 0)
                identifyForm.ShowDialog();  
            
        }

        private void DrawIdentifyFlash(GeoFeatures sFeatures)
        {
            int sSelFeatureCount = sFeatures.Count;
            if (sSelFeatureCount > 0)
            {
                GeoGeometry[] sGeometryies = new GeoGeometry[sSelFeatureCount];
                for (int i = 0; i < sSelFeatureCount; i++)
                {
                    sGeometryies[i] = sFeatures.GetItem(i).Geometry;
                }
                geoMap.FlashShapes(sGeometryies, 1, 800);
            }
        }

        /// <summary>
        /// 显示属性信息窗口
        /// </summary>
        /// <param name="sFeatures"></param>
        private void ShowIdentifyMessage(GeoFeatures sFeatures, GeoMapLayer sLayer)
        {
            GeoFields sFields = sLayer.AttributeFields;
            int sFieldCount = sFields.Count;
            string[] sFieldString = new string[sFieldCount];
            for (int i = 0; i < sFieldCount; i++)
            {
                sFieldString[i] = sFields.GetItem(i).Name;
            }
            // 弹出窗体
            int sSelFeatureCount = sFeatures.Count;
            if (sSelFeatureCount > 0)
            {
                GeoGeometry[] sGeometryies = new GeoGeometry[sSelFeatureCount];
                GeoAttributes[] sGeoAttributes = new GeoAttributes[sSelFeatureCount];
                for (int i = 0; i < sSelFeatureCount; i++)
                {
                    sGeometryies[i] = sFeatures.GetItem(i).Geometry;
                    sGeoAttributes[i] = sFeatures.GetItem(i).Attributes;
                }

                string info = "";
                for (int i = 0; i < sSelFeatureCount; i++)
                {
                    int sAttributeCount = sGeoAttributes[i].Count;
                    for (int j = 0; j < sAttributeCount; j++)
                    {
                        info += sFieldString[j] + "：" + sGeoAttributes[i].GetItem(j).ToString() + '\n';
                    }
                    info += "\n";
                }
                //UIMessageBox.ShowInfo(info);
                ShowInfoDialog(info);
                //MessageBox.Show(info, "属性信息", MessageBoxButtons.OK);

                // geoMap.FlashShapes(sGeometryies, 3, 800);
            }
        }

        private void OnSelect_MouseUp(MouseEventArgs e)
        {
            try
            {
                if (mIsInSelect == false)
                    return;
                mIsInSelect = false;
                GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
                double tolerance = geoMap.ToMapDistance(mSelectingTolerance);
                geoMap.SelectByBox(sBox, tolerance, 全包含选择.Checked, mSelectionMode);
                geoMap.RedrawTrackingShapes();
                CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
            }
            catch (Exception error)
            {
                UIMessageBox.ShowError(error.Message);
            }

        }

        private void OnPan_MouseUp(MouseEventArgs e)
        {
            if (mIsInPan == false)
                return;
            mIsInPan = false;
            double sDeltaX = geoMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = geoMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            geoMap.PanDelta(sDeltaX, sDeltaY);
        }

        private void OnZoomIn_MouseUp(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
                return;
            mIsInZoomIn = false;
            if (mStartMouseLocation.X == e.Location.X && mStartMouseLocation.Y == e.Location.Y)
            { // 用户单点
                GeoPoint sPoint = geoMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);
                geoMap.ZoomByCenter(sPoint, mZoomRatioFixed);
            }
            else
            { // 矩形放大
                GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
                geoMap.ZoomToExtent(sBox);
            }
        }

        private void OnZoomOut_MouseUp(MouseEventArgs e)
        {
            if (mIsInZoomOut == false)
                return;
            mIsInZoomOut = false;

            GeoPoint sPoint = geoMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);
            geoMap.ZoomByCenter(sPoint, 1 / mZoomRatioFixed);
        }

        private void geoMap_MouseClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            Logging = "鼠标单击";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Sketch)
            {
                OnSketch_MouseClick(e);
            }
        }

        private void geoMap_MouseWheel(object sender, MouseEventArgs e)
        {
            double sX = geoMap.ClientRectangle.Width / 2;
            double sY = geoMap.ClientRectangle.Height / 2;
            GeoPoint sPoint = geoMap.ToMapPoint(sX, sY);
            if (e.Delta > 0)
            {
                geoMap.ZoomByCenter(sPoint, mZoomRatioMouseWheel);
            }
            else
            {
                geoMap.ZoomByCenter(sPoint, 1 / mZoomRatioMouseWheel);
            }
        }

        private void geoMap_MapScaleChanged(object sender)
        {
            ShowMapScale();
        }

        // 持久绘制图形(用于绘制描绘多边形的图形)
        private void geoMap_AfterTrackingLayerDraw(object sender, GeoUserDrawingTool drawTool)
        {
            DrawSketchingShapes(drawTool);
            DrawEditingShapes(drawTool);
        }

        // 实现TreeView拖拽
        private void layerTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if ((e.Item as TreeNode).Nodes.Count != 0)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void layerTreeView_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false) && (e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode).Nodes.Count != 0)
            {
                // 拖放的目标节点
                TreeNode targetTreeNode;
                // 获取当前光标所处的坐标
                // 定义一个位置点的变量，保存当前光标所处的坐标点
                Point point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                if (((TreeView)sender).Bounds.Contains(point))
                {
                    // 根据坐标点取得处于坐标点位置的节点
                    targetTreeNode = ((TreeView)sender).GetNodeAt(point);
                    // 获取被拖动的节点
                    treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                    // 判断拖动的节点与目标节点是否是同一个,同一个不予处理
                    if (treeNode != targetTreeNode)
                    {
                        // 获取目标位置的索引号
                        int newIndex = layerTreeView.Nodes.IndexOf(targetTreeNode);
                        if (newIndex == -1) newIndex = layerTreeView.Nodes.Count;
                        // 修改顺序
                        if (treeNode.Index > newIndex)
                        {
                            geoMap.Layers.Insert(newIndex, treeNode.Tag as GeoMapLayer);
                            geoMap.Layers.RemoveAt(treeNode.Index + 1);
                        }
                        else
                        {
                            geoMap.Layers.Insert(newIndex, treeNode.Tag as GeoMapLayer);
                            geoMap.Layers.RemoveAt(treeNode.Index);
                        }
                        TreeNode sNode = (TreeNode)treeNode.Clone();
                        layerTreeView.Nodes.Insert(newIndex, sNode);
                        if(mCurrentLayerNode == treeNode)
                        {
                            layerTreeView.SelectedNode = sNode;
                            mCurrentLayerNode = sNode;
                        }
                        // 将被拖动的节点移除
                        treeNode.Remove();
                        geoMap.RedrawMap();
                        IsProjectDirty = true;
                    }
                }
            }
        }

        private void layerTreeView_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        #endregion

        #region 私有函数

        private void LoadRecentUsedFiles()
        {
            if (File.Exists("./recent_used_files.txt"))
            {
                using (StreamReader sr = new StreamReader("./recent_used_files.txt"))
                {
                    while (sr.EndOfStream == false)
                    {
                        TreeNode sNode = new TreeNode();
                        sNode.Text = sr.ReadLine();
                        sNode.Tag = sr.ReadLine();
                        FileTreeView.Nodes[0].Nodes.Add(sNode);
                    }
                }
            }

        }
        //初始化符号
        private void InitializeSymbols()
        {
            mSelectingBoxSymbol = new GeoSimpleFillSymbol();
            mSelectingBoxSymbol.Color = Color.Transparent;
            mSelectingBoxSymbol.Outline.Color = mSelectBoxColor;
            mSelectingBoxSymbol.Outline.Size = mSelectBoxWidth;
            mZoomBoxSymbol = new GeoSimpleFillSymbol();
            mZoomBoxSymbol.Color = Color.Transparent;
            mZoomBoxSymbol.Outline.Color = mZoomBoxColor;
            mZoomBoxSymbol.Outline.Size = mZoomBoxWidth;
            mMovingPolygonSymbol = new GeoSimpleFillSymbol();
            mMovingPolygonSymbol.Color = Color.Transparent;
            mMovingPolygonSymbol.Outline.Color = Color.Black;
            mMovingPolylineSymbol = new GeoSimpleLineSymbol();
            mMovingPolylineSymbol.Color = Color.Black;
            mMovingPolylineSymbol.Size = 0.3;
            mMovingPointSymbol = new GeoSimpleMarkerSymbol();
            mMovingPointSymbol.Color = Color.Black;
            mMovingPointSymbol.Size = 1;
            mEditingPolygonSymbol = new GeoSimpleFillSymbol();
            mEditingPolygonSymbol.Color = Color.Transparent;
            mEditingPolygonSymbol.Outline.Color = Color.DarkGreen;
            mEditingPolygonSymbol.Outline.Size = 0.53;
            mEditingPolylineSymbol = new GeoSimpleLineSymbol();
            mEditingPolylineSymbol.Color = Color.DarkGreen;
            mEditingPolylineSymbol.Size = 1;
            mEditingPointSymbol = new GeoSimpleMarkerSymbol();
            mEditingPointSymbol.Color = Color.DarkGreen;
            mEditingPointSymbol.Size = 1;
            mEditingVertexSymbol = new GeoSimpleMarkerSymbol();
            mEditingVertexSymbol.Color = Color.DarkGreen;
            mEditingVertexSymbol.Style = GeoSimpleMarkerSymbolStyleConstant.SolidSquare;
            mEditingVertexSymbol.Size = 2;
            mElasticSymbol = new GeoSimpleLineSymbol();
            mElasticSymbol.Color = Color.DarkGreen;
            mElasticSymbol.Size = 0.52;
            mElasticSymbol.Style = GeoSimpleLineSymbolStyleConstant.Dash;
        }
        // 初始化描绘图形
        private void InitializeSketchingShape()
        {
            mSketchingShape = new List<GeoPoints>();
            GeoPoints sPoints = new GeoPoints();
            mSketchingShape.Add(sPoints);
        }

        // 根据屏幕坐标显示地图坐标
        private void ShowCoordinates(PointF point)
        {
            GeoPoint sPoint = geoMap.ToMapPoint(point.X, point.Y);
            double sX = Math.Round(sPoint.X, 2);
            double sY = Math.Round(sPoint.Y, 2);
            tssCoordinate.Text = "X:" + sX.ToString() + ", Y:" + sY.ToString();
        }

        // 显示比例尺
        private void ShowMapScale()
        {
            tssMapScale.Text = "1 :" + geoMap.MapScale.ToString("0.00");
        }

        // 显示坐标系
        private void ShowCrs()
        {
            tssCrs.Text = "Crs:";

            if (mCrs.Type == CrsType.None)
                tssCrs.Text += "None";
            else if (mCrs.Type == CrsType.Geographic)
                tssCrs.Text += mCrs.GeographicCrs.ToString();
            else
                tssCrs.Text += mCrs.ProjectedCrs.ToString() + " " + mCrs.GeographicCrs.ToString();
        }

        //根据屏幕上的两点获得一个地图坐标下的矩形
        private GeoRectangle GetMapRectByTwoPoints(PointF point1, PointF point2)
        {
            GeoPoint sPoint1 = geoMap.ToMapPoint(point1.X, point1.Y);
            GeoPoint sPoint2 = geoMap.ToMapPoint(point2.X, point2.Y);
            double sMinX = Math.Min(sPoint1.X, sPoint2.X);
            double sMaxX = Math.Max(sPoint1.X, sPoint2.X);
            double sMinY = Math.Min(sPoint1.Y, sPoint2.Y);
            double sMaxY = Math.Max(sPoint1.Y, sPoint2.Y);
            GeoRectangle sRect = new GeoRectangle(sMinX, sMaxX, sMinY, sMaxY);
            return sRect;
        }

        //获取一个可以选择的多边形
        private GeoMapLayer GetSelectableLayer()
        {
            Int32 sLayerCount = geoMap.Layers.Count;
            GeoMapLayer sLayer = null;
            for (Int32 i = 0; i <= sLayerCount - 1; i++)
            {
                if (geoMap.Layers.GetItem(i).Selectable)
                {
                    sLayer = geoMap.Layers.GetItem(i);
                    break;
                }
            }
            return sLayer;
        }

        //修改移动图形的坐标
        private void MoveGeometries(List<GeoGeometry> mMovingGeometries, double deltaX, double deltaY)
        {
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(GeoMultiPolygon))
                {
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)mMovingGeometries[i];
                    Int32 sPartCount = sMultiPolygon.Parts.Count;
                    for (Int32 j = 0; j <= sPartCount - 1; j++)
                    {
                        GeoPoints sPoints = sMultiPolygon.Parts.GetItem(j);
                        Int32 sPointCount = sPoints.Count;
                        for (Int32 k = 0; k <= sPointCount - 1; k++)
                        {
                            GeoPoint sPoint = sPoints.GetItem(k);
                            sPoint.X = sPoint.X + deltaX;
                            sPoint.Y = sPoint.Y + deltaY;
                        }
                    }
                    sMultiPolygon.UpdateExtent();
                }
                else if (mMovingGeometries[i].GetType() == typeof(GeoMultiPolyline))
                {
                    GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)mMovingGeometries[i];
                    Int32 sPartCount = sMultiPolyline.Parts.Count;
                    for (Int32 j = 0; j <= sPartCount - 1; j++)
                    {
                        GeoPoints sPoints = sMultiPolyline.Parts.GetItem(j);
                        Int32 sPointCount = sPoints.Count;
                        for (Int32 k = 0; k <= sPointCount - 1; k++)
                        {
                            GeoPoint sPoint = sPoints.GetItem(k);
                            sPoint.X = sPoint.X + deltaX;
                            sPoint.Y = sPoint.Y + deltaY;
                        }
                    }
                    sMultiPolyline.UpdateExtent();
                }
                else
                {
                    GeoPoint sPoint = (GeoPoint)mMovingGeometries[i];
                    sPoint.X += deltaX;
                    sPoint.Y += deltaY;
                }
            }
        }
        //绘制移动图形
        private void DrawMovingShapes()
        {
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(GeoMultiPolygon))
                {
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)mMovingGeometries[i];
                    sDrawingTool.DrawMultiPolygon(sMultiPolygon, mMovingPolygonSymbol);
                }
                else if (mMovingGeometries[i].GetType() == typeof(GeoMultiPolyline))
                {
                    GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)mMovingGeometries[i];
                    sDrawingTool.DrawMultiPolyline(sMultiPolyline, mMovingPolylineSymbol);
                }
                else
                {
                    GeoPoint sPoint = (GeoPoint)mMovingGeometries[i];
                    sDrawingTool.DrawPoint(sPoint, mMovingPointSymbol);
                }
            }
        }

        //绘制正在描绘的图形
        private void DrawSketchingShapes(GeoUserDrawingTool drawingTool)
        {
            if (mSketchingShape == null)
                return;
            if (mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolygon)
            // 绘制多边形和曲线
            {
                Int32 sPartCount = mSketchingShape.Count;
                //绘制已经描绘完成的部分
                for (Int32 i = 0; i <= sPartCount - 2; i++)
                {
                    drawingTool.DrawPolygon(mSketchingShape[i], mEditingPolygonSymbol);
                }
                //正在描绘的部分（只有一个Part）
                GeoPoints sLastPart = mSketchingShape.Last();
                if (sLastPart.Count >= 2)
                    drawingTool.DrawPolyline(sLastPart, mEditingPolygonSymbol.Outline);
                //绘制所有顶点手柄
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    GeoPoints sPoints = mSketchingShape[i];
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
            else if (mSketchingGeometryType == GeoGeometryTypeConstant.MultiPolyline)
            {
                Int32 sPartCount = mSketchingShape.Count;
                //绘制已经描绘完成的部分
                for (Int32 i = 0; i <= sPartCount - 2; i++)
                {
                    drawingTool.DrawPolyline(mSketchingShape[i], mEditingPolylineSymbol);
                }
                //正在描绘的部分（只有一个Part）
                GeoPoints sLastPart = mSketchingShape.Last();
                if (sLastPart.Count >= 2)
                    drawingTool.DrawPolyline(sLastPart, mEditingPolylineSymbol);
                //绘制所有顶点手柄
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    GeoPoints sPoints = mSketchingShape[i];
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
            else if (mSketchingGeometryType == GeoGeometryTypeConstant.Point)
            {
                drawingTool.DrawPoints(mSketchingShape[0], mEditingPointSymbol);
            }
        }

        //绘制正在编辑的图形
        private void DrawEditingShapes(GeoUserDrawingTool drawingTool)
        {
            if (mEditingGeometry == null)
                return;
            if (mMapOpStyle != GeoMapOpStyleEnum.Edit)
                return;
            if (mEditingGeometry.GetType() == typeof(GeoMultiPolygon))
            {
                GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)mEditingGeometry;
                //绘制边界
                drawingTool.DrawMultiPolygon(sMultiPolygon, mEditingPolygonSymbol);
                //绘制顶点手柄
                Int32 sPartCount = sMultiPolygon.Parts.Count;
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    GeoPoints sPoints = sMultiPolygon.Parts.GetItem(i);
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
            else if (mEditingGeometry.GetType() == typeof(GeoMultiPolyline))
            {
                GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)mEditingGeometry;
                //绘制边界
                drawingTool.DrawMultiPolyline(sMultiPolyline, mEditingPolygonSymbol);
                //绘制顶点手柄
                Int32 sPartCount = sMultiPolyline.Parts.Count;
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    GeoPoints sPoints = sMultiPolyline.Parts.GetItem(i);
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
        }


        private void UncheckModeToolStrip()
        {
            SelectModeButton.Checked = false;
            PanModeButton.Checked = false;
            ZoomInModeButton.Checked = false;
            ZoomoutModeButton.Checked = false;
            IdentifyModeButton.Checked = false;
        }

        // 取消工具栏对应按钮的选中状态
        private void UncheckToolStrip()
        {
            SetEditing();
            UpdateTreeView();

            MoveItemToolStripButton.Checked = false;
            EditFeatureToolStripButton.Checked = false;
            AddFeatureToolStripButton.Checked = false;
        }

        /// <summary>
        /// 标记toolstripbutton已经被点击
        /// </summary>
        /// <param name="mapOpStyle"></param>
        private void CheckToolStrip(GeoMapOpStyleEnum mapOpStyle)
        {
            switch (mapOpStyle)
            {
                case GeoMapOpStyleEnum.ZoomIn:
                    ZoomInModeButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.ZoomOut:
                    ZoomoutModeButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Pan:
                    PanModeButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Identify:
                    IdentifyModeButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Select:
                    //交叉选中ToolStripMenuItem.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Move:
                    MoveItemToolStripButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Edit:
                    EditFeatureToolStripButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Sketch:
                    AddFeatureToolStripButton.Checked = true;
                    break;
                default:
                    break;
            }

            UncheckModeToolStrip();
        }

        private void QueryExpression(string expression)
        {
            GeoMapLayer sLayer = geoMap.Layers.GetItem(0);
            GeoDataTable sDataTable = new GeoDataTable(sLayer);
            DataRow[] sDataRows = sDataTable.GeoData.Select(expression);
            int sDataRowCount = sDataRows.Length;
            GeoFeature[] sSelGeoFeatures = new GeoFeature[sDataRowCount];
            for (int i = 0; i < sDataRowCount; i++)
            {
                sSelGeoFeatures[i] = (GeoFeature)sDataRows[i]["_GeoFeature"];
            }
            sLayer.SelectedFeatures.Clear();
            sLayer.SelectedFeatures.AddRange(sSelGeoFeatures);
            geoMap.Layers.SetItem(0, sLayer);
            geoMap.RedrawMap();
        }

        private void QueryExpressionLayer(GeoMapLayer layer, string expression, GeoSelectionModeConstant selectionMode)
        {
            GeoMapLayer sLayer = layer;
            GeoDataTable sDataTable = new GeoDataTable(sLayer);
            DataRow[] sDataRows;
            try
            {
                sDataRows = sDataTable.GeoData.Select(expression);
                int sDataRowCount = sDataRows.Length;
                GeoFeature[] sSelGeoFeatures = new GeoFeature[sDataRowCount];
                for (int i = 0; i < sDataRowCount; i++)
                {
                    sSelGeoFeatures[i] = (GeoFeature)sDataRows[i]["_GeoFeature"];
                }
                if (selectionMode == GeoSelectionModeConstant.NewSelection)
                {
                    sLayer.SelectedFeatures.Clear();
                    sLayer.SelectedFeatures.AddRange(sSelGeoFeatures);
                }
                else if (selectionMode == GeoSelectionModeConstant.AddSelection)
                {
                    sLayer.SelectedFeatures.AddRange(sSelGeoFeatures);
                }
                else
                {
                    try
                    {
                        foreach (GeoFeature feature in sSelGeoFeatures)
                        {
                            sLayer.SelectedFeatures.Remove(feature);
                        }
                    }
                    catch (Exception e)
                    {
                        UIMessageBox.ShowError("图层删除错误！\n" + e.Message);
                    }
                }
                //geoMap.Layers.SetItem(0, sLayer);
                geoMap.RedrawMap();
            }
            catch (DataException e)
            {
                UIMessageBox.ShowError("查询表达式错误！\n" + e.Message);
            }
        }

        private void UpdateTreeView()
        {
            // 加一个补丁代码显示坐标系
            if (geoMap.Layers.Count > 0)
            {
                if (layerTreeView.SelectedNode != null)
                    mCrs = (layerTreeView.SelectedNode.Tag as GeoMapLayer).Crs;
                else
                { mCrs = geoMap.Layers.GetItem(0).Crs; }
                ShowCrs();
            }
            layerTreeView.Nodes.Clear();
            for (int i = 0; i < geoMap.Layers.Count; ++i)
            {
                InsertTreeNode(geoMap.Layers.GetItem(i), i);
            }
            // 在更新树的同时更新选中的节点
            if (mCurrentLayerNode != null)
            {
                if (mCurrentLayerNode.Index >= layerTreeView.Nodes.Count) // 这个补丁是为了避免Remove最后一个出问题
                    mCurrentLayerNode = null;
                else
                {
                    mCurrentLayerNode = layerTreeView.Nodes[mCurrentLayerNode.Index];
                    layerTreeView.SelectedNode = mCurrentLayerNode; ;
                }
                //CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
            }
        }

        // 这个函数是为了显示图层渲染方式
        // 在加入图层和修改渲染方式时调用
        private TreeNode InsertTreeNode(GeoMapLayer layer, int index)
        {
            // 按照renderer Type进行处理
            GeoRenderer sRenderer = layer.Renderer;
            layer.Name = layer.Name == "" ? layer.ShapeType.ToString() : layer.Name;
            if (sRenderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                TreeNode style = CreateSimpleStyleTreeNode((sRenderer as GeoSimpleRenderer).Symbol);

                TreeNode layerNode = new TreeNode(layer.Name, new TreeNode[] { style });
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                layerNode.SelectedImageIndex = layerNode.ImageIndex = TreeImages.Images.Count - 1;
                layerNode.Checked = layer.Visible;

                layerNode.ContextMenuStrip = layerContextMenuStrip;
                //layerTreeView.Nodes.Insert(0,layerNode);
                layerNode.Tag = layer;
                layerTreeView.Nodes.Insert(index, layerNode);
                return layerNode;
            }
            else if (sRenderer.RendererType == GeoRendererTypeConstant.ClassBreaks)
            {
                GeoClassBreaksRenderer sClassBreaksRenderer = (GeoClassBreaksRenderer)sRenderer;

                TreeNode FieldName = new TreeNode(sClassBreaksRenderer.Field);
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                FieldName.SelectedImageIndex = FieldName.ImageIndex = TreeImages.Images.Count - 1;
                FieldName.Checked = layer.Visible;

                List<TreeNode> styles = new List<TreeNode>() { FieldName };
                int BreakCount = sClassBreaksRenderer.BreakCount;
                for (int i = 0; i < BreakCount; ++i)
                {
                    string startValue = i == 0 ? "0" : sClassBreaksRenderer.GetBreakValue(i - 1).ToString("F2");
                    string endValue = sClassBreaksRenderer.GetBreakValue(i).ToString("F2");
                    styles.Add(CreateSimpleStyleTreeNode(sClassBreaksRenderer.GetSymbol(i), startValue + "~" + endValue));
                }

                TreeNode layerNode = new TreeNode(layer.Name, styles.ToArray());
                sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                layerNode.SelectedImageIndex = layerNode.ImageIndex = TreeImages.Images.Count - 1;
                layerNode.Checked = layer.Visible;

                layerNode.ContextMenuStrip = layerContextMenuStrip;
                //layerTreeView.Nodes.Insert(0,layerNode);
                layerNode.Tag = layer;
                layerTreeView.Nodes.Insert(index, layerNode);
                return layerNode;
            }
            else if (sRenderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                GeoUniqueValueRenderer sUniqueValueRenderer = (GeoUniqueValueRenderer)sRenderer;

                TreeNode FieldName = new TreeNode(sUniqueValueRenderer.Field);
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                FieldName.SelectedImageIndex = FieldName.ImageIndex = TreeImages.Images.Count - 1;
                FieldName.Checked = layer.Visible;

                List<TreeNode> styles = new List<TreeNode>() { FieldName };
                int ValueCount = sUniqueValueRenderer.ValueCount;
                for (int i = 0; i < ValueCount; ++i)
                {
                    styles.Add(CreateSimpleStyleTreeNode(sUniqueValueRenderer.GetSymbol(i), sUniqueValueRenderer.GetValue(i)));
                }

                TreeNode layerNode = new TreeNode(layer.Name, styles.ToArray());
                sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                layerNode.SelectedImageIndex = layerNode.ImageIndex = TreeImages.Images.Count - 1;
                layerNode.Checked = layer.Visible;

                layerNode.ContextMenuStrip = layerContextMenuStrip;
                //layerTreeView.Nodes.Insert(0,layerNode);
                layerNode.Tag = layer;
                layerTreeView.Nodes.Insert(index, layerNode);
                return layerNode;

            }
            else
            {
                throw new Exception("Renderer Type Error!");
                return null;
            }
        }

        private TreeNode CreateSimpleStyleTreeNode(GeoSymbol symbol, string label = "    ")
        {
            TreeNode style = new TreeNode(label);
            TreeImages.Images.Add(CreateBitmapFromSymbol(symbol));
            style.SelectedImageIndex = style.ImageIndex = TreeImages.Images.Count - 1;
            style.Tag = symbol;
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
                style.Checked = (symbol as GeoSimpleFillSymbol).Visible;
            else if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
                style.Checked = (symbol as GeoSimpleLineSymbol).Visible;
            else if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
                style.Checked = (symbol as GeoSimpleMarkerSymbol).Visible;
            return style;
        }

        private Bitmap CreateBitmapFromSymbol(GeoSymbol symbol)
        {
            Bitmap styleImage = new Bitmap(50, 50);
            Graphics g = Graphics.FromImage(styleImage);
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
            {
                Rectangle sRect = new Rectangle(0, 0, styleImage.Width, styleImage.Height);
                GeoMapDrawingTools.DrawSimpleMarker(g, sRect, 0, (symbol as GeoSimpleMarkerSymbol)); // dpm is useless in this function
            }
            else if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sLineSymbol = (symbol as GeoSimpleLineSymbol);
                double dpm = 10000; // I don't know the correct dpm here so I just randomly assigned a number
                Pen sPen = new Pen(sLineSymbol.Color, (float)(sLineSymbol.Size * dpm / 1000));
                sPen.DashStyle = (DashStyle)sLineSymbol.Style;
                g.DrawLine(sPen, new Point(0, styleImage.Height / 2), new Point(styleImage.Width, styleImage.Height / 2));
                sPen.Dispose();
            }
            else if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
            {
                SolidBrush sBrush = new SolidBrush((symbol as GeoSimpleFillSymbol).Color);
                g.FillRectangle(sBrush, new RectangleF(0, 0, styleImage.Width, styleImage.Height));
                sBrush.Dispose();
            }
            else
            {
                throw new Exception("Symbol Type Error!");
            }
            g.Dispose();
            return styleImage;
        }

        /// <summary>
        /// 处理和开始编辑、结束编辑相关的button的可用性
        /// </summary>
        private void SetEditing()
        {
            RemoveItemToolStripButton.Enabled = mIsEditing;
            MoveItemToolStripButton.Enabled = mIsEditing;
            EditFeatureToolStripButton.Enabled = mIsEditing;
            AddFeatureToolStripButton.Enabled = mIsEditing;
            剪切要素ToolStripButton.Enabled = mIsEditing;
            复制要素ToolStripButton.Enabled = mIsEditing;
            粘贴要素ToolStripButton.Enabled = mIsEditing;

            剪切要素ToolStripMenuItem.Enabled = mIsEditing;
            复制要素ToolStripMenuItem.Enabled = mIsEditing;
            粘贴要素ToolStripMenuItem.Enabled = mIsEditing;

            if (mIsEditing)
            {
                this.Cursor = new Cursor("./icons/EditSelect.ico");
                startEditToolStripButton.Image = new Bitmap("./icons/edit_off.png");
                startEditToolStripButton.ToolTipText = "结束编辑";
            }
            else
            {
                startEditToolStripButton.Image = new Bitmap("./icons/edit.png");
                startEditToolStripButton.ToolTipText = "开始编辑";
            }


            EditStatusChanged?.Invoke(this, mIsEditing);
        }

        private void LayerTreeViewUpdateCheck(TreeNode node)
        {
            if (node.Nodes.Count == 0) // 子节点
            {
                if (node.Tag != null)
                {
                    GeoSymbol sSymbol = node.Tag as GeoSymbol;
                    if(node.Checked)
                    {
                        if (node.Parent.Checked == false)
                            node.Parent.Checked = true;
                        if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
                        {
                            if ((sSymbol as GeoSimpleFillSymbol).Visible == true) return;
                            (sSymbol as GeoSimpleFillSymbol).Visible = true;
                        }
                        else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
                        {
                            if ((sSymbol as GeoSimpleLineSymbol).Visible == true) return;
                            (sSymbol as GeoSimpleLineSymbol).Visible = true;
                        }
                        else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
                        {
                            if ((sSymbol as GeoSimpleMarkerSymbol).Visible == true) return;
                            (sSymbol as GeoSimpleMarkerSymbol).Visible = true;
                        }
                    }
                    else
                    {
                        if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
                        {
                            if ((sSymbol as GeoSimpleFillSymbol).Visible == false) return;
                            (sSymbol as GeoSimpleFillSymbol).Visible = false;
                        }
                        else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
                        {
                            if ((sSymbol as GeoSimpleLineSymbol).Visible == false) return;
                            (sSymbol as GeoSimpleLineSymbol).Visible = false;
                        }
                        else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
                        {
                            if ((sSymbol as GeoSimpleMarkerSymbol).Visible == false) return;
                            (sSymbol as GeoSimpleMarkerSymbol).Visible = false;
                        }
                    }
                }
            }
            else // 父节点
            {
                GeoMapLayer sLayer = node.Tag as GeoMapLayer;
                if (node.Checked)
                {
                    sLayer.Visible = true;
                    layerTreeView.AfterCheck -= layerTreeView_AfterCheck;
                    foreach (TreeNode sNode in node.Nodes)
                    {
                        sNode.Checked = true;
                        if(sNode.Tag != null)
                        {
                            GeoSymbol sSymbol = sNode.Tag as GeoSymbol;
                            if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
                            {
                                (sSymbol as GeoSimpleFillSymbol).Visible = true;
                            }
                            else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
                            {
                                (sSymbol as GeoSimpleLineSymbol).Visible = true;
                            }
                            else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
                            {
                                (sSymbol as GeoSimpleMarkerSymbol).Visible = true;
                            }
                        }
                    }
                    layerTreeView.AfterCheck += layerTreeView_AfterCheck;

                }
                else
                {
                    sLayer.Visible = false;
                    layerTreeView.AfterCheck -= layerTreeView_AfterCheck;
                    foreach (TreeNode sNode in node.Nodes)
                    {   
                        sNode.Checked = false;
                        if(sNode.Tag != null)
                        {
                            GeoSymbol sSymbol = sNode.Tag as GeoSymbol;
                            if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
                            {
                                (sSymbol as GeoSimpleFillSymbol).Visible = false;
                            }
                            else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
                            {
                                (sSymbol as GeoSimpleLineSymbol).Visible = false;
                            }
                            else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
                            {
                                (sSymbol as GeoSimpleMarkerSymbol).Visible = false;
                            }
                        }
                    }
                    layerTreeView.AfterCheck += layerTreeView_AfterCheck;

                    sLayer.SelectedFeatures.Clear();
                }
            }
            geoMap.RedrawMap();
        }
        #endregion

        #region 图层右键菜单
        private void 特性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // !这里获取layer时应该是按名字获取，或许可以考虑在Layers里面加一个GetItem(string name)的函数。
            // ** 现在用code的Tag data 的形式实现了；
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;

            FormCollection collection = Application.OpenForms;

            foreach (Form form in collection)
            {
                if (form.GetType() == typeof(LayerAttributesForm))
                { form.TopMost = true; return; }
            }

            //GeoMapLayer layer = new GeoMapLayer(mCurrentLayerNode.Text, GeoGeometryTypeConstant.Point);
            LayerAttributesForm layerAttributes = new LayerAttributesForm(layer, geoMap);
            layerAttributes.FormClosed += layerAttributes_FormClosed;
            layerAttributes.Show();
        }

        private void SaveLyrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "图层文件 (*.lay)|*.lay";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(saveFileDialog1.FileName);
                GeoDataIOTools.SaveMapLayer(layer, saveFileDialog1.FileName);
                saveFileDialog1.Dispose();
            }

        }
        private void SaveSqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoLayers sLayers = new GeoLayers();
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            sLayers.Add(layer);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "SQLite Database (*.db)|*.db";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(saveFileDialog1.FileName);
                GeoDatabaseIOTools.SaveGeoProject(sLayers, saveFileDialog1.FileName);
                saveFileDialog1.Dispose();
            }

        }
        private void 定义坐标参照系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
#if DEBUG
            //if (layer.Crs.Type == CrsType.None)
            //    layer.Crs = new GeoCoordinateReferenceSystem(GeographicCrsType.Beijing1954, ProjectedCrsType.Lambert2SP);
#endif
            CrsDefineForm crsDefine = new CrsDefineForm(layer);
            crsDefine.ShowDialog();

            if (crsDefine.IsOK)
            {
                geoMap.RedrawMap();
                geoMap.FullExtent();
                mCrs = layer.Crs;
                ShowCrs();
                geoMap.Refresh();
            }
        }

        private void 坐标参照系转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
#if DEBUG
            if (layer.Crs.Type == CrsType.None)
                layer.Crs = new GeoCoordinateReferenceSystem(GeographicCrsType.Beijing1954, ProjectedCrsType.Lambert2SP);
#endif
            CrsTransferForm crsTransfer = new CrsTransferForm(layer);
            crsTransfer.ShowDialog();
            if (crsTransfer.IsOK)
            {
                mCrs = layer.Crs;
                ShowCrs();
                geoMap.FullExtent();
                geoMap.RedrawMap();
                geoMap.Refresh();
            }

        }

        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            AttributeTableForm attributeForm = new AttributeTableForm(layer, mIsEditing);
            attributeForm.MapRedraw += AttributeForm_MapRedraw;
            attributeForm.LayerQuery += ExpressionForm_LayerQuery;
            attributeForm.MapEditStatusChanged += AttributeForm_MapEditStatusChanged;
            attributeForm.FeatureCut += AttributeForm_FeatureCut;
            attributeForm.FeatureCopied += AttributeForm_FeatureCopied;
            attributeForm.FeaturePasted += AttributeForm_FeaturePasted;
            attributeForm.FeatureAdded += AttributeForm_FeatureAdded;
            attributeForm.FeatureRemoved += AttributeForm_FeatureRemoved;
            CurrentAcitveLayerUpdated += attributeForm.MainPage_CurrentActiveLayerChanged;
            EditStatusChanged += attributeForm.MainPage_EditStatusChanged;
            attributeForm.Show();

            attributeForm.FormClosed += AttributeForm_FormClosed;
        }


        private void 移除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除图层吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                geoMap.Layers.RemoveAt(mCurrentLayerNode.Index);
                mCurrentLayerNode.Remove();
                UpdateTreeView();
                geoMap.RedrawMap();
                IsProjectDirty = true;
            }
        }

        private void 移到顶层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode sNode = (TreeNode)mCurrentLayerNode.Clone();
            layerTreeView.Nodes.Insert(0, sNode);
            geoMap.Layers.Insert(0, mCurrentLayerNode.Tag as GeoMapLayer);
            geoMap.Layers.RemoveAt(mCurrentLayerNode.Index);
            mCurrentLayerNode.Remove();
            layerTreeView.SelectedNode = sNode;
            geoMap.RedrawMap();
        }

        private void 图层重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
            UIEditOption option = new UIEditOption();
            option.AutoLabelWidth = true;
            option.Text = "图层重命名";
            option.AddText("Name", "图层名称", mCurrentLayerNode.Text, true);
            UIEditForm editForm = new UIEditForm(option);
            editForm.ShowDialog();
            if (editForm.IsOK)
            {
                layer.Name = (string)editForm["Name"];
                geoMap.Layers.SetItem(mCurrentLayerNode.Index, layer);
                UpdateTreeView();
            }
        }

        #endregion

        #region 子窗口事件处理
        private void layerAttributes_FormClosed(object sender, FormClosedEventArgs e)
        {
            TreeNode sNode = InsertTreeNode(mCurrentLayerNode.Tag as GeoMapLayer, mCurrentLayerNode.Index);
            mCurrentLayerNode.Remove();

            layerTreeView.SelectedNode = sNode;
            mCurrentLayerNode = sNode;

            geoMap.RedrawMap();
        }

        private void AttributeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AttributeTableForm attributeTableForm = sender as AttributeTableForm;
            CurrentAcitveLayerUpdated -= attributeTableForm.MainPage_CurrentActiveLayerChanged;
            EditStatusChanged -= attributeTableForm.MainPage_EditStatusChanged;
        }

        private void AttributeForm_MapRedraw(object sender)
        {
            geoMap.RedrawMap();
        }

        private void ExpressionForm_LayerQuery(object sender, GeoMapLayer layer, string expression, GeoSelectionModeConstant selectionMode)
        {
            QueryExpressionLayer(layer, expression, selectionMode);
        }

        private void AttributeForm_MapEditStatusChanged(object sender, bool status)
        {
            开始编辑_Click(sender, new EventArgs());
            //btnSelect_Click(sender, new EventArgs());
            //mIsEditing = status;
            //SetEditing();
        }

        private void AttributeForm_FeatureCut(object sender, GeoMapLayer layer)
        {
            Cut();
        }

        private void AttributeForm_FeatureRemoved(object sender, GeoMapLayer layer)
        {
            GeoMapLayer sLayer = NewUndo(layer);
            sLayer.Features.RemoveRange(sLayer.SelectedFeatures.ToArray());
            sLayer.SelectedFeatures.Clear();
            geoMap.RedrawMap();
            CurrentAcitveLayerUpdated?.Invoke(this, sLayer);
        }

        private void AttributeForm_FeatureAdded(object sender, GeoMapLayer layer)
        {
            GeoMapLayer sLayer = layer;
            if (sLayer != null)
            {
                sLayer = NewUndo(sLayer);
            }

            GeoFeature newFeature = sLayer.GetNewFeature();
            sLayer.Features.Add(newFeature);
            sLayer.UpdateExtent();

            // 初始化描绘图形
            InitializeSketchingShape();
            geoMap.RedrawMap();
            CurrentAcitveLayerUpdated?.Invoke(this, sLayer);
        }

        private void AttributeForm_FeaturePasted(object sender, GeoMapLayer layer)
        {
            Paste();
        }

        private void AttributeForm_FeatureCopied(object sender, GeoMapLayer layer)
        {
            Copy();
        }

        #endregion

        /// <summary>
        /// 每当一个图层被选择时, 自动选择该图层作为编辑的对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layerTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == mCurrentLayerNode) return;

            if (mCurrentLayerNode != null)
            {
                var oldlayer = (GeoMapLayer)mCurrentLayerNode.Tag;
                oldlayer.SelectedFeatures.Clear();
                geoMap.RedrawMap();
            }
            if (e.Node.Nodes.Count != 0)
                mCurrentLayerNode = e.Node;

#if DEBUG
            Logging = mCurrentLayerNode.Text;
#endif

            int layerIndex = mCurrentLayerNode.Index;
            geoMap.Layers.Deselect();
            GeoMapLayer layer = geoMap.Layers.GetItem(layerIndex);

            mCrs = layer.Crs;

            layer.Selectable = true;
            ShowCrs();
        }

        #region 事件
        public delegate void CurrentActiveLayerUpdatedHandle(object sender, GeoMapLayer layer);
        public event CurrentActiveLayerUpdatedHandle CurrentAcitveLayerUpdated;

        public delegate void EditStatusChangedHandle(object sender, bool status);
        public event EditStatusChangedHandle EditStatusChanged;
        public event EditStatusChangedHandle ProjectDirtyChanged;

        public delegate void ProjectNameChangedHandle(object sender, string name);
        public event ProjectNameChangedHandle ProjectNameChanged;
        
        //public event CurrentActiveLayerUpdatedHandle CurrentAcitveLayerSelected;
        //public event CurrentActiveLayerUpdatedHandle CurrentAcitveLayerMoved;
        //public event CurrentActiveLayerUpdatedHandle CurrentAcitveLayerDeleted;
        //public event CurrentActiveLayerUpdatedHandle CurrentAcitveLayerEdited;
        //public event CurrentActiveLayerUpdatedHandle CurrentAcitveLayerAdded;

        #endregion
#if DEBUG
        private string Logging
        {
            get
            {
                return _Logging.Text;
            }
            set
            {
                _Logging.AppendText("\r\n" + System.DateTime.Now.ToString("HH:mm:ss") + "  " + value);
                _Logging.ScrollToCaret();
            }
        }
        private TextBox _Logging = null;
        public void SetDebugForm(DebugForm form)
        {
            _Logging = form.logging;
        }
#endif
        private void LoadLayerFile(string sFileName)
        {
            string suffix = sFileName.Split('.').Last();
            //string suffix = sFileName.Split('.')[1];
            IsProjectDirty = true;
            if (ProjectName.IsNullOrEmpty())
                ProjectName = "Untitled";

#if DEBUG
            Logging = suffix;
#endif
            bool success = true;
            switch (suffix)
            {
                case "lay":
                    {
                        try
                        {
                            FileStream sStream = new FileStream(sFileName, FileMode.Open);
                            BinaryReader sr = new BinaryReader(sStream);
                            GeoMapLayer sLayer = GeoDataIOTools.LoadMapLayer(sr);
                            if (File.Exists(sFileName + "prj"))
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                FileStream fileStream = new FileStream(sFileName + "prj", FileMode.Open, FileAccess.ReadWrite);
                                sLayer.Crs = (GeoCoordinateReferenceSystem)formatter.Deserialize(fileStream);
                            }
                            sLayer.Name = sFileName.Split('\\').Last().Split('.').First();
                            //检查是否已经添加同名图层
                            for (int j = 0; j < geoMap.Layers.Count; j++)
                            {
                                if (geoMap.Layers.GetItem(j).Name == sLayer.Name)
                                    sLayer.Name = sLayer.Name + "1";
                            }
                            geoMap.Layers.Add(sLayer);
                            if (geoMap.Layers.Count == 1)
                            {
                                geoMap.FullExtent();
                            }
                            else
                            {
                                geoMap.RedrawMap();
                            }
                            sStream.Dispose();
                            sr.Dispose();

                            UpdateTreeView();
                            TreeNodeCollection sCollection = FileTreeView.Nodes[0].Nodes;
                            for (int j = 0; j < sCollection.Count; j++)
                            {
                                if (sCollection[j].Text == sFileName.Split('\\').Last())
                                    return;
                            }
                            TreeNode sTreeNode = new TreeNode();
                            sTreeNode.Text = sFileName.Split('\\').Last();
                            sTreeNode.Tag = sFileName;
                            //MessageBox.Show(sTreeNode.Tag.ToString());
                            FileTreeView.Nodes[0].Nodes.Insert(0, sTreeNode);
                            if (FileTreeView.Nodes[0].Nodes.Count >= 8)
                                FileTreeView.Nodes[0].Nodes.RemoveAt(7);
                            FileTreeView.Update();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.ToString());
                            success = false;
                        }
                        break;
                    }
                case "db":
                    {
                        try
                        {
                            GeoLayers sLayers = new GeoLayers();
                            GeoDatabaseIOTools.LoadGeoProject(sLayers, sFileName);
                            GeoMapLayer sLayer = sLayers.GetItem(0);
                            sLayer.Name = sFileName.Split('\\').Last().Split('.').First();
                            //检查是否已经添加同名图层
                            for (int j = 0; j < geoMap.Layers.Count; j++)
                            {
                                if (geoMap.Layers.GetItem(j).Name == sLayer.Name)
                                    sLayer.Name = sLayer.Name + "1";
                            }
                            geoMap.Layers.Add(sLayer);
                            if (geoMap.Layers.Count == 1)
                            {
                                geoMap.FullExtent();
                            }
                            else
                            {
                                geoMap.RedrawMap();
                            }
                            UpdateTreeView();
                            TreeNodeCollection sCollection = FileTreeView.Nodes[0].Nodes;
                            for (int j = 0; j < sCollection.Count; j++)
                            {
                                if (sCollection[j].Text == sFileName.Split('\\').Last())
                                    return;
                            }
                            TreeNode sTreeNode = new TreeNode();
                            sTreeNode.Text = sFileName.Split('\\').Last();
                            sTreeNode.Tag = sFileName;
                            //MessageBox.Show(sTreeNode.Tag.ToString());
                            FileTreeView.Nodes[0].Nodes.Insert(0, sTreeNode);
                            if (FileTreeView.Nodes[0].Nodes.Count >= 8)
                                FileTreeView.Nodes[0].Nodes.RemoveAt(7);
                            FileTreeView.Update();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.ToString());
                            success = false;
                        }
                        break;
                    }
                case "shp":
                    {
                        try
                        {
                            GeoMapLayer sLayer = GeoShpIOTools.ReadSHPFile(sFileName);
                            sLayer.Name = sFileName.Split('\\').Last().Split('.').First();
                            char[] path = sFileName.ToCharArray();
                            if (path.Length != 0)
                            {
                                path[path.Length - 1] = 'f';
                                path[path.Length - 2] = 'b';
                                path[path.Length - 3] = 'd';

                                GeoShpIOTools.ReadDBFFile(new string(path), sLayer);
                                path[path.Length - 1] = 'j';
                                path[path.Length - 2] = 'r';
                                path[path.Length - 3] = 'p';
                                GeoShpIOTools.ReadPrjFile(new string(path), sLayer);

                            }
                            //检查是否已经添加同名图层
                            for (int j = 0; j < geoMap.Layers.Count; j++)
                            {
                                if (geoMap.Layers.GetItem(j).Name == sLayer.Name)
                                    sLayer.Name = sLayer.Name + "1";
                            }
                            geoMap.Layers.Add(sLayer);
                            if (geoMap.Layers.Count == 1)
                            {
                                geoMap.FullExtent();
                            }
                            else
                            {
                                geoMap.RedrawMap();
                            }
                            UpdateTreeView();
                            TreeNodeCollection sCollection = FileTreeView.Nodes[0].Nodes;
                            for (int j = 0; j < sCollection.Count; j++)
                            {
                                if (sCollection[j].Text == sFileName.Split('\\').Last())
                                    return;
                            }
                            TreeNode sTreeNode = new TreeNode();
                            sTreeNode.Text = sFileName.Split('\\').Last();
                            sTreeNode.Tag = sFileName;
                            //MessageBox.Show(sTreeNode.Tag.ToString());
                            FileTreeView.Nodes[0].Nodes.Insert(0, sTreeNode);
                            if (FileTreeView.Nodes[0].Nodes.Count >= 8)
                                FileTreeView.Nodes[0].Nodes.RemoveAt(7);
                            FileTreeView.Update();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.ToString());
                            success = false;
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("不支持的文件类型:" + suffix);
                        success = false;
                        //Debug.Assert(false);
                        break;
                    }

            }


            using (System.IO.StreamWriter file = new System.IO.StreamWriter("./recent_used_files.txt"))
            {
                foreach (TreeNode sNode in FileTreeView.Nodes[0].Nodes)
                {
                    file.WriteLine(sNode.Text);
                    file.WriteLine(sNode.Tag.ToString());
                }
            }
        }
        private void btnLoadLayerFile_Click(object sender, EventArgs e)
        {
            var crs = new GeoCoordinateReferenceSystem(GeographicCrsType.Beijing1954, ProjectedCrsType.Lambert2SP);

            // 获取文件名
            OpenFileDialog sDialog = new OpenFileDialog();
            sDialog.Filter = "layerfiles(*.lay)|*.lay|All files(*.*)|*.*";
            sDialog.FilterIndex = 1;
            string sFileName = "";
            if (sDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = sDialog.FileName;
                sDialog.Dispose();
            }
            else
            {
                sDialog.Dispose();
                return;
            }
            LoadLayerFile(sFileName);

        }
        /// <summary>
        /// 读取shp文件选择界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开shp图层文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sFileName = "";
            OpenFileDialog sOpenFileDialog = new OpenFileDialog();
            sOpenFileDialog.Filter = "shapefiles(*.shp)|*.shp|All files(*.*)|*.*";
            sOpenFileDialog.FilterIndex = 1;
            if (sOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = sOpenFileDialog.FileName;
                sOpenFileDialog.Dispose();
                LoadLayerFile(sFileName);
            }
            else
            {
                sOpenFileDialog.Dispose();
                return;
            }

        }

        private void 打开数据库图层文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sFileName = "";
            OpenFileDialog sOpenFileDialog = new OpenFileDialog();
            sOpenFileDialog.Filter = "database(*.db)|*.db|All files(*.*)|*.*";
            sOpenFileDialog.FilterIndex = 1;
            if (sOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = sOpenFileDialog.FileName;
                sOpenFileDialog.Dispose();
                LoadLayerFile(sFileName);
            }
            else
            {
                sOpenFileDialog.Dispose();
                return;
            }
        }

        private void RemoveItemToolStripButton_Click(object sender, EventArgs e)
        {
            if (mIsEditing == false)
            {
                return;
            }
            var layer = GetSelectableLayer();
            if (layer.SelectedFeatures.Count != 0)
                layer = NewUndo(layer);


            var selectedFeatures = layer.SelectedFeatures;
            layer.Features.RemoveRange(selectedFeatures.ToArray());
            selectedFeatures.Clear();
            geoMap.RedrawMap();
            UpdateTreeView();
            CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
        }

        private void uiPanel3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void geoMap_DoubleClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            Logging = "鼠标双击";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Sketch)
            {
                btnEndPart_Click(sender, e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {

            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Edit)
            {
#if DEBUG
                Logging = "编辑模式双击";
#endif
                
                // 找到鼠标点击后对应的点
                GeoPoint mousePoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
                double tolerance = geoMap.ToMapDistance(mSelectingTolerance);

                string mode = null; // "add", "delete"
                if (mEditingGeometry.GetType() == typeof(GeoMultiPolygon))
                {
                    GeoMultiPolygon editingMultiPolygon = mEditingGeometry as GeoMultiPolygon; // 目前只考虑选择一个多边形
                                                                                          // 如果鼠标的点并不在多边形附近, 直接放弃
                    if (!editingMultiPolygon.GetEnvelope().IsInside(mousePoint, tolerance))
                    {
                        return;
                    }

                    // 遍历所有点集, 查找是否点击了某一个点
                    for (int i = 0; i < editingMultiPolygon.Parts.Count; i++)
                    {
                        // 对每一个点集判断是否包含鼠标的范围
                        GeoPoints points = editingMultiPolygon.Parts.GetItem(i);
                        if (GeoMapTools.IsPointOnPolygon(mousePoint, points, tolerance))
                        {
#if DEBUG
                            Logging = "在线上";
#endif
                            foreach(var point in points.ToArray())
                            {
                                if (GeoMapTools.IsPointOnPoint(mousePoint, point, tolerance))
                                    // 双击，点到了一个点，说明需要删掉这个点
                                {
#if DEBUG
                                    Logging = "且在点上";
#endif
                                    if (points.Count > 3)
                                        // 如果点数量超过三个，那么需要删除这个点，更新extent，重新绘图
                                    {
#if DEBUG
                                        Logging = "删除点";
#endif
                                        points.Remove(point);
                                    }
                                    else
                                        // 否则直接删掉这个多边形即可
                                    {
#if DEBUG
                                        Logging = "删除多边形";
#endif
                                        editingMultiPolygon.Parts.Remove(points);
                                    }
                                    editingMultiPolygon.UpdateExtent();
                                    return;
                                }
                            }

#if DEBUG
                            Logging = "但不在点上";
#endif
                            // 此时需要新建一个点
                            int index = GeoMapTools.PointOnWhichLine(mousePoint, points, tolerance);
                            if (index == -1)
                            {
#if DEBUG
                                Logging = "这里一定有问题";
                                Debug.Assert(true);
#endif
                            }
                            else
                            {
                                points.Insert(index + 1, mousePoint);
                                points.UpdateExtent();
                            }
                            editingMultiPolygon.UpdateExtent();
                            geoMap.RedrawTrackingShapes();
                            return;
                        }
                    }
                }
                else if (mEditingGeometry.GetType() == typeof(GeoMultiPolyline))
                {
                    GeoMultiPolyline editingMultiPolyline = mEditingGeometry as GeoMultiPolyline; // 目前只考虑选择一个多边形
                                                                                               // 如果鼠标的点并不在多边形附近, 直接放弃
                    if (!editingMultiPolyline.GetEnvelope().IsInside(mousePoint, tolerance))
                    {
                        return;
                    }

                    // 遍历所有点集, 查找是否点击了某一个点
                    for (int i = 0; i < editingMultiPolyline.Parts.Count; i++)
                    {
                        // 对每一个点集判断是否包含鼠标的范围
                        GeoPoints points = editingMultiPolyline.Parts.GetItem(i);
                        if (GeoMapTools.IsPointOnPolyline(mousePoint, points, tolerance))
                        {
#if DEBUG
                            Logging = "在线上";
#endif
                            foreach (var point in points.ToArray())
                            {
                                if (GeoMapTools.IsPointOnPoint(mousePoint, point, tolerance))
                                // 双击，点到了一个点，说明需要删掉这个点
                                {
#if DEBUG
                                    Logging = "且在点上";
#endif
                                    if (points.Count > 2)
                                    // 如果点数量超过两个，那么需要删除这个点，更新extent，重新绘图
                                    {
#if DEBUG
                                        Logging = "删除点";
#endif
                                        points.Remove(point);
                                    }
                                    else
                                    // 否则直接删掉这个多边形即可
                                    {
#if DEBUG
                                        Logging = "删除多边形";
#endif
                                        editingMultiPolyline.Parts.Remove(points);
                                    }
                                    editingMultiPolyline.UpdateExtent();
                                    return;
                                }
                            }

#if DEBUG
                            Logging = "但不在点上";
#endif
                            // 此时需要新建一个点
                            int index = GeoMapTools.PointOnWhichLine(mousePoint, points, tolerance);
                            if (index == -1)
                            {
#if DEBUG
                                Logging = "这里一定有问题";
                                Debug.Assert(true);
#endif
                            }
                            else
                            {
                                points.Insert(index + 1, mousePoint);
                                points.UpdateExtent();
                            }
                            editingMultiPolyline.UpdateExtent();
                            geoMap.RedrawTrackingShapes();
                            return;
                        }
                    }
                }
                else
                {
                    // 不需要对点进行加减操作

                }







                // 没有找到好奇怪, 应该是多边形在附近但是和点离得也不近, 有点蠢
                return;
            }
        }

        #region CopyPaste
        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            // Control被按下
            {
#if DEBUG
                Logging = "Control 按下";
#endif
                if (e.KeyCode == Keys.C)
                // Control-C, Copy
                {
#if DEBUG
                    Logging = "Control-C 按下";
#endif
                    Copy();
                }
                else if (e.KeyCode == Keys.X)
                {
                    Cut();
                }
                else if (e.KeyCode == Keys.V)
                // Control-V, Paste
                {
                    Paste();
                }
                else if (e.KeyCode == Keys.Z)
                // Control-Z, Undo
                {
                    Undo();
                }
                else if (e.KeyCode == Keys.Y)
                // Control-Y, Redo
                {
                    Redo();
                }
            }
#if DEBUG
            Logging = e.KeyValue.ToString() + " key down";
#endif
        }

        private List<GeoGeometry> mItemsForCopy = new List<GeoGeometry>();
        private void Copy()
        {
#if DEBUG
            Logging = "Copy";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                var sLayer = GetSelectableLayer();
                if (sLayer.SelectedFeatures.Count == 0)
                {
                    return;
                }
                sLayer = NewUndo(sLayer);
                var features = sLayer.SelectedFeatures;
                mItemsForCopy.Clear();
                foreach (var feature in features.ToArray())
                {
                    mItemsForCopy.Add(feature.Geometry.Clone());
                }
                CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
            }
        }

        private void Paste()
        {
#if DEBUG
            Logging = "Paste";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                var sLayer = GetSelectableLayer();
                sLayer = NewUndo(sLayer);
                sLayer.ClearSelection();
                double sDeltaX = geoMap.ToMapDistance(20);
                double sDeltaY = geoMap.ToMapDistance(20);
                MoveGeometries(mItemsForCopy, sDeltaX, sDeltaY);
                foreach (var geometry in mItemsForCopy)
                {
                    if (geometry.Type != sLayer.ShapeType)
                    {
                        return;
                    }
                    var sFeature = sLayer.GetNewFeature();

                    sFeature.Geometry = geometry.Clone();
                    sLayer.Features.Add(sFeature);
                    sLayer.SelectedFeatures.Add(sFeature);
                }
                sLayer.UpdateExtent();

                geoMap.RedrawMap();
                CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
            }


        }

        private void Cut()
        {
#if DEBUG
            Logging = "Cut";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                var sLayer = GetSelectableLayer();
                var features = sLayer.SelectedFeatures;
                mItemsForCopy.Clear();
                foreach (var feature in features.ToArray())
                {
                    mItemsForCopy.Add(feature.Geometry.Clone());
                }

                sLayer.Features.RemoveRange(features.ToArray());
                sLayer.SelectedFeatures.Clear();
                geoMap.RedrawMap();
                CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
            }
        }
        #endregion

        #region 撤销和重做
        private List<(GeoMapLayer, GeoMapLayer)> undo_layers = new List<(GeoMapLayer, GeoMapLayer)>();
        private int _undo_index = -1;

        private int undo_index
        {
            get { return _undo_index; }
            set
            {
                _undo_index = value;
#if DEBUG
                Logging = _undo_index.ToString();
#endif
                CheckUndo();
            }
        }

        private void CheckUndo()
        {
            if (_undo_index == -1)
            {
                撤销ToolStripButton.Enabled = false;
                撤销操作ToolStripMenuItem.Enabled = false;
            }
            else
            {
                撤销操作ToolStripMenuItem.Enabled = true;
                撤销ToolStripButton.Enabled = true;
            }

            if (_undo_index == undo_layers.Count - 1)
            {
                重做ToolStripButton.Enabled = false;
                重做操作ToolStripMenuItem.Enabled = false;
            }
            else
            {
                重做ToolStripButton.Enabled = true;
                重做操作ToolStripMenuItem.Enabled = true;
            }

            if (undo_layers.Count == 0)
            {
                重做ToolStripButton.Enabled = false;
                重做操作ToolStripMenuItem.Enabled = false;
                撤销ToolStripButton.Enabled = false;
                撤销操作ToolStripMenuItem.Enabled = false;
            }

            if (undo_index != -1)
            {
                var currentLayer = undo_layers[undo_index].Item2;
                var anotherCurrentLayer = undo_layers[undo_index].Item1;
                if (!geoMap.Layers.Contain(currentLayer) && !geoMap.Layers.Contain(anotherCurrentLayer))
                // 如果没有这个图层（一般来说是被删掉了），那么直接清空编辑树
                {
                    undo_layers.Clear();
                    undo_index = -1;
                }
            }
        }

        private void Undo()
        {
            if (undo_layers.Count == 0 || undo_index == -1)
            {
                return;
            }
            geoMap.Layers.Replace(undo_layers[undo_index].Item2, undo_layers[undo_index].Item1);

            geoMap.RedrawMap();
            undo_index--;
            CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
        }

        private void Redo()
        {
            if (undo_layers.Count == 0 || undo_index == undo_layers.Count - 1)
            {
                return;
            }
            undo_index++;
            geoMap.Layers.Replace(undo_layers[undo_index].Item1, undo_layers[undo_index].Item2);
            geoMap.RedrawMap();

            CurrentAcitveLayerUpdated?.Invoke(this, mCurrentLayerNode.Tag as GeoMapLayer);
        }

        private void ResetUndo()
        {
            while (undo_index + 1 != undo_layers.Count)
            {
                undo_layers.RemoveAt(undo_index + 1);
            }
        }

        static int MAX_UNDO = 50;

        private GeoMapLayer NewUndo(GeoMapLayer srcLayer)
        {
            ResetUndo();


            var desLayer = srcLayer.Clone();
            geoMap.Layers.Replace(srcLayer, desLayer);
            desLayer.Selectable = true;

            undo_layers.Add((srcLayer, desLayer));

            UpdateTreeView();
            undo_index++;

            if (undo_layers.Count > MAX_UNDO)
            {
                undo_layers.RemoveRange(0, undo_layers.Count - MAX_UNDO);
                undo_index -= undo_layers.Count - MAX_UNDO;
            }
            return desLayer;
        }
        #endregion

        private void 复制要素_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void 粘贴要素_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void 退出DEETUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void layerTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
#if DEBUG
            Logging = "Node AfterCheck triggered, Current Node Check Status:" + e.Node.Checked.ToString();
#endif
            LayerTreeViewUpdateCheck(e.Node);
            IsProjectDirty = true;
        }

        private void FileTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0) return;//双击父节点返回
            string path = e.Node.Tag.ToString();
#if DEBUG
            Logging = path;
#endif
            if (File.Exists(path))
            {
                LoadLayerFile(path);
            }
            else
            {
                MessageBox.Show("该文件已被移动或删除，请确认文件位置后打开");
            }
        }

        private void 撤销_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void 重做_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void 矩形选择模式更改_Click(object sender, EventArgs e)
        {
            if (sender == 交叉选择 || sender == 交叉选择菜单)
            {
                全包含选择菜单.Checked = false;
                全包含选择.Checked = false;
                交叉选择.Checked = true;
                交叉选择菜单.Checked = true;
                return;
            }
            else if (sender == 全包含选择 || sender == 全包含选择菜单)
            {
                全包含选择菜单.Checked = true;
                全包含选择.Checked = true;
                交叉选择.Checked = false;
                交叉选择菜单.Checked = false;
                return;
            }
        }

        private void SelectionModeChange_Click(object sender, EventArgs e)
        {
            if (sender == newSelectionMenuItem || sender == newSelectionToolStripItem)
            {
                mSelectionMode = GeoSelectionModeConstant.NewSelection;
                newSelectionToolStripItem.Checked = true;
                newSelectionMenuItem.Checked = true;
                addSelectionToolStripItem.Checked = false;
                addSelectionMenuItem.Checked = false;
                removeSelectionToolStripItem.Checked = false;
                removeSelectionMenuItem.Checked = false;
                
            }
            if (sender == addSelectionMenuItem || sender == addSelectionToolStripItem)
            {
                mSelectionMode = GeoSelectionModeConstant.AddSelection;
                newSelectionToolStripItem.Checked = false;
                newSelectionMenuItem.Checked = false;
                addSelectionToolStripItem.Checked = true ;
                addSelectionMenuItem.Checked = true ;
                removeSelectionToolStripItem.Checked = false;
                removeSelectionMenuItem.Checked = false;
                
            }
            if (sender == removeSelectionMenuItem || sender == removeSelectionToolStripItem)
            {
                mSelectionMode = GeoSelectionModeConstant.RemoveSelection;
                newSelectionToolStripItem.Checked = false;
                newSelectionMenuItem.Checked = false;
                addSelectionToolStripItem.Checked = false;
                addSelectionMenuItem.Checked = false;
                removeSelectionToolStripItem.Checked = true;
                removeSelectionMenuItem.Checked = true;
                
            }
        }

        private void 导出图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "保存";
            saveFileDialog1.Filter = "*.png|*.png";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                geoMap.SaveImg(saveFileDialog1.FileName);
                //Timer timer1 = new Timer();
                //timer1.Enabled = true;
                //timer1.Enabled = false;
                //Point screenPoint = geoMap.PointToScreen(new Point());
                //Rectangle rect = new Rectangle(screenPoint, geoMap.Size);
                
                //Image img = new Bitmap(rect.Width, rect.Height);
                //Graphics g = Graphics.FromImage(img);
                //g.CopyFromScreen(Convert.ToInt32(rect.X*g.DpiX / 0.0254) - 1, Convert.ToInt32(rect.Y*g.DpiY / 0.0254) - 1,0, 0, rect.Size);
                //img.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                
                
                //Timer timer1 = new Timer();
                //timer1.Enabled = true;
                //timer1.Enabled = false;
                //Bitmap bit = new Bitmap(this.Width, this.Height);//实例化一个和窗体一样大的bitmap
                //Graphics g = Graphics.FromImage(bit);
                //g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
                //                                                      //g.CopyFromScreen(this.Left, this.Top, 0, 0, new Size(this.Width, this.Height));//保存整个窗体为图片
                //g.CopyFromScreen(geoMap.PointToScreen(Point.Empty), Point.Empty, geoMap.Size);//只保存某个控件
                //bit.Save(saveFileDialog1.FileName);//默认保存格式为PNG，保存成jpg格式质量不是很好
                //if (File.Exists(saveFileDialog1.FileName.ToString()))
                //{
                //    MessageBox.Show("截图成功！");
                //    return;
                //}
            }
        }

        private void RectSelectModeButton_Click(object sender, EventArgs e)
        {
            if (SelectModeButton.Checked)
            {
                UncheckModeToolStrip();
                
                mMapOpStyle = GeoMapOpStyleEnum.None;
            } else
            {
                UncheckModeToolStrip();
                SelectModeButton.Checked = true;
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.Select;
            }
        }

        private void 显示所有图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(TreeNode node in layerTreeView.Nodes)
            {
                node.Checked = true;
            }
        }

        private void 隐藏所有图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(TreeNode node in layerTreeView.Nodes)
            {
                node.Checked = false;
            }
        }

        private void 新建图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // 弹出一个对话框
            var newLayerForm = new NewLayerForm();

            newLayerForm.ShowDialog();
            var newLayer = newLayerForm.Layer;

            if (newLayer != null)
            {
                geoMap.Layers.Add(newLayer);
                UpdateTreeView();
                geoMap.RedrawMap();
            }
        }

        
        private void layerTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Color selectedColor = Color.FromArgb(48,48,48);
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(selectedColor), e.Node.Bounds);
         
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White,e.Bounds);
            }
            else
            {
                e.DrawDefault = true;
            }
         
            //if ((e.State & TreeNodeStates.Focused) != 0)
            //{
            //    using (Pen focusPen = new Pen(Color.Black))
            //    {
            //        focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            //        Rectangle focusBounds = e.Node.Bounds;
            //        focusBounds.Size = new Size(focusBounds.Width - 1,
            //        focusBounds.Height - 1);
            //        e.Graphics.DrawRectangle(focusPen, focusBounds);
            //    }
            //}
        }

        private void layerTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.Bounds.Contains(e.Location)) // 保证点其余部分不会出问题
            {
                //LayerTreeViewUpdateCheck(e.Node);
#if DEBUG
                Logging = "Node Double clicked not on TextRect, Current Node Check Status:" + e.Node.Checked.ToString();
#endif
                return;
            }

            
            TreeNode node = layerTreeView.GetNodeAt(e.Location);
            if(node != null)
            {
                if(node.Nodes.Count != 0)
                {
                    mCurrentLayerNode = node;
                }
                else
                {
                    mCurrentLayerNode = node.Parent;
                }
                GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;

                FormCollection collection = Application.OpenForms;

                foreach (Form form in collection)
                {
                    if (form.GetType() == typeof(LayerAttributesForm))
                    { 
                        form.TopMost = true; 
                        return;
                    }
                }

                //GeoMapLayer layer = new GeoMapLayer(mCurrentLayerNode.Text, GeoGeometryTypeConstant.Point);
                LayerAttributesForm layerAttributes = new LayerAttributesForm(layer, geoMap);
                layerAttributes.FormClosed += layerAttributes_FormClosed;
                layerAttributes.Show();
            }

    
        }

        private void 剪切要素_Click(object sender, EventArgs e)
        {
            Cut();
        }

     
        private void MainPage_KeyUp(object sender, KeyEventArgs e)
        {
#if DEBUG
            Logging = e.KeyValue.ToString() + " key up";
#endif
        }
    }
}
