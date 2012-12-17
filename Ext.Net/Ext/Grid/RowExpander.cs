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
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("")]
    public partial class RowExpander : Plugin
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public RowExpander() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.RowExpander";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ptype")]
        [DefaultValue("")]
        [Description("")]
        public override string PType
        {
            get
            {
                return "rowexpander";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override System.Type RequiredOwnerType
        {
            get
            {
                return typeof(GridPanelBase);
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.Component.Count > 0 && this.SingleExpand.HasValue && !this.SingleExpand.Value)
            {
                this.Component[0].IDMode = Ext.Net.IDMode.Ignore;
            }

            base.OnBeforeClientInit(sender);
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxyId")]
        [Description("")]
        protected override string ConfigIDProxy
        {
            get { return base.ConfigIDProxy; }
        }

        private ComponentLoader loader;

        /// <summary>
        /// A configuration object or an instance of a Ext.ComponentLoader to load remote content.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [ConfigOption("loader", typeof(FunctionLazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A configuration object or an instance of a Ext.ComponentLoader to load remote content.")]
        public virtual ComponentLoader Loader
        {
            get
            {
                return this.loader;
            }
            set
            {
                if (this.loader != null && this.PluginOwner != null)
                {
                    this.PluginOwner.Controls.Remove(this.loader);
                    this.PluginOwner.LazyItems.Remove(this.loader);
                }

                this.loader = value;

                if (this.loader != null && this.PluginOwner != null)
                {
                    this.loader.EnableViewState = this.DesignMode;
                    this.PluginOwner.Controls.Add(this.loader);
                    this.PluginOwner.LazyItems.Add(this.loader);
                }
            }
        }

        private XTemplate template;

        /// <summary>
        /// The template string to use to display each item in the dropdown list.
        /// </summary>
        [Meta]
        [Category("3. RowExpander")]
        [ConfigOption("rowBodyTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The template string to use to display each item in the dropdown list.")]
        public virtual XTemplate Template
        {
            get
            {
                if (this.template == null)
                {
                    this.template = new XTemplate();
                }

                return this.template;
            }
        }

        ItemsCollection<AbstractComponent> component;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("component", typeof(FunctionItemCollectionJsonConverter))]
        [Description("")]
        public virtual ItemsCollection<AbstractComponent> Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new ItemsCollection<AbstractComponent>();
                    this.component.SingleItemMode = true;
                    this.Component.AfterItemAdd += Component_AfterItemAdd;
                }

                return this.component;
            }
        }

        void Component_AfterItemAdd(AbstractComponent item)
        {
            if (this.PluginOwner != null)
            {                
                this.PluginOwner.Controls.Add(item);
                this.PluginOwner.LazyItems.Add(item);
            }
        }

        /// <summary>
        /// Recreate component on each row expand
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("Recreate component on each row expand")]
        public virtual bool RecreateComponent
        {
            get
            {
                return this.State.Get<bool>("RecreateComponent", false);
            }
            set
            {
                this.State.Set("RecreateComponent", value);
            }
        }

        /// <summary>
        /// Call doLayout after a row expanding/collapsing
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("Call doLayout after a row expanding/collapsing")]
        public virtual bool DoLayoutOnExpand
        {
            get
            {
                return this.State.Get<bool>("DoLayoutOnExpand", true);
            }
            set
            {
                this.State.Set("DoLayoutOnExpand", value);
            }
        }

        /// <summary>
        /// Swallow row body's events
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("Swallow row body's events")]
        public virtual bool SwallowBodyEvents
        {
            get
            {
                return this.State.Get<bool>("SwallowBodyEvents", false);
            }
            set
            {
                this.State.Set("SwallowBodyEvents", value);
            }
        }

        /// <summary>
        /// True to select a row when clicking on the expander icon (defaults to false).
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("True to select a row when clicking on the expander icon (defaults to false).")]
        public virtual bool SelectRowOnExpand
        {
            get
            {
                return this.State.Get<bool>("SelectRowOnExpand", false);
            }
            set
            {
                this.State.Set("SelectRowOnExpand", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(0)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int ScrollOffset
        {
            get
            {
                return this.State.Get<int>("ScrollOffset", 0);
            }
            set
            {
                this.State.Set("ScrollOffset", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool ExpandOnEnter
        {
            get
            {
                return this.State.Get<bool>("ExpandOnEnter", true);
            }
            set
            {
                this.State.Set("ExpandOnEnter", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool ExpandOnDblClick
        {
            get
            {
                return this.State.Get<bool>("ExpandOnDblClick", true);
            }
            set
            {
                this.State.Set("ExpandOnDblClick", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool InvalidateComponentsOnRefresh
        {
            get
            {
                return this.State.Get<bool>("InvalidateComponentsOnRefresh", false);
            }
            set
            {
                this.State.Set("InvalidateComponentsOnRefresh", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool? SingleExpand
        {
            get
            {
                return this.State.Get<bool?>("SingleExpand", null);
            }
            set
            {
                this.State.Set("SingleExpand", value);
            }
        }

        [ConfigOption("singleExpand", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string SingleExpandProxy
        {
            get
            {
                if (this.Component.Count > 0 && !this.SingleExpand.HasValue)
                {
                    return "true";
                }

                return this.SingleExpand.HasValue ? JSON.Serialize(this.SingleExpand.Value) : "";
            }
        }

        private Renderer renderer;

        /// <summary>
        /// A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.
        /// 
        /// See Ext.util.Format for some default formatting functions.
        ///
        /// The render function is called with the following parameters:
        ///     value : Object
        ///         The data value for the cell.
        ///     metadata : Object
        ///         A collection of metadata about the current cell; can be used or modified by the renderer. Recognized properties are: tdCls, tdAttr, and style.
        ///         
        ///         tdCls : String
        ///             A CSS class name to add to the cell's TD element.
        ///         tdAttr : String
        ///             An HTML attribute definition string to apply to the data container element
        ///              within the table cell (e.g. 'style="color:red;"').
        ///         style : String
        ///     
        ///     record : Ext.data.record
        ///         The record for the current row
        ///     rowIndex : Number
        ///         The index of the current row
        ///     colIndex : Number
        ///         The index of the current column
        ///     store : Ext.data.Store
        ///         The index of the current column
        ///     view : Ext.grid.View
        ///         The current view
        /// Returns:
        ///     The HTML string to be rendered.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RendererJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.")]
        public virtual Renderer Renderer
        {
            get
            {
                return this.renderer;
            }
            set
            {
                this.renderer = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override void PluginAdded()
        {
            base.PluginAdded();

            GridPanel grid = this.PluginOwner as GridPanel;

            if (grid == null)
            {
                throw new InvalidOperationException("The RowExpander plugin can only be added to the GridPanel Control or a Control which inherits from GridPanel.");
            }

            if (!this.PluginOwner.Controls.Contains(this.Template))
            {
                this.PluginOwner.Controls.Add(this.Template);
            }

            if (!this.PluginOwner.LazyItems.Contains(this.Template))
            {
                this.PluginOwner.LazyItems.Add(this.Template);
            }

            if (this.Component.Count > 0)
            {
                if (!this.PluginOwner.Controls.Contains(this.Component[0]))
                {
                    this.PluginOwner.Controls.Add(this.Component[0]);
                }

                if (!this.PluginOwner.LazyItems.Contains(this.Component[0]))
                {
                    this.PluginOwner.LazyItems.Add(this.Component[0]);
                }
            }

            if (this.Loader != null && this.PluginOwner != null)
            {
                this.Loader.EnableViewState = this.DesignMode;
                this.PluginOwner.Controls.Add(this.Loader);
                this.PluginOwner.LazyItems.Add(this.Loader);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override void PluginRemoved()
        {
            base.PluginRemoved();

            if (this.PluginOwner.Controls.Contains(this.Template))
            {
                this.PluginOwner.Controls.Remove(this.Template);
            }

            if (this.PluginOwner.LazyItems.Contains(this.Template))
            {
                this.PluginOwner.LazyItems.Remove(this.Template);
            }

            if (this.Component.Count > 0)
            {
                if (this.PluginOwner.Controls.Contains(this.Component[0]))
                {
                    this.PluginOwner.Controls.Remove(this.Component[0]);
                }

                if (this.PluginOwner.LazyItems.Contains(this.Component[0]))
                {
                    this.PluginOwner.LazyItems.Remove(this.Component[0]);
                }
            }

            if (this.Loader != null && this.PluginOwner != null)
            {
                this.PluginOwner.Controls.Remove(this.Loader);
                this.PluginOwner.LazyItems.Remove(this.Loader);
            }
        }

        private RowExpanderListeners listeners;

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
        public RowExpanderListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new RowExpanderListeners();
                }

                return this.listeners;
            }
        }

        private RowExpanderDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side DirectEventHandlers")]
        public RowExpanderDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new RowExpanderDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Toggle (expand/collapse) row
        /// </summary>
        [Meta]
        [Description("Toggle (expand/collapse) row")]
        public virtual void ToggleRow(int row)
        {
            this.Call("toggleRow", row);
        }

        /// <summary>
        /// Expand all rows
        /// </summary>
        [Meta]
        [Description("Expand all rows")]
        public virtual void ExpandAll()
        {
            this.Call("expandAll");
        }

        /// <summary>
        /// Collapse all rows
        /// </summary>
        [Meta]
        [Description("Collapse all rows")]
        public virtual void CollapseAll()
        {
            this.Call("collapseAll");
        }

        /// <summary>
        /// Expand row
        /// </summary>
        [Meta]
        [Description("Expand row")]
        public virtual void ExpandRow(int row)
        {
            this.Call("expandRow", row);
        }

        /// <summary>
        /// Collapse row
        /// </summary>
        [Meta]
        [Description("Collapse row")]
        public virtual void CollapseRow(int row)
        {
            this.Call("collapseRow", row);
        }
    }
}