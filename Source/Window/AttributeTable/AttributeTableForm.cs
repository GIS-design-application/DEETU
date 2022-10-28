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
        }

        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            uiTabControl1.SelectedIndex = menuIndex;
        }

        private void InitializeFormPage()
        {
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

            }

            // List View
            GeoFeatures features = mLayer.Features;
            GeoFeatures selectedFeatures = mLayer.SelectedFeatures;
            for (int i = 0; i < features.Count; i++)
            {
                ListViewItem item = new ListViewItem(features.GetItem(i).Attributes.GetItem(0).ToString());
                item.Tag = (object)features.GetItem(i);
                item.ImageIndex = 0;

                for (int j = 0; j < selectedFeatures.Count; j++)
                {
                    if (selectedFeatures.GetItem(j) == features.GetItem(i))
                    {
                        item.ImageIndex = 1;
                        break;
                    }
                }
            }

            // image list
            Bitmap rect1 = new Bitmap(30, 30);
            Graphics g = rect1.Graphics();
            g.DrawRectangle(Color.Black, 0, 0, 30, 30);
            smallImageList.Images[0] = rect1;
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
