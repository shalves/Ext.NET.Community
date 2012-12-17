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
        new public abstract partial class Builder<TDragDrop, TBuilder> : Observable.Builder<TDragDrop, TBuilder>
            where TDragDrop : DragDrop
            where TBuilder : Builder<TDragDrop, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDragDrop component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Provides default constraint padding to \"constrainTo\" elements (defaults to {left: 0, right:0, top:0, bottom:0}).
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DefaultPadding(Action<Paddings> action)
            {
                action(this.ToComponent().DefaultPadding);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The group defines a logical collection of DragDrop objects that are related. Instances only get events when interacting with other DragDrop object in the same group. This lets us define multiple groups using a single DragDrop subclass if we want.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Groups(Action<DragDropGroups> action)
            {
                action(this.ToComponent().Groups);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// By default, drags can only be initiated if the mousedown occurs in the region the linked element is. This is done in part to work around a bug in some browsers that mis-report the mousedown if the previous mouseup happened outside of the window. This property is set to true if outer handles are defined.
			/// </summary>
            public virtual TBuilder HasOuterHandles(bool hasOuterHandles)
            {
                this.ToComponent().HasOuterHandles = hasOuterHandles;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id of the element associated with this object. This is what we refer to as the \"linked element\" because the size and position of this element is used to determine when the drag and drop objects have interacted.
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The group of related DragDrop objects
			/// </summary>
            public virtual TBuilder Group(string group)
            {
                this.ToComponent().Group = group;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to false to enable a DragDrop object to fire drag events while dragging over its own Element. Defaults to true - DragDrop objects do not by default fire drag events to themselves.
			/// </summary>
            public virtual TBuilder IgnoreSelf(bool ignoreSelf)
            {
                this.ToComponent().IgnoreSelf = ignoreSelf;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An Array of CSS class names for elements to be considered in valid as drag handles.
			/// </summary>
            public virtual TBuilder InvalidHandleClasses(string[] invalidHandleClasses)
            {
                this.ToComponent().InvalidHandleClasses = invalidHandleClasses;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array who's items identify HTML tags to be considered invalid as drag handles.
			/// </summary>
            public virtual TBuilder InvalidHandleTypes(string[] invalidHandleTypes)
            {
                this.ToComponent().InvalidHandleTypes = invalidHandleTypes;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array who's items identify the IDs of elements to be considered invalid as drag handles
			/// </summary>
            public virtual TBuilder InvalidHandleIds(string[] invalidHandleIds)
            {
                this.ToComponent().InvalidHandleIds = invalidHandleIds;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// By default, all instances can be a drop target. This can be disabled by setting isTarget to false.
			/// </summary>
            public virtual TBuilder IsTarget(bool isTarget)
            {
                this.ToComponent().IsTarget = isTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Maintain offsets when we resetconstraints. Set to true when you want the position of the element relative to its parent to stay the same when the page changes
			/// </summary>
            public virtual TBuilder MaintainOffset(bool maintainOffset)
            {
                this.ToComponent().MaintainOffset = maintainOffset;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// When set to true, other DD objects in cooperating DDGroups do not receive notification events when this DD object is dragged over them. Defaults to false.
			/// </summary>
            public virtual TBuilder MoveOnly(bool moveOnly)
            {
                this.ToComponent().MoveOnly = moveOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The padding configured for this drag and drop object for calculating the drop zone intersection with this object. An array containing the 4 padding values: [top, right, bottom, left]
			/// </summary>
            public virtual TBuilder Padding(int[] padding)
            {
                this.ToComponent().Padding = padding;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// By default the drag and drop instance will only respond to the primary button click (left button for a right-handed mouse). Set to true to allow drag and drop to start with any mouse click that is propogated by the browser
			/// </summary>
            public virtual TBuilder PrimaryButtonOnly(bool primaryButtonOnly)
            {
                this.ToComponent().PrimaryButtonOnly = primaryButtonOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Array of pixel locations the element will snap to if we specified a horizontal graduation/interval. This array is generated automatically when you define a tick interval.
			/// </summary>
            public virtual TBuilder XTicks(int[] xTicks)
            {
                this.ToComponent().XTicks = xTicks;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Array of pixel locations the element will snap to if we specified a vertical graduation/interval. This array is generated automatically when you define a tick interval.
			/// </summary>
            public virtual TBuilder YTicks(int[] yTicks)
            {
                this.ToComponent().YTicks = yTicks;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Returns a reference to the actual element to drag. By default this is the same as the html element, but it can be assigned to another element. An example of this can be found in Ext.dd.DDProxy
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetDragEl(Action<JFunction> action)
            {
                action(this.ToComponent().GetDragEl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Fired when we are done dragging the object
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EndDrag(Action<JFunction> action)
            {
                action(this.ToComponent().EndDrag);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Override the onAvailable method to do what is needed after the initial position was determined.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnAvailable(Action<JFunction> action)
            {
                action(this.ToComponent().OnAvailable);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Abstract method called during the onMouseMove event while dragging an object.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnDrag(Action<JFunction> action)
            {
                action(this.ToComponent().OnDrag);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Abstract method called when this item is dropped on another DragDrop obj
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnDragDrop(Action<JFunction> action)
            {
                action(this.ToComponent().OnDragDrop);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Abstract method called when this element fist begins hovering over another DragDrop obj
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnDragEnter(Action<JFunction> action)
            {
                action(this.ToComponent().OnDragEnter);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Abstract method called when we are no longer hovering over an element
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnDragOut(Action<JFunction> action)
            {
                action(this.ToComponent().OnDragOut);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Abstract method called when this element is hovering over another DragDrop obj
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnDragOver(Action<JFunction> action)
            {
                action(this.ToComponent().OnDragOver);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Abstract method called when this item is dropped on an area with no drop target
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnInvalidDrop(Action<JFunction> action)
            {
                action(this.ToComponent().OnInvalidDrop);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Event handler that fires when a drag/drop obj gets a mousedown
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnMouseDown(Action<JFunction> action)
            {
                action(this.ToComponent().OnMouseDown);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Event handler that fires when a drag/drop obj gets a mouseup
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder OnMouseUp(Action<JFunction> action)
            {
                action(this.ToComponent().OnMouseUp);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Event handler that fires when a drag/drop obj gets a mouseup
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder StartDrag(Action<JFunction> action)
            {
                action(this.ToComponent().StartDrag);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Code that executes immediately before the onDrag event
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder B4Drag(Action<JFunction> action)
            {
                action(this.ToComponent().B4Drag);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Code that executes immediately before the onDragDrop event
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder B4DragDrop(Action<JFunction> action)
            {
                action(this.ToComponent().B4DragDrop);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Code that executes immediately before the onDragOut event
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder B4DragOut(Action<JFunction> action)
            {
                action(this.ToComponent().B4DragOut);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Code that executes immediately before the onDragOver event
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder B4DragOver(Action<JFunction> action)
            {
                action(this.ToComponent().B4DragOver);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Code that executes immediately before the endDrag event
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder B4EndDrag(Action<JFunction> action)
            {
                action(this.ToComponent().B4EndDrag);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Code executed immediately before the onMouseDown event
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder B4MouseDown(Action<JFunction> action)
            {
                action(this.ToComponent().B4MouseDown);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Code that executes immediately before the startDrag event
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder B4StartDrag(Action<JFunction> action)
            {
                action(this.ToComponent().B4StartDrag);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}