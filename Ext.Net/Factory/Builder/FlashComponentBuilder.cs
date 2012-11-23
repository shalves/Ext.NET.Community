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
    public partial class FlashComponent
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TFlashComponent, TBuilder> : ComponentBase.Builder<TFlashComponent, TBuilder>
            where TFlashComponent : FlashComponent
            where TBuilder : Builder<TFlashComponent, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFlashComponent component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The background color. Defaults to '#ffffff' (white).
			/// </summary>
            public virtual TBuilder BackgroundColor(string backgroundColor)
            {
                this.ToComponent().BackgroundColor = backgroundColor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to prompt the user to install flash if not installed. Note that this uses Ext.FlashComponent.EXPRESS_INSTALL_URL, which should be set to the local resource. Defaults to false.
			/// </summary>
            public virtual TBuilder ExpressInstall(bool expressInstall)
            {
                this.ToComponent().ExpressInstall = expressInstall;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Indicates the version the flash content was published for. Defaults to '9.0.45'.
			/// </summary>
            public virtual TBuilder FlashVersion(string flashVersion)
            {
                this.ToComponent().FlashVersion = flashVersion;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The URL of the swf object to include. Defaults to undefined.
			/// </summary>
            public virtual TBuilder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A set of key value pairs to be passed to the flash object as flash variables.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FlashVars(Action<ParameterCollection> action)
            {
                action(this.ToComponent().FlashVars);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A set of key value pairs to be passed to the flash object as parameters.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FlashParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().FlashParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The height of the embedded SWF movie inside the component. Defaults to \"100%\" so that the movie matches the height of the component.
			/// </summary>
            public virtual TBuilder SwfHeight(string swfHeight)
            {
                this.ToComponent().SwfHeight = swfHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of the embedded SWF movie inside the component. Defaults to \"100%\" so that the movie matches the width of the component.
			/// </summary>
            public virtual TBuilder SwfWidth(string swfWidth)
            {
                this.ToComponent().SwfWidth = swfWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The wmode of the flash object. This can be used to control layering. Set to 'transparent' to ignore the backgroundColor and make the background of the Flash movie transparent.
			/// </summary>
            public virtual TBuilder WMode(string wMode)
            {
                this.ToComponent().WMode = wMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<FlashComponentListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<FlashComponentDirectEvents> action)
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
        public partial class Builder : FlashComponent.Builder<FlashComponent, FlashComponent.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FlashComponent()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FlashComponent component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FlashComponent.Config config) : base(new FlashComponent(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FlashComponent component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FlashComponent.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FlashComponent(this);
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
        public FlashComponent.Builder FlashComponent()
        {
#if MVC
			return this.FlashComponent(new FlashComponent { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.FlashComponent(new FlashComponent());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public FlashComponent.Builder FlashComponent(FlashComponent component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new FlashComponent.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FlashComponent.Builder FlashComponent(FlashComponent.Config config)
        {
#if MVC
			return new FlashComponent.Builder(new FlashComponent(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new FlashComponent.Builder(new FlashComponent(config));
#endif			
        }
    }
}