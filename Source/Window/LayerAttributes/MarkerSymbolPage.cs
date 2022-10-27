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
        private GeoSimpleRenderer mSimpleRenderer = null;
        private GeoClassBreaksRenderer mClassBreaksRenderer = null;
        private GeoUniqueValueRenderer mUniqueValueRenderer = null;
        private List<GeoUniqueValueRenderer> mUniqueValueRenderers = new List<GeoUniqueValueRenderer>();
        private List<GeoClassBreaksRenderer> mClassBreaksRenderers = new List<GeoClassBreaksRenderer>();
        private int mSymbolsCount = 10;
        private Button mClassDefaultButton = null;
        private Button mUniqueDefaultButton = null;
        #endregion

        #region 构造函数
        public MarkerSymbolPage(GeoMapLayer layer)
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

            foreach(GeoSimpleMarkerSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleMarkerSymbolStyleConstant)))
            {
                markerStyleComboBox.Items.Add(s.ToString());
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

                uniqueColorgradComboBox.Items.AddRange(mUniqueValueRenderers.ToArray());
                uniqueColorgradComboBox.SelectedIndex = 0;
            }
            else
            {
                initializeClassBreaksRenderer();
                classFieldComboBox.SelectedIndex = mLayer.AttributeFields.FindField(mClassBreaksRenderer.Field);

                classColorgradComboBox.Items.AddRange(mClassBreaksRenderers.ToArray());
                classColorgradComboBox.SelectedIndex = 0;
            }
            
        }

        private void initializeSimpleRenderer()
        {
            GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
            mSimpleRenderer = simpleRenderer;
            GeoSimpleMarkerSymbol markerSymbol = (GeoSimpleMarkerSymbol)simpleRenderer.Symbol;
            markerColorPicker.Value = markerSymbol.Color;
            markerStyleComboBox.SelectedIndex = (int)markerSymbol.Style;
        }

        private void initializeUniqueValueRenderer()
        {
            GeoUniqueValueRenderer uniqueValueRenderer = (GeoUniqueValueRenderer)mLayer.Renderer;
            mUniqueValueRenderer = uniqueValueRenderer;
            mUniqueValueRenderers.Add(mUniqueValueRenderer);

            if (mUniqueDefaultButton != null) uniqueTableLayoutPanel.Controls.Remove(mUniqueDefaultButton);
            Button defaultSymbolButton = GetMarkerSymbolButton((GeoSimpleMarkerSymbol)uniqueValueRenderer.DefaultSymbol);
            mUniqueDefaultButton = defaultSymbolButton;
            uniqueTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);

            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                GeoSimpleMarkerSymbol markerSymbol = (GeoSimpleMarkerSymbol)uniqueValueRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateMarkerBitmapFromSymbol(markerSymbol);
                uniqueDataGridView.AddRow(symbolImage, uniqueValueRenderer.GetValue(i));
            }
            CreateUniqueValueRenderers((mLayer.Renderer as GeoUniqueValueRenderer).Field);
        }

        private void initializeClassBreaksRenderer()
        {
            GeoClassBreaksRenderer classBreaksRenderer = (GeoClassBreaksRenderer)mLayer.Renderer;
            mClassBreaksRenderer = classBreaksRenderer;
            mClassBreaksRenderers.Add(mClassBreaksRenderer);

            if (mClassDefaultButton != null) classTableLayoutPanel.Controls.Remove(mClassDefaultButton);
            Button defaultSymbolButton = GetMarkerSymbolButton((GeoSimpleMarkerSymbol)classBreaksRenderer.DefaultSymbol);
            mClassDefaultButton = defaultSymbolButton;
            classTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleMarkerSymbol markerSymbol = (GeoSimpleMarkerSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateMarkerBitmapFromSymbol(markerSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i));
            }
            CreateClassBreaksRenderers((mLayer.Renderer as GeoUniqueValueRenderer).Field);

        }

        private Button GetMarkerSymbolButton(GeoSimpleMarkerSymbol symbol)
        {
            Button sButton = new Button();
            sButton.Text = "";
            sButton.Dock = DockStyle.Fill;
            sButton.FlatAppearance.BorderSize = 0;
            sButton.BackgroundImage = CreateMarkerBitmapFromSymbol(symbol);
            sButton.BackgroundImageLayout = ImageLayout.Center;

            MouseEventHandler handler = (sender, e) => SymbolGridButton_MouseClick(sButton, symbol);
            sButton.MouseClick += handler;

            return sButton;
        }

        private Bitmap CreateMarkerBitmapFromSymbol(GeoSimpleMarkerSymbol symbol)
        {
            Bitmap styleImage = new Bitmap(20, 20);
            Graphics g = Graphics.FromImage(styleImage);
            Rectangle sRect = new Rectangle(0, 0, 20, 20);
            GeoMapDrawingTools.DrawSimpleMarker(g, sRect, 0, symbol); // dpm is useless in this 
            g.Dispose();
            return styleImage;
        }

        #endregion


        #region 事件处理
        private void SymbolGridButton_MouseClick(Button button, GeoSimpleMarkerSymbol symbol)
        {
            EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm(symbol);
            FormClosedEventHandler handle = (sender, e) => SimpleForm_FormClosed(button, symbol);
            SimpleForm.FormClosed += handle;
            SimpleForm.Show();
        }

        private void SimpleForm_FormClosed(Button button, GeoSimpleMarkerSymbol symbol)
        {
            button.BackgroundImage = CreateMarkerBitmapFromSymbol(symbol);
            button.BackgroundImageLayout = ImageLayout.Center;
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
            if (uniqueFieldComboBox.SelectedIndex == -1) return;
            mLayer.Renderer = CreateUniqueValueRenderer(uniqueFieldComboBox.SelectedItem.ToString());
            if (mLayer.Renderer != null)
            {
                uniqueColorgradComboBox.Items.Clear();
                uniqueDataGridView.Rows.Clear();
                mUniqueValueRenderers.Clear();

                initializeUniqueValueRenderer();
                uniqueColorgradComboBox.Items.AddRange(mUniqueValueRenderers.ToArray());
                uniqueColorgradComboBox.SelectedIndex = 0;
                uniqueDataGridView.Refresh();
            }
        }

        private void classFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classFieldComboBox.SelectedIndex == -1) return;
            mLayer.Renderer = CreateClassBreaksRenderer(classFieldComboBox.SelectedItem.ToString());
            if (mLayer.Renderer != null)
            {
                classColorgradComboBox.Items.Clear();
                classDataGridView.Rows.Clear();
                mClassBreaksRenderers.Clear();

                initializeClassBreaksRenderer();
                classDataGridView.Refresh();
                classColorgradComboBox.Items.AddRange(mClassBreaksRenderers.ToArray());
                classColorgradComboBox.SelectedIndex = 0;
            }
        }

        private void UniqueColorComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            Color StartColor = (mUniqueValueRenderers[e.Index].GetSymbol(0) as GeoSimpleMarkerSymbol).Color;
            Color EndColor = (mUniqueValueRenderers[e.Index].GetSymbol(mUniqueValueRenderers[e.Index].ValueCount - 1) as GeoSimpleMarkerSymbol).Color;
            LinearGradientBrush sBrush = new LinearGradientBrush(new RectangleF(r.X, r.Y, r.Width, r.Height - 2), StartColor, EndColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(sBrush, r);
            g.DrawRectangle(new Pen(this.BackColor), r);
            e.DrawFocusRectangle();
        }

        private void ClassBreaksComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            Color StartColor = (mClassBreaksRenderers[e.Index].GetSymbol(0) as GeoSimpleMarkerSymbol).Color;
            Color EndColor = (mClassBreaksRenderers[e.Index].GetSymbol(mClassBreaksRenderers[e.Index].BreakCount - 1) as GeoSimpleMarkerSymbol).Color;
            LinearGradientBrush sBrush = new LinearGradientBrush(new RectangleF(r.X, r.Y, r.Width, r.Height - 2), StartColor, EndColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(sBrush, r);
            g.DrawRectangle(new Pen(this.BackColor), r);
            e.DrawFocusRectangle();
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
                    GeoSimpleMarkerSymbol sSymbol = new GeoSimpleMarkerSymbol();
                    sRenderer.AddBreakValue(sValue, sSymbol);
                }
                Color sStartColor = new GeoSimpleFillSymbol().Color;
                Color sEndColor = new GeoSimpleFillSymbol().Color;
                sRenderer.RampColor(sStartColor, sEndColor);
                sRenderer.DefaultSymbol = new GeoSimpleMarkerSymbol();
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
                    GeoSimpleMarkerSymbol sSymbol = new GeoSimpleMarkerSymbol();
                    sRenderer.AddUniqueValue(sValues[i], sSymbol);

                }
                sRenderer.DefaultSymbol = new GeoSimpleMarkerSymbol();
                return sRenderer;
            }
            catch (Exception e)
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
            GeoSimpleMarkerSymbol sSymbol = new GeoSimpleMarkerSymbol();
            sRenderer.Symbol = sSymbol;
            return sRenderer;
        }
        #endregion

        private void uniqueColorgradComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mUniqueValueRenderers[uniqueColorgradComboBox.SelectedIndex];
            uniqueDataGridView.Rows.Clear();
            GeoUniqueValueRenderer uniqueValueRenderer = mLayer.Renderer as GeoUniqueValueRenderer;
            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                GeoSimpleMarkerSymbol MarkerSymbol = (GeoSimpleMarkerSymbol)uniqueValueRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateMarkerBitmapFromSymbol(MarkerSymbol);
                uniqueDataGridView.AddRow(symbolImage, uniqueValueRenderer.GetValue(i));
            }
            uniqueDataGridView.Refresh();
        }

        private void classColorgradComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mClassBreaksRenderers[classColorgradComboBox.SelectedIndex];
            classDataGridView.Rows.Clear();
            GeoClassBreaksRenderer classBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleMarkerSymbol MarkerSymbol = (GeoSimpleMarkerSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateMarkerBitmapFromSymbol(MarkerSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i));
            }
            classDataGridView.Refresh();
        }
    }
}
