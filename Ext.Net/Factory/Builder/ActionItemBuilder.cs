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
    public partial class ActionItem
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TActionItem, TBuilder> : BaseItem.Builder<TActionItem, TBuilder>
            where TActionItem : ActionItem
            where TBuilder : Builder<TActionItem, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TActionItem component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An icon to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The url of an image to display as the clickable element in the column.
			/// </summary>
            public virtual TBuilder IconUrl(string iconUrl)
            {
                this.ToComponent().IconUrl = iconUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function which returns the CSS class to apply to the icon image.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetClass(Action<JFunction> action)
            {
                action(this.ToComponent().GetClass);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A function which returns the tooltip string for any row.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetTip(Action<JFunction> action)
            {
                action(this.ToComponent().GetTip);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A function which determines whether the action item for any row is disabled and returns true or false.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder IsDisabled(Action<JFunction> action)
            {
                action(this.ToComponent().IsDisabled);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A function called when the icon is clicked.
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which the handler, getClass, isDisabled and getTip fuctions are executed. Defaults to this Column.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A tooltip message to be displayed on hover. Ext.tip.QuickTipManager must have been initialized.
			/// </summary>
            public virtual TBuilder Tooltip(string tooltip)
            {
                this.ToComponent().Tooltip = tooltip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true, the action will not respond to click events, and will be displayed semi-opaque.
			/// </summary>
            public virtual TBuilder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ActionItem.Builder<ActionItem, ActionItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ActionItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ActionItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ActionItem.Config config) : base(new ActionItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ActionItem component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ActionItem(this);
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
        public ActionItem.Builder ActionItem()
        {
#if MVC
			return this.ActionItem(new ActionItem { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ActionItem(new ActionItem());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionItem.Builder ActionItem(ActionItem component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ActionItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionItem.Builder ActionItem(ActionItem.Config config)
        {
#if MVC
			return new ActionItem.Builder(new ActionItem(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ActionItem.Builder(new ActionItem(config));
#endif			
        }
    }
}