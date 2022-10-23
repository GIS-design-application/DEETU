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
    public partial class AnnotationPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        #endregion

        public AnnotationPage(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;
        }
    }
}
