/*****************************************
 * @file: GeoFeatures 
 * @author:dhd
 * @date:2021-04-28
 * @description：Feature Collection, 处理要素类中要素的增加删除和修改
 * 
 * 
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DEETU.Geometry;
using System.Data;

namespace DEETU.Core
{
    /// <summary>
    /// 要素集合类型
    /// </summary>
    public class GeoFeatures
    {
        #region 字段
        private List<GeoFeature> _Features;
        #endregion

        #region 构造函数

        public GeoFeatures()
        {
            _Features = new List<GeoFeature>();
        }

        #endregion

        #region 属性
        /// <summary>
        /// 获取要素个数
        /// </summary>
        public int Count
        {
            get { return _Features.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的要素
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns></returns>
        public GeoFeature GetItem(int index)
        {
            return _Features[index];
        }

        /// <summary>
        /// 设置要素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="feature"></param>
        public void SetItem(int index, GeoFeature feature)
        {
            _Features[index] = feature;
        }

        /// <summary>
        /// 删除指定要素
        /// </summary>
        /// <param name="feature"></param>
        public void Remove(GeoFeature feature)
        {
            _Features.Remove(feature);
        }


        /// <summary>
        /// 添加一个点到末尾
        /// </summary>
        /// <param name="point">拟添加的点</param>
        public void Add(GeoFeature feature)
        {
            _Features.Add(feature);
        }

        /// <summary>
        /// 添加一组点到末尾
        /// </summary>
        /// <param name="points">拟添加的一组点</param>
        public void AddRange(GeoFeature[] features)
        {
            _Features.AddRange(features);
        }

        /// <summary>
        /// 将制定数组中的要素插入到指定位置
        /// </summary>
        /// <param name="index">指定位置</param>
        /// <param name="points">数组</param>
        public void InsertRange(int index, GeoFeature[] features)
        {
            _Features.InsertRange(index, features);
        }

        /// <summary>
        /// 将制定要素插入到指定位置
        /// </summary>
        /// <param name="index">指定位置</param>
        /// <param name="point">指定要素</param>
        public void Insert(int index, GeoFeature feature)
        {
            _Features.Insert(index, feature);
        }

        /// <summary>
        /// 删除指定位置的要素
        /// </summary>
        /// <param name="index">指定位置</param>
        public void RemoveAt(int index)
        {
            _Features.RemoveAt(index);
        }

        /// <summary>
        /// 将所有要素复制到一个数组中，并返回
        /// </summary>
        /// <returns></returns>
        public GeoFeature[] ToArray()
        {
            return _Features.ToArray();
        }

        /// <summary>
        /// 删除所有要素
        /// </summary>
        public void Clear()
        {
            _Features.Clear();
        }

        #endregion
    }
}