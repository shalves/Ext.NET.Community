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
    public partial class DateFilter
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DateFilter(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DateFilter.Config Conversion to DateFilter
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DateFilter(DateFilter.Config config)
        {
            return new DateFilter(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridFilter.Config 
        { 
			/*  Implicit DateFilter.Config Conversion to DateFilter.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DateFilter.Builder(DateFilter.Config config)
			{
				return new DateFilter.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string beforeText = "Before";

			/// <summary>
			/// The text displayed for the 'Before' menu item
			/// </summary>
			[DefaultValue("Before")]
			public virtual string BeforeText 
			{ 
				get
				{
					return this.beforeText;
				}
				set
				{
					this.beforeText = value;
				}
			}

			private string afterText = "After";

			/// <summary>
			/// The text displayed for the 'After' menu item
			/// </summary>
			[DefaultValue("After")]
			public virtual string AfterText 
			{ 
				get
				{
					return this.afterText;
				}
				set
				{
					this.afterText = value;
				}
			}

			private string onText = "On";

			/// <summary>
			/// The text displayed for the 'On' menu item
			/// </summary>
			[DefaultValue("On")]
			public virtual string OnText 
			{ 
				get
				{
					return this.onText;
				}
				set
				{
					this.onText = value;
				}
			}

			private string format = "d";

			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
			/// </summary>
			[DefaultValue("d")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}
        
			private DatePickerOptions datePickerOptions = null;

			/// <summary>
			/// 
			/// </summary>
			public DatePickerOptions DatePickerOptions
			{
				get
				{
					if (this.datePickerOptions == null)
					{
						this.datePickerOptions = new DatePickerOptions();
					}
			
					return this.datePickerOptions;
				}
			}
			
			private DateTime maxDate = new DateTime(9999, 12, 31);

			/// <summary>
			/// Allowable date as passed to the Ext.DatePicker
			/// </summary>
			[DefaultValue(typeof(DateTime), "9999-12-31")]
			public virtual DateTime MaxDate 
			{ 
				get
				{
					return this.maxDate;
				}
				set
				{
					this.maxDate = value;
				}
			}

			private DateTime minDate = new DateTime(0001, 01, 01);

			/// <summary>
			/// Allowable date as passed to the Ext.DatePicker
			/// </summary>
			[DefaultValue(typeof(DateTime), "0001-01-01")]
			public virtual DateTime MinDate 
			{ 
				get
				{
					return this.minDate;
				}
				set
				{
					this.minDate = value;
				}
			}

			private DateTime? beforeValue = null;

			/// <summary>
			/// Predefined filter value
			/// </summary>
			[DefaultValue(null)]
			public virtual DateTime? BeforeValue 
			{ 
				get
				{
					return this.beforeValue;
				}
				set
				{
					this.beforeValue = value;
				}
			}

			private DateTime? afterValue = null;

			/// <summary>
			/// Predefined filter value
			/// </summary>
			[DefaultValue(null)]
			public virtual DateTime? AfterValue 
			{ 
				get
				{
					return this.afterValue;
				}
				set
				{
					this.afterValue = value;
				}
			}

			private DateTime? onValue = null;

			/// <summary>
			/// Predefined filter value
			/// </summary>
			[DefaultValue(null)]
			public virtual DateTime? OnValue 
			{ 
				get
				{
					return this.onValue;
				}
				set
				{
					this.onValue = value;
				}
			}

        }
    }
}