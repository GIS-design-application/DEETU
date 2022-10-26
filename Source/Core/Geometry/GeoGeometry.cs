using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    public abstract class GeoGeometry : GeoShape
    {
        public virtual GeoGeometry Clone()
        {
            throw new Exception("Clone method should be called with specified Geo object");
        }

        public virtual GeoRectangle UpdateExtent()
        {
            throw new Exception("UpdateExtent method should be called with specified Geo object");
        }

    }
}
