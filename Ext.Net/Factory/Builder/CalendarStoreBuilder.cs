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
 * @version   : 2.0.0.rc2 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class CalendarStore
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Store.Builder<CalendarStore, CalendarStore.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CalendarStore()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CalendarStore component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CalendarStore.Config config) : base(new CalendarStore(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CalendarStore component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of CalendarStore.Builder</returns>
            public virtual CalendarStore.Builder Calendars(Action<CalendarModelCollection> action)
            {
                action(this.ToComponent().Calendars);
                return this as CalendarStore.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CalendarStore.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CalendarStore(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CalendarStore.Builder CalendarStore()
        {
            return this.CalendarStore(new CalendarStore());
        }

        /// <summary>
        /// 
        /// </summary>
        public CalendarStore.Builder CalendarStore(CalendarStore component)
        {
            return new CalendarStore.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CalendarStore.Builder CalendarStore(CalendarStore.Config config)
        {
            return new CalendarStore.Builder(new CalendarStore(config));
        }
    }
}