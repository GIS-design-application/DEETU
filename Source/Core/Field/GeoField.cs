using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Core
{
    /// <summary>
    /// 属性字段
    /// </summary>
    public class GeoField
    {
        #region 字段

        private string _Name = ""; // 字段名称
        private string _AliasName = ""; // 字段别名
        private GeoValueTypeConstant _ValueType = GeoValueTypeConstant.dInt16;
        private int _Length; // 长度，针对文本类型

        #endregion

        #region 构造函数
        public GeoField(string name)
        {
            _Name = name;
            _AliasName = name;
        }

        public GeoField(string name, GeoValueTypeConstant type)
        {
            _Name = name;
            _AliasName = name;
            _ValueType = type;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取字段名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }
        /// <summary>
        /// 获取和修改别名
        /// </summary>
        public string AliaName
        {
            get { return _AliasName; }
            set { _AliasName = value; }
        }
        /// <summary>
        /// 获取字段类型
        /// </summary>
        public GeoValueTypeConstant ValueType
        {
            get { return _ValueType; }
        }
        /// <summary>
        /// 获取字段长度
        /// </summary>
        public int Length
        {
            get { return _Length; }
        }
        #endregion

        #region 方法

        public GeoField Clone()
        {
            GeoField sField = new GeoField(_Name, _ValueType);
            sField._AliasName = _AliasName;
            sField._Length = _Length;
            return sField;
        }


        #endregion

    }
}
