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

namespace DEETU.Source.Window
{
    public partial class MainPage : UIPage
    {
        public MainPage()
        {
            InitializeComponent();
            geoMap.MouseWheel += geoMap_MouseWheel;
        }

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

        // 与界面交互有关的变量
        private TreeNode mCurrentLayerNode;
        private GeoCoordinateReferenceSystem mCrs = new GeoCoordinateReferenceSystem();
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
        }


        private void btnFullExtent_Click(object sender, EventArgs e)
        {
            geoMap.FullExtent();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.ZoomIn)
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = new Cursor("./icons/ZoomIn.ico");
                mMapOpStyle = GeoMapOpStyleEnum.ZoomIn;
                CheckToolStrip(mMapOpStyle);
            }
            else
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.ZoomOut)
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = new Cursor("./icons/ZoomOut.ico");
                mMapOpStyle = GeoMapOpStyleEnum.ZoomOut;
                CheckToolStrip(mMapOpStyle);
            }
            else
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
            }
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.Pan)
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = new Cursor("./icons/PanUp.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Pan;
                CheckToolStrip(mMapOpStyle);
            }
            else
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.Select)
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = new Cursor("./icons/EditSelect.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Select;
                CheckToolStrip(mMapOpStyle);
            }
            else
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
            }
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            if (mMapOpStyle != GeoMapOpStyleEnum.Identify)
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = new Cursor("./icons/EditSelect.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Identify;
                CheckToolStrip(mMapOpStyle);
            }
            else
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
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
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = new Cursor("./icons/EditMove.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Move;
                CheckToolStrip(mMapOpStyle);
            }
            else
            {
                UncheckToolStrip(mMapOpStyle);
                mMapOpStyle = GeoMapOpStyleEnum.None;
                this.Cursor = Cursors.Default;
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
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = new Cursor("./icons/Cross.ico");
                mMapOpStyle = GeoMapOpStyleEnum.Sketch;
                mSketchingGeometryType = GetSelectableLayer().ShapeType; // 可以编辑的图层是什么类别就用添加什么类别的多边形
                CheckToolStrip(mMapOpStyle);
            }
             else
             // 停止描绘地理要素
            {
                UncheckToolStrip(mMapOpStyle);
                btnEndSketch_Click(sender, e);
                mMapOpStyle = GeoMapOpStyleEnum.None;
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// 添加元素下点击鼠标
        /// </summary>
        /// <param name="e"></param>
        private void OnSketch_MouseClick(MouseEventArgs e)
        {
            // 将屏幕坐标转化为地图坐标并加入描绘图形
            GeoPoint sPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);

            // 在描绘要素的最后一项加一个点
            mSketchingShape.Last().Add(sPoint);

            geoMap.RedrawTrackingShapes();
            // 实现持久图形的绘制
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
            if(sLayer != null)
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
            {
                UncheckToolStrip(mMapOpStyle);
                this.Cursor = Cursors.Default;
                mMapOpStyle = GeoMapOpStyleEnum.None;
                return;
            }
            this.Cursor = new Cursor("./icons/EditMoveVertex.ico");
            GeoMapLayer slayer = GetSelectableLayer();
            
            if (slayer == null)
            {
                return;
            }

            // 是否具有一个选择要素(不能没有, 不能有多个)
            if (slayer.SelectedFeatures.Count != 1)
                return;

            slayer = NewUndo(slayer);

            UncheckToolStrip(mMapOpStyle);
            mEditingGeometry = slayer.SelectedFeatures.GetItem(0).Geometry;
            mMapOpStyle = GeoMapOpStyleEnum.Edit;
            geoMap.RedrawTrackingShapes();
#if DEBUG

#endif
            CheckToolStrip(mMapOpStyle);
        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            // 将mEditingGeometry中的多边形放回slayer中
            GeoMapLayer slayer = GetSelectableLayer();
            slayer.SelectedFeatures.GetItem(0).Geometry = mEditingGeometry;

            // 取消编辑多边形
            mEditingGeometry = null;

            mMapOpStyle = GeoMapOpStyleEnum.None;

            // 重绘
            geoMap.RedrawMap();
        }
        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(geoMap.Layers.FilePath==null)
                SaveNewProject();
            else
            {
                GeoDatabaseIOTools.SaveGeoProject(geoMap.Layers, geoMap.Layers.FilePath);
            }
        }
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            geoMap.Layers=new GeoLayers();
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
                MessageBox.Show(saveFileDialog1.FileName);
                GeoDatabaseIOTools.SaveGeoProject(geoMap.Layers, saveFileDialog1.FileName);
                saveFileDialog1.Dispose();

            }
        }
        private void SaveNewProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNewProject();
        }
        private void CloseProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            geoMap.Layers = new GeoLayers();
            UpdateTreeView();

        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                GeoDatabaseIOTools.LoadGeoProject(geoMap.Layers, sFileName);
                geoMap.Layers.FilePath = sFileName;
                if (geoMap.Layers.Count == 1)
                {
                    geoMap.FullExtent();
                }
                else
                {
                    geoMap.RedrawMap();
                }
                UpdateTreeView();
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

        private void startEditToolStripButton_Click(object sender, EventArgs e)
        {
            if (mCurrentLayerNode == null)
            {
                UIMessageBox.ShowError("请选择图层", false);
            }
            btnSelect_Click(sender, e);
            mIsEditing = !mIsEditing;
            SetEditing();

            if (mIsEditing)
                startEditToolStripButton.Image = new Bitmap("./icons/edit_off.png");
            else
                startEditToolStripButton.Image = new Bitmap("./icons/edit.png");

        }
        #endregion


        #region 地图控件事件处理
        private void geoMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == GeoMapOpStyleEnum.ZoomIn)
            {
                OnZoomIn_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.ZoomOut)
            {
                OnZoomOut_MouseDown(e);
            }
            else if (mMapOpStyle == GeoMapOpStyleEnum.Pan)
            {
                this.Cursor = new Cursor("./icons/PanDown.ico");
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
                    logging = "点击到了嗷" + tolerance.ToString();
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

        private void OnPan_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
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
            if (mMapOpStyle == GeoMapOpStyleEnum.ZoomIn)
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
                if (mEditingLeftPoint != null )
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
            geoMap.Refresh();
            GeoPoint point1 = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            GeoPoint point2 = geoMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);

            GeoUserDrawingTool drawingTool = geoMap.GetDrawingTool();
            drawingTool.DrawLine(point1, point2, mElasticSymbol);
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
            if (mMapOpStyle == GeoMapOpStyleEnum.ZoomIn)
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
            if(mMovingGeometries.Count>0)
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

        private void OnIdentify_MouseUp(MouseEventArgs e)
        {
            if (mIsInIdentify == false)
                return;
            mIsInIdentify = false;
            geoMap.Refresh();
            GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);
            if (geoMap.Layers.Count == 0)
            {
                return;
            }
            else
            {
                GeoMapLayer sLayer = geoMap.Layers.GetItem(0);

                GeoFields sFields = sLayer.AttributeFields;
                int sFieldCount = sFields.Count;
                string[] sFieldString = new string[sFieldCount];
                for (int i = 0; i < sFieldCount; i++)
                {
                    sFieldString[i] = sFields.GetItem(i).Name;
                }

                GeoFeatures sFeatures = sLayer.SearchByBox(sBox, tolerance);
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
                    MessageBox.Show(info, "属性信息", MessageBoxButtons.OK);

                    // geoMap.FlashShapes(sGeometryies, 3, 800);
                }
            }
        }
        private void OnSelect_MouseUp(MouseEventArgs e)
        {
            if (mIsInSelect == false)
                return;
            mIsInSelect = false;
            GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);
            geoMap.SelectByBox(sBox, tolerance, 0);
            geoMap.RedrawTrackingShapes();
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
            logging = "鼠标单击";
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
                        layerTreeView.Nodes.Insert(newIndex, (TreeNode)treeNode.Clone());
                        // 将被拖动的节点移除
                        treeNode.Remove();
                        geoMap.RedrawMap();
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
        private void MoveGeometries(List<GeoGeometry>mMovingGeometries, double deltaX, double deltaY)
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

        // 取消工具栏对应按钮的选中状态
        private void UncheckToolStrip(GeoMapOpStyleEnum mapOpStyle)
        {
            switch (mapOpStyle)
            {
                case GeoMapOpStyleEnum.ZoomIn:
                    zoomInToolStripButton.Checked = false;
                    break;
                case GeoMapOpStyleEnum.ZoomOut:
                    zoomOutToolStripButton.Checked = false;
                    break;
                case GeoMapOpStyleEnum.Pan:
                    panToolStripButton.Checked = false;
                    break;
                case GeoMapOpStyleEnum.Identify:
                    identifyToolStripButton.Checked = false;
                    break;
                case GeoMapOpStyleEnum.Select:
                    交叉选中ToolStripMenuItem.Checked = false;
                    break;
                case GeoMapOpStyleEnum.Move:
                    MoveItemToolStripButton.Checked = false;
                    break;
                case GeoMapOpStyleEnum.Edit:
                    EditFeatureToolStripButton.Checked = false;
                    btnEndEdit_Click(null, null);
                    break;
                case GeoMapOpStyleEnum.Sketch:
                    AddFeatureToolStripButton.Checked = false;
                    break;
                default:
                    break;
            }
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
                    zoomInToolStripButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.ZoomOut:
                    zoomOutToolStripButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Pan:
                    panToolStripButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Identify:
                    identifyToolStripButton.Checked = true;
                    break;
                case GeoMapOpStyleEnum.Select:
                    交叉选中ToolStripMenuItem.Checked = true;
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
                mCrs = geoMap.Layers.GetItem(0).Crs;
                ShowCrs();
            }
            layerTreeView.Nodes.Clear();
            for (int i = 0; i < geoMap.Layers.Count; ++i)
            {
                InsertTreeNode(geoMap.Layers.GetItem(i), i);
            }
        }

        // 这个函数是为了显示图层渲染方式
        // 在加入图层和修改渲染方式时调用
        private void InsertTreeNode(GeoMapLayer layer, int index)
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
                
                layerNode.ContextMenuStrip = layerContextMenuStrip;
                //layerTreeView.Nodes.Insert(0,layerNode);
                layerNode.Tag = layer;
                layerTreeView.Nodes.Insert(index, layerNode);
            }
            else if (sRenderer.RendererType == GeoRendererTypeConstant.ClassBreaks)
            {
                GeoClassBreaksRenderer sClassBreaksRenderer = (GeoClassBreaksRenderer)sRenderer;
                
                TreeNode FieldName = new TreeNode(sClassBreaksRenderer.Field);
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                FieldName.SelectedImageIndex = FieldName.ImageIndex = TreeImages.Images.Count - 1;

                List<TreeNode> styles = new List<TreeNode>() { FieldName };
                int BreakCount = sClassBreaksRenderer.BreakCount;
                for (int i = 0; i < BreakCount; ++i)
                {
                    string startValue = i == 0 ? "0" : sClassBreaksRenderer.GetBreakValue(i - 1).ToString();
                    string endValue = sClassBreaksRenderer.GetBreakValue(i).ToString();
                    styles.Add(CreateSimpleStyleTreeNode(sClassBreaksRenderer.GetSymbol(i), startValue + "~" + endValue));
                }

                TreeNode layerNode = new TreeNode(layer.Name, styles.ToArray());
                sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                layerNode.SelectedImageIndex = layerNode.ImageIndex = TreeImages.Images.Count - 1;

                layerNode.ContextMenuStrip = layerContextMenuStrip;
                //layerTreeView.Nodes.Insert(0,layerNode);
                layerNode.Tag = layer;
                layerTreeView.Nodes.Insert(index, layerNode);
            }
            else if (sRenderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                GeoUniqueValueRenderer sUniqueValueRenderer = (GeoUniqueValueRenderer)sRenderer;
                
                TreeNode FieldName = new TreeNode(sUniqueValueRenderer.Field);
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sSymbol.Color = Color.Transparent;
                TreeImages.Images.Add(CreateBitmapFromSymbol(sSymbol));
                FieldName.SelectedImageIndex = FieldName.ImageIndex = TreeImages.Images.Count - 1;

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

                layerNode.ContextMenuStrip = layerContextMenuStrip;
                //layerTreeView.Nodes.Insert(0,layerNode);
                layerNode.Tag = layer;
                layerTreeView.Nodes.Insert(index, layerNode);
            }
            else
            {
                throw new Exception("Renderer Type Error!");
            }
        }

        private TreeNode CreateSimpleStyleTreeNode(GeoSymbol symbol, string label = "    ")
        {
            TreeNode style = new TreeNode(label);
            TreeImages.Images.Add(CreateBitmapFromSymbol(symbol));
            style.SelectedImageIndex = style.ImageIndex = TreeImages.Images.Count - 1;
            style.Tag = symbol;
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
                double dpm = 1000; // I don't know the correct dpm here so I just randomly assigned a number
                Pen sPen = new Pen(sLineSymbol.Color, (float)(sLineSymbol.Size / 1000 * dpm));
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
            startEditToolStripButton.Checked = mIsEditing;           

            RemoveItemToolStripButton.Enabled = mIsEditing;
            MoveItemToolStripButton.Enabled = mIsEditing;
            EditFeatureToolStripButton.Enabled = mIsEditing;
            AddFeatureToolStripButton.Enabled = mIsEditing;
            剪切要素ToolStripButton.Enabled = mIsEditing;
            复制要素ToolStripButton.Enabled = mIsEditing;
            粘贴要素ToolStripButton.Enabled = mIsEditing;
            撤销ToolStripButton.Enabled = mIsEditing;
            重做ToolStripButton.Enabled = mIsEditing;

            剪切要素ToolStripMenuItem.Enabled = mIsEditing;
            复制要素ToolStripMenuItem.Enabled = mIsEditing;
            粘贴要素ToolStripMenuItem.Enabled = mIsEditing;
            撤销操作ToolStripMenuItem.Enabled = mIsEditing;
            重做操作ToolStripMenuItem.Enabled = mIsEditing;
        }
        #endregion

        #region 图层右键菜单
        private void 特性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // !这里获取layer时应该是按名字获取，或许可以考虑在Layers里面加一个GetItem(string name)的函数。
            // ** 现在用code的Tag data 的形式实现了；
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;

            //GeoMapLayer layer = new GeoMapLayer(mCurrentLayerNode.Text, GeoGeometryTypeConstant.Point);
            LayerAttributesForm layerAttributes = new LayerAttributesForm(layer);
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
                MessageBox.Show(saveFileDialog1.FileName);
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
                MessageBox.Show(saveFileDialog1.FileName);
                GeoDatabaseIOTools.SaveGeoProject(sLayers, saveFileDialog1.FileName);
                saveFileDialog1.Dispose();
            }
            
        }
        private void 定义坐标参照系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoMapLayer layer = mCurrentLayerNode.Tag as GeoMapLayer;
