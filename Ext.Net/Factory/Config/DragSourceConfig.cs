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
    public partial class DragSource
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DragSource(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DragSource.Config Conversion to DragSource
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DragSource(DragSource.Config config)
        {
            return new DragSource(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DDProxy.Config 
        { 
			/*  Implicit DragSource.Config Conversion to DragSource.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DragSource.Builder(DragSource.Config config)
			{
				return new DragSource.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string group = "";

			/// <summary>
			/// A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public override string Group 
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

			private object dragData = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual object DragData 
			{ 
				get
				{
					return this.dragData;
				}
				set
				{
					this.dragData = value;
				}
			}

			private bool animRepair = true;

			/// <summary>
			/// If true, animates the proxy element back to the position of the handle element used to trigger the drag. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AnimRepair 
			{ 
				get
				{
					return this.animRepair;
				}
				set
				{
					this.animRepair = value;
				}
			}

			private string dropAllowed = "x-dd-drop-ok";

			/// <summary>
			/// The CSS class returned to the drag source when drop is allowed (defaults to \"x-dd-drop-ok\").
			/// </summary>
			[DefaultValue("x-dd-drop-ok")]
			public virtual string DropAllowed 
			{ 
				get
				{
					return this.dropAllowed;
				}
				set
				{
					this.dropAllowed = value;
				}
			}

			private string dropNotAllowed = "x-dd-drop-nodrop";

			/// <summary>
			/// The CSS class returned to the drag source when drop is not allowed (defaults to \"x-dd-drop-nodrop\").
			/// </summary>
			[DefaultValue("x-dd-drop-nodrop")]
			public virtual string DropNotAllowed 
			{ 
				get
				{
					return this.dropNotAllowed;
				}
				set
				{
					this.dropNotAllowed = value;
				}
			}

			private string repairHighlightColor = "c3daf9";

			/// <summary>
			/// The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to light blue). The color must be a 6 digit hex value, without a preceding '#'. Defaults to: \"c3daf9\"
			/// </summary>
			[DefaultValue("c3daf9")]
			public virtual string RepairHighlightColor 
			{ 
				get
				{
					return this.repairHighlightColor;
				}
				set
				{
					this.repairHighlightColor = value;
				}
			}
        
			private JFunction afterDragDrop = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after a valid drag drop has occurred by providing an implementation.
			/// </summary>
			public JFunction AfterDragDrop
			{
				get
				{
					if (this.afterDragDrop == null)
					{
						this.afterDragDrop = new JFunction();
					}
			
					return this.afterDragDrop;
				}
			}
			        
			private JFunction afterDragEnter = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action when the dragged item enters the drop target by providing an implementation.
			/// </summary>
			public JFunction AfterDragEnter
			{
				get
				{
					if (this.afterDragEnter == null)
					{
						this.afterDragEnter = new JFunction();
					}
			
					return this.afterDragEnter;
				}
			}
			        
			private JFunction afterDragOut = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after the dragged item is dragged out of the target without dropping.
			/// </summary>
			public JFunction AfterDragOut
			{
				get
				{
					if (this.afterDragOut == null)
					{
						this.afterDragOut = new JFunction();
					}
			
					return this.afterDragOut;
				}
			}
			        
			private JFunction afterDragOver = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action while the dragged item is over the drop target by providing an implementation.
			/// </summary>
			public JFunction AfterDragOver
			{
				get
				{
					if (this.afterDragOver == null)
					{
						this.afterDragOver = new JFunction();
					}
			
					return this.afterDragOver;
				}
			}
			        
			private JFunction afterInvalidDrop = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after an invalid drop has occurred by providing an implementation.
			/// </summary>
			public JFunction AfterInvalidDrop
			{
				get
				{
					if (this.afterInvalidDrop == null)
					{
						this.afterInvalidDrop = new JFunction();
					}
			
					return this.afterInvalidDrop;
				}
			}
			        
			private JFunction afterValidDrop = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after an invalid drop has occurred by providing an implementation.
			/// </summary>
			public JFunction AfterValidDrop
			{
				get
				{
					if (this.afterValidDrop == null)
					{
						this.afterValidDrop = new JFunction();
					}
			
					return this.afterValidDrop;
				}
			}
			        
			private JFunction beforeDragDrop = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the dragged item is dropped onto the target and optionally cancel the onDragDrop.
			/// </summary>
			public JFunction BeforeDragDrop
			{
				get
				{
					if (this.beforeDragDrop == null)
					{
						this.beforeDragDrop = new JFunction();
					}
			
					return this.beforeDragDrop;
				}
			}
			        
			private JFunction beforeDragEnter = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the dragged item enters the drop target and optionally cancel the onDragEnter.
			/// </summary>
			public JFunction BeforeDragEnter
			{
				get
				{
					if (this.beforeDragEnter == null)
					{
						this.beforeDragEnter = new JFunction();
					}
			
					return this.beforeDragEnter;
				}
			}
			        
			private JFunction beforeDragOut = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the dragged item is dragged out of the target without dropping, and optionally cancel the onDragOut.
			/// </summary>
			public JFunction BeforeDragOut
			{
				get
				{
					if (this.beforeDragOut == null)
					{
						this.beforeDragOut = new JFunction();
					}
			
					return this.beforeDragOut;
				}
			}
			        
			private JFunction beforeDragOver = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action while the dragged item is over the drop target and optionally cancel the onDragOver.
			/// </summary>
			public JFunction BeforeDragOver
			{
				get
				{
					if (this.beforeDragOver == null)
					{
						this.beforeDragOver = new JFunction();
					}
			
					return this.beforeDragOver;
				}
			}
			        
			private JFunction beforeInvalidDrop = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action after an invalid drop has occurred.
			/// </summary>
			public JFunction BeforeInvalidDrop
			{
				get
				{
					if (this.beforeInvalidDrop == null)
					{
						this.beforeInvalidDrop = new JFunction();
					}
			
					return this.beforeInvalidDrop;
				}
			}
			        
			private JFunction onBeforeDrag = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action before the initial drag event begins and optionally cancel it.
			/// </summary>
			public JFunction OnBeforeDrag
			{
				get
				{
					if (this.onBeforeDrag == null)
					{
						this.onBeforeDrag = new JFunction();
					}
			
					return this.onBeforeDrag;
				}
			}
			        
			private JFunction onStartDrag = null;

			/// <summary>
			/// An empty function by default, but provided so that you can perform a custom action once the initial drag event has begun. The drag cannot be canceled from this function.
			/// </summary>
			public JFunction OnStartDrag
			{
				get
				{
					if (this.onStartDrag == null)
					{
						this.onStartDrag = new JFunction();
					}
			
					return this.onStartDrag;
				}
			}
			        
			private JFunction getDragData = null;

			/// <summary>
			/// Returns the data object associated with this drag source.
			/// </summary>
			public JFunction GetDragData
			{
				get
				{
					if (this.getDragData == null)
					{
						this.getDragData = new JFunction();
					}
			
					return this.getDragData;
				}
			}
			
        }
    }
}