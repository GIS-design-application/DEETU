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
        #endregion

        public LayerAttributesForm(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;
            mTemporaryLayer = layer.Clone();

            AddPage(new InfoPage(layer), 1);
            switch (layer.ShapeType)
            {
                case GeoGeometryTypeConstant.Point:
                    AddPage(new MarkerSymbolPage(layer), 2);
                    break;
                case GeoGeometryTypeConstant.MultiPolyline:
                    AddPage(new LineSymbolPage(layer), 2);
                    break;
                case GeoGeometryTypeConstant.MultiPolygon:
                    AddPage(new FillSymbolPage(layer), 2);
                    break;
                default:
                    break;
            }
            AddPage(new FieldPage(layer), 3);
            AddPage(new AnnotationPage(layer), 4);
            
            Aside.CreateNode("信息", 61451, 24, 1); 
            Aside.CreateNode("符号化", 61452, 24, 2); 
            Aside.CreateNode("字段", 61453, 24, 3); 
            Aside.CreateNode("注记", 61454, 24, 4); 
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            mLayer = mTemporaryLayer;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
