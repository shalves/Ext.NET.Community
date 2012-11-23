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
    public partial class AjaxProxy
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TAjaxProxy, TBuilder> : ServerProxy.Builder<TAjaxProxy, TBuilder>
            where TAjaxProxy : AjaxProxy
            where TBuilder : Builder<TAjaxProxy, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAjaxProxy component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Any headers to add to the Ajax request. Defaults to undefined.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Headers(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Headers);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Send params as JSON object
			/// </summary>
            public virtual TBuilder Json(bool json)
            {
                this.ToComponent().Json = json;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Send params as XML object
			/// </summary>
            public virtual TBuilder Xml(bool xml)
            {
                this.ToComponent().Xml = xml;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Mapping of action name to HTTP request method. In the basic AjaxProxy these are set to 'GET' for 'read' actions and 'POST' for 'create', 'update' and 'destroy' actions. The Ext.data.proxy.Rest maps these to the correct RESTful methods.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ActionMethods(Action<CRUDMethods> action)
            {
                action(this.ToComponent().ActionMethods);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Returns the HTTP method name for a given request. By default this returns based on a lookup on actionMethods.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetMethod(Action<JFunction> action)
            {
                action(this.ToComponent().GetMethod);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : AjaxProxy.Builder<AjaxProxy, AjaxProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new AjaxProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AjaxProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AjaxProxy.Config config) : base(new AjaxProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(AjaxProxy component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.AjaxProxy(this);
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
        public AjaxProxy.Builder AjaxProxy()
        {
#if MVC
			return this.AjaxProxy(new AjaxProxy { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.AjaxProxy(new AjaxProxy());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy.Builder AjaxProxy(AjaxProxy component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new AjaxProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public AjaxProxy.Builder AjaxProxy(AjaxProxy.Config config)
        {
#if MVC
			return new AjaxProxy.Builder(new AjaxProxy(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new AjaxProxy.Builder(new AjaxProxy(config));
#endif			
        }
    }
}