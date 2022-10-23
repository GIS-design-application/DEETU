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
            fontTextBox.Text = labelRenderer.TextSymbol.Font.ToString();
            maskCheckBox.Checked = labelRenderer.TextSymbol.UseMask;
            if (maskCheckBox.Checked)
            {
                maskColorPicker.Value = labelRenderer.TextSymbol.MaskColor;
                maskSizeDoubleUpDown.Value = labelRenderer.TextSymbol.MaskWidth;
            }
            else
                tableLayoutPanel1.SetDisabled();
            alignmentRadioButtonGroup.SelectedIndex = (int)labelRenderer.TextSymbol.Alignment;
        }
    }
}
