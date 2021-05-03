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
            protected set { Mbr = new GeoArgs.GeoMbr(value); } 
        }
        private double Perimeter { get; set; }
        private double Area { get; set; }
        

        public GeoPolygon()
        {
            Area = Perimeter = 0;
            Mbr = new GeoArgs.GeoMbr();
            Rings = new List<GeoLinearRing>();
        }
        public GeoPolygon(List<GeoLinearRing> rings)
        {
            Rings = new List<GeoLinearRing>(rings);
            if (rings.Count != 0)
            {
                Mbr = new GeoArgs.GeoMbr(rings[0].GetMbr());
                Perimeter = Area = 0;
                Area = rings[0].GetArea();
                for (int i = 0; i < rings.Count; ++i)
                {
                    if (i == 0) Area += rings[0].GetArea();
                    else Area -= rings[i].GetArea();
                    Perimeter += rings[i].GetPerimeter();
                }
            }
            else Mbr = new GeoArgs.GeoMbr();

        }
        public GeoPolygon(GeoPolygon p)
        {
            Rings = new List<GeoLinearRing>(p.Rings);
            Perimeter = p.Perimeter;
            Area = p.Area;
            Mbr = new GeoArgs.GeoMbr(p.Mbr);
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
                GeoArgs.GeoMbr Mbr = other.GetMbr();
                if (Mbr.Contains(Mbr))
                {
                    switch (other.GetGeometryType())
                    {
                        case GeoArgs.GeoType.OGRPoint:
                        case GeoArgs.GeoType.OGRPolygon:
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

        public override bool Intersects(ref GeoGeometry other)
        {
            bool flag = false;
            if (other != null)
            {
                GeoArgs.GeoMbr Mbr = other.GetMbr();
                if (Mbr.Intersects(Mbr))
                {
                    switch (other.GetGeometryType())
                    {
                        case GeoArgs.GeoType.OGRPolygon:
                            other = (GeoPolygon)other;

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