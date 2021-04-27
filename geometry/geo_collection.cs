using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.geometry
{
    public class geo_collection
    {
        // Properties
        private List<geo_geometry> _item_list { get; }

        // Methods
        public geo_collection(List<geo_geometry> item_list)
        {
            _item_list = item_list;
        }


    }
}
