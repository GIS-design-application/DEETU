using DEETU.Core;
using DEETU.Map;
using DEETU.Tool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEETU.Source.Window
{
    public partial class NewLayerForm : UIForm
    {
        public NewLayerForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        internal GeoMapLayer Layer = null;

        private void InitializeComboBoxes()
        {
            GeometryTypeComboBox.Items.AddRange(new string[3] {
                "Point",
                "MultiPolyline",
                "MultiPolygon"
            });

            GeoCrsComboBox.Items.AddRange(new string[2]
            {
                "WGS84",
                "Beijing1954",
            });

            PrjCrsComboBox.Items.AddRange(new string[3]
            {
                "WebMercator",
                "Lambert2SP",
                "None"
            });

            FieldTypeComboBox.Items.AddRange(new string[6]
            {
                "dInt16",
                "dInt32",
                "dInt64",
                "dSingle",
                "dDouble",
                "dText",
            });
        }

        private void AddField_Click(object sender, EventArgs e)
        {
            if (FieldTypeComboBox.SelectedItem == null)
            {
                UIMessageBox.Show("请选择字段类型");
                return;
            }

            var fieldName = FieldNameTextBox.Text;
            var fieldType = FieldTypeComboBox.SelectedText;

            FieldListDataGrid.AddRow(new string[2]{ fieldName, fieldType });

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in FieldListDataGrid.SelectedRows)
            {
                FieldListDataGrid.Rows.Remove(row);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (PrjCrsComboBox.SelectedItem == null || GeoCrsComboBox.SelectedItem == null || GeometryTypeComboBox.SelectedItem == null)
            {
                UIMessageBox.Show("未定义必要属性");
                return;
            }

            // 基本信息

            var layerName = LayerNameTextBox.Text;
            var layerType = (GeoGeometryTypeConstant)GeometryTypeComboBox.SelectedIndex;

            
            GeoCoordinateReferenceSystem crs = null;
            if (PrjCrsComboBox.SelectedIndex != 2)
            {
                crs = new GeoCoordinateReferenceSystem((GeographicCrsType)GeoCrsComboBox.SelectedIndex +1, (ProjectedCrsType)PrjCrsComboBox.SelectedIndex+1);
            }
            else
            {
                crs = new GeoCoordinateReferenceSystem((GeographicCrsType)GeoCrsComboBox.SelectedIndex+1, null);
            }

            // 属性信息
            var geoFields = new GeoFields();

            foreach (DataGridViewRow row in FieldListDataGrid.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                string name = (string)row.Cells[0].Value;
                var type = GeoValueTypeConstant.dDouble;
                switch ((string)row.Cells[1].Value)
                {
                    case "dDouble":
                        type = GeoValueTypeConstant.dDouble;
                        break;
                    case "dInt16":
                        type = GeoValueTypeConstant.dInt16;
                        break;
                    case "dInt32":
                        type = GeoValueTypeConstant.dInt32;
                        break;
                    case "dInt64":
                        type = GeoValueTypeConstant.dInt64;
                        break;
                    case "dSingle":
                        type = GeoValueTypeConstant.dSingle;
                        break;
                    case "dText":
                        type = GeoValueTypeConstant.dText;
                        break;
                    default:
                        break;
                }


                var field = new GeoField(name, type);
                try
                {
                    geoFields.Append(field);
                }
                catch (Exception error)
                {
                    UIMessageBox.Show(error.ToString());
                }
            }

            Layer = new GeoMapLayer(layerName, layerType, geoFields);
            Layer.Crs = crs;

            this.Close();
        }
    }
}
