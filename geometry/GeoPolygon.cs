using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.geometry
{
    class GeoPolygon : GeoSurface
    {
        public List<GeoLinearRing> Rings 
        {
            get { return Rings; } 
            protected set {Rings = new List<GeoLinearRing>(value); } 
        }
        public GeoArgs.GeoMbr Mbr 
        {
            get { return Mbr; } 
            protected set { Mbr = new GeoArgs.GeoMbr(value.x_min_, value.x_max_, value.y_min_, value.y_max_); } 
        }
        public double Perimeter { get; set; }
        public double Area { get; set; }
        

        public GeoPolygon()
        {
            Area = Perimeter = 0;
            Mbr = new GeoArgs.GeoMbr();
            Rings = new List<GeoLinearRing>();
        }
        public GeoPolygon(List<GeoLinearRing> rings)
        {
            Rings = new List<GeoLinearRing>();
            if (rings.Count != 0)
            {
                GeoArgs.GeoMbr sMbr = Rings[0].GetMbr();
                Mbr = new GeoArgs.GeoMbr(sMbr.x_min_, sMbr.x_max_, sMbr.y_min_, sMbr.y_max_);
                Perimeter = Area = 0;
                Area = rings[0].GetArea();
                for (int i = 0; i < rings.Count; ++i)
                {
                    Rings.Add(new GeoLinearRing(rings[i]));
                    if (i == 0) Area += rings[0].GetArea();
                    else Area -= rings[i].GetArea();
                    Perimeter += rings[i].GetPerimeter();
                }
            }
            else Mbr = new GeoArgs.GeoMbr();

        }
        public GeoPolygon(GeoPolygon p)
        {
            Rings = new List<GeoLinearRing>();
            for (int i = 0; i < p.Rings.Count; ++i)
                Rings.Add(new GeoLinearRing(p.Rings[i]));
            Perimeter = p.Perimeter;
            Area = p.Area;
            GeoArgs.GeoMbr sMbr = Rings[0].GetMbr();
            Mbr = new GeoArgs.GeoMbr(sMbr.x_min_, sMbr.x_max_, sMbr.y_min_, sMbr.y_max_);
        }

        public override GeoGeometry clone()
        {
            return (GeoGeometry)new GeoPolygon(this);
        }

        public override bool Contains(ref GeoGeometry other)
        {
            bool flag = false;
            if (other != null)
            {
                GeoArgs.GeoMbr sMbr = other.GetMbr();
                if (sMbr.y_max_ <= Mbr.y_max_ && sMbr.y_min_ >= Mbr.y_min_ && sMbr.x_min_ >= Mbr.x_min_ && sMbr.x_max_<= Mbr.x_max_)
                {
                    for(int i = 0; i < Rings.Count; ++i)
                    {
                        if (i == 0)
                        {
                            if (Rings[0].Contains(other))
                                flag = true;
                        }
                        else
                        {
                            if (Rings[i].Contains(other))
                            {
                                flag = false;
                                break; 
                            }
                        }
                    }
                }
            }
            return flag;
        }

        public override bool Intersects(ref GeoGeometry other)
        {
            bool flag = false;
            if (other != null)
            {
                GeoArgs.GeoMbr sMbr = other.GetMbr();
                if (AreBoxesCross(Mbr,sMbr))
                {
                    switch (other.GetGeometryType())
                    {
                        case GeoArgs.GeoType.OGRPolygon:
                            break;
                        case GeoArgs.GeoType.OGRLineString:
                            break;
                        case GeoArgs.GeoType.OGRMultiPoint:
                            break;
                        default:
                            break;
                    }
                }
            }
            return flag;
        }

        public override bool Equals(ref GeoGeometry other)
        {
            if(other.GetGeometryType() == GeoArgs.GeoType.OGRPolygon)
            {
                bool flag = false;
                GeoPolygon temp = (GeoPolygon)other;
                if (temp.Area == this.Area)
                {
                    if(temp.Perimeter == this.Perimeter)
                    {
                        int length = 0;
                        if ((length = temp.Rings.Count) == Rings.Count)
                        {
                            flag = true;
                            for (int i = 0; i < length && flag; ++i)
                            {
                                if (!temp.Rings[i].Equals(this.Rings[i]))
                                    flag = false;
                            }
                        }
                    }
                }
                return flag;
            }
            return false;
        }

        public override GeoArgs.GeoType GetGeometryType()
        {
            return GeoArgs.GeoType.OGRPolygon;
        }

        public override GeoArgs.GeoMbr GetMbr()
        {
            return Mbr;
        }

        public override bool IsEmpty()
        {
            return Rings.Count() == 0 || Rings[0].IsEmpty();
        }
    }
}