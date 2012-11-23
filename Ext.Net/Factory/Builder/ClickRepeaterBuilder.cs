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
    public partial class ClickRepeater
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TClickRepeater, TBuilder> : Observable.Builder<TClickRepeater, TBuilder>
            where TClickRepeater : ClickRepeater
            where TBuilder : Builder<TClickRepeater, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TClickRepeater component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True if autorepeating should start slowly and accelerate. Interval and Delay are ignored.
			/// </summary>
            public virtual TBuilder Accelerate(bool accelerate)
            {
                this.ToComponent().Accelerate = accelerate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The initial delay before the repeating event begins firing. Similar to an autorepeat key delay.
			/// </summary>
            public virtual TBuilder Delay(int delay)
            {
                this.ToComponent().Delay = delay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The element to act as a button.
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The interval between firings of the \"click\" event. Default 20 ms.
			/// </summary>
            public virtual TBuilder Interval(int interval)
            {
                this.ToComponent().Interval = interval;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class name to be applied to the element while pressed.
			/// </summary>
            public virtual TBuilder PressedCls(string pressedCls)
            {
                this.ToComponent().PressedCls = pressedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to prevent the default click event.
			/// </summary>
            public virtual TBuilder PreventDefault(bool preventDefault)
            {
                this.ToComponent().PreventDefault = preventDefault;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to stop the default click event
			/// </summary>
            public virtual TBuilder StopDefault(bool stopDefault)
            {
                this.ToComponent().StopDefault = stopDefault;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function called when the traget is clicked (can be used instead of click event).
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to ignore the left button
			/// </summary>
            public virtual TBuilder IgnoreLeftButton(bool ignoreLeftButton)
            {
                this.ToComponent().IgnoreLeftButton = ignoreLeftButton;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to ignore the right button
			/// </summary>
            public virtual TBuilder IgnoreRightButton(bool ignoreRightButton)
            {
                this.ToComponent().IgnoreRightButton = ignoreRightButton;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to ignore the middle button
			/// </summary>
            public virtual TBuilder IgnoreMiddleButton(bool ignoreMiddleButton)
            {
                this.ToComponent().IgnoreMiddleButton = ignoreMiddleButton;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ClickRepeaterListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ClickRepeaterDirectEvents> action)
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
        public partial class Builder : ClickRepeater.Builder<ClickRepeater, ClickRepeater.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ClickRepeater()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ClickRepeater component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ClickRepeater.Config config) : base(new ClickRepeater(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ClickRepeater component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ClickRepeater.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ClickRepeater(this);
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
        public ClickRepeater.Builder ClickRepeater()
        {
#if MVC
			return this.ClickRepeater(new ClickRepeater { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ClickRepeater(new ClickRepeater());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ClickRepeater.Builder ClickRepeater(ClickRepeater component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ClickRepeater.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ClickRepeater.Builder ClickRepeater(ClickRepeater.Config config)
        {
#if MVC
			return new ClickRepeater.Builder(new ClickRepeater(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ClickRepeater.Builder(new ClickRepeater(config));
#endif			
        }
    }
}