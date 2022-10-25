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
    public partial class EditMarkerSymbolPage : UITitlePage
    {
        private GeoSimpleMarkerSymbol mMarkerSymbol;
        private GeoSimpleMarkerSymbol mTempMarkerSymbol;
        public EditMarkerSymbolPage(GeoSimpleMarkerSymbol markerSymbol)
        {
            mMarkerSymbol = markerSymbol;
            mTempMarkerSymbol = mMarkerSymbol;
            InitializeComponent();

            foreach (GeoSimpleMarkerSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleMarkerSymbolStyleConstant)))
            {
                markerStyleComboBox.Items.Add(s.ToString());
            }

            markerColorPicker.Value = mMarkerSymbol.Color;
            markerStyleComboBox.SelectedIndex = (int)mMarkerSymbol.Style;
            sizeDoubleUpDown.Value = mMarkerSymbol.Size;
        }

        private void markerColorPicker_ValueChanged(object sender, Color value)
        {
            mTempMarkerSymbol.Color = value;
        }

        private void markerStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mTempMarkerSymbol.Style = (GeoSimpleMarkerSymbolStyleConstant)markerStyleComboBox.SelectedIndex;
        }

        private void sizeDoubleUpDown_ValueChanged(object sender, double value)
        {
            mTempMarkerSymbol.Size = value;
        }

        private void ConformButton_Click(object sender, EventArgs e)
        {
            mMarkerSymbol = mTempMarkerSymbol;
            this.Parent.Parent.Parent.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Parent.Parent.Hide();
        }
    }
}
