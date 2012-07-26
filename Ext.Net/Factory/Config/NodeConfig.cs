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
    public partial class Node
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Node(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Node.Config Conversion to Node
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Node(Node.Config config)
        {
            return new Node(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit Node.Config Conversion to Node.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Node.Builder(Node.Config config)
			{
				return new Node.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string nodeID = "";

			/// <summary>
			/// The id for this node. If one is not specified, one is generated.
			/// </summary>
			[DefaultValue("")]
			public virtual string NodeID 
			{ 
				get
				{
					return this.nodeID;
				}
				set
				{
					this.nodeID = value;
				}
			}

			private bool leaf = false;

			/// <summary>
			/// Set to true to indicate that this child can have no children. The expand icon/arrow will then not be rendered for this node. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Leaf 
			{ 
				get
				{
					return this.leaf;
				}
				set
				{
					this.leaf = value;
				}
			}

			private bool allowDrag = true;

			/// <summary>
			/// False to make this node undraggable if draggable = true (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowDrag 
			{ 
				get
				{
					return this.allowDrag;
				}
				set
				{
					this.allowDrag = value;
				}
			}

			private bool allowDrop = true;

			/// <summary>
			/// False if this node cannot have child nodes dropped on it (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowDrop 
			{ 
				get
				{
					return this.allowDrop;
				}
				set
				{
					this.allowDrop = value;
				}
			}

			private bool? _checked = null;

			/// <summary>
			/// True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Checked 
			{ 
				get
				{
					return this._checked;
				}
				set
				{
					this._checked = value;
				}
			}

			private string cls = "";

			/// <summary>
			/// A css class to be added to the node.
			/// </summary>
			[DefaultValue("")]
			public virtual string Cls 
			{ 
				get
				{
					return this.cls;
				}
				set
				{
					this.cls = value;
				}
			}

			private bool expandable = false;

			/// <summary>
			/// Set to true to allow for expanding/collapsing of this node (the node will always show a plus/minus icon, even when empty). Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Expandable 
			{ 
				get
				{
					return this.expandable;
				}
				set
				{
					this.expandable = value;
				}
			}

			private bool expanded = false;

			/// <summary>
			/// True to start the node expanded
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Expanded 
			{ 
				get
				{
					return this.expanded;
				}
				set
				{
					this.expanded = value;
				}
			}

			private bool emptyChildren = false;

			/// <summary>
			/// True to render empty children array
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EmptyChildren 
			{ 
				get
				{
					return this.emptyChildren;
				}
				set
				{
					this.emptyChildren = value;
				}
			}

			private string href = "#";

			/// <summary>
			/// URL of the link used for the node (defaults to #)
			/// </summary>
			[DefaultValue("#")]
			public virtual string Href 
			{ 
				get
				{
					return this.href;
				}
				set
				{
					this.href = value;
				}
			}

			private string hrefTarget = "";

			/// <summary>
			/// Target for link. Only applicable when href also specified.
			/// </summary>
			[DefaultValue("")]
			public virtual string HrefTarget 
			{ 
				get
				{
					return this.hrefTarget;
				}
				set
				{
					this.hrefTarget = value;
				}
			}

			private string iconFile = "";

			/// <summary>
			/// The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconFile 
			{ 
				get
				{
					return this.iconFile;
				}
				set
				{
					this.iconFile = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A css class to be added to the nodes icon element for applying css background images
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private string qtip = "";

			/// <summary>
			/// Tooltip text to show on this node.
			/// </summary>
			[DefaultValue("")]
			public virtual string Qtip 
			{ 
				get
				{
					return this.qtip;
				}
				set
				{
					this.qtip = value;
				}
			}

			private string qtitle = "";

			/// <summary>
			/// Tooltip title.
			/// </summary>
			[DefaultValue("")]
			public virtual string Qtitle 
			{ 
				get
				{
					return this.qtitle;
				}
				set
				{
					this.qtitle = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The text for to show on node label.
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}
        
			private NodeCollection children = null;

			/// <summary>
			/// Array of child nodes.
			/// </summary>
			public NodeCollection Children
			{
				get
				{
					if (this.children == null)
					{
						this.children = new NodeCollection();
					}
			
					return this.children;
				}
			}
			
			private string dataPath = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DataPath 
			{ 
				get
				{
					return this.dataPath;
				}
				set
				{
					this.dataPath = value;
				}
			}
        
			private ConfigItemCollection customAttributes = null;

			/// <summary>
			/// Collection of custom node attributes
			/// </summary>
			public ConfigItemCollection CustomAttributes
			{
				get
				{
					if (this.customAttributes == null)
					{
						this.customAttributes = new ConfigItemCollection();
					}
			
					return this.customAttributes;
				}
			}
			
			private object attributesObject = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual object AttributesObject 
			{ 
				get
				{
					return this.attributesObject;
				}
				set
				{
					this.attributesObject = value;
				}
			}
        
			private TreeStoreListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public TreeStoreListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new TreeStoreListeners();
					}
			
					return this.listeners;
				}
			}
			
        }
    }
}