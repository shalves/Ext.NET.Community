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
    public partial class GroupTabPanelDirectEvents : ContainerDirectEvents
    {
        public GroupTabPanelDirectEvents() { }

        public GroupTabPanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeGroupChange;

        /// <summary>
        /// Fires before a group change (activated by setActiveGroup). Return false in any listener to cancel the groupchange
        /// Parameters
        /// item : Ext.ux.GroupTabPanel
        ///     The GroupTabPanel
        /// newGroup : Ext.Component
        ///     The root group card that is about to be activated
        /// oldGroup : Ext.Component
        ///     The root group card that is currently active
        /// </summary>
        [ListenerArgument(0, "item", typeof(GroupTabPanel), "this")]
        [ListenerArgument(1, "newGroup")]
        [ListenerArgument(2, "oldGroup")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforegroupchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a group change (activated by setActiveGroup). Return false in any listener to cancel the groupchange")]
        public virtual ComponentDirectEvent BeforeGroupChange
        {
            get
            {
                return this.beforeGroupChange ?? (this.beforeGroupChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent groupChange;

        /// <summary>
        /// Fires when a new group has been activated (activated by setActiveGroup).
        /// Parameters
        /// item : Ext.ux.GroupTabPanel
        ///     The GroupTabPanel
        /// newGroup : Ext.Component
        ///     The newly activated root group item
        /// oldGroup : Ext.Component
        ///     The previously active root group item
        /// </summary>
        [ListenerArgument(0, "item", typeof(GroupTabPanel), "this")]
        [ListenerArgument(1, "newGroup")]
        [ListenerArgument(2, "oldGroup")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new group has been activated (activated by setActiveGroup).")]
        public virtual ComponentDirectEvent GroupChange
        {
            get
            {
                return this.groupChange ?? (this.groupChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeTabChange;

        /// <summary>
        /// Fires before a tab change (activated by setActiveTab). Return false in any listener to cancel the tabchange
        /// Parameters
        /// item : Ext.ux.GroupTabPanel
        ///     The GroupTabPanel
        /// newCard : Ext.Component
        ///     The card that is about to be activated
        /// oldCard : Ext.Component
        ///     The card that is currently active
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "newCard", typeof(AbstractComponent), "newCard")]
        [ListenerArgument(2, "oldCard", typeof(AbstractComponent), "oldCard")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a tab change (activated by setActiveTab). Return false in any listener to cancel the tabchange")]
        public virtual ComponentDirectEvent BeforeTabChange
        {
            get
            {
                return this.beforeTabChange ?? (this.beforeTabChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent tabChange;

        /// <summary>
        /// Fires when a new tab has been activated (activated by setActiveTab).
        /// Parameters
        /// item : Ext.ux.GroupTabPanel
        ///     The GroupTabPanel
        /// newCard : Ext.Component
        ///     The newly activated item
        /// oldCard : Ext.Component
        ///     The previously active item
        /// </summary>
        [ListenerArgument(0, "item", typeof(AbstractComponent), "this")]
        [ListenerArgument(1, "newCard", typeof(AbstractComponent), "newCard")]
        [ListenerArgument(2, "oldCard", typeof(AbstractComponent), "oldCard")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new tab has been activated (activated by setActiveTab).")]
        public virtual ComponentDirectEvent TabChange
        {
            get
            {
                return this.tabChange ?? (this.tabChange = new ComponentDirectEvent(this));
            }
        }
    }
}