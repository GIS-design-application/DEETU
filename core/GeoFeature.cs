/*****************************************
 * @file: GeoFeature 
 * @author:dhd
 * @date:2021-04-28
 * @description：Feature 类, 描述要素的属性，几何，id以及属性的字段
 * 
 * 
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DEETU.geometry;

namespace DEETU.core
{
    public class GeoFeature
    {
        #region Constructor
        public GeoFeature()
        {
            this.id_ = -1;
            this.fields_ = new List<GeoField>();
            this.attributes_ = new ArrayList();
            this.geometry_ = null;
        }
        public GeoFeature(Int64 id)
        {
            this.id_ = id;
            this.fields_ = new List<GeoField>();
            this.attributes_ = new ArrayList();
            this.geometry_ = null;
        }
        public GeoFeature(List<GeoField> fields, Int64 id)
        {
            this.id_ = id;
            this.fields_ = new List<GeoField>(fields);//deepcopy，避免引用类型引起的bug
            this.attributes_ = new ArrayList();
            this.geometry_ = null;
        }
        public GeoFeature(GeoFeature other)
        {
            GeoFeature cloned = other.Clone();
            this.id_ = cloned.Id;
            this.fields_ = cloned.Fields;
            this.attributes_ = cloned.Attributes;
            this.geometry_ = cloned.Geometry;
            
        }
        #endregion

        #region Properties
        // Privates
        private ArrayList attributes_;
        // 这里单独在写出来attributes是为了提高速度和方便feature的加入
        private List<GeoField> fields_;
        private Int64 id_; 
        private GeoGeometry geometry_;

        // Publics
        public ArrayList Attributes
        {
            get{return attributes_;}
        }        
        public List<GeoField> Fields
        {
            get{return fields_;}
        }        
        public Int64 Id
        {
            get{return id_;}
        }        
        public GeoGeometry Geometry
        {
            get{return geometry_;}
        }
        #endregion

        #region Public Member Functions            
        // Sets
        public void SetAttributes(ArrayList attributes)
        {
            this.attributes_ = attributes;
        }        
        public void SetFields(List<GeoField> fields, bool init_attributes=false)
        {
            this.fields_ = new List<GeoField>(fields);
            if (init_attributes)
            {
                this.attributes_.Clear();
                // this.attributes_增加一行空值
            }
        }        
        public void SetId(Int64 id)
        {
            this.id_ = id;
        }        
        public void SetGeometry(GeoGeometry geometry)
        {
            this.geometry_ = geometry;
        }        

        public object Attribute(string name)
        {
            int field_idx = fields_.FindIndex(f => f.Name.Equals(name));
            return Attribute(field_idx);
        }
        public object Attribute(int field_idx)
        // * 这里好像只能装箱了，尚不知道调用时是否需要拆箱。
        {
            GeoField field = fields_[field_idx];
            return attributes_[field_idx];
        }

        public void AddAttribute(GeoField field)
        {
            fields_.Add(field);
            attributes_.Add(null);
        }

        public void DeleteAttribute(string name)
        {
            int field_idx = fields_.FindIndex(f => f.Name.Equals(name));
            DeleteAttribute(field_idx);
        }
        public void DeleteAttribute(int field_idx)
        {
            fields_.RemoveAt(field_idx);
        }
        public bool HasGeometry()
        {
            return this.geometry_ == null;
        }
        public void ClearGeometry()
        {
            this.geometry_ = null;
        }
        public GeoFeature Clone()
        {
            GeoFeature cloned = new GeoFeature();
            cloned.id_ = id_ + 1; // ?id上应该怎么设置
            cloned.geometry_ = geometry_.clone();
            cloned.attributes_ = (ArrayList)attributes_.Clone();
            foreach (GeoField f in fields_)
            {
                cloned.fields_.Add(f.Clone());
            }
            return cloned;
        }
        #endregion
    }
}
