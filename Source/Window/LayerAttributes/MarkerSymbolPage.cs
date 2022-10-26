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
using DEETU.Source.Window.LayerAttributes;
using System.Drawing.Drawing2D;

namespace DEETU.Source.Window
{
    public partial class MarkerSymbolPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        private readonly Color[][] Colors = new Color[][] { new Color[] { Color.Red, Color.Green }, new Color[] { Color.Red, Color.Blue }, new Color[] { Color.Green, Color.Blue } };

        #endregion
        public MarkerSymbolPage(GeoMapLayer layer)
        {
            InitializeComponent();
            // mLayer = layer.Clone();
            mLayer = layer;
            renderMethodCB.SelectedIndex = (int)layer.Renderer.RendererType;
            
            InitializeTabs();
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
            foreach(GeoSimpleMarkerSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleMarkerSymbolStyleConstant)))
            {
                markerStyleComboBox.Items.Add(s.ToString());
            }
            classColorgradComboBox.Items.AddRange(Colors);
            classColorgradComboBox.SelectedIndex = 0;
            uniqueColorgradComboBox.Items.AddRange(Colors);
            uniqueColorgradComboBox.SelectedIndex = 0;

            // 对于不同的渲染模式进行配置
            if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
                GeoSimpleMarkerSymbol markerSymbol = (GeoSimpleMarkerSymbol)simpleRenderer.Symbol;
                markerColorPicker.Value = markerSymbol.Color;
                markerStyleComboBox.SelectedIndex = (int)markerSymbol.Style;
                // 对于一开始是simple的图层把simple symbol当做剩下两种方法的default
                uniqueTableLayoutPanel.Controls.Add(GetMarkerSymbolButton(markerSymbol), 1, 2);
                classTableLayoutPanel.Controls.Add(GetMarkerSymbolButton(markerSymbol), 1, 2);
            }
            else if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                GeoUniqueValueRenderer uniqueValueRenderer = (GeoUniqueValueRenderer)mLayer.Renderer;
                uniqueFieldComboBox.SelectedItem = uniqueValueRenderer.Field;
                Button defaultSymbolButton = GetMarkerSymbolButton((GeoSimpleMarkerSymbol)uniqueValueRenderer.DefaultSymbol);
                uniqueTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
                for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
                {
                    GeoSimpleMarkerSymbol markerSymbol = (GeoSimpleMarkerSymbol)uniqueValueRenderer.GetSymbol(i);
                    Button symbolButton = GetMarkerSymbolButton(markerSymbol);
                    uniqueDataGridView.AddRow(symbolButton, uniqueValueRenderer.GetValue(i));
                }
            }
            else
            {
                GeoClassBreaksRenderer classBreaksRenderer = (GeoClassBreaksRenderer)mLayer.Renderer;
                classFieldComboBox.SelectedItem = classBreaksRenderer.Field;
                Button defaultSymbolButton = GetMarkerSymbolButton((GeoSimpleMarkerSymbol)classBreaksRenderer.DefaultSymbol);
                classTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
                for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
                {
                    GeoSimpleMarkerSymbol markerSymbol = (GeoSimpleMarkerSymbol)classBreaksRenderer.GetSymbol(i);
                    Button symbolButton = GetMarkerSymbolButton(markerSymbol);
                    uniqueDataGridView.AddRow(symbolButton, classBreaksRenderer.GetBreakValue(i));
                }
            }
            
        }

        private Button GetMarkerSymbolButton(GeoSimpleMarkerSymbol symbol)
        {
            Button sButton = new Button();
            sButton.Text = "";
            sButton.Dock = DockStyle.Fill;
            sButton.FlatAppearance.BorderSize = 0;
            sButton.BackgroundImage = CreateMarkerBitmapFromSymbol(symbol);

            MouseEventHandler handler = (sender, e) => SymbolGridButton_MouseClick(sButton, symbol);
            sButton.MouseClick += handler;

            return sButton;
        }

        private Bitmap CreateMarkerBitmapFromSymbol(GeoSimpleMarkerSymbol symbol)
        {
            Bitmap styleImage = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(styleImage);
            Rectangle sRect = new Rectangle(0, styleImage.Width, 0, styleImage.Height);
            GeoMapDrawingTools.DrawSimpleMarker(g, sRect, 0, symbol); // dpm is useless in this 
            g.Dispose();
            return styleImage;
        }


        private void SymbolGridButton_MouseClick(Button button, GeoSymbol symbol)
        {
            EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm(symbol);
            FormClosedEventHandler handle = (sender, e) => SimpleForm_FormClosed(button);
            SimpleForm.FormClosed += handle;
            SimpleForm.Show();
        }

        private void SimpleForm_FormClosed(Button button)
        {
            button.Refresh();
        }

        private void markerStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleMarkerSymbol).Style = (GeoSimpleMarkerSymbolStyleConstant)markerStyleComboBox.SelectedIndex;
        }

        private void markerColorPicker_ValueChanged(object sender, Color value)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleMarkerSymbol).Color = value;
        }

        private void uniqueFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            (mLayer.Renderer as GeoUniqueValueRenderer).Field = uniqueFieldComboBox.SelectedItem.ToString();
        }

        private void classFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            (mLayer.Renderer as GeoClassBreaksRenderer).Field = classFieldComboBox.SelectedItem.ToString();
        }

        private void UniqueColorComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            int ColorNum = Colors[e.Index].Length;
            int interval_x = r.Width / ColorNum;
            for (int i = 0; i < ColorNum; ++i)
                g.FillRectangle(new SolidBrush(Colors[e.Index][i]), new Rectangle(i * interval_x, 0, interval_x, r.Height));
            e.DrawFocusRectangle();
        }

        private void ClassBreaksComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            int ColorNum = Colors[e.Index].Length;
            int interval_x = r.Width / ColorNum;
            for (int i = 0; i < ColorNum; ++i)
                g.FillRectangle(new SolidBrush(Colors[e.Index][i]), new Rectangle(i * interval_x, 0, interval_x, r.Height));
            e.DrawFocusRectangle();
        }

        private void renderTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderMethodCB.SelectedIndex = renderTabControl.SelectedIndex;
            if (renderMethodCB.SelectedItem.ToString() == "单一符号")
                CreateSimpleRenderer();
            else if (renderMethodCB.SelectedItem.ToString() == "分级符号")
                CreateClassBreaksRenderer();
            else
                CreateUniqueValueRenderer();
        }
        private void renderMethodCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderTabControl.SelectedIndex = renderMethodCB.SelectedIndex;
            if (renderMethodCB.SelectedItem.ToString() == "单一符号")
                CreateSimpleRenderer();
            else if (renderMethodCB.SelectedItem.ToString() == "分级符号")
                CreateClassBreaksRenderer();
            else
                CreateUniqueValueRenderer();
        }

        private void CreateClassBreaksRenderer()
        {
            // 假设存在"f5"的字段且为单精度浮点型
            GeoClassBreaksRenderer sRenderer = new GeoClassBreaksRenderer();
            sRenderer.Field = "F5";
            List<double> sValues = new List<double>();
            int sFeatureCount = mLayer.Features.Count;
            int sFieldIndex = mLayer.AttributeFields.FindField(sRenderer.Field);
            for (int i = 0; i < sFeatureCount; i++)
            {
                double sValue = (float)mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                sValues.Add(sValue);
            }
            // 获取最小, 最大值, 并分为5级
            double sMinValue = sValues.Min();
            double sMaxValue = sValues.Max();
            for (int i = 0; i < 5; i++)
            {
                double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / 5;
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sRenderer.AddBreakValue(sValue, sSymbol);
            }
            Color sStartColor = Color.FromArgb(255, 255, 192, 192);
            Color sEndColor = Color.Maroon;
            sRenderer.RampColor(sStartColor, sEndColor);
            sRenderer.DefaultSymbol = new GeoSimpleFillSymbol();
            mLayer.Renderer = sRenderer;
        }

        private void CreateUniqueValueRenderer()
        {
            // 假定第一个字段名称为"名称"且为字符型

            GeoUniqueValueRenderer sRenderer = new GeoUniqueValueRenderer();
            sRenderer.Field = "名称";
            List<string> sValues = new List<string>();
            int sFeatureCount = mLayer.Features.Count;
            for (int i = 0; i < sFeatureCount; i++)
            {
                string svalue = (string)mLayer.Features.GetItem(i).Attributes.GetItem(0); // 这里使用0 假定第一个就是字符串的名称
                sValues.Add(svalue);
            }
            // 去除重复
            sValues = sValues.Distinct().ToList();
            // 生成符号
            int sValueCount = sValues.Count;
            for (int i = 0; i < sValueCount; i++)
            {
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sRenderer.AddUniqueValue(sValues[i], sSymbol);

            }
            sRenderer.DefaultSymbol = new GeoSimpleFillSymbol();
            mLayer.Renderer = sRenderer;

        }

        private void CreateSimpleRenderer()
        {
            GeoSimpleRenderer sRenderer = new GeoSimpleRenderer();
            GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
            sRenderer.Symbol = sSymbol;
            mLayer.Renderer = sRenderer;
        }
    }
}
