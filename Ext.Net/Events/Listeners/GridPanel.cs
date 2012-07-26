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
	/// 
	/// </summary>
	[Description("")]
    public partial class GridPanelListeners : TablePanelListeners
    {
        private ComponentListener groupClick;

        /// <summary>
        /// Fires when group header is clicked. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is clicked. Only applies for grids with a Grouping feature.")]
        public virtual ComponentListener GroupClick
        {
            get
            {
                return this.groupClick ?? (this.groupClick = new ComponentListener());
            }
        }

        private ComponentListener groupContextMenu;

        /// <summary>
        /// Fires when group header is right clicked. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is right clicked. Only applies for grids with a Grouping feature.")]
        public virtual ComponentListener GroupContextMenu
        {
            get
            {
                return this.groupContextMenu ?? (this.groupContextMenu = new ComponentListener());
            }
        }

        private ComponentListener groupDblClick;

        /// <summary>
        /// Fires when group header is double clicked. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is double clicked. Only applies for grids with a Grouping feature.")]
        public virtual ComponentListener GroupDblClick
        {
            get
            {
                return this.groupDblClick ?? (this.groupDblClick = new ComponentListener());
            }
        }

        private ComponentListener groupCollapse;

        /// <summary>
        /// Fires when group header is collapsed. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is collapsed. Only applies for grids with a Grouping feature.")]
        public virtual ComponentListener GroupCollapse
        {
            get
            {
                return this.groupCollapse ?? (this.groupCollapse = new ComponentListener());
            }
        }

        private ComponentListener groupExpand;

        /// <summary>
        /// Fires when group header is double expanded. Only applies for grids with a Grouping feature.
        /// Parameters
        /// view : Ext.view.Table
        /// node : HTMLElement
        /// group : String
        /// The name of the group
        /// e : Ext.EventObject
        /// </summary>
        [ListenerArgument(0, "view", typeof(TableView))]
        [ListenerArgument(1, "node", typeof(string))]
        [ListenerArgument(2, "group")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is double expanded. Only applies for grids with a Grouping feature.")]
        public virtual ComponentListener GroupExpand
        {
            get
            {
                return this.groupExpand ?? (this.groupExpand = new ComponentListener());
            }
        }

        private ComponentListener reconfigure;

        /// <summary>
        /// Fires after a reconfigure
        /// Parameters
        /// item : Ext.grid.Panel
        /// store : Ext.data.Store
        ///     The store that was passed to the reconfigure method
        /// columns : Object[]
        ///     The column configs that were passed to the reconfigure method
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "store")]
        [ListenerArgument(2, "columns")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("reconfigure", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a reconfigure")]
        public override ComponentListener Reconfigure
        {
            get
            {
                return this.reconfigure ?? (this.reconfigure = new ComponentListener());
            }
        }
    }
}