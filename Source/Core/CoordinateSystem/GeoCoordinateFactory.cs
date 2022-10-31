/********************************************
 * 说明：
 * 1. 该文件存储坐标系统用到的枚举类以及坐标系统工厂类
 * 2. 由于地理坐标系的转换难以实现，先将Beijing1954-WGS84的转换实现为不进行坐标转换，直接返回。
 * 
 * *******************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU.Core;
using DEETU.Geometry;

namespace DEETU.Core
{
    /// <summary>
    /// 投影类型枚举
    /// 共支持4种坐标系统，2种地理坐标系，2种投影坐标系
    /// </summary>
    public enum GeographicCrsType
    {
        WGS84 = 1,
        Beijing1954 = 2,
    }
    public enum ProjectedCrsType
    {
        WebMercator = 1,
        Lambert2SP = 2
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
            //Lambert
            _DefaultLambert2SPParam.Add("Name", "Lambert Conformal Conic 2SP");
            _DefaultLambert2SPParam.Add("Latitude of first standard parallel", "30");
            _DefaultLambert2SPParam.Add("Latitude of second standard parallel", "62");
            _DefaultLambert2SPParam.Add("Origin latitude", "0");
            _DefaultLambert2SPParam.Add("Origin longitude", "105");
            _DefaultLambert2SPParam.Add("False Northing", "0");
            _DefaultLambert2SPParam.Add("False Easting", "0");
            //Beijing1954
            _DefaultBeijing1954Param.Add("Name", "Beijing 1954");
            _DefaultBeijing1954Param.Add("Ellipsoidal flattening reciprocal", "298.3");
            _DefaultBeijing1954Param.Add("a", "6378245");
            _DefaultBeijing1954Param.Add("b", "6356863.01877305");
            //WGS84
            _DefaultWGS84Param.Add("Name", "WGS84");
            _DefaultWGS84Param.Add("Ellipsoidal flattening reciprocal", "298.2572236");
            _DefaultWGS84Param.Add("a", "6378137");
            _DefaultWGS84Param.Add("b", "6356752.314245179");
            //WebMercator
            _DefaultWebMercatorParam.Add("Name", "WebMercator");
            _DefaultWebMercatorParam.Add("False Northing", "0");
            _DefaultWebMercatorParam.Add("False Easting", "0");
            _DefaultWebMercatorParam.Add("Origin longitude", "0");
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
            double f = 1.0 / Convert.ToDouble(geographicParam["Ellipsoidal flattening reciprocal"]);
            double phi1 = Convert.ToDouble(lambertParam["Latitude of first standard parallel"]);
            double phi2 = Convert.ToDouble(lambertParam["Latitude of second standard parallel"]);
            double phi0 = Convert.ToDouble(lambertParam["Origin latitude"]);
            double a = Convert.ToDouble(geographicParam["a"]);
            double lamda0 = Convert.ToDouble(lambertParam["Origin longitude"]);
            double E0 = Convert.ToDouble(lambertParam["False Easting"]);
            double N0 = Convert.ToDouble(lambertParam["False Northing"]);

            double e = Math.Sqrt(2 * f - f * f);
            double m1 = Math.Cos(Math.PI / 180 * phi1);
            m1=m1/Math.Sqrt(1 - Math.Pow(e * Math.Sin(Math.PI / 180 * phi1), 2));
            double m2 = Math.Cos(Math.PI / 180 * phi2) /
                Math.Sqrt(1 - Math.Pow(e * Math.Sin(Math.PI / 180 * phi2), 2));
            double t0 = Math.Tan((Math.PI / 4) - (phi0 * Math.PI / 2 / 180)) /
                Math.Pow((1 - e * Math.Sin(Math.PI / 180 * phi0)) / (1 + e * Math.Sin(Math.PI / 180 * phi0)), e / 2);
            double t1 = Math.Tan((Math.PI / 4) - (phi1 * Math.PI / 2 / 180)) /
                Math.Pow((1 - e * Math.Sin(Math.PI / 180 * phi1)) / (1 + e * Math.Sin(Math.PI / 180 * phi1)), e / 2);
            double t2 = Math.Tan((Math.PI / 4) - (phi2 * Math.PI / 2 / 180)) /
                Math.Pow((1 - e * Math.Sin(Math.PI / 180 * phi2)) / (1 + e * Math.Sin(Math.PI / 180 * phi2)), e / 2);


            double n = (Math.Log(m1) - Math.Log(m2)) / (Math.Log(t1) - Math.Log(t2));
            double F = m1 / (n * Math.Pow(t1, n));
            double rho0 = a * F * Math.Pow(t0, n);
            foreach (GeoPoints geoPoints in points)
                foreach (GeoPoint point in geoPoints.Points)
                {
                    double deltaN = point.Y-N0;
                    double deltaE = point.X - E0;
                    double deltaRho = Math.Sqrt(deltaE * deltaE + Math.Pow((rho0 - deltaN), 2));
                    if (n <= 0) deltaRho = -deltaRho;
                    double deltaT = Math.Pow((deltaRho / (a * F)), 1 / n);
                    double deltaGamma = Math.Atan2(deltaE, (rho0 - deltaN));

                    double phi = Math.PI / 2 - 2 * Math.Atan(deltaT);
                    phi = Math.PI / 2 - 2 * Math.Atan(deltaT *
                        (Math.Pow((1 - e * Math.Sin(Math.PI / 180 * phi)) / (1 + e * Math.Sin(Math.PI / 180 * phi)), e / 2)));

                    point.Y = phi*180/Math.PI;
                    point.X = (deltaGamma/ n )* (180 / Math.PI )+ lamda0;
                }

        }
        public static void GeographicToLambert(
            List<GeoPoints> points,
            Dictionary<string, string> geographicParam,
            Dictionary<string, string> lambertParam)
        {
            double f = 1.0 / Convert.ToDouble(geographicParam["Ellipsoidal flattening reciprocal"]);
            double phi1 = Convert.ToDouble(lambertParam["Latitude of first standard parallel"]);
            double phi2 = Convert.ToDouble(lambertParam["Latitude of second standard parallel"]);
            double phi0 = Convert.ToDouble(lambertParam["Origin latitude"]);
            double a = Convert.ToDouble(geographicParam["a"]);
            double lamda0 = Convert.ToDouble(lambertParam["Origin longitude"]);
            double E0= Convert.ToDouble(lambertParam["False Easting"]);
            double N0 = Convert.ToDouble(lambertParam["False Northing"]);

            double e = Math.Sqrt(2 * f - f * f);
            double m1 = Math.Cos(Math.PI / 180 * phi1) /
                Math.Sqrt(1 - Math.Pow(e * Math.Sin(Math.PI / 180 * phi1), 2));
            double m2 = Math.Cos(Math.PI / 180 * phi2) /
                Math.Sqrt(1 - Math.Pow(e * Math.Sin(Math.PI / 180 * phi2), 2));
            double t0 = Math.Tan((Math.PI / 4) - (phi0 * Math.PI / 2 / 180)) /
                Math.Pow((1 - e*Math.Sin(Math.PI / 180 * phi0)) / (1 + e * Math.Sin(Math.PI / 180 * phi0)), e / 2);
            double t1 = Math.Tan((Math.PI / 4) - (phi1 * Math.PI / 2 / 180)) /
                Math.Pow((1 - e * Math.Sin(Math.PI / 180 * phi1)) / (1 + e * Math.Sin(Math.PI / 180 * phi1)), e / 2);
            double t2 = Math.Tan((Math.PI / 4) - (phi2 * Math.PI / 2 / 180)) /
                Math.Pow((1 - e * Math.Sin(Math.PI / 180 * phi2)) / (1 + e * Math.Sin(Math.PI / 180 * phi2)), e / 2);

     
            double n = (Math.Log(m1) - Math.Log(m2)) / (Math.Log(t1) - Math.Log(t2));
            double F = m1 / (n * Math.Pow(t1, n));
            double rho0 = a * F * Math.Pow(t0, n);
            foreach (GeoPoints geoPoints in points)
                foreach (GeoPoint point in geoPoints.Points)
                {
                    double phi = point.Y;
                    double t= Math.Tan((Math.PI / 4) - (phi * Math.PI / 2 / 180)) /
                        Math.Pow((1 - e * Math.Sin(Math.PI / 180 * phi)) / (1 + e * Math.Sin(Math.PI / 180 * phi)), e / 2);
                    double rho = a * F * Math.Pow(t, n);
                    double gamma = n * (point.X-lamda0);
                    point.X = E0 + rho * Math.Sin(gamma*Math.PI/180);
                    point.Y = N0 + rho0 - rho * Math.Cos(gamma * Math.PI / 180);
                }

        }
        public static void WebMercatorToWGS84(
            List<GeoPoints> points,
            Dictionary<string, string> webMercatorParam,
            Dictionary<string, string> WGS84Param)
        {
            foreach (GeoPoints geoPoints in points)
                foreach (GeoPoint point in geoPoints.Points)
                {
                    var xValue = point.X / 20037508.34 * 180;
                    var yValue = point.Y / 20037508.34 * 180;
                    yValue = 180 / Math.PI * (2 * Math.Atan(Math.Exp(yValue * Math.PI / 180)) - Math.PI / 2);
                    point.X = xValue;
                    point.Y = yValue;
                }
                    
        }
        public static void WGS84ToWebMercator(
            List<GeoPoints> points,
            Dictionary<string, string> WGS84Param,
            Dictionary<string, string> webMercatorParam)
        {
            foreach (GeoPoints geoPoints in points)
                foreach(GeoPoint point in geoPoints.Points)
                {
                    var xValue = point.X * 20037508.34 / 180;
                    var y = Math.Log(Math.Tan((90 + point.Y) * Math.PI / 360)) / (Math.PI / 180);
                    var yValue = y * 20037508.34 / 180;
                    point.X = xValue;
                    point.Y = yValue;
                }
        }
        public static void Beijing1954ToWGS84(
            List<GeoPoints> points,
            Dictionary<string, string> Beijing1954Param,
            Dictionary<string, string> WGS84Param)
        {
            return;
        }
        public static void WGS84ToBeijing1954(
            List<GeoPoints> points,
            Dictionary<string, string> WGS84Param,
            Dictionary<string, string> Beijing1954Param)
        {
            return;
        }

    }
}
