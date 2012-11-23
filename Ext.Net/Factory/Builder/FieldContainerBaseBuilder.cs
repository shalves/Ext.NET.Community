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
    public abstract partial class FieldContainerBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TFieldContainerBase, TBuilder> : AbstractContainer.Builder<TFieldContainerBase, TBuilder>
            where TFieldContainerBase : FieldContainerBase
            where TBuilder : Builder<TFieldContainerBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFieldContainerBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If set to true, the field container will automatically combine and display the validation errors from all the fields it contains as a single error on the container, according to the configured msgTarget. Defaults to false.
			/// </summary>
            public virtual TBuilder CombineErrors(bool combineErrors)
            {
                this.ToComponent().CombineErrors = combineErrors;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If set to true, and there is no defined fieldLabel, the field container will automatically generate its label by combining the labels of all the fields it contains. Defaults to false.
			/// </summary>
            public virtual TBuilder CombineLabels(bool combineLabels)
            {
                this.ToComponent().CombineLabels = combineLabels;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The string to use when joining the labels of individual sub-fields, when combineLabels is set to true. Defaults to ', '.
			/// </summary>
            public virtual TBuilder LabelConnector(string labelConnector)
            {
                this.ToComponent().LabelConnector = labelConnector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FieldDefaults(Action<Labelable> action)
            {
                action(this.ToComponent().FieldDefaults);
                return this as TBuilder;
            }
			 
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
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ActiveErrorsTpl(Action<XTemplate> action)
            {
                action(this.ToComponent().ActiveErrorsTpl);
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
			/// The CSS class to use when marking the component invalid (defaults to 'x-form-invalid')
			/// </summary>
            public virtual TBuilder InvalidCls(string invalidCls)
            {
                this.ToComponent().InvalidCls = invalidCls;
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
			/// Preserve indicator icon place. Defaults to false
			/// </summary>
            public virtual TBuilder PreserveIndicatorIcon(bool preserveIndicatorIcon)
            {
                this.ToComponent().PreserveIndicatorIcon = preserveIndicatorIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator text.
			/// </summary>
            public virtual TBuilder IndicatorText(string indicatorText)
            {
                this.ToComponent().IndicatorText = indicatorText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator css class.
			/// </summary>
            public virtual TBuilder IndicatorCls(string indicatorCls)
            {
                this.ToComponent().IndicatorCls = indicatorCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator icon class.
			/// </summary>
            public virtual TBuilder IndicatorIconCls(string indicatorIconCls)
            {
                this.ToComponent().IndicatorIconCls = indicatorIconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IndicatorIcon(Icon indicatorIcon)
            {
                this.ToComponent().IndicatorIcon = indicatorIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator tip.
			/// </summary>
            public virtual TBuilder IndicatorTip(string indicatorTip)
            {
                this.ToComponent().IndicatorTip = indicatorTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The note.
			/// </summary>
            public virtual TBuilder Note(string note)
            {
                this.ToComponent().Note = note;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The note css class.
			/// </summary>
            public virtual TBuilder NoteCls(string noteCls)
            {
                this.ToComponent().NoteCls = noteCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note align
			/// </summary>
            public virtual TBuilder NoteAlign(NoteAlign noteAlign)
            {
                this.ToComponent().NoteAlign = noteAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to encode note text
			/// </summary>
            public virtual TBuilder NoteEncode(bool noteEncode)
            {
                this.ToComponent().NoteEncode = noteEncode;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetNote(string note, bool encode)
            {
                this.ToComponent().SetNote(note, encode);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowNote()
            {
                this.ToComponent().ShowNote();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideNote()
            {
                this.ToComponent().HideNote();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowIndicator()
            {
                this.ToComponent().ShowIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideIndicator()
            {
                this.ToComponent().HideIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearIndicator()
            {
                this.ToComponent().ClearIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlignIndicator()
            {
                this.ToComponent().AlignIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetFieldLabel(string label)
            {
                this.ToComponent().SetFieldLabel(label);
                return this as TBuilder;
            }
            
        }        
    }
}