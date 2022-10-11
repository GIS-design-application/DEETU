using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DEETU.Core;
using DEETU.Geometry;
using DEETU.Map;
using DEETU.Tool;
using DEETU.IO;

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
        private bool mIsInPan = false; // 是否在漫游 
        private bool mIsInIdentify = false; // 是否在查询
        private bool mIsMovingShapes = false; // 是否正在移动图形
        private List<GeoGeometry> mMovingGeometries = new List<GeoGeometry>(); // 正在移动的图形集合
        private GeoGeometry mEditingGeometry; // 正在编辑的图形
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
            if(sDialog.ShowDialog() == DialogResult.OK)
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
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnFullExtent_Click(object sender, EventArgs e)
        {

        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {

        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {

        }

        private void btnPan_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpleRender_Click(object sender, EventArgs e)
        {

        }

        private void btnUniqueValue_Click(object sender, EventArgs e)
        {

        }

        private void btnClassBreaks_Click(object sender, EventArgs e)
        {

        }

        private void btnShowLabela_Click(object sender, EventArgs e)
        {

        }

        private void btnMovePolygon_Click(object sender, EventArgs e)
        {

        }

        private void btnSketchPolygon_Click(object sender, EventArgs e)
        {

        }

        private void btnEndPart_Click(object sender, EventArgs e)
        {

        }

        private void btnEndSketch_Click(object sender, EventArgs e)
        {

        }

        private void btnEditPolygon_Click(object sender, EventArgs e)
        {

        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region 地图控件事件处理
        private void geoMap_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void geoMap_MouseMove(object sender, MouseEventArgs e)
        {
            // 显示屏幕坐标
            ShowCoordinates(e.Location);
        }

        private void geoMap_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void geoMap_MouseClick(object sender, MouseEventArgs e)
        {

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

        private void geoMap_AfterTrackingLayerDraw(object sender, Tool.GeoUserDrawingTool drawTool)
        {

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
