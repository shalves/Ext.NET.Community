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
    public partial class DragTrackerDirectEvents : ComponentDirectEvents
    {
        public DragTrackerDirectEvents() { }

        public DragTrackerDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforestart;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestart", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeStart
        {
            get
            {
                if (this.beforestart == null)
                {
                    this.beforestart = new ComponentDirectEvent(this);
                }

                return this.beforestart;
            }
        }

        private ComponentDirectEvent drag;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drag", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Drag
        {
            get
            {
                if (this.drag == null)
                {
                    this.drag = new ComponentDirectEvent(this);
                }

                return this.drag;
            }
        }

        private ComponentDirectEvent dragend;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragend", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent DragEnd
        {
            get
            {
                if (this.dragend == null)
                {
                    this.dragend = new ComponentDirectEvent(this);
                }

                return this.dragend;
            }
        }

        private ComponentDirectEvent dragstart;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragstart", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent DragStart
        {
            get
            {
                if (this.dragstart == null)
                {
                    this.dragstart = new ComponentDirectEvent(this);
                }

                return this.dragstart;
            }
        }

        private ComponentDirectEvent mousedown;

        /// <summary>
        /// Fires when the mouse button is pressed down, but before a drag operation begins. The drag operation begins after either the mouse has been moved by tolerance pixels, or after the autoStart timer fires.
        /// Return false to veto the drag operation.
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseDown
        {
            get
            {
                if (this.mousedown == null)
                {
                    this.mousedown = new ComponentDirectEvent(this);
                }

                return this.mousedown;
            }
        }

        private ComponentDirectEvent mousemove;

        /// <summary>
        /// Fired when the mouse is moved. Returning false cancels the drag operation.
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousemove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseMove
        {
            get
            {
                if (this.mousemove == null)
                {
                    this.mousemove = new ComponentDirectEvent(this);
                }

                return this.mousemove;
            }
        }

        private ComponentDirectEvent mouseup;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseUp
        {
            get
            {
                if (this.mouseup == null)
                {
                    this.mouseup = new ComponentDirectEvent(this);
                }

                return this.mouseup;
            }
        }

        private ComponentDirectEvent mouseout;

        /// <summary>
        /// Fires when the mouse exits the DragTracker's target element (or if delegate is used, when the mouse exits a delegate element).
        /// Only available when trackOver is true
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseout", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseOut
        {
            get
            {
                if (this.mouseout == null)
                {
                    this.mouseout = new ComponentDirectEvent(this);
                }

                return this.mouseout;
            }
        }

        private ComponentDirectEvent mouseover;

        /// <summary>
        /// Fires when the mouse enters the DragTracker's target element (or if delegate is used, when the mouse enters a delegate element).
        /// Only available when trackOver is true
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// target : HTMLElement
        ///     The element mouseovered.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [ListenerArgument(2, "target", typeof(object), "The element mouseovered.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent MouseOver
        {
            get
            {
                if (this.mouseover == null)
                {
                    this.mouseover = new ComponentDirectEvent(this);
                }

                return this.mouseover;
            }
        }
    }
}
