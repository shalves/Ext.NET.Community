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
    public partial class DragTrackerListeners : ComponentListeners
    {
        private ComponentListener beforestart;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestart", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeStart
        {
            get
            {
                if (this.beforestart == null)
                {
                    this.beforestart = new ComponentListener();
                }

                return this.beforestart;
            }
        }
        
        private ComponentListener drag;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("drag", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener Drag
        {
            get
            {
                if (this.drag == null)
                {
                    this.drag = new ComponentListener();
                }

                return this.drag;
            }
        }

        private ComponentListener dragend;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener DragEnd
        {
            get
            {
                if (this.dragend == null)
                {
                    this.dragend = new ComponentListener();
                }

                return this.dragend;
            }
        }

        private ComponentListener dragstart;

        /// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragstart", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener DragStart
        {
            get
            {
                if (this.dragstart == null)
                {
                    this.dragstart = new ComponentListener();
                }

                return this.dragstart;
            }
        }

        private ComponentListener mousedown;

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
        [ConfigOption("mousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener MouseDown
        {
            get
            {
                if (this.mousedown == null)
                {
                    this.mousedown = new ComponentListener();
                }

                return this.mousedown;
            }
        }

        private ComponentListener mousemove;

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
        [ConfigOption("mousemove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener MouseMove
        {
            get
            {
                if (this.mousemove == null)
                {
                    this.mousemove = new ComponentListener();
                }

                return this.mousemove;
            }
        }

        private ComponentListener mouseup;

		/// <summary>
        /// Parameters
        /// item : Object
        /// e : Object
        ///     event object
		/// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "Event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener MouseUp
        {
            get
            {
                if (this.mouseup == null)
                {
                    this.mouseup = new ComponentListener();
                }

                return this.mouseup;
            }
        }

        private ComponentListener mouseout;

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
        [ConfigOption("mouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener MouseOut
        {
            get
            {
                if (this.mouseout == null)
                {
                    this.mouseout = new ComponentListener();
                }

                return this.mouseout;
            }
        }

        private ComponentListener mouseover;

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
        [ConfigOption("mouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener MouseOver
        {
            get
            {
                if (this.mouseover == null)
                {
                    this.mouseover = new ComponentListener();
                }

                return this.mouseover;
            }
        }
    }
}