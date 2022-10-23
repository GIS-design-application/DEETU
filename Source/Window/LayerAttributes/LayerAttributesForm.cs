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

namespace DEETU.Source.Window
{
    public partial class LayerAttributesForm : UIAsideMainFrame
    {
        #region 字段
        private GeoMapLayer mLayer;
        #endregion
        public LayerAttributesForm(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;

            AddPage(new InfoPage(layer), 1);
            AddPage(new SymbolPage(layer), 2);
            AddPage(new FieldPage(layer), 3);
            AddPage(new AnnotationPage(layer), 4);
            
            Aside.CreateNode("信息", 61451, 24, 1); 
            Aside.CreateNode("符号化", 61452, 24, 2); 
            Aside.CreateNode("字段", 61453, 24, 3); 
            Aside.CreateNode("注记", 61454, 24, 4); 
        }
    }
}
