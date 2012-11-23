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
    public abstract partial class CalendarPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCalendarPanelBase, TBuilder> : AbstractPanel.Builder<TCalendarPanelBase, TBuilder>
            where TCalendarPanelBase : CalendarPanelBase
            where TBuilder : Builder<TCalendarPanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCalendarPanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Alternate text to use for the 'Day' nav bar button.
			/// </summary>
            public virtual TBuilder DayText(string dayText)
            {
                this.ToComponent().DayText = dayText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Alternate text to use for the 'Month' nav bar button.
			/// </summary>
            public virtual TBuilder MonthText(string monthText)
            {
                this.ToComponent().MonthText = monthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to include the day view (and toolbar button), false to hide them (defaults to true).
			/// </summary>
            public virtual TBuilder ShowDayView(bool showDayView)
            {
                this.ToComponent().ShowDayView = showDayView;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to include the month view (and toolbar button), false to hide them (defaults to true). If the day and week views are both hidden, the month view will show by default even if this config is false.
			/// </summary>
            public virtual TBuilder ShowMonthView(bool showMonthView)
            {
                this.ToComponent().ShowMonthView = showMonthView;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the calendar navigation toolbar, false to hide it (defaults to true). Note that if you hide the default navigation toolbar you'll have to provide an alternate means of navigating the calendar.
			/// </summary>
            public virtual TBuilder ShowNavBar(bool showNavBar)
            {
                this.ToComponent().ShowNavBar = showNavBar;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the current time next to the date in the calendar's current day box, false to not show it (defaults to true).
			/// </summary>
            public virtual TBuilder ShowTime(bool showTime)
            {
                this.ToComponent().ShowTime = showTime;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show the value of todayText instead of today's date in the calendar's current day box, false to display the day number(defaults to true).
			/// </summary>
            public virtual TBuilder ShowTodayText(bool showTodayText)
            {
                this.ToComponent().ShowTodayText = showTodayText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to include the week view (and toolbar button), false to hide them (defaults to true).
			/// </summary>
            public virtual TBuilder ShowWeekView(bool showWeekView)
            {
                this.ToComponent().ShowWeekView = showWeekView;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Alternate text to use for the 'Today' nav bar button.
			/// </summary>
            public virtual TBuilder TodayText(string todayText)
            {
                this.ToComponent().TodayText = todayText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Alternate text to use for the 'Week' nav bar button.
			/// </summary>
            public virtual TBuilder WeekText(string weekText)
            {
                this.ToComponent().WeekText = weekText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The calendar store ID to use.
			/// </summary>
            public virtual TBuilder CalendarStoreID(string calendarStoreID)
            {
                this.ToComponent().CalendarStoreID = calendarStoreID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CalendarStore(CalendarStore calendarStore)
            {
                this.ToComponent().CalendarStore = calendarStore;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The event store ID to use.
			/// </summary>
            public virtual TBuilder EventStoreID(string eventStoreID)
            {
                this.ToComponent().EventStoreID = eventStoreID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder EventStore(EventStore eventStore)
            {
                this.ToComponent().EventStore = eventStore;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DayView(DayView dayView)
            {
                this.ToComponent().DayView = dayView;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder WeekView(WeekView weekView)
            {
                this.ToComponent().WeekView = weekView;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MonthView(MonthView monthView)
            {
                this.ToComponent().MonthView = monthView;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder EventDetails(EventDetails eventDetails)
            {
                this.ToComponent().EventDetails = eventDetails;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}