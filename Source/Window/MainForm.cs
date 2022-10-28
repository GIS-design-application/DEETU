using DEETU.Core;
using DEETU.Geometry;
using DEETU.IO;
using DEETU.Map;
using DEETU.Tool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using DEETU.Testing;
using DEETU.Source.IO;

namespace DEETU
{
    public partial class MainForm : Form
    {
        #region �ֶ�
        // ѡ�����
        private Color mZoomBoxColor = Color.DeepPink; // �Ŵ����ɫ
        private double mZoomBoxWidth = 0.53; // �Ŵ�еı߽���
        private Color mSelectBoxColor = Color.DarkGreen; // ѡ�����ɫ
        private double mSelectBoxWidth = 0.53; // ѡ��б߽���
        private double mZoomRatioFixed = 2; // �̶�����ϵ��
        private double mZoomRatioMouseWheel = 1.2; //��������ϵ��
        private double mSelectingTolerance = 3;// ��λ����
        private GeoSimpleFillSymbol mSelectingBoxSymbol; // ѡ��еķ���
        private GeoSimpleFillSymbol mZoomBoxSymbol; // �Ŵ�еķ���
        private GeoSimpleFillSymbol mMovingPolygonSymbol; // �ƶ�����εķ���
        private GeoSimpleFillSymbol mEditingPolygonSymbol; // �༭����εķ���
        private GeoSimpleMarkerSymbol mEditingVertexSymbol; // �༭�ֱ�����
        private GeoSimpleMarkerSymbol mEditingVertexHoverSymbol; // �༭�ֱ�����:hover
        private GeoSimpleLineSymbol mElasticSymbol; // ��Ƥ�����


        // ���ͼ�����йصı���
        private int mMapOpStyle = 0; // 1: �Ŵ�, 2: ��С, 3: ����, 4: ѡ��, 5: ��ѯ
                                     // 6: �ƶ�, 7: ���, 8: �༭
        private PointF mStartMouseLocation; // ����ʱ�����
        private bool mIsInZoomIn = false; // �Ƿ��ڷŴ�
        private bool mIsInZoomOut = false; // �Ƿ�����С
        private bool mIsInPan = false; // �Ƿ������� 
        private bool mIsInIdentify = false; // �Ƿ��ڲ�ѯ
        private bool mIsInSelect = false;
        private bool mIsMovingShapes = false; // �Ƿ������ƶ�ͼ��
        private bool mIsEditingShapes = false; // �Ƿ����ڱ༭ͼ��
        private List<GeoGeometry> mMovingGeometries = new List<GeoGeometry>(); // �����ƶ���ͼ�μ���
        private GeoGeometry mEditingGeometry; // ���ڱ༭��ͼ��
        private GeoPoint mEditingPoint, mEditingLeftPoint, mEditingRightPoint; // ���ڱ༭��ͼ���б���������ĵ�
        private List<GeoPoints> mSketchingShape; // ��������ͼ��, ��һ����㼯�ϴ洢


        #endregion


        public MainForm()
        {
            InitializeComponent();
            geoMap.MouseWheel += geoMap_MouseWheel;
            
        }


        #region ����Ͱ�ť�¼�����

        // װ�ش���
        private void MainForm_Load(object sender, EventArgs e)
        {
            // (1) ��ʼ������
            InitializeSymbols();
            // (2) ��ʼ�����ͼ��
            InitializeSketchingShape();
            // (3) ��ʾ������
            ShowMapScale();
        }