#if DEBUG
            if (layer.Crs.Type == CrsType.None)
                layer.Crs = new GeoCoordinateReferenceSystem(GeographicCrsType.Beijing1954, ProjectedCrsType.Lambert2SP);
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
            AttributeTableForm attributeForm = new AttributeTableForm(layer);
            attributeForm.MapRedraw += AttributeForm_MapRedraw;
            attributeForm.LayerQuery += ExpressionForm_LayerQuery;
            attributeForm.Show();
        }

        #endregion

        #region 子窗口事件处理
        private void layerAttributes_FormClosed(object sender, FormClosedEventArgs e)
        {
            InsertTreeNode(mCurrentLayerNode.Tag as GeoMapLayer, mCurrentLayerNode.Index);
            mCurrentLayerNode.Remove();
            geoMap.RedrawMap();
        }

        private void AttributeForm_MapRedraw(object sender)
        {
            geoMap.RedrawMap();
        }

        private void ExpressionForm_LayerQuery(object sender, GeoMapLayer layer, string expression, GeoSelectionModeConstant selectionMode)
        {
            QueryExpressionLayer(layer, expression, selectionMode);
        }

        #endregion

        /// <summary>
        /// 每当一个图层被选择时, 自动选择该图层作为编辑的对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layerTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Nodes.Count != 0)
                mCurrentLayerNode = e.Node;
