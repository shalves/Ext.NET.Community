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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TimeField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TimeField.Config Conversion to TimeField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TimeField(TimeField.Config config)
        {
            return new TimeField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : PickerField.Config 
        { 
			/*  Implicit TimeField.Config Conversion to TimeField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TimeField.Builder(TimeField.Config config)
			{
				return new TimeField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private TimeSpan selectedTime = new TimeSpan(-9223372036854775808);

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
			public virtual TimeSpan SelectedTime 
			{ 
				get
				{
					return this.selectedTime;
				}
				set
				{
					this.selectedTime = value;
				}
			}

			private object selectedValue = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual object SelectedValue 
			{ 
				get
				{
					return this.selectedValue;
				}
				set
				{
					this.selectedValue = value;
				}
			}

			private bool autoSelect = true;

			/// <summary>
			/// true to automatically highlight the first result gathered by the data store in the dropdown list when it is opened. (Defaults to true). A false value would cause nothing in the list to be highlighted automatically, so the user would have to manually highlight an item before pressing the enter or tab key to select it (unless the value of (typeAhead) were true), or use the mouse to select a value.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoSelect 
			{ 
				get
				{
					return this.autoSelect;
				}
				set
				{
					this.autoSelect = value;
				}
			}

			private bool forceSelection = false;

			/// <summary>
			/// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceSelection 
			{ 
				get
				{
					return this.forceSelection;
				}
				set
				{
					this.forceSelection = value;
				}
			}

			private bool growToLongestValue = true;

			/// <summary>
			/// false to not allow the component to resize itself when its data changes (and its grow property is true). Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool GrowToLongestValue 
			{ 
				get
				{
					return this.growToLongestValue;
				}
				set
				{
					this.growToLongestValue = value;
				}
			}

			private bool fireSelectOnLoad = false;

			/// <summary>
			/// True to fire select event after setValue on page load
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FireSelectOnLoad 
			{ 
				get
				{
					return this.fireSelectOnLoad;
				}
				set
				{
					this.fireSelectOnLoad = value;
				}
			}

			private int minChars = 0;

			/// <summary>
			/// The minimum number of characters the user must type before autocomplete and typeAhead activate (defaults to 4 if queryMode = 'remote' or 0 if queryMode = 'local', does not apply if editable = false).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinChars 
			{ 
				get
				{
					return this.minChars;
				}
				set
				{
					this.minChars = value;
				}
			}

			private bool typeAhead = false;

			/// <summary>
			/// True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TypeAhead 
			{ 
				get
				{
					return this.typeAhead;
				}
				set
				{
					this.typeAhead = value;
				}
			}

			private int typeAheadDelay = 250;

			/// <summary>
			/// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
			/// </summary>
			[DefaultValue(250)]
			public virtual int TypeAheadDelay 
			{ 
				get
				{
					return this.typeAheadDelay;
				}
				set
				{
					this.typeAheadDelay = value;
				}
			}

			private string valueNotFoundText = "";

			/// <summary>
			/// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined). If this default text is used, it means there is no value set and no validation will occur on this field.
			/// </summary>
			[DefaultValue("")]
			public virtual string ValueNotFoundText 
			{ 
				get
				{
					return this.valueNotFoundText;
				}
				set
				{
					this.valueNotFoundText = value;
				}
			}

			private string altFormats = "";

			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H|gi a|hi a|giA|hiA|gi A|hi A').
			/// </summary>
			[DefaultValue("")]
			public virtual string AltFormats 
			{ 
				get
				{
					return this.altFormats;
				}
				set
				{
					this.altFormats = value;
				}
			}

			private string format = "t";

			/// <summary>
			/// The default time format string which can be overriden for localization support. The format must be valid according to Ext.Date.parse (defaults to 'g:i A', e.g., '3:15 PM'). For 24-hour time format try 'H:i' instead.
			/// </summary>
			[DefaultValue("t")]
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

			private int increment = 15;

			/// <summary>
			/// The number of minutes between each time value in the list (defaults to 15).
			/// </summary>
			[DefaultValue(15)]
			public virtual int Increment 
			{ 
				get
				{
					return this.increment;
				}
				set
				{
					this.increment = value;
				}
			}

			private string maxText = "The time in this field must be equal to or before {0}";

			/// <summary>
			/// The error text to display when the entered time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
			/// </summary>
			[DefaultValue("The time in this field must be equal to or before {0}")]
			public virtual string MaxText 
			{ 
				get
				{
					return this.maxText;
				}
				set
				{
					this.maxText = value;
				}
			}

			private TimeSpan maxTime = new TimeSpan(9223372036854775807);

			/// <summary>
			/// The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "9223372036854775807")]
			public virtual TimeSpan MaxTime 
			{ 
				get
				{
					return this.maxTime;
				}
				set
				{
					this.maxTime = value;
				}
			}

			private TimeSpan minTime = new TimeSpan(-9223372036854775808);

			/// <summary>
			/// The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
			public virtual TimeSpan MinTime 
			{ 
				get
				{
					return this.minTime;
				}
				set
				{
					this.minTime = value;
				}
			}

			private string minText = "The time in this field must be equal to or after {0}";

			/// <summary>
			/// The error text to display when the entered time is before minValue (defaults to 'The time in this field must be equal to or after {0}').
			/// </summary>
			[DefaultValue("The time in this field must be equal to or after {0}")]
			public virtual string MinText 
			{ 
				get
				{
					return this.minText;
				}
				set
				{
					this.minText = value;
				}
			}

			private int pickerMaxHeight = 300;

			/// <summary>
			/// The maximum height of the Ext.picker.Time dropdown. Defaults to 300.
			/// </summary>
			[DefaultValue(300)]
			public virtual int PickerMaxHeight 
			{ 
				get
				{
					return this.pickerMaxHeight;
				}
				set
				{
					this.pickerMaxHeight = value;
				}
			}

			private bool selectOnTab = true;

			/// <summary>
			/// Whether the Tab key should select the currently highlighted item. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SelectOnTab 
			{ 
				get
				{
					return this.selectOnTab;
				}
				set
				{
					this.selectOnTab = value;
				}
			}

			private bool snapToIncrement = false;

			/// <summary>
			/// Specify as true to enforce that only values on the increment boundary are accepted. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SnapToIncrement 
			{ 
				get
				{
					return this.snapToIncrement;
				}
				set
				{
					this.snapToIncrement = value;
				}
			}

			private string submitFormat = "t";

			/// <summary>
			/// The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).
			/// </summary>
			[DefaultValue("t")]
			public virtual string SubmitFormat 
			{ 
				get
				{
					return this.submitFormat;
				}
				set
				{
					this.submitFormat = value;
				}
			}

			private BoundList listConfig = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual BoundList ListConfig 
			{ 
				get
				{
					return this.listConfig;
				}
				set
				{
					this.listConfig = value;
				}
			}

			private int pageSize = 0;

			/// <summary>
			/// If greater than 0, a Ext.toolbar.Paging is displayed in the footer of the dropdown list and the filter queries will execute with page start and limit parameters. Only applies when queryMode = 'remote' (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int PageSize 
			{ 
				get
				{
					return this.pageSize;
				}
				set
				{
					this.pageSize = value;
				}
			}

			private bool queryCaching = true;

			/// <summary>
			/// When true, this prevents the combo from re-querying (either locally or remotely) when the current query is the same as the previous query. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool QueryCaching 
			{ 
				get
				{
					return this.queryCaching;
				}
				set
				{
					this.queryCaching = value;
				}
			}

			private int queryDelay = -1;

			/// <summary>
			/// The length of time in milliseconds to delay between the start of typing and sending the query to filter the dropdown list (defaults to 500 if queryMode = 'remote' or 10 if queryMode = 'local')
			/// </summary>
			[DefaultValue(-1)]
			public virtual int QueryDelay 
			{ 
				get
				{
					return this.queryDelay;
				}
				set
				{
					this.queryDelay = value;
				}
			}

			private DataLoadMode queryMode = DataLoadMode.Local;

			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
			/// </summary>
			[DefaultValue(DataLoadMode.Local)]
			public virtual DataLoadMode QueryMode 
			{ 
				get
				{
					return this.queryMode;
				}
				set
				{
					this.queryMode = value;
				}
			}

			private string queryParam = "query";

			/// <summary>
			/// Name of the parameter used by the Store to pass the typed string when the ComboBox is configured with queryMode: 'remote' (defaults to 'query'). If explicitly set to a falsy value it will not be sent.
			/// </summary>
			[DefaultValue("query")]
			public virtual string QueryParam 
			{ 
				get
				{
					return this.queryParam;
				}
				set
				{
					this.queryParam = value;
				}
			}

			private TriggerAction triggerAction = TriggerAction.Query;

			/// <summary>
			/// The action to execute when the trigger is clicked.
			/// </summary>
			[DefaultValue(TriggerAction.Query)]
			public virtual TriggerAction TriggerAction 
			{ 
				get
				{
					return this.triggerAction;
				}
				set
				{
					this.triggerAction = value;
				}
			}
        
			private ComboBoxListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ComboBoxListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ComboBoxListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ComboBoxDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ComboBoxDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ComboBoxDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}