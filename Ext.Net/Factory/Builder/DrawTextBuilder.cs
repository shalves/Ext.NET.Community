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
    public partial class DrawText
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDrawText, TBuilder> : DrawComponent.Builder<TDrawText, TBuilder>
            where TDrawText : DrawText
            where TBuilder : Builder<TDrawText, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDrawText component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Turn on autoSize support which will set the bounding div's size to the natural size of the contents. Defaults to true.
			/// </summary>
            public virtual TBuilder AutoSize(bool autoSize)
            {
                this.ToComponent().AutoSize = autoSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The angle by which to initially rotate the text clockwise. Defaults to zero.
			/// </summary>
            public virtual TBuilder Degrees(int degrees)
            {
                this.ToComponent().Degrees = degrees;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS selector string which matches a style rule in the document stylesheet from which the text's font properties are read.
			/// </summary>
            public virtual TBuilder StyleSelector(string styleSelector)
            {
                this.ToComponent().StyleSelector = styleSelector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display (html tags are not accepted)
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder TextStyle(SpriteAttributes textStyle)
            {
                this.ToComponent().TextStyle = textStyle;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DrawText.Builder<DrawText, DrawText.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DrawText()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DrawText component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DrawText.Config config) : base(new DrawText(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DrawText component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawText.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DrawText(this);
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
        public DrawText.Builder DrawText()
        {
#if MVC
			return this.DrawText(new DrawText { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DrawText(new DrawText());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawText.Builder DrawText(DrawText component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DrawText.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawText.Builder DrawText(DrawText.Config config)
        {
#if MVC
			return new DrawText.Builder(new DrawText(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DrawText.Builder(new DrawText(config));
#endif			
        }
    }
}