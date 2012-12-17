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
    public partial class ResourcesRegistrator
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TResourcesRegistrator, TBuilder> : Observable.Builder<TResourcesRegistrator, TBuilder>
            where TResourcesRegistrator : ResourcesRegistrator
            where TBuilder : Builder<TResourcesRegistrator, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TResourcesRegistrator component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ResourceItems(Action<List<ClientResourceItem>> action)
            {
                action(this.ToComponent().ResourceItems);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ResourcesRegistrator.Builder<ResourcesRegistrator, ResourcesRegistrator.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ResourcesRegistrator()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ResourcesRegistrator component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ResourcesRegistrator.Config config) : base(new ResourcesRegistrator(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ResourcesRegistrator component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ResourcesRegistrator.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ResourcesRegistrator(this);
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
        public ResourcesRegistrator.Builder ResourcesRegistrator()
        {
#if MVC
			return this.ResourcesRegistrator(new ResourcesRegistrator { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ResourcesRegistrator(new ResourcesRegistrator());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ResourcesRegistrator.Builder ResourcesRegistrator(ResourcesRegistrator component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ResourcesRegistrator.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ResourcesRegistrator.Builder ResourcesRegistrator(ResourcesRegistrator.Config config)
        {
#if MVC
			return new ResourcesRegistrator.Builder(new ResourcesRegistrator(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ResourcesRegistrator.Builder(new ResourcesRegistrator(config));
#endif			
        }
    }
}