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
    public partial class SortInfo
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TSortInfo, TBuilder> : BaseItem.Builder<TSortInfo, TBuilder>
            where TSortInfo : SortInfo
            where TBuilder : Builder<TSortInfo, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSortInfo component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Internal UI Event. Fired before the view is refreshed.
			/// </summary>
            public virtual TBuilder Field(string field)
            {
                this.ToComponent().Field = field;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The direction to sort (\"asc\" or \"desc\")
			/// </summary>
            public virtual TBuilder Direction(SortDirection direction)
            {
                this.ToComponent().Direction = direction;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : SortInfo.Builder<SortInfo, SortInfo.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SortInfo()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SortInfo component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SortInfo.Config config) : base(new SortInfo(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SortInfo component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SortInfo.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SortInfo(this);
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
        public SortInfo.Builder SortInfo()
        {
#if MVC
			return this.SortInfo(new SortInfo { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.SortInfo(new SortInfo());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public SortInfo.Builder SortInfo(SortInfo component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new SortInfo.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SortInfo.Builder SortInfo(SortInfo.Config config)
        {
#if MVC
			return new SortInfo.Builder(new SortInfo(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new SortInfo.Builder(new SortInfo(config));
#endif			
        }
    }
}