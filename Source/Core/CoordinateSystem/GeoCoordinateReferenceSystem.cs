using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU.Core;


namespace DEETU.Source.Core.CoordinateSystem
{
    /// <summary>
    /// 用来记录图层或地图的坐标系统
    /// </summary>
    public class GeoCoordinateReferenceSystem
    {

        CrsName? _GeographicCrs;//可空枚举
        CrsName? _ProjectedCrs;
        Dictionary<string, string> _Parameters;
        string _Unit;//单位

        GeoCoordinateReferenceSystem()
        {
            _GeographicCrs = null;
            _ProjectedCrs = null;
            _Unit = null;
            _Parameters = new Dictionary<string, string>();
        }

        #region 属性
        public bool IsEmpty
        {
            get
            {
                if (_GeographicCrs == null) return true;
                return false;
            }
        }
        /// <summary>
        /// 坐标系类型
        /// </summary>
        public CrsType Type
        {
            get {
                if (_GeographicCrs == null) return CrsType.None;
                else if (_ProjectedCrs == null) return CrsType.Geographic;
                else return CrsType.Projected;
            }
        }
        #endregion

        #region 方法
        public void SetParameters(string key, string value)
        {
            if(_Parameters.ContainsKey(key))
            {
                _Parameters[key] = value;
            }
            else
            {
                throw new Exception("parameter is not existing,please check crs name");
            }
        }
        /// <summary>
        /// 更改投影类型，但不更改数据。
        /// 使用前提示用户确认
        /// </summary>
        /// <param name="newCrs"></param>
        public void ChangeCrs(CrsName? newProjectedCrs=null,CrsName? newGeographicCrs=null)
        {
            if(newGeographicCrs == CrsName.WebMercator)
            {
                _GeographicCrs = CrsName.WGS84;
                _ProjectedCrs = CrsName.WebMercator;
            }
            else if(newCrs==CrsName.Beijing1954||newCrs==CrsName.WGS84)
            {

            }
        }
        #endregion
    }
}
