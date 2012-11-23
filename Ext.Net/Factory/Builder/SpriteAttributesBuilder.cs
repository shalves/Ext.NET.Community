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
    public partial class SpriteAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TSpriteAttributes, TBuilder> : BaseItem.Builder<TSpriteAttributes, TBuilder>
            where TSpriteAttributes : SpriteAttributes
            where TBuilder : Builder<TSpriteAttributes, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSpriteAttributes component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The type of the sprite. Possible options are 'circle', 'path', 'rect', 'text', 'square', 'image'
			/// </summary>
            public virtual TBuilder Type(SpriteType type)
            {
                this.ToComponent().Type = type;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The fill color
			/// </summary>
            public virtual TBuilder Fill(string fill)
            {
                this.ToComponent().Fill = fill;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used with text type sprites. The full font description. Uses the same syntax as the CSS font parameter
			/// </summary>
            public virtual TBuilder Font(string font)
            {
                this.ToComponent().Font = font;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used in rectangle sprites, the height of the rectangle
			/// </summary>
            public virtual TBuilder Height(int? height)
            {
                this.ToComponent().Height = height;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The opacity of the sprite. A number between 0 and 1.
			/// </summary>
            public virtual TBuilder Opacity(double opacity)
            {
                this.ToComponent().Opacity = opacity;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used in path sprites, the path of the sprite written in SVG-like path syntax
			/// </summary>
            public virtual TBuilder Path(string path)
            {
                this.ToComponent().Path = path;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used in circle sprites, the radius of the circle
			/// </summary>
            public virtual TBuilder Radius(int radius)
            {
                this.ToComponent().Radius = radius;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used in square sprites, the dimension of the square
			/// </summary>
            public virtual TBuilder Size(int size)
            {
                this.ToComponent().Size = size;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The stroke color
			/// </summary>
            public virtual TBuilder Stroke(string stroke)
            {
                this.ToComponent().Stroke = stroke;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used with text type sprites. The text itself
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used in rectangle sprites, the width of the rectangle
			/// </summary>
            public virtual TBuilder Width(int? width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position along the x-axis
			/// </summary>
            public virtual TBuilder X(int? x)
            {
                this.ToComponent().X = x;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position along the y-axis
			/// </summary>
            public virtual TBuilder Y(int? y)
            {
                this.ToComponent().Y = y;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Src(string src)
            {
                this.ToComponent().Src = src;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Blur(int? blur)
            {
                this.ToComponent().Blur = blur;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClipRect(string clipRect)
            {
                this.ToComponent().ClipRect = clipRect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Cursor(string cursor)
            {
                this.ToComponent().Cursor = cursor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CX(int? cX)
            {
                this.ToComponent().CX = cX;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CY(int? cY)
            {
                this.ToComponent().CY = cY;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DominantBaseline(DominantBaseline dominantBaseline)
            {
                this.ToComponent().DominantBaseline = dominantBaseline;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder FillOpacity(double? fillOpacity)
            {
                this.ToComponent().FillOpacity = fillOpacity;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder FontFamily(string fontFamily)
            {
                this.ToComponent().FontFamily = fontFamily;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder FontSize(string fontSize)
            {
                this.ToComponent().FontSize = fontSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder FontStyle(string fontStyle)
            {
                this.ToComponent().FontStyle = fontStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder FontWeight(string fontWeight)
            {
                this.ToComponent().FontWeight = fontWeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Gradient(string gradient)
            {
                this.ToComponent().Gradient = gradient;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Hidden(bool? hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Href(string href)
            {
                this.ToComponent().Href = href;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RX(int? rX)
            {
                this.ToComponent().RX = rX;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RY(int? rY)
            {
                this.ToComponent().RY = rY;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StrokeDashArray(string strokeDashArray)
            {
                this.ToComponent().StrokeDashArray = strokeDashArray;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StrokeLinecap(StrokeLinecap strokeLinecap)
            {
                this.ToComponent().StrokeLinecap = strokeLinecap;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StrokeLinejoin(StrokeLinejoin strokeLinejoin)
            {
                this.ToComponent().StrokeLinejoin = strokeLinejoin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StrokeMiterLimit(int? strokeMiterLimit)
            {
                this.ToComponent().StrokeMiterLimit = strokeMiterLimit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the opacity of the painting operation used to stroke the current object
			/// </summary>
            public virtual TBuilder StrokeOpacity(double strokeOpacity)
            {
                this.ToComponent().StrokeOpacity = strokeOpacity;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This property specifies the width of the stroke on the current object.
			/// </summary>
            public virtual TBuilder StrokeWidth(double? strokeWidth)
            {
                this.ToComponent().StrokeWidth = strokeWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder TextAnchor(string textAnchor)
            {
                this.ToComponent().TextAnchor = textAnchor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ZIndex(int? zIndex)
            {
                this.ToComponent().ZIndex = zIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Translate(Action<TranslateAttribute> action)
            {
                action(this.ToComponent().Translate);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Rotate(Action<RotateAttribute> action)
            {
                action(this.ToComponent().Rotate);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Scale(Action<ScaleAttribute> action)
            {
                action(this.ToComponent().Scale);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : SpriteAttributes.Builder<SpriteAttributes, SpriteAttributes.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SpriteAttributes()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SpriteAttributes component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SpriteAttributes.Config config) : base(new SpriteAttributes(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SpriteAttributes component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SpriteAttributes(this);
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
        public SpriteAttributes.Builder SpriteAttributes()
        {
#if MVC
			return this.SpriteAttributes(new SpriteAttributes { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.SpriteAttributes(new SpriteAttributes());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes.Builder SpriteAttributes(SpriteAttributes component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new SpriteAttributes.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SpriteAttributes.Builder SpriteAttributes(SpriteAttributes.Config config)
        {
#if MVC
			return new SpriteAttributes.Builder(new SpriteAttributes(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new SpriteAttributes.Builder(new SpriteAttributes(config));
#endif			
        }
    }
}