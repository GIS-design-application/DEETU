using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU.Core;
using System.Diagnostics;
using System.CodeDom;

namespace DEETU.Core
{
    /// <summary>
    /// 用来记录图层或地图的坐标系统
    /// </summary>
    [Serializable]
    public class GeoCoordinateReferenceSystem
    {

        GeographicCrsType? _GeographicCrs;//可空枚举
        ProjectedCrsType? _ProjectedCrs;
        Dictionary<string, string> _GeographicParameters;
        Dictionary<string, string> _ProjectedParameters;
        string _Unit;//单位

        #region 构造函数
        public GeoCoordinateReferenceSystem()
        {
            _GeographicCrs = null;
            _ProjectedCrs = null;
            _Unit = null;
            _GeographicParameters = new Dictionary<string, string>();
            _ProjectedParameters = new Dictionary<string, string>();
        }

        public GeoCoordinateReferenceSystem(GeographicCrsType? geographicCrs, ProjectedCrsType? projectedCrs)
        {
            _GeographicCrs = geographicCrs;
            _ProjectedCrs = projectedCrs;
            SetParameters(_GeographicCrs, _ProjectedCrs);
        }
        #endregion

        #region 运算符重载
        public static bool operator == (GeoCoordinateReferenceSystem crs1,GeoCoordinateReferenceSystem crs2)
        {
            if (crs1.GeographicCrs == crs2.GeographicCrs && crs1.ProjectedCrs == crs2.ProjectedCrs)
                return true;
            return false;
        }
        public static bool operator !=(GeoCoordinateReferenceSystem crs1, GeoCoordinateReferenceSystem crs2)
        {
            if ((object)crs2 == null)
            {
                return true;
            }
            if (crs1.GeographicCrs == crs2.GeographicCrs && crs1.ProjectedCrs == crs2.ProjectedCrs)
                return false;
            return true;
        }
        #endregion


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
        public GeographicCrsType? GeographicCrs
        {
            get { return _GeographicCrs; }
        }
        public ProjectedCrsType? ProjectedCrs
        {
            get { return _ProjectedCrs; }
        }
        public String Unit
        {
            get { return _Unit; }
        }
        
        public Dictionary<string, string> GeographicParameters
        {
            get { return _GeographicParameters; }
        }
        public Dictionary<string, string> ProjectedParameters
        {
            get { return _ProjectedParameters; }
        }
        #endregion

        #region 方法


        public GeoCoordinateReferenceSystem Clone ()
        {
            var desCrs = new GeoCoordinateReferenceSystem(_GeographicCrs, _ProjectedCrs);
            desCrs._GeographicParameters = new Dictionary<string, string>(_GeographicParameters);
            desCrs._ProjectedParameters = new Dictionary<string, string>(_ProjectedParameters);
            desCrs._Unit = _Unit;
            return desCrs;
        }
        /// <summary>
        /// 设置自定义参数
        /// </summary>
        /// <param name="isGeographic">是否是地理坐标系参数</param>
        /// <param name="parameters">参数列表</param>
        public void SetParameters(bool isGeographic=true,Dictionary<string, string> parameters=null)
        {
            if (isGeographic)
            {
                foreach (string key in parameters.Keys)
                {
                    if (_GeographicParameters.ContainsKey(key) == false)
                    {
                        throw new Exception("parameter is not existing,please check crs name");
                    }
                }
                foreach (string key in parameters.Keys)
                {
                    _GeographicParameters[key] = parameters[key];
                }
            }
            else
            {
                foreach (string key in parameters.Keys)
                {
                    if (_GeographicParameters.ContainsKey(key) == false)
                    {
                        throw new Exception("parameter is not existing,please check crs name");
                    }
                }
                foreach (string key in parameters.Keys)
                {
                    _GeographicParameters[key] = parameters[key];
                }
            }
        }
        /// <summary>
        /// 更改投影类型，但不更改数据。
        /// 使用前提示用户确认
        /// </summary>
        /// <param name="newCrs"></param>
        //TODO:对于投影坐标系的参数应该由两部分构成
        public void ChangeCrs(GeographicCrsType? newGeographicCrs=null, ProjectedCrsType? newProjectedCrs = null)
        {
            if (newGeographicCrs == _GeographicCrs && newProjectedCrs == _ProjectedCrs)
                return;
            if(newGeographicCrs==null)
                throw new Exception("Geographic Crs cannot be null");
            if (newGeographicCrs == GeographicCrsType.Beijing1954 &&
                newProjectedCrs== ProjectedCrsType.WebMercator)
            {
                throw new Exception("WebMercator can't be paired with Beijing1954");
            }
            //更改参数

            switch(newGeographicCrs)
            {
                case GeographicCrsType.Beijing1954:
                    _GeographicParameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultBeijing1954Param);
                    if (newProjectedCrs != null)
                        _ProjectedParameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultLambert2SPParam);
                    else _ProjectedParameters = null;
                    break;
                case GeographicCrsType.WGS84:
                    _GeographicParameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultWGS84Param);
                    if (newProjectedCrs == ProjectedCrsType.WebMercator)
                        _ProjectedParameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultWebMercatorParam);
                    else if (newProjectedCrs == ProjectedCrsType.Lambert2SP)
                        _ProjectedParameters = new Dictionary<string, string>(GeoCoordinateFactory.DefaultLambert2SPParam);
                    else _ProjectedParameters = null;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
        #endregion

        private void SetParameters(GeographicCrsType? geographicCrs, ProjectedCrsType? projectedCrs)
        {
            switch (geographicCrs)
            {
                case GeographicCrsType.Beijing1954:
                    _GeographicParameters = GeoCoordinateFactory.DefaultBeijing1954Param;
                    break;
                case GeographicCrsType.WGS84:
                    _GeographicParameters = GeoCoordinateFactory.DefaultWGS84Param;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            switch (projectedCrs)
            {
                case ProjectedCrsType.Lambert2SP:
                    _ProjectedParameters = GeoCoordinateFactory.DefaultLambert2SPParam;
                    break;
                case ProjectedCrsType.WebMercator:
                    _ProjectedParameters = GeoCoordinateFactory.DefaultWebMercatorParam;
                    break;
                default:
                    break;
            }
        }
    }
}
