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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ComboBoxListeners : PickerFieldListeners
    {
        private ComponentListener beforeQuery;

        /// <summary>
        /// Fires before all queries are processed. Return false to cancel the query or set the queryEvent's cancel property to true.
        /// Parameters
        /// queryEvent : Object
        /// An object that has these properties:
        ///     combo : Ext.form.field.ComboBox
        ///         This combo box
        ///     query : String
        ///         The query string
        ///     forceAll : Boolean
        ///         True to force "all" query
        ///     cancel : Boolean
        ///         Set to true to cancel the query
        /// </summary>
        [ListenerArgument(0, "queryEvent", typeof(object), "An object that includes combo (This combo box), query (The query), forceAll (True to force 'all' query) and cancel (Set to true to cancel the query).")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforequery", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before all queries are processed. Return false to cancel the query or set the queryEvent's cancel property to true.")]
        public virtual ComponentListener BeforeQuery 
        {
            get
            {                
                return this.beforeQuery ?? (this.beforeQuery = new ComponentListener());
            }
        }

        private ComponentListener beforeSelect;

        /// <summary>
        /// Fires before the selected item is added to the collection
        /// Parameters
        /// item : Ext.form.field.ComboBox
        ///     This combo box
        /// record : Ext.data.Record
        ///     The selected record
        /// index : Number
        ///     The index of the selected record
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This combo box")]
        [ListenerArgument(1, "record", typeof(object), "The data record returned from the underlying store")]
        [ListenerArgument(2, "index", typeof(int), "The index of the selected item in the dropdown list")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the selected item is added to the collection")]
        public virtual ComponentListener BeforeSelect
        {
            get
            {
                return this.beforeSelect ?? (this.beforeSelect = new ComponentListener());
            }
        }

        private ComponentListener beforeDeselect;

        /// <summary>
        /// Fires before the deselected item is removed from the collection
        /// Parameters
        /// item : Ext.form.field.ComboBox
        ///     This combo box
        /// record : Ext.data.Record
        ///     The deselected record
        /// index : Number
        ///     The index of the deselected record
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This combo box")]
        [ListenerArgument(1, "record", typeof(object), "The deselected record")]
        [ListenerArgument(2, "index", typeof(int), "The index of the deselected record")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedeselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the deselected item is removed from the collection")]
        public virtual ComponentListener BeforeDeselect
        {
            get
            {
                return this.beforeDeselect ?? (this.beforeDeselect = new ComponentListener());
            }
        }

        private ComponentListener select;

        /// <summary>
        /// Fires when at least one list item is selected.
        /// Parameters
        /// item : Ext.form.field.ComboBox
        ///     This combo box
        /// records : Array
        ///     The selected records
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This combo box")]
        [ListenerArgument(1, "records", typeof(object), "The data record returned from the underlying store")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("select", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when at least one list item is selected.")]
        public override ComponentListener Select
        {
            get
            {
                return this.select ?? (this.select = new ComponentListener());
            }
        }
    }
}