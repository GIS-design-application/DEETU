using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using DEETU.Core;

namespace DEETU.Source.Window
{
    public partial class CrsEditForm : UIEditForm
    {
        #region 字段
        private GeographicCrsType? _GeographicCrs = null;
        private ProjectedCrsType? _ProjectedCrs = null;
        #endregion

        public CrsEditForm()
        {
            InitializeComponent();
            InitializeCrs();
        }

        #region 属性
        public GeographicCrsType? GeographicCrs { get => _GeographicCrs; }
        public ProjectedCrsType? ProjectedCrs { get => _ProjectedCrs; }
        #endregion

        private void InitializeCrs()
        {
            geoComboBox.Items.AddRange(Enum.GetNames(typeof(GeographicCrsType)));
            projectComboBox.Items.AddRange(Enum.GetNames(typeof(ProjectedCrsType)));
            geoComboBox.SelectedIndex = 0;
            projectComboBox.SelectedIndex = 0;
        }

        private void geoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (geoComboBox.SelectedIndex == 0)
            {
                _GeographicCrs = null;
                geoRichText.Text = "";
            }
            else
            {
                _GeographicCrs = (GeographicCrsType)geoComboBox.SelectedIndex;
                if (_GeographicCrs == GeographicCrsType.Beijing1954)
                    geoRichText.Text = ParamOutput(GeoCoordinateFactory.DefaultBeijing1954Param);
                if (_GeographicCrs == GeographicCrsType.WGS84)
                    geoRichText.Text = ParamOutput(GeoCoordinateFactory.DefaultWGS84Param);
            }
        }

        private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectComboBox.SelectedIndex == 0)
            {
                _ProjectedCrs = null;
                projectRichText.Text = "";
            }
            else
            {
                _ProjectedCrs = (ProjectedCrsType)projectComboBox.SelectedIndex;
                if (_ProjectedCrs == ProjectedCrsType.Lambert2SP)
                    projectRichText.Text = ParamOutput(GeoCoordinateFactory.DefaultLambert2SPParam);
                if (_ProjectedCrs == ProjectedCrsType.WebMercator)
                    projectRichText.Text = ParamOutput(GeoCoordinateFactory.DefaultWebMercatorParam);
            }
        }

        private string ParamOutput(Dictionary<string, string> param)
        {
            string result = "";
            foreach (string key in param.Keys)
            {
                result += key + ": " + param[key] + "\n";
            }
            return result;
        }

    }


}
