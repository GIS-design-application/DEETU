using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEETU.Geometry;
using DEETU.Core;
using DEETU.Tool;
using DEETU.Map;

namespace DEETU.Map
{
    public partial class GeoMapControl : UserControl
    {
        #region 字段

        // 设计时属性变量
        private Color _SelectionColor = Color.Cyan; // 选择要素的颜色
        private Color _FlashColor = Color.Green; // 闪烁要素的颜色

        // 运行时属性变量
        private GeoLayers _Layers = new GeoLayers(); // 图层集合

        // 模块级变量（优点是更适合描述一个软件的整体结构）
        private GeoMapDrawingReference mMapDrawingReference; // 地图屏幕坐标转换对象
        private Bitmap mBufferMap1 = new Bitmap(10, 10); // 缓冲位图,含要素及其注记
        private Bitmap mBufferMap2 = new Bitmap(10, 10); // 缓冲位图,含要素(包括注记)及跟踪图形
        private Bitmap mBufferMap3 = new Bitmap(10, 10); // 在屏幕上移动BufferMap2时,先将2绘制到3上,再将3绘制到控件上,以避免清除便捷带来的闪烁,相当于使用buffermap3绕过了闪烁

        private GeoSimpleMarkerSymbol mSelectedPointSymbol; // 选择的点符号
        private GeoSimpleLineSymbol mSelectedLineSymbol; // 选择的线要素
        private GeoSimpleFillSymbol mSelectedFillSymbol; // 选择的面符号

        private GeoShapeFlashControler mFlashControler = new GeoShapeFlashControler();
        private GeoSimpleMarkerSymbol mFlashPointSymbol;
        private GeoSimpleLineSymbol mFlashLineSymbol; // 闪烁的线符号
        private GeoSimpleFillSymbol mFlashFillSymbol; // 闪烁的面符号





        #endregion

        #region 构造函数
        public GeoMapControl()
        {
            CreateMapDrawingReference();// 新建地图-屏幕坐标转换对象
            InitializeComponent();
            InitializeSymbols(); // 初始化符号
            ResizeBufferMap(); // 调整缓冲位图尺寸

            mFlashControler.NeedDrawFlashShapes += MFlashControler_NeedDrawFlashShapes;
            mFlashControler.NeedClearFlashShapes += MFlashControler_NeedClearFlashShapes;

        }


        #endregion


        #region 属性


        [Browsable(false)]
        public GeoLayers Layers
        {
            get { return _Layers; }
            set { _Layers = value; }
        }


        /// <summary>
        /// 获取比例尺倒数
        /// </summary>
        [Browsable(false)]
        public double MapScale
        {
            get
            {
                return mMapDrawingReference.MapScale;
            }

        }

        /// <summary>
        /// 获取控件左上点的X坐标
        /// </summary>
        [Browsable(false)]
        public double MapOffsetX
        {
            get { return mMapDrawingReference.OffsetX; }
        }

        /// <summary>
        /// 获取控件左上点的Y坐标（地图坐标）
        /// </summary>
        [Browsable(false)]
        public double MapOffsetY
        {
            get { return mMapDrawingReference.OffsetY; }
        }

        /// <summary>
        /// 获取或设置选择颜色
        /// </summary>
        [Browsable(true), Description("获取或设置选择颜色")]
        public Color SelectionColor
        {
            get { return _SelectionColor; }
            set { _SelectionColor = value; }
        }

