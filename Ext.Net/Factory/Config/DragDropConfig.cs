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
    public abstract partial class DragDrop
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Observable.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private Paddings defaultPadding = null;

			/// <summary>
			/// Provides default constraint padding to \"constrainTo\" elements (defaults to {left: 0, right:0, top:0, bottom:0}).
			/// </summary>
			public Paddings DefaultPadding
			{
				get
				{
					if (this.defaultPadding == null)
					{
						this.defaultPadding = new Paddings();
					}
			
					return this.defaultPadding;
				}
			}
			        
			private DragDropGroups groups = null;

			/// <summary>
			/// The group defines a logical collection of DragDrop objects that are related. Instances only get events when interacting with other DragDrop object in the same group. This lets us define multiple groups using a single DragDrop subclass if we want.
			/// </summary>
			public DragDropGroups Groups
			{
				get
				{
					if (this.groups == null)
					{
						this.groups = new DragDropGroups();
					}
			
					return this.groups;
				}
			}
			
			private bool hasOuterHandles = false;

			/// <summary>
			/// By default, drags can only be initiated if the mousedown occurs in the region the linked element is. This is done in part to work around a bug in some browsers that mis-report the mousedown if the previous mouseup happened outside of the window. This property is set to true if outer handles are defined.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HasOuterHandles 
			{ 
				get
				{
					return this.hasOuterHandles;
				}
				set
				{
					this.hasOuterHandles = value;
				}
			}

			private string target = "";

			/// <summary>
			/// The id of the element associated with this object. This is what we refer to as the \"linked element\" because the size and position of this element is used to determine when the drag and drop objects have interacted.
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

			private string group = "default";

			/// <summary>
			/// The group of related DragDrop objects
			/// </summary>
			[DefaultValue("default")]
			public virtual string Group 
			{ 
				get
				{
					return this.group;
				}
				set
				{
					this.group = value;
				}
			}

			private bool ignoreSelf = true;

			/// <summary>
			/// Set to false to enable a DragDrop object to fire drag events while dragging over its own Element. Defaults to true - DragDrop objects do not by default fire drag events to themselves.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool IgnoreSelf 
			{ 
				get
				{
					return this.ignoreSelf;
				}
				set
				{
					this.ignoreSelf = value;
				}
			}

			private string[] invalidHandleClasses = null;

			/// <summary>
			/// An Array of CSS class names for elements to be considered in valid as drag handles.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] InvalidHandleClasses 
			{ 
				get
				{
					return this.invalidHandleClasses;
				}
				set
				{
					this.invalidHandleClasses = value;
				}
			}

			private string[] invalidHandleTypes = null;

			/// <summary>
			/// An array who's items identify HTML tags to be considered invalid as drag handles.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] InvalidHandleTypes 
			{ 
				get
				{
					return this.invalidHandleTypes;
				}
				set
				{
					this.invalidHandleTypes = value;
				}
			}

			private string[] invalidHandleIds = null;

			/// <summary>
			/// An array who's items identify the IDs of elements to be considered invalid as drag handles
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] InvalidHandleIds 
			{ 
				get
				{
					return this.invalidHandleIds;
				}
				set
				{
					this.invalidHandleIds = value;
				}
			}

			private bool isTarget = true;

			/// <summary>
			/// By default, all instances can be a drop target. This can be disabled by setting isTarget to false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool IsTarget 
			{ 
				get
				{
					return this.isTarget;
				}
				set
				{
					this.isTarget = value;
				}
			}

			private bool maintainOffset = false;

			/// <summary>
			/// Maintain offsets when we resetconstraints. Set to true when you want the position of the element relative to its parent to stay the same when the page changes
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MaintainOffset 
			{ 
				get
				{
					return this.maintainOffset;
				}
				set
				{
					this.maintainOffset = value;
				}
			}

			private bool moveOnly = false;

			/// <summary>
			/// When set to true, other DD objects in cooperating DDGroups do not receive notification events when this DD object is dragged over them. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MoveOnly 
			{ 
				get
				{
					return this.moveOnly;
				}
				set
				{
					this.moveOnly = value;
				}
			}

			private int[] padding = null;

			/// <summary>
			/// The padding configured for this drag and drop object for calculating the drop zone intersection with this object. An array containing the 4 padding values: [top, right, bottom, left]
			/// </summary>
			[DefaultValue(null)]
			public virtual int[] Padding 
			{ 
				get
				{
					return this.padding;
				}
				set
				{
					this.padding = value;
				}
			}

			private bool primaryButtonOnly = true;

			/// <summary>
			/// By default the drag and drop instance will only respond to the primary button click (left button for a right-handed mouse). Set to true to allow drag and drop to start with any mouse click that is propogated by the browser
			/// </summary>
			[DefaultValue(true)]
			public virtual bool PrimaryButtonOnly 
			{ 
				get
				{
					return this.primaryButtonOnly;
				}
				set
				{
					this.primaryButtonOnly = value;
				}
			}

			private int[] xTicks = null;

			/// <summary>
			/// Array of pixel locations the element will snap to if we specified a horizontal graduation/interval. This array is generated automatically when you define a tick interval.
			/// </summary>
			[DefaultValue(null)]
			public virtual int[] XTicks 
			{ 
				get
				{
					return this.xTicks;
				}
				set
				{
					this.xTicks = value;
				}
			}

			private int[] yTicks = null;

			/// <summary>
			/// Array of pixel locations the element will snap to if we specified a vertical graduation/interval. This array is generated automatically when you define a tick interval.
			/// </summary>
			[DefaultValue(null)]
			public virtual int[] YTicks 
			{ 
				get
				{
					return this.yTicks;
				}
				set
				{
					this.yTicks = value;
				}
			}
        
			private JFunction getDragEl = null;

			/// <summary>
			/// Returns a reference to the actual element to drag. By default this is the same as the html element, but it can be assigned to another element. An example of this can be found in Ext.dd.DDProxy
			/// </summary>
			public JFunction GetDragEl
			{
				get
				{
					if (this.getDragEl == null)
					{
						this.getDragEl = new JFunction();
					}
			
					return this.getDragEl;
				}
			}
			        
			private JFunction endDrag = null;

			/// <summary>
			/// Fired when we are done dragging the object
			/// </summary>
			public JFunction EndDrag
			{
				get
				{
					if (this.endDrag == null)
					{
						this.endDrag = new JFunction();
					}
			
					return this.endDrag;
				}
			}
			        
			private JFunction onAvailable = null;

			/// <summary>
			/// Override the onAvailable method to do what is needed after the initial position was determined.
			/// </summary>
			public JFunction OnAvailable
			{
				get
				{
					if (this.onAvailable == null)
					{
						this.onAvailable = new JFunction();
					}
			
					return this.onAvailable;
				}
			}
			        
			private JFunction onDrag = null;

			/// <summary>
			/// Abstract method called during the onMouseMove event while dragging an object.
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
			        
			private JFunction onDragDrop = null;

			/// <summary>
			/// Abstract method called when this item is dropped on another DragDrop obj
			/// </summary>
			public JFunction OnDragDrop
			{
				get
				{
					if (this.onDragDrop == null)
					{
						this.onDragDrop = new JFunction();
					}
			
					return this.onDragDrop;
				}
			}
			        
			private JFunction onDragEnter = null;

			/// <summary>
			/// Abstract method called when this element fist begins hovering over another DragDrop obj
			/// </summary>
			public JFunction OnDragEnter
			{
				get
				{
					if (this.onDragEnter == null)
					{
						this.onDragEnter = new JFunction();
					}
			
					return this.onDragEnter;
				}
			}
			        
			private JFunction onDragOut = null;

			/// <summary>
			/// Abstract method called when we are no longer hovering over an element
			/// </summary>
			public JFunction OnDragOut
			{
				get
				{
					if (this.onDragOut == null)
					{
						this.onDragOut = new JFunction();
					}
			
					return this.onDragOut;
				}
			}
			        
			private JFunction onDragOver = null;

			/// <summary>
			/// Abstract method called when this element is hovering over another DragDrop obj
			/// </summary>
			public JFunction OnDragOver
			{
				get
				{
					if (this.onDragOver == null)
					{
						this.onDragOver = new JFunction();
					}
			
					return this.onDragOver;
				}
			}
			        
			private JFunction onInvalidDrop = null;

			/// <summary>
			/// Abstract method called when this item is dropped on an area with no drop target
			/// </summary>
			public JFunction OnInvalidDrop
			{
				get
				{
					if (this.onInvalidDrop == null)
					{
						this.onInvalidDrop = new JFunction();
					}
			
					return this.onInvalidDrop;
				}
			}
			        
			private JFunction onMouseDown = null;

			/// <summary>
			/// Event handler that fires when a drag/drop obj gets a mousedown
			/// </summary>
			public JFunction OnMouseDown
			{
				get
				{
					if (this.onMouseDown == null)
					{
						this.onMouseDown = new JFunction();
					}
			
					return this.onMouseDown;
				}
			}
			        
			private JFunction onMouseUp = null;

			/// <summary>
			/// Event handler that fires when a drag/drop obj gets a mouseup
			/// </summary>
			public JFunction OnMouseUp
			{
				get
				{
					if (this.onMouseUp == null)
					{
						this.onMouseUp = new JFunction();
					}
			
					return this.onMouseUp;
				}
			}
			        
			private JFunction startDrag = null;

			/// <summary>
			/// Event handler that fires when a drag/drop obj gets a mouseup
			/// </summary>
			public JFunction StartDrag
			{
				get
				{
					if (this.startDrag == null)
					{
						this.startDrag = new JFunction();
					}
			
					return this.startDrag;
				}
			}
			        
			private JFunction b4Drag = null;

			/// <summary>
			/// Code that executes immediately before the onDrag event
			/// </summary>
			public JFunction B4Drag
			{
				get
				{
					if (this.b4Drag == null)
					{
						this.b4Drag = new JFunction();
					}
			
					return this.b4Drag;
				}
			}
			        
			private JFunction b4DragDrop = null;

			/// <summary>
			/// Code that executes immediately before the onDragDrop event
			/// </summary>
			public JFunction B4DragDrop
			{
				get
				{
					if (this.b4DragDrop == null)
					{
						this.b4DragDrop = new JFunction();
					}
			
					return this.b4DragDrop;
				}
			}
			        
			private JFunction b4DragOut = null;

			/// <summary>
			/// Code that executes immediately before the onDragOut event
			/// </summary>
			public JFunction B4DragOut
			{
				get
				{
					if (this.b4DragOut == null)
					{
						this.b4DragOut = new JFunction();
					}
			
					return this.b4DragOut;
				}
			}
			        
			private JFunction b4DragOver = null;

			/// <summary>
			/// Code that executes immediately before the onDragOver event
			/// </summary>
			public JFunction B4DragOver
			{
				get
				{
					if (this.b4DragOver == null)
					{
						this.b4DragOver = new JFunction();
					}
			
					return this.b4DragOver;
				}
			}
			        
			private JFunction b4EndDrag = null;

			/// <summary>
			/// Code that executes immediately before the endDrag event
			/// </summary>
			public JFunction B4EndDrag
			{
				get
				{
					if (this.b4EndDrag == null)
					{
						this.b4EndDrag = new JFunction();
					}
			
					return this.b4EndDrag;
				}
			}
			        
			private JFunction b4MouseDown = null;

			/// <summary>
			/// Code executed immediately before the onMouseDown event
			/// </summary>
			public JFunction B4MouseDown
			{
				get
				{
					if (this.b4MouseDown == null)
					{
						this.b4MouseDown = new JFunction();
					}
			
					return this.b4MouseDown;
				}
			}
			        
			private JFunction b4StartDrag = null;

			/// <summary>
			/// Code that executes immediately before the startDrag event
			/// </summary>
			public JFunction B4StartDrag
			{
				get
				{
					if (this.b4StartDrag == null)
					{
						this.b4StartDrag = new JFunction();
					}
			
					return this.b4StartDrag;
				}
			}
			
        }
    }
}