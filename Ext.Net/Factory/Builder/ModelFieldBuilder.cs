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
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ModelField
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TModelField, TBuilder> : BaseItem.Builder<TModelField, TBuilder>
            where TModelField : ModelField
            where TBuilder : Builder<TModelField, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TModelField component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name by which the field is referenced within the Model.
			/// </summary>
            public virtual TBuilder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (Optional) A path expression for use by the Ext.data.reader.Reader implementation that is creating the Model to extract the Field value from the data object. If the path expression is the same as the field name, the mapping may be omitted.
			/// </summary>
            public virtual TBuilder Mapping(string mapping)
            {
                this.ToComponent().Mapping = mapping;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ServerMapping(string serverMapping)
            {
                this.ToComponent().ServerMapping = serverMapping;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (Optional) The data type for automatic conversion from received data to the stored value if convert has not been specified.
			/// </summary>
            public virtual TBuilder Type(ModelFieldType type)
            {
                this.ToComponent().Type = type;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Sort method
			/// </summary>
            public virtual TBuilder SortType(SortTypeMethod sortType)
            {
                this.ToComponent().SortType = sortType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (Optional) Initial direction to sort
			/// </summary>
            public virtual TBuilder SortDir(SortDirection sortDir)
            {
                this.ToComponent().SortDir = sortDir;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Empty value representation during saving (default value as None)
			/// </summary>
            public virtual TBuilder SubmitEmptyValue(EmptyValue submitEmptyValue)
            {
                this.ToComponent().SubmitEmptyValue = submitEmptyValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder CustomSortType(Action<JFunction> action)
            {
                action(this.ToComponent().CustomSortType);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A function which converts the Model's value for this Field into a form which can be used by whatever Writer is being used to sync data with the server.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Serialize(Action<JFunction> action)
            {
                action(this.ToComponent().Serialize);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// (Optional) A function which converts the value provided by the Reader into an object that will be stored in the Record.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Convert(Action<JFunction> action)
            {
                action(this.ToComponent().Convert);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder NullConvert(bool nullConvert)
            {
                this.ToComponent().NullConvert = nullConvert;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RenderMilliseconds(bool renderMilliseconds)
            {
                this.ToComponent().RenderMilliseconds = renderMilliseconds;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (Optional) Used when converting received data into a Date when the type is specified as \"date\".
			/// </summary>
            public virtual TBuilder DateFormat(string dateFormat)
            {
                this.ToComponent().DateFormat = dateFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used to provide a custom format when serializing dates with a writer. If this is not specified, the DateFormat will be used.
			/// </summary>
            public virtual TBuilder DateWriteFormat(string dateWriteFormat)
            {
                this.ToComponent().DateWriteFormat = dateWriteFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used when converting received data into a Date when the Type is specified as \"Date\". This configuration takes precedence over DateFormat.
			/// </summary>
            public virtual TBuilder DateReadFormat(string dateReadFormat)
            {
                this.ToComponent().DateReadFormat = dateReadFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (Optional) The default value used when a Model is being created by a Reader when the item referenced by the mapping does not exist in the data object (i.e. undefined). (defaults to \"\")
			/// </summary>
            public virtual TBuilder DefaultValue(string defaultValue)
            {
                this.ToComponent().DefaultValue = defaultValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render this property as complex object
			/// </summary>
            public virtual TBuilder IsComplex(bool isComplex)
            {
                this.ToComponent().IsComplex = isComplex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to exclude this field from the Ext.data.Model.modified fields in a model. This will also exclude the field from being written using a Ext.data.writer.Writer. This option is useful when model fields are used to keep state on the client but do not need to be persisted to the server. Defaults to true.
			/// </summary>
            public virtual TBuilder Persist(bool persist)
            {
                this.ToComponent().Persist = persist;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false.
			/// </summary>
            public virtual TBuilder UseNull(bool useNull)
            {
                this.ToComponent().UseNull = useNull;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Configure `true` to encode html in the field before sync
			/// </summary>
            public virtual TBuilder HtmlEncode(bool htmlEncode)
            {
                this.ToComponent().HtmlEncode = htmlEncode;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ModelField.Builder<ModelField, ModelField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ModelField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ModelField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ModelField.Config config) : base(new ModelField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ModelField component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ModelField(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ModelField()
        {
#if MVC
			return this.ModelField(new ModelField { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ModelField(new ModelField());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ModelField(ModelField component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ModelField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ModelField.Builder ModelField(ModelField.Config config)
        {
#if MVC
			return new ModelField.Builder(new ModelField(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ModelField.Builder(new ModelField(config));
#endif			
        }
    }
}