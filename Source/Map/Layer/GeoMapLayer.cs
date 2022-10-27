using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DEETU.Geometry;
using DEETU.Core;
using DEETU.Tool;

namespace DEETU.Map
{
    public class GeoMapLayer
    {
        #region 字段
        
        // 图层属性部分
        private GeoGeometryTypeConstant _ShapeType = GeoGeometryTypeConstant.Point; // 要素几何类型
        private string _Name = "Untitled"; // 图层名称
        private bool _Visible = true; // 图层是否可见
        private bool _Selectable = true; // 是否可以执行选择操作 //TODO:这里需要注意, 在增加图层管理之后, 这个变量决定了图层是否可以被选择
        private string _Description = ""; // 描述
        private bool _IsDirty = false; // 是否被修改过
        private GeoRenderer _Renderer; // 符号渲染
        private GeoLabelRenderer _LabelRenderer; // 注记渲染对象
        private GeoFields _AttributeFields = new GeoFields(); // 字段集合

        // 投影部分
        private GeoCoordinateReferenceSystem _Crs;

        // 要素部分
        private GeoFeatures _Features = new GeoFeatures(); // 要素集合
        private GeoFeatures _SelectedFeatures = new GeoFeatures(); // 选择的要素集合
        private GeoRectangle _Extent = new GeoRectangle(0,0,0,0); // 图层范围
        #endregion

        #region 构造函数

        public GeoMapLayer()
        {
            Initialize();
        }
        public GeoMapLayer(string name, GeoGeometryTypeConstant shapeType)
        {
            _Name = name;
            _ShapeType = shapeType;
            Initialize();
        }

