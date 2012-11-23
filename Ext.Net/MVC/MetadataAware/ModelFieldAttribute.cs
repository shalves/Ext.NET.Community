/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.1.0 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/using System;
using System.Web.Mvc;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;

namespace Ext.Net.MVC
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ModelFieldAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.modelfield";
        private  ModelFieldType type = ModelFieldType.Auto;
        private  SortTypeMethod sortType = SortTypeMethod.None;
        private  SortDirection sortDir = SortDirection.Default;
        private  EmptyValue submitEmptyValue = EmptyValue.None;
        private  bool persist = true;

        public ModelFieldAttribute()
        {            
        }

        public virtual void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            metadata.AdditionalValues[ModelFieldAttribute.KEY] = this;
        }
        
        public void CopyTo(ModelField field, Model model)
        {
            field.Apply(this);

            if (this.IDProperty)
            {
                model.IDProperty = field.Name;
            }

            if (this.CustomSortHandler != null)
            {
                field.CustomSortType.Fn = this.CustomSortHandler;
            }

            if (this.SerializeHandler != null)
            {
                field.Serialize.Fn = this.SerializeHandler;
            }

            if (this.ConvertHandler != null)
            {
                field.Convert.Fn = this.ConvertHandler;
            }

            if (this.DefaultValue != null)
            {
                field.DefaultValue = TokenUtils.RawWrap(JSON.Serialize(this.DefaultValue));
            }
        }

        [DefaultValue(false)]
        public virtual bool IDProperty
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public virtual bool Ignore
        {
            get;
            set;
        }

        /// <summary>
        /// The name by which the field is referenced within the Model. This is referenced by, for example, the dataIndex property in column definition objects passed to Ext.grid.header.Container.
        /// Note: In the simplest case, if no properties other than name are required, a field definition may consist of just a String for the field name.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A path expression for use by the Ext.data.reader.Reader implementation that is creating the Model to extract the Field value from the data object. If the path expression is the same as the field name, the mapping may be omitted.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Mapping
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public virtual string ServerMapping
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) The data type for automatic conversion from received data to the stored value if convert has not been specified. This may be specified as a string value. Possible values are
        /// </summary>
        [DefaultValue(ModelFieldType.Auto)]
        public virtual ModelFieldType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering. Predefined functions are provided in Ext.data.SortTypes.       
        /// </summary>
        [DefaultValue(SortTypeMethod.None)]
        public virtual SortTypeMethod SortType
        {
            get
            {
                return this.sortType;
            }
            set
            {
                this.sortType = value;
            }
        }

        /// <summary>
        /// Initial direction to sort ("ASC" or "DESC"). Defaults to "ASC".
        /// </summary>
        [DefaultValue(SortDirection.Default)]
        public virtual SortDirection SortDir
        {
            get
            {
                return this.sortDir;
            }
            set
            {
                this.sortDir = value;
            }
        }

        /// <summary>
        /// Empty value representation during saving (default value as None)
        /// </summary>
        [DefaultValue(EmptyValue.None)]
        public virtual EmptyValue SubmitEmptyValue
        {
            get
            {
                return this.submitEmptyValue;
            }
            set
            {
                this.submitEmptyValue = value;
            }
        }

        /// <summary>
        /// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.
        /// </summary>
        [DefaultValue(null)]
        public virtual string CustomSortHandler
        {
            get;
            set;
        }

        /// <summary>
        /// A function which converts the Model's value for this Field into a form which can be used by whatever Writer is being used to sync data with the server.
        /// </summary>
        [DefaultValue(null)]
        public virtual string SerializeHandler
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) A function which converts the value provided by the Reader into an object that will be stored in the Model.
        /// </summary>
        [DefaultValue(null)]
        public virtual string ConvertHandler
        {
            get;
            set;
        }

        /// <summary>
        /// If you ensure that data comes with correct format then convert can be set to null, it increase a parsing performance 
        /// </summary>
        [DefaultValue(false)]
        public virtual bool NullConvert
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public virtual bool RenderMilliseconds
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) Used when converting received data into a Date when the type is specified as "date".
        /// </summary>
        [DefaultValue(null)]
        public virtual string DateFormat
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) The default value used when a Model is being created by a Reader when the item referenced by the mapping does not exist in the data object (i.e. undefined). (defaults to "")
        /// </summary>
        [DefaultValue(null)]
        public virtual object DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// True to render this property as complex object
        /// </summary>
        [DefaultValue(false)]
        public virtual bool IsComplex
        {
            get;
            set;
        }

        /// <summary>
        /// False to exclude this field from the Ext.data.Model.modified fields in a model. This will also exclude the field from being written using a Ext.data.writer.Writer. This option is useful when model fields are used to keep state on the client but do not need to be persisted to the server. Defaults to true.
        /// </summary>
        [DefaultValue(true)]
        public virtual bool Persist
        {
            get
            {
                return this.persist;
            }
            set
            {
                this.persist = value;
            }
        }

        /// <summary>
        /// Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool UseNull
        {
            get;
            set;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class VirtualModelField : ModelFieldAttribute
    {
        public override void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            if (!metadata.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY))
            {
                metadata.AdditionalValues[ModelFieldAttribute.KEY] = new List<VirtualModelField>();
            }

            var collection = (List<VirtualModelField>)metadata.AdditionalValues[ModelFieldAttribute.KEY];
            collection.Add(this);
        }
    }
}