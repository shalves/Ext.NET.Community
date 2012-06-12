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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A TabPanel with grouping support.
    /// </summary>
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(GroupTabPanel), "Build.ToolboxIcons.GroupTabPanel.bmp")]
    [ToolboxData("<{0}:GroupTabPanel runat=\"server\" Title=\"GroupTabPanel\"><Items></Items></{0}:GroupTabPanel>")]
    [Description("")]
    public partial class GroupTabPanel : AbstractContainer, IXPostBackDataHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientStyleItem(typeof(GroupTabPanel), "Ext.Net.Build.Ext.Net.ux.resources.GroupTabPanel-embedded.css", "/ux/resources/GroupTabPanel.css"));                
                baseList.Add(new ClientScriptItem(typeof(GroupTabPanel), "Ext.Net.Build.Ext.Net.ux.grouptabpanel.GroupTabPanel.js", "/ux/grouptabpanel/GroupTabPanel.js"));

                return baseList;
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
                return "grouptabpanel";
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
                return "Ext.ux.GroupTabPanel";
            }
        }

        /// <summary>
        /// Deferred Render
        /// </summary>
        [ConfigOption]
        [Category("7. GroupTabPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Deferred Render")]
        public virtual bool DeferredRender
        {
            get
            {
                return this.State.Get<bool>("DeferredRender", false);
            }
            set
            {
                this.State.Set("DeferredRender", value);
            }
        }

        /// <summary>
        /// Active group
        /// </summary>
        [Category("7. GroupTabPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveGroup")]
        [Description("Active group")]
        public virtual string ActiveGroup
        {
            get
            {
                return this.State.Get<string>("ActiveGroup", "");
            }
            set
            {
                this.State.Set("ActiveGroup", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("7. GroupTabPanel")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveGroup")]
        public virtual int ActiveGroupIndex
        {
            get
            {
                return this.State.Get<int>("ActiveGroupIndex", (this.Items.Count == 0) ? -1 : 0);
            }
            set
            {
                this.State.Set("ActiveGroupIndex", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("activeGroup", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected internal string ActiveGroupProxy
        {
            get
            {
                if (this.ActiveGroup.IsNotEmpty())
                {
                    return JSON.Serialize(this.ActiveGroup);
                }

                if (this.ActiveGroupIndex < 0)
                {
                    return "";
                }

                return this.ActiveGroupIndex.ToString();
            }
        }

        /// <summary>
        /// Active tab
        /// </summary>
        [Category("7. GroupTabPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        [Description("Active tab")]
        public virtual string ActiveTab
        {
            get
            {
                return this.State.Get<string>("ActiveTab", "");
            }
            set
            {
                this.State.Set("ActiveTab", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("7. GroupTabPanel")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        public virtual int ActiveTabIndex
        {
            get
            {
                return this.State.Get<int>("ActiveTabIndex", -1);
            }
            set
            {
                this.State.Set("ActiveTabIndex", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("activeTab", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected internal string ActiveTabProxy
        {
            get
            {
                if (this.ActiveTab.IsNotEmpty())
                {
                    return JSON.Serialize(this.ActiveTab);
                }

                if (this.ActiveTabIndex < 0)
                {
                    return "";
                }

                return this.ActiveTabIndex.ToString();
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //[Meta]
        //[ConfigOption(JsonMode.ToLower)]
        //[Category("7. GroupTabPanel")]
        //[DefaultValue(TabAlign.Left)]
        //[NotifyParentProperty(true)]
        //public virtual TabAlign TabPosition
        //{
        //    get
        //    {
        //        return this.State.Get<TabAlign>("TabPosition", TabAlign.Left);
        //    }
        //    set
        //    {
        //        this.State.Set("TabPosition", value);
        //    }
        //}

        /// <summary>
        /// The initial width in pixels of each new tab (defaults to 120).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GroupTabPanel")]
        [DefaultValue(typeof(Unit), "120")]
        [NotifyParentProperty(true)]
        [Description("The initial width in pixels of each new tab (defaults to 120).")]
        public virtual Unit TabWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(State["TabWidth"], Unit.Pixel(120), "TabWidth");
            }
            set
            {
                this.State.Set("TabWidth", value);
            }
        }

        private GroupTabPanelListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public GroupTabPanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GroupTabPanelListeners();
                }

                return this.listeners;
            }
        }

        private GroupTabPanelDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [ConfigOption("directEvents", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Server-side Ajax Event Handlers")]
        public GroupTabPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GroupTabPanelDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        private static readonly object EventGroupChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler GroupChanged
        {
            add
            {
                this.Events.AddHandler(EventGroupChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventGroupChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnGroupChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventGroupChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static readonly object EventTabChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler TabChanged
        {
            add
            {
                this.Events.AddHandler(EventTabChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventTabChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnTabChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTabChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        private int stateChanges;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_ActiveTab")];

            if (val.IsNotEmpty())
            {
                int activeTabNum;
                string[] at = val.Split(':');

                if (int.TryParse(at.Length > 1 ? at[1] : at[0], out activeTabNum))
                {
                    if (activeTabNum > -1 && (this.ActiveTabIndex != activeTabNum || this.ActiveTab != at[0]))
                    {
                        this.State.Suspend();
                        this.ActiveTab = at[0];
                        this.ActiveTabIndex = activeTabNum;
                        this.State.Resume();
                        this.stateChanges = 1;
                    }
                }
            }
                

            val = postCollection[this.ConfigID.ConcatWith("_ActiveGroup")];

            if (val.IsNotEmpty())
            {
                int activeGroupNum;
                string[] at = val.Split(':');

                if (int.TryParse(at.Length > 1 ? at[1] : at[0], out activeGroupNum))
                {
                    if (activeGroupNum > -1 && (this.ActiveGroupIndex != activeGroupNum || this.ActiveGroup != at[0]))
                    {
                        this.State.Suspend();
                        this.ActiveGroup = at[0];
                        this.ActiveGroupIndex = activeGroupNum;
                        this.State.Resume();
                        
                        this.stateChanges = this.stateChanges == 1 ? 3 : 2;
                    }
                }
            }

            return this.stateChanges != 0;
        }

        protected virtual void RaisePostDataChangedEvent()
        {
            if(this.stateChanges > 1) 
            {
                this.OnGroupChanged(EventArgs.Empty);
            }

            if(this.stateChanges == 1 || this.stateChanges == 3) 
            {
                this.OnTabChanged(EventArgs.Empty);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void SetActiveGroup(int index)
        {
            this.Call("setActiveGroup", index);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void SetActiveGroup(AbstractComponent group)
        {
            this.SetActiveGroup(group.ClientID);            
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void SetActiveGroup(string id)
        {
            this.Call("setActiveGroup", id);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(int index)
        {
            this.Call("setActiveTab", index);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(AbstractComponent item)
        {
            this.SetActiveTab(item.ClientID);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        /// <param name="id">The id.</param>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(string id)
        {            
            this.Call("setActiveTab", id);
        }
    }
}