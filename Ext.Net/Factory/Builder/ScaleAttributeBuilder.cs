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
    public partial class ScaleAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TScaleAttribute, TBuilder> : TranslateAttribute.Builder<TScaleAttribute, TBuilder>
            where TScaleAttribute : ScaleAttribute
            where TBuilder : Builder<TScaleAttribute, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TScaleAttribute component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CX(double? cX)
            {
                this.ToComponent().CX = cX;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CY(double? cY)
            {
                this.ToComponent().CY = cY;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ScaleAttribute.Builder<ScaleAttribute, ScaleAttribute.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ScaleAttribute()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ScaleAttribute component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ScaleAttribute.Config config) : base(new ScaleAttribute(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ScaleAttribute component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ScaleAttribute.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ScaleAttribute(this);
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
        public ScaleAttribute.Builder ScaleAttribute()
        {
#if MVC
			return this.ScaleAttribute(new ScaleAttribute { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ScaleAttribute(new ScaleAttribute());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ScaleAttribute.Builder ScaleAttribute(ScaleAttribute component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ScaleAttribute.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ScaleAttribute.Builder ScaleAttribute(ScaleAttribute.Config config)
        {
#if MVC
			return new ScaleAttribute.Builder(new ScaleAttribute(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ScaleAttribute.Builder(new ScaleAttribute(config));
#endif			
        }
    }
}