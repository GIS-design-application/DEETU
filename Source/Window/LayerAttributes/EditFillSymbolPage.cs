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
    public partial class EditFillSymbolPage : UITitlePage
    {
        private GeoSimpleFillSymbol mFillSymbol;
        private GeoSimpleFillSymbol mTempFillSymbol;

        public EditFillSymbolPage(GeoSimpleFillSymbol fillSymbol)
        {
            mFillSymbol = fillSymbol;
            mTempFillSymbol = mFillSymbol;
            InitializeComponent();

            foreach (GeoSimpleLineSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleLineSymbolStyleConstant)))
            {
                edgeStyleComboBox.Items.Add(s.ToString());
            }

            fillColorPicker.Value = mFillSymbol.Color;
            edgeColorPicker.Value = mFillSymbol.Outline.Color;
            edgeStyleComboBox.SelectedIndex = (int)mFillSymbol.Outline.Style;
            edgeWidthDoubleUpDown.Value = mFillSymbol.Outline.Size;
        }

        private void fillColorPicker_ValueChanged(object sender, Color value)
        {
            mTempFillSymbol.Color = value;
        }

        private void edgeColorPicker_ValueChanged(object sender, Color value)
        {
            mTempFillSymbol.Outline.Color = value;
        }

        private void edgeWidthDoubleUpDown_ValueChanged(object sender, double value)
        {
            mTempFillSymbol.Outline.Size = value;
        }

        private void edgeStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mTempFillSymbol.Outline.Style = (GeoSimpleLineSymbolStyleConstant)edgeStyleComboBox.SelectedIndex;
        }

        private void ConformButton_Click(object sender, EventArgs e)
        {
            mFillSymbol = mTempFillSymbol;
            this.Parent.Parent.Parent.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Parent.Parent.Hide();
        }
    }
}
