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
        new public abstract partial class Config : AbstractPanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string dayText = "Day";

			/// <summary>
			/// Alternate text to use for the 'Day' nav bar button.
			/// </summary>
			[DefaultValue("Day")]
			public virtual string DayText 
			{ 
				get
				{
					return this.dayText;
				}
				set
				{
					this.dayText = value;
				}
			}

			private string monthText = "Month";

			/// <summary>
			/// Alternate text to use for the 'Month' nav bar button.
			/// </summary>
			[DefaultValue("Month")]
			public virtual string MonthText 
			{ 
				get
				{
					return this.monthText;
				}
				set
				{
					this.monthText = value;
				}
			}

			private bool showDayView = true;

			/// <summary>
			/// True to include the day view (and toolbar button), false to hide them (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowDayView 
			{ 
				get
				{
					return this.showDayView;
				}
				set
				{
					this.showDayView = value;
				}
			}

			private bool showMonthView = true;

			/// <summary>
			/// True to include the month view (and toolbar button), false to hide them (defaults to true). If the day and week views are both hidden, the month view will show by default even if this config is false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowMonthView 
			{ 
				get
				{
					return this.showMonthView;
				}
				set
				{
					this.showMonthView = value;
				}
			}

			private bool showNavBar = true;

			/// <summary>
			/// True to display the calendar navigation toolbar, false to hide it (defaults to true). Note that if you hide the default navigation toolbar you'll have to provide an alternate means of navigating the calendar.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowNavBar 
			{ 
				get
				{
					return this.showNavBar;
				}
				set
				{
					this.showNavBar = value;
				}
			}

			private bool showTime = true;

			/// <summary>
			/// True to display the current time next to the date in the calendar's current day box, false to not show it (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowTime 
			{ 
				get
				{
					return this.showTime;
				}
				set
				{
					this.showTime = value;
				}
			}

			private bool showTodayText = true;

			/// <summary>
			/// True to show the value of todayText instead of today's date in the calendar's current day box, false to display the day number(defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowTodayText 
			{ 
				get
				{
					return this.showTodayText;
				}
				set
				{
					this.showTodayText = value;
				}
			}

			private bool showWeekView = true;

			/// <summary>
			/// True to include the week view (and toolbar button), false to hide them (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowWeekView 
			{ 
				get
				{
					return this.showWeekView;
				}
				set
				{
					this.showWeekView = value;
				}
			}

			private string todayText = "Today";

			/// <summary>
			/// Alternate text to use for the 'Today' nav bar button.
			/// </summary>
			[DefaultValue("Today")]
			public virtual string TodayText 
			{ 
				get
				{
					return this.todayText;
				}
				set
				{
					this.todayText = value;
				}
			}

			private string weekText = "Week";

			/// <summary>
			/// Alternate text to use for the 'Week' nav bar button.
			/// </summary>
			[DefaultValue("Week")]
			public virtual string WeekText 
			{ 
				get
				{
					return this.weekText;
				}
				set
				{
					this.weekText = value;
				}
			}

			private string calendarStoreID = "";

			/// <summary>
			/// The calendar store ID to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string CalendarStoreID 
			{ 
				get
				{
					return this.calendarStoreID;
				}
				set
				{
					this.calendarStoreID = value;
				}
			}

			private CalendarStore calendarStore = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual CalendarStore CalendarStore 
			{ 
				get
				{
					return this.calendarStore;
				}
				set
				{
					this.calendarStore = value;
				}
			}

			private string eventStoreID = "";

			/// <summary>
			/// The event store ID to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string EventStoreID 
			{ 
				get
				{
					return this.eventStoreID;
				}
				set
				{
					this.eventStoreID = value;
				}
			}

			private EventStore eventStore = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual EventStore EventStore 
			{ 
				get
				{
					return this.eventStore;
				}
				set
				{
					this.eventStore = value;
				}
			}

			private DayView dayView = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual DayView DayView 
			{ 
				get
				{
					return this.dayView;
				}
				set
				{
					this.dayView = value;
				}
			}

			private WeekView weekView = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual WeekView WeekView 
			{ 
				get
				{
					return this.weekView;
				}
				set
				{
					this.weekView = value;
				}
			}

			private MonthView monthView = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual MonthView MonthView 
			{ 
				get
				{
					return this.monthView;
				}
				set
				{
					this.monthView = value;
				}
			}

			private EventDetails eventDetails = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual EventDetails EventDetails 
			{ 
				get
				{
					return this.eventDetails;
				}
				set
				{
					this.eventDetails = value;
				}
			}

        }
    }
}