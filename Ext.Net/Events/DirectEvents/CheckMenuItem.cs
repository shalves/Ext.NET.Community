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
	[Description("")]
    public partial class CheckMenuItemDirectEvents : MenuItemDirectEvents
    {
        public CheckMenuItemDirectEvents() { }

        public CheckMenuItemDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeCheckChange;

        /// <summary>
        /// Fires before a change event. Return false to cancel.
        /// Parameters
        /// item : Ext.menu.CheckItem
        /// checked : Boolean
        /// </summary>
        [ListenerArgument(0, "item", typeof(CheckMenuItem), "this")]
        [ListenerArgument(1, "checked", typeof(bool), "checked")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecheckchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a change event. Return false to cancel.")]
        public virtual ComponentDirectEvent BeforeCheckChange
        {
            get
            {
                return this.beforeCheckChange ?? (this.beforeCheckChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent checkChange;

        /// <summary>
        /// Fires after a change event.
        /// Parameters
        /// item : Ext.menu.CheckItem
        /// checked : Boolean
        /// </summary>
        [ListenerArgument(0, "item", typeof(CheckMenuItem), "this")]
        [ListenerArgument(1, "checked", typeof(bool), "checked")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("checkchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a change event.")]
        public virtual ComponentDirectEvent CheckChange
        {
            get
            {
                return this.checkChange ?? (this.checkChange = new ComponentDirectEvent(this));
            }
        }
    }
}