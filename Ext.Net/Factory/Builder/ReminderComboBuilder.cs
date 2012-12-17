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
    public partial class ReminderCombo
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TReminderCombo, TBuilder> : ComboBox.Builder<TReminderCombo, TBuilder>
            where TReminderCombo : ReminderCombo
            where TBuilder : Builder<TReminderCombo, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TReminderCombo component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The label text to display next to this Component (defaults to 'Reminder').
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
			/// The underlying data field name to bind to this ComboBox (defaults to 'desc').
			/// </summary>
            public virtual TBuilder DisplayField(string displayField)
            {
                this.ToComponent().DisplayField = displayField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ValueField(string valueField)
            {
                this.ToComponent().ValueField = valueField;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ReminderCombo.Builder<ReminderCombo, ReminderCombo.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ReminderCombo()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ReminderCombo component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ReminderCombo.Config config) : base(new ReminderCombo(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ReminderCombo component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ReminderCombo.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ReminderCombo(this);
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
        public ReminderCombo.Builder ReminderCombo()
        {
#if MVC
			return this.ReminderCombo(new ReminderCombo { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ReminderCombo(new ReminderCombo());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ReminderCombo.Builder ReminderCombo(ReminderCombo component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ReminderCombo.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ReminderCombo.Builder ReminderCombo(ReminderCombo.Config config)
        {
#if MVC
			return new ReminderCombo.Builder(new ReminderCombo(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ReminderCombo.Builder(new ReminderCombo(config));
#endif			
        }
    }
}