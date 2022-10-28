using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SQLite;
using DEETU.Core;
using DEETU.Geometry;
using DEETU.Map;
using DEETU.Tool;
using System.Windows.Forms;
using DEETU.Core;

namespace DEETU.IO
{

    internal static class GeoDatabaseIOTools
    {
        #region 数据库保存
        
        internal static byte[] CrsToByteArray(GeoCoordinateReferenceSystem crs)
        {
            byte[] byteArray;
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, crs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw new Exception("Failed to serialize. Reason: " + e.Message);
            }
            finally
            {
                byteArray = fs.ToArray();
                fs.Close();
            }
            return byteArray;
            //从filestream中读取的实现
            //using (FileStream fs = File.OpenRead(path))
            //{
            //    byte[] b = new byte[1024];
            //    UTF8Encoding temp = new UTF8Encoding(true);
            //    while (fs.Read(b,0,b.Length) > 0)
            //    {
            //        Console.WriteLine(temp.GetString(b));
            //    }
            //}
        }

        internal static bool SaveGeoProject(GeoLayers project,string path)
        {
            string conn_str = "Data Source = ";
            conn_str += path;
            //如果不存在，则新建数据库
            bool is_new = false;
            if(File.Exists(path)==false)
            {
                is_new = true;
                try
                {
                    SQLiteConnection.CreateFile(path);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
            
            SQLiteConnection conn = new SQLiteConnection(conn_str);
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            //新建表
            if (is_new)
            {
                //新建表
                cmd.CommandText = "CREATE TABLE project_metadata (name varchar,crs BLOB, geotype int)";
                try { cmd.ExecuteNonQuery(); } catch (Exception e) { MessageBox.Show(e.Message.ToString()); }
                for (int i = 0; i < project.Count; i++)
                {
                    GeoMapLayer sLayer = project.GetItem(i);
                    string attribute_str = "CREATE TABLE " + sLayer.Name + " (id integer,renderer BLOB,geometry BLOB,";
                    for (int j = 0; j < sLayer.AttributeFields.Count; j++)
                    {
                        attribute_str += sLayer.AttributeFields.GetItem(j).Name;
                        switch (sLayer.AttributeFields.GetItem(j).ValueType)
                        {
                            case GeoValueTypeConstant.dDouble:
                            case GeoValueTypeConstant.dSingle:
                                attribute_str += " real";
                                break;
                            case GeoValueTypeConstant.dText:
                                attribute_str += " text";
                                break;
                            //其他全为int
                            default:
                                attribute_str += " integer";
                                break;
                        }
                        if (j != sLayer.AttributeFields.Count - 1) attribute_str += ",";
                    }
                    attribute_str += ")";
                    cmd.CommandText = attribute_str;
                    MessageBox.Show(attribute_str);
                    try { cmd.ExecuteNonQuery(); } catch (Exception e) { MessageBox.Show(e.Message.ToString()); }
                }
            }
            //存储元数据
            //存储project的元数据
            for(int i=0;i<project.Count;i++)
            {
                string meta_str = "INSERT INTO project_metadata VALUES(";
                meta_str += "\"" + project.GetItem(i).Name + "\",";

                byte[] sByteArray = CrsToByteArray(project.GetItem(i).Crs);
                meta_str+= "@" + sByteArray + ""+",";

                switch (project.GetItem(i).ShapeType)
                {
                    case GeoGeometryTypeConstant.Point:
                        meta_str += "0)";
                        break;
                    case GeoGeometryTypeConstant.MultiPolyline:
                        meta_str += "1)";
                        break;
                    default:
                        meta_str += "2)";
                        break;
                }
                MessageBox.Show(meta_str);
                cmd.CommandText = meta_str;
                cmd.ExecuteNonQuery();
            }

            //每个图层存储一张表
            return true;
            for (int i=0;i<project.Count;i++)
            {
                GeoMapLayer sLayer = project.GetItem(i);
                GeoFields sFields = project.GetItem(i).AttributeFields;
                for(int ID=0;ID<sLayer.Features.Count; ID++)
                {

                    string insert = "INSERT INTO " + sLayer.Name + "(id,renderer,geometry)) VALUES(" + ID.ToString()+",";

                    
                    for (int j=0;j<sFields.Count;j++)
                    {
                        GeoValueTypeConstant type= sFields.GetItem(j).ValueType;
                        string name = sFields.GetItem(j).Name;

                    }
                }
                

                byte[] sByteArray = CrsToByteArray(project.GetItem(i).Crs);

               
            }
            return true;
        }

        public static bool LoadMeta(GeoLayers layers,SQLiteConnection conn)
        {

            SQLiteCommand cmd = conn.CreateCommand();

            //创建SQL语句
            string sql = "select * from project_metadata";
            cmd.CommandText = sql;
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            { 
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader[0].ToString();
                        GeoGeometryTypeConstant sShapeType = (GeoGeometryTypeConstant)reader.GetInt32(2);
                        GeoMapLayer sLayer = new GeoMapLayer(name,sShapeType);
                        MemoryStream memstream = GetBytes(reader, 1);
                        BinaryFormatter formatter = new BinaryFormatter();
                        sLayer.Crs = (GeoCoordinateReferenceSystem)formatter.Deserialize(memstream);
                        memstream.Close();
                        layers.Add(sLayer);
                    }
                }
                else
                {
                    MessageBox.Show("no result!");
                    return false;
                }
            }
            return true;
        }
        public static bool LoadLayers(GeoLayers layers, SQLiteConnection conn)
        {
            SQLiteCommand cmd = conn.CreateCommand();

            for(int i=0;i<layers.Count;i++)
            {
                GeoMapLayer sLayer = layers.GetItem(i);
                string sql = "select * from " + layers.GetItem(i).Name;
                cmd.CommandText = sql;
                //获取表头
                using (SQLiteDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SchemaOnly))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for(int j=0;i<reader.FieldCount;j++){
                                MessageBox.Show(reader[j].ToString());
                                
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("no result!");
                        return false;
                    }
                }
                //建立属性

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader[0]);
                            MemoryStream memstream = GetBytes(reader, 2);
                            BinaryFormatter formatter = new BinaryFormatter();
                            GeoGeometry geoGeometry = (GeoGeometry)formatter.Deserialize(memstream);
                            memstream.Dispose();
                            GeoFeature sFeature = new GeoFeature(sLayer.ShapeType, geoGeometry);
                            GeoAttributes sAttributes = new GeoAttributes();
                            for (int j=3;j< reader.FieldCount;j++)
                            {



                                memstream = GetBytes(reader, 1);
                            }
                            GeoGeometryTypeConstant sShapeType = (GeoGeometryTypeConstant)reader.GetInt32(2);



                            layers.Add(sLayer);
                        }
                    }
                    else
                    {
                        MessageBox.Show("no result!");
                        return false;
                    }
                }
            }
            return true;
        }
        private static MemoryStream GetBytes(SQLiteDataReader reader,int column)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(column, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream;
            }
        }
        #endregion

    }
}