        private void btnLoadLayerFile_Click(object sender, EventArgs e)
        {
            // ��ȡ�ļ���
            OpenFileDialog sDialog = new OpenFileDialog();
            string sFileName = "";
            if (sDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = sDialog.FileName;
                sDialog.Dispose();
            }
            else
            {
                sDialog.Dispose();
                return;
            }

            try
            {
                FileStream sStream = new FileStream(sFileName, FileMode.Open);
                BinaryReader sr = new BinaryReader(sStream);
                GeoMapLayer sLayer = GeoDataIOTools.LoadMapLayer(sr);
                geoMap.Layers.Add(sLayer);
                if (geoMap.Layers.Count == 1)
                {
                    geoMap.FullExtent();
                }
                else
                {
                    geoMap.RedrawMap();
                }
                sStream.Dispose();
                sr.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private void btnSHPLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog sOpenFileDialog = new OpenFileDialog();
            sOpenFileDialog.Filter = "shapefiles(*.shp)|*.shp|All files(*.*)|*.*";
            sOpenFileDialog.FilterIndex = 1;
            if (sOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GeoMapLayer sLayer = GeoShpIOTools.ReadSHPFile(sOpenFileDialog.FileName);
                    char[] path = sOpenFileDialog.FileName.ToCharArray();
                    if (path.Length != 0)
                    {
                        path[path.Length - 1] = 'f';
                        path[path.Length - 2] = 'b';
                        path[path.Length - 3] = 'd';

                        GeoShpIOTools.ReadDBFFile(new string(path), sLayer);
                    }
                    //TODO:layer����layers
                    //TODO:ˢ�»���
                    geoMap.Layers.Add(sLayer);
                    if (geoMap.Layers.Count == 1)
                    {
                        geoMap.FullExtent();
                    }
                    else
                    {
                        geoMap.RedrawMap();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
        }
        private void btnFullExtent_Click(object sender, EventArgs e)
        {
            geoMap.FullExtent();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 1;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 2;
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 3;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 4;
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 5;
        }

        // ����Ⱦ
        private void btnSimpleRender_Click(object sender, EventArgs e)
        {
            // ���Ҷ����ͼ��
            GeoMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            GeoSimpleRenderer sRenderer = new GeoSimpleRenderer();
            GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
            sRenderer.Symbol = sSymbol;
            sLayer.Renderer = sRenderer;
            geoMap.RedrawMap();
        }

        // Ψһֵ��Ⱦ
        private void btnUniqueValue_Click(object sender, EventArgs e)
        {
            // ���Ҷ����ͼ��
            GeoMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            // �ٶ���һ���ֶ�����Ϊ"����"��Ϊ�ַ���

            GeoUniqueValueRenderer sRenderer = new GeoUniqueValueRenderer();
            sRenderer.Field = "����";
            List<string> sValues = new List<string>();
            int sFeatureCount = sLayer.Features.Count;
            for (int i = 0; i < sFeatureCount; i++)
            {
                string svalue = (string)sLayer.Features.GetItem(i).Attributes.GetItem(0); // ����ʹ��0 �ٶ���һ�������ַ���������
                sValues.Add(svalue);
            }
            // ȥ���ظ�
            sValues = sValues.Distinct().ToList();
            // ���ɷ���
            int sValueCount = sValues.Count;
            for (int i = 0; i < sValueCount; i++)
            {
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sRenderer.AddUniqueValue(sValues[i], sSymbol);

            }
            sRenderer.DefaultSymbol = new GeoSimpleFillSymbol();
            sLayer.Renderer = sRenderer;
            geoMap.RedrawMap();
        }

        private void btnClassBreaks_Click(object sender, EventArgs e)
        {
            GeoMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
            {
                return;
            }
            // �������"f5"���ֶ���Ϊ�����ȸ�����
            GeoClassBreaksRenderer sRenderer = new GeoClassBreaksRenderer();
            sRenderer.Field = "F5";
            List<double> sValues = new List<double>();
            int sFeatureCount = sLayer.Features.Count;
            int sFieldIndex = sLayer.AttributeFields.FindField(sRenderer.Field);
            for (int i = 0; i < sFeatureCount; i++)
            {
                double sValue = (float)sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                sValues.Add(sValue);
            }
            // ��ȡ��С, ���ֵ, ����Ϊ5��
            double sMinValue = sValues.Min();
            double sMaxValue = sValues.Max();
            for (int i = 0; i < 5; i++)
            {
                double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / 5;
                GeoSimpleFillSymbol sSymbol = new GeoSimpleFillSymbol();
                sRenderer.AddBreakValue(sValue, sSymbol);
            }
            Color sStartColor = Color.FromArgb(255, 255, 192, 192);
            Color sEndColor = Color.Maroon;
            sRenderer.RampColor(sStartColor, sEndColor);
            sRenderer.DefaultSymbol = new GeoSimpleFillSymbol();
            sLayer.Renderer = sRenderer;
            geoMap.RedrawMap();
        }

        private void btnShowLabel_Click(object sender, EventArgs e)
        {
            if (geoMap.Layers.Count == 0)
                return;
            // ��ȡ��һ��ͼ��
            GeoMapLayer sLayer = geoMap.Layers.GetItem(0);
            GeoLabelRenderer sLabelRenderer = new GeoLabelRenderer();
            sLabelRenderer.Field = sLayer.AttributeFields.GetItem(0).Name;
            Font sOldFont = sLabelRenderer.TextSymbol.Font;
            sLabelRenderer.TextSymbol.Font = new Font(sOldFont.Name, 12);
            sLabelRenderer.TextSymbol.UseMask = true;
            sLabelRenderer.LabelFeatures = true;
            sLayer.LabelRenderer = sLabelRenderer;
            geoMap.RedrawMap();
        }

        // �ƶ������
        private void btnMovePolygon_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 6;
        }

        // �������
        private void btnSketchPolygon_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 7;
        }

        // ����part
        private void btnEndPart_Click(object sender, EventArgs e)
        {
            // �ж��Ƿ���Խ���:����������
            if (mSketchingShape.Last().Count < 3)
            {
                return;
            }
            // ��list������һ��������
            GeoPoints sPoints = new GeoPoints();
            mSketchingShape.Add(sPoints);
            geoMap.RedrawTrackingShapes();
        }

        private void btnEndSketch_Click(object sender, EventArgs e)
        {
            // �����������
            // �����Ƿ���Խ���
            if (mSketchingShape.Last().Count >= 1 && mSketchingShape.Last().Count < 3)
            {
                return;
            }
            if (mSketchingShape.Last().Count == 0)
            {
                mSketchingShape.Remove(mSketchingShape.Last());
            }
            // ���ȥ��û�޸����, ɾ���յ�, �û����ٻ�������һ�������, ��ô�ͼ�������ͼ��.
            if (mSketchingShape.Count > 0)
            {
                GeoMapLayer sLayer = GetPolygonLayer();
                if (sLayer != null)
                { // ����һ�����϶����
                    GeoMultiPolygon sMultipolygon = new GeoMultiPolygon();
                    sMultipolygon.Parts.AddRange(mSketchingShape.ToArray());
                    sMultipolygon.UpdateExtent(); // �ǵ�ֻҪ����α��޸ľ���Ҫ���¶���εķ�Χ
                    // ����Ҫ�ز�����ͼ��
                    GeoFeature sFeature = sLayer.GetNewFeature();

                    // ������ͼ�μ��뵽feature֮��, feature���뵽ͼ��
                    sFeature.Geometry = sMultipolygon;
                    sLayer.Features.Add(sFeature);
                    sLayer.UpdateExtent(); // �ǵ�ͼ���޸�֮��Ҳ��Ҫ���¶���εķ�Χ
                }
            }

            // ��ʼ�����ͼ��
            InitializeSketchingShape();
            geoMap.RedrawMap();
        }

        private void btnEditPolygon_Click(object sender, EventArgs e)
        {
            GeoMapLayer slayer = GetPolygonLayer();
            if (slayer == null)
            {
                return;
            }
            // �Ƿ����һ��ѡ��Ҫ��(����û��, �����ж��)
            if (slayer.SelectedFeatures.Count != 1)
                return;
            GeoMultiPolygon sOriMultiPolygon = slayer.SelectedFeatures.GetItem(0).Geometry as GeoMultiPolygon;
            GeoMultiPolygon sDesMultiPolygon = sOriMultiPolygon.Clone() as GeoMultiPolygon;
            mEditingGeometry = sDesMultiPolygon;

            mMapOpStyle = 8;
            geoMap.RedrawTrackingShapes();
        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            // ��mEditingGeometry�еĶ���ηŻ�slayer��
            GeoMapLayer slayer = GetPolygonLayer();
            slayer.SelectedFeatures.GetItem(0).Geometry = mEditingGeometry;
            
            // ȡ���༭�����
            mEditingGeometry = null;

            mMapOpStyle = -1;

            // �ػ�
            geoMap.RedrawMap();
        }
        #endregion

        #region ��ͼ�ؼ��¼�����
        private void geoMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)
            {
                OnZoomIn_MouseDown(e);
            }
            else if (mMapOpStyle == 2)
            {
                OnZoomOut_MouseDown(e);
            }
            else if (mMapOpStyle == 3)
            {
                OnPan_MouseDown(e);
            }
            else if (mMapOpStyle == 4)
            {
                OnSelect_MouseDown(e);
            }
            else if (mMapOpStyle == 5)
            {
                OnIdentify_MouseDown(e);
            }
            else if (mMapOpStyle == 6)
            {
                OnMoveShape_MouseDown(e);
            }
            else if (mMapOpStyle == 7)
            {

            }
            else if (mMapOpStyle == 8)
            {
                OnEditShape_MouseDown(e);
            }
        }

