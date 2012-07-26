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
 * @version   : 2.0.0 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class Resizer
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Resizer(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Resizer.Config Conversion to Resizer
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Resizer(Resizer.Config config)
        {
            return new Resizer(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit Resizer.Config Conversion to Resizer.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Resizer.Builder(Resizer.Config config)
			{
				return new Resizer.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string constrainToElement = "";

			/// <summary>
			/// An element, or a Region into which the resize operation must be constrained.
			/// </summary>
			[DefaultValue("")]
			public virtual string ConstrainToElement 
			{ 
				get
				{
					return this.constrainToElement;
				}
				set
				{
					this.constrainToElement = value;
				}
			}

			private System.Drawing.Rectangle? constrainToRegion = null;

			/// <summary>
			/// An element, or a Region into which the resize operation must be constrained.
			/// </summary>
			[DefaultValue(null)]
			public virtual System.Drawing.Rectangle? ConstrainToRegion 
			{ 
				get
				{
					return this.constrainToRegion;
				}
				set
				{
					this.constrainToRegion = value;
				}
			}

			private bool? dynamic = null;

			/// <summary>
			/// Specify as true to update the target (Element or Component) dynamically during dragging. This is true by default, but the Component class passes false when it is configured as Ext.Component.resizable.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Dynamic 
			{ 
				get
				{
					return this.dynamic;
				}
				set
				{
					this.dynamic = value;
				}
			}

			private ResizeHandle handles = ResizeHandle.Default;

			/// <summary>
			/// String consisting of the resize handles to display. Defaults to 's e se' for Elements and fixed position Components. Defaults to 8 point resizing for floating Components (such as Windows). Specify either 'all' or any of 'n s e w ne nw se sw'. Defaults to: \"s e se\"
			/// </summary>
			[DefaultValue(ResizeHandle.Default)]
			public virtual ResizeHandle Handles 
			{ 
				get
				{
					return this.handles;
				}
				set
				{
					this.handles = value;
				}
			}

			private string handlesSummary = "";

			/// <summary>
			/// String consisting of the resize handles to display (defaults to 's e se'). Specify either 'all' or any of 'n s e w ne nw se sw'.
			/// </summary>
			[DefaultValue("")]
			public virtual string HandlesSummary 
			{ 
				get
				{
					return this.handlesSummary;
				}
				set
				{
					this.handlesSummary = value;
				}
			}

			private Unit height = Unit.Empty;

			/// <summary>
			/// Optional. The height to set target to in pixels. Defaults to: null
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Height 
			{ 
				get
				{
					return this.height;
				}
				set
				{
					this.height = value;
				}
			}

			private int heightIncrement = 0;

			/// <summary>
			/// The increment to snap the height resize in pixels. Defaults to: 0
			/// </summary>
			[DefaultValue(0)]
			public virtual int HeightIncrement 
			{ 
				get
				{
					return this.heightIncrement;
				}
				set
				{
					this.heightIncrement = value;
				}
			}

			private int maxHeight = 10000;

			/// <summary>
			/// The maximum height for the element (defaults to 10000)
			/// </summary>
			[DefaultValue(10000)]
			public virtual int MaxHeight 
			{ 
				get
				{
					return this.maxHeight;
				}
				set
				{
					this.maxHeight = value;
				}
			}

			private int maxWidth = 10000;

			/// <summary>
			/// The maximum width for the element (defaults to 10000)
			/// </summary>
			[DefaultValue(10000)]
			public virtual int MaxWidth 
			{ 
				get
				{
					return this.maxWidth;
				}
				set
				{
					this.maxWidth = value;
				}
			}

			private int minHeight = 20;

			/// <summary>
			/// The minimum height for the element (defaults to 20)
			/// </summary>
			[DefaultValue(20)]
			public virtual int MinHeight 
			{ 
				get
				{
					return this.minHeight;
				}
				set
				{
					this.minHeight = value;
				}
			}

			private int minWidth = 20;

			/// <summary>
			/// The minimum width for the element (defaults to 20)
			/// </summary>
			[DefaultValue(20)]
			public virtual int MinWidth 
			{ 
				get
				{
					return this.minWidth;
				}
				set
				{
					this.minWidth = value;
				}
			}

			private bool pinned = false;

			/// <summary>
			/// True to ensure that the resize handles are always visible, false indicates resizing by cursor changes only. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Pinned 
			{ 
				get
				{
					return this.pinned;
				}
				set
				{
					this.pinned = value;
				}
			}

			private bool preserveRatio = false;

			/// <summary>
			/// True to preserve the original ratio between height and width during resize (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreserveRatio 
			{ 
				get
				{
					return this.preserveRatio;
				}
				set
				{
					this.preserveRatio = value;
				}
			}

			private string target = "";

			/// <summary>
			/// The Element or Component to resize.
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

			private bool transparent = false;

			/// <summary>
			/// True for transparent handles. This is only applied at config time. (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Transparent 
			{ 
				get
				{
					return this.transparent;
				}
				set
				{
					this.transparent = value;
				}
			}

			private Unit width = Unit.Empty;

			/// <summary>
			/// Optional. The width to set the target to in pixels. Defaults to: null
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private int widthIncrement = 0;

			/// <summary>
			/// The increment to snap the width resize in pixels (defaults to 0)
			/// </summary>
			[DefaultValue(0)]
			public virtual int WidthIncrement 
			{ 
				get
				{
					return this.widthIncrement;
				}
				set
				{
					this.widthIncrement = value;
				}
			}
        
			private ResizableListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ResizableListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ResizableListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ResizableDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ResizableDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ResizableDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}