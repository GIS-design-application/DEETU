using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Data.SQLite;
using DEETU.Core;
using DEETU.Geometry;
using DEETU.Map;
using DEETU.Tool;


namespace DEETU.Source.IO
{

    internal static class GeoDatabaseIOTools
    {
        #region 数据库保存
        internal static bool SaveGeoProject(GeoLayers project)
        {

            //每个图层存储一张表
            for(int i=0;i<project.Count;i++)
            {

            }
        }

        #endregion


        internal static GeoMapLayer LoadMapLayer(BinaryReader sr)
        {
            Int32 sTemp = sr.ReadInt32();   //不需要
            GeoGeometryTypeConstant sGeometryType = (GeoGeometryTypeConstant)sr.ReadInt32();
            GeoFields sFields = LoadFields(sr);
            GeoFeatures sFeatures = LoadFeatures(sGeometryType, sFields, sr);
            GeoMapLayer sMapLayer = new GeoMapLayer("", sGeometryType, sFields);
            sMapLayer.Features = sFeatures;
            return sMapLayer;
        }
    }
}
