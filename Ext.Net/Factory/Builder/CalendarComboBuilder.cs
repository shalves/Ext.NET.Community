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
    public partial class CalendarCombo
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCalendarCombo, TBuilder> : ComboBox.Builder<TCalendarCombo, TBuilder>
            where TCalendarCombo : CalendarCombo
            where TBuilder : Builder<TCalendarCombo, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCalendarCombo component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The calendar store ID to use.
			/// </summary>
            public virtual TBuilder CalendarStoreID(string calendarStoreID)
            {
                this.ToComponent().CalendarStoreID = calendarStoreID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The label text to display next to this Component (defaults to 'Calendar').
			/// </summary>
            public virtual TBuilder FieldLabel(string fieldLabel)
            {
                this.ToComponent().FieldLabel = fieldLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'All').
			/// </summary>
            public virtual TBuilder TriggerAction(TriggerAction triggerAction)
            {
                this.ToComponent().TriggerAction = triggerAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'Local' which loads from the server).
			/// </summary>
            public virtual TBuilder QueryMode(DataLoadMode queryMode)
            {
                this.ToComponent().QueryMode = queryMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true)
			/// </summary>
            public virtual TBuilder ForceSelection(bool forceSelection)
            {
                this.ToComponent().ForceSelection = forceSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to true).
			/// </summary>
            public virtual TBuilder SelectOnFocus(bool selectOnFocus)
            {
                this.ToComponent().SelectOnFocus = selectOnFocus;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CalendarCombo.Builder<CalendarCombo, CalendarCombo.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CalendarCombo()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CalendarCombo component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CalendarCombo.Config config) : base(new CalendarCombo(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CalendarCombo component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CalendarCombo.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CalendarCombo(this);
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
        public CalendarCombo.Builder CalendarCombo()
        {
#if MVC
			return this.CalendarCombo(new CalendarCombo { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CalendarCombo(new CalendarCombo());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CalendarCombo.Builder CalendarCombo(CalendarCombo component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CalendarCombo.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CalendarCombo.Builder CalendarCombo(CalendarCombo.Config config)
        {
#if MVC
			return new CalendarCombo.Builder(new CalendarCombo(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CalendarCombo.Builder(new CalendarCombo(config));
#endif			
        }
    }
}