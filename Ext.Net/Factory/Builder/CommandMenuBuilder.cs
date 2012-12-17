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
    public partial class CommandMenu
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCommandMenu, TBuilder> : BaseItem.Builder<TCommandMenu, TBuilder>
            where TCommandMenu : CommandMenu
            where TBuilder : Builder<TCommandMenu, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCommandMenu component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Items(Action<MenuCommandCollection> action)
            {
                action(this.ToComponent().Items);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Shared(bool shared)
            {
                this.ToComponent().Shared = shared;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whenever a menu gets so long that the items won't fit the viewable area, it provides the user with an easy UI to scroll the menu.
			/// </summary>
            public virtual TBuilder EnableScrolling(bool enableScrolling)
            {
                this.ToComponent().EnableScrolling = enableScrolling;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width of the menu in pixels (defaults to 120).
			/// </summary>
            public virtual TBuilder MinWidth(int minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum height of the menu. Only applies when enableScrolling is set to True (defaults to null).
			/// </summary>
            public virtual TBuilder MaxHeight(int maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The amount to scroll the menu. Only applies when enableScrolling is set to True (defaults to 24).
			/// </summary>
            public virtual TBuilder ScrollIncrement(int scrollIncrement)
            {
                this.ToComponent().ScrollIncrement = scrollIncrement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show the icon separator. (defaults to true).
			/// </summary>
            public virtual TBuilder ShowSeparator(bool showSeparator)
            {
                this.ToComponent().ShowSeparator = showSeparator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True or \"sides\" for the default effect, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"sides\")
			/// </summary>
            public virtual TBuilder Shadow(ShadowMode shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.Element.alignTo anchor position value to use for submenus of this menu (defaults to \"tl-tr?\")
			/// </summary>
            public virtual TBuilder SubMenuAlign(string subMenuAlign)
            {
                this.ToComponent().SubMenuAlign = subMenuAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).
			/// </summary>
            public virtual TBuilder IgnoreParentClicks(bool ignoreParentClicks)
            {
                this.ToComponent().IgnoreParentClicks = ignoreParentClicks;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CommandMenu.Builder<CommandMenu, CommandMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CommandMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandMenu.Config config) : base(new CommandMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CommandMenu component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CommandMenu(this);
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
        public CommandMenu.Builder CommandMenu()
        {
#if MVC
			return this.CommandMenu(new CommandMenu { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CommandMenu(new CommandMenu());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandMenu.Builder CommandMenu(CommandMenu component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CommandMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandMenu.Builder CommandMenu(CommandMenu.Config config)
        {
#if MVC
			return new CommandMenu.Builder(new CommandMenu(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CommandMenu.Builder(new CommandMenu(config));
#endif			
        }
    }
}