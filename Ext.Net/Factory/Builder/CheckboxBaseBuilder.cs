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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public abstract partial class CheckboxBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TCheckboxBase, TBuilder> : Field.Builder<TCheckboxBase, TBuilder>
            where TCheckboxBase : CheckboxBase
            where TBuilder : Builder<TCheckboxBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCheckboxBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup after the box label text. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
            public virtual TBuilder AfterBoxLabelTextTpl(XTemplate afterBoxLabelTextTpl)
            {
                this.ToComponent().AfterBoxLabelTextTpl = afterBoxLabelTextTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup after the box label element. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
            public virtual TBuilder AfterBoxLabelTpl(XTemplate afterBoxLabelTpl)
            {
                this.ToComponent().AfterBoxLabelTpl = afterBoxLabelTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup before the box label text. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
            public virtual TBuilder BeforeBoxLabelTextTpl(XTemplate beforeBoxLabelTextTpl)
            {
                this.ToComponent().BeforeBoxLabelTextTpl = beforeBoxLabelTextTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup before the box label text. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
            public virtual TBuilder BeforeBoxLabelTpl(XTemplate beforeBoxLabelTpl)
            {
                this.ToComponent().BeforeBoxLabelTpl = beforeBoxLabelTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional text label that will appear next to the checkbox. Whether it appears before or after the checkbox is determined by the boxLabelAlign config (defaults to after).
			/// </summary>
            public virtual TBuilder BoxLabel(string boxLabel)
            {
                this.ToComponent().BoxLabel = boxLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position relative to the checkbox where the boxLabel should appear. Recognized values are 'before' and 'after'. Defaults to 'after'.
			/// </summary>
            public virtual TBuilder BoxLabelAlign(BoxLabelAlign boxLabelAlign)
            {
                this.ToComponent().BoxLabelAlign = boxLabelAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder BoxLabelStyle(string boxLabelStyle)
            {
                this.ToComponent().BoxLabelStyle = boxLabelStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup inside the box label element (as attributes). If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
            public virtual TBuilder BoxLabelAttrTpl(XTemplate boxLabelAttrTpl)
            {
                this.ToComponent().BoxLabelAttrTpl = boxLabelAttrTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder BoxLabelCls(string boxLabelCls)
            {
                this.ToComponent().BoxLabelCls = boxLabelCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if the the checkbox should render already checked (defaults to false).
			/// </summary>
            public virtual TBuilder Checked(bool _checked)
            {
                this.ToComponent().Checked = _checked;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class added to the component's main element when it is in the checked state.
			/// </summary>
            public virtual TBuilder CheckedCls(string checkedCls)
            {
                this.ToComponent().CheckedCls = checkedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function called when the checked value changes (can be used instead of handling the change event).
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The value that should go into the generated input element's value attribute and should be used as the parameter value when submitting as part of a form. Defaults to \"on\".
			/// </summary>
            public virtual TBuilder InputValue(string inputValue)
            {
                this.ToComponent().InputValue = inputValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object to use as the scope ('this' reference) of the handler function. Defaults to this Checkbox.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If configured, this will be submitted as the checkbox's value during form submit if the checkbox is unchecked. By default this is undefined, which results in nothing being submitted for the checkbox field when the form is submitted (the default behavior of HTML checkboxes).
			/// </summary>
            public virtual TBuilder UncheckedValue(string uncheckedValue)
            {
                this.ToComponent().UncheckedValue = uncheckedValue;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}