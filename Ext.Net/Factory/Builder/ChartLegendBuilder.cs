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
    public partial class ChartLegend
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TChartLegend, TBuilder> : BaseItem.Builder<TChartLegend, TBuilder>
            where TChartLegend : ChartLegend
            where TBuilder : Builder<TChartLegend, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TChartLegend component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Fill style for the legend box. Defaults to: \"#FFF\"
			/// </summary>
            public virtual TBuilder BoxFill(string boxFill)
            {
                this.ToComponent().BoxFill = boxFill;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Style of the stroke for the legend box. Defaults to: \"#000\"
			/// </summary>
            public virtual TBuilder BoxStroke(string boxStroke)
            {
                this.ToComponent().BoxStroke = boxStroke;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Width of the stroke for the legend box. Defaults to: 1
			/// </summary>
            public virtual TBuilder BoxStrokeWidth(int boxStrokeWidth)
            {
                this.ToComponent().BoxStrokeWidth = boxStrokeWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Sets the z-index for the legend. Defaults to 100.
			/// </summary>
            public virtual TBuilder BoxZIndex(int boxZIndex)
            {
                this.ToComponent().BoxZIndex = boxZIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Amount of space between legend items. Defaults to: 10
			/// </summary>
            public virtual TBuilder ItemSpacing(int itemSpacing)
            {
                this.ToComponent().ItemSpacing = itemSpacing;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Color to be used for the legend labels, eg '#000'. Defaults to: \"#000\"
			/// </summary>
            public virtual TBuilder LabelColor(string labelColor)
            {
                this.ToComponent().LabelColor = labelColor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Font to be used for the legend labels, eg '12px Helvetica'. Defaults to: \"12px Helvetica, sans-serif\"
			/// </summary>
            public virtual TBuilder LabelFont(string labelFont)
            {
                this.ToComponent().LabelFont = labelFont;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Amount of padding between the legend box's border and its items. Defaults to: 5
			/// </summary>
            public virtual TBuilder Padding(int padding)
            {
                this.ToComponent().Padding = padding;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position of the legend in relation to the chart. One of: \"top\", \"bottom\", \"left\", \"right\", or \"float\". If set to \"float\", then the legend box will be positioned at the point denoted by the x and y parameters. Defaults to: \"bottom\"
			/// </summary>
            public virtual TBuilder Position(LegendPosition position)
            {
                this.ToComponent().Position = position;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If set to true the legend will be refreshed when the chart is. This is useful to update the legend items if series are added/removed/updated from the chart. Default is true.
			/// </summary>
            public virtual TBuilder Update(bool update)
            {
                this.ToComponent().Update = update;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether or not the legend should be displayed. Defaults to: true
			/// </summary>
            public virtual TBuilder Visible(bool visible)
            {
                this.ToComponent().Visible = visible;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// X-position of the legend box. Used directly if position is set to \"float\", otherwise it will be calculated dynamically. Defaults to: 0
			/// </summary>
            public virtual TBuilder X(int x)
            {
                this.ToComponent().X = x;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Y-position of the legend box. Used directly if position is set to \"float\", otherwise it will be calculated dynamically. Defaults to: 0
			/// </summary>
            public virtual TBuilder Y(int y)
            {
                this.ToComponent().Y = y;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ChartLegend.Builder<ChartLegend, ChartLegend.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ChartLegend()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChartLegend component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ChartLegend.Config config) : base(new ChartLegend(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ChartLegend component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartLegend.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ChartLegend(this);
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
        public ChartLegend.Builder ChartLegend()
        {
#if MVC
			return this.ChartLegend(new ChartLegend { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ChartLegend(new ChartLegend());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartLegend.Builder ChartLegend(ChartLegend component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ChartLegend.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ChartLegend.Builder ChartLegend(ChartLegend.Config config)
        {
#if MVC
			return new ChartLegend.Builder(new ChartLegend(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ChartLegend.Builder(new ChartLegend(config));
#endif			
        }
    }
}