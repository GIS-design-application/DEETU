/*****************************************
 * @file: GeoLineString
 * @author:zwy
 * @date:2021-05-01
 * @说明: LineString为基本的线类型，用vertexes存储节点信息，Vertex只读属性读取节点信息。
 *        TODO:
 *        1. 完善构造函数
 *        2. 增加对环的相等判断
 *        3. 空间关系判断
 *        4. 修改vertexes查看方法
 * ****************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEETU.geometry
{
    public class GeoLineString:GeoCurve
    {
        //节点集合
        public List<GeoPoint> vertice = new List<GeoPoint>();

        //如果闭合，默认首尾存储两次
        public override bool IsClosed()
        {
            if (vertexes[0].Equals(vertexes[vertexes.Count - 1]))
                return true;
            return false;
        }

        public GeoArgs.GeoMbr mbr { get; }
        //基本方法
        public override bool IsEmpty()
        {
            if (vertexes.Count == 0) return true;
            return false;
        }
        public override GeoGeometry clone()
        {
            GeoLineString new_line = new GeoLineString();
            for(int i=0;i<this.vertexes.Count;i++)
            {
                new_line.vertexes.Add(this.vertexes[i].clone() as GeoPoint);
            }
            return new_line;
        }

        // deprecated
        // public override void GetMBR(ref GeoArgs.GeoMbr mbr) ;

        public override bool Equals(ref GeoGeometry other)
        {
            if (other.GetGeometryType() != GeoArgs.GeoType.OGRLineString)
                return false;
            GeoLineString other_line = other as GeoLineString;
            if (vertexes.Count != other_line.Vertexes.Count)
                return false;
            for(int i=0;i<vertexes.Count;i++ )
            {
                if (!vertexes[i].Equals(other_line.Vertexes[i]))
                    return false;
            }
            return true;
            //TODO:闭合环的判断
        }
        public override GeoArgs.GeoType GetGeometryType()
        {
            return GeoArgs.GeoType.OGRLineString;
        }


        //属性信息获取
        public override double GetLength()
        {
            double len = 0;
            for (int i = 0; i < vertexes.Count - 1; i++)
            {
                len += Math.Sqrt(
                    Math.Pow((vertexes[i].x - vertexes[i + 1].x), 2) + 
                    Math.Pow((vertexes[i].y - vertexes[i + 1].y), 2));
            }
            return len;
        }


        //空间关系查询
        public override bool Intersects(ref GeoGeometry other)
        {
            return false;
        }
        public override bool Contains(ref GeoGeometry other)
        {
            return false;
        }
    }
}
