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

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class MvcResourceManagerConfig
    {
        private bool cleanResourceUrl = true;

        /// <summary>
        /// 
        /// </summary>
        public bool CleanResourceUrl
        {
            get
            {
                return this.cleanResourceUrl;
            }
            set
            {
                this.cleanResourceUrl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ResourcePath
        {
            get;
            set;
        }

        private ScriptMode scriptMode = ScriptMode.Release;

        /// <summary>
        /// 
        /// </summary>
        public ScriptMode ScriptMode
        {
            get
            {
                return this.scriptMode;
            }
            set
            {
                this.scriptMode = value;
            }
        }

        private ResourceLocationType renderScripts = ResourceLocationType.Embedded;

        /// <summary>
        /// 
        /// </summary>
        public ResourceLocationType RenderScripts
        {
            get
            {
                return this.renderScripts;
            }
            set
            {
                this.renderScripts = value;
            }
        }

        private ResourceLocationType renderStyles = ResourceLocationType.Embedded;

        /// <summary>
        /// 
        /// </summary>
        public ResourceLocationType RenderStyles
        {
            get
            {
                return this.renderStyles;
            }
            set
            {
                this.renderStyles = value;
            }
        }

        private Theme theme = Theme.Default;

        /// <summary>
        /// 
        /// </summary>
        public Theme Theme
        {
            get
            {
                return this.theme;
            }
            set
            {
                this.theme = value;
            }
        }

        private bool quickTips = true;

        /// <summary>
        /// 
        /// </summary>
        public bool QuickTips
        {
            get
            {
                return this.quickTips;
            }
            set
            {
                this.quickTips = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Locale
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Namespace
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDMode IDMode
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FormID
        {
            get;
            set;
        }
        
        private ResourceManagerListeners listeners;

        /// <summary>
        /// 
        /// </summary>
        public ResourceManagerListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new ResourceManagerListeners());
            }
            internal set
            {
                this.listeners = value;
            }
        }

        private ListenerCollection customListeners;

        /// <summary>
        /// 
        /// </summary>
        public ListenerCollection CustomListeners
        {
            get
            {
                return this.customListeners ?? (this.customListeners = new ListenerCollection());
            }
            internal set
            {
                this.customListeners = value;
            }
        }

        private ResourceManagerDirectEvents directEvents;

        /// <summary>
        /// 
        /// </summary>
        public ResourceManagerDirectEvents DirectEvents
        {
            get
            {
                return this.directEvents ?? (this.directEvents = new ResourceManagerDirectEvents());
            }
            internal set
            {
                this.directEvents = value;
            }
        }

        private DirectEventCollection customDirectEvents;

        /// <summary>
        /// 
        /// </summary>
        public DirectEventCollection CustomDirectEvents
        {
            get
            {
                return this.customDirectEvents ?? (this.customDirectEvents = new DirectEventCollection());
            }
            internal set
            {
                this.customDirectEvents = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public StartupMask StartupMask
        {
            get;
            set;
        }

        private bool showWarningOnAjaxFailure = true;

        /// <summary>
        /// 
        /// </summary>
        public bool ShowWarningOnAjaxFailure
        {
            get
            {
                return this.showWarningOnAjaxFailure;
            }
            set
            {
                this.showWarningOnAjaxFailure = value;
            }
        }

        private ClientProxy directMethodProxy = ClientProxy.Default;
        public virtual ClientProxy DirectMethodProxy
        {
            get
            {
                return this.directMethodProxy;
            }
            set
            {
                this.directMethodProxy = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DirectMethodNamespace
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MvcResourceManager : ResourceManager
    {
        private static ResourceManager defaultManager = new ResourceManager();
        
        private static ResourceManager Default
        {
            get
            {
                return MvcResourceManager.defaultManager;
            }
        }

        public static MvcResourceManager GetMvcInstance()
        {
            if (HttpContext.Current == null)
            {
                return null;
            }

            return HttpContext.Current.Items[typeof(MvcResourceManager)] as MvcResourceManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onready"></param>
        protected override void AddInitAchorTag(StringBuilder onready)
        {            
            onready.Append("<#:anchor id='ext.net.global.script.before' />");            
            
            base.AddInitAchorTag(onready);

            if (this.RenderStyles != ResourceLocationType.None)
            {
                onready.Append("<#:anchor id='ext.net.global.icons' />");
            }
            onready.Append("<#:anchor id='ext.net.global.script.after' />");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string BuildStyleBlock()
        {
            string s = base.BuildStyleBlock();
            return s + (this.RenderStyles != ResourceLocationType.None ? "<#:anchor id='ext.net.global.styles' />" : "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ignoreRenderScriptsMode"></param>
        /// <returns></returns>
        public override string BuildScripts(bool ignoreRenderScriptsMode)
        {
            string s = base.BuildScripts(ignoreRenderScriptsMode);
            return s + (this.RenderScripts != ResourceLocationType.None ? "<#:anchor id='ext.net.global.scripts' />" : "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string SelfRender()
        {
            this.ShareConfig();
            return base.SelfRender();
        }

        /// <summary>
        /// 
        /// </summary>
        public static MvcResourceManagerConfig SharedConfig
        {
            get
            {
                var config = HttpContext.Current.Items["Ext.Net.GlobalManagerConfig"];

                return config == null ? new MvcResourceManagerConfig() : (MvcResourceManagerConfig)config;
            }
            set
            {
                HttpContext.Current.Items["Ext.Net.GlobalManagerConfig"] = value;
            }
        }

        public static void RegisterLocale(string localeCode)
        {
            MvcResourceManager.Default.RegisterLocale(localeCode);
        }

        public static string GetThemeUrl(Theme theme)
        {
            return MvcResourceManager.Default.GetThemeUrl(theme);
        }
        
        public static void SetTheme(Theme theme)
        {
            string themeName = theme == Ext.Net.Theme.Default ? "blue" : theme.ToString().ToLowerInvariant();
            ResourceManager.AddInstanceScript("Ext.net.ResourceMgr.setTheme(\"{0}\", \"{1}\");", MvcResourceManager.GetThemeUrl(theme), themeName);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void ShareConfig()
        {
            HttpContext.Current.Items["Ext.Net.GlobalManagerConfig"] = new MvcResourceManagerConfig
            {
                CleanResourceUrl = this.CleanResourceUrl,
                ResourcePath = this.ResourcePath,
                ScriptMode = this.ScriptMode,
                RenderScripts = this.RenderScripts,
                RenderStyles = this.RenderStyles,
                Theme = this.Theme,
                QuickTips = this.QuickTips,
                Locale = this.Locale,
                Namespace = this.Namespace,
                IDMode = this.IDMode,
                FormID = this.FormID,
                Listeners = this.Listeners,
                CustomListeners = this.CustomListeners,
                DirectEvents = this.DirectEvents,
                CustomDirectEvents = this.CustomDirectEvents
            };
        }

        public static void MarkAsMVC()
        {
            if (HttpContext.Current.Application["Ext.Net.MVC.IsMVC"] == null)
            {
                HttpContext.Current.Application["Ext.Net.MVC.IsMVC"] = new object();
            }
        }

        public static bool IsMVC
        {
            get
            {
                return HttpContext.Current.Application["Ext.Net.MVC.IsMVC"] != null;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class MvcResourceManagerBuilder : IHtmlString
    {
        private MvcResourceManagerConfig config;
        private MvcResourceManager mgr;

        /// <summary>
        /// 
        /// </summary>
        public MvcResourceManagerBuilder() : this(null)
        {            
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public MvcResourceManagerBuilder(MvcResourceManagerConfig config)
        {
            MvcResourceManager.MarkAsMVC();
            this.config = config ?? new MvcResourceManagerConfig();
            this.mgr = new MvcResourceManager();
            this.mgr.IsSelfRender = true;

            if(HttpContext.Current != null)
            {
                HttpContext.Current.Items[typeof(MvcResourceManager)] = this.mgr;
            }

            this.config.Listeners = this.mgr.Listeners;
            this.config.CustomListeners = this.mgr.CustomListeners;
            this.config.DirectEvents = this.mgr.DirectEvents;
            this.config.CustomDirectEvents = this.mgr.CustomDirectEvents;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cleanResourceUrl"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder CleanResourceUrl(bool cleanResourceUrl)
        {
            this.config.CleanResourceUrl = cleanResourceUrl;
            this.mgr.CleanResourceUrl = cleanResourceUrl;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder ResourcePath(string resourcePath)
        {
            this.config.ResourcePath = resourcePath;
            this.mgr.ResourcePath = resourcePath;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptMode"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder ScriptMode(ScriptMode scriptMode)
        {
            this.config.ScriptMode = scriptMode;
            this.mgr.ScriptMode = scriptMode;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderScripts"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder RenderScripts(ResourceLocationType renderScripts)
        {
            this.config.RenderScripts = renderScripts;
            this.mgr.RenderScripts = renderScripts;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderStyles"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder RenderStyles(ResourceLocationType renderStyles)
        {
            this.config.RenderStyles = renderStyles;
            this.mgr.RenderStyles = renderStyles;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder Theme(Theme theme)
        {
            this.config.Theme = theme;
            this.mgr.Theme = theme;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quickTips"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder QuickTips(bool quickTips)
        {
            this.config.QuickTips = quickTips;
            this.mgr.QuickTips = quickTips;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder Locale(string locale)
        {
            this.config.Locale = locale;
            this.mgr.Locale = locale;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMode"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder IDMode(IDMode idMode)
        {
            this.config.IDMode = idMode;
            this.mgr.IDMode = idMode;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder Namespace(string ns)
        {
            this.config.Namespace = ns;
            this.mgr.Namespace = ns;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder FormID(string formID)
        {
            this.config.FormID = formID;
            this.mgr.FormID = formID;
            return this;
        }

        public virtual MvcResourceManagerBuilder Listeners(Action<ResourceManagerListeners> action)
        {
            action(this.config.Listeners);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomListeners(Action<ListenerCollection> action)
        {
            action(this.config.CustomListeners);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomListeners(Listener listener)
        {
            this.config.CustomListeners.Add(listener);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomListeners(IEnumerable<Listener> listeners)
        {
            this.config.CustomListeners.AddRange(listeners);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomListeners(params Listener[] listeners)
        {
            this.config.CustomListeners.AddRange(listeners);
            return this;
        }

        public virtual MvcResourceManagerBuilder DirectEvents(Action<ResourceManagerDirectEvents> action)
        {
            action(this.config.DirectEvents);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomDirectEvents(Action<DirectEventCollection> action)
        {
            action(this.config.CustomDirectEvents);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomDirectEvents(DirectEvent directEvent)
        {
            this.config.CustomDirectEvents.Add(directEvent);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomDirectEvents(IEnumerable<DirectEvent> directEvents)
        {
            this.config.CustomDirectEvents.AddRange(directEvents);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomDirectEvents(params DirectEvent[] directEvents)
        {
            this.config.CustomDirectEvents.AddRange(directEvents);
            return this;
        }

        public virtual MvcResourceManagerBuilder StartupMask(StartupMask mask)
        {
            this.config.StartupMask = mask;
            this.mgr.StartupMask = mask;
            return this;
        }

        public virtual MvcResourceManagerBuilder ShowWarningOnAjaxFailure(bool value)
        {
            this.config.ShowWarningOnAjaxFailure = value;
            this.mgr.ShowWarningOnAjaxFailure = value;
            return this;
        }

        public virtual MvcResourceManagerBuilder DirectMethodProxy(ClientProxy value)
        {
            this.config.DirectMethodProxy = value;
            this.mgr.DirectMethodProxy = value;
            return this;
        }

        public virtual MvcResourceManagerBuilder DirectMethodNamespace(string value)
        {
            this.config.DirectMethodNamespace = value;
            this.mgr.DirectMethodNamespace = value;
            return this;
        }

        #region IHtmlString

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToHtmlString()
        {
            mgr.ViewContext = Ext.Net.X.Builder.HtmlHelper.ViewContext;
            return mgr.SelfRender();
        }

        #endregion
    }
}