        public GeoMapLayer(string name, GeoGeometryTypeConstant shapeType, GeoFields attributeFields)
        {
            _Name = name;
            _ShapeType = shapeType;
            _AttributeFields = attributeFields;
            Initialize();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取图层的要素几何类型
        /// </summary>
        public GeoGeometryTypeConstant ShapeType
        {
            get { return _ShapeType; }
        }

        /// <summary>
        /// 获取或设置图层名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// 指示图层是否可见
        /// </summary>
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        /// <summary>
        /// 指示图层是否可以进行选择操作
        /// </summary>
        public bool Selectable
        {
            get { return _Selectable; }
            set { _Selectable = value; }
        }

        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// 指示图层是否被修改过
        /// </summary>
        public bool IsDirty
        {
            get { return _IsDirty; }
            set { _IsDirty = value; }
        }

        /// <summary>
        /// 获取图层范围
        /// </summary>
        public GeoRectangle Extent
        {
            get { return _Extent; }
        }


        /// <summary>
        /// 获取或设置要素集合
        /// </summary>
        public GeoFeatures Features
        {
            get { return _Features; }
            set
            {
                _Features = value;
                CalExtent();
            }
        }

        /// <summary>
        /// 获取或设置选择要素集合
        /// </summary>
        public GeoFeatures SelectedFeatures
        {
            get { return _SelectedFeatures; }
            set { _SelectedFeatures = value; }
        }

        /// <summary>
        /// 获取属性字段集合
        /// </summary>
        public GeoFields AttributeFields
        {
            get { return _AttributeFields; }
        }

        /// <summary>
        /// 获取或设置图层渲染
        /// </summary>
        public GeoRenderer Renderer
        {
            get { return _Renderer; }
            set { _Renderer = value; }
        }

        /// <summary>
        /// 获取或设置图层注记渲染
        /// </summary>
        public GeoLabelRenderer LabelRenderer
        {
            get { return _LabelRenderer; }
            set { _LabelRenderer = value; }
        }
        public GeoCoordinateReferenceSystem Crs
        {
            get { return _Crs; }
            set { _Crs = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 更新范围
        /// </summary>
        public void UpdateExtent()
        {
            CalExtent();
        }

        /// <summary>
        /// 获取选择要素集合的范围
        /// </summary>
        /// <returns></returns>
        public GeoRectangle GetSelectionExtent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 清除选择
        /// </summary>
        public void ClearSelection()
        {
            _SelectedFeatures.Clear();
        }

        /// <summary>
        /// 根据指定矩形盒执行搜索并返回一个要素集合
        /// </summary>
        /// <param name="selectingBox"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public GeoFeatures SearchByBox(GeoRectangle selectingBox, double tolerance)
        {
            // 说明，仅考虑一种选择模式
            GeoFeatures sSelection = null;
            if(selectingBox.Width == 0 && selectingBox.Height == 0)
            {
                // 按点选
                GeoPoint sSelectingPoint = new GeoPoint(selectingBox.MinX, selectingBox.MinY);
                sSelection = SearchFeaturesByPoint(sSelectingPoint, tolerance);
            }
            else
            {
                // 按框选，忽略容限
                sSelection = SearchFeaturesByBox(selectingBox);
            }
            return sSelection;
        }

        /// <summary>
        /// 根据指定方法执行选择
        /// </summary>
        /// <param name="features"></param>
        /// <param name="selsctMethod">选择方法</param>
        public void ExecuteSelect(GeoFeatures features, int selectMethod = 0)
        {
            // 说明，此处仅考虑新建集合
            if (selectMethod == 0)
            {
                _SelectedFeatures.Clear();
                int sFeatureCount = features.Count;
                for (int i = 0; i < sFeatureCount; ++i)
                    _SelectedFeatures.Add(features.GetItem(i));
                
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 获取一个新要素
        /// </summary>
        /// <returns></returns>
        public GeoFeature GetNewFeature()
        {
            return CreateNewFeature();
        }

        public GeoMapLayer Clone()
        {
            throw new NotImplementedException("服务于撤销, 重做, 属性修改等.");
        }
        #endregion

        #region 程序集方法
        /// <summary>
        /// 绘制所有要素
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="extent">绘制范围，地图范围</param>
        /// <param name="mapScale">地图比例尺倒数</param>
        /// <param name="dpm">每米对应多少点数</param>
        /// <param name="mpu">地图坐标单位对应的米数</param>
        internal void DrawFeatures(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu)
        {
            //（1）为所有要素配置符号
            SetFeatureSymbols();
            //（2）判断是否位于绘制范围内，如果是，则绘制
            int sFeatureCount = _Features.Count;
            for(int i = 0; i < sFeatureCount;++i)
            {
                GeoFeature sFeature = _Features.GetItem(i);
                if(IsFeatureInExtent(sFeature, extent) == true)
                {
                    GeoGeometry sGeometry = sFeature.Geometry;
                    GeoSymbol sSymbol = sFeature.Symbol;
                    GeoMapDrawingTools.DrawGeometry(g, extent, mapScale, dpm, mpu, sGeometry, sSymbol);
                }
            }
        }
        /// <summary>
        /// 绘制所有选中的要素
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="extent">绘制范围，地图范围</param>
        /// <param name="mapScale">地图比例尺倒数</param>
        /// <param name="dpm">每米对应多少点数</param>
        /// <param name="mpu">地图坐标单位对应的米数</param>
        /// <param name="symbol">要用户自己指定符号</param>
        internal void DrawSelectedFeatures(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoSymbol symbol)
        {
            for (int i = 0; i < _SelectedFeatures.Count; i++)
            {
                GeoFeature sFeature = _SelectedFeatures.GetItem(i);
                if (IsFeatureInExtent(sFeature, extent) == true)
                    GeoMapDrawingTools.DrawGeometry(g, extent, mapScale, dpm, mpu, sFeature.Geometry, symbol);
            }
        }

        /// <summary>
        /// 绘制注记
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="extent">绘制范围，地图范围</param>
        /// <param name="mapScale">地图比例尺倒数</param>
        /// <param name="dpm">每米对应多少点数</param>
        /// <param name="mpu">地图坐标单位对应的米数</param>
        /// <param name="placedLabelExtents">已经标注的注记的屏幕范围</param>
        internal void DrawLabels(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, List<RectangleF> placedLabelExtents)
        {
            if (_LabelRenderer == null)
                return;
            if (_LabelRenderer.LabelFeatures == false)
                return;
            Int32 sFieldIndex = _AttributeFields.FindField(_LabelRenderer.Field);
            if (sFieldIndex < 0)
                return;
            Int32 sFeatureCount = _Features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                GeoFeature sFeature = _Features.GetItem(i);
                if (IsFeatureInExtent(sFeature, extent) == false)
                {   //要素不位于显示范围内，不显示注记
                    continue;
                }
                if (sFeature.Symbol == null)
                {   //要素没有配置符号，不显示注记
                    continue;
                }
                if (IsFeatureSymbolVisible(sFeature) == false)
                {   //要素符号不可见，自然就不显示注记
                    continue;
                }
                string sLabelText = GetValueString(sFeature.Attributes.GetItem(sFieldIndex));
                if (sLabelText == string.Empty)
                {   //注记文本为空，不显示注记
                    continue;
                }
                //根据要素几何类型采用相应的配置方案
                if (sFeature.ShapeType == GeoGeometryTypeConstant.Point)
                {   //点要素，取点的右上为定位点，但要考虑点符号的大小
                    //（1）复制符号
                    GeoTextSymbol sTextSymbol;  //最终绘制注记所采用的符号
                    sTextSymbol = _LabelRenderer.TextSymbol.Clone();    //复制符号
                    //（2）计算定位点并设置符号
                    PointF sSrcLabelPoint;   //定位点的屏幕坐标
                    GeoPoint sPoint = (GeoPoint)sFeature.Geometry;
                    PointF sSrcPoint = FromMapPoint(extent, mapScale, dpm, mpu, sPoint);    //点要素的屏幕坐标
                    GeoSimpleMarkerSymbol sMarkerSymbol = (GeoSimpleMarkerSymbol)sFeature.Symbol;
                    float sSymbolSize = (float)(sMarkerSymbol.Size / 1000 * dpm);        //符号的屏幕尺寸
                    //右上方并设置符号
                    sSrcLabelPoint = new PointF(sSrcPoint.X + sSymbolSize / 2, sSrcPoint.Y - sSymbolSize / 2);
                    sTextSymbol.Alignment = GeoTextSymbolAlignmentConstant.BottomLeft;
                    //（3）计算注记的屏幕范围矩形
                    RectangleF sLabelExtent = GetLabelExtent(g, dpm, sSrcLabelPoint, sLabelText, sTextSymbol);
                    //（4）冲突检测
                    if (HasConflict(sLabelExtent, placedLabelExtents) == false)
                    {   //没有冲突，则绘制并将当前注记范围矩形加入placedLabelExtents
                        GeoMapDrawingTools.DrawLabel(g, dpm, sLabelExtent.Location, sLabelText, sTextSymbol);
                        placedLabelExtents.Add(sLabelExtent);
                    }
                }
                else if (sFeature.ShapeType == GeoGeometryTypeConstant.MultiPolyline)
                {   //线要素，为每个部分的中点配置一个注记
                    //（1）获取符号，线要素无需复制符号
                    GeoTextSymbol sTextSymbol = _LabelRenderer.TextSymbol;
                    //（2）对每个部分进行配置
                    GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)sFeature.Geometry;
                    Int32 sPartCount = sMultiPolyline.Parts.Count;
                    for (Int32 j = 0; j <= sPartCount - 1; j++)
                    {
                        //获取注记
                        GeoPoint sMapLabelPoint = GeoMapTools.GetMidPointOfPolyline(sMultiPolyline.Parts.GetItem(j));
                        PointF sSrcLabelPoint = FromMapPoint(extent, mapScale, dpm, mpu, sMapLabelPoint);
                        //计算注记的屏幕范围矩形
                        RectangleF sLabelExtent = GetLabelExtent(g, dpm, sSrcLabelPoint, sLabelText, _LabelRenderer.TextSymbol);
                        //冲突检测
                        if (HasConflict(sLabelExtent, placedLabelExtents) == false)
                        {   //没有冲突，则绘制并将当前注记范围矩形加入placedLabelExtents
                            GeoMapDrawingTools.DrawLabel(g, dpm, sLabelExtent.Location, sLabelText, sTextSymbol);
                            placedLabelExtents.Add(sLabelExtent);
                        }
                    }
                }
                else if (sFeature.ShapeType == GeoGeometryTypeConstant.MultiPolygon)
                {   //面要素，为面积最大的外环及其内环所构成的多边形配置一个注记
                    //（1）获取符号，面要素无需复制符号
                    GeoTextSymbol sTextSymbol = _LabelRenderer.TextSymbol;
                    //（2）获取注记点
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)sFeature.Geometry;
                    GeoPoint sMapLabelPoint = GeoMapTools.GetLabelPointOfMultiPolygon(sMultiPolygon);
                    PointF sSrcLabelPoint = FromMapPoint(extent, mapScale, dpm, mpu, sMapLabelPoint);
                    //（3）计算注记的屏幕范围矩形
                    RectangleF sLabelExtent = GetLabelExtent(g, dpm, sSrcLabelPoint, sLabelText, _LabelRenderer.TextSymbol);
                    //（4）冲突检测
                    if (HasConflict(sLabelExtent, placedLabelExtents) == false)
                    {   //没有冲突，则绘制并将当前注记范围矩形加入placedLabelExtents
                        GeoMapDrawingTools.DrawLabel(g, dpm, sLabelExtent.Location, sLabelText, sTextSymbol);
                        placedLabelExtents.Add(sLabelExtent);
                    }
                }
                else
                { throw new Exception("Invalid shape type!"); }
            }
        }
        
        #endregion

        #region 私有函数

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            // （1）加入_AttributeFeilds对象的事件
            _AttributeFields.FieldRemoved += _AttributeFields_FieldRemoved;
            _AttributeFields.FieldAppended += _AttributeFields_FieldAppended;
            // （2）初始化图层的渲染
            InitializeRenderer();
            //  (3) 初始化图层的坐标系
            _Crs = new GeoCoordinateReferenceSystem();
        }

        // 初始化渲染
        private void InitializeRenderer()
        {
            GeoSimpleRenderer sRenderer = new GeoSimpleRenderer();
            if(_ShapeType == GeoGeometryTypeConstant.Point)
            {
                sRenderer.Symbol = new GeoSimpleMarkerSymbol();
                _Renderer = sRenderer;
            }
            else if(_ShapeType == GeoGeometryTypeConstant.MultiPolyline)
            {
                sRenderer.Symbol = new GeoSimpleLineSymbol();
                _Renderer = sRenderer;
            }
            else if(_ShapeType == GeoGeometryTypeConstant.MultiPolygon)
            {
                sRenderer.Symbol = new GeoSimpleFillSymbol();
                _Renderer = sRenderer;
            }
            else
            {
                throw new Exception("Invalid shape type!");
            }
        }

        // 有字段被删除
        private void _AttributeFields_FieldRemoved(object sender, int fieldIndex, GeoField fieldRemoved)
        {
            int sFeatureCount = _Features.Count;
            for(int i = 0; i < sFeatureCount;++i)
            {
                _Features.GetItem(i).Attributes.RemoveAt(fieldIndex);
            }
        }

        //有字段被加入
        private void _AttributeFields_FieldAppended(object sender, GeoField fieldAppended)
        {
            //给所有要素增加一个属性值
            Int32 sFeatureCount = _Features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                GeoFeature sFeature = _Features.GetItem(i);
                if (fieldAppended.ValueType == GeoValueTypeConstant.dInt16)
                {
                    Int16 sValue = 0;
                    sFeature.Attributes.Append(sValue);
                }
                else if (fieldAppended.ValueType == GeoValueTypeConstant.dInt32)
                {
                    Int32 sValue = 0;
                    sFeature.Attributes.Append(sValue);
                }
                else if (fieldAppended.ValueType == GeoValueTypeConstant.dInt64)
                {
                    Int64 sValue = 0;
                    sFeature.Attributes.Append(sValue);
                }
                else if (fieldAppended.ValueType == GeoValueTypeConstant.dSingle)
                {
                    float sValue = 0;
                    sFeature.Attributes.Append(sValue);
                }
                else if (fieldAppended.ValueType == GeoValueTypeConstant.dDouble)
                {
                    double sValue = 0;
                    sFeature.Attributes.Append(sValue);
                }
                else if (fieldAppended.ValueType == GeoValueTypeConstant.dText)
                {
                    string sValue = string.Empty;
                    sFeature.Attributes.Append(sValue);
                }
                else
                {
                    throw new Exception("Invalid field value type!");
                }
            }
        }
        // 计算范围
        private void CalExtent()
        {
            double sMinX = Double.MaxValue;
            double sMaxX = Double.MinValue;
            double sMinY = Double.MaxValue;
            double sMaxY = Double.MinValue;
            Int32 sFeatureCount = _Features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                GeoRectangle sExtent = _Features.GetItem(i).GetEnvelope();
                if (sExtent.MinX < sMinX)
                    sMinX = sExtent.MinX;
                if (sExtent.MaxX > sMaxX)
                    sMaxX = sExtent.MaxX;
                if (sExtent.MinY < sMinY)
                    sMinY = sExtent.MinY;
                if (sExtent.MaxY > sMaxY)
                    sMaxY = sExtent.MaxY;
            }
            _Extent = new GeoRectangle(sMinX, sMaxX, sMinY, sMaxY);
        }

