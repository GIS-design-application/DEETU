/*****************************************
 * @file: GeoCurve
 * @author:zwy
 * @date:2021-05-01
 * @说明: 所有线类型的基类
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.geometry
{
    abstract public class GeoCurve : GeoGeometry
    {
        public abstract bool IsClosed();
        public abstract double GetLength();
    }
}
