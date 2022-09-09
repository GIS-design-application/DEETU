using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU
{
    public class geo_args
    {
        //错误类型
        public enum geo_err
        {
            GEOERR_NONE,                       /**< 成功 */
            GEOERR_NOT_ENOUGH_DATA,            /**< 数据不足 */
            GEOERR_NOT_ENOUGH_MEMORY,          /**< 内存不足 */
            GEOERR_UNSUPPORTED_GEOMETRY_TYPE,  /**< 类型不支持 */
            GEOERR_UNSUPPORTED_OPERATION,      /**< 操作不支持 */
            GEOERR_CORRUPT_DATA,               /**< 数据损坏 */
            GEOERR_FAILURE,                    /**< 失败 */
            GEOERR_NON_EXISTING_FEATURE,       /**< 未存储 */
            GEOERR_TYPEERROR                   /**< 类型错误 */
        };
        //几何类型
        public enum geom_type
        {
            Unknown = 7,
            OGRLinearRing = 6,
            OGRLineString = 5,
            OGRMultiLineString = 4,
            OGRMultiPoint = 3,
            OGRMultiPolygon = 2,
            OGRPolygon = 1,
            OGRPoint = 0
        };
        //点与多边形关系
        public enum point_to_polygon { on_line, inner, outer };


        //最小外包矩形类
        public class OGRMBR
        {
            public OGRMBR() { }
            public OGRMBR(double x_min, double x_max, double y_min, double y_max)
            {
                x_min_ = x_min;
                x_max_ = x_max;
                y_min_ = y_min;
                y_max_ = y_max;
            }
            double x_min_, x_max_, y_min_, y_max_;
        };
    }
}
