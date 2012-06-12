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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public partial class DragSource
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : DDProxy.Builder<DragSource, DragSource.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DragSource()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DragSource component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DragSource.Config config) : base(new DragSource(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DragSource component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).
			/// </summary>
            public virtual DragSource.Builder Group(string group)
            {
                this.ToComponent().Group = group;
                return this as DragSource.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DragSource.Builder DragData(object dragData)
            {
                this.ToComponent().DragData = dragData;
                return this as DragSource.Builder;
            }
             
 			/// <summary>
			/// If true, animates the proxy element back to the position of the handle element used to trigger the drag. Defaults to: true
			/// </summary>
            public virtual DragSource.Builder AnimRepair(bool animRepair)
            {
                this.ToComponent().AnimRepair = animRepair;
                return this as DragSource.Builder;
            }
             
 			/// <summary>
			/// The CSS class returned to the drag source when drop is allowed (defaults to \"x-dd-drop-ok\").
			/// </summary>
            public virtual DragSource.Builder DropAllowed(string dropAllowed)
            {
                this.ToComponent().DropAllowed = dropAllowed;
                return this as DragSource.Builder;
            }
             
 			/// <summary>
			/// The CSS class returned to the drag source when drop is not allowed (defaults to \"x-dd-drop-nodrop\").
			/// </summary>
            public virtual DragSource.Builder DropNotAllowed(string dropNotAllowed)
            {
                this.ToComponent().DropNotAllowed = dropNotAllowed;
                return this as DragSource.Builder;
            }
             
 			/// <summary>
			/// The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to light blue). The color must be a 6 digit hex value, without a preceding '#'. Defaults to: \"c3daf9\"
			/// </summary>
            public virtual DragSource.Builder RepairHighlightColor(string repairHighlightColor)
            {
                this.ToComponent().RepairHighlightColor = repairHighlightColor;
                return this as DragSource.Builder;
            }
             
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after a valid drag drop has occurred by providing an implementation.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder AfterDragDrop(Action<JFunction> action)
            {
                action(this.ToComponent().AfterDragDrop);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action when the dragged item enters the drop target by providing an implementation.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder AfterDragEnter(Action<JFunction> action)
            {
                action(this.ToComponent().AfterDragEnter);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after the dragged item is dragged out of the target without dropping.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder AfterDragOut(Action<JFunction> action)
            {
                action(this.ToComponent().AfterDragOut);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action while the dragged item is over the drop target by providing an implementation.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder AfterDragOver(Action<JFunction> action)
            {
                action(this.ToComponent().AfterDragOver);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after an invalid drop has occurred by providing an implementation.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder AfterInvalidDrop(Action<JFunction> action)
            {
                action(this.ToComponent().AfterInvalidDrop);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after an invalid drop has occurred by providing an implementation.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder AfterValidDrop(Action<JFunction> action)
            {
                action(this.ToComponent().AfterValidDrop);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the dragged item is dropped onto the target and optionally cancel the onDragDrop.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder BeforeDragDrop(Action<JFunction> action)
            {
                action(this.ToComponent().BeforeDragDrop);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the dragged item enters the drop target and optionally cancel the onDragEnter.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder BeforeDragEnter(Action<JFunction> action)
            {
                action(this.ToComponent().BeforeDragEnter);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the dragged item is dragged out of the target without dropping, and optionally cancel the onDragOut.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder BeforeDragOut(Action<JFunction> action)
            {
                action(this.ToComponent().BeforeDragOut);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action while the dragged item is over the drop target and optionally cancel the onDragOver.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder BeforeDragOver(Action<JFunction> action)
            {
                action(this.ToComponent().BeforeDragOver);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after an invalid drop has occurred.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder BeforeInvalidDrop(Action<JFunction> action)
            {
                action(this.ToComponent().BeforeInvalidDrop);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the initial drag event begins and optionally cancel it.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder OnBeforeDrag(Action<JFunction> action)
            {
                action(this.ToComponent().OnBeforeDrag);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action once the initial drag event has begun. The drag cannot be canceled from this function.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder OnStartDrag(Action<JFunction> action)
            {
                action(this.ToComponent().OnStartDrag);
                return this as DragSource.Builder;
            }
			 
 			/// <summary>
			/// Returns the data object associated with this drag source.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DragSource.Builder</returns>
            public virtual DragSource.Builder GetDragData(Action<JFunction> action)
            {
                action(this.ToComponent().GetDragData);
                return this as DragSource.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DragSource.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DragSource(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DragSource.Builder DragSource()
        {
            return this.DragSource(new DragSource());
        }

        /// <summary>
        /// 
        /// </summary>
        public DragSource.Builder DragSource(DragSource component)
        {
            return new DragSource.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DragSource.Builder DragSource(DragSource.Config config)
        {
            return new DragSource.Builder(new DragSource(config));
        }
    }
}