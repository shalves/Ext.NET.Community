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
    public partial class DisplayField
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDisplayField, TBuilder> : Field.Builder<TDisplayField, TBuilder>
            where TDisplayField : DisplayField
            where TBuilder : Builder<TDisplayField, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDisplayField component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The format of the string to render using the .Text property. Example 'Hello {0}'.
			/// </summary>
            public virtual TBuilder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default text to display if the Text property is empty (defaults to '').
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to escape HTML in text when rendering it.
			/// </summary>
            public virtual TBuilder HtmlEncode(bool htmlEncode)
            {
                this.ToComponent().HtmlEncode = htmlEncode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function to transform the raw value for display in the field. The function will receive 2 arguments, the raw value and the Ext.form.field.Display object.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Renderer(Action<JFunction> action)
            {
                action(this.ToComponent().Renderer);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<FieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<FieldDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DisplayField.Builder<DisplayField, DisplayField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DisplayField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DisplayField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DisplayField.Config config) : base(new DisplayField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DisplayField component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DisplayField(this);
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
        public DisplayField.Builder DisplayField()
        {
#if MVC
			return this.DisplayField(new DisplayField { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DisplayField(new DisplayField());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField(DisplayField component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DisplayField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField(DisplayField.Config config)
        {
#if MVC
			return new DisplayField.Builder(new DisplayField(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DisplayField.Builder(new DisplayField(config));
#endif			
        }
    }
}