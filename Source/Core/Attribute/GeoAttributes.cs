using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Core

{
    /// <summary>
    /// 属性集合类
    /// </summary>
    public class GeoAttributes
    {
        #region 字段
        // 这里使用object有点不得劲，可以自己设计一个AttributeValue的类（考虑课时课堂就不做的）
        private List<object> _Attributes;

        #endregion

        #region 构造函数
        public GeoAttributes()
        {
            _Attributes = new List<object>();
        }
        public GeoAttributes(List<Object>objs)
        {
            _Attributes = new List<object>();
            _Attributes = objs;
        }

        #endregion

        #region 属性

        public int Count
        {
            get { return _Attributes.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的元素
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns></returns>
        public object GetItem(int index)
        {
            return _Attributes[index];
        }
        /// <summary>
        /// 添加一个点到末尾
        /// </summary>
        /// <param name="value">拟添加的值</param>
        public void Append(object value)
        {
            _Attributes.Add(value);
        }
        /// <summary>
        /// 添加一组属性到末尾
        /// </summary>
        /// <param name="Attributes">拟添加的一组属性</param>
        public void AddRange(object[] Attributes)
        {
            _Attributes.AddRange(Attributes);
        }
        /// <summary>
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="index">指定位置</param>
        public void RemoveAt(int index)
        {
            _Attributes.RemoveAt(index);
        }
        /// <summary>
        /// 将所有元素复制到一个数组中，并返回
        /// </summary>
        /// <returns></returns>
        public object[] ToArray()
        {
            return _Attributes.ToArray();
        }
        /// <summary>
        /// 删除所有元素
        /// </summary>
        public void Clear()
        {
            _Attributes.Clear();
        }
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public GeoAttributes Clone()
        {
            GeoAttributes sAttributes = new GeoAttributes();
            sAttributes._Attributes.AddRange(_Attributes);
            return sAttributes;
        }

        #endregion
    }
}
