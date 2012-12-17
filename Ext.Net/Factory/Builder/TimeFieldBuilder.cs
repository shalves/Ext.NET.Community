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
    public partial class TimeField
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTimeField, TBuilder> : PickerField.Builder<TTimeField, TBuilder>
            where TTimeField : TimeField
            where TBuilder : Builder<TTimeField, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTimeField component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectedTime(TimeSpan selectedTime)
            {
                this.ToComponent().SelectedTime = selectedTime;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectedValue(object selectedValue)
            {
                this.ToComponent().SelectedValue = selectedValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to automatically highlight the first result gathered by the data store in the dropdown list when it is opened. (Defaults to true). A false value would cause nothing in the list to be highlighted automatically, so the user would have to manually highlight an item before pressing the enter or tab key to select it (unless the value of (typeAhead) were true), or use the mouse to select a value.
			/// </summary>
            public virtual TBuilder AutoSelect(bool autoSelect)
            {
                this.ToComponent().AutoSelect = autoSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to false)
			/// </summary>
            public virtual TBuilder ForceSelection(bool forceSelection)
            {
                this.ToComponent().ForceSelection = forceSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// false to not allow the component to resize itself when its data changes (and its grow property is true). Defaults to: true
			/// </summary>
            public virtual TBuilder GrowToLongestValue(bool growToLongestValue)
            {
                this.ToComponent().GrowToLongestValue = growToLongestValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to fire select event after setValue on page load
			/// </summary>
            public virtual TBuilder FireSelectOnLoad(bool fireSelectOnLoad)
            {
                this.ToComponent().FireSelectOnLoad = fireSelectOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum number of characters the user must type before autocomplete and typeAhead activate (defaults to 4 if queryMode = 'remote' or 0 if queryMode = 'local', does not apply if editable = false).
			/// </summary>
            public virtual TBuilder MinChars(int minChars)
            {
                this.ToComponent().MinChars = minChars;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).
			/// </summary>
            public virtual TBuilder TypeAhead(bool typeAhead)
            {
                this.ToComponent().TypeAhead = typeAhead;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
			/// </summary>
            public virtual TBuilder TypeAheadDelay(int typeAheadDelay)
            {
                this.ToComponent().TypeAheadDelay = typeAheadDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined). If this default text is used, it means there is no value set and no validation will occur on this field.
			/// </summary>
            public virtual TBuilder ValueNotFoundText(string valueNotFoundText)
            {
                this.ToComponent().ValueNotFoundText = valueNotFoundText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H|gi a|hi a|giA|hiA|gi A|hi A').
			/// </summary>
            public virtual TBuilder AltFormats(string altFormats)
            {
                this.ToComponent().AltFormats = altFormats;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default time format string which can be overriden for localization support. The format must be valid according to Ext.Date.parse (defaults to 'g:i A', e.g., '3:15 PM'). For 24-hour time format try 'H:i' instead.
			/// </summary>
            public virtual TBuilder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of minutes between each time value in the list (defaults to 15).
			/// </summary>
            public virtual TBuilder Increment(int increment)
            {
                this.ToComponent().Increment = increment;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display when the entered time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
			/// </summary>
            public virtual TBuilder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
            public virtual TBuilder MaxTime(TimeSpan maxTime)
            {
                this.ToComponent().MaxTime = maxTime;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
            public virtual TBuilder MinTime(TimeSpan minTime)
            {
                this.ToComponent().MinTime = minTime;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display when the entered time is before minValue (defaults to 'The time in this field must be equal to or after {0}').
			/// </summary>
            public virtual TBuilder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum height of the Ext.picker.Time dropdown. Defaults to 300.
			/// </summary>
            public virtual TBuilder PickerMaxHeight(int pickerMaxHeight)
            {
                this.ToComponent().PickerMaxHeight = pickerMaxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether the Tab key should select the currently highlighted item. Defaults to true.
			/// </summary>
            public virtual TBuilder SelectOnTab(bool selectOnTab)
            {
                this.ToComponent().SelectOnTab = selectOnTab;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify as true to enforce that only values on the increment boundary are accepted. Defaults to: false
			/// </summary>
            public virtual TBuilder SnapToIncrement(bool snapToIncrement)
            {
                this.ToComponent().SnapToIncrement = snapToIncrement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).
			/// </summary>
            public virtual TBuilder SubmitFormat(string submitFormat)
            {
                this.ToComponent().SubmitFormat = submitFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ListConfig(BoundList listConfig)
            {
                this.ToComponent().ListConfig = listConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If greater than 0, a Ext.toolbar.Paging is displayed in the footer of the dropdown list and the filter queries will execute with page start and limit parameters. Only applies when queryMode = 'remote' (defaults to 0).
			/// </summary>
            public virtual TBuilder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// When true, this prevents the combo from re-querying (either locally or remotely) when the current query is the same as the previous query. Defaults to: true
			/// </summary>
            public virtual TBuilder QueryCaching(bool queryCaching)
            {
                this.ToComponent().QueryCaching = queryCaching;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The length of time in milliseconds to delay between the start of typing and sending the query to filter the dropdown list (defaults to 500 if queryMode = 'remote' or 10 if queryMode = 'local')
			/// </summary>
            public virtual TBuilder QueryDelay(int queryDelay)
            {
                this.ToComponent().QueryDelay = queryDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
			/// </summary>
            public virtual TBuilder QueryMode(DataLoadMode queryMode)
            {
                this.ToComponent().QueryMode = queryMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the parameter used by the Store to pass the typed string when the ComboBox is configured with queryMode: 'remote' (defaults to 'query'). If explicitly set to a falsy value it will not be sent.
			/// </summary>
            public virtual TBuilder QueryParam(string queryParam)
            {
                this.ToComponent().QueryParam = queryParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The action to execute when the trigger is clicked.
			/// </summary>
            public virtual TBuilder TriggerAction(TriggerAction triggerAction)
            {
                this.ToComponent().TriggerAction = triggerAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ComboBoxListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ComboBoxDirectEvents> action)
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
        public partial class Builder : TimeField.Builder<TimeField, TimeField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TimeField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeField.Config config) : base(new TimeField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TimeField component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TimeField(this);
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
        public TimeField.Builder TimeField()
        {
#if MVC
			return this.TimeField(new TimeField { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TimeField(new TimeField());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField(TimeField component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TimeField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField(TimeField.Config config)
        {
#if MVC
			return new TimeField.Builder(new TimeField(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TimeField.Builder(new TimeField(config));
#endif			
        }
    }
}