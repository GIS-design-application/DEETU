/*****************************************
 * @file: GeoGeometry 
 * @author:zwy
 * @date:2021-04-23
 * @说明：geo开头为所有图形模块内容，GeoGeometry为所有图形类的基类
 *       为abstract class，无法实例化
 *       获取长度、面积、周长由于各种图形不是都使用，因此设为virtual方法，可以不覆写
 *       其余方法都为abstract方法，在子类中必须显式定义
 * ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DEETU.geometry
{

    abstract public class GeoGeometry
    {
        //基本方法
        public abstract bool IsEmpty();
        public abstract GeoGeometry clone();
        public abstract GeoArgs.GeoMbr GetMBR() ;
        public abstract bool Equals(ref GeoGeometry other) ;
        public abstract GeoArgs.GeoType GetGeometryType()  ;


        //属性信息获取
        public virtual double GetLength() { return -1; }
        public virtual double GetArea() { return -1; }
        public virtual double GetPerimeter() { return -1; }


        //空间关系查询
        public abstract bool Intersects(ref GeoGeometry other);
        public abstract bool Contains(ref GeoGeometry other) ;
    }
}
