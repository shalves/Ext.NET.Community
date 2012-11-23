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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DragTracker(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DragTracker.Config Conversion to DragTracker
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DragTracker(DragTracker.Config config)
        {
            return new DragTracker(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : LazyObservable.Config 
        { 
			/*  Implicit DragTracker.Config Conversion to DragTracker.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DragTracker.Builder(DragTracker.Config config)
			{
				return new DragTracker.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool trackOver = false;

			/// <summary>
			/// Set to true to fire mouseover and mouseout events when the mouse enters or leaves the target element.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TrackOver 
			{ 
				get
				{
					return this.trackOver;
				}
				set
				{
					this.trackOver = value;
				}
			}

			private int tolerance = 5;

			/// <summary>
			/// Number of pixels the drag target must be moved before dragging is considered to have started. Defaults to 5.
			/// </summary>
			[DefaultValue(5)]
			public virtual int Tolerance 
			{ 
				get
				{
					return this.tolerance;
				}
				set
				{
					this.tolerance = value;
				}
			}

			private int autoStart = 0;

			/// <summary>
			/// Defaults to 0. Specify a Number for the number of milliseconds to defer trigger start.
			/// </summary>
			[DefaultValue(0)]
			public virtual int AutoStart 
			{ 
				get
				{
					return this.autoStart;
				}
				set
				{
					this.autoStart = value;
				}
			}

			private string proxyCls = "x-view-selector";

			/// <summary>
			/// Proxy class
			/// </summary>
			[DefaultValue("x-view-selector")]
			public virtual string ProxyCls 
			{ 
				get
				{
					return this.proxyCls;
				}
				set
				{
					this.proxyCls = value;
				}
			}

			private string overCls = "";

			/// <summary>
			/// A CSS class to add to the DragTracker's target element when the element (or, if the delegate option is used, when a delegate element) is mouseovered.
			/// </summary>
			[DefaultValue("")]
			public virtual string OverCls 
			{ 
				get
				{
					return this.overCls;
				}
				set
				{
					this.overCls = value;
				}
			}

			private string constrainTo = "";

			/// <summary>
			/// A Region (Or an element from which a Region measurement will be read) which is used to constrain the result of the getOffset call.
			/// </summary>
			[DefaultValue("")]
			public virtual string ConstrainTo 
			{ 
				get
				{
					return this.constrainTo;
				}
				set
				{
					this.constrainTo = value;
				}
			}

			private string _delegate = "";

			/// <summary>
			/// A DomQuery selector which identifies child elements within the DragTracker's encapsulating Element which are the tracked elements. This limits tracking to only begin when the matching elements are mousedowned.
			/// </summary>
			[DefaultValue("")]
			public virtual string Delegate 
			{ 
				get
				{
					return this._delegate;
				}
				set
				{
					this._delegate = value;
				}
			}

			private bool preventDefault = true;

			/// <summary>
			/// Specify false to enable default actions on onMouseDown events. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool PreventDefault 
			{ 
				get
				{
					return this.preventDefault;
				}
				set
				{
					this.preventDefault = value;
				}
			}

			private bool stopEvent = false;

			/// <summary>
			/// Specify true to stop the mousedown event from bubbling to outer listeners from the target element (or its delegates). Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StopEvent 
			{ 
				get
				{
					return this.stopEvent;
				}
				set
				{
					this.stopEvent = value;
				}
			}

			private bool selection = true;

			/// <summary>
			/// Defaults to true. If false then no selection tracker
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Selection 
			{ 
				get
				{
					return this.selection;
				}
				set
				{
					this.selection = value;
				}
			}

			private string target = "";

			/// <summary>
			/// ID of the element that is linked to this instance
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}
        
			private JFunction onBeforeStart = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction OnBeforeStart
			{
				get
				{
					if (this.onBeforeStart == null)
					{
						this.onBeforeStart = new JFunction();
					}
			
					return this.onBeforeStart;
				}
			}
			        
			private JFunction onStart = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction OnStart
			{
				get
				{
					if (this.onStart == null)
					{
						this.onStart = new JFunction();
					}
			
					return this.onStart;
				}
			}
			        
			private JFunction onDrag = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction OnDrag
			{
				get
				{
					if (this.onDrag == null)
					{
						this.onDrag = new JFunction();
					}
			
					return this.onDrag;
				}
			}
			        
			private JFunction onEnd = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction OnEnd
			{
				get
				{
					if (this.onEnd == null)
					{
						this.onEnd = new JFunction();
					}
			
					return this.onEnd;
				}
			}
			        
			private DragTrackerListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public DragTrackerListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new DragTrackerListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private DragTrackerDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public DragTrackerDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new DragTrackerDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}