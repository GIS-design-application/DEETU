using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEETU.Core;
using DEETU.Map;
using DEETU.Tool;
using Sunny.UI;

namespace DEETU.Source.Window
{
    public partial class SelectedByExpressionForm : UIForm
    {
        #region 字段
        GeoMapLayer mLayer;
        #endregion
        public SelectedByExpressionForm(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;

            Initialize();
        }

        #region 事件处理函数
        /// <summary>
        /// 点击操作符向表达式添加对应操作符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperatorButtons_Click(object sender, EventArgs e)
        {
            UIButton button = sender as UIButton;
            expressionTextBox.Text += " " + button.Text + " ";
        }

        /// <summary>
        /// 双击字段在向表达式添加字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldsListBox_ItemDoubleClick(object sender, EventArgs e)
        {
            expressionTextBox.Text += fieldsListBox.SelectedItem.ToString() ;
        }

        private void getUniqueValueButton_Click(object sender, EventArgs e)
        {
            int fieldIdx = fieldsListBox.SelectedIndex;
            if (fieldIdx == -1)
            {
                UIMessageBox.ShowError("请选择字段", false);
                return;
            }
            GeoValueTypeConstant valueType = mLayer.AttributeFields.GetItem(fieldIdx).ValueType;
            valueListBox.Items.Clear();
            GeoFeatures features = mLayer.Features;
            List<object> valueList = new List<object>();
            for (int i = 0; i < features.Count; i++)
            {
                object value = features.GetItem(i).Attributes.GetItem(fieldIdx);
                switch (valueType)
                {
                    case GeoValueTypeConstant.dInt16:
                        valueList.Add((Int16)value);
                        break;
                    case GeoValueTypeConstant.dInt32:
                        valueList.Add((Int32)value);
                        break;
                    case GeoValueTypeConstant.dInt64:
                        valueList.Add((Int64)value);
                        break;
                    case GeoValueTypeConstant.dSingle:
                        valueList.Add((Single)value);
                        break;
                    case GeoValueTypeConstant.dDouble:
                        valueList.Add((double)value);
                        break;
                    case GeoValueTypeConstant.dText:
                        valueList.Add((string)value);
                        break;
                    default:
                        valueList.Add(value.ToString());
                        break;
                }
            }

            valueList.Sort();
            for (int i = 0; i < features.Count; i++)
            {
                valueListBox.Items.Add(valueList[i].ToString());
            }
        }

        /// <summary>
        /// 双击值向表达式添加对应值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueListBox_ItemDoubleClick(object sender, EventArgs e)
        {
            GeoField selectedField = mLayer.AttributeFields.GetItem(fieldsListBox.SelectedIndex);
            if (selectedField.ValueType == GeoValueTypeConstant.dText)
                expressionTextBox.Text += "'" + valueListBox.SelectedItem.ToString() + "'";
            else
                expressionTextBox.Text += valueListBox.SelectedItem.ToString() ;
        }

        private void searchValueButton_Click(object sender, EventArgs e)
        {
            int fieldIdx = fieldsListBox.SelectedIndex;
            if (fieldIdx == -1)
            {
                UIMessageBox.ShowError("请选择字段", false);
                return;
            }
            GeoValueTypeConstant valueType = mLayer.AttributeFields.GetItem(fieldIdx).ValueType;

            if (searchTextBox.Text.IsNullOrWhiteSpace())
                return;
            else
            {
                List<string> itemList = valueListBox.Items.Cast<string>().ToList();
                if (valueType == GeoValueTypeConstant.dText)
                {
                    valueListBox.SelectedIndex = itemList.FindIndex((string s) => s.Contains(searchTextBox.Text));
                }
                else
                {
                    List<double> doubleList = itemList.ConvertAll(s => Convert.ToDouble(s)) ;
                    int frontIndex= doubleList.FindIndex((double d) => d > Convert.ToDouble(searchTextBox.Text)) ;
                    valueListBox.SelectedIndex = frontIndex > -1 ? frontIndex - 1 : -1;
                }
                if (valueListBox.SelectedIndex < 0)
                    UIMessageBox.ShowInfo("未找到符合要求的值", false);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (expressionTextBox.Text.IsNullOrWhiteSpace())
            {
                DialogResult dr = MessageBox.Show("您没有输入任何表达式，确定要继续吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return;
            }
                
            GeoSelectionModeConstant selectionMode = (GeoSelectionModeConstant)uiComboboxEx1.SelectedIndex;
            LayerQuery?.Invoke(this, mLayer, expressionTextBox.Text, selectionMode);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 私有函数
        private void Initialize()
        {
            layerNameText.Text = mLayer.Name;
            uiComboboxEx1.SelectedIndex = 0;
            GeoFields fields = mLayer.AttributeFields;
            for (int i = 0; i < fields.Count; i++)
            {
                fieldsListBox.Items.Add(fields.GetItem(i).Name);
            }
            expressionLabel.Text = "Select * From " + mLayer.Name + " Where";
        }
        #endregion

        #region 事件
        public delegate void LayerQueryHandler(object sender, GeoMapLayer layer, string expression, GeoSelectionModeConstant selectionMode);
        public event LayerQueryHandler LayerQuery;

        #endregion
    }
}
