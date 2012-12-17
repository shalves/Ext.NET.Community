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
    public partial class BooleanFilter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TBooleanFilter, TBuilder> : GridFilter.Builder<TBooleanFilter, TBuilder>
            where TBooleanFilter : BooleanFilter
            where TBuilder : Builder<TBooleanFilter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TBooleanFilter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text displayed for the 'Yes' checkbox
			/// </summary>
            public virtual TBuilder YesText(string yesText)
            {
                this.ToComponent().YesText = yesText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text displayed for the 'No' checkbox
			/// </summary>
            public virtual TBuilder NoText(string noText)
            {
                this.ToComponent().NoText = noText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default value of this filter (defaults to false)
			/// </summary>
            public virtual TBuilder DefaultValue(bool defaultValue)
            {
                this.ToComponent().DefaultValue = defaultValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Predefined filter value
			/// </summary>
            public virtual TBuilder Value(bool? value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : BooleanFilter.Builder<BooleanFilter, BooleanFilter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BooleanFilter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BooleanFilter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BooleanFilter.Config config) : base(new BooleanFilter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BooleanFilter component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BooleanFilter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BooleanFilter(this);
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
        public BooleanFilter.Builder BooleanFilter()
        {
#if MVC
			return this.BooleanFilter(new BooleanFilter { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.BooleanFilter(new BooleanFilter());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public BooleanFilter.Builder BooleanFilter(BooleanFilter component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new BooleanFilter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BooleanFilter.Builder BooleanFilter(BooleanFilter.Config config)
        {
#if MVC
			return new BooleanFilter.Builder(new BooleanFilter(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new BooleanFilter.Builder(new BooleanFilter(config));
#endif			
        }
    }
}