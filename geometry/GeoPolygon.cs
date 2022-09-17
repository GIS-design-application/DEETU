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
        public GeoArgs.GeoMbr MBR 
        {
            get { return MBR; } 
            protected set { MBR = new GeoArgs.GeoMbr(value); } 
        }
        private double Perimeter { get; set; }
        private double Area { get; set; }
        

        public GeoPolygon()
        {
            Area = Perimeter = 0;
            MBR = new GeoArgs.GeoMbr();
            Rings = new List<GeoLinearRing>();
        }
        public GeoPolygon(List<GeoLinearRing> rings)
        {
            Rings = new List<GeoLinearRing>(rings);
            if (rings.Count != 0)
            {
                MBR = new GeoArgs.GeoMbr(rings[0].GetMbr());
                Perimeter = Area = 0;
                Area = rings[0].GetArea();
                for (int i = 0; i < rings.Count; ++i)
                {
                    if (i == 0) Area += rings[0].GetArea();
                    else Area -= rings[i].GetArea();
                    Perimeter += rings[i].GetPerimeter();
                }
            }
            else MBR = new GeoArgs.GeoMbr();

        }
        public GeoPolygon(GeoPolygon p)
        {
            Rings = new List<GeoLinearRing>(p.Rings);
            Perimeter = p.Perimeter;
            Area = p.Area;
            MBR = new GeoArgs.GeoMbr(p.MBR);
        }

        public override GeoGeometry Clone()
        {
            return new GeoPolygon(this);
        }

        public override bool Contains(ref GeoGeometry other)
        {
            if (other != null)
            {
                GeoArgs.GeoMbr mbr = new GeoArgs.GeoMbr();
                other.GetMBR(ref mbr);
                if (MBR.Contains(mbr))
                {
                    switch (other.GetGeometryType())
                    {
                        case GeoArgs.GeoType.OGRPoint:
                            break;
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
            return false;
        }

        public override bool Intersects(ref GeoGeometry other)
        {
            bool flag = false;
            if (other != null)
            {
                GeoArgs.GeoMbr mbr = new GeoArgs.GeoMbr();
                other.GetMBR(ref mbr);
                if (MBR.Intersects(mbr))
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

        public override void GetMBR(ref GeoArgs.GeoMbr mbr)
        {
            mbr = MBR;
        }

        public override bool IsEmpty()
        {
            return Rings.Count() == 0 || Rings[0].IsEmpty();
        }
    }
}