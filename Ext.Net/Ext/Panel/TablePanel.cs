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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// TablePanel is the basis of both TreePanel and GridPanel.
    /// 
    /// TablePanel aggregates:
    /// 
    /// a Selection Model
    /// a View
    /// a Store
    /// Scrollers
    /// Ext.grid.header.Container
    /// </summary>
    [Meta]
    public abstract partial class TablePanel : AbstractPanel, INoneContentable
    {
        private EditorCollection editor;

        /// <summary>
        /// (optional) The Field to use when editing values in columns if editing is supported by the grid.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("(optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.")]
        public virtual EditorCollection Editor
        {
            get
            {
                if (this.editor == null)
                {
                    this.editor = new EditorCollection();
                    this.editor.AfterItemAdd += this.AfterItemAdd;
                    this.editor.AfterItemRemove += this.AfterItemRemove;
                    this.editor.SingleItemMode = false;
                }

                return editor;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool IsRowEditing
        {
            get
            {
                var rowEditing = this.Plugins.Find(p => p is RowEditing);
                return rowEditing != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("editors", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string EditorsProxy
        {
            get
            {
                if (this.Editor.Count == 0 && this.EditorOptions.IsDefaultInstanceName)
                {
                    return "";
                }

                if (this.IsRowEditing)
                {
                    throw new Exception("Row editing doesn't support grid's editors");
                }

                string options = this.EditorOptions.Serialize();                

                if (this.Editor.Count == 0)
                {
                    return "[new " + this.EditorOptions.InstanceName + "(" + options + ")]";
                }
                
                options = options.Replace("{", "{{").Replace("}", "}}");
                string tpl = "new " + this.EditorOptions.InstanceName + "(Ext.apply({{field:{0}}}, " + options + "))";

                StringBuilder sb = new StringBuilder("[");

                foreach (var ed in this.Editor)
                {
                    sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                            {"id", ed.ClientID + "_ClientInit"},
                            {"tpl", tpl}
                        }));
                    sb.Append(",");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");

                return sb.ToString();
            }
        }

        private JFunction editorStrategy;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. ColumnBase")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction EditorStrategy
        {
            get
            {
                if (this.editorStrategy == null)
                {
                    this.editorStrategy = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.editorStrategy.Args = new string[] { "record", "column", "editors", "panel" };
                    }

                }

                return this.editorStrategy;
            }
        }

        private CellEditorOptions editorOptions;

        /// <summary>
        /// Editor options
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Editor options")]
        public virtual CellEditorOptions EditorOptions
        {
            get
            {
                if (this.editorOptions == null)
                {
                    editorOptions = new CellEditorOptions();
                }

                return editorOptions;
            }
        }

        /// <summary>
        /// true to add css for column separation lines. Default is false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TablePanel")]
        [DefaultValue(false)]
        [Description("true to add css for column separation lines. Default is false.")]
        public virtual bool ColumnLines
        {
            get
            {
                return this.State.Get<bool>("ColumnLines", false);
            }
            set
            {
                this.State.Set("ColumnLines", value);
            }
        }
        
        private GridHeaderContainer columns;

        /// <summary>
        /// Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
        /// </summary>
        [Meta]
        [ConfigOption("columns", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.")]
        public virtual GridHeaderContainer ColumnModel
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new GridHeaderContainer();
                    this.Controls.Add(this.columns);
                    this.LazyItems.Add(this.columns);
                }

                return this.columns;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.ColumnModel.EnsureChildControlsInternal();
        }

        /// <summary>
        /// Defaults to true to enable deferred row rendering. This allows the GridView to execute a refresh quickly, with the expensive update of the row structure deferred so that layouts with GridPanels appear, and lay out more quickly.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Defaults to true to enable deferred row rendering.")]
        public virtual bool DeferRowRender
        {
            get
            {
                return this.State.Get<bool>("DeferRowRender", true);
            }
            set
            {
                this.State.Set("DeferRowRender", value);
            }
        }

        /// <summary>
        /// True to disable selection model. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to disable selection model. Defaults to: false")]
        public virtual bool DisableSelection
        {
            get
            {
                return this.State.Get<bool>("DisableSelection", false);
            }
            set
            {
                this.State.Set("DisableSelection", value);
            }
        }

        /// <summary>
        /// Default text (html tags are accepted) to display in the Panel body when the Store is empty. When specified, and the Store is empty, the text will be rendered inside a DIV with the CSS class "x-grid-empty".
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Default text (html tags are accepted) to display in the Panel body when the Store is empty. When specified, and the Store is empty, the text will be rendered inside a DIV with the CSS class \"x-grid-empty\".")]
        public virtual string EmptyText
        {
            get
            {
                return this.State.Get<string>("EmptyText", "");
            }
            set
            {
                this.State.Set("EmptyText", value);
            }
        }

        /// <summary>
        /// False to disable column hiding within this grid. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to disable column hiding within this grid. Defaults to: true")]
        public virtual bool EnableColumnHide
        {
            get
            {
                return this.State.Get<bool>("EnableColumnHide", true);
            }
            set
            {
                this.State.Set("EnableColumnHide", value);
            }
        }

        /// <summary>
        /// False to disable column dragging within this grid. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to disable column dragging within this grid. Defaults to: true")]
        public virtual bool EnableColumnMove
        {
            get
            {
                return this.State.Get<bool>("EnableColumnMove", true);
            }
            set
            {
                this.State.Set("EnableColumnMove", value);
            }
        }

        /// <summary>
        /// False to disable column resizing within this grid. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to disable column resizing within this grid. Defaults to: true")]
        public virtual bool EnableColumnResize
        {
            get
            {
                return this.State.Get<bool>("EnableColumnResize", true);
            }
            set
            {
                this.State.Set("EnableColumnResize", value);
            }
        }

        /// <summary>
        /// True to enable locking support for this grid. Alternatively, locking will also be automatically enabled if any of the columns in the column configuration contain the locked config option. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to enable locking support for this grid. Alternatively, locking will also be automatically enabled if any of the columns in the column configuration contain the locked config option. Defaults to: false")]
        public virtual bool EnableLocking
        {
            get
            {
                return this.State.Get<bool>("EnableLocking", false);
            }
            set
            {
                this.State.Set("EnableLocking", value);
            }
        }

        /// <summary>
        /// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.")]
        public virtual bool ForceFit
        {
            get
            {
                return this.State.Get<bool>("ForceFit", false);
            }
            set
            {
                this.State.Set("ForceFit", value);
            }
        }

        /// <summary>
        /// True to hide the headers. Defaults to false.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to hide the headers. Defaults to false.")]
        public virtual bool HideHeaders
        {
            get
            {
                return this.State.Get<bool>("HideHeaders", false);
            }
            set
            {
                this.State.Set("HideHeaders", value);
            }
        }

        /// <summary>
        /// True to enable 'MULTI' selection mode on selection model.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable 'MULTI' selection mode on selection model.")]
        public virtual bool MultiSelect
        {
            get
            {
                return this.State.Get<bool>("MultiSelect", false);
            }
            set
            {
                this.State.Set("MultiSelect", value);
            }
        }

        /// <summary>
        /// True to constrain column dragging so that a column cannot be dragged in or out of it's current group. Only relevant while enableColumnMove is enabled. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to constrain column dragging so that a column cannot be dragged in or out of it's current group. Only relevant while enableColumnMove is enabled. Defaults to: false")]
        public virtual bool RestrictColumnReorder
        {
            get
            {
                return this.State.Get<bool>("RestrictColumnReorder", false);
            }
            set
            {
                this.State.Set("RestrictColumnReorder", value);
            }
        }

        /// <summary>
        /// Adds row line styling. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Adds row line styling. Defaults to: true")]
        public virtual bool RowLines
        {
            get
            {
                return this.State.Get<bool>("RowLines", true);
            }
            set
            {
                this.State.Set("RowLines", value);
            }
        }

        /// <summary>
        /// Scrollers configuration. Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(ScrollMode.Both)]
        [Description("Scrollers configuration. Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.")]
        public virtual ScrollMode Scroll
        {
            get
            {
                return this.State.Get<ScrollMode>("Scroll", ScrollMode.Both);
            }
            set
            {
                this.State.Set("Scroll", value);
            }
        }

        /// <summary>
        /// Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(40)]
        [Description("Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.")]
        public virtual int ScrollDelta 
        {
            get
            {
                return this.State.Get<int>("ScrollDelta", 40);
            }
            set
            {
                this.State.Set("ScrollDelta", value);
            }
        }

        /// <summary>
        /// True to enable 'SIMPLE' selection mode on selection model.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to enable 'SIMPLE' selection mode on selection model.")]
        public virtual bool SimpleSelect
        {
            get
            {
                return this.State.Get<bool>("SimpleSelect", false);
            }
            set
            {
                this.State.Set("SimpleSelect", value);
            }
        }

        /// <summary>
        /// False to disable column sorting via clicking the header and via the Sorting menu items. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to disable column sorting via clicking the header and via the Sorting menu items. Defaults to: true")]
        public virtual bool SortableColumns
        {
            get
            {
                return this.State.Get<bool>("SortableColumns", true);
            }
            set
            {
                this.State.Set("SortableColumns", value);
            }
        }

        private SelectionModelCollection selectionModel;

        /// <summary>
        /// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
        /// </summary>
        [Meta]
        [ConfigOption("selModel>Primary")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).")]
        public virtual SelectionModelCollection SelectionModel
        {
            get
            {
                if (this.selectionModel == null)
                {
                    this.selectionModel = new SelectionModelCollection();
                    this.selectionModel.AfterItemAdd += this.AfterItemAdd;
                    this.selectionModel.AfterItemRemove += this.AfterItemRemove;
                }

                return this.selectionModel;
            }
        }

        /// <summary>
        /// An xtype of selection model to use. Defaults to 'rowmodel'. This is used to create selection model if just a config object or nothing at all given in selModel config. Defaults to: "rowmodel"
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Selection model type")]
        public virtual SelectionType? SelType
        {
            get
            {
                return this.State.Get<SelectionType?>("SelType", null);
            }
            set
            {
                this.State.Set("SelType", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("selType")]
        [DefaultValue("")]
        protected virtual string SelTypeProxy
        {
            get
            {
               return this.SelType.HasValue ? (this.SelType.Value.ToString().ToLowerInvariant() + "model") : "";
            }
        }

        /// <summary>
        /// Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. ")]
        public virtual bool AllowDeselect
        {
            get
            {
                return this.State.Get<bool>("AllowDeselect", false);
            }
            set
            {
                this.State.Set("AllowDeselect", value);
            }
        }

        /// <summary>
        /// Reset the scrollbar when the view refreshs. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Reset the scrollbar when the view refreshs. Defaults to true")]
        public virtual bool InvalidateScrollerOnRefresh
        {
            get
            {
                return this.State.Get<bool>("InvalidateScrollerOnRefresh", true);
            }
            set
            {
                this.State.Set("InvalidateScrollerOnRefresh", value);
            }
        }

        /// <summary>
        /// The list of selectors of the ignore targets
        /// </summary>
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of selectors of the ignore targets")]
        public virtual string[] IgnoreTargets
        {
            get
            {
                return this.State.Get<string[]>("IgnoreTargets", null);
            }
            set
            {
                this.State.Set("IgnoreTargets", value);
            }
        }

        /// <summary>
        /// Returns a GridPanel's Selection model
        /// </summary>
        public AbstractSelectionModel GetSelectionModel()
        {
            return this.SelectionModel.Primary;
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store", JsonMode.ToClientID)]
        [Category("7. GridPanel")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return this.State.Get<string>("StoreID", "");
            }
            set
            {
                this.State.Set("StoreID", value);
            }
        }

        /// <summary>
        /// Show/Hide the grid's header.
        /// </summary>
        /// <param name="hide"></param>
        [Description("Show/Hide the grid's header.")]
        protected virtual void SetHideHeaders(bool hide)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}.headerCt.setVisible({1});", this.ClientID, JSON.Serialize(!hide));
            this.DoComponentLayout();
        }

        /// <summary>
        /// Reconfigure the table with a new store/column. Either the store or the column can be ommitted if you don't wish to change them.
        /// </summary>
        /// <param name="store">The new store.</param>
        /// <param name="columns">An array of column configs</param>
        public virtual void Reconfigure(AbstractStore store, ColumnBase[] columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (ColumnBase column in columns)
            {
                sb.Append(column.ToConfig());
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            this.Call("reconfigure", store.ToConfig(LazyMode.Instance), new JRawValue(sb.ToString()));
        }

        /// <summary>
        /// Scrolls the TablePanel by deltaX
        /// </summary>
        /// <param name="deltaX">Number</param>
        public virtual void ScrollByDeltaX(int deltaX)
        {
            this.Call("scrollByDeltaX", deltaX);
        }

        /// <summary>
        /// Scrolls the TablePanel by deltaY
        /// </summary>
        /// <param name="deltaY">Number</param>
        public virtual void ScrollByDeltaY(int deltaY)
        {
            this.Call("scrollByDeltaY", deltaY);
        }

        /// <summary>
        /// Sets the scrollTop of the TablePanel.
        /// </summary>
        /// <param name="top">Number</param>
        public virtual void SetScrollTop(int top)
        {
            this.Call("setScrollTop", top);
        }

        #region TODO Need implement these methods

        /// <summary>
        /// Add new column to the end.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void AddColumn(ColumnBase column, bool doLayout)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("addColumn", JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)), doLayout);
        }

        /// <summary>
        /// Add new column to the end.
        /// </summary>
        /// <param name="column"></param>
        [Meta]
        public virtual void AddColumn(ColumnBase column)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("addColumn", JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)));
        }

        /// <summary>
        /// Insert new column.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void InsertColumn(int index, ColumnBase column, bool doLayout)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("insertColumn", index, JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)), doLayout);
        }

        /// <summary>
        /// Insert new column.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        [Meta]
        public virtual void InsertColumn(int index, ColumnBase column)
        {
            this.ColumnModel.Columns.Add(column);
            this.Call("insertColumn", index, JRawValue.From(column.ToConfig(Ext.Net.LazyMode.Config)));
        }

        /// <summary>
        /// Remove column.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void RemoveColumn(int index, bool doLayout)
        {
            this.Call("removeColumn", index, doLayout);
        }

        /// <summary>
        /// Remove column.
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        public virtual void RemoveColumn(int index)
        {
            this.Call("removeColumn", index);
        }

        /// <summary>
        /// Remove all columns.
        /// </summary>
        /// <param name="doLayout"></param>
        [Meta]
        public virtual void RemoveAllColumns(bool doLayout)
        {
            this.Call("removeAllColumns", doLayout);
        }

        /// <summary>
        /// Remove all columns.
        /// </summary>
        [Meta]
        public virtual void RemoveAllColumns()
        {
            this.Call("removeAllColumns");
        }

        /// <summary>
        /// Reconfigures the grid with a new store/columns.
        /// </summary>
        /// <param name="storeId"></param>
        [Meta]
        public virtual void Reconfigure(string storeId)
        {
            StringBuilder sb = new StringBuilder("[");
            var comma = false;
            foreach (var column in this.ColumnModel.Columns)
	        {
                if(comma)
                {
                    sb.Append(",");
                }
                sb.Append(column.ToConfig(Ext.Net.LazyMode.Config));                
                comma = true;
	        }
            sb.Append("]");

            this.Call("reconfigure", JRawValue.From(storeId.IsEmpty() ? "undefined" : storeId), JRawValue.From(sb.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        public virtual void Reconfigure()
        {
            this.Reconfigure(string.Empty);
        }

        /// <summary>
        /// Reconfigures the grid with a new store/columns.
        /// </summary>
        [Meta]
        public virtual void Reconfigure(AbstractStore store, IEnumerable<ColumnBase> columns)
        {
            StringBuilder sb = new StringBuilder("[");
            var comma = false;
            foreach (var column in columns)
            {
                if (comma)
                {
                    sb.Append(",");
                }
                sb.Append(column.ToConfig(Ext.Net.LazyMode.Config));
                comma = true;
            }
            sb.Append("]");

            this.Call("reconfigure", JRawValue.From(store == null ? "undefined" : store.ToConfig(Ext.Net.LazyMode.Instance)), JRawValue.From(sb.ToString()));
        }

        /// <summary>
        /// Reconfigures the grid with a new columns.
        /// </summary>
        [Meta]
        public virtual void Reconfigure(IEnumerable<ColumnBase> columns)
        {
            this.Reconfigure(null, columns);
        }
        
        #endregion
    }
}
