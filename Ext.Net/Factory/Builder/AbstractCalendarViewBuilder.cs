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
    public abstract partial class AbstractCalendarView
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TAbstractCalendarView, TBuilder> : ComponentBase.Builder<TAbstractCalendarView, TBuilder>
            where TAbstractCalendarView : AbstractCalendarView
            where TBuilder : Builder<TAbstractCalendarView, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractCalendarView component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The 0-based index for the day on which the calendar week begins (0=Sunday, which is the default)
			/// </summary>
            public virtual TBuilder StartDay(int startDay)
            {
                this.ToComponent().StartDay = startDay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display inside the drag proxy while dragging over the calendar to create a new event (defaults to 'Create event for {0}' where {0} is a date range supplied by the view)
			/// </summary>
            public virtual TBuilder DDCreateEventText(string dDCreateEventText)
            {
                this.ToComponent().DDCreateEventText = dDCreateEventText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display inside the drag proxy while dragging an event to reposition it (defaults to 'Move event to {0}' where {0} is the updated event start date/time supplied by the view)
			/// </summary>
            public virtual TBuilder DDMoveEventText(string dDMoveEventText)
            {
                this.ToComponent().DDMoveEventText = dDMoveEventText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The string displayed to the user in the drag proxy while dragging the resize handle of an event (defaults to 'Update event to {0}' where {0} is the updated event start-end range supplied by the view). Note that this text is only used in views that allow resizing of events.
			/// </summary>
            public virtual TBuilder DDResizeEventText(string dDResizeEventText)
            {
                this.ToComponent().DDResizeEventText = dDResizeEventText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable a visual effect on adding a new event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doAddFx method.
			/// </summary>
            public virtual TBuilder EnableAddFx(bool enableAddFx)
            {
                this.ToComponent().EnableAddFx = enableAddFx;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable drag and drop in the calendar view (the default), false to disable it
			/// </summary>
            public virtual TBuilder EnableDD(bool enableDD)
            {
                this.ToComponent().EnableDD = enableDD;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable a visual effect on adding a new event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doAddFx method.
			/// </summary>
            public virtual TBuilder EnableFx(bool enableFx)
            {
                this.ToComponent().EnableFx = enableFx;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable a visual effect on removing an event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doRemoveFx method.
			/// </summary>
            public virtual TBuilder EnableRemoveFx(bool enableRemoveFx)
            {
                this.ToComponent().EnableRemoveFx = enableRemoveFx;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable a visual effect on updating an event, false to disable it (the default). Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doUpdateFx method.
			/// </summary>
            public virtual TBuilder EnableUpdateFx(bool enableUpdateFx)
            {
                this.ToComponent().EnableUpdateFx = enableUpdateFx;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to monitor the browser's resize event (the default), false to ignore it. If the calendar view is rendered into a fixed-size container this can be set to false. However, if the view can change dimensions (e.g., it's in fit layout in a viewport or some other resizable container) it is very important that this config is true so that any resize event propagates properly to all subcomponents and layouts get recalculated properly.
			/// </summary>
            public virtual TBuilder MonitorResize(bool monitorResize)
            {
                this.ToComponent().MonitorResize = monitorResize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allows switching between two different modes of rendering events that span multiple days. When true, span events are always sorted first, possibly at the expense of start dates being out of order (e.g., a span event that starts at 11am one day and spans into the next day would display before a non-spanning event that starts at 10am, even though they would not be in date order). This can lead to more compact layouts when there are many overlapping events. If false (the default), events will always sort by start date first which can result in a less compact, but chronologically consistent layout.
			/// </summary>
            public virtual TBuilder SpansHavePriority(bool spansHavePriority)
            {
                this.ToComponent().SpansHavePriority = spansHavePriority;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether or not the view tracks and responds to the browser mouseover event on contained elements (defaults to true). If you don't need mouseover event highlighting you can disable this.
			/// </summary>
            public virtual TBuilder TrackMouseOver(bool trackMouseOver)
            {
                this.ToComponent().TrackMouseOver = trackMouseOver;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}