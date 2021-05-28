using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    public class GeoRectangle : GeoShape
    {
        #region 字段
        private double _MinX, _MinY, _MaxX, _MaxY;
        #endregion

        #region 构造函数
        public GeoRectangle()
        {

        }
        public GeoRectangle(double minX, double maxX, double minY, double maxY)
        {
            _MaxX = maxX;
            _MaxY = maxY;
            _MinX = minX;
            _MinY = minY;
        }
        public GeoRectangle(GeoRectangle r)
        {
            _MaxX = r.MaxX;
            _MaxY = r.MaxY;
            _MinX = r.MinX;
            _MinY = r.MinY;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取最小X
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }
        /// <summary>
        /// 获取最小Y
        /// </summary>
        public double MinY
        {
            get { return _MinY; }
        }
        /// <summary>
        /// 获取最大X
        /// </summary>
        public double MaxX
        {
            get { return _MaxX; }
        }
        /// <summary>
        /// 获取最大Y
        /// </summary>
        public double MaxY
        {
            get { return _MaxY; }
        }
        /// <summary>
        /// 获取宽度
        /// </summary>
        public double Width
        {
            get { return _MaxX - _MinX; }
        }

        /// <summary>
        /// 获取高度
        /// </summary>
        public double Height
        {
            get { return _MaxY - _MinY; }
        }
        /// <summary>
        /// 指示是否为空矩形
        /// </summary>
        public bool IsEmpty 
        {
            get 
            {
                bool flag = false;
                if (_MaxX <= _MinX)
                    flag = true;
                if (_MaxY <= _MinY)
                    flag = true;
                return flag;
            }
        }
        #endregion
        
        #region 方法

        #endregion
    }
}
