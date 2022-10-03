using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Renderer
{
    public abstract class GeoRenderer
    {
        public abstract GeoRendererTypeConstant RendererType { get; }
        public abstract GeoRenderer Clone();
    }
}
