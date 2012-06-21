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
 * @version   : 2.0.0.rc1 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class ColumnBase : ComponentBase, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.Locked.HasValue && this.Locked.Value && this.Flex > 0)
            {
                throw new Exception("Columns which are locked do NOT support a flex width. You must set a width on the '" + this.Text + "' column.");
            }
        }
        
        ItemsCollection<AbstractComponent> headerItems;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("headerItems", typeof(ItemCollectionJsonConverter))]
        [Description("")]
        public virtual ItemsCollection<AbstractComponent> HeaderItems
        {
            get
            {
                if (this.headerItems == null)
                {
                    this.headerItems = new ItemsCollection<AbstractComponent>();
                    this.headerItems.AfterItemAdd += this.AfterItemAdd;
                    this.headerItems.AfterItemRemove += this.AfterItemRemove;
                }

                return this.headerItems;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool HideTitleEl
        {
            get
            {
                return this.State.Get<bool>("HideTitleEl", false);
            }
            set
            {
                this.State.Set("HideTitleEl", value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(null)]
        [Description("")]
        public virtual bool? Locked
        {
            get
            {
                return this.State.Get<bool?>("Locked", null);
            }
            set
            {
                this.State.Set("Locked", value);
            }
        }

        /// <summary>
        /// Sets the alignment of the header and rendered columns. Defaults to 'left'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("2. ColumnBase")]
        [DefaultValue(Alignment.Left)]
        [Description("Sets the alignment of the header and rendered columns. Defaults to 'left'.")]
        public virtual Alignment Align
        {
            get
            {
                return this.State.Get<Alignment>("Align", Alignment.Left);
            }
            set
            {
                this.State.Set("Align", value);
            }
        }

        private ColumnCollection columns;

        /// <summary>
        /// An optional array of sub-column definitions. This column becomes a group, and houses the columns defined in the columns config.
        ///
        /// Group columns may not be sortable. But they may be hideable and moveable. And you may move headers into and out of a group. Note that if all sub columns are dragged out of a group, the group is destroyed.
        /// </summary>
        [Meta]
        [ConfigOption("columns", typeof(ItemCollectionJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional array of sub-column definitions. This column becomes a group, and houses the columns defined in the columns config.")]
        public virtual ColumnCollection Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new ColumnCollection();
                    this.columns.AfterItemAdd += this.AfterItemAdd;
                    this.columns.AfterItemRemove += this.AfterItemRemove;
                }

                return this.columns;
            }
        }

        /// <summary>
        /// Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.")]
        public virtual string DataIndex
        {
            get
            {
                return this.State.Get<string>("DataIndex", null);
            }
            set
            {
                this.State.Set("DataIndex", value);
            }
        }

        /// <summary>
        /// False to disable drag-drop reordering of this column. Defaults to: true
        /// </summary>
        [DefaultValue(true)]
        [Description("False to disable drag-drop reordering of this column. Defaults to: true")]
        public override bool Draggable
        {
            get
            {
                return this.State.Get<bool>("Draggable", true);
            }
            set
            {
                this.State.Set("Draggable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [ConfigOption("draggable")]
        protected override bool DraggableProxy
        {
            get
            {
                return !this.Draggable && this.DraggableConfig == null ? false : true;
            }
        }

        private Renderer editorRenderer;

        /// <summary>
        /// A renderer to be used in conjunction with RowEditing. This renderer is used to display a custom value for non-editable fields.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RendererJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A renderer to be used in conjunction with RowEditing. This renderer is used to display a custom value for non-editable fields.")]
        [DirectEventUpdate(MethodName = "SetEditorRenderer")]
        public virtual Renderer EditorRenderer
        {
            get
            {
                return this.editorRenderer ?? (this.editorRenderer = new Renderer());
            }
            set
            {
                this.editorRenderer = value;
                this.State.SetDirectEventUpdate("EditorRenderer", value);
            }
        }

        private EditorCollection editor;

        /// <summary>
        /// An optional xtype or config object for a Field to use for editing. Only applicable if the grid is using an Editing plugin.
        /// </summary>
        [Meta]
        [Category("2. ColumnBase")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional xtype or config object for a Field to use for editing. Only applicable if the grid is using an Editing plugin.")]
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
                if (this.Parent is ColumnBase)
                {
                    return ((ColumnBase)this.Parent).IsRowEditing;
                }
                
                if (this.Parent == null || this.Parent.Parent == null)
                {
                    return false;
                }                

                var grid = this.Parent.Parent as ComponentBase;
                if (grid != null)
                {                    
                    var rowEditing = grid.Plugins.Find(p => p is RowEditing);
                    return rowEditing != null;
                }

                return false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("editor", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string EditorProxy
        {
            get
            {
                if ((this.Editor.Count == 0 && this.EditorOptions.IsDefaultInstanceName) || (this.Editor.Count == 0 && this.IsRowEditing) || this.Editor.Count > 1)
                {
                    return "";
                }

                if (this.IsRowEditing)
                {
                    return Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                            {"id", this.Editor.Primary.ClientID + "_ClientInit"},
                            {"tpl", "{0}"}
                        });
                }

                string options = this.EditorOptions.Serialize();                

                if (this.Editor.Count == 0)
                {
                    return "new " + this.EditorOptions.InstanceName + "(" + options + ")";
                }

                options = options.Replace("{", "{{").Replace("}", "}}");
                string tpl = "new " + this.EditorOptions.InstanceName + "(Ext.apply({{field:{0}}}, " + options + "))";

                return Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                            {"id", this.Editor.Primary.ClientID + "_ClientInit"},
                            {"tpl", tpl}
                        });
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
                if (this.Editor.Count > 1 && this.IsRowEditing)
                {
                    throw new Exception("Row editing doesn't support multiple editors per column");
                }

                if (this.Editor.Count == 0 || this.Editor.Count == 1)
                {
                    return "";
                }

                string options = this.EditorOptions.Serialize();
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
        /// The text to diplay in empty cells (cells with a value of undefined, null, or ''). Defaults to &#160; aka &nbsp;.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The text to diplay in empty cells (cells with a value of undefined, null, or ''). Defaults to &#160; aka &nbsp;.")]
        public virtual string EmptyCellText
        {
            get
            {
                return this.State.Get<string>("EmptyCellText", "");
            }
            set
            {
                this.State.Set("EmptyCellText", value);
            }
        }

        /// <summary>
        /// If the grid uses a Ext.grid.feature.Grouping, this option may be used to disable the header menu item to group by the column selected. By default, the header menu group option is enabled. Set to false to disable (but still show) the group option in the header menu for the column.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("If the grid uses a Ext.grid.feature.Grouping, this option may be used to disable the header menu item to group by the column selected. By default, the header menu group option is enabled. Set to false to disable (but still show) the group option in the header menu for the column.")]
        public virtual bool Groupable
        {
            get
            {
                return this.State.Get<bool>("Groupable", true);
            }
            set
            {
                this.State.Set("Groupable", value);
            }
        }

        /// <summary>
        /// Optional. Specify as false to prevent the user from hiding this column (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(true)]
        [Description("Optional. Specify as false to prevent the user from hiding this column (defaults to true).")]
        public virtual bool Hideable
        {
            get
            {
                return this.State.Get<bool>("Hideable", true);
            }
            set
            {
                this.State.Set("Hideable", value);
            }
        }

        /// <summary>
        /// True to disabled the column header menu containing sort/hide options. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to disabled the column header menu containing sort/hide options. Defaults to false.")]
        public virtual bool MenuDisabled
        {
            get
            {
                return this.State.Get<bool>("MenuDisabled", false);
            }
            set
            {
                this.State.Set("MenuDisabled", value);
            }
        }

        /// <summary>
        /// The text to render in the column visibility selection menu for this column. If not specified, will default to the text value. Defaults to: null
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The text to render in the column visibility selection menu for this column. If not specified, will default to the text value. Defaults to: null")]
        public virtual string MenuText
        {
            get
            {
                return this.State.Get<string>("MenuText", "");
            }
            set
            {
                this.State.Set("MenuText", value);
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
        [DirectEventUpdate(MethodName = "SetRenderer")]
        public virtual Renderer Renderer
        {
            get
            {
                return this.renderer ?? (this.renderer = new Renderer());
            }
            set
            {
                this.renderer = value;
                this.State.SetDirectEventUpdate("Renderer", value);
            }
        }

        /// <summary>
        /// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. ColumnBase")]
        [DefaultValue("")]
        [Description("The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// False to prevent the column from being resizable. Defaults to: true
        /// </summary>
        [Meta]
        [Category("2. ColumnBase")]
        [DefaultValue(true)]
        [Description("False to prevent the column from being resizable. Defaults to: true")]
        public override bool Resizable
        {
            get
            {
                return this.State.Get<bool>("Resizable", true);
            }
            set
            {
                this.State.Set("Resizable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [ConfigOption("resizable")]
        protected override bool ResizableProxy
        {
            get
            {
                return this.Resizable && this.ResizableConfig == null ? true : false;
            }
        }

        /// <summary>
        /// Specify as true to constrain column dragging so that a column cannot be dragged into or out of this column. Note that this config is only valid for column headers which contain child column headers.
        /// </summary>
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(false)]
        [Description("Specify as true to constrain column dragging so that a column cannot be dragged into or out of this column. Note that this config is only valid for column headers which contain child column headers.")]
        public virtual bool Sealed
        {
            get
            {
                return this.State.Get<bool>("Sealed", false);
            }
            set
            {
                this.State.Set("Sealed", value);
            }
        }

        /// <summary>
        /// False to disable sorting of this column. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort. Defaults to: true
        /// </summary>
        [Meta]        
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(null)]
        [Description("False to disable sorting of this column. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort. Defaults to: true")]
        public virtual bool? Sortable
        {
            get
            {
                return this.State.Get<bool?>("Sortable", null);
            }
            set
            {
                this.State.Set("Sortable", value);
            }
        }

        /// <summary>
        /// Optional. A CSS class names to apply to the table cells for this column.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("Optional. A CSS class names to apply to the table cells for this column.")]
        public virtual string TdCls
        {
            get
            {
                return this.State.Get<string>("TdCls", "");
            }
            set
            {
                this.State.Set("TdCls", value);
            }
        }

        /// <summary>
        /// The list of selectors to stop the selection
        /// </summary>
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("TThe list of selectors to stop the selection")]
        public virtual string[] StopSelectionSelectors
        {
            get
            {
                object obj = this.ViewState["StopSelectionSelectors"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["StopSelectionSelectors"] = value;
            }
        }

        /// <summary>
        /// The header text to be used as innerHTML (html tags are accepted) to display in the Grid. Note: to have a clickable header with no text displayed you can use the default of &#160; aka &nbsp;. Defaults to: "&#160;"
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The header text to be used as innerHTML (html tags are accepted) to display in the Grid. Note: to have a clickable header with no text displayed you can use the default of &#160; aka &nbsp;. Defaults to: \"&#160;\"")]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.WithSet)]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        protected virtual void SetRenderer(Renderer renderer)
        {
            this.Set("renderer", new JRawValue(renderer.ToConfigString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        protected virtual void SetEditorRenderer(Renderer renderer)
        {
            this.Set("editorRenderer", new JRawValue(renderer.ToConfigString()));
        }

        /// <summary>
        /// Sets the form field to be used for editing. Note: This method only has an implementation if an Editing plugin has been enabled on the grid.
        /// </summary>
        /// <param name="editor">An object representing a field to be created. If no xtype is specified a 'textfield' is assumed.</param>
        public virtual void SetEditor(Field editor)
        {
            this.Call("setEditor", new JRawValue(editor.ToConfig(LazyMode.Config)));
        }
    }
}