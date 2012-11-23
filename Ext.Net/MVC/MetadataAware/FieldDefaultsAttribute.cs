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
 ********/using System;
using System.Web.Mvc;
using System.ComponentModel;
using System.Reflection;

namespace Ext.Net.MVC
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FieldAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.fielddefaults";
        private bool autoFitErrors = true;
        private bool hideEmptyLabel = true;
        private LabelAlign labelAlign = LabelAlign.Left;
        private int labelPad = 5;
        private int labelWidth = 100;
        private MessageTarget msgTarget = MessageTarget.Qtip;
        private bool submitValue = true;
        private bool allowBlank = true;
        private int growMax = 800;
        private int growMin = 30;
        private int maxLength = -1;
        private int size = 20;
        private ValidationType standardVtype = ValidationType.None;

        public FieldAttribute()
        {            
        }

        [DefaultValue(false)]
        public bool Ignore
        {
            get;
            set;
        }

        [DefaultValue(null)]
        public Type FieldType
        {
            get;
            set;
        }

        /// <summary>
        /// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
        /// 
        /// Standard template:
        /// <code>
        /// '&lt;tpl if="errors &amp;&amp; errors.length"&gt;',
        ///    '&lt;ul&gt;&lt;tpl for="errors"&gt;&lt;li&lt;tpl if="xindex == xcount"&gt; class="last"&lt;/tpl&gt;&gt;{.}&lt;/li&gt;&lt;/tpl&gt;&lt;/ul&gt;',
        /// '&lt;/tpl&gt;'        
        /// </code>
        /// </summary>
        [DefaultValue(null)]
        public virtual string ActiveErrorsTpl
        {
            get;
            set;
        }

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

        /// <summary>
        /// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
        /// </summary>
        [DefaultValue(null)]
        public virtual string BaseBodyCls
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
        /// </summary>
        [DefaultValue(null)]
        public virtual string ClearCls
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class to use when the field value is dirty.
        /// </summary>
        [DefaultValue(null)]
        public virtual string DirtyCls
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
        /// </summary>
        [DefaultValue(null)]
        public virtual string ErrorMsgCls
        {
            get;
            set;
        }

        /// <summary>
        /// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
        /// </summary>
        [DefaultValue(null)]
        public virtual string FieldBodyCls
        {
            get;
            set;
        }

        /// <summary>
        /// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
        /// </summary>
        [DefaultValue(null)]
        public virtual string FieldLabel
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
        /// </summary>
        [DefaultValue(null)]
        public virtual string FocusCls
        {
            get;
            set;
        }

        /// <summary>
        /// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
        /// </summary>
        [DefaultValue(null)]
        public virtual string FormItemCls
        {
            get;
            set;
        }

        /// <summary>
        /// When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty. Setting this to false will cause the empty label element to be rendered and space to be reserved for it; this is useful if you want a field without a label to line up with other labeled fields in the same form. Defaults to true.
        ///
        /// If you wish to unconditionall hide the label even if a non-empty fieldLabel is configured, then set the hideLabel config to true.
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

        /// <summary>
        /// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
        ///
        /// Also see hideEmptyLabel, which controls whether space will be reserved for an empty fieldLabel.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool HideLabel
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
        /// </summary>
        [DefaultValue(null)]
        public virtual string InvalidCls
        {
            get;
            set;
        }

        /// <summary>
        /// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid')
        /// </summary>
        [DefaultValue(null)]
        public virtual string InvalidText
        {
            get;
            set;
        }

        /// <summary>
        /// Controls the position and alignment of the fieldLabel. Valid values are:
        /// "left" (the default) - The label is positioned to the left of the field, with its text aligned to the left. Its width is determined by the labelWidth config.
        /// "top" - The label is positioned above the field.
        /// "right" - The label is positioned to the left of the field, with its text aligned to the right. Its width is determined by the labelWidth config.
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

        /// <summary>
        /// The CSS class to be applied to the label element. Defaults to 'x-form-item-label'. This (single) CSS class is used to formulate the renderSelector and drives the field layout where it is concatenated with a hyphen ('-') and labelAlign. To add additional classes, use labelClsExtra.
        /// </summary>
        [DefaultValue(null)]
        public virtual string LabelCls
        {
            get;
            set;
        }

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

        /// <summary>
        /// Character(s) to be inserted at the end of the label text.
        /// </summary>
        [DefaultValue(null)]
        public virtual string LabelSeparator
        {
            get;
            set;
        }

        /// <summary>
        /// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
        /// </summary>
        [DefaultValue(null)]
        public virtual string LabelStyle
        {
            get;
            set;
        }

        /// <summary>
        /// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to "left" or "right". Defaults to 100.
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

        /// <summary>
        /// The location where the error message text should display. Must be one of the following values:
        /// 
        /// qtip Display a quick tip containing the message when the user hovers over the field. This is the default.
        /// title Display the message in a default browser title attribute popup.
        /// under Add a block div beneath the field containing the error message.
        /// side Add an error icon to the right of the field, displaying the message in a popup on hover.
        /// none Don't display any error message. This might be useful if you are implementing custom error display.
        /// [element id] Add the error message directly to the innerHTML of the specified element.
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

        /// <summary>
        /// Add the error message directly to the innerHTML of the specified element.
        /// </summary>
        [DefaultValue(null)]
        public virtual string MsgTargetElement
        {
            get;
            set;
        }

        /// <summary>
        /// true to disable displaying any error message set on this object. Defaults to false.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool PreventMark
        {
            get;
            set;
        }

        /// <summary>
        /// true to mark the field as readOnly in HTML (defaults to false).
        /// Note: this only sets the element's readOnly DOM attribute.
        /// Setting readOnly=true, for example, will not disable triggering a ComboBox or Date; it gives you the option of forcing the user to choose via the trigger without typing in the text box. To hide the trigger use hideTrigger.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool ReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class applied to the component's main element when it is readOnly.
        /// </summary>
        [DefaultValue(null)]
        public virtual string ReadOnlyCls
        {
            get;
            set;
        }

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

        /// <summary>
        /// Preserve indicator icon place. Defaults to false
        /// </summary>
        [DefaultValue(false)]
        public virtual bool PreserveIndicatorIcon
        {
            get;
            set;
        }

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

        /// <summary>
        /// Error text to display if the allow blank validation fails (defaults to 'This field is required').
        /// </summary>
        [DefaultValue(null)]
        public virtual string BlankText
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable input keystroke filtering (defaults to false).
        /// </summary>
        [DefaultValue(false)]
        public virtual bool DisableKeyFilter
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
        /// </summary>
        [DefaultValue(null)]
        public virtual string EmptyCls
        {
            get;
            set;
        }

        /// <summary>
        /// The default text to place into an empty field.
        /// 
        /// Note that normally this value will be submitted to the server if this field is enabled; to prevent this you can set the submitEmptyText option of Ext.form.Basic.submit to false.
        /// 
        /// Also note that if you use inputType:'file', emptyText is not supported and should be avoided.
        /// 
        /// Note that for browsers that support it, setting this property will use the HTML 5 placeholder attribute, and for older browsers that don't support the HTML 5 placeholder attribute the value will be placed directly into the input element itself as the raw value. This means that older browsers will obfuscate the emptyText value for password input fields.
        /// </summary>
        [DefaultValue(null)]
        public virtual string EmptyText
        {
            get;
            set;
        }

        /// <summary>
        /// True to enable the proxying of key events for the HTML input field (defaults to false)
        /// </summary>
        [DefaultValue(false)]
        public virtual bool EnableKeyEvents
        {
            get;
            set;
        }

        /// <summary>
        /// True to set the maxLength property on the underlying input field. Defaults to false
        /// </summary>
        [DefaultValue(false)]
        public virtual bool EnforceMaxLength
        {
            get;
            set;
        }

        /// <summary>
        /// True if this field should automatically grow and shrink to its content (defaults to false).
        /// </summary>
        [DefaultValue(false)]
        public virtual bool Grow
        {
            get;
            set;
        }

        /// <summary>
        /// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital "W" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.
        /// </summary>
        [DefaultValue(null)]
        public virtual string GrowAppend
        {
            get;
            set;
        }

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

        /// <summary>
        /// An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.
        /// </summary>
        [DefaultValue(null)]
        public virtual string MaskRe
        {
            get;
            set;
        }

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

        /// <summary>
        /// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
        /// </summary>
        [DefaultValue(null)]
        public virtual string MaxLengthText
        {
            get;
            set;
        }

        /// <summary>
        /// Minimum input field length required (defaults to 0).
        /// </summary>
        [DefaultValue(0)]
        public virtual int MinLength
        {
            get;
            set;
        }

        /// <summary>
        /// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
        /// </summary>
        [DefaultValue(null)]
        public virtual string MinLengthText
        {
            get;
            set;
        }

        /// <summary>
        /// A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Regex
        {
            get;
            set;
        }

        /// <summary>
        /// The error text to display if regex is used and the test fails during validation (defaults to '').
        /// </summary>
        [DefaultValue(null)]
        public virtual string RegexText
        {
            get;
            set;
        }

        /// <summary>
        /// True to automatically select any existing field text when the field receives input focus (defaults to false).
        /// </summary>
        [DefaultValue(false)]
        public virtual bool SelectOnFocus
        {
            get;
            set;
        }

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

        /// <summary>
        /// A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.
        /// </summary>        
        [DefaultValue(null)]
        public virtual string StripCharsRe
        {
            get;
            set;
        }

        /// <summary>   
        /// A custom validation function to be called during field validation (getErrors) (defaults to undefined). If specified, this function will be called first, allowing the developer to override the default validation process.
        /// This function will be passed the following Parameters:
        /// value: Mixed
        ///     The current field value
        /// 
        /// This function is to Return:
        /// true: Boolean
        ///     true if the value is valid
        /// msg: String
        ///     An error message if the value is invalid
        /// </summary>        
        [DefaultValue(null)]
        public virtual string Validator
        {
            get;
            set;
        }

        /// <summary>
        /// A custom error message to display in place of the default message provided for the validator currently set for this field (defaults to ''). Only applies if validator is set, else ignored.
        /// </summary>
        [DefaultValue(null)]
        public virtual string ValidatorText
        {
            get;
            set;
        }

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

        /// <summary>
        /// A validation type name as defined in Ext.form.VTypes (defaults to null).
        /// </summary>
        [DefaultValue(null)]
        public virtual string Vtype
        {
            get;
            set;
        }

        /// <summary>
        /// A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.
        /// </summary>
        [DefaultValue(null)]
        public virtual string VtypeText
        {
            get;
            set;
        }

        public virtual void CopyTo(Field field)
        {
            field.Apply(this);
            
            if (this.Validator != null)
            {
                field.Validator.Fn = this.Validator;
            }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }
            
            metadata.AdditionalValues[FieldAttribute.KEY] = this;
        }        
    }

}