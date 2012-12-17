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
    public partial class PieSeries
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TPieSeries, TBuilder> : AbstractSeries.Builder<TPieSeries, TBuilder>
            where TPieSeries : PieSeries
            where TBuilder : Builder<TPieSeries, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TPieSeries component) : base(component) { }


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
			/// An array of color values which will be used, in order, as the gauge slice fill colors.
			/// </summary>
            public virtual TBuilder ColorSet(string[] colorSet)
            {
                this.ToComponent().ColorSet = colorSet;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether to set the pie chart as donut chart. Default's false. Can be set to a particular percentage to set the radius of the donut chart.
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
			/// 
			/// </summary>
            public virtual TBuilder HighlightSegmentMargin(int? highlightSegmentMargin)
            {
                this.ToComponent().HighlightSegmentMargin = highlightSegmentMargin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The store record field name to be used for the pie slice lengths. The values bound to this field name must be positive real numbers.
			/// </summary>
            public virtual TBuilder LengthField(string lengthField)
            {
                this.ToComponent().LengthField = lengthField;
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
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : PieSeries.Builder<PieSeries, PieSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PieSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PieSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PieSeries.Config config) : base(new PieSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PieSeries component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PieSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PieSeries(this);
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
        public PieSeries.Builder PieSeries()
        {
#if MVC
			return this.PieSeries(new PieSeries { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.PieSeries(new PieSeries());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public PieSeries.Builder PieSeries(PieSeries component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new PieSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PieSeries.Builder PieSeries(PieSeries.Config config)
        {
#if MVC
			return new PieSeries.Builder(new PieSeries(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new PieSeries.Builder(new PieSeries(config));
#endif			
        }
    }
}