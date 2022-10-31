using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Core
{
    [Serializable]
    public  abstract class GeoSymbol
    {
        /// <summary>
        /// 抽象属性，获取符号类型
        /// </summary>
        public abstract GeoSymbolTypeConstant SymbolType { get; }
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public abstract GeoSymbol Clone();
    }
}
