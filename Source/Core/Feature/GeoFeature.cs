using DEETU;
using DEETU.Geometry;
using DEETU.Core;
using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Core
{
    public class GeoFeature
    {
        #region 字段
        
        private GeoGeometryTypeConstant _ShapeType = GeoGeometryTypeConstant.MultiPolygon;
        private GeoGeometry _Geometry; // 几何图形
        private GeoAttributes _Attributes; // 属性集合
        private GeoSymbol _Symbol;  // 配置的符号

        #endregion

        #region 构造函数

        public GeoFeature(GeoGeometryTypeConstant shapeType, GeoGeometry geometry, GeoAttributes attributes)
        {
            _ShapeType = shapeType;
            _Geometry = geometry;
            _Attributes = attributes;
        }

        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置图形类型
        /// </summary>
        public GeoGeometryTypeConstant ShapeType
        {
            get { return _ShapeType; }
            set { _ShapeType = value; }
        }
        /// <summary>
        /// 获取或设置几何
        /// </summary>
        public GeoGeometry Geometry
        {
            get { return _Geometry; }
            set { _Geometry = value; }
        }
        /// <summary>
        /// 获取或设置属性
        /// </summary>
        public GeoAttributes Attributes
        {
            get { return _Attributes; }
            set { _Attributes = value; }
        }
        /// <summary>
        /// 仅供内部程序使用，获取或配置符号
        /// </summary>
        internal GeoSymbol Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取外包矩形
        /// </summary>
        /// <returns></returns>
        public GeoRectangle GetEnvelope()
        {
            GeoRectangle sRect = null;
            switch(_ShapeType)
            {
                case GeoGeometryTypeConstant.Point:
                    GeoPoint sPoint = (GeoPoint)_Geometry;
                    sRect = new GeoRectangle(sPoint.X, sPoint.X, sPoint.Y, sPoint.Y);
                    break;
                case GeoGeometryTypeConstant.MultiPolygon:
                    GeoMultiPolygon sMultiPolygon= (GeoMultiPolygon)_Geometry;
                    sRect = sMultiPolygon.GetEnvelope();
                    break;
                case GeoGeometryTypeConstant.MultiPolyline:
                    GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)_Geometry;
                    sRect = sMultiPolyline.GetEnvelope();
                    break;
                default:
                    break;
            }
            return sRect;
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public GeoFeature Clone()
        {
            GeoGeometryTypeConstant sShapeType = _ShapeType;
            GeoGeometry sGeometry = null;
            GeoAttributes sAttributes = _Attributes.Clone();
            if (_ShapeType == GeoGeometryTypeConstant.Point)
            {
                GeoPoint sPoint = (GeoPoint)_Geometry;
                sGeometry = sPoint.Clone() as GeoGeometry;
            }
            else if (_ShapeType == GeoGeometryTypeConstant.MultiPolyline)
            {
                GeoMultiPolyline sMultiPolyline = _Geometry as GeoMultiPolyline;
                sGeometry = sMultiPolyline.Clone() as GeoGeometry;
            }
            else if (_ShapeType == GeoGeometryTypeConstant.MultiPolygon)
            {
                GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)_Geometry;
                sGeometry = sMultiPolygon.Clone() as GeoMultiPolygon;
            }
            GeoFeature sFeature = new GeoFeature(sShapeType, sGeometry, sAttributes);
            return sFeature;
        }

        /// <summary>
        /// 用某个几何要素替换现在的几何要素
        /// </summary>
        /// <param name="srcGeometry"></param>
        public void Replace(GeoGeometry srcGeometry)
        {
            _Geometry = srcGeometry;
        }


        #endregion
    }
}
