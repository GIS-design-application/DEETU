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
        private GeoSimpleRenderer mSimpleRenderer = null;
        private GeoClassBreaksRenderer mClassBreaksRenderer = null;
        private GeoUniqueValueRenderer mUniqueValueRenderer = null;
        private List<GeoUniqueValueRenderer> mUniqueValueRenderers = new List<GeoUniqueValueRenderer>();
        private List<GeoClassBreaksRenderer> mClassBreaksRenderers = new List<GeoClassBreaksRenderer>();
        private int mSymbolsCount = 10;
        private Button mClassDefaultButton = null;
        private Button mUniqueDefaultButton = null;

        #endregion
        public LineSymbolPage(GeoMapLayer layer)
        {
            InitializeComponent();
            // mLayer = layer.Clone();
            mLayer = layer;
            renderMethodCB.SelectedIndex = (int)layer.Renderer.RendererType;
            renderMethodCB.SelectedIndexChanged += RenderMethodCB_SelectedIndexChanged;
            renderTabControl.SelectedIndexChanged += RenderTabControl_SelectedIndexChanged;
            
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
            foreach(GeoSimpleLineSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleLineSymbolStyleConstant)))
            {
                styleComboBox.Items.Add(s.ToString());
            }
            for (int i = 0; i < mLayer.AttributeFields.Count; i++)
                uniqueFieldComboBox.Items.Add(mLayer.AttributeFields.GetItem(i).Name);
            for (int i = 0; i < mLayer.AttributeFields.Count; i++)
                classFieldComboBox.Items.Add(mLayer.AttributeFields.GetItem(i).Name);

            // 对于不同的渲染模式进行配置
            if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                initializeSimpleRenderer();
            }
            else if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                initializeUniqueValueRenderer();
                uniqueFieldComboBox.SelectedIndex = mLayer.AttributeFields.FindField(mUniqueValueRenderer.Field);
 
                UniqueValueComboBoxEx.Items.AddRange(mUniqueValueRenderers.ToArray());
                UniqueValueComboBoxEx.SelectedIndex = 0;
            }
            else
            {
                initializeClassBreaksRenderer();
                classFieldComboBox.SelectedIndex = mLayer.AttributeFields.FindField(mClassBreaksRenderer.Field);

                ClassBreaksComboBoxEx.Items.AddRange(mClassBreaksRenderers.ToArray());
                ClassBreaksComboBoxEx.SelectedIndex = 0;
            }
            
        }

        private void initializeSimpleRenderer()
        {
            GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
            mSimpleRenderer = simpleRenderer;
            GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)simpleRenderer.Symbol;
            lineColorPicker.Value = lineSymbol.Color;
            sizeDoubleUpDown.Value = lineSymbol.Size;
            styleComboBox.SelectedIndex = (int)lineSymbol.Style;
        }

        private void initializeUniqueValueRenderer()
        {
            GeoUniqueValueRenderer uniqueValueRenderer = (GeoUniqueValueRenderer)mLayer.Renderer;
            mUniqueValueRenderer = uniqueValueRenderer;
            mUniqueValueRenderers.Add(mUniqueValueRenderer);

            if (mUniqueDefaultButton != null) uniqueTableLayoutPanel.Controls.Remove(mUniqueDefaultButton);
            Button defaultSymbolButton = GetLineSymbolButton((GeoSimpleLineSymbol)uniqueValueRenderer.DefaultSymbol);
            mUniqueDefaultButton = defaultSymbolButton;
            uniqueTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);

            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)uniqueValueRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateLineBitmapFromSymbol(lineSymbol);
                uniqueDataGridView.AddRow(symbolImage, uniqueValueRenderer.GetValue(i));
            }
            CreateUniqueValueRenderers((mLayer.Renderer as GeoUniqueValueRenderer).Field);
        }

        private void initializeClassBreaksRenderer()
        {
            GeoClassBreaksRenderer classBreaksRenderer = (GeoClassBreaksRenderer)mLayer.Renderer;
            mClassBreaksRenderer = classBreaksRenderer;
            mClassBreaksRenderers.Add(mClassBreaksRenderer);

            if (mClassBreaksRenderer != null) classTableLayoutPanel.Controls.Remove(mClassDefaultButton);
            Button defaultSymbolButton = GetLineSymbolButton((GeoSimpleLineSymbol)classBreaksRenderer.DefaultSymbol);
            mClassDefaultButton = defaultSymbolButton;
            classTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);

            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateLineBitmapFromSymbol(lineSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i));
            }
            CreateClassBreaksRenderers((mLayer.Renderer as GeoUniqueValueRenderer).Field);
        }


        private Button GetLineSymbolButton(GeoSimpleLineSymbol symbol)
        {
            Button sButton = new Button();
            sButton.BackColor = Color.White;
            sButton.Text = "";
            sButton.Dock = DockStyle.Fill;
            sButton.FlatAppearance.BorderSize = 0;
            sButton.BackgroundImage = CreateLineBitmapFromSymbol(symbol);
            sButton.BackgroundImageLayout = ImageLayout.Tile;

            MouseEventHandler handler = (sender, e) => SymbolGridButton_MouseClick(sButton, symbol);
            sButton.MouseClick += handler;

            return sButton;
        }

        private Bitmap CreateLineBitmapFromSymbol(GeoSimpleLineSymbol symbol)
        {
            Bitmap styleImage = new Bitmap(50, 20);
            Graphics g = Graphics.FromImage(styleImage);
            double dpm = 100; // I don't know the correct dpm here so I just randomly assigned a number
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawLine(sPen, new Point(0, styleImage.Height / 2), new Point(styleImage.Width, styleImage.Height / 2));
            g.Dispose();
            return styleImage;
        }


        private void SymbolGridButton_MouseClick(Button button, GeoSimpleLineSymbol symbol)
        {
            EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm(symbol);
            FormClosedEventHandler handle = (sender, e) => SimpleForm_FormClosed(button, symbol);
            SimpleForm.FormClosed += handle;
            SimpleForm.Show();
        }

        private void SimpleForm_FormClosed(Button button, GeoSimpleLineSymbol symbol)
        {
            button.BackgroundImage = CreateLineBitmapFromSymbol(symbol);
            button.BackgroundImageLayout = ImageLayout.Tile;
            button.Refresh();
        }
        private void ClassBreaksComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            Color StartColor = (mClassBreaksRenderers[e.Index].GetSymbol(0) as GeoSimpleLineSymbol).Color;
            Color EndColor = (mClassBreaksRenderers[e.Index].GetSymbol(mClassBreaksRenderers[e.Index].BreakCount - 1) as GeoSimpleLineSymbol).Color;
            LinearGradientBrush sBrush = new LinearGradientBrush(new RectangleF(r.X, r.Y, r.Width, r.Height - 2), StartColor, EndColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(sBrush, r);
            g.DrawRectangle(new Pen(this.BackColor), r);
            e.DrawFocusRectangle();
        }

        private void UniqueColorComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            Color StartColor = (mUniqueValueRenderers[e.Index].GetSymbol(0) as GeoSimpleLineSymbol).Color;
            Color EndColor = (mUniqueValueRenderers[e.Index].GetSymbol(mUniqueValueRenderers[e.Index].ValueCount - 1) as GeoSimpleLineSymbol).Color;
            LinearGradientBrush sBrush = new LinearGradientBrush(new RectangleF(r.X, r.Y, r.Width, r.Height - 2), StartColor, EndColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(sBrush, r);
            g.DrawRectangle(new Pen(this.BackColor), r);
            e.DrawFocusRectangle();
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
            if (uniqueFieldComboBox.SelectedIndex == -1) return;
            mLayer.Renderer = CreateUniqueValueRenderer(uniqueFieldComboBox.SelectedItem.ToString());
            if (mLayer.Renderer != null)
            {
                UniqueValueComboBoxEx.Items.Clear();
                uniqueDataGridView.Rows.Clear();
                mUniqueValueRenderers.Clear();

                initializeUniqueValueRenderer();
                CreateUniqueValueRenderers(uniqueFieldComboBox.SelectedItem.ToString());
                UniqueValueComboBoxEx.Items.AddRange(mUniqueValueRenderers.ToArray());
                UniqueValueComboBoxEx.SelectedIndex = 0;
                uniqueDataGridView.Refresh();
            }
        }

        private void classFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classFieldComboBox.SelectedIndex == -1) return;
            mLayer.Renderer = CreateClassBreaksRenderer(classFieldComboBox.SelectedItem.ToString());
            if (mLayer.Renderer != null)
            {
                ClassBreaksComboBoxEx.Items.Clear();
                classDataGridView.Rows.Clear();
                mClassBreaksRenderers.Clear();

                initializeClassBreaksRenderer();
                classDataGridView.Refresh();
                ClassBreaksComboBoxEx.Items.AddRange(mClassBreaksRenderers.ToArray());
                ClassBreaksComboBoxEx.SelectedIndex = 0;
            }

        }
        private void RenderTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderMethodCB.SelectedIndex = renderTabControl.SelectedIndex;
            if (renderMethodCB.SelectedItem.ToString() == "单一符号")
            {
                if (mSimpleRenderer == null)
                {
                    mLayer.Renderer = CreateSimpleRenderer();
                    initializeSimpleRenderer();
                }
                else mLayer.Renderer = mSimpleRenderer;
            }
            else if (renderMethodCB.SelectedItem.ToString() == "分级符号")
            {
                if (mClassBreaksRenderer == null)
                {
                    classFieldComboBox.SelectedIndex = 0;
                }
                else mLayer.Renderer = mClassBreaksRenderer;
            }
            else if (renderMethodCB.SelectedItem.ToString() == "唯一值")
            {
                if (mUniqueValueRenderer == null)
                {
                    uniqueFieldComboBox.SelectedIndex = 0;
                }
                else mLayer.Renderer = mUniqueValueRenderer;
            }
        }
        private void RenderMethodCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderTabControl.SelectedIndex = renderMethodCB.SelectedIndex;
        }

        private GeoClassBreaksRenderer CreateClassBreaksRenderer(string field)
        {
            try
            {
                GeoClassBreaksRenderer sRenderer = new GeoClassBreaksRenderer();
                sRenderer.Field = field;
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
                    GeoSimpleLineSymbol sSymbol = new GeoSimpleLineSymbol();
                    sRenderer.AddBreakValue(sValue, sSymbol);
                }
                Color sStartColor = new GeoSimpleFillSymbol().Color;
                Color sEndColor = new GeoSimpleFillSymbol().Color;
                sRenderer.RampColor(sStartColor, sEndColor);
                sRenderer.DefaultSymbol = new GeoSimpleLineSymbol();
                return sRenderer;
            }
            catch(Exception e)
            {
                MessageBox.Show("这个字段无法进行分级渲染！");
                return null;
            }
        }

        private void CreateClassBreaksRenderers(string field)
        {
            for (int i = 0; i < mSymbolsCount; ++i)
            {
                mClassBreaksRenderers.Add(CreateClassBreaksRenderer(field));
            }
        }

        private GeoUniqueValueRenderer CreateUniqueValueRenderer(string field)
        {
            try
            {
                GeoUniqueValueRenderer sRenderer = new GeoUniqueValueRenderer();
                sRenderer.Field = field;
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
                    GeoSimpleLineSymbol sSymbol = new GeoSimpleLineSymbol();
                    sRenderer.AddUniqueValue(sValues[i], sSymbol);

                }
                sRenderer.DefaultSymbol = new GeoSimpleLineSymbol();
                return sRenderer;
            }
            catch(Exception e)
            {
                MessageBox.Show("这个字段不能进行唯一值渲染");

                return null;
            }


        }

        private void CreateUniqueValueRenderers(string field)
        {
            for (int i = 0; i < mSymbolsCount; ++i)
            {
                mUniqueValueRenderers.Add(CreateUniqueValueRenderer(field));
            }
        }

        private GeoSimpleRenderer CreateSimpleRenderer()
        {
            GeoSimpleRenderer sRenderer = new GeoSimpleRenderer();
            GeoSimpleLineSymbol sSymbol = new GeoSimpleLineSymbol();
            sRenderer.Symbol = sSymbol;
            return sRenderer;
        }

        private void UniqueValueComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mUniqueValueRenderers[UniqueValueComboBoxEx.SelectedIndex];
            uniqueDataGridView.Rows.Clear();
            GeoUniqueValueRenderer uniqueValueRenderer = mLayer.Renderer as GeoUniqueValueRenderer;
            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)uniqueValueRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateLineBitmapFromSymbol(lineSymbol);
                uniqueDataGridView.AddRow(symbolImage, uniqueValueRenderer.GetValue(i));
            }
            uniqueDataGridView.Refresh();
        }

        private void ClassBreaksComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mClassBreaksRenderers[ClassBreaksComboBoxEx.SelectedIndex];
            classDataGridView.Rows.Clear();
            GeoClassBreaksRenderer classBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleLineSymbol LineSymbol = (GeoSimpleLineSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateLineBitmapFromSymbol(LineSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i));
            }
            classDataGridView.Refresh();
        }
    }
}
