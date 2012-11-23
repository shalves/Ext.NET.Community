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
    public partial class TabScrollerMenu
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTabScrollerMenu, TBuilder> : Plugin.Builder<TTabScrollerMenu, TBuilder>
            where TTabScrollerMenu : TabScrollerMenu
            where TBuilder : Builder<TTabScrollerMenu, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTabScrollerMenu component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The page size.
			/// </summary>
            public virtual TBuilder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum text length to truncate.
			/// </summary>
            public virtual TBuilder MaxText(int maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Menu prefix text.
			/// </summary>
            public virtual TBuilder MenuPrefixText(string menuPrefixText)
            {
                this.ToComponent().MenuPrefixText = menuPrefixText;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TabScrollerMenu.Builder<TabScrollerMenu, TabScrollerMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TabScrollerMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabScrollerMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabScrollerMenu.Config config) : base(new TabScrollerMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TabScrollerMenu component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TabScrollerMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TabScrollerMenu(this);
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
        public TabScrollerMenu.Builder TabScrollerMenu()
        {
#if MVC
			return this.TabScrollerMenu(new TabScrollerMenu { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TabScrollerMenu(new TabScrollerMenu());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TabScrollerMenu.Builder TabScrollerMenu(TabScrollerMenu component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TabScrollerMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TabScrollerMenu.Builder TabScrollerMenu(TabScrollerMenu.Config config)
        {
#if MVC
			return new TabScrollerMenu.Builder(new TabScrollerMenu(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TabScrollerMenu.Builder(new TabScrollerMenu(config));
#endif			
        }
    }
}