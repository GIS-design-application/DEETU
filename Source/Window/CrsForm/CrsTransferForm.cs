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
    public partial class CrsTransferForm : UIEditForm
    {
        #region 字段
        private GeoMapLayer mLayer;
        private GeoCoordinateReferenceSystem _SourceCrs;
        private GeoCoordinateReferenceSystem _TargetCrs;
        #endregion
        
        public CrsTransferForm(GeoMapLayer layer)
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
            List<GeoMapLayer> layers = new List<GeoMapLayer>();
            layers.Add(mLayer);
            try
            {
                CoordinateTransform transform = new CoordinateTransform(_SourceCrs, _TargetCrs, layers);
                transform.Transform();
                ShowSuccessNotifier("坐标系转换完成");
                this.btnOK_Click(sender, e);
                this.Close();
                
            }
            catch(Exception error)
            {
                Sunny.UI.UIMessageBox.Show(error.Message);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
