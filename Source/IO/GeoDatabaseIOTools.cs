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
using System.Windows.Forms;

namespace DEETU.Source.IO
{

    internal static class GeoDatabaseIOTools
    {
        #region 数据库保存
        
        internal static bool SaveGeoProject(GeoLayers project,string path)
        {
            string conn_str = "Data Source = ";
            conn_str += path;
            //如果不存在，则新建数据库
            if(File.Exists(path)==false)
            {
                try
                {
                    SQLiteConnection.CreateFile(path);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            SQLiteConnection conn = new SQLiteConnection(conn_str);
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            //存储元数据

            //每个图层存储一张表
            for (int i=0;i<project.Count;i++)
            {

            }
            return true;
        }

        #endregion

    }
}
