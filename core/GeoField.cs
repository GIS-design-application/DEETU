using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEETU.core
{
    class GeoField
    {
        // Constructors

        // Properties
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

        //Public Member Functions
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

    }
}
