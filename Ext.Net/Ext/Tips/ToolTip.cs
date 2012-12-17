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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// ToolTip is a Ext.tip.Tip implementation that handles the common case of displaying a tooltip when hovering over a certain element or elements on the page. It allows fine-grained control over the tooltip's alignment relative to the target element or mouse, and the timing of when it is automatically shown and hidden.
    /// This implementation does not have a built-in method of automatically populating the tooltip's text based on the target element; you must either configure a fixed html value for each ToolTip instance, or implement custom logic (e.g. in a beforeshow event listener) to generate the appropriate tooltip content on the fly. See Ext.tip.QuickTip for a more convenient way of automatically populating and configuring a tooltip based on specific DOM attributes of each target element.
    /// 
    /// Delegation
    /// In addition to attaching a ToolTip to a single element, you can also use delegation to attach one ToolTip to many elements under a common parent. This is more efficient than creating many ToolTip instances. To do this, point the target config to a common ancestor of all the elements, and then set the delegate config to a CSS selector that will select all the appropriate sub-elements.
    /// When using delegation, it is likely that you will want to programmatically change the content of the ToolTip based on each delegate element; you can do this by implementing a custom listener for the beforeshow event. 
    /// 
    /// Alignment
    /// The following configuration properties allow control over how the ToolTip is aligned relative to the target element and/or mouse pointer:
    ///     anchor
    ///     anchorToTarget
    ///     anchorOffset
    ///     trackMouse
    ///     mouseOffset
    /// 
    /// Showing/Hiding
    /// The following configuration properties allow control over how and when the ToolTip is automatically shown and hidden:
    ///     autoHide
    ///     showDelay
    ///     hideDelay
    ///     dismissDelay
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ToolTip runat=\"server\" Title=\"Message\"></{0}:ToolTip>")]
    [ToolboxBitmap(typeof(ToolTip), "Build.ToolboxIcons.ToolTip.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("ToolTip is a Ext.tip.Tip implementation that handles the common case of displaying a tooltip when hovering over a certain element or elements on the page. It allows fine-grained control over the tooltip's alignment relative to the target element or mouse, and the timing of when it is automatically shown and hidden.")]
    public partial class ToolTip : ToolTipBase
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolTip() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.tip.ToolTip";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("3. AbstractComponent")]
        public override string XType
        {
            get
            {
                return "tooltip";
            }
        }

        private PanelListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public PanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PanelListeners();
                }

                return this.listeners;
            }
        }

        private PanelDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public PanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PanelDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}