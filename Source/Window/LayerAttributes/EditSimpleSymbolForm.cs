using System;
using Sunny.UI;
using DEETU.Core;
using DEETU.Tool;
using DEETU.Map;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEETU.Source.Window.LayerAttributes
{
    public partial class EditSimpleSymbolForm : UIMainFrame
    {
        private GeoMapLayer mLayer;
        public EditSimpleSymbolForm(GeoMapLayer layer)
        {
            mLayer = layer;
            InitializeComponent();
            switch (mLayer.ShapeType)
            {
                case GeoGeometryTypeConstant.MultiPolygon:
                    AddPage(new EditFillSymbolPage((GeoSimpleFillSymbol)(layer.Renderer as GeoSimpleRenderer).Symbol));
                    break;
                case GeoGeometryTypeConstant.MultiPolyline:
                    AddPage(new EditLineSymbolPage((GeoSimpleLineSymbol)(layer.Renderer as GeoSimpleRenderer).Symbol));
                    break;
                case GeoGeometryTypeConstant.Point:
                    AddPage(new EditMarkerSymbolPage((GeoSimpleMarkerSymbol)(layer.Renderer as GeoSimpleRenderer).Symbol));
                    break;
                default:
                    break;
            }

        }
    }
}
