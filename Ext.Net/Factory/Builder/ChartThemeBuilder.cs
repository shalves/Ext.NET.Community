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
    public partial class ChartTheme
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TChartTheme, TBuilder> : Observable.Builder<TChartTheme, TBuilder>
            where TChartTheme : ChartTheme
            where TBuilder : Builder<TChartTheme, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TChartTheme component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ThemeName(string themeName)
            {
                this.ToComponent().ThemeName = themeName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Background(bool background)
            {
                this.ToComponent().Background = background;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder UseGradients(bool useGradients)
            {
                this.ToComponent().UseGradients = useGradients;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder BaseColor(string baseColor)
            {
                this.ToComponent().BaseColor = baseColor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Colors(string[] colors)
            {
                this.ToComponent().Colors = colors;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Axis(SpriteAttributes axis)
            {
                this.ToComponent().Axis = axis;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisLabelTop(SpriteAttributes axisLabelTop)
            {
                this.ToComponent().AxisLabelTop = axisLabelTop;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisLabelRight(SpriteAttributes axisLabelRight)
            {
                this.ToComponent().AxisLabelRight = axisLabelRight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisLabelBottom(SpriteAttributes axisLabelBottom)
            {
                this.ToComponent().AxisLabelBottom = axisLabelBottom;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisLabelLeft(SpriteAttributes axisLabelLeft)
            {
                this.ToComponent().AxisLabelLeft = axisLabelLeft;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisTitleTop(SpriteAttributes axisTitleTop)
            {
                this.ToComponent().AxisTitleTop = axisTitleTop;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisTitleRight(SpriteAttributes axisTitleRight)
            {
                this.ToComponent().AxisTitleRight = axisTitleRight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisTitleBottom(SpriteAttributes axisTitleBottom)
            {
                this.ToComponent().AxisTitleBottom = axisTitleBottom;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisTitleLeft(SpriteAttributes axisTitleLeft)
            {
                this.ToComponent().AxisTitleLeft = axisTitleLeft;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Series(SpriteAttributes series)
            {
                this.ToComponent().Series = series;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SeriesLabel(SpriteAttributes seriesLabel)
            {
                this.ToComponent().SeriesLabel = seriesLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Marker(SpriteAttributes marker)
            {
                this.ToComponent().Marker = marker;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisLabel(SpriteAttributes axisLabel)
            {
                this.ToComponent().AxisLabel = axisLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AxisTitle(SpriteAttributes axisTitle)
            {
                this.ToComponent().AxisTitle = axisTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SeriesThemes(Action<SpriteAttributesCollection> action)
            {
                action(this.ToComponent().SeriesThemes);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder MarkerThemes(Action<SpriteAttributesCollection> action)
            {
                action(this.ToComponent().MarkerThemes);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ChartTheme.Builder<ChartTheme, ChartTheme.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ChartTheme()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChartTheme component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChartTheme.Config config) : base(new ChartTheme(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ChartTheme component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartTheme.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ChartTheme(this);
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
        public ChartTheme.Builder ChartTheme()
        {
#if MVC
			return this.ChartTheme(new ChartTheme { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ChartTheme(new ChartTheme());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartTheme.Builder ChartTheme(ChartTheme component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ChartTheme.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartTheme.Builder ChartTheme(ChartTheme.Config config)
        {
#if MVC
			return new ChartTheme.Builder(new ChartTheme(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ChartTheme.Builder(new ChartTheme(config));
#endif			
        }
    }
}