using DEETU.Core;
using DEETU.Geometry;
using DEETU.Map;
using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEETU.IO
{
    internal static class GeoDataIOTools
    {
        #region 程序集方法
        internal static bool SaveMapLayer(GeoMapLayer sLayer)
        {

            FileStream fileStream = new FileStream("C:\\Users\\zwy99\\Desktop\\test.lay", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fileStream);
            bw.Write(1);//没有用
            bw.Write(Convert.ToInt32(sLayer.ShapeType));
            if(SaveFields(bw,sLayer.AttributeFields)==false)
            {
                return false;
            }
            if (SaveFeatures(bw,sLayer.Features,sLayer.AttributeFields,sLayer.ShapeType) == false)
            {
                MessageBox.Show("save features fail");
                return false;
            }
            fileStream.Close();
            return true;
        }
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
        #endregion

        #region 私有函数
        /// <summary>
        /// 存储字段集合
        /// </summary>
        /// <param name="bw"></param>
        /// <returns>是否成功</returns>



        private static bool SaveAttributes(BinaryWriter bw,GeoFields fields,GeoAttributes attributes)
        {
            Int32 sFieldCount = fields.Count;
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            {
                GeoField sField = fields.GetItem(i);
                SaveValue(bw,sField.ValueType, attributes.GetItem(i));
            }
            return true;
        }
        private static bool SaveValue(BinaryWriter bw, GeoValueTypeConstant valueType,object value)
        {
            if (valueType == GeoValueTypeConstant.dInt16)
            {
                bw.Write(Convert.ToInt16(value));
                return true;
            }
            else if (valueType == GeoValueTypeConstant.dInt32)
            {
                bw.Write(Convert.ToInt32(value));
                return true;
            }
            else if (valueType == GeoValueTypeConstant.dInt64)
            {
                bw.Write(Convert.ToInt64(value));
                return true;
            }
            else if (valueType == GeoValueTypeConstant.dSingle)
            {
                bw.Write(Convert.ToSingle(value));
                return true;
            }
            else if (valueType == GeoValueTypeConstant.dDouble)
            {
                bw.Write(Convert.ToDouble(value));
                return true;
            }
            else if (valueType == GeoValueTypeConstant.dText)
            {
                bw.Write(Convert.ToString(value));
                return true;
            }
            else
            {
                MessageBox.Show("wrong value type!");
                return false;
            }
        }



        private static bool SaveFields(BinaryWriter bw, GeoFields fields)
        {
            bw.Write(Convert.ToInt32(fields.Count)); //字段数量
            for (Int32 i = 0; i <= fields.Count - 1; i++)
            {
                try
                {
                    GeoField sField = fields.GetItem(i);
                    bw.Write(sField.Name);
                    bw.Write(Convert.ToInt32(sField.ValueType));
                    bw.Write(Convert.ToInt32(1));//不需要
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;
                }
            }
            return true;
        }
        //读取字段集合
        private static GeoFields LoadFields(BinaryReader sr)
        {
            Int32 sFieldCount = sr.ReadInt32(); //字段数量
            GeoFields sFields = new GeoFields();
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            {
                string sName = sr.ReadString();
                GeoValueTypeConstant sValueType = (GeoValueTypeConstant)sr.ReadInt32();
                Int32 sTemp = sr.ReadInt32();   //不需要；
                GeoField sField = new GeoField(sName, sValueType);
                sFields.Append(sField);
            }
            return sFields;
        }
        private static bool SaveFeatures(BinaryWriter bw, GeoFeatures features, GeoFields fields, GeoGeometryTypeConstant geometryType)
        {
            Int32 sFeatureCount = features.Count;
            bw.Write(sFeatureCount);
            for (int i = 0; i <= sFeatureCount - 1; i++)
            {
                MessageBox.Show(i.ToString());
                try { SaveGeometry(bw, features.GetItem(i).Geometry, geometryType); } catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
                try { SaveAttributes(bw, fields, features.GetItem(i).Attributes); } catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
            }
            return true;
        }

        //读取要素集合
        private static GeoFeatures LoadFeatures(GeoGeometryTypeConstant geometryType, GeoFields fields, BinaryReader sr)
        {
            GeoFeatures sFeatures = new GeoFeatures();
            Int32 sFeatureCount = sr.ReadInt32();
            for (int i = 0; i <= sFeatureCount - 1; i++)
            {
                //MessageBox.Show(i.ToString());
                GeoGeometry sGeometry = LoadGeometry(geometryType, sr);
                GeoAttributes sAttributes = LoadAttributes(fields, sr);
                GeoFeature sFeature = new GeoFeature(geometryType, sGeometry, sAttributes);
                sFeatures.Add(sFeature);
            }
            return sFeatures;
        }
        private static bool SaveGeometry(BinaryWriter bw, GeoGeometry geometry, GeoGeometryTypeConstant geometryType)
        {
            if (geometryType == GeoGeometryTypeConstant.Point)
            {
                return (SavePoint(bw, geometry));
            }
            else if (geometryType == GeoGeometryTypeConstant.MultiPolyline)
            {
                return (SaveMultiPolyline(bw, geometry));
            }
            else if (geometryType == GeoGeometryTypeConstant.MultiPolygon)
            {
                return (SaveMultiPolygon(bw, geometry));
            }
            else
            {
                MessageBox.Show("no geometry type!");
                return false;
            }

        }
        private static GeoGeometry LoadGeometry(GeoGeometryTypeConstant geometryType, BinaryReader sr)
        {
            if (geometryType == GeoGeometryTypeConstant.Point)
            {
                GeoPoint sPoint = LoadPoint(sr);
                return sPoint;
            }
            else if (geometryType == GeoGeometryTypeConstant.MultiPolyline)
            {
                GeoMultiPolyline sMultiPolyline = LoadMultiPolyline(sr);
                return sMultiPolyline;
            }
            else if (geometryType == GeoGeometryTypeConstant.MultiPolygon)
            {
                GeoMultiPolygon sMultiPolygon = LoadMultiPolygon(sr);
                return sMultiPolygon;
            }
            else
                return null;
        }
        private static bool SavePoint(BinaryWriter bw, GeoGeometry geometry)
        {
            //原数据支持多点，按照多点读取，然后返回多点的第一个点
            bw.Write(1);//点数
            bw.Write((geometry as GeoPoint).X);
            bw.Write((geometry as GeoPoint).Y);
            return true;
        }
        //读取一个点
        private static GeoPoint LoadPoint(BinaryReader sr)
        {
            //原数据支持多点，按照多点读取，然后返回多点的第一个点
            Int32 sPointCount = sr.ReadInt32();
            GeoPoints sPoints = new GeoPoints();
            for (Int32 i = 0; i <= sPointCount - 1; i++)
            {
                double sX = sr.ReadDouble();
                double sY = sr.ReadDouble();
                GeoPoint sPoint = new GeoPoint(sX, sY);
                sPoints.Add(sPoint);
            }
            return sPoints.GetItem(0);
        }
        private static bool SaveMultiPolyline(BinaryWriter bw, GeoGeometry geometry)
        {

            Int32 sPartCount = (geometry as GeoMultiPolyline).Parts.Count;
            bw.Write(Convert.ToInt32(sPartCount));
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = (geometry as GeoMultiPolyline).Parts.GetItem(i).Count;
                bw.Write(Convert.ToInt32(sPointCount));
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    bw.Write((geometry as GeoMultiPolyline).Parts.GetItem(i).GetItem(j).X);
                    bw.Write((geometry as GeoMultiPolyline).Parts.GetItem(i).GetItem(j).Y);
                }
            }
            return true;
        }
        //读取一个复合折线
        private static GeoMultiPolyline LoadMultiPolyline(BinaryReader sr)
        {
            GeoMultiPolyline sMultiPolyline = new GeoMultiPolyline();
            Int32 sPartCount = sr.ReadInt32();
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                GeoPoints sPoints = new GeoPoints();
                Int32 sPointCount = sr.ReadInt32();
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    double sX = sr.ReadDouble();
                    double sY = sr.ReadDouble();
                    GeoPoint sPoint = new GeoPoint(sX, sY);
                    sPoints.Add(sPoint);
                }
                sMultiPolyline.Parts.Add(sPoints);
            }
            sMultiPolyline.UpdateExtent();
            return sMultiPolyline;
        }
        private static bool SaveMultiPolygon(BinaryWriter bw, GeoGeometry geometry)
        {
            Int32 sPartCount = (geometry as GeoMultiPolygon).Parts.Count;
            bw.Write(sPartCount);
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = (geometry as GeoMultiPolygon).Parts.GetItem(i).Count;
                bw.Write(sPointCount);
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    bw.Write((geometry as GeoMultiPolygon).Parts.GetItem(i).GetItem(j).X);
                    bw.Write((geometry as GeoMultiPolygon).Parts.GetItem(i).GetItem(j).Y);
                }
            }
            return true;
        }
        //读取一个复合多边形
        private static GeoMultiPolygon LoadMultiPolygon(BinaryReader sr)
        {
            GeoMultiPolygon sMultiPolygon = new GeoMultiPolygon();
            Int32 sPartCount = sr.ReadInt32();
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                GeoPoints sPoints = new GeoPoints();
                Int32 sPointCount = sr.ReadInt32();
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    double sX = sr.ReadDouble();
                    double sY = sr.ReadDouble();
                    GeoPoint sPoint = new GeoPoint(sX, sY);
                    sPoints.Add(sPoint);
                }
                sMultiPolygon.Parts.Add(sPoints);
            }
            sMultiPolygon.UpdateExtent();
            return sMultiPolygon;
        }

        private static GeoAttributes LoadAttributes(GeoFields fields, BinaryReader sr)
        {
            Int32 sFieldCount = fields.Count;
            GeoAttributes sAttributes = new GeoAttributes();
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            {
                GeoField sField = fields.GetItem(i);
                object sValue = LoadValue(sField.ValueType, sr);
                sAttributes.Append(sValue);
            }
            return sAttributes;
        }

        private static object LoadValue(GeoValueTypeConstant valueType, BinaryReader sr)
        {
            if (valueType == GeoValueTypeConstant.dInt16)
            {
                Int16 sValue = sr.ReadInt16();
                return sValue;
            }
            else if (valueType == GeoValueTypeConstant.dInt32)
            {
                Int32 sValue = sr.ReadInt32();
                return sValue;
            }
            else if (valueType == GeoValueTypeConstant.dInt64)
            {
                Int64 sValue = sr.ReadInt64();
                return sValue;
            }
            else if (valueType == GeoValueTypeConstant.dSingle)
            {
                float sValue = sr.ReadSingle();
                return sValue;
            }
            else if (valueType == GeoValueTypeConstant.dDouble)
            {
                double sValue = sr.ReadDouble();
                return sValue;
            }
            else if (valueType == GeoValueTypeConstant.dText)
            {
                string sValue = sr.ReadString();
                return sValue;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
