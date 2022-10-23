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
    public partial class InfoPage : UITitlePage
    {
        #region 字段
        private GeoMapLayer mLayer;
        #endregion
        public InfoPage(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;

            // 设置RichTextBox的背景色
            nameRichTextBox.BackColor = this.BackColor;
            pathRichTextBox.BackColor = this.BackColor;
            descriptionRichTextBox.BackColor = this.BackColor;
            extentRichTextBox.BackColor = this.BackColor;
            geometryRichTextBox.BackColor = this.BackColor;
            crsRichTextBox.BackColor = this.BackColor;
            unitRichTextBox.BackColor = this.BackColor;
            countRichTextBox.BackColor = this.BackColor;
            fieldRichTextBox.BackColor = this.BackColor;

            InitializeInfo();

        }

        #region 私有函数
        private void InitializeInfo()
        {
            nameRichTextBox.Text = mLayer.Name;
            descriptionRichTextBox.Text = mLayer.Description;

            if (mLayer.ShapeType == GeoGeometryTypeConstant.Point)           
                geometryRichTextBox.Text = "Point";
            if (mLayer.ShapeType == GeoGeometryTypeConstant.MultiPolyline)           
                geometryRichTextBox.Text = "MultiPolyline";
            if (mLayer.ShapeType == GeoGeometryTypeConstant.MultiPolygon)           
                geometryRichTextBox.Text = "MultiPolygon";

            countRichTextBox.Text = mLayer.Features.Count.ToString();

            double MaxX = mLayer.Extent.MaxX;
            double MaxY = mLayer.Extent.MaxY;
            double MinX = mLayer.Extent.MinX;
            double MinY = mLayer.Extent.MinY;
            if (MaxX*MaxY*MinX*MinY != 0)
                extentRichTextBox.Text = String.Format("{0},{1};\n{2},{3}", MinX, MaxX, MinY, MaxY);

            GeoFields fields = mLayer.AttributeFields;
            fieldRichTextBox.Text = fields.Count.ToString();
            if (fields.Count == 0)
                fieldDataGridView.Visible = false;
            for (int i = 0; i < fields.Count; i++)
            {
                GeoField f = fields.GetItem(i);
                fieldDataGridView.AddRow(f.Name, f.AliaName, f.ValueType.ToString());
            }

        }
        #endregion

    }
}
