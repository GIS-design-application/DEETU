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
using System.Security.Cryptography;

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
        private Color[][] mColors = GeoMapDrawingTools.GetColors();
        private Button mClassDefaultButton = null;
        private Button mUniqueDefaultButton = null;

        #endregion
        public LineSymbolPage(GeoMapLayer layer)
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
            foreach(GeoSimpleLineSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleLineSymbolStyleConstant)))
            {
                styleComboBox.Items.Add(s.ToString());
            }
            for (int i = 0; i < mLayer.AttributeFields.Count; i++)
                uniqueFieldComboBox.Items.Add(mLayer.AttributeFields.GetItem(i).Name);
            for (int i = 0; i < mLayer.AttributeFields.Count; i++)
                if(mLayer.AttributeFields.GetItem(i).ValueType != GeoValueTypeConstant.dText)
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

        private Button GetLineSymbolButton(GeoSimpleLineSymbol symbol)
        {
            Button sButton = new Button();
            sButton.BackColor = Color.White;
            sButton.Text = "";
            sButton.Dock = DockStyle.Fill;
            sButton.FlatAppearance.BorderSize = 0;
            sButton.BackgroundImage = CreateLineBitmapFromSymbol(symbol);
            sButton.BackgroundImageLayout = ImageLayout.Zoom;

            MouseEventHandler handler = (sender, e) => SymbolGridButton_MouseClick(sButton, symbol);
            sButton.MouseClick += handler;

            return sButton;
        }

        private Bitmap CreateLineBitmapFromSymbol(GeoSimpleLineSymbol symbol)
        {
            Bitmap styleImage = new Bitmap(50, 20);
            Graphics g = Graphics.FromImage(styleImage);
            double dpm = 1000; // I don't know the correct dpm here so I just randomly assigned a number
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawLine(sPen, new Point(0, (styleImage.Height - (int)sPen.Width) / 2), new Point(styleImage.Width, (styleImage.Height - (int)sPen.Width) / 2));
            g.Dispose();
            return styleImage;
        }

        #region event
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
            button.BackgroundImageLayout = ImageLayout.Zoom;
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
            int n = mUniqueValueRenderers[e.Index].ValueCount;
            for(int i = 0; i < n; ++i)
            {
                SolidBrush sBrush = new SolidBrush((mUniqueValueRenderers[e.Index].GetSymbol(i) as GeoSimpleLineSymbol).Color);
                Rectangle sRect = new Rectangle(r.X + i * r.Width / n, r.Y, r.Width / n, r.Height);
                g.FillRectangle(sBrush, sRect);
            }
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

        private void UniqueValueComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mUniqueValueRenderer = mUniqueValueRenderers[UniqueValueComboBoxEx.SelectedIndex];
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
            mLayer.Renderer = mClassBreaksRenderer = mClassBreaksRenderers[ClassBreaksComboBoxEx.SelectedIndex];
            classDataGridView.Rows.Clear();
            GeoClassBreaksRenderer classBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleLineSymbol LineSymbol = (GeoSimpleLineSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateLineBitmapFromSymbol(LineSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            classDataGridView.Refresh();
        }


        private void uniqueDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == 0)
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
            if(type == GeoRendererTypeConstant.ClassBreaks)
            {
                GeoSimpleLineSymbol symbol = (GeoSimpleLineSymbol)(mLayer.Renderer as GeoClassBreaksRenderer).GetSymbol(index);
                classDataGridView.Rows[index].Cells[0].Value = CreateLineBitmapFromSymbol(symbol);
                classDataGridView.Refresh();
                ClassBreaksComboBoxEx.Refresh();
            }
            else if(type == GeoRendererTypeConstant.UniqueValue)
            {
                GeoSimpleLineSymbol symbol = (GeoSimpleLineSymbol)(mLayer.Renderer as GeoUniqueValueRenderer).GetSymbol(index);
                uniqueDataGridView.Rows[index].Cells[0].Value = CreateLineBitmapFromSymbol(symbol);
                uniqueDataGridView.Refresh();
                UniqueValueComboBoxEx.Refresh();
            }
        }


        private void uiIntegerUpDown2_ValueChanged(object sender, int value)
        {
            if (mClassBreaksRenderer == null)
            {
                MessageBox.Show("当前没有可以调整分级数的渲染！");
                return;
            }
            if (mClassBreaksRenderer.BreakCount != value)
            {
                Color sStartColor = (mClassBreaksRenderer.GetSymbol(0) as GeoSimpleLineSymbol).Color;
                Color sEndColor = (mClassBreaksRenderer.GetSymbol(mClassBreaksRenderer.BreakCount - 1) as GeoSimpleLineSymbol).Color;
                mLayer.Renderer = CreateClassBreaksRenderer(classFieldComboBox.SelectedItem.ToString(), value, uiDoubleUpDown1.Value, uiDoubleUpDown2.Value, sStartColor, sEndColor);
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

        #region renderer建立与修改
        // 初始化渲染
        private void initializeSimpleRenderer()
        {
            GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
            mSimpleRenderer = simpleRenderer;
            GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)simpleRenderer.Symbol;
            lineColorPicker.Value = lineSymbol.Color;
            sizeDoubleUpDown.Value = lineSymbol.Size;
            styleComboBox.SelectedIndex = (int)lineSymbol.Style;
        }

        // 初始化渲染
        private void initializeUniqueValueRenderer()
        {
            // 先清空
            UniqueValueComboBoxEx.Items.Clear();
            uniqueDataGridView.Rows.Clear();
            mUniqueValueRenderers.Clear();
            // 建立当前的
            GeoUniqueValueRenderer uniqueValueRenderer = (GeoUniqueValueRenderer)mLayer.Renderer;
            mUniqueValueRenderer = uniqueValueRenderer;
            mUniqueValueRenderers.Add(mUniqueValueRenderer);
            // 建立默认按钮
            if (mUniqueDefaultButton != null) uniqueTableLayoutPanel.Controls.Remove(mUniqueDefaultButton);
            Button defaultSymbolButton = GetLineSymbolButton((GeoSimpleLineSymbol)uniqueValueRenderer.DefaultSymbol);
            mUniqueDefaultButton = defaultSymbolButton;
            uniqueTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
            // 建立当前的符号列表展示
            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)uniqueValueRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateLineBitmapFromSymbol(lineSymbol);
                uniqueDataGridView.AddRow(symbolImage, uniqueValueRenderer.GetValue(i));
            }
            uniqueDataGridView.Refresh();

            // 建立其他渲染
            CreateUniqueValueRenderers((mLayer.Renderer as GeoUniqueValueRenderer).Field);
            UniqueValueComboBoxEx.Items.AddRange(mUniqueValueRenderers.ToArray());
            UniqueValueComboBoxEx.SelectedIndex = 0;
        }

        // 初始化渲染
        private void initializeClassBreaksRenderer(int value)
        {
            // 先清空
            ClassBreaksComboBoxEx.Items.Clear();
            classDataGridView.Rows.Clear();
            mClassBreaksRenderers.Clear();
            // 建立当前渲染
            GeoClassBreaksRenderer classBreaksRenderer = (GeoClassBreaksRenderer)mLayer.Renderer;
            mClassBreaksRenderer = classBreaksRenderer;
            mClassBreaksRenderers.Add(mClassBreaksRenderer);
            // 建立默认按钮
            if (mClassDefaultButton != null) classTableLayoutPanel.Controls.Remove(mClassDefaultButton);
            
            Button defaultSymbolButton = GetLineSymbolButton((GeoSimpleLineSymbol)classBreaksRenderer.DefaultSymbol);
            mClassDefaultButton = defaultSymbolButton;
            classTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);
            // 建立每个图片展示
            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleLineSymbol lineSymbol = (GeoSimpleLineSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateLineBitmapFromSymbol(lineSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            classDataGridView.Refresh();
            // 建立其他备选渲染
            CreateClassBreaksRenderers((mLayer.Renderer as GeoClassBreaksRenderer).Field, value);
            ClassBreaksComboBoxEx.Items.AddRange(mClassBreaksRenderers.ToArray());
            ClassBreaksComboBoxEx.SelectedIndex = 0;
        }
        private GeoClassBreaksRenderer CreateClassBreaksRenderer(string field, int n, double startWidth, double endWidth, Color startColor, Color endColor)
        {
            try
            {
                GeoClassBreaksRenderer sRenderer = new GeoClassBreaksRenderer();
                sRenderer.Field = field;
                List<double> sValues = new List<double>();
                int sFeatureCount = mLayer.Features.Count;
                int sFieldIndex = mLayer.AttributeFields.FindField(field);
                GeoValueTypeConstant sFieldValueType = mLayer.AttributeFields.GetItem(sFieldIndex).ValueType;
                switch (sFieldValueType)
                {
                    case GeoValueTypeConstant.dDouble:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = Convert.ToDouble(mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dSingle:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = Convert.ToSingle(mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dInt16:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = Convert.ToInt16(mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dInt32:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = Convert.ToInt32(mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                            sValues.Add(sValue);
                        }
                        break;
                    case GeoValueTypeConstant.dInt64:
                        for (int i = 0; i < sFeatureCount; i++)
                        {
                            double sValue = Convert.ToInt64(mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
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
                    GeoSimpleLineSymbol sSymbol = new GeoSimpleLineSymbol();
                    sSymbol.Size = sWidth;
                    sRenderer.AddBreakValue(sValue, sSymbol);
                }
                Color sStartColor = startColor;
                Color sEndColor = endColor;
                sRenderer.RampColor(sStartColor, sEndColor);
                sRenderer.DefaultSymbol = new GeoSimpleLineSymbol();
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
                mClassBreaksRenderers.Add(CreateClassBreaksRenderer(field, value, uiDoubleUpDown1.Value, uiDoubleUpDown2.Value, mColors[i][0], mColors[i][1]));
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
                int sFieldIndex = mLayer.AttributeFields.FindField(field);
                for (int i = 0; i < sFeatureCount; i++)
                {
                    string svalue = mLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex).ToString();
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
            GeoSimpleLineSymbol sSymbol = new GeoSimpleLineSymbol();
            sRenderer.Symbol = sSymbol;
            return sRenderer;
        }
        private void UpdateClassBreaksRenderers(int value, double startWidth, double endWidth)
        {
            classDataGridView.Rows.Clear();
            for (int i = 0; i < mClassBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleLineSymbol lineSymbol = mClassBreaksRenderer.GetSymbol(i) as GeoSimpleLineSymbol;
                lineSymbol.Size = startWidth + (endWidth - startWidth) * (i + 1) / value;
                Bitmap symbolImage = CreateLineBitmapFromSymbol(lineSymbol);
                classDataGridView.AddRow(symbolImage, mClassBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            for(int i = 0; i < mClassBreaksRenderers.Count; ++i)
            {
                GeoClassBreaksRenderer sRenderer = mClassBreaksRenderers[i];
                for(int j = 0; j < sRenderer.BreakCount; ++j)
                    (sRenderer.GetSymbol(j) as GeoSimpleLineSymbol).Size = startWidth + (endWidth - startWidth) * (j + 1) / value;

            }
            classDataGridView.Refresh();
        }
        #endregion

    }
}
