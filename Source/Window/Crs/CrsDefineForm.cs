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
    public partial class CrsDefineForm : UIEditForm
    {
        #region 字段
        private GeoMapLayer mLayer;
        private GeoCoordinateReferenceSystem _SourceCrs;
        private GeoCoordinateReferenceSystem _TargetCrs;

        #endregion
        
        public CrsDefineForm(GeoMapLayer layer)
        {
            InitializeComponent();
            mLayer = layer;
            InitializeCrs();
        }
        private void InitializeCrs()
        {
             _SourceCrs = mLayer.Crs;
            sourceCrsText.Text = _SourceCrs.ProjectedCrs.ToString() + " " + _SourceCrs.GeographicCrs.ToString();
        }

        private void chooseCrsButton_Click(object sender, EventArgs e)
        {
            CrsEditForm crsEdit = new CrsEditForm();
            crsEdit.ShowDialog();
            if (crsEdit.IsOK)
            {
                _TargetCrs = new GeoCoordinateReferenceSystem(crsEdit.GeographicCrs, crsEdit.ProjectedCrs);
                targetCrsTest.Text = _TargetCrs.ProjectedCrs.ToString() + " " + _TargetCrs.GeographicCrs.ToString();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            mLayer.Crs = _TargetCrs;
            btnOK_Click(sender, e);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
