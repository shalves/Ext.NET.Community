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
    public partial class AjaxOptions
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TAjaxOptions, TBuilder> : BaseItem.Builder<TAjaxOptions, TBuilder>
            where TAjaxOptions : AjaxOptions
            where TBuilder : Builder<TAjaxOptions, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAjaxOptions component) : base(component) { }


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
			/// The timeout in milliseconds to be used for requests. (defaults to 30000)
			/// </summary>
            public virtual TBuilder Timeout(int timeout)
            {
                this.ToComponent().Timeout = timeout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The URL to which to send the request, or a function to call which returns a URL string. The scope of the function is specified by the scope option. Defaults to the configured url.
			/// </summary>
            public virtual TBuilder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The HTTP method to use for the request. Defaults to the configured method, or if no method was configured, \"GET\" if no parameters are being sent, and \"POST\" if parameters are being sent. Note that the method name is case-sensitive and should be all caps.
			/// </summary>
            public virtual TBuilder Method(HttpMethod method)
            {
                this.ToComponent().Method = method;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if the form object is a file upload
			/// </summary>
            public virtual TBuilder IsUpload(bool isUpload)
            {
                this.ToComponent().IsUpload = isUpload;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// JSON data to use as the post. 
			/// </summary>
            public virtual TBuilder Json(bool json)
            {
                this.ToComponent().Json = json;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// XML document to use for the post.
			/// </summary>
            public virtual TBuilder Xml(bool xml)
            {
                this.ToComponent().Xml = xml;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.
			/// </summary>
            public virtual TBuilder FormID(string formID)
            {
                this.ToComponent().FormID = formID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object containing request headers which are added to each request made by this object.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Headers(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Headers);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Params(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Params);
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
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : AjaxOptions.Builder<AjaxOptions, AjaxOptions.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new AjaxOptions()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AjaxOptions component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AjaxOptions.Config config) : base(new AjaxOptions(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(AjaxOptions component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxOptions.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.AjaxOptions(this);
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
        public AjaxOptions.Builder AjaxOptions()
        {
#if MVC
			return this.AjaxOptions(new AjaxOptions { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.AjaxOptions(new AjaxOptions());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxOptions.Builder AjaxOptions(AjaxOptions component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new AjaxOptions.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxOptions.Builder AjaxOptions(AjaxOptions.Config config)
        {
#if MVC
			return new AjaxOptions.Builder(new AjaxOptions(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new AjaxOptions.Builder(new AjaxOptions(config));
#endif			
        }
    }
}