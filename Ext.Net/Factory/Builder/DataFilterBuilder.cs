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
    public partial class DataFilter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDataFilter, TBuilder> : BaseItem.Builder<TDataFilter, TBuilder>
            where TDataFilter : DataFilter
            where TBuilder : Builder<TDataFilter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDataFilter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to allow any match - no regex start/end line anchors will be added. Defaults to false
			/// </summary>
            public virtual TBuilder AnyMatch(bool anyMatch)
            {
                this.ToComponent().AnyMatch = anyMatch;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to make the regex case sensitive (adds 'i' switch to regex). Defaults to false.
			/// </summary>
            public virtual TBuilder CaseSensitive(bool caseSensitive)
            {
                this.ToComponent().CaseSensitive = caseSensitive;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to force exact match (^ and $ characters added to the regex). Defaults to false. Ignored if anyMatch is true.
			/// </summary>
            public virtual TBuilder ExactMatch(bool exactMatch)
            {
                this.ToComponent().ExactMatch = exactMatch;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The property to filter on. Required unless a filter is passed
			/// </summary>
            public virtual TBuilder Property(string property)
            {
                this.ToComponent().Property = property;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional root property. This is mostly useful when filtering a Store, in which case we set the root to 'data' to make the filter pull the property out of the data object of each item
			/// </summary>
            public virtual TBuilder Root(string root)
            {
                this.ToComponent().Root = root;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Filter value
			/// </summary>
            public virtual TBuilder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DataFilter.Builder<DataFilter, DataFilter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DataFilter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataFilter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataFilter.Config config) : base(new DataFilter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DataFilter component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataFilter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DataFilter(this);
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
        public DataFilter.Builder DataFilter()
        {
#if MVC
			return this.DataFilter(new DataFilter { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DataFilter(new DataFilter());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DataFilter.Builder DataFilter(DataFilter component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DataFilter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataFilter.Builder DataFilter(DataFilter.Config config)
        {
#if MVC
			return new DataFilter.Builder(new DataFilter(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DataFilter.Builder(new DataFilter(config));
#endif			
        }
    }
}