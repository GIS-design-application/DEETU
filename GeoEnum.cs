using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU
{
    /// <summary>
    /// 值类型常数
    /// </summary>
    public enum GeoValueTypeConstant
    {
        dInt16 = 0,
        dInt32 = 1,
        dInt64 = 2,
        dSingle = 3,
        dDouble = 4,
        dTest = 5
    }
    /// <summary>
    /// 符号类型
    /// </summary>
    public enum GeoSymbolTypeConstant
    {
        SimpleMarkerSymbol = 0,
        SimpleLineSymbol = 1,
        SimpleFillSymbol = 2
    }

    /// <summary>
    /// 简单点符号类型
    /// </summary>
    public enum GeoSimpleMarkerSymbolStyleConstant
    {
        Circle = 0,
        SolidCircle = 1,
        Triangle = 2,
        SolidTriangle = 3,
        Square = 4,
        SolidSquare = 5,
        CircleDot = 6,
        CircleCircle = 7
    }

    /// <summary>
    /// 简单线符号类型
    /// </summary>
    public enum GeoSimpleLineSymbolStyleConstant
    {
        Solid = 0,
        Dash = 1,
        Dot = 2,
        DashDot = 3,
        DashDotDot = 4
    }

    /// <summary>
    /// 几何类型常数
    /// </summary>
    public enum GeoGeometryTypeConstant
    {
        Point = 0,
        LineString = 1,
        LinearRing = 2,
        Polygon = 3,
        MultiPolyline = 4,
        MultiPolygon = 5,
        MultiPoint = 6
    }

    /// <summary>
    /// 渲染类型常数
    /// </summary>
    public enum GeoRendererTypeConstant
    {
        Simple = 0,
        UniqueValue = 1,
        ClassBreaks = 2
    }
}
