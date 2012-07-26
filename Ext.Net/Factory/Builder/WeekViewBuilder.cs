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
 * @version   : 2.0.0 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : DayView.Builder<WeekView, WeekView.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new WeekView()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(WeekView component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(WeekView.Config config) : base(new WeekView(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(WeekView component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The number of days to display in the view (defaults to 7)
			/// </summary>
            public virtual WeekView.Builder DayCount(int dayCount)
            {
                this.ToComponent().DayCount = dayCount;
                return this as WeekView.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.WeekView(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder WeekView()
        {
            return this.WeekView(new WeekView());
        }

        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder WeekView(WeekView component)
        {
            return new WeekView.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder WeekView(WeekView.Config config)
        {
            return new WeekView.Builder(new WeekView(config));
        }
    }
}