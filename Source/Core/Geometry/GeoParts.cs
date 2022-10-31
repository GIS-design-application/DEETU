using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    /// <summary>
    /// 部分的类
    /// </summary>
    [Serializable]
    public class GeoParts: GeoShape
    {
        #region 字段
        private List<GeoPoints> _Parts;
        #endregion

        #region 构造函数
        public GeoParts()
        {
            _Parts = new List<GeoPoints>();
        }
        public GeoParts(GeoPoints[] parts)
        {
            _Parts = new List<GeoPoints>();
            _Parts.AddRange(parts);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取部分的数量
        /// </summary>
        public int Count
        {
            get { return _Parts.Count; }
        }
        public List<GeoPoints> Parts
        {
            get { return _Parts; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的元素
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns></returns>
        public GeoPoints GetItem(int index)
        {
            return _Parts[index];
        }
        /// <summary>
        /// 添加一个点到末尾
        /// </summary>
        /// <param name="point">拟添加的点</param>
        public void Add(GeoPoints part)
        {
            _Parts.Add(part);
        }
        /// <summary>
        /// 添加一组点到末尾
        /// </summary>
        /// <param name="points">拟添加的一组点</param>
        public void AddRange(GeoPoints[] parts)
        {
            _Parts.AddRange(parts);
        }
        /// <summary>
        /// 将制定数组中的元素插入到指定位置
        /// </summary>
        /// <param name="index">指定位置</param>
        /// <param name="points">数组</param>
        public void InsertRange(int index, GeoPoints[] parts)
        {
            _Parts.InsertRange(index, parts);
        }
        /// <summary>
        /// 将制定元素插入到指定位置
        /// </summary>
        /// <param name="index">指定位置</param>
        /// <param name="point">指定元素</param>
        public void Insert(int index, GeoPoints part)
        {
            _Parts.Insert(index, part);
        }
        /// <summary>
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="index">指定位置</param>
        public void RemoveAt(int index)
        {
            _Parts.RemoveAt(index);
        }
        /// <summary>
        /// 将所有元素复制到一个数组中，并返回
        /// </summary>
        /// <returns></returns>
        public GeoPoints[] ToArray()
        {
            return _Parts.ToArray();
        }
        /// <summary>
        /// 删除所有元素
        /// </summary>
        public void Clear()
        {
            _Parts.Clear();
        }
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        override public object Clone()
        {
            GeoParts sParts = new GeoParts();
            Int32 sPartCount = _Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                GeoPoints sPart = _Parts[i].Clone() as GeoPoints;
                sParts.Add(sPart);
            }
            return sParts;
        }


        #endregion
    }
}
