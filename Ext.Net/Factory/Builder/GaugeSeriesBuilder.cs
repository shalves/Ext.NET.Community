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
    public partial class GaugeSeries
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGaugeSeries, TBuilder> : AbstractSeries.Builder<TGaugeSeries, TBuilder>
            where TGaugeSeries : GaugeSeries
            where TBuilder : Builder<TGaugeSeries, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGaugeSeries component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers. REQUIRED
			/// </summary>
            public virtual TBuilder AngleField(string angleField)
            {
                this.ToComponent().AngleField = angleField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Use the entire disk or just a fraction of it for the gauge.
			/// </summary>
            public virtual TBuilder Donut(int donut)
            {
                this.ToComponent().Donut = donut;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The duration for the pie slice highlight effect. Defaults to: 150
			/// </summary>
            public virtual TBuilder HighlightDuration(int highlightDuration)
            {
                this.ToComponent().HighlightDuration = highlightDuration;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Use the Gauge Series as an area series or add a needle to it. Default's false.
			/// </summary>
            public virtual TBuilder Needle(bool needle)
            {
                this.ToComponent().Needle = needle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether to add the pie chart elements as legend items. Default's false.
			/// </summary>
            public virtual TBuilder ShowInLegend(bool showInLegend)
            {
                this.ToComponent().ShowInLegend = showInLegend;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Style(SpriteAttributes style)
            {
                this.ToComponent().Style = style;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of color values which will be used, in order, as the gauge slice fill colors.
			/// </summary>
            public virtual TBuilder ColorSet(string[] colorSet)
            {
                this.ToComponent().ColorSet = colorSet;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetValue(object value)
            {
                this.ToComponent().SetValue(value);
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : GaugeSeries.Builder<GaugeSeries, GaugeSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GaugeSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GaugeSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GaugeSeries.Config config) : base(new GaugeSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GaugeSeries component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GaugeSeries(this);
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
        public GaugeSeries.Builder GaugeSeries()
        {
#if MVC
			return this.GaugeSeries(new GaugeSeries { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.GaugeSeries(new GaugeSeries());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries.Builder GaugeSeries(GaugeSeries component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new GaugeSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries.Builder GaugeSeries(GaugeSeries.Config config)
        {
#if MVC
			return new GaugeSeries.Builder(new GaugeSeries(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new GaugeSeries.Builder(new GaugeSeries(config));
#endif			
        }
    }
}