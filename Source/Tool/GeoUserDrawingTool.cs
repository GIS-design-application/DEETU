using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DEETU.Geometry;
using DEETU.Core;
using DEETU.Map;

namespace DEETU.Tool
{
    /// <summary>
    /// 用户绘图
    /// </summary>
    public class GeoUserDrawingTool
    {
        #region 字段
        private Graphics _MyGraphics;               //绘图对象
        private GeoRectangle _Extent;              //绘图区域左上点（0，0）对应的投影坐标系中的点，即投影坐标系相对屏幕坐标系的平移量
        private double _MapScale = 10000;               //比例尺的倒数
        private double _dpm = 96 / 0.0254;              //屏幕上每米代表的象素数
        private double _mpu = 1.0;                      //1个地图坐标单位代表的米数，一般为1.
        #endregion

        #region 构造函数

        internal GeoUserDrawingTool(Graphics graphics, GeoRectangle extent, double mapScale, double dpm, double mpu)
        {
            _MyGraphics = graphics;
            _Extent = extent;
            _MapScale = mapScale;
            _dpm = dpm;
            _mpu = mpu;
        }

        #endregion

        #region 属性

        internal Graphics MyGraphics
        {
            get { return _MyGraphics; }
            set { _MyGraphics = value; }
        }

        internal GeoRectangle Extent
        {
            get { return _Extent; }
            set { _Extent = value; }
        }

        internal double MapScale
        {
            get { return _MapScale; }
        }

        internal double dpm
        {
            get { return _dpm; }
        }

        internal double mpu
        {
            get { return _mpu; }
        }

        #endregion

        #region 方法


        /// <summary>
        /// 以指定符号绘制指定点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="symbol"></param>
        public void DrawPoint(GeoPoint point, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawPoint(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, point, symbol);
        }

        /// <summary>
        /// 以指定符号绘制指定点集合
        /// </summary>
        /// <param name="points"></param>
        /// <param name="symbol"></param>
        public void DrawPoints(GeoPoints points, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawPoints(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, points, symbol);
        }

        /// <summary>
        /// 以指定符号绘制指定矩形
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="symbol"></param>
        public void DrawRectangle(GeoRectangle rectangle, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawRectangle(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, rectangle, symbol);
        }

        /// <summary>
        /// 以指定符号绘制指定线段
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="symbol"></param>
        public void DrawLine(GeoPoint point1, GeoPoint point2, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawLine(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, point1, point2, symbol);
        }

        /// <summary>
        /// 以指定符号绘制指定折线
        /// </summary>
        /// <param name="points"></param>
        /// <param name="symbol"></param>
        public void DrawPolyline(GeoPoints points, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawPolyline(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, points, symbol);
        }

        /// <summary>
        /// 以指定符号绘制指定多边形
        /// </summary>
        /// <param name="points"></param>
        /// <param name="symbol"></param>
        public void DrawPolygon(GeoPoints points, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawPolygon(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, points, symbol);
        }

        /// <summary>
        /// 以指定符号绘制指定复合折线
        /// </summary>
        /// <param name="multiPolyline"></param>
        /// <param name="symbol"></param>
        public void DrawMultiPolyline(GeoMultiPolyline multiPolyline, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawMultiPolyline(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, multiPolyline, symbol);
        }

        /// <summary>
        /// 以指定符号绘制指定复合多边形
        /// </summary>
        /// <param name="multiPolygon"></param>
        /// <param name="symbol"></param>
        public void DrawMultiPolygon(GeoMultiPolygon multiPolygon, GeoSymbol symbol)
        {
            GeoMapDrawingTools.DrawMultiPolygon(_MyGraphics, _Extent, _MapScale, _dpm, _mpu, multiPolygon, symbol);
        }

        #endregion
    }
}
