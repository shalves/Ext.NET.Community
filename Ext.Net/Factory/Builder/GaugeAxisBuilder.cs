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
    public partial class GaugeAxis
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGaugeAxis, TBuilder> : AbstractAxis.Builder<TGaugeAxis, TBuilder>
            where TGaugeAxis : GaugeAxis
            where TBuilder : Builder<TGaugeAxis, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGaugeAxis component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The offset positioning of the tick marks and labels in pixels. Defaults to: 10
			/// </summary>
            public virtual TBuilder Margin(int margin)
            {
                this.ToComponent().Margin = margin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value of the interval to be displayed in the axis (REQUIRED).
			/// </summary>
            public virtual TBuilder Maximum(double? maximum)
            {
                this.ToComponent().Maximum = maximum;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value of the interval to be displayed in the axis (REQUIRED).
			/// </summary>
            public virtual TBuilder Minimum(double? minimum)
            {
                this.ToComponent().Minimum = minimum;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of steps and tick marks to add to the interval. (REQUIRED).
			/// </summary>
            public virtual TBuilder Steps(double? steps)
            {
                this.ToComponent().Steps = steps;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The title for the Axis.
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : GaugeAxis.Builder<GaugeAxis, GaugeAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GaugeAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GaugeAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GaugeAxis.Config config) : base(new GaugeAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GaugeAxis component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GaugeAxis(this);
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
        public GaugeAxis.Builder GaugeAxis()
        {
#if MVC
			return this.GaugeAxis(new GaugeAxis { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.GaugeAxis(new GaugeAxis());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeAxis.Builder GaugeAxis(GaugeAxis component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new GaugeAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeAxis.Builder GaugeAxis(GaugeAxis.Config config)
        {
#if MVC
			return new GaugeAxis.Builder(new GaugeAxis(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new GaugeAxis.Builder(new GaugeAxis(config));
#endif			
        }
    }
}