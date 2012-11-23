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
    public partial class DesktopTaskBar
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDesktopTaskBar, TBuilder> : Toolbar.Builder<TDesktopTaskBar, TBuilder>
            where TDesktopTaskBar : DesktopTaskBar
            where TBuilder : Builder<TDesktopTaskBar, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDesktopTaskBar component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder QuickStart(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().QuickStart);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Tray(Action<ToolbarCollection> action)
            {
                action(this.ToComponent().Tray);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideQuickStart(bool hideQuickStart)
            {
                this.ToComponent().HideQuickStart = hideQuickStart;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideTray(bool hideTray)
            {
                this.ToComponent().HideTray = hideTray;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder QuickStartWidth(int quickStartWidth)
            {
                this.ToComponent().QuickStartWidth = quickStartWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder TrayWidth(int trayWidth)
            {
                this.ToComponent().TrayWidth = trayWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TrayClock(Action<TrayClock> action)
            {
                action(this.ToComponent().TrayClock);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DesktopTaskBar.Builder<DesktopTaskBar, DesktopTaskBar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopTaskBar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopTaskBar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopTaskBar.Config config) : base(new DesktopTaskBar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopTaskBar component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopTaskBar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopTaskBar(this);
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
        public DesktopTaskBar.Builder DesktopTaskBar()
        {
#if MVC
			return this.DesktopTaskBar(new DesktopTaskBar { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DesktopTaskBar(new DesktopTaskBar());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopTaskBar.Builder DesktopTaskBar(DesktopTaskBar component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DesktopTaskBar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopTaskBar.Builder DesktopTaskBar(DesktopTaskBar.Config config)
        {
#if MVC
			return new DesktopTaskBar.Builder(new DesktopTaskBar(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DesktopTaskBar.Builder(new DesktopTaskBar(config));
#endif			
        }
    }
}