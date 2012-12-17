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
    public partial class DatePicker
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDatePicker, TBuilder> : ComponentBase.Builder<TDatePicker, TBuilder>
            where TDatePicker : DatePicker
            where TBuilder : Builder<TDatePicker, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDatePicker component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text to display for the aria title. Defaults to: \"Date Picker: {0}\"
			/// </summary>
            public virtual TBuilder AriaTitle(string ariaTitle)
            {
                this.ToComponent().AriaTitle = ariaTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The date format to display for the current value in the ariaTitle. Defaults to: \"MMMM dd, yyyy\"
			/// </summary>
            public virtual TBuilder AriaTitleDateFormat(string ariaTitleDateFormat)
            {
                this.ToComponent().AriaTitleDateFormat = ariaTitleDateFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of textual day names which can be overriden for localization support (defaults to Ext.Date.dayNames)
			/// </summary>
            public virtual TBuilder DayNames(string[] dayNames)
            {
                this.ToComponent().DayNames = dayNames;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable animations when showing the month picker. Defaults to: false
			/// </summary>
            public virtual TBuilder DisableAnim(bool disableAnim)
            {
                this.ToComponent().DisableAnim = disableAnim;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The class to apply to disabled cells. Defaults to: \"x-datepicker-disabled\"
			/// </summary>
            public virtual TBuilder DisabledCellCls(string disabledCellCls)
            {
                this.ToComponent().DisabledCellCls = disabledCellCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DisabledDates(Action<DisabledDateCollection> action)
            {
                action(this.ToComponent().DisabledDates);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// JavaScript regular expression used to disable a pattern of dates. The disabledDates config will generate this regex internally, but if you specify disabledDatesRE it will take precedence over the disabledDates value. Defaults to: null
			/// </summary>
            public virtual TBuilder DisabledDatesRE(string disabledDatesRE)
            {
                this.ToComponent().DisabledDatesRE = disabledDatesRE;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The tooltip text to display when the date falls on a disabled date. Defaults to: \"Disabled\"
			/// </summary>
            public virtual TBuilder DisabledDatesText(string disabledDatesText)
            {
                this.ToComponent().DisabledDatesText = disabledDatesText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
			/// </summary>
            public virtual TBuilder DisabledDays(int[] disabledDays)
            {
                this.ToComponent().DisabledDays = disabledDays;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The tooltip to display when the date falls on a disabled day. Defaults to: \"Disabled\"
			/// </summary>
            public virtual TBuilder DisabledDaysText(string disabledDaysText)
            {
                this.ToComponent().DisabledDaysText = disabledDaysText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically focus the picker on show. Defaults to: false
			/// </summary>
            public virtual TBuilder FocusOnShow(bool focusOnShow)
            {
                this.ToComponent().FocusOnShow = focusOnShow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
			/// </summary>
            public virtual TBuilder Format(string format)
            {
                this.ToComponent().Format = format;
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
			/// The format for displaying a date in a longer format.
			/// </summary>
            public virtual TBuilder LongDayFormat(string longDayFormat)
            {
                this.ToComponent().LongDayFormat = longDayFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum allowed date.
			/// </summary>
            public virtual TBuilder MaxDate(DateTime maxDate)
            {
                this.ToComponent().MaxDate = maxDate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display if the maxDate validation fails. (defaults to 'This date is after the maximum date').
			/// </summary>
            public virtual TBuilder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum allowed date.
			/// </summary>
            public virtual TBuilder MinDate(DateTime minDate)
            {
                this.ToComponent().MinDate = minDate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display if the minDate validation fails. (defaults to 'This date is before the minimum date').
			/// </summary>
            public virtual TBuilder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
			/// </summary>
            public virtual TBuilder MonthNames(string[] monthNames)
            {
                this.ToComponent().MonthNames = monthNames;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The date format for the header month. Defaults to: \"MMMM yyyy\"
			/// </summary>
            public virtual TBuilder MonthYearFormat(string monthYearFormat)
            {
                this.ToComponent().MonthYearFormat = monthYearFormat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
			/// </summary>
            public virtual TBuilder MonthYearText(string monthYearText)
            {
                this.ToComponent().MonthYearText = monthYearText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
			/// </summary>
            public virtual TBuilder NextText(string nextText)
            {
                this.ToComponent().NextText = nextText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
			/// </summary>
            public virtual TBuilder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which the handler function will be called. Defaults to this DatePicker instance.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The class to apply to the selected cell. Defaults to: \"x-datepicker-selected\"
			/// </summary>
            public virtual TBuilder SelectedCls(string selectedCls)
            {
                this.ToComponent().SelectedCls = selectedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
			/// </summary>
            public virtual TBuilder ShowToday(bool showToday)
            {
                this.ToComponent().ShowToday = showToday;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
			/// </summary>
            public virtual TBuilder StartDay(int startDay)
            {
                this.ToComponent().StartDay = startDay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display on the button that selects the current date (defaults to 'Today').
			/// </summary>
            public virtual TBuilder TodayText(string todayText)
            {
                this.ToComponent().TodayText = todayText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string used to format the message for displaying in a tooltip over the button that selects the current date. The {0} token in string is replaced by today's date. Defaults to: \"{0} (Spacebar)\"
			/// </summary>
            public virtual TBuilder TodayTip(string todayTip)
            {
                this.ToComponent().TodayTip = todayTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<DatePickerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<DatePickerDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
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
			/// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
			/// </summary>
            public virtual TBuilder SelectedDate(DateTime selectedDate)
            {
                this.ToComponent().SelectedDate = selectedDate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectedValue(Action<object> action)
            {
                action(this.ToComponent().SelectedValue);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The fields null value.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EmptyValue(Action<object> action)
            {
                action(this.ToComponent().EmptyValue);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Value(object value)
            {
                this.ToComponent().Value = value;
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
			/// Clear the value of this field.
			/// </summary>
            public virtual TBuilder Clear()
            {
                this.ToComponent().Clear();
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DatePicker.Builder<DatePicker, DatePicker.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DatePicker()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DatePicker component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DatePicker.Config config) : base(new DatePicker(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DatePicker component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DatePicker(this);
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
        public DatePicker.Builder DatePicker()
        {
#if MVC
			return this.DatePicker(new DatePicker { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DatePicker(new DatePicker());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker(DatePicker component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DatePicker.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker(DatePicker.Config config)
        {
#if MVC
			return new DatePicker.Builder(new DatePicker(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DatePicker.Builder(new DatePicker(config));
#endif			
        }
    }
}