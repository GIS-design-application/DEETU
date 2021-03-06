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
    // 修改线符号的简单属性
    public partial class EditLineSymbolPage : UIPage
    {
        private GeoSimpleLineSymbol mLineSymbol;
        private GeoSimpleLineSymbol mTempLineSymbol;
        public EditLineSymbolPage(GeoSimpleLineSymbol lineSymbol)
        {
            mLineSymbol = lineSymbol;
            mTempLineSymbol = (GeoSimpleLineSymbol)mLineSymbol.Clone();
            InitializeComponent();

            foreach (GeoSimpleLineSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleLineSymbolStyleConstant)))
            {
                styleComboBox.Items.Add(s.ToString());
            }

            sizeDoubleUpDown.Value = mLineSymbol.Size;
            styleComboBox.SelectedIndex = (int)mLineSymbol.Style;
            lineColorPicker.Value = mLineSymbol.Color;
        }

        private void sizeDoubleUpDown_ValueChanged(object sender, double value)
        {
            mTempLineSymbol.Size = value;
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mTempLineSymbol.Style = (GeoSimpleLineSymbolStyleConstant)styleComboBox.SelectedIndex;
        }

        private void lineColorPicker_ValueChanged(object sender, Color value)
        {
            mTempLineSymbol.Color = value;
        }

        private void ConformButton_Click(object sender, EventArgs e)
        {
            mLineSymbol.Style = mTempLineSymbol.Style;
            mLineSymbol.Size = mTempLineSymbol.Size;
            mLineSymbol.Color = mTempLineSymbol.Color;
            (this.Parent.Parent.Parent as EditSimpleSymbolForm).Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent.Parent as EditSimpleSymbolForm).Close();
        }
    }
}
