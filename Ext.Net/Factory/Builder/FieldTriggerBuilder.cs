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
    public partial class FieldTrigger
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TFieldTrigger, TBuilder> : BaseItem.Builder<TFieldTrigger, TBuilder>
            where TFieldTrigger : FieldTrigger
            where TBuilder : Builder<TFieldTrigger, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFieldTrigger component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A trigger tag
			/// </summary>
            public virtual TBuilder Tag(string tag)
            {
                this.ToComponent().Tag = tag;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the trigger element and display only the base text field (defaults to false).
			/// </summary>
            public virtual TBuilder HideTrigger(bool hideTrigger)
            {
                this.ToComponent().HideTrigger = hideTrigger;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to apply to the trigger.
			/// </summary>
            public virtual TBuilder TriggerCls(string triggerCls)
            {
                this.ToComponent().TriggerCls = triggerCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the trigger. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(TriggerIcon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Quick tip.
			/// </summary>
            public virtual TBuilder Qtip(string qtip)
            {
                this.ToComponent().Qtip = qtip;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : FieldTrigger.Builder<FieldTrigger, FieldTrigger.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FieldTrigger()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldTrigger component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldTrigger.Config config) : base(new FieldTrigger(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FieldTrigger component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldTrigger.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FieldTrigger(this);
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
        public FieldTrigger.Builder FieldTrigger()
        {
#if MVC
			return this.FieldTrigger(new FieldTrigger { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.FieldTrigger(new FieldTrigger());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldTrigger.Builder FieldTrigger(FieldTrigger component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new FieldTrigger.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldTrigger.Builder FieldTrigger(FieldTrigger.Config config)
        {
#if MVC
			return new FieldTrigger.Builder(new FieldTrigger(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new FieldTrigger.Builder(new FieldTrigger(config));
#endif			
        }
    }
}