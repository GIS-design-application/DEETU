using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    /// <summary>
    /// 点
    /// </summary>
    [Serializable]
    public class GeoPoint : GeoGeometry
    {
        #region 字段
        private double _X;
        private double _Y;
        #endregion

        #region 构造函数
        public GeoPoint(double x, double y)
        {
            this._X = x;
            this._Y = y;
        }
        public GeoPoint(GeoPoint p)
        {
            _X = p.X;
            _Y = p.Y;
        }
        public GeoPoint() { }
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置X坐标
        /// </summary>
        public double X
        {
            get { return _X; }
            set { _X = value; }
        }

        /// <summary>
        /// 获取或设置Y坐标
        /// </summary>
        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        override public GeoGeometry Clone()
        {
            return new GeoPoint(this);
        }
        #endregion
    }
}
