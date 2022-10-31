using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Data;
using DEETU.Map;

namespace DEETU.IO
{
    public class GeoDatabase
    {

        #region 字段
        private DataTable _MapData; // 用于记录图层的元数据
        private List<GeoDataTable> _LayersData; // 用于记录图层数据
        #endregion


        #region 构造函数
        public GeoDatabase() 
        {
            _MapData = new DataTable();
            _LayersData = new List<GeoDataTable>();
        }
        #endregion


        #region 属性
        #endregion


        #region 方法
        /// <summary>
        /// 从某个图层中直接生成一个GeoMapLayer, 需要读取layersdata和mapdata
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GeoMapLayer CreateLayer(int index)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 私有函数
        #endregion
    }


}