        private void OnEditShape_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            GeoMultiPolygon editingPolygon = mEditingGeometry as GeoMultiPolygon; // Ŀǰֻ����ѡ��һ�������

            // �ҵ���������Ӧ�ĵ�
            GeoPoint mousePoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);

            // ������ĵ㲢���ڶ���θ���, ֱ�ӷ���
            if (!editingPolygon.GetEnvelope().IsInside(mousePoint, tolerance))
            {
                return;
            }

            // �������е㼯
            for (int i = 0; i < editingPolygon.Parts.Count; i++)
            {
                // ��ÿһ���㼯�ж��Ƿ�������ķ�Χ
                GeoPoints points = editingPolygon.Parts.GetItem(i);
                if (!points.GetEnvelope().IsInside(mousePoint, tolerance))
                {
                    continue;
                }
                else
                {
                    // ����ÿһ����
                    for (int j = 0; j < points.Count; j++)
                    {
                        if (GeoMapTools.IsPointOnPoint(points.GetItem(j), mousePoint, tolerance))
                        {
                            mEditingPoint = points.GetItem(j);
                            if (j == 0)
                            {
                                mEditingLeftPoint = points.GetItem(points.Count - 1);
                                mEditingRightPoint = points.GetItem(j + 1);
                            }
                            else if (j == points.Count - 1)
                            {
                                mEditingLeftPoint = points.GetItem(j - 1);
                                mEditingRightPoint = points.GetItem(0);
                            }
                            else
                            {
                                mEditingLeftPoint = points.GetItem(j - 1);
                                mEditingRightPoint = points.GetItem(j + 1);
                            }
                            mIsEditingShapes = true;
                            geoMap.RedrawTrackingShapes();
                            return;
                        }
                    }
                }
            }

            // û���ҵ������, Ӧ���Ƕ�����ڸ������Ǻ͵����Ҳ����, �е��
            return;
        }

        private void OnMoveShape_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            // ����һ�������ͼ��
            GeoMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
            {
                return;
            }

            // �ж��Ƿ���ѡ�е�Ҫ��
            int sSelFeatureCount = sLayer.SelectedFeatures.Count;
            if (sSelFeatureCount == 0)
                return;
            mMovingGeometries.Clear();
            for (int i = 0; i < sSelFeatureCount; i++)
            {
                GeoMultiPolygon sOriPolygon = (GeoMultiPolygon)sLayer.SelectedFeatures
                                                                    .GetItem(i).Geometry;
                GeoMultiPolygon sDesPolygon = (GeoMultiPolygon)sOriPolygon.Clone();
                mMovingGeometries.Add(sDesPolygon);

            }

            mStartMouseLocation = e.Location;
            mIsMovingShapes = true;

        }

        private void OnIdentify_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInIdentify = true;
            }
        }

        private void OnSelect_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInSelect = true;
            }
        }

        private void OnPan_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInPan = true;
            }
        }

        private void OnZoomIn_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInZoomIn = true;
            }
        }

        private void OnZoomOut_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInZoomOut = true;
            }
        }

        private void geoMap_MouseMove(object sender, MouseEventArgs e)
        {
            // ��ʾ��Ļ����
            ShowCoordinates(e.Location);
            if (mMapOpStyle == 1)
            {
                OnZoomIn_MouseMove(e);
            }
            else if (mMapOpStyle == 2)
            {
                OnZoomOut_MouseMove(e);
            }
            else if (mMapOpStyle == 3)
            {
                OnPan_MouseMove(e);
            }
            else if (mMapOpStyle == 4)
            {
                OnSelect_MouseMove(e);
            }
            else if (mMapOpStyle == 5)
            {
                OnIdentify_MouseMove(e);
            }
            else if (mMapOpStyle == 6)
            {
                OnMoveShape_MouseMove(e);
            }
            else if (mMapOpStyle == 7)
            {
                OnSketch_MouseMove(e);
            }
            else if (mMapOpStyle == 8) // �༭�����
            {
                OnEditShape_MouseMove(e);
            }
        }

        // �ƶ�һ����, ���ߵĵ㶼��Ҫ�ƶ�һ��
        private void OnEditShape_MouseMove(MouseEventArgs e)
        {
            if (mIsEditingShapes == false)
            {
                return;
            }
            // ��ô�ʱ���λ��
            GeoPoint sCurPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);

       

            geoMap.Refresh();
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawLine(sCurPoint, mEditingLeftPoint, mElasticSymbol);
            sDrawingTool.DrawLine(sCurPoint, mEditingRightPoint, mElasticSymbol);
        }

        private void OnSketch_MouseMove(MouseEventArgs e)
        {
            GeoPoint sCurPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            GeoPoints sLastPart = mSketchingShape.Last();
            int sPointCount = sLastPart.Count;
            if (sPointCount == 0)
                return;
            else if (sPointCount == 1)
            {
                // ֻ��һ������, ��ôֻ����һ����Ƥ��
                geoMap.Refresh();
                GeoPoint sFirstPoint = sLastPart.GetItem(0);
                GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
                sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);

            }
            else

            {
                // ���ж������, ����������Ƥ��
                geoMap.Refresh();
                GeoPoint sFirstPoint = sLastPart.GetItem(0);
                GeoPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
                sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);
                sDrawingTool.DrawLine(sLastPoint, sCurPoint, mElasticSymbol);

            }
        }

        private void OnMoveShape_MouseMove(MouseEventArgs e)
        {
            if (mIsMovingShapes == false)
            {
                return;
            }
            // �޸��ƶ�ͼ�ε�����
            double sDeltaX = geoMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = geoMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            ModifyMovingGeometries(sDeltaX, sDeltaY);

            geoMap.Refresh();
            // �����ƶ�ͼ��
            DrawMovingShapes();

            // ������������ƶ���ʼλ��
            mStartMouseLocation = e.Location;
        }

        private void OnIdentify_MouseMove(MouseEventArgs e)
        {
            if (mIsInIdentify == false)
                return;
            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mSelectingBoxSymbol);
        }

        private void OnSelect_MouseMove(MouseEventArgs e)
        {
            if (mIsInSelect == false)
            {
                return;
            }

            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mSelectingBoxSymbol);
        }

        private void OnPan_MouseMove(MouseEventArgs e)
        {
            if (mIsInPan == false)
            {
                return;
            }
            geoMap.Refresh();
            GeoPoint point1 = geoMap.ToMapPoint(e.Location.X, e.Location.Y);
            GeoPoint point2 = geoMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);

            GeoUserDrawingTool drawingTool = geoMap.GetDrawingTool();
            drawingTool.DrawLine(point1, point2, mElasticSymbol);
        }

        private void OnZoomIn_MouseMove(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
            {
                return;
            }
            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mZoomBoxSymbol);

        }

        private void OnZoomOut_MouseMove(MouseEventArgs e)
        {
            if (mIsInZoomOut == false)
            {
                return;
            }
            geoMap.Refresh();
            GeoRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mZoomBoxSymbol);
        }

        private void geoMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)
            {
                OnZoomIn_MouseUp(e);
            }
            else if (mMapOpStyle == 2)
            {
                OnZoomOut_MouseUp(e);
            }
            else if (mMapOpStyle == 3)
            {
                OnPan_MouseUp(e);
            }
            else if (mMapOpStyle == 4)
            {
                OnSelect_MouseUp(e);
            }
            else if (mMapOpStyle == 5)
            {
                OnIdentify_MouseUp(e);
            }
            else if (mMapOpStyle == 6)
            {
                OnMoveShape_MouseUp(e);
            }
            else if (mMapOpStyle == 7)
            {

            }
            else if (mMapOpStyle == 8)
            {
                OnEditShape_MouseUp(e);
            }
        }

        private void OnEditShape_MouseUp(MouseEventArgs e)
        {
            if (mIsEditingShapes == false)
            {
                return;
            }
            mIsEditingShapes = false;
            // ����Ŀǰ���ָ��ĵ�
            GeoPoint sCurPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);

            // �����ڵĵ��滻�༭�ĵ�
            mEditingPoint.X = sCurPoint.X;
            mEditingPoint.Y = sCurPoint.Y;


            (mEditingGeometry as GeoMultiPolygon).UpdateExtent();

            // �ػ��ͼ
            geoMap.RedrawMap();
            
        }

        private void OnMoveShape_MouseUp(MouseEventArgs e)
        {
            if (mIsMovingShapes == false)
                return;
            mIsMovingShapes = false;
            GeoMapLayer selectLayer = geoMap.Layers.getSelectableLayer();
            // ����Ӧ���޸����ݲ���, ���ٱ�д
            for (int i = 0; i < mMovingGeometries.Count; i++)
            {
                GeoGeometry geometry = mMovingGeometries[i];
                GeoFeature feature = geoMap.Layers.getSelectableLayer().SelectedFeatures.GetItem(i);
                feature.Replace(geometry);
            }
            // ���ǽ������ƶ���ͼ����clone���滻


            // ���»��Ƶ�ͼ
            geoMap.RedrawMap();

            mMovingGeometries.Clear();
        }

        private void OnIdentify_MouseUp(MouseEventArgs e)
        {
            if (mIsInIdentify == false)
                return;
            mIsInIdentify = false;
            geoMap.Refresh();
            GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);
            if (geoMap.Layers.Count == 0)
            {
                return;
            }
            else
            {
                GeoMapLayer sLayer = geoMap.Layers.GetItem(0);

                GeoFields sFields = sLayer.AttributeFields;
                int sFieldCount = sFields.Count;
                string[] sFieldString = new string[sFieldCount];
                for (int i = 0; i < sFieldCount; i++)
                {
                    sFieldString[i] = sFields.GetItem(i).Name;
                }

                GeoFeatures sFeatures = sLayer.SearchByBox(sBox, tolerance);
                // ��������
                int sSelFeatureCount = sFeatures.Count;
                if (sSelFeatureCount > 0)
                {
                    GeoGeometry[] sGeometryies = new GeoGeometry[sSelFeatureCount];
                    GeoAttributes[] sGeoAttributes = new GeoAttributes[sSelFeatureCount];
                    for (int i = 0; i < sSelFeatureCount; i++)
                    {
                        sGeometryies[i] = sFeatures.GetItem(i).Geometry;
                        sGeoAttributes[i] = sFeatures.GetItem(i).Attributes;
                    }

                    string info = "";
                    for (int i = 0; i < sSelFeatureCount; i++)
                    {
                        int sAttributeCount = sGeoAttributes[i].Count;
                        for (int j = 0; j < sAttributeCount; j++)
                        {
                            info += sFieldString[j] + "��" + sGeoAttributes[i].GetItem(j).ToString() + '\n';
                        }
                        info += "\n";
                    }
                    MessageBox.Show(info, "������Ϣ", MessageBoxButtons.OK);

                    // geoMap.FlashShapes(sGeometryies, 3, 800);
                }
            }
        }

        private void OnSelect_MouseUp(MouseEventArgs e)
        {
            if (mIsInSelect == false)
                return;
            mIsInSelect = false;
            GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double tolerance = geoMap.ToMapDistance(mSelectingTolerance);
            geoMap.SelectByBox(sBox, tolerance, 0);
            geoMap.RedrawTrackingShapes();
        }

        private void OnPan_MouseUp(MouseEventArgs e)
        {
            if (mIsInPan == false)
                return;
            mIsInPan = false;
            double sDeltaX = geoMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = geoMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            geoMap.PanDelta(sDeltaX, sDeltaY);
        }

        private void OnZoomIn_MouseUp(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
                return;
            mIsInZoomIn = false;
            if (mStartMouseLocation.X == e.Location.X && mStartMouseLocation.Y == e.Location.Y)
            { // �û�����
                GeoPoint sPoint = geoMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);
                geoMap.ZoomByCenter(sPoint, mZoomRatioFixed);
            }
            else
            { // ���ηŴ�
                GeoRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
                geoMap.ZoomToExtent(sBox);
            }
        }

        private void OnZoomOut_MouseUp(MouseEventArgs e)
        {
            if (mIsInZoomOut == false)
                return;
            mIsInZoomOut = false;

            GeoPoint sPoint = geoMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);
            geoMap.ZoomByCenter(sPoint, 1 / mZoomRatioFixed);
        }

        private void geoMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 7)
            {
                OnSketch_MouseClick(e);
            }
        }

        private void OnSketch_MouseClick(MouseEventArgs e)
        {
            // ����Ļ����ת��Ϊ��ͼ���겢�������ͼ��
            GeoPoint sPoint = geoMap.ToMapPoint(e.Location.X, e.Location.Y);

            // ��������ε����һ���һ����

            mSketchingShape.Last().Add(sPoint);

            geoMap.RedrawTrackingShapes();
            // ʵ�ֳ־�ͼ�εĻ���
        }

        private void geoMap_MouseWheel(object sender, MouseEventArgs e)
        {
            double sX = geoMap.ClientRectangle.Width / 2;
            double sY = geoMap.ClientRectangle.Height / 2;
            GeoPoint sPoint = geoMap.ToMapPoint(sX, sY);
            if (e.Delta > 0)
            {
                geoMap.ZoomByCenter(sPoint, mZoomRatioMouseWheel);
            }
            else
            {
                geoMap.ZoomByCenter(sPoint, 1 / mZoomRatioMouseWheel);
            }
        }

        private void geoMap_MapScaleChanged(object sender)
        {

        }

        // �־û���ͼ��(���ڻ���������ε�ͼ��)
        private void geoMap_AfterTrackingLayerDraw(object sender, GeoUserDrawingTool drawTool)
        {
            DrawSketchingShapes(drawTool);
            DrawEditingShapes(drawTool);
        }
        #endregion

        #region ˽�к���
        //��ʼ������
        private void InitializeSymbols()
        {
            mSelectingBoxSymbol = new GeoSimpleFillSymbol();
            mSelectingBoxSymbol.Color = Color.Transparent;
            mSelectingBoxSymbol.Outline.Color = mSelectBoxColor;
            mSelectingBoxSymbol.Outline.Size = mSelectBoxWidth;
            mZoomBoxSymbol = new GeoSimpleFillSymbol();
            mZoomBoxSymbol.Color = Color.Transparent;
            mZoomBoxSymbol.Outline.Color = mZoomBoxColor;
            mZoomBoxSymbol.Outline.Size = mZoomBoxWidth;
            mMovingPolygonSymbol = new GeoSimpleFillSymbol();
            mMovingPolygonSymbol.Color = Color.Transparent;
            mMovingPolygonSymbol.Outline.Color = Color.Black;
            mEditingPolygonSymbol = new GeoSimpleFillSymbol();
            mEditingPolygonSymbol.Color = Color.Transparent;
            mEditingPolygonSymbol.Outline.Color = Color.DarkGreen;
            mEditingPolygonSymbol.Outline.Size = 0.53;
            mEditingVertexSymbol = new GeoSimpleMarkerSymbol();
            mEditingVertexSymbol.Color = Color.DarkGreen;
            mEditingVertexSymbol.Style = GeoSimpleMarkerSymbolStyleConstant.SolidSquare;
            mEditingVertexSymbol.Size = 2;
            mEditingVertexHoverSymbol = new GeoSimpleMarkerSymbol();
            mEditingVertexHoverSymbol.Color = Color.Red;
            mEditingVertexHoverSymbol.Style = GeoSimpleMarkerSymbolStyleConstant.SolidSquare;
            mEditingVertexHoverSymbol.Size = 2;
            mElasticSymbol = new GeoSimpleLineSymbol();
            mElasticSymbol.Color = Color.DarkGreen;
            mElasticSymbol.Size = 0.52;
            mElasticSymbol.Style = GeoSimpleLineSymbolStyleConstant.Dash;
        }
        // ��ʼ�����ͼ��
        private void InitializeSketchingShape()
        {
            mSketchingShape = new List<GeoPoints>();
            GeoPoints sPoints = new GeoPoints();
            mSketchingShape.Add(sPoints);
        }

        // ������Ļ������ʾ��ͼ����
        private void ShowCoordinates(PointF point)
        {
            GeoPoint sPoint = geoMap.ToMapPoint(point.X, point.Y);
            double sX = Math.Round(sPoint.X, 2);
            double sY = Math.Round(sPoint.Y, 2);
            tssCoordinate.Text = "X:" + sX.ToString() + ", Y:" + sY.ToString();
        }

        // ��ʾ������
        private void ShowMapScale()
        {
            tssMapScale.Text = "1 :" + geoMap.MapScale.ToString("0.00");
        }

        //������Ļ�ϵ�������һ����ͼ�����µľ���
        private GeoRectangle GetMapRectByTwoPoints(PointF point1, PointF point2)
        {
            GeoPoint sPoint1 = geoMap.ToMapPoint(point1.X, point1.Y);
            GeoPoint sPoint2 = geoMap.ToMapPoint(point2.X, point2.Y);
            double sMinX = Math.Min(sPoint1.X, sPoint2.X);
            double sMaxX = Math.Max(sPoint1.X, sPoint2.X);
            double sMinY = Math.Min(sPoint1.Y, sPoint2.Y);
            double sMaxY = Math.Max(sPoint1.Y, sPoint2.Y);
            GeoRectangle sRect = new GeoRectangle(sMinX, sMaxX, sMinY, sMaxY);
            return sRect;
        }

        //��ȡһ�������ͼ��
        private GeoMapLayer GetPolygonLayer()
        {
            Int32 sLayerCount = geoMap.Layers.Count;
            GeoMapLayer sLayer = null;
            for (Int32 i = 0; i <= sLayerCount - 1; i++)
            {
                if (geoMap.Layers.GetItem(i).ShapeType == GeoGeometryTypeConstant.MultiPolygon)
                {
                    sLayer = geoMap.Layers.GetItem(i);
                    break;
                }
            }
            return sLayer;
        }

        //�޸��ƶ�ͼ�ε�����
        private void ModifyMovingGeometries(double deltaX, double deltaY)
        {
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(GeoMultiPolygon))
                {
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)mMovingGeometries[i];
                    Int32 sPartCount = sMultiPolygon.Parts.Count;
                    for (Int32 j = 0; j <= sPartCount - 1; j++)
                    {
                        GeoPoints sPoints = sMultiPolygon.Parts.GetItem(j);
                        Int32 sPointCount = sPoints.Count;
                        for (Int32 k = 0; k <= sPointCount - 1; k++)
                        {
                            GeoPoint sPoint = sPoints.GetItem(k);
                            sPoint.X = sPoint.X + deltaX;
                            sPoint.Y = sPoint.Y + deltaY;
                        }
                    }
                    sMultiPolygon.UpdateExtent();
                }
            }
        }
        //�����ƶ�ͼ��
        private void DrawMovingShapes()
        {
            GeoUserDrawingTool sDrawingTool = geoMap.GetDrawingTool();
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(GeoMultiPolygon))
                {
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)mMovingGeometries[i];
                    sDrawingTool.DrawMultiPolygon(sMultiPolygon, mMovingPolygonSymbol);
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG

            logging = e.KeyValue.ToString() + " key down";
