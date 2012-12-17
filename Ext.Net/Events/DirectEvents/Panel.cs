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
    public partial class PanelDirectEvents : ContainerDirectEvents
    {
        public PanelDirectEvents() { }

        public PanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeClose;

        /// <summary>
        /// Fires before the user closes the panel. Return false from any listener to stop the close event being fired
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel being closed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the user closes the panel. Return false from any listener to stop the close event being fired")]
        public virtual ComponentDirectEvent BeforeClose
        {
            get
            {
                return this.beforeClose ?? (this.beforeClose = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeCollapse;

        /// <summary>
        /// Fires before this panel is collapsed. Return false to prevent the collapse.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel being collapsed.
        /// direction : string
        ///    The direction of the collapse.
        /// animate : bool
        ///    True if the collapse is animated, else false.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "the Panel being collapsed.")]
        [ListenerArgument(1, "direction", typeof(bool), "")]
        [ListenerArgument(2, "animate", typeof(bool), "True if the collapse is animated, else false.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this panel is collapsed. Return false to prevent the collapse.")]
        public virtual ComponentDirectEvent BeforeCollapse
        {
            get
            {
                return this.beforeCollapse ?? (this.beforeCollapse = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeExpand;

        /// <summary>
        /// Fires before this panel is expanded. Return false to prevent the expand.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel being expanded.
        /// animate : bool
        ///    True if the expand is animated, else false.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel being expanded.")]
        [ListenerArgument(1, "animate", typeof(bool), "True if the expand is animated, else false.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this panel is expanded. Return false to prevent the expand.")]
        public virtual ComponentDirectEvent BeforeExpand
        {
            get
            {
                return this.beforeExpand ?? (this.beforeExpand = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent bodyResize;

        /// <summary>
        /// Fires after the Panel has been resized.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     the Panel which has been resized.
        /// width : Number
        ///     The Panel body's new width.
        /// height : Number
        ///     The Panel body's new height.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel which has been resized.")]
        [ListenerArgument(1, "width", typeof(int), "The Panel's new width.")]
        [ListenerArgument(2, "height", typeof(int), "The Panel's new height.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bodyresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been resized.")]
        public virtual ComponentDirectEvent BodyResize
        {
            get
            {
                return this.bodyResize ?? (this.bodyResize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent close;

        /// <summary>
        /// Fires when the user closes the panel.
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been closed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("close", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user closes the panel.")]
        public virtual ComponentDirectEvent Close
        {
            get
            {
                return this.close ?? (this.close = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent collapse;

        /// <summary>
        /// Fires after the Panel has been collapsed.
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been collapsed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been collapsed.")]
        public virtual ComponentDirectEvent Collapse
        {
            get
            {
                return this.collapse ?? (this.collapse = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent expand;

        /// <summary>
        /// Fires after the Panel has been expanded.
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been expanded.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been expanded.")]
        public virtual ComponentDirectEvent Expand
        {
            get
            {
                return this.expand ?? (this.expand = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent titleChange;

        /// <summary>
        /// Fires after the Panel title has been set or changed.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel which has had its title changed.
        /// newTitle : String
        ///     The new title.
        /// oldTitle : String
        ///     The previous panel title.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel which has had its title changed.")]
        [ListenerArgument(1, "newTitle", typeof(string), "new title.")]
        [ListenerArgument(2, "oldTitle", typeof(string), "old title.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("titlechange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel title has been set or changed.")]
        public virtual ComponentDirectEvent TitleChange
        {
            get
            {
                return this.titleChange ?? (this.titleChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent iconClsChange;

        /// <summary>
        /// Fires after the Panel icon class has been set or changed.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel which has the iconCls changed.
        /// newIconCls : string
        ///     The new iconCls.
        /// oldIconCls : string
        ///     The previous panel iconCls.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "newIconCls", typeof(string))]
        [ListenerArgument(2, "oldIconCls", typeof(string))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iconclschange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel icon class has been set or changed.")]
        public virtual ComponentDirectEvent IconClsChange
        {
            get
            {
                return this.iconClsChange ?? (this.iconClsChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent iconChange;

        /// <summary>
        /// Fires after the Panel icon has been set or changed.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel which has the icon changed.
        /// newIcon : string
        ///     The path to the new icon image.
        /// oldIcon : string
        ///     The path to the previous panel icon image.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "newIcon", typeof(string))]
        [ListenerArgument(2, "oldIcon", typeof(string))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iconchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel icon has been set or changed.")]
        public virtual ComponentDirectEvent IconChange
        {
            get
            {
                return this.iconChange ?? (this.iconChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent _float;

        /// <summary>
        /// Fires after a collapsed Panel has been "floated" by clicking on it's header. Only applicable when the Panel is an item in a Border Layout.
        /// Parameters
        /// item : Ext.panel.Panel        
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("float", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a collapsed Panel has been \"floated\" by clicking on it's header. Only applicable when the Panel is an item in a Border Layout.")]
        public virtual ComponentDirectEvent Float
        {
            get
            {
                return this._float ?? (this._float = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent unfloat;

        /// <summary>
        /// Fires after a "floated" Panel has returned to it's collapsed state as a result of the mouse leaving the Panel. Only applicable when the Panel is an item in a Border Layout.
        /// Parameters
        /// item : Ext.panel.Panel        
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("unfloat", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a \"floated\" Panel has returned to it's collapsed state as a result of the mouse leaving the Panel. Only applicable when the Panel is an item in a Border Layout.")]
        public virtual ComponentDirectEvent Unfloat
        {
            get
            {
                return this.unfloat ?? (this.unfloat = new ComponentDirectEvent(this));
            }
        }
    }
}