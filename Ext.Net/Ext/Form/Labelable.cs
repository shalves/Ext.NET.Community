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

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Design;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class Labelable : BaseItem
    {

        /// <summary>
        /// 
        /// </summary>
        public Labelable()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Labelable(BaseControl owner) : base(owner)
        {
        }

        /// <summary>
        /// If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("If specified, then the component will be displayed with this value as its active error when first rendered. Defaults to undefined. Use setActiveError or unsetActiveError to change it after component creation.")]
        public virtual string ActiveError
        {
            get
            {
                return this.State.Get<string>("ActiveError", null);
            }
            set
            {
                this.State.Set("ActiveError", value);
            }
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
        [Meta]
        [ConfigOption("activeErrorsTpl")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.")]
        public virtual string ActiveErrorsTpl
        {
            get
            {
                return this.State.Get<string>("ActiveErrorsTpl", null);
            }
            set
            {
                this.State.Set("ActiveErrorsTpl", value);
            }
        }

        /// <summary>
        /// Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Whether to adjust the component's body area to make room for 'side' or 'under' error messages. Defaults to true.")]
        public virtual bool AutoFitErrors
        {
            get
            {
                return this.State.Get<bool>("AutoFitErrors", true);
            }
            set
            {
                this.State.Set("AutoFitErrors", value);
            }
        }

        /// <summary>
        /// The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("x-form-item-body")]
        [Description("The CSS class to be applied to the body content element. Defaults to 'x-form-item-body'.")]
        public virtual string BaseBodyCls
        {
            get
            {
                return this.State.Get<string>("BaseBodyCls", "x-form-item-body");
            }
            set
            {
                this.State.Set("BaseBodyCls", value);
            }
        }

        /// <summary>
        /// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("x-clear")]
        [Description("The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').")]
        public virtual string ClearCls
        {
            get
            {
                return this.State.Get<string>("ClearCls", "x-clear");
            }
            set
            {
                this.State.Set("ClearCls", value);
            }
        }

        /// <summary>
        /// The CSS class to use when the field value is dirty.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("x-form-dirty")]
        [Description("The CSS class to use when the field value is dirty.")]
        public virtual string DirtyCls
        {
            get
            {
                return this.State.Get<string>("DirtyCls", "x-form-dirty");
            }
            set
            {
                this.State.Set("DirtyCls", value);
            }
        }

        /// <summary>
        /// The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("x-form-error-msg")]
        [Description("The CSS class to be applied to the error message element. Defaults to 'x-form-error-msg'.")]
        public virtual string ErrorMsgCls
        {
            get
            {
                return this.State.Get<string>("ErrorMsgCls", "x-form-error-msg");
            }
            set
            {
                this.State.Set("ErrorMsgCls", value);
            }
        }

        /// <summary>
        /// An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("An extra CSS class to be applied to the body content element in addition to fieldBodyCls. Defaults to empty.")]
        public virtual string FieldBodyCls
        {
            get
            {
                return this.State.Get<string>("FieldBodyCls", "");
            }
            set
            {
                this.State.Set("FieldBodyCls", value);
            }
        }

        /// <summary>
        /// The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The label for the field. It gets appended with the labelSeparator, and its position and sizing is determined by the labelAlign, labelWidth, and labelPad configs. Defaults to undefined.")]
        public virtual string FieldLabel
        {
            get
            {
                return this.State.Get<string>("FieldLabel", "");
            }
            set
            {
                this.State.Set("FieldLabel", value);
            }
        }

        /// <summary>
        /// The CSS class to use when the field receives focus (defaults to 'x-form-focus')
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("x-form-focus")]
        [Description("The CSS class to use when the field receives focus (defaults to 'x-form-focus')")]
        public virtual string FocusCls
        {
            get
            {
                return this.State.Get<string>("FocusCls", "x-form-focus");
            }
            set
            {
                this.State.Set("FocusCls", value);
            }
        }

        /// <summary>
        /// A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("x-form-item")]
        [Description("A CSS class to be applied to the outermost element to denote that it is participating in the form field layout. Defaults to 'x-form-item'.")]
        public virtual string FormItemCls
        {
            get
            {
                return this.State.Get<string>("FormItemCls", "x-form-item");
            }
            set
            {
                this.State.Set("FormItemCls", value);
            }
        }

        /// <summary>
        /// When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty. Setting this to false will cause the empty label element to be rendered and space to be reserved for it; this is useful if you want a field without a label to line up with other labeled fields in the same form. Defaults to true.
        ///
        /// If you wish to unconditionall hide the label even if a non-empty fieldLabel is configured, then set the hideLabel config to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description(" When set to true, the label element (fieldLabel and labelSeparator) will be automatically hidden if the fieldLabel is empty.")]
        public virtual bool HideEmptyLabel
        {
            get
            {
                return this.State.Get<bool>("HideEmptyLabel", true);
            }
            set
            {
                this.State.Set("HideEmptyLabel", value);
            }
        }

        /// <summary>
        /// Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.
        ///
        /// Also see hideEmptyLabel, which controls whether space will be reserved for an empty fieldLabel.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Set to true to completely hide the label element (fieldLabel and labelSeparator). Defaults to false.")]
        public virtual bool HideLabel
        {
            get
            {
                return this.State.Get<bool>("HideLabel", false);
            }
            set
            {
                this.State.Set("HideLabel", value);
            }
        }

        /// <summary>
        /// The width of the field input element in pixels. Defaults to 100.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("The width of the field input element in pixels. Defaults to 100.")]
        public virtual int InputWidth
        {
            get
            {
                return this.State.Get<int>("InputWidth", 100);
            }
            set
            {
                this.State.Set("InputWidth", value);
            }
        }

        /// <summary>
        /// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("x-form-invalid")]
        [Description("The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')")]
        public virtual string InvalidCls
        {
            get
            {
                return this.State.Get<string>("InvalidCls", "x-form-invalid");
            }
            set
            {
                this.State.Set("InvalidCls", value);
            }
        }

        /// <summary>
        /// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid')
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').")]
        public virtual string InvalidText
        {
            get
            {
                return this.State.Get<string>("InvalidText", "");
            }
            set
            {
                this.State.Set("InvalidText", value);
            }
        }

        /// <summary>
        /// Controls the position and alignment of the fieldLabel. Valid values are:
        /// "left" (the default) - The label is positioned to the left of the field, with its text aligned to the left. Its width is determined by the labelWidth config.
        /// "top" - The label is positioned above the field.
        /// "right" - The label is positioned to the left of the field, with its text aligned to the right. Its width is determined by the labelWidth config.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(LabelAlign.Left)]
        [NotifyParentProperty(true)]
        [Description("Controls the position and alignment of the fieldLabel.")]
        public virtual LabelAlign LabelAlign
        {
            get
            {
                return this.State.Get<LabelAlign>("LabelAlign", LabelAlign.Left);
            }
            set
            {
                this.State.Set("LabelAlign", value);
            }
        }

        /// <summary>
        /// The CSS class to be applied to the label element. Defaults to 'x-form-item-label'. This (single) CSS class is used to formulate the renderSelector and drives the field layout where it is concatenated with a hyphen ('-') and labelAlign. To add additional classes, use labelClsExtra.
        /// </summary>
        [Meta]
        [ConfigOption("labelClsExtra")]
        [DefaultValue("")]
        [Description("The CSS class to be applied to the label element.")]
        public virtual string LabelCls
        {
            get
            {
                return this.State.Get<string>("LabelCls", "");
            }
            set
            {
                this.State.Set("LabelCls", value);
            }
        }

        /// <summary>
        /// The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(5)]
        [NotifyParentProperty(true)]
        [Description("The amount of space in pixels between the fieldLabel and the input field. Defaults to 5.")]
        public virtual int LabelPad
        {
            get
            {
                return this.State.Get<int>("LabelPad", 5);
            }
            set
            {
                this.State.Set("LabelPad", value);
            }
        }

        /// <summary>
        /// Character(s) to be inserted at the end of the label text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(":")]
        [Description("Character(s) to be inserted at the end of the label text.")]
        public virtual string LabelSeparator
        {
            get
            {
                return this.State.Get<string>("LabelSeparator", ":");
            }
            set
            {
                this.State.Set("LabelSeparator", value);
            }
        }

        /// <summary>
        /// A CSS style specification string to apply directly to this field's label. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("A CSS style specification string to apply directly to this field's label. Defaults to undefined.")]
        public virtual string LabelStyle
        {
            get
            {
                return this.State.Get<string>("LabelStyle", "");
            }
            set
            {
                this.State.Set("LabelStyle", value);
            }
        }

        /// <summary>
        /// The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to "left" or "right". Defaults to 100.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("The width of the fieldLabel in pixels. Only applicable if the labelAlign is set to \"left\" or \"right\". Defaults to 100.")]
        public virtual int LabelWidth
        {
            get
            {
                return this.State.Get<int>("LabelWidth", 100);
            }
            set
            {
                this.State.Set("LabelWidth", value);
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
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [TypeConverter(typeof(MessageTarget))]
        [DefaultValue(MessageTarget.Qtip)]
        [Description("The location where the error message text should display.")]
        public virtual MessageTarget MsgTarget
        {
            get
            {
                return this.State.Get<MessageTarget>("MsgTarget", MessageTarget.Qtip);
            }
            set
            {
                this.State.Set("MsgTarget", value);
            }
        }

        /// <summary>
        /// Add the error message directly to the innerHTML of the specified element.
        /// </summary>
        [Meta]
        [ConfigOption("msgTarget")]
        [DefaultValue("")]
        [Description("Add the error message directly to the innerHTML of the specified element.")]
        public virtual string MsgTargetElement
        {
            get
            {
                return this.State.Get<string>("MsgTargetElement", "");
            }
            set
            {
                this.State.Set("MsgTargetElement", value);
            }
        }

        /// <summary>
        /// true to disable displaying any error message set on this object. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("true to disable displaying any error message set on this object. Defaults to false.")]
        public virtual bool PreventMark
        {
            get
            {
                return this.State.Get<bool>("PreventMark", false);
            }
            set
            {
                this.State.Set("PreventMark", value);
            }
        }

        /// <summary>
        /// true to mark the field as readOnly in HTML (defaults to false).
        /// Note: this only sets the element's readOnly DOM attribute.
        /// Setting readOnly=true, for example, will not disable triggering a ComboBox or Date; it gives you the option of forcing the user to choose via the trigger without typing in the text box. To hide the trigger use hideTrigger.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("true to mark the field as readOnly in HTML (defaults to false).")]
        public virtual bool ReadOnly
        {
            get
            {
                return this.State.Get<bool>("ReadOnly", false);
            }
            set
            {
                this.State.Set("ReadOnly", value);
            }
        }

        /// <summary>
        /// The CSS class applied to the component's main element when it is readOnly.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The CSS class applied to the component's main element when it is readOnly.")]
        public virtual string ReadOnlyCls
        {
            get
            {
                return this.State.Get<string>("ReadOnlyCls", "");
            }
            set
            {
                this.State.Set("ReadOnlyCls", value);
            }
        }

        /// <summary>
        /// Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Setting this to false will prevent the field from being submitted even when it is not disabled. Defaults to true.")]
        public virtual bool SubmitValue
        {
            get
            {
                return this.State.Get<bool>("SubmitValue", true);
            }
            set
            {
                this.State.Set("SubmitValue", value);
            }
        }

        /// <summary>
        /// Preserve indicator icon place. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Preserve indicator icon place. Defaults to false")]
        public virtual bool PreserveIndicatorIcon
        {
            get
            {
                return this.State.Get<bool>("PreserveIndicatorIcon", false);
            }
            set
            {
                this.State.Set("PreserveIndicatorIcon", value);
            }
        }

        /// <summary>
        /// False to validate that the value length > 0 (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(true)]
        [Description("False to validate that the value length > 0 (defaults to true).")]
        public virtual bool AllowBlank
        {
            get
            {
                return this.State.Get<bool>("AllowBlank", true);
            }
            set
            {
                this.State.Set("AllowBlank", value);
            }
        }

        /// <summary>
        /// Error text to display if the allow blank validation fails (defaults to 'This field is required').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the allow blank validation fails (defaults to 'This field is required').")]
        public virtual string BlankText
        {
            get
            {
                return this.State.Get<string>("BlankText", "");
            }
            set
            {
                this.State.Set("BlankText", value);
            }
        }

        /// <summary>
        /// True to disable input keystroke filtering (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to disable input keystroke filtering (defaults to false).")]
        public virtual bool DisableKeyFilter
        {
            get
            {
                return this.State.Get<bool>("DisableKeyFilter", false);
            }
            set
            {
                this.State.Set("DisableKeyFilter", value);
            }
        }

        /// <summary>
        /// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Description("The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.")]
        public virtual string EmptyCls
        {
            get
            {
                return this.State.Get<string>("EmptyCls", "");
            }
            set
            {
                this.State.Set("EmptyCls", value);
            }
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
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The default text to display in an empty field (defaults to null).")]
        public virtual string EmptyText
        {
            get
            {
                return this.State.Get<string>("EmptyText", "");
            }
            set
            {
                this.State.Set("EmptyText", value);
            }
        }

        /// <summary>
        /// True to enable the proxying of key events for the HTML input field (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to enable the proxying of key events for the HTML input field (defaults to false)")]
        public virtual bool EnableKeyEvents
        {
            get
            {
                return this.State.Get<bool>("EnableKeyEvents", false);
            }
            set
            {
                this.State.Set("EnableKeyEvents", value);
            }
        }

        /// <summary>
        /// True to set the maxLength property on the underlying input field. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to set the maxLength property on the underlying input field. Defaults to false")]
        public virtual bool EnforceMaxLength
        {
            get
            {
                return this.State.Get<bool>("EnforceMaxLength", false);
            }
            set
            {
                this.State.Set("EnforceMaxLength", value);
            }
        }

        /// <summary>
        /// True if this field should automatically grow and shrink to its content (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True if this field should automatically grow and shrink to its content (defaults to false).")]
        public virtual bool Grow
        {
            get
            {
                return this.State.Get<bool>("Grow", false);
            }
            set
            {
                this.State.Set("Grow", value);
            }
        }

        /// <summary>
        /// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital "W" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("W")]
        [Description("A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital \"W\" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.")]
        public virtual string GrowAppend
        {
            get
            {
                return this.State.Get<string>("GrowAppend", "W");
            }
            set
            {
                this.State.Set("GrowAppend", value);
            }
        }

        /// <summary>
        /// The maximum width to allow when grow = true (defaults to 800).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(800)]
        [Description("The maximum width to allow when grow = true (defaults to 800).")]
        public virtual int GrowMax
        {
            get
            {
                return this.State.Get<int>("GrowMax", 800);
            }
            set
            {
                this.State.Set("GrowMax", value);
            }
        }

        /// <summary>
        /// The minimum width to allow when grow = true (defaults to 30).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(30)]
        [Description("The minimum width to allow when grow = true (defaults to 30).")]
        public virtual int GrowMin
        {
            get
            {
                return this.State.Get<int>("GrowMin", 30);
            }
            set
            {
                this.State.Set("GrowMin", value);
            }
        }

        /// <summary>
        /// An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [DirectEventUpdate(MethodName = "SetMaskRe")]
        [Description("An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.")]
        public virtual string MaskRe
        {
            get
            {
                return this.State.Get<string>("MaskRe", "");
            }
            set
            {
                this.State.Set("MaskRe", value);
            }
        }

        /// <summary>
        /// Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(-1)]
        [Description("Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.")]
        public virtual int MaxLength
        {
            get
            {
                return this.State.Get<int>("MaxLength", -1);
            }
            set
            {
                this.State.Set("MaxLength", value);
            }
        }

        /// <summary>
        /// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').")]
        public virtual string MaxLengthText
        {
            get
            {
                return this.State.Get<string>("MaxLengthText", "");
            }
            set
            {
                this.State.Set("MaxLengthText", value);
            }
        }

        /// <summary>
        /// Minimum input field length required (defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(0)]
        [Description("Minimum input field length required (defaults to 0).")]
        public virtual int MinLength
        {
            get
            {
                return this.State.Get<int>("MinLength", 0);
            }
            set
            {
                this.State.Set("MinLength", value);
            }
        }

        /// <summary>
        /// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').")]
        public virtual string MinLengthText
        {
            get
            {
                return this.State.Get<string>("MinLengthText", "");
            }
            set
            {
                this.State.Set("MinLengthText", value);
            }
        }

        /// <summary>
        /// A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.")]
        public virtual string Regex
        {
            get
            {
                return this.State.Get<string>("Regex", "");
            }
            set
            {
                this.State.Set("Regex", value);
            }
        }

        /// <summary>
        /// The error text to display if regex is used and the test fails during validation (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display if regex is used and the test fails during validation (defaults to '').")]
        public virtual string RegexText
        {
            get
            {
                return this.State.Get<string>("RegexText", "");
            }
            set
            {
                this.State.Set("RegexText", value);
            }
        }

        /// <summary>
        /// True to automatically select any existing field text when the field receives input focus (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to automatically select any existing field text when the field receives input focus (defaults to false).")]
        public virtual bool SelectOnFocus
        {
            get
            {
                return this.State.Get<bool>("SelectOnFocus", false);
            }
            set
            {
                this.State.Set("SelectOnFocus", value);
            }
        }

        /// <summary>
        /// An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(20)]
        [Description("An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.")]
        public virtual int Size
        {
            get
            {
                return this.State.Get<int>("Size", 20);
            }
            set
            {
                this.State.Set("Size", value);
            }
        }

        /// <summary>
        /// A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.")]
        public virtual string StripCharsRe
        {
            get
            {
                return this.State.Get<string>("StripCharsRe", "");
            }
            set
            {
                this.State.Set("StripCharsRe", value);
            }
        }

        private JFunction validator;

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
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Field")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A custom validation function to be called during field validation (getErrors) (defaults to undefined). If specified, this function will be called first, allowing the developer to override the default validation process.")]
        public virtual JFunction Validator
        {
            get
            {
                if (this.validator == null)
                {
                    this.validator = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.validator.Args = new string[] { "value" };
                    }
                }

                return this.validator;
            }
        }

        /// <summary>
        /// A validation type name as defined in Ext.form.VTypes (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption("vtype", JsonMode.ToLower)]
        [Category("6. TextField")]
        [DefaultValue(ValidationType.None)]
        [Description("A validation type name as defined in Ext.form.VTypes (defaults to null).")]
        public virtual ValidationType StandardVtype
        {
            get
            {
                return this.State.Get<ValidationType>("StandardVtype", ValidationType.None);
            }
            set
            {
                this.State.Set("StandardVtype", value);
            }
        }

        /// <summary>
        /// A validation type name as defined in Ext.form.VTypes (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Description("A validation type name as defined in Ext.form.VTypes (defaults to null).")]
        public virtual string Vtype
        {
            get
            {
                return this.State.Get<string>("Vtype", "");
            }
            set
            {
                this.State.Set("Vtype", value);
            }
        }

        /// <summary>
        /// A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.")]
        public virtual string VtypeText
        {
            get
            {
                return this.State.Get<string>("VtypeText", "");
            }
            set
            {
                this.State.Set("VtypeText", value);
            }
        }
    }
}
