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
    public partial class FieldSet
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TFieldSet, TBuilder> : AbstractContainer.Builder<TFieldSet, TBuilder>
            where TFieldSet : FieldSet
            where TBuilder : Builder<TFieldSet, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFieldSet component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name to assign to the fieldset's checkbox if checkboxToggle = true (defaults to '[fieldset id]-checkbox').
			/// </summary>
            public virtual TBuilder CheckboxName(string checkboxName)
            {
                this.ToComponent().CheckboxName = checkboxName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to render a checkbox into the fieldset frame just in front of the legend to expand/collapse the fieldset when the checkbox is toggled. (defaults to false). This checkbox will be included in form submits using the checkboxName.
			/// </summary>
            public virtual TBuilder CheckboxToggle(bool checkboxToggle)
            {
                this.ToComponent().CheckboxToggle = checkboxToggle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to render the fieldset as collapsed by default. If checkboxToggle is specified, the checkbox will also be unchecked by default.
			/// </summary>
            public virtual TBuilder Collapsed(bool collapsed)
            {
                this.ToComponent().Collapsed = collapsed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to make the fieldset collapsible and have the expand/collapse toggle button automatically rendered into the legend element, false to keep the fieldset statically sized with no collapse button (defaults to false). Another option is to configure checkboxToggle. Use the collapsed config to collapse the fieldset by default.
			/// </summary>
            public virtual TBuilder Collapsible(bool collapsible)
            {
                this.ToComponent().Collapsible = collapsible;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A title to be displayed in the fieldset's legend. May contain HTML markup.
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true will add a listener to the titleCmp property for the click event which will execute the toggle method. This option is only used when the collapsible property is set to true. Defaults to: true
			/// </summary>
            public virtual TBuilder ToggleOnTitleClick(bool toggleOnTitleClick)
            {
                this.ToComponent().ToggleOnTitleClick = toggleOnTitleClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<FieldSetListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<FieldSetDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : FieldSet.Builder<FieldSet, FieldSet.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FieldSet()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldSet component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldSet.Config config) : base(new FieldSet(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FieldSet component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldSet.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FieldSet(this);
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
        public FieldSet.Builder FieldSet()
        {
#if MVC
			return this.FieldSet(new FieldSet { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.FieldSet(new FieldSet());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldSet.Builder FieldSet(FieldSet component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new FieldSet.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldSet.Builder FieldSet(FieldSet.Config config)
        {
#if MVC
			return new FieldSet.Builder(new FieldSet(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new FieldSet.Builder(new FieldSet(config));
#endif			
        }
    }
}