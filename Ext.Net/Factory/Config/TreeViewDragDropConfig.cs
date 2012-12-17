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
    public partial class TreeViewDragDrop
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TreeViewDragDrop(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TreeViewDragDrop.Config Conversion to TreeViewDragDrop
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TreeViewDragDrop(TreeViewDragDrop.Config config)
        {
            return new TreeViewDragDrop(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit TreeViewDragDrop.Config Conversion to TreeViewDragDrop.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TreeViewDragDrop.Builder(TreeViewDragDrop.Config config)
			{
				return new TreeViewDragDrop.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string dragText = "{0} selected node{1}";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("{0} selected node{1}")]
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

			private bool allowParentInserts = false;

			/// <summary>
			/// Allow inserting a dragged node between an expanded parent node and its first child that will become a sibling of the parent when dropped.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowParentInserts 
			{ 
				get
				{
					return this.allowParentInserts;
				}
				set
				{
					this.allowParentInserts = value;
				}
			}

			private bool allowContainerDrops = false;

			/// <summary>
			/// True if drops on the tree container (outside of a specific tree node) are allowed.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowContainerDrops 
			{ 
				get
				{
					return this.allowContainerDrops;
				}
				set
				{
					this.allowContainerDrops = value;
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

			private string dDGroup = "TreeDD";

			/// <summary>
			/// A named drag drop group to which this object belongs. If a group is specified, then both the DragZones and DropZone used by this plugin will only interact with other drag drop objects in the same group. Defaults to: \"TreeDD\"
			/// </summary>
			[DefaultValue("TreeDD")]
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
			/// Set to false to disallow dragging items from the View. Defaults to: true
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
			/// Set to false to disallow the View from accepting drop gestures. Defaults to: true
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

			private bool appendOnly = false;

			/// <summary>
			/// True if the tree should only allow append drops (use for trees which are sorted). Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AppendOnly 
			{ 
				get
				{
					return this.appendOnly;
				}
				set
				{
					this.appendOnly = value;
				}
			}

			private int expandDelay = 1000;

			/// <summary>
			/// The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node over the target. Defaults to: 1000
			/// </summary>
			[DefaultValue(1000)]
			public virtual int ExpandDelay 
			{ 
				get
				{
					return this.expandDelay;
				}
				set
				{
					this.expandDelay = value;
				}
			}

			private string nodeHighlightColor = "c3daf9";

			/// <summary>
			/// The color to use when visually highlighting the dragged or dropped node (default value is light blue). The color must be a 6 digit hex value, without a preceding '#'. See also nodeHighlightOnDrop and nodeHighlightOnRepair. Defaults to: \"c3daf9\"
			/// </summary>
			[DefaultValue("c3daf9")]
			public virtual string NodeHighlightColor 
			{ 
				get
				{
					return this.nodeHighlightColor;
				}
				set
				{
					this.nodeHighlightColor = value;
				}
			}

			private bool nodeHighlightOnDrop = true;

			/// <summary>
			/// Whether or not to highlight any nodes after they are successfully dropped on their target. Defaults to the value of Ext.enableFx. See also nodeHighlightColor and nodeHighlightOnRepair.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool NodeHighlightOnDrop 
			{ 
				get
				{
					return this.nodeHighlightOnDrop;
				}
				set
				{
					this.nodeHighlightOnDrop = value;
				}
			}

			private bool nodeHighlightOnRepair = true;

			/// <summary>
			/// Whether or not to highlight any nodes after they are repaired from an unsuccessful drag/drop. Defaults to the value of Ext.enableFx. See also nodeHighlightColor and nodeHighlightOnDrop.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool NodeHighlightOnRepair 
			{ 
				get
				{
					return this.nodeHighlightOnRepair;
				}
				set
				{
					this.nodeHighlightOnRepair = value;
				}
			}

			private bool allowLeafDrop = false;

			/// <summary>
			/// true to allow append to the leaf node
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowLeafDrop 
			{ 
				get
				{
					return this.allowLeafDrop;
				}
				set
				{
					this.allowLeafDrop = value;
				}
			}

        }
    }
}