#endif
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
#if DEBUG
            logging = e.KeyValue.ToString() + " key up";
#endif
        }

        //������������ͼ��
        private void DrawSketchingShapes(GeoUserDrawingTool drawingTool)
        {
            if (mSketchingShape == null)
                return;
            Int32 sPartCount = mSketchingShape.Count;
            //�����Ѿ������ɵĲ���
            for (Int32 i = 0; i <= sPartCount - 2; i++)
            {
                drawingTool.DrawPolygon(mSketchingShape[i], mEditingPolygonSymbol);
            }
            //�������Ĳ��֣�ֻ��һ��Part��
            GeoPoints sLastPart = mSketchingShape.Last();
            if (sLastPart.Count >= 2)
                drawingTool.DrawPolyline(sLastPart, mEditingPolygonSymbol.Outline);
            //�������ж����ֱ�
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                GeoPoints sPoints = mSketchingShape[i];
                drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
            }
        }

        //�������ڱ༭��ͼ��
        private void DrawEditingShapes(GeoUserDrawingTool drawingTool)
        {
            if (mEditingGeometry == null)
                return;
            if (mEditingGeometry.GetType() == typeof(GeoMultiPolygon))
            {
                GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)mEditingGeometry;
                //���Ʊ߽�
                drawingTool.DrawMultiPolygon(sMultiPolygon, mEditingPolygonSymbol);
                //���ƶ����ֱ�
                Int32 sPartCount = sMultiPolygon.Parts.Count;
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    GeoPoints sPoints = sMultiPolygon.Parts.GetItem(i);
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
        }




        #endregion
        
