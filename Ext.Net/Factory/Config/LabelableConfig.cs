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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Labelable(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Labelable.Config Conversion to Labelable
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Labelable(Labelable.Config config)
        {
            return new Labelable(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit Labelable.Config Conversion to Labelable.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Labelable.Builder(Labelable.Config config)
			{
				return new Labelable.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string activeError = null;

			/// <summary>
			/// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
			/// </summary>
			[DefaultValue(null)]
			public virtual string ActiveError 
			{ 
				get
				{
					return this.activeError;
				}
				set
				{
					this.activeError = value;
				}
			}

			private string activeErrorsTpl = null;

			/// <summary>
			/// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
			/// </summary>
			[DefaultValue(null)]
			public virtual string ActiveErrorsTpl 
			{ 
				get
				{
					return this.activeErrorsTpl;
				}
				set
				{
					this.activeErrorsTpl = value;
				}
			}

			private bool autoFitErrors = true;

			/// <summary>
			/// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoFitErrors 
			{ 
				get
				{
					return this.autoFitErrors;
				}
				set
				{
					this.autoFitErrors = value;
				}
			}

			private string baseBodyCls = "x-form-item-body";

			/// <summary>
			/// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
			/// </summary>
			[DefaultValue("x-form-item-body")]
			public virtual string BaseBodyCls 
			{ 
				get
				{
					return this.baseBodyCls;
				}
				set
				{
					this.baseBodyCls = value;
				}
			}

			private string clearCls = "x-clear";

			/// <summary>
			/// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
			/// </summary>
			[DefaultValue("x-clear")]
			public virtual string ClearCls 
			{ 
				get
				{
					return this.clearCls;
				}
				set
				{
					this.clearCls = value;
				}
			}

			private string dirtyCls = "x-form-dirty";

			/// <summary>
			/// The CSS class to use when the field value is dirty.
			/// </summary>
			[DefaultValue("x-form-dirty")]
			public virtual string DirtyCls 
			{ 
				get
				{
					return this.dirtyCls;
				}
				set
				{
					this.dirtyCls = value;
				}
			}

			private string errorMsgCls = "x-form-error-msg";

			/// <summary>
			/// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
			/// </summary>
			[DefaultValue("x-form-error-msg")]
			public virtual string ErrorMsgCls 
			{ 
				get
				{
					return this.errorMsgCls;
				}
				set
				{
					this.errorMsgCls = value;
				}
			}

			private string fieldBodyCls = "";

			/// <summary>
			/// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldBodyCls 
			{ 
				get
				{
					return this.fieldBodyCls;
				}
				set
				{
					this.fieldBodyCls = value;
				}
			}

			private string fieldLabel = "";

			/// <summary>
			/// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldLabel 
			{ 
				get
				{
					return this.fieldLabel;
				}
				set
				{
					this.fieldLabel = value;
				}
			}

			private string focusCls = "x-form-focus";

			/// <summary>
			/// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
			/// </summary>
			[DefaultValue("x-form-focus")]
			public virtual string FocusCls 
			{ 
				get
				{
					return this.focusCls;
				}
				set
				{
					this.focusCls = value;
				}
			}

			private string formItemCls = "x-form-item";

			/// <summary>
			/// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
			/// </summary>
			[DefaultValue("x-form-item")]
			public virtual string FormItemCls 
			{ 
				get
				{
					return this.formItemCls;
				}
				set
				{
					this.formItemCls = value;
				}
			}

			private bool hideEmptyLabel = true;

			/// <summary>
			///  When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideEmptyLabel 
			{ 
				get
				{
					return this.hideEmptyLabel;
				}
				set
				{
					this.hideEmptyLabel = value;
				}
			}

			private bool hideLabel = false;

			/// <summary>
			/// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideLabel 
			{ 
				get
				{
					return this.hideLabel;
				}
				set
				{
					this.hideLabel = value;
				}
			}

			private int inputWidth = 100;

			/// <summary>
			/// The width of the field input element in pixels. Defaults to 100.
			/// </summary>
			[DefaultValue(100)]
			public virtual int InputWidth 
			{ 
				get
				{
					return this.inputWidth;
				}
				set
				{
					this.inputWidth = value;
				}
			}

			private string invalidCls = "x-form-invalid";

			/// <summary>
			/// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
			/// </summary>
			[DefaultValue("x-form-invalid")]
			public virtual string InvalidCls 
			{ 
				get
				{
					return this.invalidCls;
				}
				set
				{
					this.invalidCls = value;
				}
			}

			private string invalidText = "";

			/// <summary>
			/// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
			/// </summary>
			[DefaultValue("")]
			public virtual string InvalidText 
			{ 
				get
				{
					return this.invalidText;
				}
				set
				{
					this.invalidText = value;
				}
			}

			private LabelAlign labelAlign = LabelAlign.Left;

			/// <summary>
			/// Controls the position and alignment of the fieldLabel.
			/// </summary>
			[DefaultValue(LabelAlign.Left)]
			public virtual LabelAlign LabelAlign 
			{ 
				get
				{
					return this.labelAlign;
				}
				set
				{
					this.labelAlign = value;
				}
			}

			private string labelCls = "";

			/// <summary>
			/// The CSS class to be applied to the label element.
			/// </summary>
			[DefaultValue("")]
			public virtual string LabelCls 
			{ 
				get
				{
					return this.labelCls;
				}
				set
				{
					this.labelCls = value;
				}
			}

			private int labelPad = 5;

			/// <summary>
			/// The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.
			/// </summary>
			[DefaultValue(5)]
			public virtual int LabelPad 
			{ 
				get
				{
					return this.labelPad;
				}
				set
				{
					this.labelPad = value;
				}
			}

			private string labelSeparator = ":";

			/// <summary>
			/// Character(s) to be inserted at the end of the label text.
			/// </summary>
			[DefaultValue(":")]
			public virtual string LabelSeparator 
			{ 
				get
				{
					return this.labelSeparator;
				}
				set
				{
					this.labelSeparator = value;
				}
			}

			private string labelStyle = "";

			/// <summary>
			/// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string LabelStyle 
			{ 
				get
				{
					return this.labelStyle;
				}
				set
				{
					this.labelStyle = value;
				}
			}

			private int labelWidth = 100;

			/// <summary>
			/// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to \"left\" or \"right\". Defaults to 100.
			/// </summary>
			[DefaultValue(100)]
			public virtual int LabelWidth 
			{ 
				get
				{
					return this.labelWidth;
				}
				set
				{
					this.labelWidth = value;
				}
			}

			private MessageTarget msgTarget = MessageTarget.Qtip;

			/// <summary>
			/// The location where the error message text should display.
			/// </summary>
			[DefaultValue(MessageTarget.Qtip)]
			public virtual MessageTarget MsgTarget 
			{ 
				get
				{
					return this.msgTarget;
				}
				set
				{
					this.msgTarget = value;
				}
			}

			private string msgTargetElement = "";

			/// <summary>
			/// Add the error message directly to the innerHTML of the specified element.
			/// </summary>
			[DefaultValue("")]
			public virtual string MsgTargetElement 
			{ 
				get
				{
					return this.msgTargetElement;
				}
				set
				{
					this.msgTargetElement = value;
				}
			}

			private bool preventMark = false;

			/// <summary>
			/// true to disable displaying any error message set on this object. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventMark 
			{ 
				get
				{
					return this.preventMark;
				}
				set
				{
					this.preventMark = value;
				}
			}

			private bool readOnly = false;

			/// <summary>
			/// true to mark the field as readOnly in HTML (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ReadOnly 
			{ 
				get
				{
					return this.readOnly;
				}
				set
				{
					this.readOnly = value;
				}
			}

			private string readOnlyCls = "";

			/// <summary>
			/// The CSS class applied to the component's main element when it is readOnly.
			/// </summary>
			[DefaultValue("")]
			public virtual string ReadOnlyCls 
			{ 
				get
				{
					return this.readOnlyCls;
				}
				set
				{
					this.readOnlyCls = value;
				}
			}

			private bool submitValue = true;

			/// <summary>
			/// Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SubmitValue 
			{ 
				get
				{
					return this.submitValue;
				}
				set
				{
					this.submitValue = value;
				}
			}

			private bool preserveIndicatorIcon = false;

			/// <summary>
			/// Preserve indicator icon place. Defaults to false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreserveIndicatorIcon 
			{ 
				get
				{
					return this.preserveIndicatorIcon;
				}
				set
				{
					this.preserveIndicatorIcon = value;
				}
			}

			private bool allowBlank = true;

			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlank 
			{ 
				get
				{
					return this.allowBlank;
				}
				set
				{
					this.allowBlank = value;
				}
			}

			private string blankText = "";

			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
			[DefaultValue("")]
			public virtual string BlankText 
			{ 
				get
				{
					return this.blankText;
				}
				set
				{
					this.blankText = value;
				}
			}

			private bool disableKeyFilter = false;

			/// <summary>
			/// True to disable input keystroke filtering (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableKeyFilter 
			{ 
				get
				{
					return this.disableKeyFilter;
				}
				set
				{
					this.disableKeyFilter = value;
				}
			}

			private string emptyCls = "";

			/// <summary>
			/// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyCls 
			{ 
				get
				{
					return this.emptyCls;
				}
				set
				{
					this.emptyCls = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// The default text to display in an empty field (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private bool enableKeyEvents = false;

			/// <summary>
			/// True to enable the proxying of key events for the HTML input field (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableKeyEvents 
			{ 
				get
				{
					return this.enableKeyEvents;
				}
				set
				{
					this.enableKeyEvents = value;
				}
			}

			private bool enforceMaxLength = false;

			/// <summary>
			/// True to set the maxLength property on the underlying input field. Defaults to false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnforceMaxLength 
			{ 
				get
				{
					return this.enforceMaxLength;
				}
				set
				{
					this.enforceMaxLength = value;
				}
			}

			private bool grow = false;

			/// <summary>
			/// True if this field should automatically grow and shrink to its content (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Grow 
			{ 
				get
				{
					return this.grow;
				}
				set
				{
					this.grow = value;
				}
			}

			private string growAppend = "W";

			/// <summary>
			/// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital \"W\" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.
			/// </summary>
			[DefaultValue("W")]
			public virtual string GrowAppend 
			{ 
				get
				{
					return this.growAppend;
				}
				set
				{
					this.growAppend = value;
				}
			}

			private int growMax = 800;

			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
			[DefaultValue(800)]
			public virtual int GrowMax 
			{ 
				get
				{
					return this.growMax;
				}
				set
				{
					this.growMax = value;
				}
			}

			private int growMin = 30;

			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 30).
			/// </summary>
			[DefaultValue(30)]
			public virtual int GrowMin 
			{ 
				get
				{
					return this.growMin;
				}
				set
				{
					this.growMin = value;
				}
			}

			private string maskRe = "";

			/// <summary>
			/// An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.
			/// </summary>
			[DefaultValue("")]
			public virtual string MaskRe 
			{ 
				get
				{
					return this.maskRe;
				}
				set
				{
					this.maskRe = value;
				}
			}

			private int maxLength = -1;

			/// <summary>
			/// Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.
			/// </summary>
			[DefaultValue(-1)]
			public virtual int MaxLength 
			{ 
				get
				{
					return this.maxLength;
				}
				set
				{
					this.maxLength = value;
				}
			}

			private string maxLengthText = "";

			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MaxLengthText 
			{ 
				get
				{
					return this.maxLengthText;
				}
				set
				{
					this.maxLengthText = value;
				}
			}

			private int minLength = 0;

			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinLength 
			{ 
				get
				{
					return this.minLength;
				}
				set
				{
					this.minLength = value;
				}
			}

			private string minLengthText = "";

			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MinLengthText 
			{ 
				get
				{
					return this.minLengthText;
				}
				set
				{
					this.minLengthText = value;
				}
			}

			private string regex = "";

			/// <summary>
			/// A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.
			/// </summary>
			[DefaultValue("")]
			public virtual string Regex 
			{ 
				get
				{
					return this.regex;
				}
				set
				{
					this.regex = value;
				}
			}

			private string regexText = "";

			/// <summary>
			/// The error text to display if regex is used and the test fails during validation (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string RegexText 
			{ 
				get
				{
					return this.regexText;
				}
				set
				{
					this.regexText = value;
				}
			}

			private bool selectOnFocus = false;

			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SelectOnFocus 
			{ 
				get
				{
					return this.selectOnFocus;
				}
				set
				{
					this.selectOnFocus = value;
				}
			}

			private int size = 20;

			/// <summary>
			/// An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.
			/// </summary>
			[DefaultValue(20)]
			public virtual int Size 
			{ 
				get
				{
					return this.size;
				}
				set
				{
					this.size = value;
				}
			}

			private string stripCharsRe = "";

			/// <summary>
			/// A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.
			/// </summary>
			[DefaultValue("")]
			public virtual string StripCharsRe 
			{ 
				get
				{
					return this.stripCharsRe;
				}
				set
				{
					this.stripCharsRe = value;
				}
			}
        
			private JFunction validator = null;

			/// <summary>
			/// A custom validation function to be called during field validation (getErrors) (defaults to undefined). If specified, this function will be called first, allowing the developer to override the default validation process.
			/// </summary>
			public JFunction Validator
			{
				get
				{
					if (this.validator == null)
					{
						this.validator = new JFunction();
					}
			
					return this.validator;
				}
			}
			
			private ValidationType standardVtype = ValidationType.None;

			/// <summary>
			/// A validation type name as defined in Ext.form.VTypes (defaults to null).
			/// </summary>
			[DefaultValue(ValidationType.None)]
			public virtual ValidationType StandardVtype 
			{ 
				get
				{
					return this.standardVtype;
				}
				set
				{
					this.standardVtype = value;
				}
			}

			private string vtype = "";

			/// <summary>
			/// A validation type name as defined in Ext.form.VTypes (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string Vtype 
			{ 
				get
				{
					return this.vtype;
				}
				set
				{
					this.vtype = value;
				}
			}

			private string vtypeText = "";

			/// <summary>
			/// A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.
			/// </summary>
			[DefaultValue("")]
			public virtual string VtypeText 
			{ 
				get
				{
					return this.vtypeText;
				}
				set
				{
					this.vtypeText = value;
				}
			}

        }
    }
}