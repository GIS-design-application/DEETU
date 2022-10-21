using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU.Core;
using DEETU.Geometry;
using DEETU.Map;
using DEETU.Tool;

namespace DEETU.Source.Core.CoordinateSystem
{
    public class CoordinateTransform
    {
        #region 字段
        public GeoCoordinateReferenceSystem _SrcCrs;
        public GeoCoordinateReferenceSystem _DstCrs;
        public List<GeoMapLayer> _Layers;
        #endregion

        #region 构造函数
        public CoordinateTransform(
            GeoCoordinateReferenceSystem srcCrs,
            GeoCoordinateReferenceSystem dstCrs,
            List<GeoMapLayer> layers)
        {
            if (srcCrs.IsEmpty == true || dstCrs.IsEmpty == true)
                throw new Exception("Crs to transform cannot be null!");
            if (layers.Count == 0)
                throw new Exception("There must be layers to transform!");
            _SrcCrs = srcCrs;
            _DstCrs = dstCrs;
            _Layers = layers;
        }
        #endregion

        #region 方法

        public List<GeoPoints> GetGeometryFromFeature(GeoFeature feature)
        {
            List < GeoPoints > points= new List<GeoPoints>();
            if (feature.ShapeType==GeoGeometryTypeConstant.Point)
            {
                List<GeoPoint> tmp_points = new List<GeoPoint>();
                tmp_points.Add((feature.Geometry) as GeoPoint);
                points.Add(new GeoPoints(tmp_points));
            }
            else if(feature.ShapeType == GeoGeometryTypeConstant.MultiPolyline)
            {
                points.AddRange((feature.Geometry as GeoMultiPolyline).Parts.Parts);

            }
            else if (feature.ShapeType == GeoGeometryTypeConstant.MultiPolygon)
            {
                points.AddRange((feature.Geometry as GeoMultiPolygon).Parts.Parts);
            }
            return points;
        }

        /// <summary>
        /// 坐标系转化函数
        /// </summary>
        public void Transform()
        {
            if (_SrcCrs == _DstCrs) return;
            if (_SrcCrs.Type == CrsType.Projected)
            {
                if (_SrcCrs.ProjectedCrs == ProjectedCrsType.Lambert2SP)
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoCoordinateFactory.LambertToGeographic(
                                GetGeometryFromFeature(layer.Features.GetItem(i)),
                                _SrcCrs.ProjectedParameters,
                                _SrcCrs.GeographicParameters
                                );
                        }
                }
                else
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoCoordinateFactory.WebMercatorToWGS84(
                                GetGeometryFromFeature(layer.Features.GetItem(i)),
                                _SrcCrs.ProjectedParameters,
                                _SrcCrs.GeographicParameters
                                );
                        }
                }
            }
            if(_SrcCrs.GeographicCrs!=_DstCrs.GeographicCrs)
            {
                if(_DstCrs.GeographicCrs== GeographicCrsType.Beijing1954)
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {

                            GeoCoordinateFactory.WGS84ToBeijing1954(
                                GetGeometryFromFeature(layer.Features.GetItem(i)),
                                _SrcCrs.GeographicParameters,
                                _DstCrs.GeographicParameters
                                );
                        }
                }
                else
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {

                            GeoCoordinateFactory.Beijing1954ToWGS84(
                                GetGeometryFromFeature(layer.Features.GetItem(i)),
                                _SrcCrs.GeographicParameters,
                                _DstCrs.GeographicParameters
                                );
                        }
                }
            }
            if(_DstCrs.Type== CrsType.Projected)
            {
                if (_DstCrs.ProjectedCrs == ProjectedCrsType.Lambert2SP)
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoCoordinateFactory.GeographicToLambert(
                                GetGeometryFromFeature(layer.Features.GetItem(i)),
                                _DstCrs.GeographicParameters,
                                _DstCrs.ProjectedParameters
                                );
                        }
                }
                else
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {

                            GeoCoordinateFactory.WGS84ToWebMercator(
                                GetGeometryFromFeature(layer.Features.GetItem(i)),
                                _DstCrs.GeographicParameters,
                                _DstCrs.ProjectedParameters
                                );
                        }
                }
            }
            //更改图层坐标系
            foreach (GeoMapLayer layer in _Layers)
            {
                layer.Crs = _DstCrs;
            }
        }
        #endregion
    }
}
