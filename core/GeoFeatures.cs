/*****************************************
 * @file: GeoFeatures 
 * @author:dhd
 * @date:2021-04-28
 * @description：Feature Collection, 处理要素类中要素的增加删除和修改
 * 
 * 
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DEETU.Geometry;
using System.Data;

namespace DEETU.core
{
    public class GeoFeatures
    {
        #region Constructor
        public GeoFeatures()
        {
            this.fields_ = new List<GeoField>();
            this.features_ = new List<GeoFeature>();
            this.attribute_table_ = new DataTable();
        }

        public GeoFeatures(GeoFeatures other)
        {
            GeoFeatures cloned = other.Clone();
            this.features_ = cloned.features_;
            this.attribute_table_ = cloned.attribute_table_;
            this.fields_ = cloned.fields_;       
        }
        #endregion

        #region Properties
        private List<GeoFeature> features_;
        private List<GeoField> fields_;
        private DataTable attribute_table_;

        // Public
        public List<GeoField> Fields
        {
            get{return fields_;}
        }        
        public bool IsEmpty
        {
            get { return features_.Count == 0; }
        }
        public int FeatureCount
        {
            get { return features_.Count(); }
        }

        // These attributes shouldnot be accessesed
        // public List<GeoFeatures> Features
        // {
        //     get { return features_; }
        // }
        
        // public DataTable AttributeTable
        // {
        //     get { return attribute_table_; }
        // }
        #endregion

        #region Public Member Functions
        // Basic Methods
        public GeoFeatures Clone()
        {
            GeoFeatures cloned = new GeoFeatures();
            foreach (GeoField f in fields_)
            {
                cloned.fields_.Add(f.Clone());
            }
            foreach (GeoFeature f in features_)
            {
                cloned.features_.Add(f.Clone());
            }
            cloned.attribute_table_ = attribute_table_.Copy();
            return cloned;
        }
        
        
        // Change features
        public void AddAttributes(List<GeoField> fields)
        {
            fields.AddRange(fields);
            foreach (GeoField field in fields)
            {
                attribute_table_.Columns.Add(field.Name, field.Type);
                foreach (GeoFeature feature in features_)
                {
                    feature.AddAttribute(field);
                }
            }
            
            SyncFeatureTable(GeoFeaturesOperationEnum.ADD_ATTRIBUTES);
        }
        
        public void AddAttribute(GeoField field)
        {
            fields_.Add(field);
            attribute_table_.Columns.Add(field.Name, field.Type);
            foreach (GeoFeature feature in features_)
            {
                feature.AddAttribute(field);
            }

            SyncFeatureTable(GeoFeaturesOperationEnum.ADD_ATTRIBUTE);
        }

        public void AddFeatures(GeoFeatures features)
        {
            if (features.fields_ != fields_)
                throw new InvalidOperationException();
            AddFeatures(features.features_);
        }

        public void AddFeatures(List<GeoFeature> features_list)
        {
            features_.AddRange(features_list);
            foreach (GeoFeature feature in features_list)
            {
                DataRow new_row = attribute_table_.NewRow();
                for (int i = 0; i < fields_.Count; i++)
                {
                    new_row[i] = feature.Attribute(i);
                }
                attribute_table_.Rows.Add(new_row);
                
            }
            SyncFeatureTable(GeoFeaturesOperationEnum.ADD_FEATURES);

        }

        public void AddFeature(GeoFeature feature)
        {
            features_.Add(feature);
            DataRow new_row = attribute_table_.NewRow();
            for (int i = 0; i < fields_.Count; i++)
            {
                new_row[i] = feature.Attribute(i);
            }
            attribute_table_.Rows.Add(new_row);

            SyncFeatureTable(GeoFeaturesOperationEnum.ADD_FEATURE);
            
        }

        public void DeleteAttribute(int field_idx)
        {
            fields_.RemoveAt(field_idx);
            attribute_table_.Columns.RemoveAt(field_idx);
            foreach (GeoFeature feature in features_)
            {
                feature.DeleteAttribute(field_idx);
            }

            SyncFeatureTable(GeoFeaturesOperationEnum.DEL_ATTRIBUTE);
        }

        public void DeleteFeature(int id)
        {
            int feature_idx = features_.FindIndex(f => f.Id.Equals(id));
            features_.RemoveAt(feature_idx);
            attribute_table_.Rows.RemoveAt(feature_idx);
        }

        public void DeleteAttributes(int[] attribute_ids)
            // ? 感觉删除属性好像只支持一个一个删除就可以了？
        {

        }

        public void DeleteFeatures(int[] ids)
        {
            foreach (int id in ids)
            {
                DeleteFeature(id);
            }
        }

        // Getfeatures
        public GeoFeature GetFeature(int id)
        {
            int feature_idx = features_.FindIndex(f => f.Id.Equals(id));
            return features_[feature_idx];
        }


        #endregion

        #region Private Memeber Functions
        private void SyncFeatureTable(GeoFeaturesOperationEnum operation)
        {
            // 这个函数目前可能还没有什么特别的用处。现在相关的同步操作全部给写进了操作里
            // 可能将来会需要做表和Feature的同步，保留
            if (operation == GeoFeaturesOperationEnum.ADD_FEATURE)
            {

            }
        }

        #endregion
    }
    public enum GeoFeaturesOperationEnum
    {
        ADD_FEATURE, ADD_FEATURES, ADD_ATTRIBUTES, ADD_ATTRIBUTE, DEL_ATTRIBUTE, DEL_FEATURE, DEL_FEATURES
    }

}