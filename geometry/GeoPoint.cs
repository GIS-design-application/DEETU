/*****************************************
 * @file: GeoPoint 
 * @author:zwy
 * @date:2021-04-27
 * @说明：
 * 
 * 
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.geometry
{
    class GeoPoint:GeoGeometry
    {
        private double x_,y_;
        public GeoPoint()
        {
            x_ = -1;
            y_ = -1;
        }
        // 具有两个参数的构造函数
        public GeoPoint(int x, int y)
        {
            this.x_ = x;
            this.y_ = y;
        }
        public GeoPoint(GeoPoint other)
        {
            this.x_ = other.x;
            this.y_ = other.y;
        }
        public int x
        {
            get{return x;}
        }
        public int y{
            get{return y;}
        }
        //基本方法
        public override bool IsEmpty()
        {
            if(x_==-1&&y_==-1) return true;
            return false;
        }
        public override GeoGeometry clone()
        {
            GeoPoint new_point=new GeoPoint(this);
            return new_point;
        }
        public override void GetMBR(ref GeoArgs.GeoMbr mbr)
        {
            return GeoArgs.GeoMbr(x_,x_,y_,y_);
        }
        public override bool Equals(ref GeoGeometry other)
        {
            if(other.GetType()==GeoArgs.GeoType.OGRPoint)
            {
                GeoPoint other_point=other;
                if(other_point.x==x_&&other_point.y_==y) return true;
            }
            return false;
        }
        public override GeoArgs.GeoType GetGeometryType()
            {return GeoArgs.GeoType.OGRPoint;}


        //属性信息获取
        public virtual double GetLength() { return -1; }
        public virtual double GetArea() { return -1; }
        public virtual double GetPerimeter() { return -1; }


        //空间关系查询
        public override bool Intersects(ref GeoGeometry other);
        public override bool Contains(ref GeoGeometry other) ;
    }
}
