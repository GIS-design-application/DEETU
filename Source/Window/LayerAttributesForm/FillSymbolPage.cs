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
    public partial class FillSymbolPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;  // 渲染的图层
        private GeoSimpleRenderer mSimpleRenderer = null; // 记录生成的简单渲染
        private GeoClassBreaksRenderer mClassBreaksRenderer = null; // 记录生成的分级渲染
        private GeoUniqueValueRenderer mUniqueValueRenderer = null; // 记录生成的唯一值渲染
        private List<GeoUniqueValueRenderer> mUniqueValueRenderers = new List<GeoUniqueValueRenderer>(); // 为了渐变色选择框的方便，生成渲染并存储在这里
        private List<GeoClassBreaksRenderer> mClassBreaksRenderers = new List<GeoClassBreaksRenderer>();
        private Color[][] mColors = GeoMapDrawingTools.GetColors(); // 提前生成一点好看的颜色
        private Button mClassDefaultButton = null; // 给两个渲染添加默认值
        private Button mUniqueDefaultButton = null;

        #endregion
        public FillSymbolPage(GeoMapLayer layer)
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
            foreach(GeoSimpleLineSymbolStyleConstant s in Enum.GetValues(typeof(GeoSimpleLineSymbolStyleConstant)))
            {
                edgeStyleComboBox.Items.Add(s.ToString());
            }
            for (int i = 0; i < mLayer.AttributeFields.Count; i++)
                uniqueFieldComboBox.Items.Add(mLayer.AttributeFields.GetItem(i).Name);
            for (int i = 0; i < mLayer.AttributeFields.Count; i++)
                if(mLayer.AttributeFields.GetItem(i).ValueType != GeoValueTypeConstant.dText)
                    classFieldComboBox.Items.Add(mLayer.AttributeFields.GetItem(i).Name);
            // 对于不同的渲染模式进行配置
            // 通过出触发时间来进行处理
            if (mLayer.Renderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                mSimpleRenderer = mLayer.Renderer as GeoSimpleRenderer;
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

        // 建立简单渲染的图片
        private Bitmap CreateSimpleFillSymbolImage(GeoSimpleFillSymbol symbol)
        {
            Bitmap styleImage = new Bitmap(50, 25);
            Graphics g = Graphics.FromImage(styleImage);
            SolidBrush sBrush = new SolidBrush(symbol.Color);
            Pen sPen = new Pen(symbol.Outline.Color, (float)symbol.Outline.Size);
            g.FillRectangle(sBrush, new Rectangle(0, 0, styleImage.Width, styleImage.Height));
            g.DrawRectangle(sPen, new Rectangle(0, 0, styleImage.Width, styleImage.Height));
            return styleImage;
        }

        // 建立默认按钮
        private Button GetFillSymbolButton(GeoSimpleFillSymbol symbol, string name)
        {
            Button sButton = new Button();
            sButton.BackColor = symbol.Color;
            sButton.Name = name;
            sButton.Dock = DockStyle.Fill;
            sButton.FlatAppearance.BorderColor = symbol.Outline.Color;
            sButton.FlatAppearance.BorderSize = (int)symbol.Outline.Size;

            MouseEventHandler handler = (sender, e) => SymbolGridButton_MouseClick(sButton, symbol);
            sButton.MouseClick += handler;

            return sButton;
        }

        #region event
        // 处理默认按钮弹出的事件
        private void SymbolGridButton_MouseClick(Button button, GeoSimpleFillSymbol symbol)
        {
            EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm(symbol);
            FormClosedEventHandler handle = (sender, e) => SimpleForm_FormClosed(button, symbol);
            SimpleForm.FormClosed += handle;
            SimpleForm.Show();
        }

        // 在默认按钮修改完成以后，进行刷新
        private void SimpleForm_FormClosed(Button button, GeoSimpleFillSymbol symbol)
        {
            button.BackColor = symbol.Color;
            button.FlatAppearance.BorderColor = symbol.Outline.Color;
            button.FlatAppearance.BorderSize = (int)symbol.Outline.Size;
            button.Refresh();
            if (button.Name == "class")
                UpdateClassBreaksRenderersOutLine();
            else if (button.Name == "unique")
                UpdateUniqueValueRenderersOutLine();
        }

        // 选择颜色
        private void fillColorPicker_ValueChanged(object sender, Color value)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleFillSymbol).Color = value;
        }
        // 选择边框颜色
        private void edgeColorPicker_ValueChanged(object sender, Color value)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleFillSymbol).Outline.Color = value;
        }
        // 选择宽度
        private void edgeWidthDoubleUpDown_ValueChanged(object sender, double value)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleFillSymbol).Outline.Size = value;
        }
        // 选择边框样式
        private void edgeStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((mLayer.Renderer as GeoSimpleRenderer).Symbol as GeoSimpleFillSymbol).Outline.Style = (GeoSimpleLineSymbolStyleConstant)edgeStyleComboBox.SelectedIndex;
        }
        // 唯一值渲染字段修改
        private void uniqueFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uniqueFieldComboBox.SelectedIndex == -1) return;
            // 如果没有新建唯一值渲染，或者是新的字段
            if (mUniqueValueRenderer == null || mUniqueValueRenderer.Field != uniqueFieldComboBox.SelectedItem.ToString())
            {
                mLayer.Renderer = CreateUniqueValueRenderer(uniqueFieldComboBox.SelectedItem.ToString());
                mUniqueValueRenderer = mLayer.Renderer as GeoUniqueValueRenderer;
            }
            if(mLayer.Renderer != null)
            {
                initializeUniqueValueRenderer();
            }
        }
        // 分级渲染字段修改
        private void classFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classFieldComboBox.SelectedIndex == -1) return;
            // 如果没有新建分级渲染，或者是新的字段
            if (mClassBreaksRenderer == null || mClassBreaksRenderer.Field != classFieldComboBox.SelectedItem.ToString())
            {
                // 新建一个渐变色
                Color sStartColor = new GeoSimpleFillSymbol().Color;
                Color sEndColor = Color.FromArgb(sStartColor.R / 2, sStartColor.G / 2, sStartColor.B / 2);
                mLayer.Renderer = CreateClassBreaksRenderer(classFieldComboBox.SelectedItem.ToString(), uiIntegerUpDown2.Value, sStartColor, sEndColor);
                mClassBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            }
            if(mLayer.Renderer != null)
            {
                initializeClassBreaksRenderer(uiIntegerUpDown2.Value);
            }
        }
        // 绘制渐变色的combobox
        private void ClassColorgradComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            Color StartColor = (mClassBreaksRenderers[e.Index].GetSymbol(0) as GeoSimpleFillSymbol).Color;
            Color EndColor = (mClassBreaksRenderers[e.Index].GetSymbol(mClassBreaksRenderers[e.Index].BreakCount - 1) as GeoSimpleFillSymbol).Color;
            LinearGradientBrush sBrush = new LinearGradientBrush(new RectangleF(r.X, r.Y, r.Width, r.Height - 2), StartColor, EndColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(sBrush, r);
            g.DrawRectangle(new Pen(this.BackColor), r);
            e.DrawFocusRectangle();
        }

        // 绘制唯一值渲染的颜色选择盒
        private void UniqueColorgradComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index == -1) return;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            int n = mUniqueValueRenderers[e.Index].ValueCount;
            for (int i = 0; i < n; ++i)
            {
                SolidBrush sBrush = new SolidBrush((mUniqueValueRenderers[e.Index].GetSymbol(i) as GeoSimpleFillSymbol).Color);
                Rectangle sRect = new Rectangle(r.X + i * r.Width / n, r.Y, r.Width / n, r.Height);
                g.FillRectangle(sBrush, sRect);
            }
            g.DrawRectangle(new Pen(this.BackColor), r);
            e.DrawFocusRectangle();
        }

        // 选择渲染方式变化时的函数
        // 大体上就是判断一下是否点击过，点击过之后不会生成新的，不会因为用户选择别的方式而删除前面编辑的结果
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
                if(classFieldComboBox.Items.Count == 0)
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

        // 创建一个分级渲染
        // 用字段，分级数，起始颜色，终止颜色来进行处理
        private GeoClassBreaksRenderer CreateClassBreaksRenderer(string field, int n, Color startColor, Color endColor)
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
                    GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                    sRenderer.AddBreakValue(sValue, sSymbol);
                }
                Color sStartColor = startColor;
                Color sEndColor = endColor;
                sRenderer.RampColor(sStartColor, sEndColor);
                sRenderer.DefaultSymbol = new GeoSimpleFillSymbol();
                return sRenderer;
            }
            catch(Exception e)
            {
                MessageBox.Show("这个字段无法进行分级渲染！");
                return null;
            }
        }
        
        // 当唯一值颜色选择过后修改DataGridView
        private void uniqueColorgradComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mUniqueValueRenderer = mUniqueValueRenderers[uniqueColorgradComboBox.SelectedIndex];
            uniqueDataGridView.Rows.Clear();
            GeoUniqueValueRenderer uniqueValueRenderer = mLayer.Renderer as GeoUniqueValueRenderer;
            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)uniqueValueRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateSimpleFillSymbolImage(fillSymbol);
                uniqueDataGridView.AddRow(symbolImage, uniqueValueRenderer.GetValue(i));
            }
            uniqueDataGridView.Refresh();
        }
        // 分级渲染修改后刷新DataGridView
        private void classColorgradComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.Renderer = mClassBreaksRenderer = mClassBreaksRenderers[classColorgradComboBox.SelectedIndex];
            classDataGridView.Rows.Clear();
            GeoClassBreaksRenderer classBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateSimpleFillSymbolImage(fillSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            classDataGridView.Refresh();
        }
        // 可以单独修改唯一值单个符号
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
        // 可以单独修改分级的单个符号
        private void classDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                EditSimpleSymbolForm SimpleForm = new EditSimpleSymbolForm((mLayer.Renderer as GeoClassBreaksRenderer).GetSymbol(e.RowIndex));
                FormClosedEventHandler handle = (obj, eve) => DataGridView_FormClosed(e.RowIndex, GeoRendererTypeConstant.ClassBreaks);
                SimpleForm.FormClosed += handle;
                SimpleForm.Show();
            }
        }// 在datagridview的符号修改之后，要对那个修改的符号进行刷新
        private void DataGridView_FormClosed(int index, GeoRendererTypeConstant type)
        {
            if (type == GeoRendererTypeConstant.ClassBreaks)
            {
                GeoSimpleFillSymbol symbol = (GeoSimpleFillSymbol)(mLayer.Renderer as GeoClassBreaksRenderer).GetSymbol(index);
                classDataGridView.Rows[index].Cells[0].Value = CreateSimpleFillSymbolImage(symbol);
                classDataGridView.Refresh();
            }
            else if (type == GeoRendererTypeConstant.UniqueValue)
            {
                GeoSimpleFillSymbol symbol = (GeoSimpleFillSymbol)(mLayer.Renderer as GeoUniqueValueRenderer).GetSymbol(index);
                uniqueDataGridView.Rows[index].Cells[0].Value = CreateSimpleFillSymbolImage(symbol);
                uniqueDataGridView.Refresh();
            }
        }
        // 修改了分级数
        private void uiIntegerUpDown2_ValueChanged(object sender, int value)
        {
            if (mClassBreaksRenderer == null)
            {
                MessageBox.Show("当前没有可以调整分级数的渲染！");
                return;
            }
            if (mClassBreaksRenderer.BreakCount != value)
            {
                Color sStartColor = (mClassBreaksRenderer.GetSymbol(0) as GeoSimpleFillSymbol).Color;
                Color sEndColor = (mClassBreaksRenderer.GetSymbol(mClassBreaksRenderer.BreakCount - 1) as GeoSimpleFillSymbol).Color;
                mLayer.Renderer = CreateClassBreaksRenderer(classFieldComboBox.SelectedItem.ToString(), value, sStartColor, sEndColor);
                mClassBreaksRenderer = mLayer.Renderer as GeoClassBreaksRenderer;
            }
            if (mLayer.Renderer != null)
            {
                initializeClassBreaksRenderer(value);  
            }
        }
        #endregion

        // 创建简单渲染
        private void initializeSimpleRenderer()
        {
            GeoSimpleRenderer simpleRenderer = (GeoSimpleRenderer)mLayer.Renderer;
            mSimpleRenderer = simpleRenderer;
            GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)simpleRenderer.Symbol;
            fillColorPicker.Value = fillSymbol.Color;
            edgeColorPicker.Value = fillSymbol.Outline.Color;
            edgeWidthDoubleUpDown.Value = fillSymbol.Outline.Size;
            edgeStyleComboBox.SelectedIndex = (int)fillSymbol.Outline.Style;
        }
        // 初始化唯一值渲染界面
        private void initializeUniqueValueRenderer()
        {
            uniqueColorgradComboBox.Items.Clear();
            uniqueDataGridView.Rows.Clear();
            mUniqueValueRenderers.Clear();

            GeoUniqueValueRenderer uniqueValueRenderer = (GeoUniqueValueRenderer)mLayer.Renderer;
            mUniqueValueRenderer = uniqueValueRenderer;
            mUniqueValueRenderers.Add(mUniqueValueRenderer);

            if (mUniqueDefaultButton != null) uniqueTableLayoutPanel.Controls.Remove(mUniqueDefaultButton);
            Button defaultSymbolButton = GetFillSymbolButton((GeoSimpleFillSymbol)uniqueValueRenderer.DefaultSymbol, "unique");
            mUniqueDefaultButton = defaultSymbolButton;
            uniqueTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);

            for (int i = 0; i < uniqueValueRenderer.ValueCount; i++)
            {
                GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)uniqueValueRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateSimpleFillSymbolImage(fillSymbol);
                uniqueDataGridView.AddRow(symbolImage, uniqueValueRenderer.GetValue(i));
            }
            CreateUniqueValueRenderers((mLayer.Renderer as GeoUniqueValueRenderer).Field);

            uniqueColorgradComboBox.Items.AddRange(mUniqueValueRenderers.ToArray());
            uniqueColorgradComboBox.SelectedIndex = 0;
            uniqueDataGridView.Refresh();
        }

        // 初始化分级渲染界面
        private void initializeClassBreaksRenderer(int value)
        {
            classColorgradComboBox.Items.Clear();
            classDataGridView.Rows.Clear();
            mClassBreaksRenderers.Clear();

            GeoClassBreaksRenderer classBreaksRenderer = (GeoClassBreaksRenderer)mLayer.Renderer;
            mClassBreaksRenderer = classBreaksRenderer;
            mClassBreaksRenderers.Add(mClassBreaksRenderer);

            if (mClassDefaultButton != null) classTableLayoutPanel.Controls.Remove(mClassDefaultButton);

            Button defaultSymbolButton = GetFillSymbolButton((GeoSimpleFillSymbol)classBreaksRenderer.DefaultSymbol, "class");
            mClassDefaultButton = defaultSymbolButton;
            classTableLayoutPanel.Controls.Add(defaultSymbolButton, 1, 2);

            for (int i = 0; i < classBreaksRenderer.BreakCount; i++)
            {
                GeoSimpleFillSymbol fillSymbol = (GeoSimpleFillSymbol)classBreaksRenderer.GetSymbol(i);
                Bitmap symbolImage = CreateSimpleFillSymbolImage(fillSymbol);
                classDataGridView.AddRow(symbolImage, classBreaksRenderer.GetBreakValue(i).ToString("F2"));
            }
            CreateClassBreaksRenderers((mLayer.Renderer as GeoClassBreaksRenderer).Field, value);

            classColorgradComboBox.Items.AddRange(mClassBreaksRenderers.ToArray());
            classColorgradComboBox.SelectedIndex = 0;
            classDataGridView.Refresh();

        }
        // 创建多个分级渲染
        private void CreateClassBreaksRenderers(string field, int value)
        {
            for (int i = 0; i < mColors.Length; ++i)
            {
                mClassBreaksRenderers.Add(CreateClassBreaksRenderer(field, value, mColors[i][0], mColors[i][1]));
            }
        }
        // 创建唯一值渲染
        private GeoUniqueValueRenderer CreateUniqueValueRenderer(string field)
        {
            try
            {
                GeoUniqueValueRenderer sRenderer = new GeoUniqueValueRenderer();
                sRenderer.Field = field;
                int index = mLayer.AttributeFields.FindField(field);
                List<string> sValues = new List<string>();
                int sFeatureCount = mLayer.Features.Count;
                for (int i = 0; i < sFeatureCount; i++)
                {
                    string svalue = mLayer.Features.GetItem(i).Attributes.GetItem(index).ToString();
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
                return sRenderer;
            }
            catch (Exception e)
            {
                MessageBox.Show("这个字段不能进行唯一值渲染");
                return null;
            }

        }
        // 创建多个唯一值渲染供选择
        private void CreateUniqueValueRenderers(string field)
        {
            for (int i = 0; i < 5; ++i)
            {
                mUniqueValueRenderers.Add(CreateUniqueValueRenderer(field));
            }
        }
        // 建立简单渲染
        private GeoSimpleRenderer CreateSimpleRenderer()
        {
            GeoSimpleRenderer sRenderer = new GeoSimpleRenderer();
            GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
            sRenderer.Symbol = sSymbol;
            return sRenderer;
        }
        // 更新所有分级渲染的宽度
        private void UpdateClassBreaksRenderersOutLine()
        {
            for (int i = 0; i < mClassBreaksRenderers.Count; ++i)
            {
                GeoClassBreaksRenderer sRenderer = mClassBreaksRenderers[i];
                for (int j = 0; j < sRenderer.BreakCount; ++j)
                {
                    GeoSimpleFillSymbol sSymbol = (sRenderer.GetSymbol(j) as GeoSimpleFillSymbol);
                    GeoSimpleFillSymbol sDefaultSymbol = (mClassBreaksRenderer.DefaultSymbol as GeoSimpleFillSymbol);
                    sSymbol.Outline.Size = sDefaultSymbol.Outline.Size;
                    sSymbol.Outline.Style = sDefaultSymbol.Outline.Style;
                    sSymbol.Outline.Color = sDefaultSymbol.Outline.Color;
                }
            }
        }
        // 更新所有唯一值渲染宽度
        private void UpdateUniqueValueRenderersOutLine()
        {
            for (int i = 0; i < mUniqueValueRenderers.Count; ++i)
            {
                GeoUniqueValueRenderer sRenderer = mUniqueValueRenderers[i];
                for (int j = 0; j < sRenderer.ValueCount; ++j)
                {
                    GeoSimpleFillSymbol sSymbol = (sRenderer.GetSymbol(j) as GeoSimpleFillSymbol);
                    GeoSimpleFillSymbol sDefaultSymbol = (mUniqueValueRenderer.DefaultSymbol as GeoSimpleFillSymbol);
                    sSymbol.Outline.Size = sDefaultSymbol.Outline.Size;
                    sSymbol.Outline.Style = sDefaultSymbol.Outline.Style;
                    sSymbol.Outline.Color = sDefaultSymbol.Outline.Color;
                }
            }
        }


    }
}
