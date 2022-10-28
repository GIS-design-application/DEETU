using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Map
{
    public class GeoLayers
    {
        #region 字段

        private List<GeoMapLayer> _Layers = new List<GeoMapLayer>();

        #endregion

        #region 构造函数

        public GeoLayers()
        { }

        #endregion

        #region 属性

        /// <summary>
        /// 获取图层数量
        /// </summary>
        public Int32 Count
        {
            get { return _Layers.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的图层
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GeoMapLayer GetItem(Int32 index)
        {
            return _Layers[index];
        }

        /// <summary>
        /// 在图层序列末尾增加一个图层
        /// </summary>
        /// <param name="mapLayer"></param>
        public void Add(GeoMapLayer mapLayer)
        {
            _Layers.Add(mapLayer);
        }

        /// <summary>
        /// 移除指定图层
        /// </summary>
        /// <param name="mapLayer"></param>
        public void Remove(GeoMapLayer mapLayer)
        {
            _Layers.Remove(mapLayer);
        }

        /// <summary>
        /// 移除指定索引号的图层
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(Int32 index)
        {
            _Layers.RemoveAt(index);
        }

        /// <summary>
        /// 清除所有图层
        /// </summary>
        public void Clear()
        {
            _Layers.Clear();
        }

        /// <summary>
        /// 将指定索引的图层移动到另一指定索引
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public void MoveTo(Int32 fromIndex, Int32 toIndex)
        {
            if (fromIndex == toIndex)
                return;
            else
            {
                GeoMapLayer sLayer = _Layers[fromIndex];
                _Layers.RemoveAt(fromIndex);
                _Layers.Insert(toIndex, sLayer);
            }
        }

        /// <summary>
        /// 在指定位置插入图层
        /// </summary>
        /// <param name="index"></param>
        /// <param name="layer"></param>
        public void Insert(int index, GeoMapLayer layer)
        {
            if(index <= _Layers.Count)
                _Layers.Insert(index, layer);
        }


        /// <summary>
        /// 用于获得选择的图层, 整张地图只能有一个图层正在被选择
        /// </summary>
        /// <returns></returns>
        public GeoMapLayer getSelectableLayer()
        {
            if (_Layers.Count == 1)
            {
                return _Layers[0];
            }
            for(int i = 0; i < _Layers.Count; i++)
            {
                if (_Layers[i].Selectable)
                {
                    return _Layers[i];
                }
            }
            throw new Exception("没有图层或没有可以选择的图层");
        }

        public void Deselect()
        {
            for (int i = 0; i < _Layers.Count; i++)
            {
                _Layers[i].Selectable = false;
            }
        }

        #endregion
    }
}
