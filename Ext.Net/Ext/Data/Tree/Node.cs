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

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class Node : BaseItem, IIcon
    {
        /// <summary>
        /// 
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// The id for this node. If one is not specified, one is generated.
        /// </summary>
        [Meta]
        [ConfigOption("id")]        
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The id for this node. If one is not specified, one is generated.")]
        public virtual string NodeID
        {
            get
            {
                return this.State.Get<string>("NodeID", "");
            }
            set
            {
                this.State.Set("NodeID", value);
            }
        }

        /// <summary>
        /// Set to true to indicate that this child can have no children. The expand icon/arrow will then not be rendered for this node. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]        
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Set to true to indicate that this child can have no children. The expand icon/arrow will then not be rendered for this node. Defaults to: false")]
        public virtual bool Leaf
        {
            get
            {
                return this.State.Get<bool>("Leaf", false);
            }
            set
            {
                this.State.Set("Leaf", value);
            }
        }

        /// <summary>
        /// False to make this node undraggable if draggable = true (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to make this node undraggable if draggable = true (defaults to true)")]
        public virtual bool AllowDrag
        {
            get
            {
                return this.State.Get<bool>("AllowDrag", true);
            }
            set
            {
                this.State.Set("AllowDrag", value);
            }
        }

        /// <summary>
        /// False if this node cannot have child nodes dropped on it (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False if this node cannot have child nodes dropped on it (defaults to true)")]
        public virtual bool AllowDrop
        {
            get
            {
                return this.State.Get<bool>("AllowDrop", true);
            }
            set
            {
                this.State.Set("AllowDrop", value);
            }
        }

        /// <summary>
        /// True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)")]
        public virtual bool? Checked
        {
            get
            {
                return this.State.Get<bool?>("Checked", null);
            }
            set
            {
                this.State.Set("Checked", value);
            }
        }

        /// <summary>
        /// A css class to be added to the node.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class to be added to the node.")]
        public virtual string Cls
        {
            get
            {
                return this.State.Get<string>("Cls", "");
            }
            set
            {
                this.State.Set("Cls", value);
            }
        }

        /// <summary>
        /// Set to true to allow for expanding/collapsing of this node (the node will always show a plus/minus icon, even when empty). Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Set to true to allow for expanding/collapsing of this node (the node will always show a plus/minus icon, even when empty). Defaults to: false")]
        public virtual bool Expandable
        {
            get
            {
                return this.State.Get<bool>("Expandable", false);
            }
            set
            {
                this.State.Set("Expandable", value);
            }
        }

        /// <summary>
        /// True to start the node expanded
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to start the node expanded")]
        public virtual bool Expanded
        {
            get
            {
                return this.State.Get<bool>("Expanded", false);
            }
            set
            {
                this.State.Set("Expanded", value);
            }
        }

        /// <summary>
        /// True to render empty children array
        /// </summary>
        [Meta]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to render empty children array")]
        public virtual bool EmptyChildren
        {
            get
            {
                return this.State.Get<bool>("EmptyChildren", false);
            }
            set
            {
                this.State.Set("EmptyChildren", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("children", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string EmptyChildrenProxy
        {
            get
            {
                return this.EmptyChildren ? "[]" : "";
            }
        }

        /// <summary>
        /// URL of the link used for the node (defaults to #)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("#")]
        [NotifyParentProperty(true)]
        [Description("URL of the link used for the node (defaults to #)")]
        public virtual string Href
        {
            get
            {
                return this.State.Get<string>("Href", "#");
            }
            set
            {
                this.State.Set("Href", value);
            }
        }

        /// <summary>
        /// Target for link. Only applicable when href also specified.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Target for link. Only applicable when href also specified.")]
        public virtual string HrefTarget
        {
            get
            {
                return this.State.Get<string>("HrefTarget", "");
            }
            set
            {
                this.State.Set("HrefTarget", value);
            }
        }

        /// <summary>
        /// The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.
        /// </summary>
        [Meta]
        [ConfigOption("icon")]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.")]
        public virtual string IconFile
        {
            get
            {
                return this.State.Get<string>("IconFile", "");
            }
            set
            {
                this.State.Set("IconFile", value);
            }
        }

        /// <summary>
        /// The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("3. TreeNode")]
        [DefaultValue(Icon.None)]
        [NotifyParentProperty(true)]
        [Description("The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return ResourceManager.GetIconRequester(this.Icon);
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class to be added to the nodes icon element for applying css background images
        /// </summary>
        [Meta]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class to be added to the nodes icon element for applying css background images")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// Tooltip text to show on this node.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Tooltip text to show on this node.")]
        public virtual string Qtip
        {
            get
            {
                return this.State.Get<string>("Qtip", "");
            }
            set
            {
                this.State.Set("Qtip", value);
            }
        }

        /// <summary>
        /// Tooltip title.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Tooltip title.")]
        public virtual string Qtitle
        {
            get
            {
                return this.State.Get<string>("Qtitle", "");
            }
            set
            {
                this.State.Set("Qtitle", value);
            }
        }

        /// <summary>
        /// The text for to show on node label.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The text for to show on node label.")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);
                return icons;
            }
        }

        private NodeCollection children;

        /// <summary>
        /// Array of child nodes.
        /// </summary>
        [Meta]
        [Category("3. TreeNode")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Array of child nodes.")]
        [ConfigOption(JsonMode.AlwaysArray)]
        public virtual NodeCollection Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = new NodeCollection(false);
                    this.children.AfterItemAdd += Nodes_AfterItemAdd;
                }

                return this.children;
            }
        }

        void Nodes_AfterItemAdd(Node item)
        {
            item.ParentNode = this;
        }

         private Node parentNode;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Node ParentNode
        {
            get 
            { 
                return this.parentNode; 
            }
            protected internal set 
            {
                this.parentNode = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual int Depth
        {
            get
            {
                int depth = 0;
                Node node = this;

                while (node.ParentNode != null)
                {
                    depth++;
                    node = node.ParentNode;
                }

                return depth;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [ConfigOption]
        public virtual string DataPath
        {
            get
            {
                return this.State.Get<string>("DataPath", "");
            }
            set
            {
                this.State.Set("DataPath", value);
            }
        }

        private ConfigItemCollection customAttributes;

        /// <summary>
        /// Collection of custom node attributes
        /// </summary>
        [Meta]
        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom node attributes")]
        public virtual ConfigItemCollection CustomAttributes
        {
            get
            {
                if (this.customAttributes == null)
                {
                    this.customAttributes = new ConfigItemCollection();
                    this.customAttributes.CamelName = false;
                }

                return this.customAttributes;
            }
        }

        private object attributesObject;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.UnrollObject)]
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        private TreeStoreListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public string ToScript()
        {
            return this.ToScript(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configOnly"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(bool configOnly)
        {
            return new ClientConfig().Serialize(this);
            //if (configOnly)
            //{
            //    return new ClientConfig().Serialize(this);
            //}
            //else
            //{
                

            //    return script;
            //}
        }
    }
}
