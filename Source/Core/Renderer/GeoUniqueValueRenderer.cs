using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Core
{
    public class GeoUniqueValueRenderer : GeoRenderer
    {

        #region 字段

        private string _Field = ""; // 绑定字段
        private string _HeadTitle = ""; // 在图层显示控件中的标题
        private bool _ShowHead = true; // 在图层显示空间中是否显示标题
        private List<string> _Values = new List<string>(); // 唯一值集合
        private List<GeoSymbol> _Symbols = new List<GeoSymbol>(); // 符号集合
        private GeoSymbol _DefaultSymbol; //  默认符号
        private bool _ShowDefaultSymbol; // 是否在图层显示控件中现实默认符号

        #endregion

        #region 构造函数
        public GeoUniqueValueRenderer()
        {

        }

        #endregion

        #region 属性
        /// <summary>
        /// 获取渲染类型
        /// </summary>
        public override GeoRendererTypeConstant RendererType
        {
            get { return GeoRendererTypeConstant.UniqueValue; }
        }

        /// <summary>
        /// 获取唯一值数量
        /// </summary>
        public int ValueCount
        {
            get { return _Values.Count; }
        }

        /// <summary>
        /// 获取或设置默认符号
        /// </summary>
        public GeoSymbol DefaultSymbol
        {
            get { return _DefaultSymbol; }
            set { _DefaultSymbol = value; }
        }
        /// <summary>
        /// 获取或设置字段
        /// </summary>
        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        // 其他属性不再编写，自行扩充

        #endregion

        #region 方法
        /// <summary>
        /// 获取唯一值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetValue(int index)
        {
            return _Values[index];
        }

        /// <summary>
        /// 设置唯一值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetValue(int index, string value)
        {
            _Values[index] = value;
        }
        /// <summary>
        /// 获取符号
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GeoSymbol GetSymbol(int index)
        {
            return _Symbols[index];
        }
        /// <summary>
        /// 设置符号
        /// </summary>
        /// <param name="index"></param>
        /// <param name="symbol"></param>
        public void SetSymbol(int index, GeoSymbol symbol)
        {
            _Symbols[index] = symbol;
        }

        /// <summary>
        /// 增加一个唯一值及对应符号
        /// </summary>
        /// <param name="value"></param>
        /// <param name="symbol"></param>
        public void AddUniqueValue(string value, GeoSymbol symbol)
        {
            _Values.Add(value);
            _Symbols.Add(symbol);
        }

        /// <summary>
        /// 增加一个唯一值数组及对应的符号数组
        /// </summary>
        /// <param name="values"></param>
        /// <param name="symbols"></param>
        public void AddUniqueValues(string[] values, GeoSymbol[] symbols)
        {
            if (values.Length == symbols.Length)
            {
                _Values.AddRange(values);
                _Symbols.AddRange(symbols);
            }
            else
            {
                throw new Exception(" The Length of the two array is not equal!");
            }

        }

        /// <summary>
        /// 根据指定唯一值查找符号并返回该符号，如果唯一值不存在，则返回默认符号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public GeoSymbol FindSymbol(string value)
        {
            int sValueCount = _Values.Count;
            for (int i = 0; i < sValueCount; ++i)
            {
                if (_Values[i] == value)
                    return _Symbols[i];
            }
            return _DefaultSymbol;
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public override GeoRenderer Clone()
        {
            GeoUniqueValueRenderer sRenderer = new GeoUniqueValueRenderer();
            sRenderer._Field = _Field;
            sRenderer._HeadTitle = _HeadTitle;
            sRenderer._ShowHead = _ShowHead;
            Int32 sValueCount = _Values.Count;
            for (Int32 i = 0; i <= sValueCount - 1; i++)
            {
                string sValue = _Values[i];
                GeoSymbol sSymbol = null;
                if (_Symbols[i] != null)
                    sSymbol = _Symbols[i].Clone();
                sRenderer.AddUniqueValue(sValue, sSymbol);
            }
            if (_DefaultSymbol != null)
                sRenderer.DefaultSymbol = _DefaultSymbol.Clone();
            sRenderer._ShowDefaultSymbol = _ShowDefaultSymbol;
            return sRenderer;
        }



        #endregion
    }
}
