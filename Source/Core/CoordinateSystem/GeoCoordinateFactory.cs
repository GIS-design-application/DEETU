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
    public enum GeographicCrs
    {
        WGS84,
        Beijing1954,
    }
    public enum ProjectedCrs
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
        public static readonly Dictionary<string,string> DefaultWGS84Param ;
        public static readonly Dictionary<string, string> DefaultBeijing1954Param;
        public static readonly Dictionary<string, string> DefaultWebMercatorParam;
        public static readonly Dictionary<string, string> DefaultLambert2SPParam;


        public static void LambertToGeographic(
            GeoPoints points,
            Dictionary<string,string> lambertParam,
            Dictionary<string,string> geographicParam)
        {

        }
        public static void GeographicToLambert(
            GeoPoints points,
            Dictionary<string, string> geographicParam,
            Dictionary<string, string> lambertParam)
        {

        }
        public static void WebMercatorToWGS84(
            GeoPoints points,
            Dictionary<string, string> webMercatorParam,
            Dictionary<string, string> WGS84Param)
        {

        }
        public static void WGS84ToWebMercator(
            GeoPoints points,
            Dictionary<string, string> WGS84Param,
            Dictionary<string, string> webMercatorParam)
        {

        }
        public static void WGS84ToBeijing1954(
            GeoPoints points,
            Dictionary<string, string> Beijing1954Param,
            Dictionary<string, string> WGS84Param)
        {

        }
        public static void Beijing1954ToWGS84(
            GeoPoints points,
            Dictionary<string, string> WGS84Param,
            Dictionary<string, string> Beijing1954Param)
        {

        }

    }
}
