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
    public partial class TextArea
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTextArea, TBuilder> : TextFieldBase.Builder<TTextArea, TBuilder>
            where TTextArea : TextArea
            where TBuilder : Builder<TTextArea, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTextArea component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An initial value for the 'cols' attribute on the textarea element. This is only used if the component has no configured width and is not given a width by its container's layout. Defaults to 4.
			/// </summary>
            public virtual TBuilder Cols(int cols)
            {
                this.ToComponent().Cols = cols;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if you want the ENTER key to be classed as a special key and the specialkey event to be fired when ENTER is pressed. Defaults to: false
			/// </summary>
            public virtual TBuilder EnterIsSpecial(bool enterIsSpecial)
            {
                this.ToComponent().EnterIsSpecial = enterIsSpecial;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to prevent scrollbars from appearing regardless of how much text is in the field. This option is only relevant when grow is true. Equivalent to setting overflow: hidden, defaults to false.
			/// </summary>
            public virtual TBuilder PreventScrollbars(bool preventScrollbars)
            {
                this.ToComponent().PreventScrollbars = preventScrollbars;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An initial value for the 'rows' attribute on the textarea element. This is only used if the component has no configured height and is not given a height by its container's layout. Defaults to 4.
			/// </summary>
            public virtual TBuilder Rows(int rows)
            {
                this.ToComponent().Rows = rows;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<TextFieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<TextFieldDirectEvents> action)
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
        public partial class Builder : TextArea.Builder<TextArea, TextArea.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TextArea()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TextArea component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TextArea.Config config) : base(new TextArea(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TextArea component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TextArea(this);
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
        public TextArea.Builder TextArea()
        {
#if MVC
			return this.TextArea(new TextArea { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TextArea(new TextArea());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea(TextArea component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TextArea.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea(TextArea.Config config)
        {
#if MVC
			return new TextArea.Builder(new TextArea(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TextArea.Builder(new TextArea(config));
#endif			
        }
    }
}