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
    public partial class EditLineSymbolForm : UITitlePage
    {
        private GeoSimpleLineSymbol mLineSymbol;
        public EditLineSymbolForm(GeoSimpleLineSymbol lineSymbol)
        {
            mLineSymbol = lineSymbol;
            InitializeComponent();
            // sizeDoubleUpDown.Value = mLineSymbol.Size;
            // styleComboBox.SelectedIndex = (int)mLineSymbol.Style;
            // lineColorPicker.Value = mLineSymbol.Color;
        }

        private void sizeDoubleUpDown_ValueChanged(object sender, double value)
        {
            mLineSymbol.Size = value;
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLineSymbol.Style = (GeoSimpleLineSymbolStyleConstant)styleComboBox.SelectedIndex;
        }

        private void lineColorPicker_ValueChanged(object sender, Color value)
        {
            mLineSymbol.Color = value;
        }
    }
}
