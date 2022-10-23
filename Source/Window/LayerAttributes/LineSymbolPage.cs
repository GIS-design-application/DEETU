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
using DEETU.Tool;
using DEETU.Core;

namespace DEETU.Source.Window
{
    public partial class LineSymbolPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        #endregion
        public LineSymbolPage(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;

            renderMethodCB.SelectedIndex = (int)layer.Renderer.RendererType;
            
            InitializeTabs();
        }

        private void renderMethodCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderTabControl.SelectedIndex = renderMethodCB.SelectedIndex;
        }

        private void InitializeTabs()
        {
            // Backgroud color
            simpleTab.BackColor = this.BackColor;
            uniqueValueTab.BackColor = this.BackColor;
            classBreakTab.BackColor = this.BackColor;
            // 一些基本的属性
            GeoFields fields = mLayer.AttributeFields;
            for (int i = 0; i < fields.Count; i++)
            {
                uniqueFieldComboBox.Items.Add(fields.GetItem(i).Name);
                classFieldComboBox.Items.Add(fields.GetItem(i).Name);
            }
            foreach(GeoSimpleLineSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleLineSymbolStyleConstant)))
            {
                styleComboBox.Items.Add(s.ToString());
            }

            // 对于不同的渲染模式进行配置
            if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
                GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)simpleRenderer.Symbol;
                lineColorPicker.Value = lineSymbol.Color;
                sizeDoubleUpDown.Value = lineSymbol.Size;
                styleComboBox.SelectedIndex = (int)lineSymbol.Style;
                // 对于一开始是simple的图层把simple symbol当做剩下两种方法的default
                uniqueTableLayoutPanel.Controls.Add(GetLineSymbolButton(lineSymbol), 1, 2);
                classTableLayoutPanel.Controls.Add(GetLineSymbolButton(lineSymbol), 1, 2);
            }
            else if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                GeoUniqueValueRenderer uniqueValueRenderer = (GeoUniqueValueRenderer)mLayer.Renderer;
                uniqueFieldComboBox.SelectedItem = uniqueValueRenderer.Field;
                Button defaultSymbolButton = GetLineSymbolButton((GeoSimpleLineSymbol)uniqueValueRenderer.DefaultSymbol);
                uniqueTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
                for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
                {
                    GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)uniqueValueRenderer.GetSymbol(i);
                    Button symbolButton = GetLineSymbolButton(lineSymbol);
                    uniqueDataGridView.AddRow(symbolButton, uniqueValueRenderer.GetValue(i));
                }
            }
            else
            {
                GeoClassBreaksRenderer classBreaksRenderer = (GeoClassBreaksRenderer)mLayer.Renderer;
                classFieldComboBox.SelectedItem = classBreaksRenderer.Field;
                Button defaultSymbolButton = GetLineSymbolButton((GeoSimpleLineSymbol)classBreaksRenderer.DefaultSymbol);
                classTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
                for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
                {
                    GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)classBreaksRenderer.GetSymbol(i);
                    Button symbolButton = GetLineSymbolButton(lineSymbol);
                    uniqueDataGridView.AddRow(symbolButton, classBreaksRenderer.GetBreakValue(i));
                }
            }
            
        }

        private Button GetLineSymbolButton(GeoSimpleLineSymbol symbol)
        {
            Button sButton = new Button();
            sButton.BackColor = symbol.Color;
            sButton.Text = "";
            sButton.Dock = DockStyle.Fill;
            sButton.FlatAppearance.BorderColor = symbol.Color;
            sButton.FlatAppearance.BorderSize = (int)symbol.Size;
            sButton.MouseClick += SymbolGridButton_MouseClick;
            return sButton;
        }

        private void SymbolGridButton_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
