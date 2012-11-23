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
    public partial class RowExpander
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TRowExpander, TBuilder> : Plugin.Builder<TRowExpander, TBuilder>
            where TRowExpander : RowExpander
            where TBuilder : Builder<TRowExpander, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TRowExpander component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A configuration object or an instance of a Ext.ComponentLoader to load remote content.
			/// </summary>
            public virtual TBuilder Loader(ComponentLoader loader)
            {
                this.ToComponent().Loader = loader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The template string to use to display each item in the dropdown list.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Template(Action<XTemplate> action)
            {
                action(this.ToComponent().Template);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Component(Action<ItemsCollection<AbstractComponent>> action)
            {
                action(this.ToComponent().Component);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Recreate component on each row expand
			/// </summary>
            public virtual TBuilder RecreateComponent(bool recreateComponent)
            {
                this.ToComponent().RecreateComponent = recreateComponent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Call doLayout after a row expanding/collapsing
			/// </summary>
            public virtual TBuilder DoLayoutOnExpand(bool doLayoutOnExpand)
            {
                this.ToComponent().DoLayoutOnExpand = doLayoutOnExpand;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Swallow row body's events
			/// </summary>
            public virtual TBuilder SwallowBodyEvents(bool swallowBodyEvents)
            {
                this.ToComponent().SwallowBodyEvents = swallowBodyEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to select a row when clicking on the expander icon (defaults to false).
			/// </summary>
            public virtual TBuilder SelectRowOnExpand(bool selectRowOnExpand)
            {
                this.ToComponent().SelectRowOnExpand = selectRowOnExpand;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ScrollOffset(int scrollOffset)
            {
                this.ToComponent().ScrollOffset = scrollOffset;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ExpandOnEnter(bool expandOnEnter)
            {
                this.ToComponent().ExpandOnEnter = expandOnEnter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ExpandOnDblClick(bool expandOnDblClick)
            {
                this.ToComponent().ExpandOnDblClick = expandOnDblClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InvalidateComponentsOnRefresh(bool invalidateComponentsOnRefresh)
            {
                this.ToComponent().InvalidateComponentsOnRefresh = invalidateComponentsOnRefresh;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SingleExpand(bool? singleExpand)
            {
                this.ToComponent().SingleExpand = singleExpand;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.
			/// </summary>
            public virtual TBuilder Renderer(Renderer renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<RowExpanderListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<RowExpanderDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Toggle (expand/collapse) row
			/// </summary>
            public virtual TBuilder ToggleRow(int row)
            {
                this.ToComponent().ToggleRow(row);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Expand all rows
			/// </summary>
            public virtual TBuilder ExpandAll()
            {
                this.ToComponent().ExpandAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Collapse all rows
			/// </summary>
            public virtual TBuilder CollapseAll()
            {
                this.ToComponent().CollapseAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Expand row
			/// </summary>
            public virtual TBuilder ExpandRow(int row)
            {
                this.ToComponent().ExpandRow(row);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Collapse row
			/// </summary>
            public virtual TBuilder CollapseRow(int row)
            {
                this.ToComponent().CollapseRow(row);
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : RowExpander.Builder<RowExpander, RowExpander.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RowExpander()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowExpander component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowExpander.Config config) : base(new RowExpander(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RowExpander component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public RowExpander.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RowExpander(this);
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
        public RowExpander.Builder RowExpander()
        {
#if MVC
			return this.RowExpander(new RowExpander { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.RowExpander(new RowExpander());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public RowExpander.Builder RowExpander(RowExpander component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new RowExpander.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RowExpander.Builder RowExpander(RowExpander.Config config)
        {
#if MVC
			return new RowExpander.Builder(new RowExpander(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new RowExpander.Builder(new RowExpander(config));
#endif			
        }
    }
}