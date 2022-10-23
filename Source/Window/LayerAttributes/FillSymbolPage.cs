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
    public partial class FillSymbolPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        #endregion
        public FillSymbolPage(GeoMapLayer layer)
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
                edgeStyleComboBox.Items.Add(s.ToString());
            }

            // 对于不同的渲染模式进行配置
            if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
                GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)simpleRenderer.Symbol;
                fillColorPicker.Value = fillSymbol.Color;
                edgeColorPicker.Value = fillSymbol.Outline.Color;
                edgeWidthDoubleUpDown.Value = fillSymbol.Outline.Size;
                edgeStyleComboBox.SelectedIndex = (int)fillSymbol.Outline.Style;
                // 对于一开始是simple的图层把simple symbol当做剩下两种方法的default
                uniqueTableLayoutPanel.Controls.Add(GetFillSymbolButton(fillSymbol), 1, 2);
                classTableLayoutPanel.Controls.Add(GetFillSymbolButton(fillSymbol), 1, 2);
            }
            else if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                GeoUniqueValueRenderer uniqueValueRenderer = (GeoUniqueValueRenderer)mLayer.Renderer;
                uniqueFieldComboBox.SelectedItem = uniqueValueRenderer.Field;
                Button defaultSymbolButton = GetFillSymbolButton((GeoSimpleFillSymbol)uniqueValueRenderer.DefaultSymbol);
                uniqueTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
                for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
                {
                    GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)uniqueValueRenderer.GetSymbol(i);
                    Button symbolButton = GetFillSymbolButton(fillSymbol);
                    uniqueDataGridView.AddRow(symbolButton, uniqueValueRenderer.GetValue(i));
                }
            }
            else
            {
                GeoClassBreaksRenderer classBreaksRenderer = (GeoClassBreaksRenderer)mLayer.Renderer;
                classFieldComboBox.SelectedItem = classBreaksRenderer.Field;
                Button defaultSymbolButton = GetFillSymbolButton((GeoSimpleFillSymbol)classBreaksRenderer.DefaultSymbol);
                classTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
                for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
                {
                    GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)classBreaksRenderer.GetSymbol(i);
                    Button symbolButton = GetFillSymbolButton(fillSymbol);
                    uniqueDataGridView.AddRow(symbolButton, classBreaksRenderer.GetBreakValue(i));
                }
            }
            
        }

        private Button GetFillSymbolButton(GeoSimpleFillSymbol symbol)
        {
            Button sButton = new Button();
            sButton.BackColor = symbol.Color;
            sButton.Text = "";
            sButton.Dock = DockStyle.Fill;
            sButton.FlatAppearance.BorderColor = symbol.Outline.Color;
            sButton.FlatAppearance.BorderSize = (int)symbol.Outline.Size;
            sButton.MouseClick += SymbolGridButton_MouseClick;
            return sButton;
        }

        private void SymbolGridButton_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
            
        }
    }
}
