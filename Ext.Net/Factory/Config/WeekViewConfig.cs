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
    public partial class WeekView
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public WeekView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit WeekView.Config Conversion to WeekView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator WeekView(WeekView.Config config)
        {
            return new WeekView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DayView.Config 
        { 
			/*  Implicit WeekView.Config Conversion to WeekView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator WeekView.Builder(WeekView.Config config)
			{
				return new WeekView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int dayCount = 7;

			/// <summary>
			/// The number of days to display in the view (defaults to 7)
			/// </summary>
			[DefaultValue(7)]
			public override int DayCount 
			{ 
				get
				{
					return this.dayCount;
				}
				set
				{
					this.dayCount = value;
				}
			}

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

        }
    }
}