using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEETU.Core;
using DEETU.Tool;

namespace DEETU.Source.Window.LayerAttributes
{
    public partial class EditFillSimbolForm : UITitlePage
    {
        private GeoSimpleFillSymbol mFillSymbol;
        public EditFillSimbolForm(GeoSimpleFillSymbol fillSymbol)
        {
            mFillSymbol = fillSymbol;
            InitializeComponent();
            // fillColorPicker.Value = mFillSymbol.Color;
            // edgeColorPicker.Value = mFillSymbol.Outline.Color;
            // edgeStyleComboBox.SelectedIndex = (int)mFillSymbol.Outline.Style;
            // edgeWidthDoubleUpDown.Value = mFillSymbol.Outline.Size;
        }

        private void fillColorPicker_ValueChanged(object sender, Color value)
        {
            mFillSymbol.Color = value;
        }

        private void edgeColorPicker_ValueChanged(object sender, Color value)
        {
            mFillSymbol.Outline.Color = value;
        }

        private void edgeWidthDoubleUpDown_ValueChanged(object sender, double value)
        {
            mFillSymbol.Outline.Size = value;
        }

        private void edgeStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mFillSymbol.Outline.Style = (GeoSimpleLineSymbolStyleConstant)edgeStyleComboBox.SelectedIndex;
        }
    }
}
