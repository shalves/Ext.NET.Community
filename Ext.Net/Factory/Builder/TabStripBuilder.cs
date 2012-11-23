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
    public partial class TabStrip
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTabStrip, TBuilder> : ComponentBase.Builder<TTabStrip, TBuilder>
            where TTabStrip : TabStrip
            where TBuilder : Builder<TTabStrip, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTabStrip component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The position where the tab strip should be rendered (defaults to 'top'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'top'.
			/// </summary>
            public virtual TBuilder TabPosition(TabPosition tabPosition)
            {
                this.ToComponent().TabPosition = tabPosition;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Items Collection
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Items(Action<Tabs> action)
            {
                action(this.ToComponent().Items);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
            public virtual TBuilder ActionContainerID(string actionContainerID)
            {
                this.ToComponent().ActionContainerID = actionContainerID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
            public virtual TBuilder ActionContainer(Container actionContainer)
            {
                this.ToComponent().ActionContainer = actionContainer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
            public virtual TBuilder ActiveTabIndex(int activeTabIndex)
            {
                this.ToComponent().ActiveTabIndex = activeTabIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MinTabWidth(int minTabWidth)
            {
                this.ToComponent().MinTabWidth = minTabWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MaxTabWidth(int maxTabWidth)
            {
                this.ToComponent().MaxTabWidth = maxTabWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the tab strip without a background content Container image (defaults to true).
			/// </summary>
            public virtual TBuilder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<TabStripListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<TabStripDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
			/// </summary>
            public virtual TBuilder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TBuilder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TBuilder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TabStrip.Builder<TabStrip, TabStrip.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TabStrip()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStrip component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStrip.Config config) : base(new TabStrip(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TabStrip component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TabStrip(this);
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
        public TabStrip.Builder TabStrip()
        {
#if MVC
			return this.TabStrip(new TabStrip { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TabStrip(new TabStrip());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip(TabStrip component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TabStrip.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip(TabStrip.Config config)
        {
#if MVC
			return new TabStrip.Builder(new TabStrip(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TabStrip.Builder(new TabStrip(config));
#endif			
        }
    }
}