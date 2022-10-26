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
using System.Windows;

namespace DEETU.Source.Window
{
    public partial class LineSymbolPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        private readonly Color[][] Colors = new Color[][] { new Color[]{ Color.Red, Color.Green, Color.Blue } };
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
            for (int i = 0; i < Colors.Length; ++i)
            {
                Bitmap ColorGrad = new Bitmap(uniqueColorgradComboBox.Width, uniqueColorgradComboBox.Height);
                Graphics g = Graphics.FromImage(ColorGrad);
                Rectangle r = ColorGrad.Bounds(); ;
                int ColorNum = Colors[i].Length;
                int interval_x = r.Width / ColorNum;
                int interval_y = r.Height / ColorNum;
                for (int j = 0; j < ColorNum; ++j)
                    g.FillRectangle(new SolidBrush(Colors[i][j]), new Rectangle(j * interval_x, j * interval_y, interval_x, interval_y));
                uniqueColorgradComboBox.Items.Add(ColorGrad);
                classColorgradComboBox.Items.Add(ColorGrad);
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
            sButton.FlatAppearance.BorderSize = 0;
            sButton.BackgroundImage = CreateLineBitmapFromSymbol(symbol);

            MouseEventHandler handler = (sender, e) => SymbolGridButton_MouseClick();
            sButton.MouseClick += handler;

            return sButton;
        }

        private Bitmap CreateLineBitmapFromSymbol(GeoSimpleLineSymbol symbol)
        {
            Bitmap styleImage = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(styleImage);
            double dpm = 10; // I don't know the correct dpm here so I just randomly assigned a number
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawLine(sPen, new Point(0, styleImage.Height / 2), new Point(styleImage.Width, styleImage.Height / 2));
            g.Dispose();
            return styleImage;
        }


        private void SymbolGridButton_MouseClick()
        {
            EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm(mLayer);
            SimpleForm.FormClosed += SimpleForm_FormClosed;
            SimpleForm.Show();
        }

        private void SimpleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
        }
        private void ClassBreaksComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            int ColorNum = Colors[e.Index].Length;
            int interval_x = r.Width / ColorNum;
            int interval_y = r.Height / ColorNum;
            for(int i = 0; i < ColorNum; ++i)
                g.FillRectangle(new SolidBrush(Colors[e.Index][i]), new Rectangle(i * interval_x, i * interval_y, interval_x, interval_y));
        }

        private void UniqueColorComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            int ColorNum = Colors[e.Index].Length;
            int interval_x = r.Width / ColorNum;
            int interval_y = r.Height / ColorNum;
            for (int i = 0; i < ColorNum; ++i)
                g.FillRectangle(new SolidBrush(Colors[e.Index][i]), new Rectangle(i * interval_x, i * interval_y, interval_x, interval_y));

        }

        private void lineColorPicker_ValueChanged(object sender, Color value)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleLineSymbol).Color = value;
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleLineSymbol).Style = (GeoSimpleLineSymbolStyleConstant)styleComboBox.SelectedIndex;

        }

        private void sizeDoubleUpDown_ValueChanged(object sender, double value)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleLineSymbol).Size = value;
        }

        private void uniqueFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            (mLayer.Renderer as GeoUniqueValueRenderer).Field = uniqueFieldComboBox.SelectedItem.ToString();
        }

        private void classFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            (mLayer.Renderer as GeoClassBreaksRenderer).Field = uniqueFieldComboBox.SelectedItem.ToString();

        }
    }
}
