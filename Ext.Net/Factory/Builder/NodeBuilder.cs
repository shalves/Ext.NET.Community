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
 * @version   : 2.1.0 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
        new public abstract partial class Builder<TNode, TBuilder> : BaseItem.Builder<TNode, TBuilder>
            where TNode : Node
            where TBuilder : Builder<TNode, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TNode component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The id for this node. If one is not specified, one is generated.
			/// </summary>
            public virtual TBuilder NodeID(string nodeID)
            {
                this.ToComponent().NodeID = nodeID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to indicate that this child can have no children. The expand icon/arrow will then not be rendered for this node. Defaults to: false
			/// </summary>
            public virtual TBuilder Leaf(bool leaf)
            {
                this.ToComponent().Leaf = leaf;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to make this node undraggable if draggable = true (defaults to true)
			/// </summary>
            public virtual TBuilder AllowDrag(bool allowDrag)
            {
                this.ToComponent().AllowDrag = allowDrag;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False if this node cannot have child nodes dropped on it (defaults to true)
			/// </summary>
            public virtual TBuilder AllowDrop(bool allowDrop)
            {
                this.ToComponent().AllowDrop = allowDrop;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)
			/// </summary>
            public virtual TBuilder Checked(bool? _checked)
            {
                this.ToComponent().Checked = _checked;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class to be added to the node.
			/// </summary>
            public virtual TBuilder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to allow for expanding/collapsing of this node (the node will always show a plus/minus icon, even when empty). Defaults to: false
			/// </summary>
            public virtual TBuilder Expandable(bool expandable)
            {
                this.ToComponent().Expandable = expandable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to start the node expanded
			/// </summary>
            public virtual TBuilder Expanded(bool expanded)
            {
                this.ToComponent().Expanded = expanded;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render empty children array
			/// </summary>
            public virtual TBuilder EmptyChildren(bool emptyChildren)
            {
                this.ToComponent().EmptyChildren = emptyChildren;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// URL of the link used for the node (defaults to #)
			/// </summary>
            public virtual TBuilder Href(string href)
            {
                this.ToComponent().Href = href;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Target for link. Only applicable when href also specified.
			/// </summary>
            public virtual TBuilder HrefTarget(string hrefTarget)
            {
                this.ToComponent().HrefTarget = hrefTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.
			/// </summary>
            public virtual TBuilder IconFile(string iconFile)
            {
                this.ToComponent().IconFile = iconFile;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class to be added to the nodes icon element for applying css background images
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Tooltip text to show on this node.
			/// </summary>
            public virtual TBuilder Qtip(string qtip)
            {
                this.ToComponent().Qtip = qtip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Tooltip title.
			/// </summary>
            public virtual TBuilder Qtitle(string qtitle)
            {
                this.ToComponent().Qtitle = qtitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text for to show on node label.
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Array of child nodes.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Children(Action<NodeCollection> action)
            {
                action(this.ToComponent().Children);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DataPath(string dataPath)
            {
                this.ToComponent().DataPath = dataPath;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Collection of custom node attributes
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder CustomAttributes(Action<ConfigItemCollection> action)
            {
                action(this.ToComponent().CustomAttributes);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AttributesObject(object attributesObject)
            {
                this.ToComponent().AttributesObject = attributesObject;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<TreeStoreListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Node.Builder<Node, Node.Builder>
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
        }

        /// <summary>
        /// 
        /// </summary>
        public Node.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Node(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
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
#if MVC
			return this.Node(new Node { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Node(new Node());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Node.Builder Node(Node component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Node.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Node.Builder Node(Node.Config config)
        {
#if MVC
			return new Node.Builder(new Node(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Node.Builder(new Node(config));
#endif			
        }
    }
}