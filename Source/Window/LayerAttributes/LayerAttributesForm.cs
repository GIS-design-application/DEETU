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
using DEETU.Tool;

namespace DEETU.Source.Window
{
    public partial class LayerAttributesForm : UIAsideHeaderMainFooterFrame
    {
        #region 字段
        private GeoMapLayer mLayer;
        private GeoMapLayer mTemporaryLayer;
        private InfoPage mInfoPage;
        private FieldPage mFieldPage;
        #endregion

        public LayerAttributesForm(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;
            mTemporaryLayer = layer.Clone();

            mInfoPage = new InfoPage(mLayer);
            AddPage(mInfoPage, 1);// 需要和下面的实时同步
            switch (mTemporaryLayer.ShapeType)
            {
                case GeoGeometryTypeConstant.Point:
                    AddPage(new MarkerSymbolPage(mTemporaryLayer), 2);
                    break;
                case GeoGeometryTypeConstant.MultiPolyline:
                    AddPage(new LineSymbolPage(mTemporaryLayer), 2);
                    break;
                case GeoGeometryTypeConstant.MultiPolygon:
                    AddPage(new FillSymbolPage(mTemporaryLayer), 2);
                    break;
                default:
                    break;
            }
            mFieldPage = new FieldPage(mLayer);
            mFieldPage.FieldEdited += mInfoPage.FieldPage_FieldEdited;
            AddPage(mFieldPage, 3);
            AddPage(new AnnotationPage(mTemporaryLayer), 4);
            
            Aside.CreateNode("信息", 112, 24, 1); 
            Aside.CreateNode("符号化", 61445, 24, 2); 
            Aside.CreateNode("字段", 61641, 24, 3); 
            Aside.CreateNode("注记", 61483, 24, 4); 
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (mTemporaryLayer.Renderer != null)
            {
                mLayer.Renderer = mTemporaryLayer.Renderer;
                mLayer.LabelRenderer = mTemporaryLayer.LabelRenderer;
                this.Close();
            }
            else
            {
                MessageBox.Show("渲染失败！");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
