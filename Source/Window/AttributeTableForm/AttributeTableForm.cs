using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using DEETU.Core;
using DEETU.Map;
using DEETU.IO;
using DEETU.Tool;
using DEETU.Geometry;

namespace DEETU.Source.Window
{
    public partial class AttributeTableForm : UIForm
    {
        #region 字段
        private GeoMapLayer mLayer;
        bool mIsEditing = false;

        #endregion
        public AttributeTableForm(GeoMapLayer layer, bool isEditing)
        {
            InitializeComponent();
            mLayer = layer;
            mIsEditing = isEditing;

            InitializeFormPage();
            InitializeGridPage();

            SetEdit();

            Header.SelectedIndex = 0;
        }

        #region 事件处理函数
        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            uiTabControl1.SelectedIndex = menuIndex;
        }

        private void featureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear all
            mLayer.SelectedFeatures.Clear();
            foreach (ListViewItem item in featureList.Items)
                item.ImageIndex = 0;
            
            if (!featureList.SelectedItems.IsNullOrEmpty())
            {
                //只显示第一个被选中的要素
                GeoFeature feature = featureList.SelectedItems[0].Tag as GeoFeature;
                ShowFeatureOnDetailTable(feature);
                foreach (ListViewItem item in featureList.SelectedItems)
                {
                    item.ImageIndex = 1;
                    mLayer.SelectedFeatures.Add(item.Tag as GeoFeature);
                }
            }
            MapRedraw?.Invoke(this);
        }

        private void reloadToolStripButton_Click
            (object sender, EventArgs e)
        {
            ReloadPages();
        }


        private void featureDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Clear all
            mLayer.SelectedFeatures.Clear();

            foreach (DataGridViewRow row in featureDataGridView.SelectedRows)
            {
                mLayer.SelectedFeatures.Add(row.Tag as GeoFeature);
            }
            
            MapRedraw?.Invoke(this);
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            mIsEditing = !mIsEditing;
            MapEditStatusChanged?.Invoke(this, mIsEditing);
            SetEdit();
        }

        private void saveEditToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void addFeatureToolStripButton_Click(object sender, EventArgs e)
        {
            //GeoFeature newFeature = mLayer.GetNewFeature();
            //mLayer.Features.Add(newFeature);
            //ReloadPages();
            FeatureAdded?.Invoke(this, mLayer);
        }

        private void removeFeatureToolStripButton_Click(object sender, EventArgs e)
        {
            if (mLayer.SelectedFeatures.Count == 0)
            {
                UIMessageBox.ShowError("请选择要素", false);
                return;
            }
            FeatureRemoved?.Invoke(this, mLayer);

            //for (int i = 0; i < mLayer.SelectedFeatures.Count; i++)
            //{
            //    mLayer.Features.Remove(mLayer.SelectedFeatures.GetItem(i));
            //}
            //ReloadPages();
            //MapRedraw?.Invoke(this);
        }

        private void addFieldStripButton_Click(object sender, EventArgs e)
        {
            UIEditOption option = new UIEditOption();
            option.AutoLabelWidth = true;
            option.Text = "增加一个字段";
            option.AddText("Name", "字段名称", "", true);
            option.AddText("AliasName", "别名", "", false);
            option.AddCombobox("Type", "数据类型", Enum.GetNames(typeof(GeoValueTypeConstant)));

            UIEditForm editForm = new UIEditForm(option);
            editForm.ShowDialog();

            if (editForm.IsOK)
            {
                GeoField newField = new GeoField((string)editForm["Name"], (GeoValueTypeConstant)editForm["Type"]);
                newField.AliaName = (string)editForm["AliasName"];
                mLayer.AttributeFields.Append(newField);
                ReloadPages();
            }
        }

        private void removeFieldToolStripButton_Click(object sender, EventArgs e)
        {
            GeoFields fields = mLayer.AttributeFields;
            fields.RemoveAt(fields.Count - 1);
        }

        private void selectByExpressionToolStripButton_Click(object sender, EventArgs e)
        {

            SelectedByExpressionForm expressionForm = new SelectedByExpressionForm(mLayer);
            expressionForm.LayerQuery += ExpressionForm_LayerQuery;
            expressionForm.ShowDialog();
        }

        private void ExpressionForm_LayerQuery(object sender, GeoMapLayer layer, string expression, GeoSelectionModeConstant selectionMode)
        {
            LayerQuery?.Invoke(this, mLayer, expression, selectionMode);
            ReloadPages();           
        }

        private void selectAllToolStripButton_Click(object sender, EventArgs e)
        {
            if (mLayer.Features.Count == 0)
                return;
            // ban selectedChanged
            featureList.SelectedIndexChanged -= featureList_SelectedIndexChanged;
            for (int i = 1; i < featureList.Items.Count; i++)
            {
                featureList.Items[i].Selected = true;
            }
            // recover selectedChanged
            featureList.SelectedIndexChanged += featureList_SelectedIndexChanged;
            featureList.Items[0].Selected = true;
            MapRedraw?.Invoke(this);
            InitializeGridPage();
        }

        private void removeSelectToolStripButton_Click(object sender, EventArgs e)
        {
            if (mLayer.Features.Count == 0)
                return;
            // ban selectedChanged
            featureList.SelectedIndexChanged -= featureList_SelectedIndexChanged;
            for (int i = 1; i < featureList.Items.Count; i++)
            {
                featureList.Items[i].Selected = false;
            }
            // recover selectedChanged
            featureList.SelectedIndexChanged += featureList_SelectedIndexChanged;
            featureList.Items[0].Selected = false;
            MapRedraw?.Invoke(this);
            InitializeGridPage();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            FeatureCut?.Invoke(this, mLayer);
        }

        private void copyStripButton_Click(object sender, EventArgs e)
        {
            FeatureCopied?.Invoke(this, mLayer);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            FeaturePasted?.Invoke(this, mLayer);
        }

        private void featureDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (featureDataGridView.SelectedCells.IsNullOrEmpty())
                return;
            DataGridViewCell cell = featureDataGridView.SelectedCells[0];
            GeoFeature feature = mLayer.Features.GetItem(cell.RowIndex);
            GeoField field = mLayer.AttributeFields.GetItem(cell.ColumnIndex);
            try
            {
                switch (field.ValueType)
                {
                    case GeoValueTypeConstant.dInt16:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToInt16(cell.Value));
                        break;
                    case GeoValueTypeConstant.dInt32:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToInt32(cell.Value));
                        break;
                    case GeoValueTypeConstant.dInt64:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToInt64(cell.Value));
                        break;
                    case GeoValueTypeConstant.dSingle:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToSingle(cell.Value));
                        break;
                    case GeoValueTypeConstant.dDouble:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToDouble(cell.Value));
                        break;
                    case GeoValueTypeConstant.dText:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToString(cell.Value));
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
            catch (Exception error)
            {
                UIMessageBox.ShowError("错误的数据类型！\n" + error.Message, false);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            UITextBox textBox = sender as UITextBox;
            int featureIdx = featureList.SelectedItems[0].Index;
            int fieldIdx = detailTable.GetRow(textBox);
            GeoFeature feature = mLayer.Features.GetItem(featureIdx);
            GeoField field = mLayer.AttributeFields.GetItem(fieldIdx);
            if (textBox.Text.IsNullOrWhiteSpace())
                return;
            try
            {
                switch (field.ValueType)
                {
                    case GeoValueTypeConstant.dInt16:
                        feature.Attributes.SetItem(fieldIdx, Convert.ToInt16(textBox.Text));
                        break;
                    case GeoValueTypeConstant.dInt32:
                        feature.Attributes.SetItem(fieldIdx, Convert.ToInt32(textBox.Text));
                        break;
                    case GeoValueTypeConstant.dInt64:
                        feature.Attributes.SetItem(fieldIdx, Convert.ToInt64(textBox.Text));
                        break;
                    case GeoValueTypeConstant.dSingle:
                        feature.Attributes.SetItem(fieldIdx, Convert.ToSingle(textBox.Text));
                        break;
                    case GeoValueTypeConstant.dDouble:
                        feature.Attributes.SetItem(fieldIdx, Convert.ToDouble(textBox.Text));
                        break;
                    case GeoValueTypeConstant.dText:
                        feature.Attributes.SetItem(fieldIdx, (textBox.Text));
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
            catch (Exception error)
            {
                UIMessageBox.ShowError("错误的数据类型！\n" + error.Message, false);
            }
        }

        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiTabControl1.SelectedIndex == 0)
                InitializeFormPage();
            else
                InitializeGridPage();
        }

        private void featureDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (featureDataGridView.SelectedCells.IsNullOrEmpty())
                return;
            DataGridViewCell cell = featureDataGridView.SelectedCells[0];
            GeoFeature feature = mLayer.Features.GetItem(cell.RowIndex);
            GeoField field = mLayer.AttributeFields.GetItem(cell.ColumnIndex);
            if (cell.Value.ToString().IsNullOrEmpty())
                return;
            try
            {
                switch (field.ValueType)
                {
                    case GeoValueTypeConstant.dInt16:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToInt16(cell.Value));
                        break;
                    case GeoValueTypeConstant.dInt32:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToInt32(cell.Value));
                        break;
                    case GeoValueTypeConstant.dInt64:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToInt64(cell.Value));
                        break;
                    case GeoValueTypeConstant.dSingle:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToSingle(cell.Value));
                        break;
                    case GeoValueTypeConstant.dDouble:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToDouble(cell.Value));
                        break;
                    case GeoValueTypeConstant.dText:
                        feature.Attributes.SetItem(cell.ColumnIndex, Convert.ToString(cell.Value));
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
            catch (Exception error)
            {
                UIMessageBox.ShowError("错误的数据类型！\n" + error.Message, false);
            }
        }

        #endregion

        #region 私有函数
        private void InitializeFormPage()
        {
            // 先禁用选择改变事件 
            featureList.SelectedIndexChanged -= featureList_SelectedIndexChanged;

            detailTable.Controls.Clear();
            featureList.Clear();

            // Detailed panel
            GeoFields fields = mLayer.AttributeFields;
            detailTable.RowCount = fields.Count;

            for (int i = 0; i < fields.Count; i++)
            {
                // label
                UILabel label = new UILabel();
                label.Text = fields.GetItem(i).AliaName;
                label.Font = new System.Drawing.Font("微软雅黑", 10f);
                label.Dock = DockStyle.Top;

                UITextBox textBox = new UITextBox();
                textBox.Font = new System.Drawing.Font("微软雅黑", 10f);
                textBox.ReadOnly = false;
                textBox.Dock = DockStyle.Top;
                textBox.TextChanged += TextBox_TextChanged;

                detailTable.Controls.Add(label, 0, i);
                detailTable.Controls.Add(textBox, 1, i);

            }

            // List View
            GeoFeatures features = mLayer.Features;
            GeoFeatures selectedFeatures = mLayer.SelectedFeatures;
            for (int i = 0; i < features.Count; i++)
            {
                ListViewItem item = new ListViewItem(features.GetItem(i).Attributes.GetItem(0).ToString());
                if (item.Text.IsNullOrEmpty())
                {
                    item.Text = "Untitled";
                }
                item.Tag = features.GetItem(i);
                item.ImageIndex = 0;

                for (int j = 0; j < selectedFeatures.Count; j++)
                {
                    if (selectedFeatures.GetItem(j) == features.GetItem(i))
                    {
                        item.ImageIndex = 1;
                        item.Selected = true;
                        
                        break;
                    }
                }
                featureList.Items.Add(item);
            }

            if (featureList.SelectedItems.Count > 0)
            {
                GeoFeature feature = featureList.SelectedItems[0].Tag as GeoFeature;
                ShowFeatureOnDetailTable(feature);
            }
            
            // 复用选择改变事件 
            featureList.SelectedIndexChanged += featureList_SelectedIndexChanged;

        }


        private void InitializeGridPage()
        {
            // 禁用DataGridViewChanged
            featureDataGridView.SelectionChanged -= featureDataGridView_SelectionChanged;

            featureDataGridView.ClearAll();
            // Columns
            GeoFields fields = mLayer.AttributeFields;
            for (int i = 0; i < fields.Count; i++)
            {
                featureDataGridView.AddColumn(fields.GetItem(i).AliaName, null);
                featureDataGridView.Columns[i].DefaultCellStyle.Font = (new Font("微软雅黑", 10f));
                featureDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }

            GeoFeatures features = mLayer.Features;
            GeoFeatures selectedFeatures = mLayer.SelectedFeatures;
            for (int i = 0; i < features.Count; i++)
            {
                GeoFeature feature = features.GetItem(i);
                object[] rowValue = new object[fields.Count];
                for (int j = 0; j < feature.Attributes.Count; j++)
                {
                    rowValue[j] = feature.Attributes.GetItem(j);
                }
                featureDataGridView.AddRow(rowValue);
                featureDataGridView.Rows[i].Tag = feature;
                

                for (int j = 0; j < selectedFeatures.Count; j++)
                {
                    if (selectedFeatures.GetItem(j) == features.GetItem(i))
                    {
                        featureDataGridView.Rows[i].Selected = true;
                        break;
                    }
                }
            }

            // 复用DataGridViewChanged
            featureDataGridView.SelectionChanged += featureDataGridView_SelectionChanged;

            // !解决第一次点edit之后featureDataGridView无法编辑的问题，可能是控件本身的bug，用了一个非常sb的解决方式
            featureDataGridView.ReadOnly = !featureDataGridView.ReadOnly;
            featureDataGridView.ReadOnly = !featureDataGridView.ReadOnly;

        }

        private void ReloadPages()
        {
            InitializeFormPage();
            InitializeGridPage();
        }

        private void ShowFeatureOnDetailTable(GeoFeature feature)
        {
            for (int i = 0; i < feature.Attributes.Count; i++)
            {
                UITextBox textBox = detailTable.GetControlFromPosition(1, i) as UITextBox;
                textBox.Text = feature.Attributes.GetItem(i).ToString();
            }
        }

        private void SetEdit()
        {
            startEditToolStripButton.Checked = mIsEditing;
            if (mIsEditing)
            {
                startEditToolStripButton.Image = new Bitmap("./icons/edit_off.png");
                startEditToolStripButton.ToolTipText = "结束编辑";
                featureDataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            }
            else
            {
                startEditToolStripButton.Image = new Bitmap("./icons/edit.png");
                startEditToolStripButton.ToolTipText = "开始编辑";
                featureDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            saveEditToolStripButton.Enabled = mIsEditing;
            cutToolStripButton.Enabled = mIsEditing;
            pasteToolStripButton.Enabled = mIsEditing;
            copyStripButton.Enabled = mIsEditing;
            addFeatureToolStripButton.Enabled = mIsEditing;
            removeFeatureToolStripButton.Enabled = mIsEditing;
            addFieldStripButton.Enabled = mIsEditing;
            removeFieldToolStripButton.Enabled = mIsEditing;

            featureDataGridView.ReadOnly = !mIsEditing;
            for (int i = 0; i < detailTable.RowCount; i++)
            {
                UITextBox textBox = detailTable.GetControlFromPosition(1, i) as UITextBox;
                textBox.ReadOnly = !mIsEditing;
            }
        }
        #endregion

        #region 事件
        public delegate void MapRedrawHandle(object sender);
        /// <summary>
        /// 使主界面中的MapControl redraw
        /// </summary>
        /// <param name="sender"></param>
        public event MapRedrawHandle MapRedraw;

        public delegate void MapEditStatusChangedHandle(object sender, bool status);
        /// <summary>
        /// Set MainPage MapControl Start editding;
        /// </summary>
        public event MapEditStatusChangedHandle MapEditStatusChanged;

        public delegate void LayerQueryHandler(object sender, GeoMapLayer layer, string expression, GeoSelectionModeConstant selectionMode);
        public event LayerQueryHandler LayerQuery;

        public delegate void FeatureEditHandle(object sender, GeoMapLayer layer);
        public event FeatureEditHandle FeatureCopied;
        public event FeatureEditHandle FeatureCut;
        public event FeatureEditHandle FeaturePasted;
        public event FeatureEditHandle FeatureAdded;
        public event FeatureEditHandle FeatureRemoved;
        #endregion

        public void MainPage_CurrentActiveLayerChanged(object sender, GeoMapLayer layer)
        {
            mLayer = layer;
            ReloadPages();
        }

        public void MainPage_EditStatusChanged(object sender, bool status)
        {
            mIsEditing = status;
            SetEdit();
        }

    }
}
