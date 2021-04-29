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
using System.Linq;
using System.Text;
using System.Data;
using DEETU.geometry;

namespace DEETU.core
{
    class GeoFeature
    {
        // Constructor
        public GeoFeature()
        {
            this.id_ = -1;
            this.fields_ = new List<GeoField>();
            this.attributes_ = new DataTable();
            this.geometry_ = null;
        }
        public GeoFeature(Int64 id)
        {
            this.id_ = id;
            this.fields_ = new List<GeoField>();
            this.attributes_ = new DataTable();
            this.geometry_ = null;
        }
        public GeoFeature(List<GeoField> fields, Int64 id)
        {
            this.id_ = id;
            this.fields_ = new List<GeoField>(fields);//deepcopy，避免引用类型引起的bug
            this.attributes_ = new DataTable();
            this.geometry_ = null;
        }
        public GeoFeature(GeoFeature other)
        {
            this.id_ = other.Id;
            this.fields_ = new List<GeoField>(other.Fields);
            this.attributes_ = other.Attributes;
            this.geometry_ = other.Geometry;
        }

        // Properties
        // Privates
        private DataTable attributes_;
        //! TODO: 这里有一个bug：
        // 每一个feature 分开写的话可能就没有办法在feature内进行查找
        // 或许可以考虑另外写一个Query类
        private List<GeoField> fields_;
        private Int64 id_;
        private GeoGeometry geometry_;

        // Publics
        public DataTable Attributes
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

        // Public Member Functions            
        // Sets
        public void SetAttributes(DataTable attributes)
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
        // * 这里好像只能装箱了，尚不知道调用时拆箱的方法。
        {

        }
        public object Attribute(int field_idx)
        // * 这里好像只能装箱了，尚不知道调用时拆箱的方法。
        {

        }
        public void DeleteAttribute(string name)
        {

        }
        public void DeleteAttribute(int field_idx)
        {

        }
        public bool HasGeometry()
        {
            return this.geometry_ == null;
        }
        public void ClearGeometry()
        {
            this.geometry_ = null;
        }
    }
}
