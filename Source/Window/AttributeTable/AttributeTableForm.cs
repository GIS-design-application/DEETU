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
                mLayer.SelectedFeatures.Add(mLayer.Features.GetItem(row.Index));
            }
            
            MapRedraw?.Invoke(this);
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            mIsEditing = !mIsEditing;
            startEditToolStripButton.Checked = mIsEditing;
            MapEditStatusChanged?.Invoke(this, mIsEditing);
            SetEdit();

            if (mIsEditing)
            {
                startEditToolStripButton.Image = new Bitmap("./icons/edit_off.png");
                startEditToolStripButton.ToolTipText = "结束编辑";
            }
            else
            {
                startEditToolStripButton.Image = new Bitmap("./icons/edit.png");
                startEditToolStripButton.ToolTipText = "开始编辑";
            }

        }

        private void saveEditToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void addFeatureToolStripButton_Click(object sender, EventArgs e)
        {
            GeoFeature newFeature = mLayer.GetNewFeature();
            mLayer.Features.Add(newFeature);
            ReloadPages();
        }

        private void removeFeatureToolStripButton_Click(object sender, EventArgs e)
        {
            if (mLayer.SelectedFeatures.Count < 0)
            {
                UIMessageBox.ShowError("请选择图层", false);
            }

            for (int i = 0; i < mLayer.SelectedFeatures.Count; i++)
            {
                mLayer.Features.Remove(mLayer.SelectedFeatures.GetItem(i));
            }
            ReloadPages();
            MapRedraw?.Invoke(this);
        }

        private void addFieldStripButton_Click(object sender, EventArgs e)
        {

        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {

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
        }

        private void removeSelectToolStripButton_Click(object sender, EventArgs e)
        {
            // ban selectedChanged
            //featureList.SelectedIndexChanged -= featureList_SelectedIndexChanged;
            for (int i = 1; i < featureList.Items.Count; i++)
            {
                featureList.Items[i].Selected = false;
            }
            // recover selectedChanged
            featureList.SelectedIndexChanged += featureList_SelectedIndexChanged;
            featureList.Items[0].Selected = false;
            
        }
        #endregion

        #region 私有函数
        private void InitializeFormPage()
        {
            // 先禁用选择改变事件 
            featureList.SelectedIndexChanged -= featureList_SelectedIndexChanged;

            // Detailed panel
            GeoFields fields = mLayer.AttributeFields;
            detailTable.RowCount = fields.Count;

            for (int i = 0; i < fields.Count; i++)
            {
                // label
                UILabel label = new UILabel();
                label.Text = fields.GetItem(i).AliaName;
                label.Font = new System.Drawing.Font("微软雅黑", 10f);
                label.Dock = DockStyle.Fill;

                UITextBox textBox = new UITextBox();
                textBox.Font = new System.Drawing.Font("微软雅黑", 10f);
                textBox.ReadOnly = false;
                textBox.Dock = DockStyle.Fill;

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
            // 复用DataGridViewChanged
            featureDataGridView.SelectionChanged -= featureDataGridView_SelectionChanged;

            GeoDataTable sDataTable = new GeoDataTable(mLayer);
            // Columns
            GeoFields fields = mLayer.AttributeFields;
            for (int i = 0; i < fields.Count; i++)
            {
                featureDataGridView.AddColumn(fields.GetItem(i).AliaName, null);
                featureDataGridView.Columns[i].DefaultCellStyle.Font = (new Font("微软雅黑", 10f));
                //featureDataGridView.Columns[i].ReadOnly = true;
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

        }

        private void ReloadPages()
        {
            detailTable.Controls.Clear();
            featureList.Clear();
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
        #endregion

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void copyStripButton_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}
