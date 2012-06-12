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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public abstract partial class AbstractCalendarView
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int startDay = 0;

			/// <summary>
			/// The 0-based index for the day on which the calendar week begins (0=Sunday, which is the default)
			/// </summary>
			[DefaultValue(0)]
			public virtual int StartDay 
			{ 
				get
				{
					return this.startDay;
				}
				set
				{
					this.startDay = value;
				}
			}

			private string dDCreateEventText = "Create event for {0}";

			/// <summary>
			/// The text to display inside the drag proxy while dragging over the calendar to create a new event (defaults to 'Create event for {0}' where {0} is a date range supplied by the view)
			/// </summary>
			[DefaultValue("Create event for {0}")]
			public virtual string DDCreateEventText 
			{ 
				get
				{
					return this.dDCreateEventText;
				}
				set
				{
					this.dDCreateEventText = value;
				}
			}

			private string dDMoveEventText = "Move event to {0}";

			/// <summary>
			/// The text to display inside the drag proxy while dragging an event to reposition it (defaults to 'Move event to {0}' where {0} is the updated event start date/time supplied by the view)
			/// </summary>
			[DefaultValue("Move event to {0}")]
			public virtual string DDMoveEventText 
			{ 
				get
				{
					return this.dDMoveEventText;
				}
				set
				{
					this.dDMoveEventText = value;
				}
			}

			private string dDResizeEventText = "Update event to {0}";

			/// <summary>
			/// The string displayed to the user in the drag proxy while dragging the resize handle of an event (defaults to 'Update event to {0}' where {0} is the updated event start-end range supplied by the view). Note that this text is only used in views that allow resizing of events.
			/// </summary>
			[DefaultValue("Update event to {0}")]
			public virtual string DDResizeEventText 
			{ 
				get
				{
					return this.dDResizeEventText;
				}
				set
				{
					this.dDResizeEventText = value;
				}
			}

			private bool enableAddFx = true;

			/// <summary>
			/// True to enable a visual effect on adding a new event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doAddFx method.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableAddFx 
			{ 
				get
				{
					return this.enableAddFx;
				}
				set
				{
					this.enableAddFx = value;
				}
			}

			private bool enableDD = true;

			/// <summary>
			/// True to enable drag and drop in the calendar view (the default), false to disable it
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableDD 
			{ 
				get
				{
					return this.enableDD;
				}
				set
				{
					this.enableDD = value;
				}
			}

			private bool enableFx = true;

			/// <summary>
			/// True to enable a visual effect on adding a new event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doAddFx method.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableFx 
			{ 
				get
				{
					return this.enableFx;
				}
				set
				{
					this.enableFx = value;
				}
			}

			private bool enableRemoveFx = true;

			/// <summary>
			/// True to enable a visual effect on removing an event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doRemoveFx method.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableRemoveFx 
			{ 
				get
				{
					return this.enableRemoveFx;
				}
				set
				{
					this.enableRemoveFx = value;
				}
			}

			private bool enableUpdateFx = false;

			/// <summary>
			/// True to enable a visual effect on updating an event, false to disable it (the default). Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doUpdateFx method.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableUpdateFx 
			{ 
				get
				{
					return this.enableUpdateFx;
				}
				set
				{
					this.enableUpdateFx = value;
				}
			}

			private bool monitorResize = true;

			/// <summary>
			/// True to monitor the browser's resize event (the default), false to ignore it. If the calendar view is rendered into a fixed-size container this can be set to false. However, if the view can change dimensions (e.g., it's in fit layout in a viewport or some other resizable container) it is very important that this config is true so that any resize event propagates properly to all subcomponents and layouts get recalculated properly.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MonitorResize 
			{ 
				get
				{
					return this.monitorResize;
				}
				set
				{
					this.monitorResize = value;
				}
			}

			private bool spansHavePriority = false;

			/// <summary>
			/// Allows switching between two different modes of rendering events that span multiple days. When true, span events are always sorted first, possibly at the expense of start dates being out of order (e.g., a span event that starts at 11am one day and spans into the next day would display before a non-spanning event that starts at 10am, even though they would not be in date order). This can lead to more compact layouts when there are many overlapping events. If false (the default), events will always sort by start date first which can result in a less compact, but chronologically consistent layout.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SpansHavePriority 
			{ 
				get
				{
					return this.spansHavePriority;
				}
				set
				{
					this.spansHavePriority = value;
				}
			}

			private bool trackMouseOver = true;

			/// <summary>
			/// Whether or not the view tracks and responds to the browser mouseover event on contained elements (defaults to true). If you don't need mouseover event highlighting you can disable this.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool TrackMouseOver 
			{ 
				get
				{
					return this.trackMouseOver;
				}
				set
				{
					this.trackMouseOver = value;
				}
			}

        }
    }
}