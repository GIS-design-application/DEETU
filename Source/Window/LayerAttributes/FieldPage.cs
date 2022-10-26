using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using DEETU.Map;
using DEETU.Core;

namespace DEETU.Source.Window
{
    public partial class FieldPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        #endregion
        public FieldPage(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;
            InitializeField();
            
        }

        #region 私有函数
        private void InitializeField()
        {
            GeoFields fields = mLayer.AttributeFields;
            if (fields.Count == 0)
                fieldDataGridView.Visible = false;
            for (int i = 0; i < fields.Count; i++)
            {
                GeoField f = fields.GetItem(i);
                fieldDataGridView.AddRow(f.Name, f.AliaName, f.ValueType.ToString());
            }
            fieldDataGridView.ReadOnly = true;
            if (mLayer.IsDirty == false)
            {
                editButton.Selected = false;
                fieldDataGridView.ReadOnly = true;
                addFieldButton.SetDisabled();
                removeFieldButton.SetDisabled();
            }
            else
            {
                editButton.Selected = true;
                fieldDataGridView.ReadOnly = false;
                addFieldButton.SetEnabled();
                removeFieldButton.SetEnabled();
            }
            
        }

        private void addFieldButton_Click(object sender, EventArgs e)
        {
            UIEditForm editForm = new UIEditForm();
            editForm.ShowDialog();
        }

        private void removeFieldButton_Click(object sender, EventArgs e)
        {
            fieldDataGridView.Rows.RemoveAt(fieldDataGridView.RowCount - 1);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editButton.Selected = !editButton.Selected;
            if (editButton.Selected)
            {
                mLayer.IsDirty = true;
                fieldDataGridView.ReadOnly = false;
                addFieldButton.SetEnabled();
                removeFieldButton.SetEnabled();
            }
            else
            {
                mLayer.IsDirty = false;
                fieldDataGridView.ReadOnly = true;
                addFieldButton.SetDisabled();
                removeFieldButton.SetDisabled();
            }
        }
        
        // TODO: 
        // 1. 把Dirty换成Editing
        // 2. editButton尽可能和主界面同步
        // 3. 结束编辑之后的同步，推送到撤销，以及infopage的更新。 还有一种方案就是不要editing按钮，但是有点奇怪。

        #endregion
    }
}
