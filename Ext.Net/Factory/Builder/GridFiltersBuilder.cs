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
 * @version   : 2.1.1 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
    public partial class GridFilters
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGridFilters, TBuilder> : GridFeature.Builder<TGridFilters, TBuilder>
            where TGridFilters : GridFilters
            where TBuilder : Builder<TGridFilters, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGridFilters component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Defaults to true, reloading the datasource when a filter change happens.
			/// </summary>
            public virtual TBuilder AutoReload(bool autoReload)
            {
                this.ToComponent().AutoReload = autoReload;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Number of milisecond to defer store updates since the last filter change.
			/// </summary>
            public virtual TBuilder UpdateBuffer(int updateBuffer)
            {
                this.ToComponent().UpdateBuffer = updateBuffer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'.
			/// </summary>
            public virtual TBuilder FilterCls(string filterCls)
            {
                this.ToComponent().FilterCls = filterCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use Ext.data.Store filter functions (local filtering) instead of the default server side filtering.
			/// </summary>
            public virtual TBuilder Local(bool local)
            {
                this.ToComponent().Local = local;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text displayed for the 'Filters' menu item.
			/// </summary>
            public virtual TBuilder MenuFilterText(string menuFilterText)
            {
                this.ToComponent().MenuFilterText = menuFilterText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The url parameter prefix for the filters.
			/// </summary>
            public virtual TBuilder ParamPrefix(string paramPrefix)
            {
                this.ToComponent().ParamPrefix = paramPrefix;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to true, including a filter submenu in the default header menu.
			/// </summary>
            public virtual TBuilder ShowMenu(bool showMenu)
            {
                this.ToComponent().ShowMenu = showMenu;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the value to be used to store state information.
			/// </summary>
            public virtual TBuilder StateId(string stateId)
            {
                this.ToComponent().StateId = stateId;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An Array of filters config objects.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Filters(Action<GridFilterCollection> action)
            {
                action(this.ToComponent().Filters);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<GridFiltersListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<GridFiltersDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridFilters.Builder<GridFilters, GridFilters.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GridFilters()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridFilters component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridFilters.Config config) : base(new GridFilters(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GridFilters component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GridFilters.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GridFilters(this);
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
        public GridFilters.Builder GridFilters()
        {
#if MVC
			return this.GridFilters(new GridFilters { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.GridFilters(new GridFilters());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public GridFilters.Builder GridFilters(GridFilters component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new GridFilters.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GridFilters.Builder GridFilters(GridFilters.Config config)
        {
#if MVC
			return new GridFilters.Builder(new GridFilters(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new GridFilters.Builder(new GridFilters(config));
#endif			
        }
    }
}