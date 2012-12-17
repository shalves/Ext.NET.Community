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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CellEditingDirectEvents : ComponentDirectEvents
    {
        public CellEditingDirectEvents() { }

        public CellEditingDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeEdit;

        /// <summary>
        /// Fires before cell editing is triggered. Return false from event handler to stop the editing.
        /// 
        /// The edit event object has the following properties:
        /// grid - The grid
        /// record - The record being edited
        /// field - The field name being edited
        /// value - The value for the field being edited.
        /// row - The grid table row
        /// column - The grid Column defining the column that is being edited.
        /// rowIdx - The row index that is being edited
        /// colIdx - The column index that is being edited
        /// cancel - Set this to true to cancel the edit or return false from your handler.
        /// 
        /// Parameters
        /// item : Ext.grid.plugin.Editing
        /// e : Object
        ///     An edit event (see above for description)
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before cell editing is triggered.")]
        public virtual ComponentDirectEvent BeforeEdit
        {
            get
            {
                return this.beforeEdit ?? (this.beforeEdit = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent cancelEdit;

        /// <summary>
        /// Fires when the user started editing a cell but then cancelled the edit. 
        /// 
        /// The edit event object has the following properties:
        /// grid - The grid
        /// record - The record being edited
        /// field - The field name being edited
        /// value - The value for the field being edited.
        /// row - The grid table row
        /// column - The grid Column defining the column that is being edited.
        /// rowIdx - The row index that is being edited
        /// colIdx - The column index that is being edited
        /// cancel - Set this to true to cancel the edit or return false from your handler.
        /// 
        /// Parameters
        /// item : Ext.grid.plugin.Editing
        /// e : Object
        ///     An edit event (see above for description)
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("canceledit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user started editing a cell but then cancelled the edit.")]
        public virtual ComponentDirectEvent CancelEdit
        {
            get
            {
                return this.cancelEdit ?? (this.cancelEdit = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent edit;

        /// <summary>
        /// Fires after a cell is edited. 
        /// 
        /// The edit event object has the following properties:
        /// grid - The grid
        /// record - The record being edited
        /// field - The field name being edited
        /// value - The value for the field being edited.
        /// originalValue - The original value for the field, before the edit.
        /// row - The grid table row
        /// column - The grid Column defining the column that is being edited.
        /// rowIdx - The row index that is being edited
        /// colIdx - The column index that is being edited
        /// 
        /// Parameters
        /// item : Ext.grid.plugin.Editing
        /// e : Object
        /// An edit event (see above for description)
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("edit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited.")]
        public virtual ComponentDirectEvent Edit
        {
            get
            {
                return this.edit ?? (this.edit = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent validateEdit;

        /// <summary>
        /// Fires after a cell is edited, but before the value is set in the record. Return false to cancel the change. 
        /// 
        /// The edit event object has the following properties:
        /// grid - The grid
        /// record - The record being edited
        /// field - The field name being edited
        /// value - The value for the field being edited.
        /// originalValue - The original value for the field, before the edit.
        /// row - The grid table row
        /// column - The grid Column defining the column that is being edited.
        /// rowIdx - The row index that is being edited
        /// colIdx - The column index that is being edited
        /// cancel - Set this to true to cancel the edit or return false from your handler.
        /// 
        /// Usage example showing how to remove the red triangle (dirty record indicator) from some records (not all). By observing the grid's validateedit event, it can be cancelled if the edit occurs on a targeted row (for example) and then setting the field's new value in the Record directly:
        /// 
        /// grid.on('validateedit', function(ed, e) {
        ///   var myTargetRow = 6;
        /// 
        ///   if (e.row == myTargetRow) {
        ///     e.cancel = true;
        ///     e.record.data[e.field] = e.value;
        ///   }
        /// });
        /// 
        /// Parameters
        /// item : Ext.grid.plugin.Editing
        /// e : Object
        /// An edit event (see above for description)
        /// </summary>
        [ListenerArgument(0, "item", typeof(object))]
        [ListenerArgument(1, "e", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validateedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited, but before the value is set in the record. Return false to cancel the change.")]
        public virtual ComponentDirectEvent ValidateEdit
        {
            get
            {
                return this.validateEdit ?? (this.validateEdit = new ComponentDirectEvent(this));
            }
        }
    }
}
