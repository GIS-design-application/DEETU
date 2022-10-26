using DEETU.Core;
using DEETU.Map;
using DEETU.Tool;
using Sunny.UI;

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
                    EditFillSymbolPage FillPage = new EditFillSymbolPage((GeoSimpleFillSymbol)(layer.Renderer as GeoSimpleRenderer).Symbol);
                    AddPage(FillPage);
                    this.Size = FillPage.Size;
                    break;
                case GeoGeometryTypeConstant.MultiPolyline:
                    EditLineSymbolPage LinePage = new EditLineSymbolPage((GeoSimpleLineSymbol)(layer.Renderer as GeoSimpleRenderer).Symbol);
                    AddPage(LinePage);
                    this.Size = LinePage.Size;
                    break;
                case GeoGeometryTypeConstant.Point:
                    EditMarkerSymbolPage MarkerPage = new EditMarkerSymbolPage((GeoSimpleMarkerSymbol)(layer.Renderer as GeoSimpleRenderer).Symbol);
                    AddPage(MarkerPage);
                    this.Size = MarkerPage.Size;                    
                    break;
                default:
                    break;
            }

        }
    }
}
