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
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ComponentLoader
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TComponentLoader, TBuilder> : Observable.Builder<TComponentLoader, TBuilder>
            where TComponentLoader : ComponentLoader
            where TBuilder : Builder<TComponentLoader, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TComponentLoader component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to add a unique cache-buster param to GET requests. (defaults to true)
			/// </summary>
            public virtual TBuilder DisableCaching(bool disableCaching)
            {
                this.ToComponent().DisableCaching = disableCaching;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'
			/// </summary>
            public virtual TBuilder DisableCachingParam(string disableCachingParam)
            {
                this.ToComponent().DisableCachingParam = disableCachingParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Any additional options to be passed to the request, for example timeout or headers.
			/// </summary>
            public virtual TBuilder AjaxOptions(AjaxOptions ajaxOptions)
            {
                this.ToComponent().AjaxOptions = ajaxOptions;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PassParentSize(bool passParentSize)
            {
                this.ToComponent().PassParentSize = passParentSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Event which triggers loading process. Default value is render
			/// </summary>
            public virtual TBuilder TriggerEvent(string triggerEvent)
            {
                this.ToComponent().TriggerEvent = triggerEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// TriggerEvent's control
			/// </summary>
            public virtual TBuilder TriggerControl(string triggerControl)
            {
                this.ToComponent().TriggerControl = triggerControl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Reload content on each show event.
			/// </summary>
            public virtual TBuilder ReloadOnEvent(bool reloadOnEvent)
            {
                this.ToComponent().ReloadOnEvent = reloadOnEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveD(bool removeD)
            {
                this.ToComponent().RemoveD = removeD;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to monitor complete state of the iframe instead load event using.
			/// </summary>
            public virtual TBuilder MonitorComplete(bool monitorComplete)
            {
                this.ToComponent().MonitorComplete = monitorComplete;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Callback(string callback)
            {
                this.ToComponent().Callback = callback;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to have the loader make a request as soon as it is created. Defaults to true. This argument can also be a set of options that will be passed to load is called.
			/// </summary>
            public virtual TBuilder AutoLoad(bool autoLoad)
            {
                this.ToComponent().AutoLoad = autoLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Params that will be attached to every request. These parameters will not be overridden by any params in the load options. Defaults to null.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder BaseParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().BaseParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A function to be called when a load request fails.
			/// </summary>
            public virtual TBuilder Failure(string failure)
            {
                this.ToComponent().Failure = failure;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True or a Ext.LoadMask configuration to enable masking during loading. Defaults to false.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder LoadMask(Action<LoadMask> action)
            {
                action(this.ToComponent().LoadMask);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Any params to be attached to the Ajax request. These parameters will be overridden by any params in the load options. Defaults to null.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Params(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Params);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to parse any inline script tags in the response.
			/// </summary>
            public virtual TBuilder Scripts(bool scripts)
            {
                this.ToComponent().Scripts = scripts;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to remove all existing components when a load completes. This option is only takes effect when the renderer option is set to component. Defaults to false.
			/// </summary>
            public virtual TBuilder RemoveAll(bool removeAll)
            {
                this.ToComponent().RemoveAll = removeAll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The type of content that is to be loaded into, which can be one of 4 types. Html|Data|Component|Frame
			/// </summary>
            public virtual TBuilder Mode(LoadMode mode)
            {
                this.ToComponent().Mode = mode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The function which handles the response
			/// </summary>
            public virtual TBuilder Renderer(string renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope to execute the success and failure functions in.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function to be called when a load request is successful.
			/// </summary>
            public virtual TBuilder Success(string success)
            {
                this.ToComponent().Success = success;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The target Ext.AbstractComponent for the loader. Defaults to null. If a string is passed it will be looked up via the id.
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The url to retrieve the content from. Defaults to null.
			/// </summary>
            public virtual TBuilder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The direct method name provides a content for the component
			/// </summary>
            public virtual TBuilder DirectMethod(string directMethod)
            {
                this.ToComponent().DirectMethod = directMethod;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Show warning if request fail.
			/// </summary>
            public virtual TBuilder ShowWarningOnFailure(bool showWarningOnFailure)
            {
                this.ToComponent().ShowWarningOnFailure = showWarningOnFailure;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ComponentLoaderListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentLoader.Builder<ComponentLoader, ComponentLoader.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ComponentLoader()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentLoader component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentLoader.Config config) : base(new ComponentLoader(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ComponentLoader component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ComponentLoader(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ComponentLoader()
        {
#if MVC
			return this.ComponentLoader(new ComponentLoader { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ComponentLoader(new ComponentLoader());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ComponentLoader(ComponentLoader component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ComponentLoader.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentLoader.Builder ComponentLoader(ComponentLoader.Config config)
        {
#if MVC
			return new ComponentLoader.Builder(new ComponentLoader(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ComponentLoader.Builder(new ComponentLoader(config));
#endif			
        }
    }
}