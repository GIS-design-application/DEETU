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

namespace DEETU.Source.Window
{
    public partial class AttributeTableForm : UIForm
    {
        #region 字段
        private GeoMapLayer mLayer;       

        #endregion
        public AttributeTableForm(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;

            InitializeFormPage();
            InitializeGridPage();
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

        private void reloadToolStripButton_Click(object sender, EventArgs e)
        {
            detailTable.Controls.Clear();
            featureList.Clear();
            InitializeFormPage();
            //InitializeGridPage();
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

        }

        private void saveEditToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void addFeatureToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void removeFeatureToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void addFieldStripButton_Click(object sender, EventArgs e)
        {

        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {

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
        }

        private void removeSelectToolStripButton_Click(object sender, EventArgs e)
        {
            // ban selectedChanged
            featureList.SelectedIndexChanged -= featureList_SelectedIndexChanged;
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
            GeoDataTable sDataTable = new GeoDataTable(mLayer);
            // Columns
            GeoFields fields = mLayer.AttributeFields;
            for (int i = 0; i < fields.Count; i++)
            {
                featureDataGridView.AddColumn(fields.GetItem(i).AliaName, null);
                featureDataGridView.Columns[i].DefaultCellStyle.Font = (new Font("微软雅黑", 10f));
                featureDataGridView.Columns[i].ReadOnly = true;
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


        }

        private void ShowFeatureOnDetailTable(GeoFeature feature)
        {
            for (int i = 0; i < feature.Attributes.Count; i++)
            {
                UITextBox textBox = detailTable.GetControlFromPosition(1, i) as UITextBox;
                textBox.Text = feature.Attributes.GetItem(i).ToString();
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

        public delegate void MapEditStartHandle(object sender);
        /// <summary>
        /// Set MainPage MapControl Start editding;
        /// </summary>
        public event MapEditStartHandle MapEditStart;

        #endregion

    }
}
