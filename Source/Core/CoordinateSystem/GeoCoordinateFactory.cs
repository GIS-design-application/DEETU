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
    public enum CrsName
    {
        WGS84,
        Beijing1954,
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
        static Dictionary<string,string> _WGS84Param;
        static Dictionary<string, string> _Beijing1954Param;
        static Dictionary<string, string> _WebMercatorParam;
        static Dictionary<string, string> _Lambert2SPParam;


        public void LambertToGeographic(GeoPoints points)
        {

        }
        public void GeographicToLambert(GeoPoints points)
        {

        }
        public void WebMercatorToWGS84(GeoPoints points)
        {

        }
        public void WGS84ToWebMercator(GeoPoints points)
        {

        }
        public void WGS84ToBeijing1954(GeoPoints points)
        {

        }
        public void Beijing1954ToWGS84(GeoPoints points)
        {

        }

    }
}
