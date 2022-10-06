using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    public abstract class GeoGeometry : GeoShape
    {
        public override object Clone()
        {
            throw new NotImplementedException("Should not call this method");
        }
    }
}
