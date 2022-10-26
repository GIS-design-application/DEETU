using DEETU.Core;
using DEETU.Map;
using DEETU.Tool;
using Sunny.UI;

namespace DEETU.Source.Window.LayerAttributes
{
    public partial class EditSimpleSymbolForm : UIMainFrame
    {
        public EditSimpleSymbolForm(GeoSymbol symbol)
        {
            InitializeComponent();
            switch (symbol.SymbolType)
            {
                case GeoSymbolTypeConstant.SimpleFillSymbol:
                    EditFillSymbolPage FillPage = new EditFillSymbolPage((GeoSimpleFillSymbol)symbol);
                    AddPage(FillPage);
                    this.Size = FillPage.Size;
                    break;
                case GeoSymbolTypeConstant.SimpleLineSymbol:
                    EditLineSymbolPage LinePage = new EditLineSymbolPage((GeoSimpleLineSymbol)symbol);
                    AddPage(LinePage);
                    this.Size = LinePage.Size;
                    break;
                case GeoSymbolTypeConstant.SimpleMarkerSymbol:
                    EditMarkerSymbolPage MarkerPage = new EditMarkerSymbolPage((GeoSimpleMarkerSymbol)symbol);
                    AddPage(MarkerPage);
                    this.Size = MarkerPage.Size;                    
                    break;
                default:
                    break;
            }

        }
    }
}
