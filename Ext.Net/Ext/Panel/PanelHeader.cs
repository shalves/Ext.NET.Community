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
 * @version   : 2.1.0 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Drawing;
using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// Simple header class which is used for on Ext.panel.Panel and Ext.window.Window.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("Simple header class which is used for on Ext.panel.Panel and Ext.window.Window.")]
    public partial class PanelHeader : AbstractContainer, IIcon
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public PanelHeader() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.panel.Header";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "header";
            }
        }

        /// <summary>
        /// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("5. PanelHeader")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        [Description("")]
        protected internal virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "#" + this.Icon.ToString();
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Category("5. PanelHeader")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the panel header icon (defaults to '').")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// Path to image for an icon in the header. Used for displaying an icon to the left of a title.
        /// </summary>
        [Meta]
        [ConfigOption("icon", JsonMode.Url)]
        [DirectEventUpdate(MethodName = "SetIconPath")]
        [Category("5. PanelHeader")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the panel header icon (defaults to '').")]
        public virtual string IconPath
        {
            get
            {
                return this.State.Get<string>("IconPath", "");
            }
            set
            {
                this.State.Set("IconPath", value);
            }
        }

        /// <summary>
        /// Set a title for the panel's header. See Ext.panel.Header.title.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetTitle")]
        [ConfigOption]
        [Category("5. PanelHeader")]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("Set a title for the panel's header. See Ext.panel.Header.title.")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", "");
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        /// <summary>
        /// May be "left", "right" or "center". The alignment of the title text within the available space between the icon and the tools. Defaults to: "left"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. PanelHeader")]
        [DefaultValue(TitleAlign.Default)]
        [NotifyParentProperty(true)]
        [Description("May be \"left\", \"right\" or \"center\". The alignment of the title text within the available space between the icon and the tools. Defaults to: \"left\"")]
        public TitleAlign TitleAlign
        {
            get
            {
                return this.State.Get<TitleAlign>("TitleAlign", TitleAlign.Default);
            }
            set
            {
                State["TitleAlign"] = value;
            }
        }

        private PanelHeaderListeners listeners;

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
        public PanelHeaderListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new PanelHeaderListeners());
            }
        }

        private PanelHeaderDirectEvents directEvents;

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
        public PanelHeaderDirectEvents DirectEvents
        {
            get
            {
                return this.directEvents ?? (this.directEvents = new PanelHeaderDirectEvents(this));
            }
        }

        /// <summary>
        /// Set the icon for the panel's header. See Ext.panel.Header.icon. It will fire the iconchange event after completion.
        /// </summary>
        /// <param name="cls">The new icon path</param>
        protected virtual void SetIconPath(string path)
        {
            this.Call("setIcon", path);
        }

        /// <summary>
        /// Sets the CSS class that provides the icon image for this panel. This method will replace any existing icon class if one has already been set.
        /// </summary>
        /// <param name="cls">Icon css class</param>
        protected virtual void SetIconCls(string cls)
        {
            this.Call("setIconCls", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        /// <param name="icon">New icon</param>
        protected virtual void SetIconCls(Icon icon)
        {
            this.SetIconCls(this.Icon != Icon.None ? "#" + icon.ToString() : "");
        }

        /// <summary>
        /// Sets the title text for the panel and optionally the icon class.
        /// </summary>
        /// <param name="title">New title</param>
        public virtual void SetTitle(string title)
        {
            this.Call("setTitle", title);
        }

        #region Члены IIcon

        /// <summary>
        /// 
        /// </summary>
        public List<Icon> Icons
        {
            get 
            {
                return new List<Icon>(1) { this.Icon };
            }
        }

        #endregion
    }
}