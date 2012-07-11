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
 * @version   : 2.0.0.rc2 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public abstract partial class FieldContainerBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractContainer.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool combineErrors = false;

			/// <summary>
			/// If set to true, the field container will automatically combine and display the validation errors from all the fields it contains as a single error on the container, according to the configured msgTarget. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CombineErrors 
			{ 
				get
				{
					return this.combineErrors;
				}
				set
				{
					this.combineErrors = value;
				}
			}

			private bool combineLabels = false;

			/// <summary>
			/// If set to true, and there is no defined fieldLabel, the field container will automatically generate its label by combining the labels of all the fields it contains. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CombineLabels 
			{ 
				get
				{
					return this.combineLabels;
				}
				set
				{
					this.combineLabels = value;
				}
			}

			private string labelConnector = ", ";

			/// <summary>
			/// The string to use when joining the labels of individual sub-fields, when combineLabels is set to true. Defaults to ', '.
			/// </summary>
			[DefaultValue(", ")]
			public virtual string LabelConnector 
			{ 
				get
				{
					return this.labelConnector;
				}
				set
				{
					this.labelConnector = value;
				}
			}
        
			private Labelable fieldDefaults = null;

			/// <summary>
			/// If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.
			/// </summary>
			public Labelable FieldDefaults
			{
				get
				{
					if (this.fieldDefaults == null)
					{
						this.fieldDefaults = new Labelable();
					}
			
					return this.fieldDefaults;
				}
			}
			
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
        
			private XTemplate activeErrorsTpl = null;

			/// <summary>
			/// The template used to format the Array of error messages passed to setActiveErrors into a single HTML string. By default this renders each message as an item in an unordered list.
			/// </summary>
			public XTemplate ActiveErrorsTpl
			{
				get
				{
					if (this.activeErrorsTpl == null)
					{
						this.activeErrorsTpl = new XTemplate();
					}
			
					return this.activeErrorsTpl;
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

			private string indicatorText = "";

			/// <summary>
			/// The indicator text.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorText 
			{ 
				get
				{
					return this.indicatorText;
				}
				set
				{
					this.indicatorText = value;
				}
			}

			private string indicatorCls = "";

			/// <summary>
			/// The indicator css class.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorCls 
			{ 
				get
				{
					return this.indicatorCls;
				}
				set
				{
					this.indicatorCls = value;
				}
			}

			private string indicatorIconCls = "";

			/// <summary>
			/// The indicator icon class.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorIconCls 
			{ 
				get
				{
					return this.indicatorIconCls;
				}
				set
				{
					this.indicatorIconCls = value;
				}
			}

			private Icon indicatorIcon = Icon.None;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon IndicatorIcon 
			{ 
				get
				{
					return this.indicatorIcon;
				}
				set
				{
					this.indicatorIcon = value;
				}
			}

			private string indicatorTip = "";

			/// <summary>
			/// The indicator tip.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorTip 
			{ 
				get
				{
					return this.indicatorTip;
				}
				set
				{
					this.indicatorTip = value;
				}
			}

			private string note = "";

			/// <summary>
			/// The note.
			/// </summary>
			[DefaultValue("")]
			public virtual string Note 
			{ 
				get
				{
					return this.note;
				}
				set
				{
					this.note = value;
				}
			}

			private string noteCls = "";

			/// <summary>
			/// The note css class.
			/// </summary>
			[DefaultValue("")]
			public virtual string NoteCls 
			{ 
				get
				{
					return this.noteCls;
				}
				set
				{
					this.noteCls = value;
				}
			}

			private NoteAlign noteAlign = NoteAlign.Down;

			/// <summary>
			/// Note align
			/// </summary>
			[DefaultValue(NoteAlign.Down)]
			public virtual NoteAlign NoteAlign 
			{ 
				get
				{
					return this.noteAlign;
				}
				set
				{
					this.noteAlign = value;
				}
			}

			private bool noteEncode = false;

			/// <summary>
			/// True to encode note text
			/// </summary>
			[DefaultValue(false)]
			public virtual bool NoteEncode 
			{ 
				get
				{
					return this.noteEncode;
				}
				set
				{
					this.noteEncode = value;
				}
			}

        }
    }
}