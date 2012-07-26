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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This class encapsulates the user interface for a tabular data set. It acts as a centralized manager for controlling the various interface elements of the view. This includes handling events, such as row and cell level based DOM events. It also reacts to events from the underlying Ext.selection.Model to provide visual feedback to the user.
    ///
    /// This class does not provide ways to manipulate the underlying data of the configured Ext.data.Store.
    ///
    /// This is the base class for both Ext.grid.View and Ext.tree.View and is not to be used directly.
    /// </summary>
    [Meta]
    public abstract partial class TableView : AbstractDataView
    {
        private JFunction getRowClass;

        /// <summary>
        /// Override this function to apply custom CSS classes to rows during rendering. You can also supply custom parameters to the row template for the current row to customize how it is rendered using the rowParams parameter. This function should return the CSS class name (or empty string '' for none) that will be added to the row's wrapping div. To apply multiple class names, simply return them space-delimited within the string (e.g., 'my-class another-class'). Example usage:
        /// 
        /// viewConfig: {
        ///     getRowClass: function(record, rowIndex, rowParams, store){
        ///         return record.get("valid") ? "row-valid" : "row-error";
        ///     }
        /// }
        ///     
        /// Parameters
        /// record : Model
        /// The Ext.data.Model corresponding to the current row.
        ///
        /// index : Number
        /// The row index.
        /// 
        /// rowParams : Object
        /// DEPRECATED. For row body use the getAdditionalData method of the rowbody feature.
        /// 
        /// store : Store
        /// The Ext.data.Store this grid is bound to
        /// 
        /// Returns
        /// String   
        /// a CSS class name to add to the row.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Override this function to apply custom CSS classes to rows during rendering. You can also supply custom parameters to the row template for the current row to customize how it is rendered using the rowParams parameter. This function should return the CSS class name (or empty string '' for none) that will be added to the row's wrapping div. To apply multiple class names, simply return them space-delimited within the string (e.g., 'my-class another-class').")]
        public virtual JFunction GetRowClass
        {
            get
            {
                if (this.getRowClass == null)
                {
                    this.getRowClass = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.getRowClass.Args = new string[] { "record", "index", "rowParams", "store" };
                    }
                }

                return this.getRowClass;
            }
        }

        /// <summary>
        /// True to enable text selections.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. TableView")]
        [DefaultValue(false)]
        [Description("True to enable text selections.")]
        public virtual bool EnableTextSelection
        {
            get
            {
                return this.State.Get<bool>("EnableTextSelection", false);
            }
            set
            {
                this.State.Set("EnableTextSelection", value);
            }
        }

        /// <summary>
        /// A CSS class to add to the first cell in every row to enable special styling for the first column. If no styling is needed on the first column, this may be configured as null. Defaults to: "x-grid-cell-first"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. TableView")]
        [DefaultValue("x-grid-cell-first")]
        [Description("A CSS class to add to the first cell in every row to enable special styling for the first column. If no styling is needed on the first column, this may be configured as null. Defaults to: \"x-grid-cell-first\"")]
        public virtual string FirstCls
        {
            get
            {
                return this.State.Get<string>("FirstCls", "x-grid-cell-first");
            }
            set
            {
                this.State.Set("FirstCls", value);
            }
        }

        /// <summary>
        /// A CSS class to add to the last cell in every row to enable special styling for the last column. If no styling is needed on the last column, this may be configured as null. Defaults to: "x-grid-cell-last"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. TableView")]
        [DefaultValue("x-grid-cell-last")]
        [Description("A CSS class to add to the last cell in every row to enable special styling for the last column. If no styling is needed on the last column, this may be configured as null. Defaults to: \"x-grid-cell-last\"")]
        public virtual string LastCls
        {
            get
            {
                return this.State.Get<string>("LastCls", "x-grid-cell-last");
            }
            set
            {
                this.State.Set("LastCls", value);
            }
        }

        /// <summary>
        /// True to show the dirty cell indicator when a cell has been modified.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. TableView")]
        [DefaultValue(true)]
        [Description("True to show the dirty cell indicator when a cell has been modified.")]
        public virtual bool MarkDirty
        {
            get
            {
                return this.State.Get<bool>("MarkDirty", true);
            }
            set
            {
                this.State.Set("MarkDirty", value);
            }
        }

        /// <summary>
        /// True to enable mouseenter and mouseleave events
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. TableView")]
        [DefaultValue(true)]
        [Description("True to enable mouseenter and mouseleave events")]
        public override bool TrackOver
        {
            get
            {
                return this.State.Get<bool>("TrackOver", true);
            }
            set
            {
                this.State.Set("TrackOver", value);
            }
        }
        
        /// <summary>
        /// Add a CSS Class to a specific row.
        /// </summary>
        /// <param name="rowIndex">An HTMLElement, index or instance of a model representing this row</param>
        /// <param name="cls"></param>
        public void AddRowCls(int rowIndex, string cls)
        {
            this.Call("addRowCls", rowIndex, cls);
        }

        /// <summary>
        /// Add a CSS Class to a specific row.
        /// </summary>
        /// <param name="id">An HTMLElement, index or instance of a model representing this row</param>
        /// <param name="cls"></param>
        public void AddRowCls(string id, string cls)
        {
            this.Call("addRowCls", id, cls);
        }

        /// <summary>
        /// Add a CSS Class to a specific row.
        /// </summary>
        /// <param name="record">An HTMLElement, index or instance of a model representing this row</param>
        /// <param name="cls"></param>
        public void AddRowCls(ModelProxy record, string cls)
        {
            this.Call("addRowCls", new JRawValue(record.ModelInstance), cls);
        }

        /// <summary>
        /// Focuses a particular row and brings it into view. Will fire the rowfocus event.
        /// </summary>
        /// <param name="rowIndex">An HTMLElement template node, index of a template node, the id of a template node or the record associated with the node.</param>
        public void FocusRow(int rowIndex)
        {
            this.Call("focusRow", rowIndex);
        }

        /// <summary>
        /// Focuses a particular row and brings it into view. Will fire the rowfocus event.
        /// </summary>
        /// <param name="id">An HTMLElement template node, index of a template node, the id of a template node or the record associated with the node.</param>
        public void FocusRow(string id)
        {
            this.Call("focusRow", id);
        }

        /// <summary>
        /// Focuses a particular row and brings it into view. Will fire the rowfocus event.
        /// </summary>
        /// <param name="record">An HTMLElement template node, index of a template node, the id of a template node or the record associated with the node.</param>
        public void FocusRow(ModelProxy record)
        {
            this.Call("focusRow", new JRawValue(record.ModelInstance));
        }

        /// <summary>
        /// Remove a CSS Class from a specific row.
        /// </summary>
        /// <param name="rowIndex">An HTMLElement, index or instance of a model representing this row</param>
        /// <param name="cls"></param>
        public void RemoveRowCls(int rowIndex, string cls)
        {
            this.Call("removeRowCls", rowIndex, cls);
        }

        /// <summary>
        /// Remove a CSS Class from a specific row.
        /// </summary>
        /// <param name="id">An HTMLElement, index or instance of a model representing this row</param>
        /// <param name="cls"></param>
        public void RemoveRowCls(string id, string cls)
        {
            this.Call("removeRowCls", id, cls);
        }

        /// <summary>
        /// Remove a CSS Class from a specific row.
        /// </summary>
        /// <param name="record">An HTMLElement, index or instance of a model representing this row</param>
        /// <param name="cls"></param>
        public void RemoveRowCls(ModelProxy record, string cls)
        {
            this.Call("removeRowCls", new JRawValue(record.ModelInstance), cls);
        }
    }
}
