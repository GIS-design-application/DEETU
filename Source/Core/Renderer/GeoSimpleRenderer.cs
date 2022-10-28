using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Core
{
    public class GeoSimpleRenderer : GeoRenderer
    {
        #region 字段

        private GeoSymbol _Symbol;

        #endregion

        #region 构造函数
        public GeoSimpleRenderer()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取渲染类型
        /// </summary>
        public override GeoRendererTypeConstant RendererType
        {
            get { return GeoRendererTypeConstant.Simple; }
        }
        /// <summary>
        /// 获取或设置符号
        /// </summary>
        public GeoSymbol Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public override GeoRenderer Clone()
        {
            GeoSimpleRenderer sRenderer = new GeoSimpleRenderer();
            sRenderer._Symbol = _Symbol.Clone();
            return sRenderer;
        }
        #endregion
    }
}
