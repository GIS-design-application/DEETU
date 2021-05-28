using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    public class GeoPoints : GeoShape
    {
        #region 字段
        
        private List<GeoPoint> _Points;
        private double _MinX = double.MaxValue, _MinY = double.MaxValue, _MaxX = double.MinValue, _MaxY = double.MaxValue;

        #endregion

        #region 构造函数
        public GeoPoints()
        {
            _Points = new List<GeoPoint>();
        }
        public GeoPoints(List<GeoPoint> ps)
        {
            _Points = new List<GeoPoint>();
            _Points.AddRange(ps);
        }
        public GeoPoints(GeoPoints points)
        {

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
        public int Count
        {
            get { return _Points.Count(); }
        }


        #endregion

        #region 方法
        /// <summary>
        /// 获取指定索引号的元素
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns></returns>
        public GeoPoint GetItem(int index)
        {
            return _Points[index];
        }
        /// <summary>
        /// 添加一个点到末尾
        /// </summary>
        /// <param name="point">拟添加的点</param>
        public void Add(GeoPoint point)
        {
            _Points.Add(point);
        }
        /// <summary>
        /// 添加一组点到末尾
        /// </summary>
        /// <param name="points">拟添加的一组点</param>
        public void AddRange(GeoPoint[] points)
        {
            _Points.AddRange(points);
        }
        /// <summary>
        /// 将制定数组中的元素插入到指定位置
        /// </summary>
        /// <param name="index">指定位置</param>
        /// <param name="points">数组</param>
        public void InsertRange(int index, GeoPoint[] points)
        {
            _Points.InsertRange(index, points);
        }
        /// <summary>
        /// 将制定元素插入到指定位置
        /// </summary>
        /// <param name="index">指定位置</param>
        /// <param name="point">指定元素</param>
        public void Insert(int index, GeoPoint point)
        {
            _Points.Insert(index, point);
        }
        /// <summary>
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="index">指定位置</param>
        public void RemoveAt(int index)
        {
            _Points.RemoveAt(index);
        }
        /// <summary>
        /// 将所有元素复制到一个数组中，并返回
        /// </summary>
        /// <returns></returns>
        public GeoPoint[] ToArray()
        {
            return _Points.ToArray();
        }
        /// <summary>
        /// 删除所有元素
        /// </summary>
        public void Clear()
        {
            _Points.Clear();
        }

        /// <summary>
        /// 获取外包矩性
        /// </summary>
        /// <returns></returns>
        public GeoRectangle GetEnvelope()
        {
            return new GeoRectangle(_MinX, _MaxX, _MinY, _MaxY);
        }
        /// <summary>
        /// 重新计算坐标范围
        /// </summary>
        public void UpdateExtent()
        {
            CalExtent();
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            GeoPoints sPoints = new GeoPoints();
            Int32 sPointCount = _Points.Count;
            for (Int32 i = 0; i <= sPointCount - 1; i++)
            {
                GeoPoint sPoint = new GeoPoint(_Points[i].X, _Points[i].Y);
                sPoints.Add(sPoint);
            }
            sPoints._MinX = _MinX;
            sPoints._MaxX = _MaxX;
            sPoints._MinY = _MinY;
            sPoints._MaxY = _MaxY;
            return sPoints;
        }

        #endregion

        #region 私有函数
        /// <summary>
        /// 计算范围
        /// </summary>
        private void CalExtent()
        {
            double sMinX = double.MaxValue;
            double sMaxX = double.MinValue;
            double sMinY = double.MaxValue;
            double sMaxY = double.MinValue;
            Int32 sPointCount = _Points.Count;
            for (Int32 i = 0; i <= sPointCount - 1; i++)
            {
                if (_Points[i].X < sMinX)
                    sMinX = _Points[i].X;
                if (_Points[i].X > sMaxX)
                    sMaxX = _Points[i].X;
                if (_Points[i].Y < sMinY)
                    sMinY = _Points[i].Y;
                if (_Points[i].Y > sMaxY)
                    sMaxY = _Points[i].Y;
            }
            _MinX = sMinX;
            _MaxX = sMaxX;
            _MinY = sMinY;
            _MaxY = sMaxY;
        }
        #endregion
    }
}
