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
    public partial class DirectProxy
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDirectProxy, TBuilder> : ServerProxy.Builder<TDirectProxy, TBuilder>
            where TDirectProxy : DirectProxy
            where TBuilder : Builder<TDirectProxy, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDirectProxy component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Specific direct functions to call on CRUD action methods \"read\", \"create\", \"update\" and \"destroy\".
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder API(Action<CRUDUrls> action)
            {
                action(this.ToComponent().API);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Function to call when executing a request. directFn is a simple alternative to defining the api configuration-parameter for Store's which will not implement a full CRUD api.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectFn(Action<JFunction> action)
            {
                action(this.ToComponent().DirectFn);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Defaults to undefined. A list of params to be executed server side. Specify the params in the order in which they must be executed on the server-side as a String of params delimited by either whitespace, comma, or pipe.
			/// </summary>
            public virtual TBuilder ParamOrder(string paramOrder)
            {
                this.ToComponent().ParamOrder = paramOrder;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Send parameters as a collection of named arguments (defaults to true). Providing a paramOrder nullifies this configuration.
			/// </summary>
            public virtual TBuilder ParamsAsHash(bool paramsAsHash)
            {
                this.ToComponent().ParamsAsHash = paramsAsHash;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DirectProxy.Builder<DirectProxy, DirectProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DirectProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DirectProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DirectProxy.Config config) : base(new DirectProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DirectProxy component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DirectProxy(this);
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
        public DirectProxy.Builder DirectProxy()
        {
#if MVC
			return this.DirectProxy(new DirectProxy { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DirectProxy(new DirectProxy());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectProxy.Builder DirectProxy(DirectProxy component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DirectProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectProxy.Builder DirectProxy(DirectProxy.Config config)
        {
#if MVC
			return new DirectProxy.Builder(new DirectProxy(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DirectProxy.Builder(new DirectProxy(config));
#endif			
        }
    }
}