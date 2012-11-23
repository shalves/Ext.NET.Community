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
    public partial class Gradient
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGradient, TBuilder> : BaseItem.Builder<TGradient, TBuilder>
            where TGradient : Gradient
            where TBuilder : Builder<TGradient, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGradient component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The unique name of the gradient.
			/// </summary>
            public virtual TBuilder GradientID(string gradientID)
            {
                this.ToComponent().GradientID = gradientID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The angle of the gradient in degrees.
			/// </summary>
            public virtual TBuilder Angle(int angle)
            {
                this.ToComponent().Angle = angle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object with numbers as keys (from 0 to 100) and style objects as values
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Stops(Action<GradientStops> action)
            {
                action(this.ToComponent().Stops);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Gradient.Builder<Gradient, Gradient.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Gradient()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Gradient component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Gradient.Config config) : base(new Gradient(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Gradient component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Gradient.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Gradient(this);
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
        public Gradient.Builder Gradient()
        {
#if MVC
			return this.Gradient(new Gradient { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Gradient(new Gradient());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Gradient.Builder Gradient(Gradient component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Gradient.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Gradient.Builder Gradient(Gradient.Config config)
        {
#if MVC
			return new Gradient.Builder(new Gradient(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Gradient.Builder(new Gradient(config));
#endif			
        }
    }
}