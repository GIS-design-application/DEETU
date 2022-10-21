using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU.Core;
using DEETU.Geometry;

namespace DEETU.Source.Core.CoordinateSystem
{
    /// <summary>
    /// 投影类型枚举
    /// 共支持4种坐标系统，2种地理坐标系，2种投影坐标系
    /// </summary>
    public enum GeographicCrsType
    {
        WGS84,
        Beijing1954,
    }
    public enum ProjectedCrsType
    {
        WebMercator,
        Lambert2SP
    }
    public enum CrsType
    {
        None,
        Geographic,
        Projected
    }
    /// <summary>
    /// 坐标系工厂类，提供工具函数
    /// </summary>
    public class GeoCoordinateFactory
    {
        //存储四种坐标系的默认参数
        private static Dictionary<string,string> _DefaultWGS84Param;
        private static Dictionary<string, string> _DefaultBeijing1954Param;
        private static Dictionary<string, string> _DefaultWebMercatorParam;
        private static Dictionary<string, string> _DefaultLambert2SPParam;

        static GeoCoordinateFactory()
        {
            _DefaultWGS84Param = new Dictionary<string, string>();
            _DefaultBeijing1954Param = new Dictionary<string, string>();
            _DefaultWebMercatorParam = new Dictionary<string, string>();
            _DefaultLambert2SPParam = new Dictionary<string, string>();

        }

        #region 属性
        public static Dictionary<string, string> DefaultWGS84Param
        {
            get { return _DefaultWGS84Param; }
        }
        public static Dictionary<string, string> DefaultBeijing1954Param
        {
            get { return _DefaultBeijing1954Param; }
        }
        public static Dictionary<string, string> DefaultWebMercatorParam
        {
            get { return _DefaultWebMercatorParam; }
        }
        public static Dictionary<string, string> DefaultLambert2SPParam
        {
            get { return _DefaultLambert2SPParam; }
        }
        #endregion
        


        public static void LambertToGeographic(
            List<GeoPoints> points,
            Dictionary<string,string> lambertParam,
            Dictionary<string,string> geographicParam)
        {

        }
        public static void GeographicToLambert(
            List<GeoPoints> points,
            Dictionary<string, string> geographicParam,
            Dictionary<string, string> lambertParam)
        {

        }
        public static void WebMercatorToWGS84(
            List<GeoPoints> points,
            Dictionary<string, string> webMercatorParam,
            Dictionary<string, string> WGS84Param)
        {

        }
        public static void WGS84ToWebMercator(
            List<GeoPoints> points,
            Dictionary<string, string> WGS84Param,
            Dictionary<string, string> webMercatorParam)
        {

        }
        public static void Beijing1954ToWGS84(
            List<GeoPoints> points,
            Dictionary<string, string> Beijing1954Param,
            Dictionary<string, string> WGS84Param)
        {

        }
        public static void WGS84ToBeijing1954(
            List<GeoPoints> points,
            Dictionary<string, string> WGS84Param,
            Dictionary<string, string> Beijing1954Param)
        {

        }

    }
}
