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
    public partial class ColorPicker
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TColorPicker, TBuilder> : ComponentBase.Builder<TColorPicker, TBuilder>
            where TColorPicker : ColorPicker
            where TBuilder : Builder<TColorPicker, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TColorPicker component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If set to true then reselecting a color that is already selected fires the select event. Defaults to: false
			/// </summary>
            public virtual TBuilder AllowReselect(bool allowReselect)
            {
                this.ToComponent().AllowReselect = allowReselect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The DOM event that will cause a color to be selected. This can be any valid event name (dblclick, contextmenu). Defaults to: \"click\"
			/// </summary>
            public virtual TBuilder ClickEvent(string clickEvent)
            {
                this.ToComponent().ClickEvent = clickEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function that will handle the select event of this picker. 
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which the handler function will be called. Defaults to this Color picker instance.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to apply to the selected element
			/// </summary>
            public virtual TBuilder SelectedCls(string selectedCls)
            {
                this.ToComponent().SelectedCls = selectedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of 6-digit color hex code strings (without the # symbol).
			/// </summary>
            public virtual TBuilder Colors(string[] colors)
            {
                this.ToComponent().Colors = colors;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An existing XTemplate instance to be used in place of the default template for rendering the component.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Template(Action<XTemplate> action)
            {
                action(this.ToComponent().Template);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.
			/// </summary>
            public virtual TBuilder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// AutoPostBack
			/// </summary>
            public virtual TBuilder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TBuilder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TBuilder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ColorPickerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ColorPickerDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DirectSelectUrl(string directSelectUrl)
            {
                this.ToComponent().DirectSelectUrl = directSelectUrl;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(string value)
            {
                this.ToComponent().Select(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Select(string value, bool suppressEvent)
            {
                this.ToComponent().Select(value, suppressEvent);
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ColorPicker.Builder<ColorPicker, ColorPicker.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColorPicker()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorPicker component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorPicker.Config config) : base(new ColorPicker(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColorPicker component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColorPicker(this);
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
        public ColorPicker.Builder ColorPicker()
        {
#if MVC
			return this.ColorPicker(new ColorPicker { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ColorPicker(new ColorPicker());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker.Builder ColorPicker(ColorPicker component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ColorPicker.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker.Builder ColorPicker(ColorPicker.Config config)
        {
#if MVC
			return new ColorPicker.Builder(new ColorPicker(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ColorPicker.Builder(new ColorPicker(config));
#endif			
        }
    }
}