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
    public partial class KeyNav
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TKeyNav, TBuilder> : Observable.Builder<TKeyNav, TBuilder>
            where TKeyNav : KeyNav
            where TBuilder : Builder<TKeyNav, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TKeyNav component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to listen component event instead underlying element
			/// </summary>
            public virtual TBuilder ComponentEvent(bool componentEvent)
            {
                this.ToComponent().ComponentEvent = componentEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation.
			/// </summary>
            public virtual TBuilder DefaultEventAction(EventAction defaultEventAction)
            {
                this.ToComponent().DefaultEventAction = defaultEventAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable this KeyNav instance (defaults to false)
			/// </summary>
            public virtual TBuilder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The event to listen for to pick up key events. Defaults to: \"keypress\"
			/// </summary>
            public virtual TBuilder EventName(string eventName)
            {
                this.ToComponent().EventName = eventName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Handle the keydown event instead of keypress. KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress. Defaults to: false
			/// </summary>
            public virtual TBuilder ForceKeyDown(bool forceKeyDown)
            {
                this.ToComponent().ForceKeyDown = forceKeyDown;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Element name of target component (can be used if KeyNav belongs to a component)
			/// </summary>
            public virtual TBuilder ComponentElement(string componentElement)
            {
                this.ToComponent().ComponentElement = componentElement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Configure this as true if there are any input fields within the target, and this KeyNav should not process events from input fields, (&lt;input>, &lt;textarea> and elements withcontentEditable=\"true\"). Defaults to: false
			/// </summary>
            public virtual TBuilder IgnoreInputFields(bool ignoreInputFields)
            {
                this.ToComponent().IgnoreInputFields = ignoreInputFields;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ProcessEvent(Action<JFunction> action)
            {
                action(this.ToComponent().ProcessEvent);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The scope (this context) in which the processEvent method is executed.
			/// </summary>
            public virtual TBuilder ProcessEventScope(string processEventScope)
            {
                this.ToComponent().ProcessEventScope = processEventScope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The element to bind to
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Space(Action<JFunction> action)
            {
                action(this.ToComponent().Space);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Left(Action<JFunction> action)
            {
                action(this.ToComponent().Left);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Right(Action<JFunction> action)
            {
                action(this.ToComponent().Right);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Up(Action<JFunction> action)
            {
                action(this.ToComponent().Up);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Down(Action<JFunction> action)
            {
                action(this.ToComponent().Down);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PageUp(Action<JFunction> action)
            {
                action(this.ToComponent().PageUp);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PageDown(Action<JFunction> action)
            {
                action(this.ToComponent().PageDown);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Del(Action<JFunction> action)
            {
                action(this.ToComponent().Del);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Home(Action<JFunction> action)
            {
                action(this.ToComponent().Home);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder End(Action<JFunction> action)
            {
                action(this.ToComponent().End);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Enter(Action<JFunction> action)
            {
                action(this.ToComponent().Enter);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Esc(Action<JFunction> action)
            {
                action(this.ToComponent().Esc);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Tab(Action<JFunction> action)
            {
                action(this.ToComponent().Tab);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : KeyNav.Builder<KeyNav, KeyNav.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new KeyNav()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyNav component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyNav.Config config) : base(new KeyNav(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(KeyNav component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyNav.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.KeyNav(this);
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
        public KeyNav.Builder KeyNav()
        {
#if MVC
			return this.KeyNav(new KeyNav { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.KeyNav(new KeyNav());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyNav.Builder KeyNav(KeyNav component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new KeyNav.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyNav.Builder KeyNav(KeyNav.Config config)
        {
#if MVC
			return new KeyNav.Builder(new KeyNav(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new KeyNav.Builder(new KeyNav(config));
#endif			
        }
    }
}