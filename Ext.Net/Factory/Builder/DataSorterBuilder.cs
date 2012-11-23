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
    public partial class DataSorter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDataSorter, TBuilder> : BaseItem.Builder<TDataSorter, TBuilder>
            where TDataSorter : DataSorter
            where TBuilder : Builder<TDataSorter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDataSorter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The direction to sort by. Defaults to ASC
			/// </summary>
            public virtual TBuilder Direction(SortDirection direction)
            {
                this.ToComponent().Direction = direction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The property to sort by. Required unless sorterFn is provided
			/// </summary>
            public virtual TBuilder Property(string property)
            {
                this.ToComponent().Property = property;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional root property. This is mostly useful when sorting a Store, in which case we set the root to 'data' to make the filter pull the property out of the data object of each item
			/// </summary>
            public virtual TBuilder Root(string root)
            {
                this.ToComponent().Root = root;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DataSorter.Builder<DataSorter, DataSorter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DataSorter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataSorter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataSorter.Config config) : base(new DataSorter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DataSorter component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DataSorter(this);
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
        public DataSorter.Builder DataSorter()
        {
#if MVC
			return this.DataSorter(new DataSorter { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DataSorter(new DataSorter());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter.Builder DataSorter(DataSorter component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DataSorter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter.Builder DataSorter(DataSorter.Config config)
        {
#if MVC
			return new DataSorter.Builder(new DataSorter(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DataSorter.Builder(new DataSorter(config));
#endif			
        }
    }
}