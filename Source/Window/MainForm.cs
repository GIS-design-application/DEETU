using DEETU.Core;
using DEETU.Geometry;
using DEETU.IO;
using DEETU.Map;
using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DEETU
{
    public partial class MainForm : Form
    {
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
        private GeoSimpleFillSymbol mEditingPolygonSymbol; // 编辑多边形的符号
        private GeoSimpleMarkerSymbol mEditingVertexSymbol; // 编辑手柄符号
        private GeoSimpleLineSymbol mElasticSymbol; // 橡皮筋符号


        // 与地图操作有关的变量
        private int mMapOpStyle = 0; // 1: 放大, 2: 缩小, 3: 漫游, 4: 选择, 5: 查询
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


        #endregion


        public MainForm()
        {
            InitializeComponent();
            geoMap.MouseWheel += geoMap_MouseWheel;
        }


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
        }

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
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnFullExtent_Click(object sender, EventArgs e)
        {
            geoMap.FullExtent();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 1;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 2;
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 3;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 4;
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 5;
        }

        // 简单渲染
        private void btnSimpleRender_Click(object sender, EventArgs e)
        {
            // 查找多边形图层
            GeoMapLayer sLayer = GetPolygonLayer();
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
            GeoMapLayer sLayer = GetPolygonLayer();
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
            GeoMapLayer sLayer = GetPolygonLayer();
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

        // 移动多边形
        private void btnMovePolygon_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 6;
        }

        // 描绘多边形
        private void btnSketchPolygon_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 7;
        }

        // 结束part
        private void btnEndPart_Click(object sender, EventArgs e)
        {
            // 判断是否可以结束:三个点以上
            if (mSketchingShape.Last().Count < 3)
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
                GeoMapLayer sLayer = GetPolygonLayer();
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
                }
            }

            // 初始化描绘图形
            InitializeSketchingShape();
            geoMap.RedrawMap();
        }

        private void btnEditPolygon_Click(object sender, EventArgs e)
        {
            GeoMapLayer slayer = GetPolygonLayer();
            if (slayer == null)
            {
                return;
            }
            // 是否具有一个选择要素(不能没有, 不能有多个)
            if (slayer.SelectedFeatures.Count != 1)
                return;
            GeoMultiPolygon sOriMultiPolygon = slayer.SelectedFeatures.GetItem(0).Geometry as GeoMultiPolygon;
            GeoMultiPolygon sDesMultiPolygon = sOriMultiPolygon.Clone() as GeoMultiPolygon;
            mEditingGeometry = sDesMultiPolygon;

            mMapOpStyle = 8;
            geoMap.RedrawTrackingShapes();
        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            // 将mEditingGeometry中的多边形放回slayer中
            GeoMapLayer slayer = GetPolygonLayer();
            slayer.SelectedFeatures.GetItem(0).Geometry = mEditingGeometry;
            geoMap.RedrawMap();
            mEditingGeometry = null;
        }
        #endregion

        #region 地图控件事件处理
        private void geoMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)
            {
                OnZoomIn_MouseDown(e);
            }
            else if (mMapOpStyle == 2)
            {
                OnZoomOut_MouseDown(e);
            }
            else if (mMapOpStyle == 3)
            {
                OnPan_MouseDown(e);
            }
            else if (mMapOpStyle == 4)
            {
                OnSelect_MouseDown(e);
            }
            else if (mMapOpStyle == 5)
            {
                OnIdentify_MouseDown(e);
            }
            else if (mMapOpStyle == 6)
            {
                OnMoveShape_MouseDown(e);
            }
            else if (mMapOpStyle == 7)
            {

            }
            else if (mMapOpStyle == 8)
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

            GeoMultiPolygon editingPolygon = mEditingGeometry as GeoMultiPolygon; // 目前只考虑选择一个多边形

            // 找到鼠标点击后对应的点
            GeoPoint mousePoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);

            // 如果鼠标的点并不在多边形附近, 直接放弃
            if (!editingPolygon.GetEnvelope().IsInside(mousePoint, tolerance))
            {
                return;
            }

            // 遍历所有点集
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
                            return;
                        }
                    }
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
            GeoMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
            {
                return;
            }

            // 判断是否有选中的要素
            int sSelFeatureCount = sLayer.SelectedFeatures.Count;
            if (sSelFeatureCount == 0)
                return;
            mMovingGeometries.Clear();
            for (int i = 0; i < sSelFeatureCount; i++)
            {
                GeoMultiPolygon sOriPolygon = (GeoMultiPolygon)sLayer.SelectedFeatures
                                                                    .GetItem(i).Geometry;
                GeoMultiPolygon sDesPolygon = (GeoMultiPolygon)sOriPolygon.Clone();
                mMovingGeometries.Add(sDesPolygon);

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
            if (mMapOpStyle == 1)
            {
                OnZoomIn_MouseMove(e);
            }
            else if (mMapOpStyle == 2)
            {
                OnZoomOut_MouseMove(e);
            }
            else if (mMapOpStyle == 3)
            {
                OnPan_MouseMove(e);
            }
            else if (mMapOpStyle == 4)
            {
                OnSelect_MouseMove(e);
            }
            else if (mMapOpStyle == 5)
            {
                OnIdentify_MouseMove(e);
            }
            else if (mMapOpStyle == 6)
            {
                OnMoveShape_MouseMove(e);
            }
            else if (mMapOpStyle == 7)
            {
                OnSketch_MouseMove(e);
            }
            else if (mMapOpStyle == 8) // 编辑多边形
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
            sDrawingTool.DrawLine(sCurPoint, mEditingLeftPoint, mElasticSymbol);
            sDrawingTool.DrawLine(sCurPoint, mEditingRightPoint, mElasticSymbol);
        }

        private void OnSketch_MouseMove(MouseEventArgs e)
        {
            GeoPoint sCurPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            GeoPoints sLastPart = mSketchingShape.Last();
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

        private void OnMoveShape_MouseMove(MouseEventArgs e)
        {
            if (mIsMovingShapes == false)
            {
                return;
            }
            // 修改移动图形的坐标
            double sDeltaX = geoMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = geoMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            ModifyMovingGeometries(sDeltaX, sDeltaY);

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
            if (mMapOpStyle == 1)
            {
                OnZoomIn_MouseUp(e);
            }
            else if (mMapOpStyle == 2)
            {
                OnZoomOut_MouseUp(e);
            }
            else if (mMapOpStyle == 3)
            {
                OnPan_MouseUp(e);
            }
            else if (mMapOpStyle == 4)
            {
                OnSelect_MouseUp(e);
            }
            else if (mMapOpStyle == 5)
            {
                OnIdentify_MouseUp(e);
            }
            else if (mMapOpStyle == 6)
            {
                OnMoveShape_MouseUp(e);
            }
            else if (mMapOpStyle == 7)
            {

            }
            else if (mMapOpStyle == 8)
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


            // 重绘地图
            geoMap.RedrawMap();
            
        }

        private void OnMoveShape_MouseUp(MouseEventArgs e)
        {
            if (mIsMovingShapes == false)
                return;
            mIsMovingShapes = false;
            GeoMapLayer selectLayer = geoMap.Layers.getSelectableLayer();
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
                GeoFeatures sFeatures = sLayer.SearchByBox(sBox, tolerance);
                // 弹出窗体
                int sSelFeatureCount = sFeatures.Count;
                if (sSelFeatureCount > 0)
                {
                    GeoGeometry[] sGeometryies = new GeoGeometry[sSelFeatureCount];
                    for (int i = 0; i < sSelFeatureCount; i++)
                    {
                        sGeometryies[i] = sFeatures.GetItem(i).Geometry;
                    }
                    geoMap.FlashShapes(sGeometryies, 3, 800);
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
            if (mMapOpStyle == 7)
            {
                OnSketch_MouseClick(e);
            }
        }

        private void OnSketch_MouseClick(MouseEventArgs e)
        {
            // 将屏幕坐标转化为地图坐标并加入描绘图形
            GeoPoint sPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);

            // 在描绘多边形的最后一项加一个点

            mSketchingShape.Last().Add(sPoint);

            geoMap.RedrawTrackingShapes();
            // 实现持久图形的绘制
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

        }

        // 持久绘制图形(用于绘制描绘多边形的图形)
        private void geoMap_AfterTrackingLayerDraw(object sender, GeoUserDrawingTool drawTool)
        {
            DrawSketchingShapes(drawTool);
            DrawEditingShapes(drawTool);
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
            mEditingPolygonSymbol = new GeoSimpleFillSymbol();
            mEditingPolygonSymbol.Color = Color.Transparent;
            mEditingPolygonSymbol.Outline.Color = Color.DarkGreen;
            mEditingPolygonSymbol.Outline.Size = 0.53;
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

        //获取一个多边形图层
        private GeoMapLayer GetPolygonLayer()
        {
            Int32 sLayerCount = geoMap.Layers.Count;
            GeoMapLayer sLayer = null;
            for (Int32 i = 0; i <= sLayerCount - 1; i++)
            {
                if (geoMap.Layers.GetItem(i).ShapeType == GeoGeometryTypeConstant.MultiPolygon)
                {
                    sLayer = geoMap.Layers.GetItem(i);
                    break;
                }
            }
            return sLayer;
        }

        //修改移动图形的坐标
        private void ModifyMovingGeometries(double deltaX, double deltaY)
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
            }
        }

        //绘制正在描绘的图形
        private void DrawSketchingShapes(GeoUserDrawingTool drawingTool)
        {
            if (mSketchingShape == null)
                return;
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
        }


        #endregion
    }
}
