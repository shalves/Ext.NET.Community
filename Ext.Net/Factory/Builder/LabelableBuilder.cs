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
    public partial class Labelable
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TLabelable, TBuilder> : BaseItem.Builder<TLabelable, TBuilder>
            where TLabelable : Labelable
            where TBuilder : Builder<TLabelable, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TLabelable component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
			/// </summary>
            public virtual TBuilder ActiveError(string activeError)
            {
                this.ToComponent().ActiveError = activeError;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
			/// </summary>
            public virtual TBuilder ActiveErrorsTpl(string activeErrorsTpl)
            {
                this.ToComponent().ActiveErrorsTpl = activeErrorsTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
			/// </summary>
            public virtual TBuilder AutoFitErrors(bool autoFitErrors)
            {
                this.ToComponent().AutoFitErrors = autoFitErrors;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
			/// </summary>
            public virtual TBuilder BaseBodyCls(string baseBodyCls)
            {
                this.ToComponent().BaseBodyCls = baseBodyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
			/// </summary>
            public virtual TBuilder ClearCls(string clearCls)
            {
                this.ToComponent().ClearCls = clearCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the field value is dirty.
			/// </summary>
            public virtual TBuilder DirtyCls(string dirtyCls)
            {
                this.ToComponent().DirtyCls = dirtyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
			/// </summary>
            public virtual TBuilder ErrorMsgCls(string errorMsgCls)
            {
                this.ToComponent().ErrorMsgCls = errorMsgCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
			/// </summary>
            public virtual TBuilder FieldBodyCls(string fieldBodyCls)
            {
                this.ToComponent().FieldBodyCls = fieldBodyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
			/// </summary>
            public virtual TBuilder FieldLabel(string fieldLabel)
            {
                this.ToComponent().FieldLabel = fieldLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
			/// </summary>
            public virtual TBuilder FocusCls(string focusCls)
            {
                this.ToComponent().FocusCls = focusCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
			/// </summary>
            public virtual TBuilder FormItemCls(string formItemCls)
            {
                this.ToComponent().FormItemCls = formItemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			///  When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty.
			/// </summary>
            public virtual TBuilder HideEmptyLabel(bool hideEmptyLabel)
            {
                this.ToComponent().HideEmptyLabel = hideEmptyLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
			/// </summary>
            public virtual TBuilder HideLabel(bool hideLabel)
            {
                this.ToComponent().HideLabel = hideLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of the field input element in pixels. Defaults to 100.
			/// </summary>
            public virtual TBuilder InputWidth(int inputWidth)
            {
                this.ToComponent().InputWidth = inputWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
			/// </summary>
            public virtual TBuilder InvalidCls(string invalidCls)
            {
                this.ToComponent().InvalidCls = invalidCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
			/// </summary>
            public virtual TBuilder InvalidText(string invalidText)
            {
                this.ToComponent().InvalidText = invalidText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Controls the position and alignment of the fieldLabel.
			/// </summary>
            public virtual TBuilder LabelAlign(LabelAlign labelAlign)
            {
                this.ToComponent().LabelAlign = labelAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to be applied to the label element.
			/// </summary>
            public virtual TBuilder LabelCls(string labelCls)
            {
                this.ToComponent().LabelCls = labelCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.
			/// </summary>
            public virtual TBuilder LabelPad(int labelPad)
            {
                this.ToComponent().LabelPad = labelPad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Character(s) to be inserted at the end of the label text.
			/// </summary>
            public virtual TBuilder LabelSeparator(string labelSeparator)
            {
                this.ToComponent().LabelSeparator = labelSeparator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
			/// </summary>
            public virtual TBuilder LabelStyle(string labelStyle)
            {
                this.ToComponent().LabelStyle = labelStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to \"left\" or \"right\". Defaults to 100.
			/// </summary>
            public virtual TBuilder LabelWidth(int labelWidth)
            {
                this.ToComponent().LabelWidth = labelWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The location where the error message text should display.
			/// </summary>
            public virtual TBuilder MsgTarget(MessageTarget msgTarget)
            {
                this.ToComponent().MsgTarget = msgTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Add the error message directly to the innerHTML of the specified element.
			/// </summary>
            public virtual TBuilder MsgTargetElement(string msgTargetElement)
            {
                this.ToComponent().MsgTargetElement = msgTargetElement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to disable displaying any error message set on this object. Defaults to false.
			/// </summary>
            public virtual TBuilder PreventMark(bool preventMark)
            {
                this.ToComponent().PreventMark = preventMark;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to mark the field as readOnly in HTML (defaults to false).
			/// </summary>
            public virtual TBuilder ReadOnly(bool readOnly)
            {
                this.ToComponent().ReadOnly = readOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class applied to the component's main element when it is readOnly.
			/// </summary>
            public virtual TBuilder ReadOnlyCls(string readOnlyCls)
            {
                this.ToComponent().ReadOnlyCls = readOnlyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.
			/// </summary>
            public virtual TBuilder SubmitValue(bool submitValue)
            {
                this.ToComponent().SubmitValue = submitValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Preserve indicator icon place. Defaults to false
			/// </summary>
            public virtual TBuilder PreserveIndicatorIcon(bool preserveIndicatorIcon)
            {
                this.ToComponent().PreserveIndicatorIcon = preserveIndicatorIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
            public virtual TBuilder AllowBlank(bool allowBlank)
            {
                this.ToComponent().AllowBlank = allowBlank;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
            public virtual TBuilder BlankText(string blankText)
            {
                this.ToComponent().BlankText = blankText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable input keystroke filtering (defaults to false).
			/// </summary>
            public virtual TBuilder DisableKeyFilter(bool disableKeyFilter)
            {
                this.ToComponent().DisableKeyFilter = disableKeyFilter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
			/// </summary>
            public virtual TBuilder EmptyCls(string emptyCls)
            {
                this.ToComponent().EmptyCls = emptyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default text to display in an empty field (defaults to null).
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable the proxying of key events for the HTML input field (defaults to false)
			/// </summary>
            public virtual TBuilder EnableKeyEvents(bool enableKeyEvents)
            {
                this.ToComponent().EnableKeyEvents = enableKeyEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to set the maxLength property on the underlying input field. Defaults to false
			/// </summary>
            public virtual TBuilder EnforceMaxLength(bool enforceMaxLength)
            {
                this.ToComponent().EnforceMaxLength = enforceMaxLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if this field should automatically grow and shrink to its content (defaults to false).
			/// </summary>
            public virtual TBuilder Grow(bool grow)
            {
                this.ToComponent().Grow = grow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital \"W\" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.
			/// </summary>
            public virtual TBuilder GrowAppend(string growAppend)
            {
                this.ToComponent().GrowAppend = growAppend;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
            public virtual TBuilder GrowMax(int growMax)
            {
                this.ToComponent().GrowMax = growMax;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 30).
			/// </summary>
            public virtual TBuilder GrowMin(int growMin)
            {
                this.ToComponent().GrowMin = growMin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.
			/// </summary>
            public virtual TBuilder MaskRe(string maskRe)
            {
                this.ToComponent().MaskRe = maskRe;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.
			/// </summary>
            public virtual TBuilder MaxLength(int maxLength)
            {
                this.ToComponent().MaxLength = maxLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
            public virtual TBuilder MaxLengthText(string maxLengthText)
            {
                this.ToComponent().MaxLengthText = maxLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
            public virtual TBuilder MinLength(int minLength)
            {
                this.ToComponent().MinLength = minLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
            public virtual TBuilder MinLengthText(string minLengthText)
            {
                this.ToComponent().MinLengthText = minLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.
			/// </summary>
            public virtual TBuilder Regex(string regex)
            {
                this.ToComponent().Regex = regex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display if regex is used and the test fails during validation (defaults to '').
			/// </summary>
            public virtual TBuilder RegexText(string regexText)
            {
                this.ToComponent().RegexText = regexText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
            public virtual TBuilder SelectOnFocus(bool selectOnFocus)
            {
                this.ToComponent().SelectOnFocus = selectOnFocus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.
			/// </summary>
            public virtual TBuilder Size(int size)
            {
                this.ToComponent().Size = size;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.
			/// </summary>
            public virtual TBuilder StripCharsRe(string stripCharsRe)
            {
                this.ToComponent().StripCharsRe = stripCharsRe;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A custom validation function to be called during field validation (getErrors) (defaults to undefined). If specified, this function will be called first, allowing the developer to override the default validation process.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Validator(Action<JFunction> action)
            {
                action(this.ToComponent().Validator);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A validation type name as defined in Ext.form.VTypes (defaults to null).
			/// </summary>
            public virtual TBuilder StandardVtype(ValidationType standardVtype)
            {
                this.ToComponent().StandardVtype = standardVtype;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A validation type name as defined in Ext.form.VTypes (defaults to null).
			/// </summary>
            public virtual TBuilder Vtype(string vtype)
            {
                this.ToComponent().Vtype = vtype;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.
			/// </summary>
            public virtual TBuilder VtypeText(string vtypeText)
            {
                this.ToComponent().VtypeText = vtypeText;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Labelable.Builder<Labelable, Labelable.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Labelable()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Labelable component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Labelable.Config config) : base(new Labelable(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Labelable component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Labelable(this);
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
        public Labelable.Builder Labelable()
        {
#if MVC
			return this.Labelable(new Labelable { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Labelable(new Labelable());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable.Builder Labelable(Labelable component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Labelable.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable.Builder Labelable(Labelable.Config config)
        {
#if MVC
			return new Labelable.Builder(new Labelable(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Labelable.Builder(new Labelable(config));
#endif			
        }
    }
}