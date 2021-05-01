/*****************************************
 * @file: GeoLinearRing
 * @author:zwy
 * @date:2021-05-01
 * @说明: 环类型
 * @TODO:
 *      1.增加构造函数中对封闭的限制
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.geometry
{
    class GeoLinearRing:GeoLineString
    {

        //将环封闭
        public void CloseRing()
        {
            if (this.IsClosed()) return;
            this.Vertexes.Add(this.Vertexes[0]);
        }

        public override bool Contains(ref GeoGeometry other)
        {
            return false;
        }
    }
}
