using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Geometry
{
    public abstract class GeoShape
    { 
        virtual public object Clone()
        {
            throw new NotImplementedException("Clone method should be called with specified Geo object");
        }
    }
}
