using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DEETU.Core;
using DEETU.Geometry;
using DEETU.Map;
using DEETU.Tool;
using System.Runtime.InteropServices;
using System.Data;

namespace DEETU.IO
{
    public class GeoDBFTable
    {
        public DataTable dt;

        public List<short> mColumnsLength;
        public List<string> mColumnsName;
        public List<string> ID;
        public int mRowCount, mColumnCount;

        public GeoDBFTable()
        {
            dt = new DataTable();
            mColumnsLength = new List<short>();
            mColumnsName = new List<string>();
            ID = new List<string>();
        }
    }
    public static class GeoShpIOTools
    {
        #region 程序集方法
        /// <summary>
        /// 读取shp文件选择界面
        /// 需要移植到主界面部分，开发时保证独立性暂时写在本类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        
        public static GeoMapLayer ReadSHPFile(string shpPath)
        {
            int sShapeType;
            GeoMapLayer sLayer;
            string name = Path.GetFileNameWithoutExtension(shpPath);
            FileStream fs = new FileStream(shpPath, FileMode.Open, FileAccess.ReadWrite);

            //读取主文件头
            BinaryReader br = new BinaryReader(fs);
            _ = br.ReadBytes(24);//文件编号及未被使用的字段
            _ = br.ReadInt32();//文件长度
            _ = br.ReadInt32();//版本
            sShapeType = br.ReadInt32();
            //更新展示范围
            //暂时没用，GeoMapLayer类直接计算
            double xmin, ymax, xmax, ymin;
            double temp = br.ReadDouble();
            xmin = temp;
            temp = br.ReadDouble();
            ymax = temp;
            temp = br.ReadDouble();
            xmax = temp;
            temp = br.ReadDouble();
            ymin = temp;
            _ = br.ReadBytes(32);//Z、M的范围
            //读取主文件记录内容
            switch (sShapeType)
            {
                case 1:
                    {
                        sLayer = new GeoMapLayer(name, GeoGeometryTypeConstant.Point);
                        sLayer.Features = new GeoFeatures();
                        while (br.PeekChar() != -1)
                        {
                            GeoPoint point = new GeoPoint();
                            _ = br.ReadInt32();//记录编号
                            _ = br.ReadInt32();//记录内容长度
                            _ = br.ReadInt32();//记录内容头的图形类型编号
                            point.X = br.ReadDouble();
                            point.Y = br.ReadDouble();
                            GeoFeature sPointFeature = new GeoFeature(GeoGeometryTypeConstant.Point, point);
                            sLayer.Features.Add(sPointFeature);
                        }
                        //StreamWriter sw = new StreamWriter("point.txt");
                        //foreach (Point p in points)
                        //{
                        //    sw.WriteLine("{0},{1},{2} ", p.X, -1 * p.Y, 0);
                        //}
                        //sw.Close();
                        break;
                    }
                case 3:
                    {
                        sLayer = new GeoMapLayer(name, GeoGeometryTypeConstant.MultiPolyline);
                        sLayer.Features = new GeoFeatures();
                        while (br.PeekChar() != -1)
                        {
                            GeoMultiPolyline sPolyline = new GeoMultiPolyline();
                            GeoParts sParts = new GeoParts();
                            _ = br.ReadInt32();//记录编号
                            _ = br.ReadInt32();//记录内容长度
                            _ = br.ReadInt32();//记录内容头的图形类型编号
                            //范围,不需要
                            _ = br.ReadDouble();
                            _ = -br.ReadDouble();
                            _ = br.ReadDouble();
                            _ = -br.ReadDouble();
                            //
                            int sPartsCount = br.ReadInt32();
                            int sPointsCount = br.ReadInt32();
                            List<int> numParts = new List<int>();
                            for (int i = 0; i < sPartsCount; i++)
                            {
                                numParts.Add(br.ReadInt32());
                            }
                            numParts.Add(sPointsCount);//为了后面的第二层循环更方便
                            for (int i = 0; i < sPartsCount; i++)
                            {
                                int startId = numParts[i];
                                GeoPoints sPart = new GeoPoints();
                                for (int j = startId; j < numParts[i+1]; j++)
                                {
                                    GeoPoint point = new GeoPoint();
                                    point.X = br.ReadDouble();
                                    point.Y = br.ReadDouble();
                                    sPart.Add(point);
                                }
                                sParts.Add(sPart);
                            }
                            sPolyline.Parts = sParts;
                            sPolyline.UpdateExtent();
                            GeoFeature sPolylineFeature = new GeoFeature(GeoGeometryTypeConstant.MultiPolyline, sPolyline);
                            sLayer.Features.Add(sPolylineFeature);
                        }
                        break;
                    }
                case 5:
                    {
                        sLayer = new GeoMapLayer(name, GeoGeometryTypeConstant.MultiPolygon);
                        sLayer.Features = new GeoFeatures();
                        while (br.PeekChar() != -1)
                        {
                            GeoMultiPolygon sPolygon = new GeoMultiPolygon();
                            GeoParts sParts = new GeoParts();
                            _ = br.ReadInt32();//记录编号
                            _ = br.ReadInt32();//记录内容长度
                            _ = br.ReadInt32();//记录内容头的图形类型编号
                            //范围,不需要
                            _ = br.ReadDouble();
                            _ = -br.ReadDouble();
                            _ = br.ReadDouble();
                            _ = -br.ReadDouble();
                            //
                            int sPartsCount = br.ReadInt32();
                            int sPointsCount = br.ReadInt32();
                            List<int> numParts = new List<int>();
                            for (int i = 0; i < sPartsCount; i++)
                            {
                                numParts.Add(br.ReadInt32());
                            }
                            numParts.Add(sPointsCount);//为了后面的第二层循环更方便
                            for (int i = 0; i < sPartsCount; i++)
                            {
                                int startId = numParts[i];
                                GeoPoints sPart = new GeoPoints();
                                for (int j = startId; j < numParts[i + 1]; j++)
                                {
                                    GeoPoint point = new GeoPoint();
                                    point.X = br.ReadDouble();
                                    point.Y = br.ReadDouble();
                                    sPart.Add(point);
                                }
                                sParts.Add(sPart);
                            }
                            sPolygon.Parts = sParts;
                            sPolygon.UpdateExtent();
                            GeoFeature sPolygonFeature = new GeoFeature(GeoGeometryTypeConstant.MultiPolygon, sPolygon);
                            sLayer.Features.Add(sPolygonFeature);
                        }
                        break;
                    }
                default:
                    {
                        br.Close();
                        fs.Close();
                        throw new Exception("不支持的几何类型，错误集合类型值:" + (sShapeType).ToString());
                    }
            }
            sLayer.UpdateExtent();
            //关闭流
            br.Close();
            fs.Close();
            return sLayer;
        }
        public static void ReadDBFFile(string dbfPath, GeoMapLayer layer)
        {
            
            GeoDBFTable table=new GeoDBFTable();
            table.dt.Columns.Clear();
            table.dt.Rows.Clear();
            table.mColumnsName.Clear();
            table.mColumnsLength.Clear();
            FileStream fs = new FileStream(dbfPath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            _ = br.ReadByte();//当前版本信息
            _ = br.ReadBytes(3);//最近更新日期
            table.mRowCount = br.ReadInt32();//文件中的记录条数
            table.mColumnCount = (br.ReadInt16() - 33) / 32;//文件头中的字节数
            _ = br.ReadInt16();//一条记录中的字节长度
            _ = br.ReadBytes(20);//系统保留
            GeoFields sFields = new GeoFields();
            for (int i = 0; i < table.mColumnCount; i++)
            {
                string name = System.Text.Encoding.Default.GetString(br.ReadBytes(10));
                table.dt.Columns.Add(new DataColumn(name, typeof(string)));
                GeoField sField = new GeoField(name,GeoValueTypeConstant.dText);
                table.mColumnsName.Add(name);
                _ = br.ReadBytes(6);//包含类型信息，暂时没读
                short length = br.ReadByte();
                table.mColumnsLength.Add(length);
                sField.Length = length;
                _ = br.ReadBytes(15);
                sFields.Append(sField);
            }
            layer.AttributeFields = sFields;
            _ = br.ReadBytes(1);//终止符0x0D
            for (int i = 0; i < table.mRowCount; i++)
            {
                GeoFeature sFeature = layer.Features.GetItem(i);
                _ = br.ReadByte();//占位符
                DataRow dr;
                dr = table.dt.NewRow();
                sFeature.Attributes = new GeoAttributes();
                for (int j = 0; j < table.mColumnCount; j++)
                {
                    string temp = System.Text.Encoding.Default.GetString(br.ReadBytes(table.mColumnsLength[j]));
                    if (j == 0) table.ID.Add(temp);
                    dr[(string)table.mColumnsName[j]] = temp;
                    object sValue = temp as object;
                    sFeature.Attributes.Append(sValue);
                }
                table.dt.Rows.Add(dr);
            }
            
        }

        public static void ReadPrjFile(string prjPath, GeoMapLayer layer)
        {
            if(File.Exists(prjPath) ==false)
            {
                layer.Crs = new GeoCoordinateReferenceSystem() ;
                return;
            }
            else
            {
                StreamReader sr = new StreamReader(prjPath);
                string prj = sr.ReadToEnd();
                GeoCoordinateReferenceSystem sCrs=new GeoCoordinateReferenceSystem();
                if(prj.Contains("PROJGCS")) 
                { 
                    if(prj.Contains("Lambert Conic Conformal (2SP)"))
                    {
                        if(prj.Contains("WGS84"))
                        {
                            sCrs=new 
                                GeoCoordinateReferenceSystem(GeographicCrsType.WGS84,ProjectedCrsType.Lambert2SP);
                        }
                        else if(prj.Contains("Beijing 1954"))
                        {
                            sCrs=new 
                                GeoCoordinateReferenceSystem(GeographicCrsType.Beijing1954,ProjectedCrsType.Lambert2SP);
                        }
                    }
                    else if(prj.Contains("WGS_1984_Web_Mercator"))
                    {
                        sCrs=new 
                            GeoCoordinateReferenceSystem(GeographicCrsType.WGS84,ProjectedCrsType.WebMercator);
                    }
                    else { MessageBox.Show("无法使用该投影坐标系对应的地理坐标系");return;}
                }
                else
                {
                    if(prj.Contains("WGS84"))
                    {
                        sCrs=new 
                            GeoCoordinateReferenceSystem(GeographicCrsType.WGS84,null);
                    }
                    else if(prj.Contains("WGS84"))
                    {
                        sCrs=new 
                            GeoCoordinateReferenceSystem(GeographicCrsType.Beijing1954,null);
                    }
                    else
                    {
                        MessageBox.Show("无法使用该地理坐标系");return;
                    }
                }
                layer.Crs=sCrs;
                MessageBox.Show(prj);
            }
        }

        #endregion

    }
}
