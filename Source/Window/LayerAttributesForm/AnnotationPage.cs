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
using DEETU.Core;
using DEETU.Tool;

namespace DEETU.Source.Window
{
    public partial class AnnotationPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        #endregion

        public AnnotationPage(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;
            InitializeAnnotations();
        }

        #region 私有函数
        private void InitializeAnnotations()
        {
            GeoFields fields = mLayer.AttributeFields;
            for (int i = 0; i < fields.Count; i++)
            {
                fieldComboBox.Items.Add(fields.GetItem(i).Name);
            }
            GeoLabelRenderer labelRenderer = mLayer.LabelRenderer;
            if (labelRenderer == null)
            {
                labelPanel.SetDisabled();
                enableCheckBox.Checked = false;
                return;
            }
            enableCheckBox.Checked = labelRenderer.LabelFeatures;
            ShowLabelRendererInfo(labelRenderer);

        }

        private void ShowLabelRendererInfo(GeoLabelRenderer labelRenderer)
        {
            fieldComboBox.SelectedItem = labelRenderer.Field;
            string fontString = GetFontString(labelRenderer.TextSymbol.Font);

            fontTextBox.Text = fontString;
            fontColotPicker.Value = labelRenderer.TextSymbol.FontColor;

            maskCheckBox.Checked = labelRenderer.TextSymbol.UseMask;
            maskColorPicker.Value = labelRenderer.TextSymbol.MaskColor;
            maskSizeDoubleUpDown.Value = labelRenderer.TextSymbol.MaskWidth;
            if (maskCheckBox.Checked)
            {
                tableLayoutPanel1.SetEnabled();
            }
            else
                tableLayoutPanel1.SetDisabled();
            alignmentRadioButtonGroup.SelectedIndex = (int)labelRenderer.TextSymbol.Alignment;
            xOffsetDoubleUpDown.Value = labelRenderer.TextSymbol.OffsetX;
            yOffsetDoubleUpDown.Value = labelRenderer.TextSymbol.OffsetY;
        }

        private static string GetFontString(Font font)
        {
            string fontString = font.Name + " ";
            fontString += font.Size.ToString() + " " + font.Style.ToString();
            return fontString;
        }
        #endregion

        #region 事件处理函数
        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableCheckBox.Checked)
            {
                labelPanel.SetEnabled();
                if (mLayer.LabelRenderer == null)
                {
                    mLayer.LabelRenderer = new GeoLabelRenderer();
                    mLayer.LabelRenderer.Field = mLayer.AttributeFields.GetItem(0).Name;
                }
                mLayer.LabelRenderer.LabelFeatures = true;
                ShowLabelRendererInfo(mLayer.LabelRenderer);
            }
            else
            {
                labelPanel.SetDisabled();
                if (mLayer.LabelRenderer != null)
                    mLayer.LabelRenderer.LabelFeatures = false;
            }
        }

        private void maskCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maskCheckBox.Checked)
            {
                tableLayoutPanel1.SetEnabled();
                mLayer.LabelRenderer.TextSymbol.UseMask = true;
            }
            else
            {
                mLayer.LabelRenderer.TextSymbol.UseMask = false;
                tableLayoutPanel1.SetDisabled();
            }
        }

        private void fieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLayer.LabelRenderer.Field = mLayer.AttributeFields.GetItem(fieldComboBox.SelectedIndex).Name;
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            mLayer.LabelRenderer.TextSymbol.Font = fontDialog.Font;
            fontTextBox.Text = GetFontString(mLayer.LabelRenderer.TextSymbol.Font);
        }

        private void fontColotPicker_ValueChanged(object sender, Color value)
        {
            mLayer.LabelRenderer.TextSymbol.FontColor = value;
        }

        private void maskColorPicker_ValueChanged(object sender, Color value)
        {
            mLayer.LabelRenderer.TextSymbol.MaskColor = value;
        }

        private void maskSizeDoubleUpDown_ValueChanged(object sender, double value)
        {
            mLayer.LabelRenderer.TextSymbol.MaskWidth = value;
        }

        private void xOffsetDoubleUpDown_ValueChanged(object sender, double value)
        {
            mLayer.LabelRenderer.TextSymbol.OffsetX = value;
        }

        private void yOffsetDoubleUpDown_ValueChanged(object sender, double value)
        {
            mLayer.LabelRenderer.TextSymbol.OffsetY = value;
        }

        private void alignmentRadioButtonGroup_ValueChanged(object sender, int index, string text)
        {
            mLayer.LabelRenderer.TextSymbol.Alignment = (GeoTextSymbolAlignmentConstant)index;
        }
        #endregion
    }
}
