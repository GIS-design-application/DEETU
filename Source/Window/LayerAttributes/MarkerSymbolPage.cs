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
using System.Security.Cryptography;

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
        private Color[][] mColors = GeoMapDrawingTools.GetColors();
        private Button mClassDefaultButton = null;
        private Button mUniqueDefaultButton = null;
        #endregion

        #region 构造函数
        public MarkerSymbolPage(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;
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
                if (mLayer.AttributeFields.GetItem(i).ValueType != GeoValueTypeConstant.dText)
                    classFieldComboBox.Items.Add(mLayer.AttributeFields.GetItem(i).Name);

            // 对于不同的渲染模式进行配置
            if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                renderMethodCB.SelectedIndex = 0;
                renderTabControl.SelectedIndex = 0;
                initializeSimpleRenderer();
            }
            else if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                mUniqueValueRenderer = mLayer.Renderer as GeoUniqueValueRenderer;
                renderMethodCB.SelectedIndex = 1;
                renderTabControl.SelectedIndex = 1;
                uniqueFieldComboBox.SelectedIndex = mLayer.AttributeFields.FindField(mUniqueValueRenderer.Field);
            }
            else
            {
                mClassBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
                uiIntegerUpDown2.Value = (mLayer.Renderer as GeoClassBreaksRenderer).BreakCount;
                renderMethodCB.SelectedIndex = 2;
                renderTabControl.SelectedIndex = 2;
                classFieldComboBox.SelectedItem = mClassBreaksRenderer.Field;
                // classFieldComboBox.SelectedIndex = mLayer.AttributeFields.FindField(mClassBreaksRenderer.Field);
            }

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
            int size = 0;
            if(uiDoubleUpDown1.Value > uiDoubleUpDown2.Value)
                size = (int)(20 * symbol.Size / uiDoubleUpDown1.Value);
            else
                size = (int)(20 * symbol.Size / uiDoubleUpDown2.Value);
            Rectangle sRect = new Rectangle((20 - size) / 2, (20 - size) / 2, size, size);
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
            if (mUniqueValueRenderer == null || mUniqueValueRenderer.Field != uniqueFieldComboBox.SelectedItem.ToString())
            {
                mLayer.Renderer = CreateUniqueValueRenderer(uniqueFieldComboBox.SelectedItem.ToString());
                mUniqueValueRenderer = mLayer.Renderer as GeoUniqueValueRenderer;
            }
            if (mLayer.Renderer != null)
            {
                initializeUniqueValueRenderer();
            }
        }

        private void classFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classFieldComboBox.SelectedIndex == -1) return;
            if (mClassBreaksRenderer == null || mClassBreaksRenderer.Field != classFieldComboBox.SelectedItem.ToString())
            {
                Color sStartColor = new GeoSimpleFillSymbol().Color;
                Color sEndColor = Color.FromArgb(sStartColor.R / 2, sStartColor.G / 2, sStartColor.B / 2);
                mLayer.Renderer = CreateClassBreaksRenderer(classFieldComboBox.SelectedItem.ToString(), uiIntegerUpDown2.Value, uiDoubleUpDown1.Value, uiDoubleUpDown2.Value, sStartColor, sEndColor);
                mClassBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            }
            if (mLayer.Renderer != null)
            {
                initializeClassBreaksRenderer(uiIntegerUpDown2.Value);
            }
        }

        private void UniqueColorComboboxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            int n = mUniqueValueRenderers[e.Index].ValueCount;
            for (int i = 0; i < n; ++i)
            {
                SolidBrush sBrush = new SolidBrush((mUniqueValueRenderers[e.Index].GetSymbol(i) as GeoSimpleMarkerSymbol).Color);
                Rectangle sRect = new Rectangle(r.X + i * r.Width / n, r.Y, r.Width / n, r.Height);
                g.FillRectangle(sBrush, sRect);
            }
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
                if (classFieldComboBox.Items.Count == 0)
                {
                    MessageBox.Show("没有可以渲染的字段");
                }
                else if (mClassBreaksRenderer == null)
                {
                    classFieldComboBox.SelectedIndex = 0;
                }
                else mLayer.Renderer = mClassBreaksRenderer;
            }
            else if (renderMethodCB.SelectedItem.ToString() == "唯一值")
            {
                if (uniqueFieldComboBox.Items.Count == 0)
                {
                    MessageBox.Show("没有可以渲染的字段");
                }
                else if (mUniqueValueRenderer == null)
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

        private void uniqueColorgradComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mUniqueValueRenderer = mUniqueValueRenderers[uniqueColorgradComboBox.SelectedIndex];
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
            mLayer.Renderer = mClassBreaksRenderer = mClassBreaksRenderers[classColorgradComboBox.SelectedIndex];
            classDataGridView.Rows.Clear();
            GeoClassBreaksRenderer classBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleMarkerSymbol MarkerSymbol = (GeoSimpleMarkerSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateMarkerBitmapFromSymbol(MarkerSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            classDataGridView.Refresh();
        }

        private void uniqueDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm((mLayer.Renderer as GeoUniqueValueRenderer).GetSymbol(e.RowIndex));
                FormClosedEventHandler handle = (obj, eve) => DataGridView_FormClosed(e.RowIndex, GeoRendererTypeConstant.UniqueValue);
                SimpleForm.FormClosed += handle;
                SimpleForm.Show();
            }
        }

        private void classDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm((mLayer.Renderer as GeoClassBreaksRenderer).GetSymbol(e.RowIndex));
                FormClosedEventHandler handle = (obj, eve) => DataGridView_FormClosed(e.RowIndex, GeoRendererTypeConstant.ClassBreaks);
                SimpleForm.FormClosed += handle;
                SimpleForm.Show();
            }
        }
        private void DataGridView_FormClosed(int index, GeoRendererTypeConstant type)
        {
            if (type == GeoRendererTypeConstant.ClassBreaks)
            {
                GeoSimpleMarkerSymbol symbol = (GeoSimpleMarkerSymbol)(mLayer.Renderer as GeoClassBreaksRenderer).GetSymbol(index);
                classDataGridView.Rows[index].Cells[0].Value = CreateMarkerBitmapFromSymbol(symbol);
                classDataGridView.Refresh();
                classColorgradComboBox.Refresh();
            }
            else if (type == GeoRendererTypeConstant.UniqueValue)
            {
                GeoSimpleMarkerSymbol symbol = (GeoSimpleMarkerSymbol)(mLayer.Renderer as GeoUniqueValueRenderer).GetSymbol(index);
                uniqueDataGridView.Rows[index].Cells[0].Value = CreateMarkerBitmapFromSymbol(symbol);
                uniqueDataGridView.Refresh();
                uniqueColorgradComboBox.Refresh();
            }
        }
        private void uiIntegerUpDown2_ValueChanged(object sender, int value)
        {
            if (mClassBreaksRenderer == null || mClassBreaksRenderer.BreakCount != value)
            {
                Color sStartColor = (mClassBreaksRenderer.GetSymbol(0) as GeoSimpleFillSymbol).Color;
                Color sEndColor = (mClassBreaksRenderer.GetSymbol(mClassBreaksRenderer.BreakCount - 1) as GeoSimpleFillSymbol).Color;
                mLayer.Renderer = CreateClassBreaksRenderer(classFieldComboBox.SelectedItem.ToString(), uiIntegerUpDown2.Value, uiDoubleUpDown1.Value, uiDoubleUpDown2.Value, sStartColor, sEndColor);
                mClassBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            }
            if (mLayer.Renderer != null)
            {
                initializeClassBreaksRenderer(value);
            }
        }
        private void uiDoubleUpDown1_ValueChanged(object sender, double value)
        {
            if (mClassBreaksRenderer != null)
            {
                UpdateClassBreaksRenderers(mClassBreaksRenderer.BreakCount, uiDoubleUpDown1.Value, uiDoubleUpDown2.Value);
            }
        }
        private void uiDoubleUpDown2_ValueChanged(object sender, double value)
        {
            if (mClassBreaksRenderer != null)
            {
                UpdateClassBreaksRenderers(mClassBreaksRenderer.BreakCount, uiDoubleUpDown1.Value, uiDoubleUpDown2.Value);
            }
        }
        #endregion


        private void initializeSimpleRenderer()
        {
            GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
            mSimpleRenderer = simpleRenderer;
            GeoSimpleMarkerSymbol markerSymbol = (GeoSimpleMarkerSymbol)simpleRenderer.Symbol;
            markerColorPicker.Value = markerSymbol.Color;
            markerStyleComboBox.SelectedIndex = (int)markerSymbol.Style;
            sizeDoubleUpDown.Value = markerSymbol.Size;
        }

        private void initializeUniqueValueRenderer()
        {
            uniqueColorgradComboBox.Items.Clear();
            uniqueDataGridView.Rows.Clear();
            mUniqueValueRenderers.Clear();

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

            uniqueColorgradComboBox.Items.AddRange(mUniqueValueRenderers.ToArray());
            uniqueColorgradComboBox.SelectedIndex = 0;
            uniqueDataGridView.Refresh();
        }

        private void initializeClassBreaksRenderer(int value)
        {
            classColorgradComboBox.Items.Clear();
            classDataGridView.Rows.Clear();
            mClassBreaksRenderers.Clear();

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
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            CreateClassBreaksRenderers((mLayer.Renderer as GeoClassBreaksRenderer).Field, value);

            classColorgradComboBox.Items.AddRange(mClassBreaksRenderers.ToArray());
            classColorgradComboBox.SelectedIndex = 0;
            classDataGridView.Refresh();
        }

        private GeoClassBreaksRenderer CreateClassBreaksRenderer(string field, int n, double startWidth, double endWidth, Color startColor, Color endColor)
        {
            try
            {
                GeoClassBreaksRenderer sRenderer = new GeoClassBreaksRenderer();
                sRenderer.Field = field;
                List<double> sValues = new List<double>();
                int sFeatureCount = mLayer.Features.Count;
                int sFieldIndex = mLayer.AttributeFields.FindField(sRenderer.Field);
                GeoValueTypeConstant sFieldValueType = mLayer.AttributeFields.GetItem(sFieldIndex).ValueType;
                switch (sFieldValueType)
                {
                    case GeoValueTypeConstant.dDouble:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = (double)mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dSingle:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = (float)mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dInt16:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = (Int16)mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dInt32:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = (Int32)mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dInt64:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = (Int64)mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                            sValues.Add(sValue);
                        }
                        break;
                }

                double sMinValue = sValues.Min();
                double sMaxValue = sValues.Max();
                for (int i = 0; i < n; i++)
                {
                    double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / n;
                    double sWidth = startWidth + (endWidth - startWidth) * (i + 1) / n;
                    GeoSimpleMarkerSymbol sSymbol = new GeoSimpleMarkerSymbol();
                    sSymbol.Size = sWidth;
                    sRenderer.AddBreakValue(sValue, sSymbol);
                }
                Color sStartColor = startColor;
                Color sEndColor = endColor;
                sRenderer.RampColor(sStartColor, sEndColor);
                sRenderer.DefaultSymbol = new GeoSimpleMarkerSymbol();
                return sRenderer;
            }
            catch (Exception e)
            {
                MessageBox.Show("这个字段无法进行分级渲染！");
                return null;
            }
        }
        private void CreateClassBreaksRenderers(string field, int value)
        {
            for (int i = 0; i < mColors.Length; ++i)
            {
                mClassBreaksRenderers.Add(CreateClassBreaksRenderer(field, uiIntegerUpDown2.Value, uiDoubleUpDown1.Value, uiDoubleUpDown2.Value, mColors[i][0], mColors[i][1]));
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
                int sFieldIndex = mLayer.AttributeFields.FindField(sRenderer.Field);
                for (int i = 0; i < sFeatureCount; i++)
                {
                    string svalue = mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex).ToString(); // 这里使用0 假定第一个就是字符串的名称
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
            for (int i = 0; i < 5; ++i)
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

        private void UpdateClassBreaksRenderers(int value, double startWidth, double endWidth)
        {
            classDataGridView.Rows.Clear();
            for (int i = 0; i < mClassBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleMarkerSymbol sMarkerSymbol = mClassBreaksRenderer.GetSymbol(i) as GeoSimpleMarkerSymbol;
                sMarkerSymbol.Size = startWidth + (endWidth - startWidth) * (i + 1) / value;
                Bitmap symbolImage = CreateMarkerBitmapFromSymbol(sMarkerSymbol);
                classDataGridView.AddRow(symbolImage, mClassBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            for (int i = 0; i < mClassBreaksRenderers.Count; ++i)
            {
                GeoClassBreaksRenderer sRenderer = mClassBreaksRenderers[i];
                for (int j = 0; j < sRenderer.BreakCount; ++j)
                    (sRenderer.GetSymbol(j) as GeoSimpleMarkerSymbol).Size = startWidth + (endWidth - startWidth) * (j + 1) / value;

            }
            classDataGridView.Refresh();
        }
    }
}
