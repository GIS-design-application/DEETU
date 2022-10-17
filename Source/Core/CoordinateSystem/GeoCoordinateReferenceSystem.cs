using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU.Core;
using System.Diagnostics;

namespace DEETU.Source.Core.CoordinateSystem
{
    /// <summary>
    /// 用来记录图层或地图的坐标系统
    /// </summary>
    public class GeoCoordinateReferenceSystem
    {

        GeographicCrs? _GeographicCrs;//可空枚举
        ProjectedCrs? _ProjectedCrs;
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
        public GeographicCrs? GeographicCrs
        {
            get { return _GeographicCrs; }
        }
        public ProjectedCrs? ProjectedCrs
        {
            get { return _ProjectedCrs; }
        }
        #endregion

        #region 方法
        public void SetParameters(Dictionary<string, string> parameters)
        {
            foreach (string key in parameters.Keys)
            {
                if (_Parameters.ContainsKey(key) == false)
                { 
                    throw new Exception("parameter is not existing,please check crs name");
                }
            }
            foreach (string key in parameters.Keys)
            {
                _Parameters[key] = parameters[key];
            }
        }
        /// <summary>
        /// 更改投影类型，但不更改数据。
        /// 使用前提示用户确认
        /// </summary>
        /// <param name="newCrs"></param>
        //TODO:对于投影坐标系的参数应该由两部分构成
        public void ChangeCrs(GeographicCrs? newGeographicCrs=null, ProjectedCrs? newProjectedCrs = null)
        {
            if (newGeographicCrs == _GeographicCrs && newProjectedCrs == _ProjectedCrs)
                return;
            if(newGeographicCrs==null)
                throw new Exception("Geographic Crs cannot be null");
            if (newGeographicCrs == GeographicCrs.Beijing1954&&
                newProjectedCrs==ProjectedCrs.WebMercator)
            {
                throw new Exception("WebMercator can't be paired with Beijing1954");
            }
            //更改参数

            switch(newGeographicCrs)
            {
                case GeographicCrs.Beijing1954:
                    if (newProjectedCrs == null)
                        _Parameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultBeijing1954Param);
                    else
                        _Parameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultLambert2SPParam);
                    break;
                case GeographicCrs.WGS84:
                    if (newProjectedCrs == null)
                        _Parameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultWGS84Param);
                    else if (newProjectedCrs == ProjectedCrs.WebMercator)
                        _Parameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultWebMercatorParam);
                    else
                        _Parameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultLambert2SPParam);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
        #endregion
    }
}
