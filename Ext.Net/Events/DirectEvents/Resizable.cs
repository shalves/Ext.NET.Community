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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ResizableDirectEvents : ComponentDirectEvents
    {
        public ResizableDirectEvents() { }

        public ResizableDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeResize;

        /// <summary>
        /// Fired before resize is allowed. Set enabled to false to cancel resize.
        /// Parameters
        /// item : Ext.resizer.Resizer
        /// width : Number
        ///     The start width
        /// height : Number
        ///     The start height
        /// e : Ext.EventObject
        ///     The mousedown event
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "width")]
        [ListenerArgument(2, "height")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before resize is allowed. Set enabled to false to cancel resize.")]
        public virtual ComponentDirectEvent BeforeResize
        {
            get
            {
                return this.beforeResize ?? (this.beforeResize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent resize;

        /// <summary>
        /// Fired after a resize.
        /// Parameters
        /// item : Ext.resizer.Resizer
        /// width : Number
        ///     The new width
        /// height : Number
        ///     The new height
        /// e : Ext.EventObject
        ///     The mouseup event
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "width")]
        [ListenerArgument(2, "height")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a resize.")]
        public virtual ComponentDirectEvent Resize
        {
            get
            {
                return this.resize ?? (this.resize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent resizedrag;

        /// <summary>
        /// Fires during resizing. Return false to cancel resize.
        /// Parameters
        /// item : Ext.resizer.Resizer
        /// width : Number
        ///     The new width
        /// height : Number
        ///     The new height
        /// e : Ext.EventObject
        ///     The mousedown event
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "width")]
        [ListenerArgument(2, "height")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resizedrag", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires during resizing. Return false to cancel resize.")]
        public virtual ComponentDirectEvent ResizeDrag
        {
            get
            {
                return this.resizedrag ?? (this.resizedrag = new ComponentDirectEvent(this));
            }
        }
    }
}