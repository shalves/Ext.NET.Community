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
 * @version   : 2.0.0.rc2 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class DropTarget
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DropTarget(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DropTarget.Config Conversion to DropTarget
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DropTarget(DropTarget.Config config)
        {
            return new DropTarget(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DDTarget.Config 
        { 
			/*  Implicit DropTarget.Config Conversion to DropTarget.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DropTarget.Builder(DropTarget.Config config)
			{
				return new DropTarget.Builder(config);
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

			private string overClass = "";

			/// <summary>
			/// The CSS class applied to the drop target element while the drag source is over it (defaults to \"\").
			/// </summary>
			[DefaultValue("")]
			public virtual string OverClass 
			{ 
				get
				{
					return this.overClass;
				}
				set
				{
					this.overClass = value;
				}
			}

			private bool containerScroll = false;

			/// <summary>
			/// True to register this container with the Scrollmanager for auto scrolling during drag operations.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ContainerScroll 
			{ 
				get
				{
					return this.containerScroll;
				}
				set
				{
					this.containerScroll = value;
				}
			}
        
			private JFunction notifyDrop = null;

			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the dragged item has been dropped on it. This method has no default implementation and returns false, so you must provide an implementation that does something to process the drop event and returns true so that the drag source's repair action does not run.
			/// </summary>
			public JFunction NotifyDrop
			{
				get
				{
					if (this.notifyDrop == null)
					{
						this.notifyDrop = new JFunction();
					}
			
					return this.notifyDrop;
				}
			}
			        
			private JFunction notifyEnter = null;

			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the source is now over the target. This default implementation adds the CSS class specified by overClass (if any) to the drop element and returns the dropAllowed config value. This method should be overridden if drop validation is required.
			/// </summary>
			public JFunction NotifyEnter
			{
				get
				{
					if (this.notifyEnter == null)
					{
						this.notifyEnter = new JFunction();
					}
			
					return this.notifyEnter;
				}
			}
			        
			private JFunction notifyOut = null;

			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the source has been dragged out of the target without dropping. This default implementation simply removes the CSS class specified by overClass (if any) from the drop element.
			/// </summary>
			public JFunction NotifyOut
			{
				get
				{
					if (this.notifyOut == null)
					{
						this.notifyOut = new JFunction();
					}
			
					return this.notifyOut;
				}
			}
			        
			private JFunction notifyOver = null;

			/// <summary>
			/// The function a Ext.dd.DragSource calls continuously while it is being dragged over the target. This method will be called on every mouse movement while the drag source is over the drop target. This default implementation simply returns the dropAllowed config value.
			/// </summary>
			public JFunction NotifyOver
			{
				get
				{
					if (this.notifyOver == null)
					{
						this.notifyOver = new JFunction();
					}
			
					return this.notifyOver;
				}
			}
			
        }
    }
}