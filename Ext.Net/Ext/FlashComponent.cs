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
using System.Drawing;
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// A simple Component for displaying an Adobe Flash SWF movie. The movie will be sized and can participate in layout like any other Component.
    /// 
    /// Configuration
    /// 
    /// This component allows several options for configuring how the target Flash movie is embedded. The most important is the required url which points to the location of the Flash movie to load. Other configurations include:
    /// 
    /// backgroundColor
    /// wmode
    /// flashVars
    /// flashParams
    /// flashAttributes
    /// </summary>
    [Meta]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(FlashComponent), "Build.ToolboxIcons.FlashComponent.bmp")]
    [ToolboxData("<{0}:FlashComponent runat=\"server\"></{0}:FlashComponent>")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A Flash AbstractComponent")]
    public partial class FlashComponent : ComponentBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FlashComponent() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "flash";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.flash.Component";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;

                baseList.Add(new ClientScriptItem(typeof(FlashComponent), "Ext.Net.Build.Ext.Net.extnet.swfobject.js", "/extnet/swfobject.js"));

                return baseList;
            }
        }

        /// <summary>
        /// The background color of the SWF movie. Defaults to '#ffffff' (white).
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [DefaultValue("#ffffff")]
        [NotifyParentProperty(true)]
        [Description("The background color. Defaults to '#ffffff' (white).")]
        public virtual string BackgroundColor
        {
            get
            {
                return this.State.Get<string>("BackgroundColor", "#ffffff");
            }
            set
            {
                this.State.Set("BackgroundColor", value);
            }
        }

        /// <summary>
        /// True to prompt the user to install flash if not installed. Note that this uses Ext.FlashComponent.EXPRESS_INSTALL_URL, which should be set to the local resource. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. FlashComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prompt the user to install flash if not installed. Note that this uses Ext.FlashComponent.EXPRESS_INSTALL_URL, which should be set to the local resource. Defaults to false.")]
        public virtual bool ExpressInstall 
        {
            get
            {
                return this.State.Get<bool>("ExpressInstall", false);
            }
            set
            {
                this.State.Set("ExpressInstall", value);
            }
        }

        /// <summary>
        /// Indicates the version the flash content was published for. Defaults to '9.0.45'.
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [DefaultValue("9.0.45")]
        [Description("Indicates the version the flash content was published for. Defaults to '9.0.45'.")]
        public virtual string FlashVersion
        {
            get
            {
                return this.State.Get<string>("FlashVersion", "9.0.45");
            }
            set
            {
                this.State.Set("FlashVersion", value);
            }
        }

        /// <summary>
        /// The URL of the swf object to include. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Url)]
        [Category("5. FlashComponent")]
        [DefaultValue("")]
        [Description("The URL of the swf object to include. Defaults to undefined.")]
        public virtual string Url
        {
            get
            {
                return this.State.Get<string>("Url", "");
            }
            set
            {
                this.State.Set("Url", value);
            }
        }

        private ParameterCollection flashVars;

        /// <summary>
        /// A set of key value pairs to be passed to the flash object as flash variables.
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A set of key value pairs to be passed to the flash object as flash variables.")]
        public virtual ParameterCollection FlashVars
        {
            get
            {
                if (this.flashVars == null)
                {
                    this.flashVars = new ParameterCollection();
                    this.flashVars.Owner = this;
                }

                return this.flashVars;
            }
        }

        private ParameterCollection flashParams;

        /// <summary>
        /// A set of key value pairs to be passed to the flash object as parameters.
        /// Possible parameters can be found here: http://kb2.adobe.com/cps/127/tn_12701.html
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A set of key value pairs to be passed to the flash object as parameters.")]
        public virtual ParameterCollection FlashParams
        {
            get
            {
                if (this.flashParams == null)
                {
                    this.flashParams = new ParameterCollection();
                    this.flashParams.Owner = this;
                }

                return this.flashParams;
            }
        }

        /// <summary>
        /// The height of the embedded SWF movie inside the component. Defaults to "100%" so that the movie matches the height of the component.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. FlashComponent")]
        [DefaultValue("")]
        [Description("The height of the embedded SWF movie inside the component. Defaults to \"100%\" so that the movie matches the height of the component.")]
        public virtual string SwfHeight
        {
            get
            {
                return this.State.Get<string>("SwfHeight", "");
            }
            set
            {
                this.State.Set("SwfHeight", value);
            }
        }

        /// <summary>
        /// The width of the embedded SWF movie inside the component. Defaults to "100%" so that the movie matches the width of the component.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. FlashComponent")]
        [DefaultValue("")]
        [Description("The width of the embedded SWF movie inside the component. Defaults to \"100%\" so that the movie matches the width of the component.")]
        public virtual string SwfWidth
        {
            get
            {
                return this.State.Get<string>("SwfWidth", "");
            }
            set
            {
                this.State.Set("SwfWidth", value);
            }
        }

        /// <summary>
        /// The wmode of the flash object. This can be used to control layering. Set to 'transparent' to ignore the backgroundColor and make the background of the Flash movie transparent.
        /// </summary>
        [Meta]
        [ConfigOption("wmode")]
        [Category("5. FlashComponent")]
        [DefaultValue("")]
        [Description("The wmode of the flash object. This can be used to control layering. Set to 'transparent' to ignore the backgroundColor and make the background of the Flash movie transparent.")]
        public virtual string WMode
        {
            get
            {
                return this.State.Get<string>("WMode", "");
            }
            set
            {
                this.State.Set("WMode", value);
            }
        }

        private FlashComponentListeners listeners;

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
        public FlashComponentListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FlashComponentListeners();
                }

                return this.listeners;
            }
        }

        private FlashComponentDirectEvents directEvents;

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
        public FlashComponentDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FlashComponentDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}