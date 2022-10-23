using Sunny.UI;
using DEETU.Core;
using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEETU.Source.Window.LayerAttributes
{
    public partial class EditMarkerSymbolForm : UITitlePage
    {
        private GeoSimpleMarkerSymbol mMarkerSymbol;
        public EditMarkerSymbolForm(GeoSimpleMarkerSymbol markerSymbol)
        {
            mMarkerSymbol = markerSymbol;
            InitializeComponent();
            // markerColorPicker.Value = mMarkerSymbol.Color;
            // markerStyleComboBox.SelectedIndex = (int)mMarkerSymbol.Style;
            // sizeDoubleUpDown.Value = mMarkerSymbol.Size;
        }

        private void markerColorPicker_ValueChanged(object sender, Color value)
        {
            mMarkerSymbol.Color = value;
        }

        private void markerStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mMarkerSymbol.Style = (GeoSimpleMarkerSymbolStyleConstant)markerStyleComboBox.SelectedIndex;
        }

        private void sizeDoubleUpDown_ValueChanged(object sender, double value)
        {
            mMarkerSymbol.Size = value;
        }
    }
}
