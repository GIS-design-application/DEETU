using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.geometry
{
    public class GeoCollection
    {
        // Properties
        private List<GeoGeometry> _item_list { get; }

        // Methods
        public GeoCollection(List<GeoGeometry> item_list)
        {
            _item_list = item_list;
        }


    }
}
