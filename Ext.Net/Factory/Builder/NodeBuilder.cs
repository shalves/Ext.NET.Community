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
    public partial class Node
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<Node, Node.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Node()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Node component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Node.Config config) : base(new Node(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Node component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The id for this node. If one is not specified, one is generated.
			/// </summary>
            public virtual Node.Builder NodeID(string nodeID)
            {
                this.ToComponent().NodeID = nodeID;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Set to true to indicate that this child can have no children. The expand icon/arrow will then not be rendered for this node. Defaults to: false
			/// </summary>
            public virtual Node.Builder Leaf(bool leaf)
            {
                this.ToComponent().Leaf = leaf;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// False to make this node undraggable if draggable = true (defaults to true)
			/// </summary>
            public virtual Node.Builder AllowDrag(bool allowDrag)
            {
                this.ToComponent().AllowDrag = allowDrag;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// False if this node cannot have child nodes dropped on it (defaults to true)
			/// </summary>
            public virtual Node.Builder AllowDrop(bool allowDrop)
            {
                this.ToComponent().AllowDrop = allowDrop;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)
			/// </summary>
            public virtual Node.Builder Checked(bool? _checked)
            {
                this.ToComponent().Checked = _checked;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// A css class to be added to the node.
			/// </summary>
            public virtual Node.Builder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Set to true to allow for expanding/collapsing of this node (the node will always show a plus/minus icon, even when empty). Defaults to: false
			/// </summary>
            public virtual Node.Builder Expandable(bool expandable)
            {
                this.ToComponent().Expandable = expandable;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// True to start the node expanded
			/// </summary>
            public virtual Node.Builder Expanded(bool expanded)
            {
                this.ToComponent().Expanded = expanded;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// True to render empty children array
			/// </summary>
            public virtual Node.Builder EmptyChildren(bool emptyChildren)
            {
                this.ToComponent().EmptyChildren = emptyChildren;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// URL of the link used for the node (defaults to #)
			/// </summary>
            public virtual Node.Builder Href(string href)
            {
                this.ToComponent().Href = href;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Target for link. Only applicable when href also specified.
			/// </summary>
            public virtual Node.Builder HrefTarget(string hrefTarget)
            {
                this.ToComponent().HrefTarget = hrefTarget;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.
			/// </summary>
            public virtual Node.Builder IconFile(string iconFile)
            {
                this.ToComponent().IconFile = iconFile;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual Node.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// A css class to be added to the nodes icon element for applying css background images
			/// </summary>
            public virtual Node.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Tooltip text to show on this node.
			/// </summary>
            public virtual Node.Builder Qtip(string qtip)
            {
                this.ToComponent().Qtip = qtip;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Tooltip title.
			/// </summary>
            public virtual Node.Builder Qtitle(string qtitle)
            {
                this.ToComponent().Qtitle = qtitle;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// The text for to show on node label.
			/// </summary>
            public virtual Node.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Array of child nodes.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Node.Builder</returns>
            public virtual Node.Builder Children(Action<NodeCollection> action)
            {
                action(this.ToComponent().Children);
                return this as Node.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual Node.Builder DataPath(string dataPath)
            {
                this.ToComponent().DataPath = dataPath;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Collection of custom node attributes
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Node.Builder</returns>
            public virtual Node.Builder CustomAttributes(Action<ConfigItemCollection> action)
            {
                action(this.ToComponent().CustomAttributes);
                return this as Node.Builder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual Node.Builder AttributesObject(object attributesObject)
            {
                this.ToComponent().AttributesObject = attributesObject;
                return this as Node.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Node.Builder</returns>
            public virtual Node.Builder Listeners(Action<TreeStoreListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as Node.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Node.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Node(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Node.Builder Node()
        {
            return this.Node(new Node());
        }

        /// <summary>
        /// 
        /// </summary>
        public Node.Builder Node(Node component)
        {
            return new Node.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Node.Builder Node(Node.Config config)
        {
            return new Node.Builder(new Node(config));
        }
    }
}