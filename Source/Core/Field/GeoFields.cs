using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.Core
{
    public class GeoFields
    {
        #region 字段

        private List<GeoField> _Fields;
        private string _PrimaryField; // 主字段
        private bool _ShowAlias = false; // 是否显示别名，方便外部程序

        #endregion

        #region 构造函数
        public GeoFields()
        {
            _Fields = new List<GeoField>();
        }


        #endregion

        #region 属性
        /// <summary>
        /// 获取字段数量
        /// </summary>
        public int Count
        {
            get { return _Fields.Count; }
        }
        /// <summary>
        /// 获取和设置主字段
        /// </summary>
        public string PrimaryField
        {
            get { return _PrimaryField; }
            set { _PrimaryField = value; }
        }
        /// <summary>
        /// 获取和设置主字段
        /// </summary>
        public bool ShowAlias
        {
            get { return _ShowAlias; }
            set { _ShowAlias = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的字段
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GeoField GetItem(int index)
        {
            return _Fields[index];
        }

        /// <summary>
        /// 获取指定名称的字段
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GeoField GetItem(string name)
        {
            int sIndex = FindField(name);
            if (sIndex >= 0) return _Fields[sIndex];
            else return null;
        }

        /// <summary>
        /// 查找指定名称的字段，返回其索引号，如无则返回-1
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Int32 FindField(string name)
        {
            Int32 sFieldCount = _Fields.Count;
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            {
                if (_Fields[i].Name.ToLower() == name.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 追加一个字段
        /// </summary>
        /// <param name="field"></param>
        public void Append(GeoField field)
        {
            if (FindField(field.Name) >= 0)
            {
                throw new Exception("Fields对象中不能存在重名的字段！");
            }
            _Fields.Add(field);
            if (FieldAppended != null)
                FieldAppended(this, field);
        }

        /// <summary>
        /// 删除指定索引号的字段
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            GeoField sField = _Fields[index];
            _Fields.RemoveAt(index);
            if (FieldRemoved != null)
                FieldRemoved(this, index, sField);
        }

        public GeoFields Clone()
        {
            var newFields = new GeoFields();
            newFields.PrimaryField = _PrimaryField;
            newFields.ShowAlias = _ShowAlias;
            foreach (var srcField in _Fields)
            {
                var desField = srcField.Clone();
                newFields.Append(desField);
            }

            return newFields;
        }


        #endregion

        #region 事件

        internal delegate void FieldAppendedHandle(object sender, GeoField fieldAppended);
        /// <summary>
        /// 有字段加入
        /// </summary>
        internal event FieldAppendedHandle FieldAppended;

        internal delegate void FieldRemovedHandle(object sender, int fieldIndex, GeoField fieldRemoved);
        /// <summary>
        /// 有字段删除
        /// </summary>
        internal event FieldRemovedHandle FieldRemoved;

        #endregion
    }
}
