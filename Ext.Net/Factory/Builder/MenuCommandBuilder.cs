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
    public partial class MenuCommand
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TMenuCommand, TBuilder> : BaseItem.Builder<TMenuCommand, TBuilder>
            where TMenuCommand : MenuCommand
            where TBuilder : Builder<TMenuCommand, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMenuCommand component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CommandName(string commandName)
            {
                this.ToComponent().CommandName = commandName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CtCls(string ctCls)
            {
                this.ToComponent().CtCls = ctCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DisabledClass(string disabledClass)
            {
                this.ToComponent().DisabledClass = disabledClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder OverCls(string overCls)
            {
                this.ToComponent().OverCls = overCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Menu(Action<CommandMenu> action)
            {
                action(this.ToComponent().Menu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A function that will handle the click event of this menu item (defaults to undefined).
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to true).
			/// </summary>
            public virtual TBuilder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : MenuCommand.Builder<MenuCommand, MenuCommand.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MenuCommand()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuCommand component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuCommand.Config config) : base(new MenuCommand(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MenuCommand component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuCommand.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MenuCommand(this);
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
        public MenuCommand.Builder MenuCommand()
        {
#if MVC
			return this.MenuCommand(new MenuCommand { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.MenuCommand(new MenuCommand());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuCommand.Builder MenuCommand(MenuCommand component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new MenuCommand.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuCommand.Builder MenuCommand(MenuCommand.Config config)
        {
#if MVC
			return new MenuCommand.Builder(new MenuCommand(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new MenuCommand.Builder(new MenuCommand(config));
#endif			
        }
    }
}