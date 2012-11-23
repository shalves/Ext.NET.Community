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
    public partial class DragTracker
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDragTracker, TBuilder> : LazyObservable.Builder<TDragTracker, TBuilder>
            where TDragTracker : DragTracker
            where TBuilder : Builder<TDragTracker, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDragTracker component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Set to true to fire mouseover and mouseout events when the mouse enters or leaves the target element.
			/// </summary>
            public virtual TBuilder TrackOver(bool trackOver)
            {
                this.ToComponent().TrackOver = trackOver;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Number of pixels the drag target must be moved before dragging is considered to have started. Defaults to 5.
			/// </summary>
            public virtual TBuilder Tolerance(int tolerance)
            {
                this.ToComponent().Tolerance = tolerance;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to 0. Specify a Number for the number of milliseconds to defer trigger start.
			/// </summary>
            public virtual TBuilder AutoStart(int autoStart)
            {
                this.ToComponent().AutoStart = autoStart;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Proxy class
			/// </summary>
            public virtual TBuilder ProxyCls(string proxyCls)
            {
                this.ToComponent().ProxyCls = proxyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to add to the DragTracker's target element when the element (or, if the delegate option is used, when a delegate element) is mouseovered.
			/// </summary>
            public virtual TBuilder OverCls(string overCls)
            {
                this.ToComponent().OverCls = overCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A Region (Or an element from which a Region measurement will be read) which is used to constrain the result of the getOffset call.
			/// </summary>
            public virtual TBuilder ConstrainTo(string constrainTo)
            {
                this.ToComponent().ConstrainTo = constrainTo;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A DomQuery selector which identifies child elements within the DragTracker's encapsulating Element which are the tracked elements. This limits tracking to only begin when the matching elements are mousedowned.
			/// </summary>
            public virtual TBuilder Delegate(string _delegate)
            {
                this.ToComponent().Delegate = _delegate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify false to enable default actions on onMouseDown events. Defaults to true.
			/// </summary>
            public virtual TBuilder PreventDefault(bool preventDefault)
            {
                this.ToComponent().PreventDefault = preventDefault;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify true to stop the mousedown event from bubbling to outer listeners from the target element (or its delegates). Defaults to false.
			/// </summary>
            public virtual TBuilder StopEvent(bool stopEvent)
            {
                this.ToComponent().StopEvent = stopEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to true. If false then no selection tracker
			/// </summary>
            public virtual TBuilder Selection(bool selection)
            {
                this.ToComponent().Selection = selection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// ID of the element that is linked to this instance
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnBeforeStart(Action<JFunction> action)
            {
                action(this.ToComponent().OnBeforeStart);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnStart(Action<JFunction> action)
            {
                action(this.ToComponent().OnStart);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnDrag(Action<JFunction> action)
            {
                action(this.ToComponent().OnDrag);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnEnd(Action<JFunction> action)
            {
                action(this.ToComponent().OnEnd);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<DragTrackerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<DragTrackerDirectEvents> action)
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
        public partial class Builder : DragTracker.Builder<DragTracker, DragTracker.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DragTracker()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DragTracker component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DragTracker.Config config) : base(new DragTracker(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DragTracker component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DragTracker.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DragTracker(this);
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
        public DragTracker.Builder DragTracker()
        {
#if MVC
			return this.DragTracker(new DragTracker { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DragTracker(new DragTracker());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DragTracker.Builder DragTracker(DragTracker component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DragTracker.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DragTracker.Builder DragTracker(DragTracker.Config config)
        {
#if MVC
			return new DragTracker.Builder(new DragTracker(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DragTracker.Builder(new DragTracker(config));
#endif			
        }
    }
}