using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.core
{
    public class GeoField
    {
        #region Constructors
        public GeoField(string name="", Type type= null, int length=0, int precision=0)
        {
            this.name_ = name;
            this.type_ = type;
            this.length_ = length;
            this.precision_ = precision;
        }
        public GeoField(GeoField other)
        {
            GeoField cloned = other.Clone();
            this.name_ = other.name_;
            this.type_ = other.type_;
            this.length_ = other.length_;
            this.precision_ = other.precision_;
            this.is_data_time_ = other.is_data_time_;
            this.is_numeric_ = other.is_numeric_;
        }
        #endregion

        #region Properties
        private string name_;
        private int length_, precision_;
        private bool is_data_time_, is_numeric_;
        private System.Type type_;

        // Copy from QGIS, standby
        // GeoFieldConstraints constraints;
        // GeoDefaultValue default_value;

        // Publics
        public string Name
        {
            get{return this.name_;}
        }

        public int Length 
        {
            get{return this.length_;}
        }

        public int Precision
        {
            get { return this.precision_; }
        }
        
        public bool IsDataOrTime
        {
            get { return this.is_data_time_; }
        }

        public bool IsNumeric
        {
            get { return this.is_numeric_; }
        }
        public Type Type
        {
            get { return this.type_; }
        }
        #endregion

        #region Public Member Functions
        public void SetName(string name)
        {
            this.name_ = name;
        }

        public void SetLength(int length)
        {
            this.length_ = length;
        }

        public void SetPrecision(int precision)
        {
            this.precision_ = precision;
        }
        
        public void SetIsDataOrTime(bool is_data_time)
        {
            this.is_data_time_ = is_data_time;
        }
        public void SetIsNumeric(bool is_numeric)
        {
            this.is_numeric_ = is_numeric;
        }
        public void SetType(Type type)
        {
            this.type_ = type;
        }
        public GeoField Clone()
        {        
            GeoField cloned = new GeoField(name_, type_.GetType(), length_, precision_);
            cloned.is_data_time_ = is_data_time_;
            cloned.is_numeric_ = is_numeric_;
            return cloned;
        }
        #endregion

    }
}
