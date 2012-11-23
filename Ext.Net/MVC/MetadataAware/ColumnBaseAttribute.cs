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
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ColumnBaseAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.column";
        public const string KEY_ORDER = "__ext.net.column_order";
        public const string KEY_IGNORE = "__ext.net.column_ignore";
        private Alignment align = Alignment.Left;
        private bool draggable = true;
        private bool groupable = true;
        private bool hideable = true;
        private bool resizable = true;
        private ToolTipType toolTipType = ToolTipType.Qtip;
        private int order = int.MaxValue;

        [DefaultValue(false)]
        public virtual bool Ignore
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public virtual bool HideTitleEl
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public virtual bool? Locked
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the alignment of the header and rendered columns. Defaults to 'left'.
        /// </summary>
        [DefaultValue(Alignment.Left)]
        public virtual Alignment Align
        {
            get
            {
                return this.align;
            }
            set
            {
                this.align = value;
            }
        }

        /// <summary>
        /// Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.
        /// </summary>
        [DefaultValue(null)]
        public virtual string DataIndex
        {
            get;
            set;
        }

        /// <summary>
        /// False to disable drag-drop reordering of this column. Defaults to: true
        /// </summary>
        [DefaultValue(true)]
        public virtual bool Draggable
        {
            get
            {
                return this.draggable;
            }
            set
            {
                this.draggable = value;
            }
        }

        /// <summary>
        /// A renderer to be used in conjunction with RowEditing. This renderer is used to display a custom value for non-editable fields.
        /// </summary>
        [DefaultValue(null)]
        public virtual string EditorRendererHandler
        {
            get;
            set;
        }

        /// <summary>
        /// The text to diplay in empty cells (cells with a value of undefined, null, or ''). Defaults to &#160; aka &nbsp;.
        /// </summary>
        [DefaultValue(null)]
        public virtual string EmptyCellText
        {
            get;
            set;
        }

        /// <summary>
        /// If the grid uses a Ext.grid.feature.Grouping, this option may be used to disable the header menu item to group by the column selected. By default, the header menu group option is enabled. Set to false to disable (but still show) the group option in the header menu for the column.
        /// </summary>
        [DefaultValue(true)]
        public virtual bool Groupable
        {
            get
            {
                return this.groupable;
            }
            set
            {
                this.groupable = value;
            }
        }

        /// <summary>
        /// Optional. Specify as false to prevent the user from hiding this column (defaults to true).
        /// </summary>
        [DefaultValue(true)]
        public virtual bool Hideable
        {
            get
            {
                return this.hideable;
            }
            set
            {
                this.hideable = value;
            }
        }

        /// <summary>
        /// True to disabled the column header menu containing sort/hide options. Defaults to false.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool MenuDisabled
        {
            get;
            set;
        }

        /// <summary>
        /// The text to render in the column visibility selection menu for this column. If not specified, will default to the text value. Defaults to: null
        /// </summary>
        [DefaultValue(null)]
        public virtual string MenuText
        {
            get;
            set;
        }

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
        [DefaultValue(null)]
        public virtual string RendererHandler
        {
            get;
            set;
        }

        /// <summary>
        /// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Scope
        {
            get;
            set;
        }

        /// <summary>
        /// False to prevent the column from being resizable. Defaults to: true
        /// </summary>
        [DefaultValue(true)]
        public virtual bool Resizable
        {
            get
            {
                return this.resizable;
            }
            set
            {
                this.resizable = value;
            }
        }

        /// <summary>
        /// Specify as true to constrain column dragging so that a column cannot be dragged into or out of this column. Note that this config is only valid for column headers which contain child column headers.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool Sealed
        {
            get;
            set;
        }

        /// <summary>
        /// False to disable sorting of this column. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort. Defaults to: true
        /// </summary>
        [DefaultValue(null)]
        public virtual bool? Sortable
        {
            get;
            set;
        }

        /// <summary>
        /// Optional. A CSS class names to apply to the table cells for this column.
        /// </summary>
        [DefaultValue(null)]
        public virtual string TdCls
        {
            get;
            set;
        }

        /// <summary>
        /// The header text to be used as innerHTML (html tags are accepted) to display in the Grid. Note: to have a clickable header with no text displayed you can use the default of &#160; aka &nbsp;. Defaults to: "&#160;"
        /// </summary>
        [DefaultValue(null)]
        public virtual string Text
        {
            get;
            set;
        }

        /// <summary>
        /// A tooltip to display for this column header
        /// </summary>
        [DefaultValue(null)]
        public virtual string ToolTip
        {
            get;
            set;
        }

        /// <summary>
        /// The type of tooltip to use. Either 'qtip' for QuickTips or 'title' for title attribute.
        /// </summary>
        [DefaultValue(ToolTipType.Qtip)]
        public virtual ToolTipType ToolTipType
        {
            get
            {
                return this.toolTipType;
            }
            set
            {
                this.toolTipType = value;
            }
        }

        /// <summary>
        /// True to wrap the cells text (excluding header). Defaults to null.
        /// </summary>
        [DefaultValue(null)]
        public virtual bool? Wrap
        {
            get;
            set;
        }

        /// <summary>
        /// Render this component hidden (default is false). If true, the hide method will be called internally.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool Hidden
        {
            get;
            set;
        }

        /// <summary>
        /// NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
        /// </summary>
        [DefaultValue(0)]
        public virtual int Flex
        {
            get;
            set;
        }

        /// <summary>
        /// The width of this component in pixels.
        /// </summary>
        [DefaultValue(0)]
        public virtual int Width
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(-1)]
        public virtual int Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }

        protected abstract ColumnBase CreateColumn();

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            var column = this.CreateColumn();
            if (!this.Ignore)
            {
                column.DataIndex = metadata.PropertyName;
                if (metadata.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY))
                {
                    string name = ((ModelFieldAttribute)metadata.AdditionalValues[ModelFieldAttribute.KEY]).Name;
                    if (name.IsNotEmpty())
                    {
                        column.DataIndex = name;
                    }
                }

                column.Text = Regex.Replace(metadata.PropertyName, "([a-z])([A-Z])", "$1 $2");

                BaseControl.Apply(column, this);

                if (this.EditorRendererHandler != null)
                {
                    column.EditorRenderer.Fn = this.EditorRendererHandler;
                }

                if (this.RendererHandler != null)
                {
                    column.Renderer.Fn = this.RendererHandler;
                }

                if (this.Width != 0)
                {
                    column.Width = this.Width;
                }
            }
            else
            {
                metadata.AdditionalValues[ColumnBaseAttribute.KEY_IGNORE] = true;
            }

            metadata.AdditionalValues[ColumnBaseAttribute.KEY] = column;
            metadata.AdditionalValues[ColumnBaseAttribute.KEY_ORDER] = this.Order;
        }
    }
}