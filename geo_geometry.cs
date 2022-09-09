using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DEETU
{

    abstract class geo_geometry
    {
        //基本方法
        public abstract bool IsEmpty();
        public abstract geo_geometry clone();
        public abstract void GetMBR(ref geo_args.OGRMBR mbr) ;
        public abstract bool Equals(ref geo_geometry other) ;
        public abstract geo_args.geom_type GetGeometryType()  ;


        //属性信息获取
        public virtual double GetLength() { return -1; }
        public virtual double GetArea() { return -1; }
        public virtual double GetPerimeter() { return -1; }


        //空间关系查询
        public abstract bool Intersects(ref geo_geometry other);
        public abstract bool Contains(ref geo_geometry other) ;
    }
}