        //根据点搜索要素
        private GeoFeatures SearchFeaturesByPoint(GeoPoint point, double tolerance)
        {
            GeoFeatures sSelectedFeatures = new GeoFeatures();
            Int32 sFeatureCount = _Features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                if (_ShapeType == GeoGeometryTypeConstant.Point)
                {
                    GeoPoint sPoint = (GeoPoint)_Features.GetItem(i).Geometry;
                    if (GeoMapTools.IsPointOnPoint(point, sPoint, tolerance) == true)
                    {
                        sSelectedFeatures.Add(_Features.GetItem(i));
                    }
                }
                else if (_ShapeType == GeoGeometryTypeConstant.MultiPolyline)
                {
                    GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)_Features.GetItem(i).Geometry;
                    if (GeoMapTools.IsPointOnMultiPolyline(point, sMultiPolyline, tolerance) == true)
                    {
                        sSelectedFeatures.Add(_Features.GetItem(i));
                    }
                }
                else if (_ShapeType == GeoGeometryTypeConstant.MultiPolygon)
                {
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)_Features.GetItem(i).Geometry;
                    if (GeoMapTools.IsPointWithinMultiPolygon(point, sMultiPolygon) == true)
                    {
                        sSelectedFeatures.Add(_Features.GetItem(i));
                    }
                }
            }
            return sSelectedFeatures;
        }

        //根据矩形盒搜索要素
        private GeoFeatures SearchFeaturesByBox(GeoRectangle selectingBox)
        {
            GeoFeatures sSelectedFeatures = new GeoFeatures();
            Int32 sFeatureCount = _Features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                if (_ShapeType == GeoGeometryTypeConstant.Point)
                {
                    GeoPoint sPoint = (GeoPoint)_Features.GetItem(i).Geometry;
                    if (GeoMapTools.IsPointWithinBox(sPoint, selectingBox) == true)
                    {
                        sSelectedFeatures.Add(_Features.GetItem(i));
                    }
                }
                else if (_ShapeType == GeoGeometryTypeConstant.MultiPolyline)
                {
                    GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)_Features.GetItem(i).Geometry;
                    if (GeoMapTools.IsMultiPolylinePartiallyWithinBox(sMultiPolyline, selectingBox) == true)
                    {
                        sSelectedFeatures.Add(_Features.GetItem(i));
                    }
                }
                else if (_ShapeType == GeoGeometryTypeConstant.MultiPolygon)
                {
                    GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)_Features.GetItem(i).Geometry;
                    if (GeoMapTools.IsMultiPolygonPartiallyWithinBox(sMultiPolygon, selectingBox) == true)
                    {
                        sSelectedFeatures.Add(_Features.GetItem(i));
                    }
                }
            }
            return sSelectedFeatures;
        }

        //新建一个要素框架
        private GeoFeature CreateNewFeature()
        {
            GeoAttributes sAttributes = new GeoAttributes();
            Int32 sFieldCount = _AttributeFields.Count;
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            {
                GeoField sField = _AttributeFields.GetItem(i);
                if (sField.ValueType == GeoValueTypeConstant.dInt16)
                {
                    Int16 sValue = 0;
                    sAttributes.Append(sValue);
                }
                else if (sField.ValueType == GeoValueTypeConstant.dInt32)
                {
                    Int32 sValue = 0;
                    sAttributes.Append(sValue);
                }
                else if (sField.ValueType == GeoValueTypeConstant.dInt64)
                {
                    Int64 sValue = 0;
                    sAttributes.Append(sValue);
                }
                else if (sField.ValueType == GeoValueTypeConstant.dSingle)
                {
                    float sValue = 0;
                    sAttributes.Append(sValue);
                }
                else if (sField.ValueType == GeoValueTypeConstant.dDouble)
                {
                    double sValue = 0;
                    sAttributes.Append(sValue);
                }
                else if (sField.ValueType == GeoValueTypeConstant.dText)
                {
                    String sValue = "";
                    sAttributes.Append(sValue);
                }
                else
                {
                    throw new Exception("Invalid value type!");
                }
            }
            GeoFeature sFeature = new GeoFeature(_ShapeType, null, sAttributes);
            return sFeature;
        }

        //为所有要素配置符号
        private void SetFeatureSymbols()
        {
            Int32 sFeatureCount = _Features.Count;
            if (_Renderer.RendererType == GeoRendererTypeConstant.Simple)
            {
                GeoSimpleRenderer sRenderer = (GeoSimpleRenderer)_Renderer;
                for (Int32 i = 0; i <= sFeatureCount - 1; i++)
                {
                    _Features.GetItem(i).Symbol = sRenderer.Symbol;
                }
            }
            else if (_Renderer.RendererType == GeoRendererTypeConstant.UniqueValue)
            {
                GeoUniqueValueRenderer sRenderer = (GeoUniqueValueRenderer)_Renderer;
                string sFieldName = sRenderer.Field;
                Int32 sFieldIndex = _AttributeFields.FindField(sFieldName);
                if (sFieldIndex >= 0)
                {
                    for (Int32 i = 0; i <= sFeatureCount - 1; i++)
                    {
                        string sValueString = GetValueString(_Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                        _Features.GetItem(i).Symbol = sRenderer.FindSymbol(sValueString);
                    }
                }
                else
                {
                    for (Int32 i = 0; i <= sFeatureCount - 1; i++)
                        _Features.GetItem(i).Symbol = null;
                }
            }
            else if (_Renderer.RendererType == GeoRendererTypeConstant.ClassBreaks)
            {
                GeoClassBreaksRenderer sRenderer = (GeoClassBreaksRenderer)_Renderer;
                string sFieldName = sRenderer.Field;
                Int32 sFieldIndex = _AttributeFields.FindField(sFieldName);
                GeoValueTypeConstant sValueType = _AttributeFields.GetItem(sFieldIndex).ValueType;
                if (sFieldIndex >= 0)
                {
                    for (Int32 i = 0; i <= sFeatureCount - 1; i++)
                    {
                        double sValue = 0;
                        if (sValueType == GeoValueTypeConstant.dInt16)
                            sValue = (Int16)_Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                        else if (sValueType == GeoValueTypeConstant.dInt32)
                            sValue = (Int32)_Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                        else if (sValueType == GeoValueTypeConstant.dInt64)
                            sValue = (Int64)_Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                        else if (sValueType == GeoValueTypeConstant.dSingle)
                            sValue = (float)_Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                        else if (sValueType == GeoValueTypeConstant.dDouble)
                            sValue = (double)_Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                        else
                            throw new Exception("Invalid value type of field " + sFieldName);

                        _Features.GetItem(i).Symbol = sRenderer.FindSymbol(sValue);
                    }
                }
                else
                {
                    for (Int32 i = 0; i <= sFeatureCount - 1; i++)
                        _Features.GetItem(i).Symbol = null;
                }
            }
            else
            {
                throw new Exception("Invalid renderer type!");
            }
        }

        //获取一个值的字符串形式
        private string GetValueString(object value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.ToString();
        }

        //指定要素是否位于指定范围，这里仅计算要素外包矩形和范围矩形是否相交
        private bool IsFeatureInExtent(GeoFeature feature, GeoRectangle extent)
        {
            GeoRectangle sRect = feature.GetEnvelope();
            if (sRect.MaxX < extent.MinX || sRect.MinX > extent.MaxX)
            { return false; }
            else if (sRect.MaxY < extent.MinY || sRect.MinY > extent.MaxY)
            { return false; }
            else
            { return true; }
        }

        //要素的符号是否可见
        private bool IsFeatureSymbolVisible(GeoFeature feature)
        {
            GeoSymbol sSymbol = feature.Symbol;
            if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
            {
                GeoSimpleMarkerSymbol sMarkerSymbol = (GeoSimpleMarkerSymbol)sSymbol;
                return sMarkerSymbol.Visible;
            }
            else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sLineSymbol = (GeoSimpleLineSymbol)sSymbol;
                return sLineSymbol.Visible;
            }
            else if (sSymbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
            {
                GeoSimpleFillSymbol sFillSymbol = (GeoSimpleFillSymbol)sSymbol;
                return sFillSymbol.Visible;
            }
            else
            { throw new Exception("Invalid symbol type!"); }
        }

        //将地图坐标转换为屏幕坐标
        private PointF FromMapPoint(GeoRectangle extent, double mapScale, double dpm, double mpu, GeoPoint point)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取地图坐标系相对屏幕坐标系的平移量
            PointF sPoint = new PointF();          //屏幕坐标
            sPoint.X = (float)((point.X - sOffsetX) * mpu / mapScale * dpm);
            sPoint.Y = (float)((sOffsetY - point.Y) * mpu / mapScale * dpm);
            return sPoint;
        }

        //获取注记的屏幕范围
        private RectangleF GetLabelExtent(Graphics g, double dpm, PointF labelPoint, string labelText, GeoTextSymbol textSymbol)
        {
            //（1）测量注记大小
            SizeF sLabelSize = g.MeasureString(labelText, textSymbol.Font);     //注记的尺寸
            //（2）计算偏移量
            float sLabelOffsetX, sLabelOffsetY;       //注记偏移量（屏幕坐标），向右、向上位正
            sLabelOffsetX = (float)(textSymbol.OffsetX / 1000 * dpm);
            sLabelOffsetY = (float)(textSymbol.OffsetY / 1000 * dpm);
            //（3）根据布局计算左上点
            PointF sTopLeftPoint = new PointF();        //注记左上点坐标（屏幕坐标）
            if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.TopLeft)
            {
                sTopLeftPoint.X = labelPoint.X + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.TopCenter)
            {
                sTopLeftPoint.X = labelPoint.X - sLabelSize.Width / 2 + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.TopRight)
            {
                sTopLeftPoint.X = labelPoint.X - sLabelSize.Width + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.CenterLeft)
            {
                sTopLeftPoint.X = labelPoint.X + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelSize.Height / 2 - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.CenterCenter)
            {
                sTopLeftPoint.X = labelPoint.X - sLabelSize.Width / 2 + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelSize.Height / 2 - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.CenterRight)
            {
                sTopLeftPoint.X = labelPoint.X - sLabelSize.Width + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelSize.Height / 2 - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.BottomLeft)
            {
                sTopLeftPoint.X = labelPoint.X + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelSize.Height - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.BottomCenter)
            {
                sTopLeftPoint.X = labelPoint.X - sLabelSize.Width / 2 + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelSize.Height - sLabelOffsetY;
            }
            else if (textSymbol.Alignment == GeoTextSymbolAlignmentConstant.BottomRight)
            {
                sTopLeftPoint.X = labelPoint.X - sLabelSize.Width + sLabelOffsetX;
                sTopLeftPoint.Y = labelPoint.Y - sLabelSize.Height - sLabelOffsetY;
            }
            else
            { throw new Exception("Invalid text symbol alignment!"); }
            //（4）返回注记范围矩形
            RectangleF sRect = new RectangleF(sTopLeftPoint, sLabelSize);
            return sRect;
        }

        //指定的矩形是否与指定矩形集合内的所有矩形存在相交
        private bool HasConflict(RectangleF labelExtent, List<RectangleF> placedLabelExtents)
        {
            Int32 sCount = placedLabelExtents.Count;
            float sMinX1 = labelExtent.X, sMaxX1 = labelExtent.X + labelExtent.Width;
            float sMinY1 = labelExtent.Y, sMaxY1 = labelExtent.Y + labelExtent.Height;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                RectangleF sCurExtent = placedLabelExtents[i];
                float sMinX2 = sCurExtent.X, sMaxX2 = sCurExtent.X + sCurExtent.Width;
                float sMinY2 = sCurExtent.Y, sMaxY2 = sCurExtent.Y + sCurExtent.Height;
                if (sMinX1 > sMaxX2 || sMaxX1 < sMinX2)
                { }
                else if (sMinY1 > sMaxY2 || sMaxY1 < sMinY2)
                { }
                else
                { return true; }
            }
            return false;
        }

        #endregion

    }
}
