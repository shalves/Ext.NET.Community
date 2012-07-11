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
    public partial class GridDragDrop
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GridDragDrop(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GridDragDrop.Config Conversion to GridDragDrop
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GridDragDrop(GridDragDrop.Config config)
        {
            return new GridDragDrop(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit GridDragDrop.Config Conversion to GridDragDrop.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GridDragDrop.Builder(GridDragDrop.Config config)
			{
				return new GridDragDrop.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string dDGroup = "GridDD";

			/// <summary>
			/// A named drag drop group to which this object belongs. If a group is specified, then both the DragZones and DropZone used by this plugin will only interact with other drag drop objects in the same group (defaults to 'GridDD').
			/// </summary>
			[DefaultValue("GridDD")]
			public virtual string DDGroup 
			{ 
				get
				{
					return this.dDGroup;
				}
				set
				{
					this.dDGroup = value;
				}
			}

			private string dragText = "{0} selected row{1}";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("{0} selected row{1}")]
			public virtual string DragText 
			{ 
				get
				{
					return this.dragText;
				}
				set
				{
					this.dragText = value;
				}
			}

			private string dragGroup = "";

			/// <summary>
			/// The ddGroup to which the DragZone will belong. This defines which other DropZones the DragZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.
			/// </summary>
			[DefaultValue("")]
			public virtual string DragGroup 
			{ 
				get
				{
					return this.dragGroup;
				}
				set
				{
					this.dragGroup = value;
				}
			}

			private string dropGroup = "";

			/// <summary>
			/// The ddGroup to which the DropZone will belong. This defines which other DragZones the DropZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.
			/// </summary>
			[DefaultValue("")]
			public virtual string DropGroup 
			{ 
				get
				{
					return this.dropGroup;
				}
				set
				{
					this.dropGroup = value;
				}
			}

			private bool enableDrag = true;

			/// <summary>
			/// Defaults to true. Set to false to disallow dragging items from the View
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableDrag 
			{ 
				get
				{
					return this.enableDrag;
				}
				set
				{
					this.enableDrag = value;
				}
			}

			private bool enableDrop = true;

			/// <summary>
			/// Defaults to true. Set to false to disallow the View from accepting drop gestures
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableDrop 
			{ 
				get
				{
					return this.enableDrop;
				}
				set
				{
					this.enableDrop = value;
				}
			}

        }
    }
}