#if DEBUG
        private string logging
        {
            get
            {
                return _logging.Text;
            }
            set
            {
                _logging.AppendText("\r\n" + System.DateTime.Now.ToString("HH:mm:ss") + "  " + value);
                _logging.ScrollToCaret();
            }
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            OpenFileDialog sOpenFileDialog = new OpenFileDialog();
            sOpenFileDialog.Filter = "SQLite(*.db)|*.db|All files(*.*)|*.*";
            sOpenFileDialog.FilterIndex = 1;
            GeoLayers sLayers = new GeoLayers();

            if (sOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = sOpenFileDialog.FileName.ToString();
                try
                {
                    string conn_str = "Data Source = ";
                    conn_str += path;
                    SQLiteConnection conn = new SQLiteConnection(conn_str);
                    conn.Open();
                    GeoDatabaseIOTools.LoadMeta(sLayers, conn);
                    //��ȡ������Ϣ
                    GeoDatabaseIOTools.LoadLayers(sLayers, conn);
                    
                    //TODO:ˢ�»���
                    if (geoMap.Layers.Count == 1)
                    {
                        geoMap.FullExtent();
                    }
                    else
                    {
                        geoMap.RedrawMap();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GeoDatabaseIOTools.SaveGeoProject(geoMap.Layers, "C:\\Users\\zwy99\\Desktop\\test");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }
    

        private TextBox _logging = null;
        public void SetDebugForm(DebugForm form)
        {
            _logging = form.logging;

        }
#endif
    }
}
