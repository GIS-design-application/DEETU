using System;


namespace DEETU.Core
{
    [Serializable]
    public class GeoLabelRenderer
    {

        #region 字段

        private bool _LabelFeatures = false;       //是否标注
        private GeoTextSymbol _TextSymbol = new GeoTextSymbol();      //文本符号
        private string _Field = "";                 //注记字段

        #endregion

        #region 属性

        /// <summary>
        /// 指示是否为图层配置注记
        /// </summary>
        public bool LabelFeatures
        {
            get { return _LabelFeatures; }
            set { _LabelFeatures = value; }
        }

        /// <summary>
        /// 获取或设置注记符号
        /// </summary>
        public GeoTextSymbol TextSymbol
        {
            get { return _TextSymbol; }
            set { _TextSymbol = value; }
        }

        /// <summary>
        /// 获取或设置绑定字段
        /// </summary>
        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        #endregion
    }
}