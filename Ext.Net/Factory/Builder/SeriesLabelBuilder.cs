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
    public partial class SeriesLabel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TSeriesLabel, TBuilder> : SpriteAttributes.Builder<TSeriesLabel, TBuilder>
            where TSeriesLabel : SeriesLabel
            where TBuilder : Builder<TSeriesLabel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSeriesLabel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Specifies the presence and position of labels for each pie slice.
			/// </summary>
            public virtual TBuilder Display(SeriesLabelDisplay display)
            {
                this.ToComponent().Display = display;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The color of the label text. Default value: '#000' (black).
			/// </summary>
            public virtual TBuilder Color(string color)
            {
                this.ToComponent().Color = color;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the label in contrasting color with the backround. Default value: false.
			/// </summary>
            public virtual TBuilder Contrast(bool contrast)
            {
                this.ToComponent().Contrast = contrast;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the field to be displayed in the label. Default value: 'name'.
			/// </summary>
            public virtual TBuilder Field(string[] field)
            {
                this.ToComponent().Field = field;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the minimum distance from a label to the origin of the visualization. This parameter is useful when using PieSeries width variable pie slice lengths. Default value: 50.
			/// </summary>
            public virtual TBuilder MinMargin(int minMargin)
            {
                this.ToComponent().MinMargin = minMargin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Either \"horizontal\" or \"vertical\". Dafault value: \"horizontal\".
			/// </summary>
            public virtual TBuilder Orientation(Orientation orientation)
            {
                this.ToComponent().Orientation = orientation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional function for formatting the label into a displayable value. Default value: function(value) { return value; }
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Renderer(Action<JFunction> action)
            {
                action(this.ToComponent().Renderer);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : SeriesLabel.Builder<SeriesLabel, SeriesLabel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SeriesLabel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SeriesLabel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SeriesLabel.Config config) : base(new SeriesLabel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SeriesLabel component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SeriesLabel(this);
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
        public SeriesLabel.Builder SeriesLabel()
        {
#if MVC
			return this.SeriesLabel(new SeriesLabel { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.SeriesLabel(new SeriesLabel());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel.Builder SeriesLabel(SeriesLabel component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new SeriesLabel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel.Builder SeriesLabel(SeriesLabel.Config config)
        {
#if MVC
			return new SeriesLabel.Builder(new SeriesLabel(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new SeriesLabel.Builder(new SeriesLabel(config));
#endif			
        }
    }
}