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
            GeoValueTypeConstant valueType = mLayer.AttributeFields.GetItem(fieldIdx).ValueType;
            valueListBox.Items.Clear();
            GeoFeatures features = mLayer.Features;
            List<object> valueList = new List<object>();
            for (int i = 0; i < features.Count; i++)
            {
                valueList.Add(features.GetItem(i).Attributes.GetItem(fieldIdx).ToString());
            }

            valueList.Sort();
            for (int i = 0; i < features.Count; i++)
            {
                valueListBox.Items.Add(valueList[i]);
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
            if (searchTextBox.Text.IsNullOrWhiteSpace())
                return;
            else
            {
                List<string> itemList = valueListBox.Items.Cast<string>().ToList();
                valueListBox.SelectedIndex = itemList.FindIndex((string s) => s.Contains(searchTextBox.Text));
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
        }
        #endregion

        #region 事件
        public delegate void LayerQueryHandler(object sender, GeoMapLayer layer, string expression, GeoSelectionModeConstant selectionMode);
        public event LayerQueryHandler LayerQuery;

        #endregion
    }
}
