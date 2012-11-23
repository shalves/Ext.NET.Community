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
    public partial class StatusBar
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TStatusBar, TBuilder> : ToolbarBase.Builder<TStatusBar, TBuilder>
            where TStatusBar : StatusBar
            where TBuilder : Builder<TStatusBar, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TStatusBar component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The number of milliseconds to wait after setting the status via setStatus before automatically clearing the status text and icon (defaults to 5000). Note that this only applies when passing the clear argument to setStatus since that is the only way to defer clearing the status. This can be overridden by specifying a different wait value in setStatus. Calls to clearStatus always clear the status bar immediately and ignore this value.
			/// </summary>
            public virtual TBuilder AutoClear(int autoClear)
            {
                this.ToComponent().AutoClear = autoClear;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default Icon applied when calling showBusy (defaults to 'Icon.None'). It can be overridden at any time by passing the iconCls argument into showBusy. See the Icon or IconCls docs for additional details about customizing the icon.
			/// </summary>
            public virtual TBuilder BusyIcon(Icon busyIcon)
            {
                this.ToComponent().BusyIcon = busyIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default iconCls applied when calling showBusy (defaults to 'x-status-busy'). It can be overridden at any time by passing the iconCls argument into showBusy. See the iconCls docs for additional details about customizing the icon.
			/// </summary>
            public virtual TBuilder BusyIconCls(string busyIconCls)
            {
                this.ToComponent().BusyIconCls = busyIconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default text applied when calling showBusy (defaults to 'Loading...'). It can be overridden at any time by passing the text argument into showBusy.
			/// </summary>
            public virtual TBuilder BusyText(string busyText)
            {
                this.ToComponent().BusyText = busyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default Icon (see the Icon or IconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to 'Icon.None').
			/// </summary>
            public virtual TBuilder DefaultIcon(Icon defaultIcon)
            {
                this.ToComponent().DefaultIcon = defaultIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default iconCls value (see the iconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').
			/// </summary>
            public virtual TBuilder DefaultIconCls(string defaultIconCls)
            {
                this.ToComponent().DefaultIconCls = defaultIconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default text value. This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').
			/// </summary>
            public virtual TBuilder DefaultText(string defaultText)
            {
                this.ToComponent().DefaultText = defaultText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An Icon that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to 'Icon.None'). The Icons is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to ''). The class is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The alignment of the status element within the overall StatusBar layout. When the StatusBar is rendered, it creates an internal div containing the status text and icon. Any additional Toolbar items added in the StatusBar's items config, or added via add or any of the supported add* methods, will be rendered, in added order, to the opposite side. The status element is greedy, so it will automatically expand to take up all sapce left over by any other items.
			/// </summary>
            public virtual TBuilder StatusAlign(StatusAlign statusAlign)
            {
                this.ToComponent().StatusAlign = statusAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string that will be rendered into the status element as the status message (defaults to '').
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ToolbarListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<StatusBarDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clears the status text and iconCls. Also supports clearing via an optional fade out animation.
			/// </summary>
            public virtual TBuilder ClearStatus()
            {
                this.ToComponent().ClearStatus();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Clears the status text and iconCls. Also supports clearing via an optional fade out animation.
			/// </summary>
            public virtual TBuilder ClearStatus(StatusBarClearStatusConfig config)
            {
                this.ToComponent().ClearStatus(config);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the status text and/or iconCls. Also supports automatically clearing the status that was set after a specified interval.
			/// </summary>
            public virtual TBuilder SetStatus(string text)
            {
                this.ToComponent().SetStatus(text);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the status text and/or iconCls. Also supports automatically clearing the status that was set after a specified interval.
			/// </summary>
            public virtual TBuilder SetStatus(StatusBarStatusConfig config)
            {
                this.ToComponent().SetStatus(config);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Convenience method for setting the status text and icon to special values that are pre-configured to indicate a 'busy' state, usually for loading or processing activities.
			/// </summary>
            public virtual TBuilder ShowBusy(string text)
            {
                this.ToComponent().ShowBusy(text);
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : StatusBar.Builder<StatusBar, StatusBar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new StatusBar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(StatusBar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(StatusBar.Config config) : base(new StatusBar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(StatusBar component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public StatusBar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.StatusBar(this);
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
        public StatusBar.Builder StatusBar()
        {
#if MVC
			return this.StatusBar(new StatusBar { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.StatusBar(new StatusBar());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public StatusBar.Builder StatusBar(StatusBar component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new StatusBar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public StatusBar.Builder StatusBar(StatusBar.Config config)
        {
#if MVC
			return new StatusBar.Builder(new StatusBar(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new StatusBar.Builder(new StatusBar(config));
#endif			
        }
    }
}