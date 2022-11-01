using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    [Serializable]
    public class GeoMultiPolyline : GeoGeometry
    {
        #region 字段

        private GeoParts _Parts;
        double _MinX = double.MaxValue, _MaxX = double.MinValue;
        double _MinY = double.MaxValue, _MaxY = double.MinValue;

        #endregion

        #region 构造函数

        public GeoMultiPolyline()
        {
            _Parts = new GeoParts();
        }

        public GeoMultiPolyline(GeoPoints points)
        {
            _Parts = new GeoParts();
            _Parts.Add(points);
        }

        public GeoMultiPolyline(GeoParts parts)
        {
            _Parts = parts;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置部分集合
        /// </summary>
        public GeoParts Parts
        {
            get { return _Parts; }
            set { _Parts = value; }
        }

        /// <summary>
        /// 获取最小X坐标
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }

        /// <summary>
        /// 获取最大X坐标
        /// </summary>
        public double MaxX
        {
            get { return _MaxX; }
        }

        /// <summary>
        /// 获取最小Y坐标
        /// </summary>
        public double MinY
        {
            get { return _MinY; }
        }

        /// <summary>
        /// 获取最大Y坐标
        /// </summary>
        public double MaxY
        {
            get { return _MaxY; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取外包矩形
        /// </summary>
        /// <returns></returns>
        public GeoRectangle GetEnvelope()
        {
            GeoRectangle sRectangle = new GeoRectangle(_MinX, _MaxX, _MinY, _MaxY);
            return sRectangle;
        }

        /// <summary>
        /// 重新计算坐标范围
        /// </summary>
        public override void UpdateExtent()
        {
            CalExtent();
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        override public GeoGeometry Clone()
        {
            GeoMultiPolyline sMultiPolyline = new GeoMultiPolyline();
            sMultiPolyline.Parts = _Parts.Clone() as GeoParts;
            sMultiPolyline._MinX = _MinX;
            sMultiPolyline._MaxX = _MaxX;
            sMultiPolyline._MinY = _MinY;
            sMultiPolyline._MaxY = _MaxY;
            return sMultiPolyline;
        }

        #endregion

        #region 私有函数

        //计算坐标范围
        private void CalExtent()
        {
            _Parts.CalExtent();
            _MinX = _Parts.MinX;
            _MaxX = _Parts.MaxX;
            _MinY = _Parts.MinY;
            _MaxY = _Parts.MaxY;
        }

        #endregion
    }
}