        /// <summary>
        /// 获取或设置闪烁图形的颜色
        /// </summary>
        [Browsable(true), Description("获取或设置选择颜色")]
        public Color FlashColor
        {
            get { return _FlashColor; }
            set { _FlashColor = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 获取地图窗口对应的地图范围(地图坐标)
        /// </summary>
        /// <returns></returns>
        public GeoRectangle GetExtent()
        {
            //定义变量
            double sMinX = double.MaxValue, sMaxX = double.MinValue;
            double sMinY = double.MaxValue, sMaxY = double.MinValue;
            GeoRectangle sExtent;
            //如果工作区为空，则返回空矩形
            Rectangle sClientRect = this.ClientRectangle;
            if (sClientRect.IsEmpty == true)
            {
                sExtent = new GeoRectangle(sMinX, sMaxX, sMinY, sMaxY);
                return sExtent;
            }
            //定义工作区左上点和右下点的屏幕坐标
            GeoPoint sTopLeftScreenPoint = new GeoPoint(0, 0);
            GeoPoint sBottomRightScreenPoint = new GeoPoint(sClientRect.Width, sClientRect.Height);
            //获取工作区左上点和右下点的地图坐标
            GeoPoint sTopLeftMapPoint = mMapDrawingReference.ToMapPoint(sTopLeftScreenPoint.X, sTopLeftScreenPoint.Y);
            GeoPoint sBottomRightMapPoint = mMapDrawingReference.ToMapPoint(sBottomRightScreenPoint.X, sBottomRightScreenPoint.Y);
            //定义范围矩形
            sMinX = sTopLeftMapPoint.X;
            sMaxX = sBottomRightMapPoint.X;
            sMinY = sBottomRightMapPoint.Y;
            sMaxY = sTopLeftMapPoint.Y;
            sExtent = new GeoRectangle(sMinX, sMaxX, sMinY, sMaxY);
            return sExtent;
        }

        /// <summary>
        /// 获取整个地图的范围(数据的范围)
        /// </summary>
        /// <returns></returns>
        public GeoRectangle GetFullExtent()
        {
            //（1）新建一个空矩形
            double sMinX = double.MaxValue, sMaxX = double.MinValue;
            double sMinY = double.MaxValue, sMaxY = double.MinValue;
            GeoRectangle sFullExtent;
            //（2）如果图层数量为0，则返回空矩形
            Int32 sLayerCount = _Layers.Count;
            if (sLayerCount == 0)
            {
                sFullExtent = new GeoRectangle(sMinX, sMaxX, sMinY, sMaxY);
                return sFullExtent;
            }
            //（3）计算范围矩形
            for (Int32 i = 0; i <= sLayerCount - 1; i++)
            {
                GeoMapLayer sLayer = _Layers.GetItem(i);
                GeoRectangle sExtent = sLayer.Extent;
                if (sExtent.IsEmpty == false)
                {
                    if (sExtent.MinX < sMinX)
                        sMinX = sExtent.MinX;
                    if (sExtent.MaxX > sMaxX)
                        sMaxX = sExtent.MaxX;
                    if (sExtent.MinY < sMinY)
                        sMinY = sExtent.MinY;
                    if (sExtent.MaxY > sMaxY)
                        sMaxY = sExtent.MaxY;
                }
            }
            sFullExtent = new GeoRectangle(sMinX, sMaxX, sMinY, sMaxY);
            return sFullExtent;
        }

        /// <summary>
        ///  在窗口内显示地图全部范围
        /// </summary>
        public void FullExtent()
        {
            GeoRectangle sFullExtent = GetFullExtent();
            if (!sFullExtent.IsEmpty)
            {
                Rectangle sClientRect = ClientRectangle;
                mMapDrawingReference.ZoomExtentToWindow(sFullExtent, sClientRect.Width, sClientRect.Height);
                UseWaitCursor = true;
                DrawBufferMap1();
                DrawBufferMap2();
                UseWaitCursor = false;
                Refresh();

                // 触发事件
                if (MapScaleChanged != null)
                {
                    MapScaleChanged(this);
                }
            }
        }
        /// <summary>
        /// 以指定中心和系数对地图进行缩放
        /// </summary>
        /// <param name="center"></param>
        /// <param name="ratio"></param>
        public void ZoomByCenter(GeoPoint center, double ratio)
        {
            mMapDrawingReference.ZoomByCenter(center, ratio);
            this.UseWaitCursor = true;
            DrawBufferMap1();
            DrawBufferMap2();
            this.UseWaitCursor = false;
            Refresh();
            //触发事件
            if (MapScaleChanged != null)
                MapScaleChanged(this);
        }

        /// <summary>
        /// 在窗口内显示指定范围
        /// </summary>
        /// <param name="extent"></param>
        public void ZoomToExtent(GeoRectangle extent)
        {
            double sWindowWidth = this.ClientRectangle.Width;
            double sWindowHeight = this.ClientRectangle.Height;
            mMapDrawingReference.ZoomExtentToWindow(extent, sWindowWidth, sWindowHeight);
            this.UseWaitCursor = true;
            DrawBufferMap1();
            DrawBufferMap2();
            this.UseWaitCursor = false;
            Refresh();
            //触发事件
            if (MapScaleChanged != null)
                MapScaleChanged(this);
        }

        /// <summary>
        /// 将地图平移指定量
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public void PanDelta(double deltaX, double deltaY)
        {
            mMapDrawingReference.PanDelta(deltaX, deltaY);
            this.UseWaitCursor = true;
            DrawBufferMap1();
            DrawBufferMap2();
            this.UseWaitCursor = false;
            Refresh();
        }

        /// <summary>
        /// 将屏幕坐标转化为地理坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GeoPoint ToMapPoint(double x, double y)
        {
            return mMapDrawingReference.ToMapPoint(x, y);
        }
        /// <summary>
        /// 地理坐标到屏幕坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GeoPoint FromMapPoint(double x, double y)
        {
            return mMapDrawingReference.FromMapPoint(x, y);
        }

        /// <summary>
        /// 将屏幕距离转化为地理距离
        /// </summary>
        /// <param name="dis"></param>
        /// <returns></returns>
        public double ToMapDistance(double dis)
        {
            return mMapDrawingReference.ToMapDistance(dis);
        }

        /// <summary>
        /// 地理距离到屏幕距离
        /// </summary>
        /// <param name="dis"></param>
        /// <returns></returns>
        public double FromMapDistance(double dis)
        {
            return mMapDrawingReference.FromMapDistance(dis);
        }

        /// <summary>
        /// 重新绘制地图
        /// </summary>
        public void RedrawMap()
        {
            UseWaitCursor = true;
            DrawBufferMap1();
            DrawBufferMap2();
            UseWaitCursor = false;
            Refresh();
        }
        /// <summary>
        /// 重新绘制跟踪图形(不需要绘制
        /// </summary>
        public void RedrawTrackingShapes()
        {
            UseWaitCursor = true;
            DrawBufferMap2();
            UseWaitCursor = false;
            Refresh();
        }

        /// <summary>
        /// 将地图图像移动到指定位置（屏幕坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PanMapImageTo(float x, float y)
        {
            Graphics g = Graphics.FromImage(mBufferMap3);
            g.Clear(Color.White);
            g.DrawImage(mBufferMap2, x, y);
            g = Graphics.FromHwnd(Handle);
            g.DrawImage(mBufferMap3, 0, 0);
            g.Dispose();
        }

        /// <summary>
        /// 对指定图形数组,以指定的次数和时间间隔进行闪烁显示
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="times"></param>
        /// <param name="interval"></param>
        public void FlashShapes(GeoShape[] shapes, Int32 times, Int32 interval)
        {
            mFlashControler.StartFlash(shapes, times, interval);
        }
        /// <summary>
        /// 获取绘图工具: 用户可能会绘制非持久图形(用户拉一个框)和持久图形
        /// </summary>
        /// <returns></returns>
        public GeoUserDrawingTool GetDrawingTool()
        {
            Graphics g = Graphics.FromHwnd(Handle);
            GeoUserDrawingTool sUserDrawingTool = CreateDrawingTool(g);
            return sUserDrawingTool;
        }

        /// <summary>
        /// 根据制定的选择盒与选择方法执行选择,对所有图层实现选择操作
        /// </summary>
        /// <param name="selectingBox"></param>
        /// <param name="talerance"></param>
        /// <param name="selectMethod"></param>
        public void SelectByBox(GeoRectangle selectingBox, double tolerance, Int32 selectMethod)
        {
            Int32 sLayerCount = _Layers.Count;
            for (Int32 i = 0; i < sLayerCount; i++)
            {
                GeoMapLayer sLayer = _Layers.GetItem(i);
                if (sLayer.Visible && sLayer.Selectable)
                {
                    GeoFeatures sFeatures = sLayer.SearchByBox(selectingBox, tolerance);
                    sLayer.ExecuteSelect(sFeatures, selectMethod);
                }
                else
                {
                    sLayer.SelectedFeatures.Clear();
                }
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 地图比例尺发生了变化
        /// </summary>
        /// <param name="sender"></param>
        public delegate void MapScaleChangedHandle(object sender);
        public event MapScaleChangedHandle MapScaleChanged;

        /// <summary>
        /// 跟踪图形绘制完毕(便于用户侦听到事件之后继续让控件绘制图形)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="drawTool"></param>
        public delegate void AfterTrackingLayerDrawHandle(object sender, GeoUserDrawingTool drawTool);
        public event AfterTrackingLayerDrawHandle AfterTrackingLayerDraw;
        #endregion

        #region 私有函数

        //创建地图-屏幕坐标转换对象
        private void CreateMapDrawingReference()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            double dpm = g.DpiX / 0.0254;
            g.Dispose();
            double mpu = 1.0;
            mMapDrawingReference = new GeoMapDrawingReference(0, 0, 1000000, dpm, mpu);
        }


        //调整缓冲位图大小
        private void ResizeBufferMap()
        {
            Rectangle sClientRectangle = this.ClientRectangle;
            if (sClientRectangle.Width > 0 && sClientRectangle.Height > 0 )
            {
                if (sClientRectangle.Width != mBufferMap1.Width || sClientRectangle.Height != mBufferMap1.Height)
                {
                    mBufferMap1 = new Bitmap(sClientRectangle.Width, sClientRectangle.Height);
                    mBufferMap2 = new Bitmap(sClientRectangle.Width, sClientRectangle.Height);
                    mBufferMap3 = new Bitmap(sClientRectangle.Width, sClientRectangle.Height);
                }
            }
        }

        //初始化符号
        private void InitializeSymbols()
        {
            //选择点符号
            mSelectedPointSymbol = new GeoSimpleMarkerSymbol();
            mSelectedPointSymbol.Color = _SelectionColor;
            mSelectedPointSymbol.Size = 3;
            //选择线符号
            mSelectedLineSymbol = new GeoSimpleLineSymbol();
            mSelectedLineSymbol.Color = _SelectionColor;
            mSelectedLineSymbol.Size = 3000 / mMapDrawingReference.dpm;
            //选择面符号
            mSelectedFillSymbol = new GeoSimpleFillSymbol();
            mSelectedFillSymbol.Color = Color.Transparent;
            mSelectedFillSymbol.Outline.Color = _SelectionColor;
            mSelectedFillSymbol.Outline.Size = 3000 / mMapDrawingReference.dpm;
            //闪烁点符号
            mFlashPointSymbol = new GeoSimpleMarkerSymbol();
            mFlashPointSymbol.Color = _FlashColor;
            mFlashPointSymbol.Style = GeoSimpleMarkerSymbolStyleConstant.SolidCircle;
            mFlashPointSymbol.Size = 3;
            //闪烁线符号
            mFlashLineSymbol = new GeoSimpleLineSymbol();
            mFlashLineSymbol.Color = _FlashColor;
            mFlashLineSymbol.Size = 1.5;
            //闪烁面符号
            mFlashFillSymbol = new GeoSimpleFillSymbol();
            mFlashFillSymbol.Color = _FlashColor;
            mFlashFillSymbol.Outline.Color = Color.Black;
            mFlashFillSymbol.Outline.Size = 0.35;
        }

        //绘制缓冲位图1
        private void DrawBufferMap1()
        {
            //（1）获取地图窗口的范围
            GeoRectangle sExtent = GetExtent();
            if (sExtent.IsEmpty == true)
                return;
            //（2）绘制所有图层的要素，采用倒序
            double sMapScale = mMapDrawingReference.MapScale;
            double dpm = mMapDrawingReference.dpm;
            double mpu = mMapDrawingReference.mpu;
            Graphics g = Graphics.FromImage(mBufferMap1);
            g.Clear(Color.White);
            Int32 sLayerCount = _Layers.Count;
            for (Int32 i = sLayerCount - 1; i >= 0; i--)
            {
                GeoMapLayer sLayer = _Layers.GetItem(i);
                if (sLayer.Visible == true)
                {
                    sLayer.DrawFeatures(g, sExtent, sMapScale, dpm, mpu);
                }
            }
            //（3）绘制所有图层的注记，依然倒序
            List<RectangleF> sPlacedLabelExtents = new List<RectangleF>();
            for (Int32 i = sLayerCount - 1; i >= 0; i--)
            {
                GeoMapLayer sLayer = _Layers.GetItem(i);
                if (sLayer.Visible == true)
                {
                    sLayer.DrawLabels(g, sExtent, sMapScale, dpm, mpu, sPlacedLabelExtents);
                }
            }
            g.Dispose();
        }

        private void DrawBufferMap2()
        {
            //（1）获取地图窗口的范围
            GeoRectangle sExtent = GetExtent();
            if (sExtent.IsEmpty == true)
                return;
            //（2）绘制缓冲位图1
            Graphics g = Graphics.FromImage(mBufferMap2);
            g.Clear(Color.White);
            Rectangle sRect = new Rectangle(0, 0, mBufferMap1.Width, mBufferMap1.Height);
            g.DrawImage(mBufferMap1, sRect, sRect, GraphicsUnit.Pixel);
            //（3）绘制所有图层的选择要素，采用倒序
            double sMapScale = mMapDrawingReference.MapScale;
            double dpm = mMapDrawingReference.dpm;
            double mpu = mMapDrawingReference.mpu;
            Int32 sLayerCount = _Layers.Count;
            for (Int32 i = sLayerCount - 1; i >= 0; i--)
            {
                GeoMapLayer sLayer = _Layers.GetItem(i);
                if (sLayer.ShapeType == GeoGeometryTypeConstant.Point)
                {
                    sLayer.DrawSelectedFeatures(g, sExtent, sMapScale, dpm, mpu, mSelectedPointSymbol);
                }
                else if (sLayer.ShapeType == GeoGeometryTypeConstant.MultiPolyline)
                {
                    sLayer.DrawSelectedFeatures(g, sExtent, sMapScale, dpm, mpu, mSelectedLineSymbol);
                }
                else if (sLayer.ShapeType == GeoGeometryTypeConstant.MultiPolygon)
                {
                    sLayer.DrawSelectedFeatures(g, sExtent, sMapScale, dpm, mpu, mSelectedFillSymbol);
                }
            }
            //（4）触发事件，以便用户程序继续绘图
            if (AfterTrackingLayerDraw != null)
            {
                //新建绘图工具
                GeoUserDrawingTool sDrawingTool = CreateDrawingTool(g);
                AfterTrackingLayerDraw(this, sDrawingTool);
            }
            g.Dispose();
        }



        private GeoUserDrawingTool CreateDrawingTool(Graphics g)
        {
            GeoRectangle sExtent = GetExtent();
            double sMapScale = mMapDrawingReference.MapScale;
            double dpm = mMapDrawingReference.dpm;
            double mpu = mMapDrawingReference.mpu;
            GeoUserDrawingTool geoDrawingTool = new GeoUserDrawingTool(g, sExtent, sMapScale, dpm, mpu);
            return geoDrawingTool;
        }

        #endregion

        #region 母版和对象事件处理
        private void GeoMapControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(mBufferMap2, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 调整三个内存位图的大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeoMapControl_Resize(object sender, EventArgs e)
        {
            ResizeBufferMap();
            RedrawMap();
        }

        private void MFlashControler_NeedClearFlashShapes(object sender)
        {
            RedrawTrackingShapes();
        }

        private void MFlashControler_NeedDrawFlashShapes(object sender, GeoShape[] shapes)
        {
            double sMapScale = mMapDrawingReference.MapScale;
            double dpm = mMapDrawingReference.dpm;
            double mpu = mMapDrawingReference.mpu;
            GeoRectangle sExtent = GetExtent();
            Graphics g = Graphics.FromImage(mBufferMap2);
            Int32 sShapeCount = shapes.Length;
            for (Int32 i = 0; i <= sShapeCount - 1; i++)
            {
                if (shapes[i].GetType() == typeof(GeoPoint))
                {
                    GeoPoint sPoint = (GeoPoint)shapes[i];
                    GeoMapDrawingTools.DrawPoint(g, sExtent, sMapScale, dpm, mpu, sPoint, mFlashPointSymbol);
                }
                else if (shapes[i].GetType() == typeof(GeoPoints))
                {
                    GeoPoints sPoints = (GeoPoints)shapes[i];
                    GeoMapDrawingTools.DrawPoints(g, sExtent, sMapScale, dpm, mpu, sPoints, mFlashPointSymbol);
                }
                else if (shapes[i].GetType() == typeof(GeoRectangle))
                {
                    GeoRectangle sRect = (GeoRectangle)shapes[i];
                    GeoMapDrawingTools.DrawRectangle(g, sExtent, sMapScale, dpm, mpu, sRect, mFlashFillSymbol);
                }
                else if (shapes[i].GetType() == typeof(GeoMultiPolyline))
                {
                    GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)shapes[i];
                    GeoMapDrawingTools.DrawMultiPolyline(g, sExtent, sMapScale, dpm, mpu, sMultiPolyline, mFlashLineSymbol);
                }
                else if (shapes[i].GetType() == typeof(GeoMultiPolygon))
                {
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)shapes[i];
                    GeoMapDrawingTools.DrawMultiPolygon(g, sExtent, sMapScale, dpm, mpu, sMultiPolygon, mFlashFillSymbol);
                }
            }
            g.Dispose();
            Refresh();
        }


        #endregion

    }
}
