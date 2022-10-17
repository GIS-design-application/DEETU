using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEETU.Core;
using DEETU.Geometry;
using DEETU.Map;

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
        public void Transform()
        {
            if (_SrcCrs.Type == CrsType.Projected)
            {
                if (_SrcCrs.ProjectedCrs == ProjectedCrs.Lambert2SP)
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoGeometry geometry = layer.Features.GetItem(i).Geometry;
                            GeoCoordinateFactory.LambertToGeographic();
                        }
                }
                else
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoGeometry geometry = layer.Features.GetItem(i).Geometry;
                            GeoCoordinateFactory.LambertToGeographic();
                        }
                }
            }
            if(_SrcCrs.GeographicCrs!=_DstCrs.GeographicCrs)
            {
                if(_DstCrs.GeographicCrs==GeographicCrs.Beijing1954)
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoGeometry geometry = layer.Features.GetItem(i).Geometry;
                            GeoCoordinateFactory.WGS84ToBeijing1954();
                        }
                }
                else
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoGeometry geometry = layer.Features.GetItem(i).Geometry;
                            GeoCoordinateFactory.Beijing1954ToWGS84();
                        }
                }
            }
            if(_DstCrs.Type== CrsType.Projected)
            {
                if (_DstCrs.ProjectedCrs == ProjectedCrs.Lambert2SP)
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoGeometry geometry = layer.Features.GetItem(i).Geometry;
                            GeoCoordinateFactory.GeographicToLambert();
                        }
                }
                else
                {
                    foreach (GeoMapLayer layer in _Layers)
                        for (int i = 0; i < layer.Features.Count; i++)
                        {
                            GeoGeometry geometry = layer.Features.GetItem(i).Geometry;
                            GeoCoordinateFactory.WGS84ToWebMercator();
                        }
                }
            }
            //更改图层坐标系
        }
        #endregion
    }
}
