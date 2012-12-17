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
    public partial class DesktopModule
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDesktopModule, TBuilder> : BaseItem.Builder<TDesktopModule, TBuilder>
            where TDesktopModule : DesktopModule
            where TBuilder : Builder<TDesktopModule, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDesktopModule component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ModuleID(string moduleID)
            {
                this.ToComponent().ModuleID = moduleID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Window(Action<WindowCollection> action)
            {
                action(this.ToComponent().Window);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Launcher(MenuItem launcher)
            {
                this.ToComponent().Launcher = launcher;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Shortcut(DesktopShortcut shortcut)
            {
                this.ToComponent().Shortcut = shortcut;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AutoRun(bool autoRun)
            {
                this.ToComponent().AutoRun = autoRun;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AutoRunHandler(string autoRunHandler)
            {
                this.ToComponent().AutoRunHandler = autoRunHandler;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DesktopModule.Builder<DesktopModule, DesktopModule.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopModule()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopModule component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopModule.Config config) : base(new DesktopModule(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopModule component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModule.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopModule(this);
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
        public DesktopModule.Builder DesktopModule()
        {
#if MVC
			return this.DesktopModule(new DesktopModule { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DesktopModule(new DesktopModule());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModule.Builder DesktopModule(DesktopModule component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DesktopModule.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModule.Builder DesktopModule(DesktopModule.Config config)
        {
#if MVC
			return new DesktopModule.Builder(new DesktopModule(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DesktopModule.Builder(new DesktopModule(config));
#endif			
        }
    }
}