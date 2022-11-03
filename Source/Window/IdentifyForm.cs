using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using DEETU.Map;
using DEETU.Core;

namespace DEETU.Source.Window
{
    public partial class IdentifyForm : UIForm
    {
        private GeoMapLayer mLayer;
        public IdentifyForm(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;

            Initialize();
            
        }

        private void Initialize()
        {
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

                detailTable.Controls.Add(label, 0, i);
                detailTable.Controls.Add(textBox, 1, i);

            }
            GeoFeatures features = mLayer.SelectedFeatures;

            for (int i = 0; i < features.Count; i++)
            {
                ListViewItem item = new ListViewItem(features.GetItem(i).Attributes.GetItem(0).ToString());
                if (item.Text.IsNullOrEmpty())
                {
                    item.Text = "Untitled" + item.Index.ToString();
                }
                item.Tag = features.GetItem(i);

                featureList.Items.Add(item);

            }

            featureList.SelectedIndexChanged += featureList_SelectedIndexChanged;
            if (featureList.Items.Count > 0)
                featureList.Items[0].Selected = true;
        }

        private void featureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.SelectedFeatures.Clear();
            
            if (!featureList.SelectedItems.IsNullOrEmpty())
            {
                //只显示第一个被选中的要素
                GeoFeature feature = featureList.SelectedItems[0].Tag as GeoFeature;
                ShowFeatureOnDetailTable(feature);
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
    }
}