#if DEBUG
            logging = mCurrentLayerNode.Text;
#endif
            int layerIndex = mCurrentLayerNode.Index;
            geoMap.Layers.Deselect();
            GeoMapLayer layer = geoMap.Layers.GetItem(layerIndex);
            layer.Selectable = true;
        }

#if DEBUG
        private string logging
        {
            get
            {
                return _logging.Text;
            }
            set
            {
                _logging.AppendText("\r\n" + System.DateTime.Now.ToString("HH:mm:ss") + "  " + value);
                _logging.ScrollToCaret();
            }
        }
        private TextBox _logging = null;
        public void SetDebugForm(DebugForm form)
        {
            _logging = form.logging;
        }
#endif
        private void btnLoadLayerFile_Click(object sender, EventArgs e)
        {
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
                FileStream sStream = new FileStream(sFileName, FileMode.Open);
                BinaryReader sr = new BinaryReader(sStream);
                GeoMapLayer sLayer = GeoDataIOTools.LoadMapLayer(sr);
                sLayer.Name = sFileName.Split('\\').Last().Split('.').First();
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
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
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
                try
                {
                    GeoMapLayer sLayer = GeoShpIOTools.ReadSHPFile(sFileName);
                    sLayer.Name = sFileName.Split('\\').Last().Split('.').First();
                    char[] path = sOpenFileDialog.FileName.ToCharArray();
                    if (path.Length != 0)
                    {
                        path[path.Length - 1] = 'f';
                        path[path.Length - 2] = 'b';
                        path[path.Length - 3] = 'd';

                        GeoShpIOTools.ReadDBFFile(new string(path), sLayer);
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
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
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
                try
                {
                    GeoLayers sLayers = new GeoLayers();
                    GeoDatabaseIOTools.LoadGeoProject(sLayers, sFileName);
                    GeoMapLayer sLayer = sLayers.GetItem(0);
                    sLayer.Name = sFileName.Split('\\').Last().Split('.').First();
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
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
            else
            {
                sOpenFileDialog.Dispose();
                return;
            }
        }


        private void RemoveItemToolStripButton_Click(object sender, EventArgs e)
        {

            var layer = GetSelectableLayer();
            if (layer.SelectedFeatures.Count != 0)
                layer = NewUndo(layer);


            var selectedFeatures = layer.SelectedFeatures;
            layer.Features.RemoveRange(selectedFeatures.ToArray());
            selectedFeatures.Clear();
            geoMap.RedrawMap();
            this.Cursor = Cursors.Default;
        }

        private void uiPanel3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void geoMap_DoubleClick(object sender, EventArgs e)
        {
#if DEBUG
            logging = "鼠标双击";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Sketch)
            {
                btnEndPart_Click(sender, e);
            }
        }





        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            // Control被按下
            {
#if DEBUG
                logging = "Control 按下";
#endif
                if (e.KeyCode == Keys.C)
                // Control-C, Copy
                {
#if DEBUG
                    logging = "Control-C 按下";
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
            logging = e.KeyValue.ToString() + " key down";
#endif
        }

        private List<GeoGeometry> mItemsForCopy = new List<GeoGeometry>();
        private void Copy()
        {
#if DEBUG
            logging = "Copy";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                var sLayer = GetSelectableLayer();
                var features = sLayer.SelectedFeatures;
                mItemsForCopy.Clear();
                foreach(var feature in features.ToArray())
                {
                    mItemsForCopy.Add(feature.Geometry.Clone());
                }
            }
        }

        private void Paste()
        {
#if DEBUG
            logging = "Paste";
#endif
            if (mMapOpStyle == GeoMapOpStyleEnum.Select)
            {
                var sLayer = GetSelectableLayer();
                sLayer.ClearSelection();
                double sDeltaX = geoMap.ToMapDistance(20);
                double sDeltaY = geoMap.ToMapDistance(20);
                MoveGeometries(mItemsForCopy, sDeltaX, sDeltaY);
                foreach (var geometry in mItemsForCopy)
                {
                    var sFeature = sLayer.GetNewFeature();
                    
                    sFeature.Geometry = geometry.Clone();
                    sLayer.Features.Add(sFeature);
                    sLayer.SelectedFeatures.Add(sFeature);
                }
                sLayer.UpdateExtent();
                
                geoMap.RedrawMap();
            }


        }

        private void Cut()
        {
#if DEBUG
            logging = "Cut";
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
                geoMap.RedrawMap();
            }
        }

        private List<(GeoMapLayer, GeoMapLayer)> undo_layers = new List<(GeoMapLayer, GeoMapLayer)>();
        private int undo_index = -1;

        private void Undo()
        {
            if (undo_layers.Count == 0 || undo_index == -1)
            {
                return;
            }
            geoMap.Layers.Replace(undo_layers[undo_index].Item2, undo_layers[undo_index].Item1);
            undo_index--;
            geoMap.RedrawMap();
        }

        private void Redo()
        {
            if (undo_layers.Count == 0 || undo_index == undo_layers.Count -1)
            {
                return;
            }
            undo_index++;
            geoMap.Layers.Replace(undo_layers[undo_index].Item1, undo_layers[undo_index].Item2);
            geoMap.RedrawMap();
        }

        private void ResetUndo()
        {
            while(undo_index + 1 != undo_layers.Count)
            {
                undo_layers.RemoveAt(undo_index + 1);
            }
        }

        private GeoMapLayer NewUndo(GeoMapLayer srcLayer)
        {
            ResetUndo();
            undo_index++;
            var desLayer = srcLayer.Clone();
            geoMap.Layers.Replace(srcLayer, desLayer);
            desLayer.Selectable = true;
           
            undo_layers.Add((srcLayer, desLayer));
            return desLayer;
        }

        private void 复制要素ToolStripButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void 粘贴要素ToolStripButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void 移除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除图层吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                geoMap.Layers.RemoveAt(mCurrentLayerNode.Index);
                mCurrentLayerNode.Remove();
                UpdateTreeView();
                geoMap.RedrawMap();
            }
        }

        private void 退出DEETUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void 移到顶层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            layerTreeView.Nodes.Insert(0, (TreeNode)mCurrentLayerNode.Clone());
            geoMap.Layers.Insert(0, mCurrentLayerNode.Tag as GeoMapLayer);
            geoMap.Layers.RemoveAt(mCurrentLayerNode.Index);
            mCurrentLayerNode.Remove();
            geoMap.RedrawMap();
        }

        private void 剪切要素ToolStripButton_Click(object sender, EventArgs e)
        {
            Cut();
        }

     

        private void MainPage_KeyUp(object sender, KeyEventArgs e)
        {
#if DEBUG
            logging = e.KeyValue.ToString() + " key up";
#endif
        }
    }
}
