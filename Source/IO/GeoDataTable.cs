using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEETU.Map;

namespace DEETU.IO
{
    public class GeoDataTable
    {
        #region 字段
        private DataTable _GeoData;
        private DataTable _AttrData;
        #endregion

        #region 构造函数
        public GeoDataTable()
        {
            _GeoData = new DataTable();
            _AttrData = new DataTable();
        }

        /// <summary>
        /// 从已有的Datatable中生成生成一个新的GeoDataTable
        /// </summary>
        /// <param name="datatable"></param>
        public GeoDataTable(DataTable geoDataTable, DataTable attrDataTable)
        {
            _GeoData = geoDataTable;
            _AttrData = attrDataTable;
        }

        public GeoDataTable(GeoMapLayer layer)
        {
            _GeoData = new DataTable();
            _AttrData = new DataTable();
            GenerateDataTable(layer);
        }
        #endregion

        #region 属性
        public DataTable GeoData => _GeoData;
        public DataTable AttrData => _AttrData;
        #endregion
        #region 方法
        /// <summary>
        /// 从MapLayer中读取所有要素, 属性数据以及Layer的元数据生成DataTable
        /// </summary>
        /// <param name="layer"></param>
        public void GenerateDataTable(GeoMapLayer layer)
        {
            // 属性数据存入
            GenerateAttributeData(layer);
            GenerateGeoData(layer);
            // 地理要素数据存入 
        }
        
        /// <summary>
        /// 对比并更新DataTable
        /// </summary>
        /// <param name="layer"></param>
        public void UpdateDataTable(GeoMapLayer layer)
        {
            _GeoData.Clear();
            GenerateDataTable(layer); // update可能很难写, 暂时将DataTable先清空然后直接generate
        }
        #endregion
        #region 私有函数
        /// <summary>
        /// 读取属性数据并存入datatable
        /// </summary>
        private void GenerateAttributeData(GeoMapLayer layer) { }
        /// <summary>
        /// 读取地理要素数据并存入datatable
        /// </summary>
        /// <param name="layer"></param>
        private void GenerateGeoData(GeoMapLayer layer) { }
        #endregion
    }
}
