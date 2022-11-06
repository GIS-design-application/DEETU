using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU;
using DEETU.Geometry;

namespace DEETU.Map
{
    /// <summary>
    /// 实现地图坐标与屏幕坐标转换的类型
    /// </summary>
    internal class GeoMapDrawingReference
    {
        #region 字段
        private double _OffsetX, _OffsetY;              //绘图区域左上点（0，0）对应的投影坐标系中的点，即投影坐标系相对屏幕坐标系的平移量
        private double _MapScale = 10000;               //比例尺的倒数
        private double _dpm = 96 / 0.0254;              //屏幕上每米代表的象素数
        private double _mpu = 1.0;                      //1个地图坐标单位代表的米数，一般为1.

        private const double mcMaxMapScale = 1000000000000;    //地图显示比例尺倒数的最大值,100亿
        private const double mcMinMapScale = 10;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="offsetX">绘图区域左上点在地图坐标系中的X坐标</param>
        /// <param name="offsetY">绘图区域左上点在地图坐标系中的Y坐标</param>
        /// <param name="mapScale">地图比例尺的倒数</param>
        /// <param name="dpm">每米代表的象素数</param>
        /// <param name="mpu">1个地图坐标单位代表的米数</param>
        internal GeoMapDrawingReference(double offsetX, double offsetY, double mapScale, double dpm, double mpu)
        {
            _OffsetX = offsetX;
            _OffsetY = offsetY;
            _MapScale = mapScale;
            _dpm = dpm;
            _mpu = mpu;
        }

        #endregion

        #region 属性

        internal double OffsetX
        {
            get { return _OffsetX; }
        }

        internal double OffsetY
        {
            get { return _OffsetY; }
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

        //以指定中心和指定系数进行缩放
        internal void ZoomByCenter(GeoPoint center, double ratio)
        {
            double sMapScale = _MapScale / ratio;      //新的比例尺

            if (sMapScale > mcMaxMapScale)
                sMapScale = mcMaxMapScale;
            else if (sMapScale < mcMinMapScale)
                sMapScale = mcMinMapScale;
            double sRatio = _MapScale / sMapScale;      //实际的缩放系数
            double sOffsetX = _OffsetX + (1 - 1 / sRatio) * (center.X - _OffsetX);
            double sOffsetY = _OffsetY + (1 - 1 / sRatio) * (center.Y - _OffsetY);
            _OffsetX = sOffsetX;
            _OffsetY = sOffsetY;
            _MapScale = sMapScale;
        }

        //将指定范围缩放至指定大小的屏幕窗口
        internal void ZoomExtentToWindow(GeoRectangle rect, double windowWidth, double windowHeight)
        {
            double sRectWidth = rect.Width, sRectHeight = rect.Height;
            double sMapRatio, sWindowRatio;
            double sViewWidth, sViewHeight;
            if (sRectWidth < 0 || sRectHeight < 0 || windowWidth < 0 || windowHeight < 0)
                return;
            else if (sRectHeight == 0 && windowHeight == 0)
                return;
            else if (sRectHeight > 0 && windowHeight == 0)
            {
                sMapRatio = sRectWidth / sRectHeight;
                //按照垂向充满窗体
                sViewWidth = sMapRatio * windowHeight;
                sViewHeight = windowHeight;
                _MapScale = sRectHeight * _mpu / windowHeight * _dpm;
                _OffsetX = rect.MinX - (windowWidth - sViewWidth) / 2 * sRectHeight / windowHeight;
                _OffsetY = rect.MaxY;
                return;
            }
            else if (sRectHeight == 0 && windowHeight > 0)
            {
                //按照横向充满窗体
                sViewWidth = windowWidth;
                sViewHeight = 0;
                _MapScale = sRectWidth * _mpu / windowWidth * _dpm;
                _OffsetX = rect.MinX;
                _OffsetY = rect.MaxY + (windowHeight - sViewHeight) / 2 * sRectWidth / windowWidth;
                return;
            }
            else
            {
                //计算宽高比例
                sMapRatio = sRectWidth / sRectHeight;
                sWindowRatio = windowWidth / windowHeight;
                //计算显示参数
                if (sMapRatio <= sWindowRatio)
                {
                    //按照垂向充满窗体
                    sViewWidth = sMapRatio * windowHeight;
                    sViewHeight = windowHeight;
                    _MapScale = sRectHeight * _mpu / windowHeight * _dpm;
                    _OffsetX = rect.MinX - (windowWidth - sViewWidth) / 2 * sRectHeight / windowHeight;
                    _OffsetY = rect.MaxY;
                }
                else
                {
                    //按照横向充满窗体
                    sViewWidth = windowWidth;
                    sViewHeight = windowWidth / sMapRatio;
                    _MapScale = sRectWidth * _mpu / windowWidth * _dpm;
                    _OffsetX = rect.MinX;
                    _OffsetY = rect.MaxY + (windowHeight - sViewHeight) / 2 * sRectWidth / windowWidth;
                }
                return;
            }
        }

        //将地图平移指定量
        internal void PanDelta(double deltaX, double deltaY)
        {
            _OffsetX = _OffsetX - deltaX;
            _OffsetY = _OffsetY - deltaY;
        }

        //将屏幕坐标转换为地图坐标
        internal GeoPoint ToMapPoint(double x, double y)
        {
            double sX = x / _dpm / _mpu * _MapScale + _OffsetX;
            double sY = _OffsetY - y / _dpm / _mpu * _MapScale;
            GeoPoint sPoint = new GeoPoint(sX, sY);
            return sPoint;
        }

        //将地图坐标转换为屏幕坐标
        internal GeoPoint FromMapPoint(double x, double y)
        {
            double sX = (x - _OffsetX) / _MapScale * _dpm * _mpu;
            double sY = (_OffsetY - y) / _MapScale * _dpm * _mpu;
            GeoPoint sPoint = new GeoPoint(sX, sY);
            return sPoint;
        }

        //将屏幕距离转换为地图距离
        internal double ToMapDistance(double dis)
        {
            double sDis = dis * _MapScale / _mpu / _dpm;
            return sDis;
        }

        //将地图距离转换为屏幕距离
        internal double FromMapDistance(double dis)
        {
            double sDis = dis / _MapScale * _dpm * _mpu;
            return sDis;
        }
        #endregion
    }
}
