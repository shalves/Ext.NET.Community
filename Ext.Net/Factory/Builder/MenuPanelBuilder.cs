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
    public partial class MenuPanel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TMenuPanel, TBuilder> : AbstractPanel.Builder<TMenuPanel, TBuilder>
            where TMenuPanel : MenuPanel
            where TBuilder : Builder<TMenuPanel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMenuPanel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Menu(Action<Menu> action)
            {
                action(this.ToComponent().Menu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Save selection after click
			/// </summary>
            public virtual TBuilder SaveSelection(bool saveSelection)
            {
                this.ToComponent().SaveSelection = saveSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Index of selected item
			/// </summary>
            public virtual TBuilder SelectedIndex(int selectedIndex)
            {
                this.ToComponent().SelectedIndex = selectedIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<PanelListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<PanelDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetSelectedIndex(int index)
            {
                this.ToComponent().SetSelectedIndex(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearSelection()
            {
                this.ToComponent().ClearSelection();
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : MenuPanel.Builder<MenuPanel, MenuPanel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MenuPanel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuPanel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuPanel.Config config) : base(new MenuPanel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MenuPanel component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuPanel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MenuPanel(this);
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
        public MenuPanel.Builder MenuPanel()
        {
#if MVC
			return this.MenuPanel(new MenuPanel { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.MenuPanel(new MenuPanel());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuPanel.Builder MenuPanel(MenuPanel component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new MenuPanel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuPanel.Builder MenuPanel(MenuPanel.Config config)
        {
#if MVC
			return new MenuPanel.Builder(new MenuPanel(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new MenuPanel.Builder(new MenuPanel(config));
#endif			
        }
    }
}