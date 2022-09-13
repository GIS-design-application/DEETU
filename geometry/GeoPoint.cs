/*****************************************
 * @file: GeoPoint 
 * @author:zwy
 * @date:2021-04-27
 * @说明：Point 类，用属性x,y读取点位置，不可set.
 *       用SetPos，SetX,SetY方法设置坐标
 * 
 * 
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DEETU.geometry
{
    class GeoPoint:GeoGeometry
    {
        private double x_,y_;
        //构造函数
        public GeoPoint()
        {
            x_ = -1;
            y_ = -1;
        }
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
        //属性
        public int x
        {
            get{return x;}
        }
        public int y{
            get{return y;}
        }
        //基本方法
        public void SetPos(double x,double y)
        {
            x_ = x;
            y_ = y;
        }
        public void SetX(double x)
        {
            x_= x;
        }
        public void SetY(double y)
        {
            y_ = y;
        }
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
        public override GeoArgs.GeoMbr GetMBR()
        {
            GeoArgs.GeoMbr mbr = new GeoArgs.GeoMbr(x_, x_, y_, y_);
            return mbr;
        }
        public override bool Equals(ref GeoGeometry other)
        {
            if(other.GetGeometryType()== GeoArgs.GeoType.OGRPoint)
            {
                GeoPoint other_point=other as GeoPoint;
                if(other_point.x==x_&&other_point.y_==y) return true;
            }
            return false;
        }
        public override GeoArgs.GeoType GetGeometryType()
        {return GeoArgs.GeoType.OGRPoint;}
        
        //TODO
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
