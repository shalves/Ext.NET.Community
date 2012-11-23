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
    public partial class CycleButton
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCycleButton, TBuilder> : SplitButtonBase.Builder<TCycleButton, TBuilder>
            where TCycleButton : CycleButton
            where TBuilder : Builder<TCycleButton, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCycleButton component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A callback function that will be invoked each time the active menu items in the button's menu has changed. If this callback is not supplied, the SplitButton will instead fire the change event on active items change. The changeHandler function will be called with the following argument list: (SplitButton this, Ext.menu.CheckItem items).
			/// </summary>
            public virtual TBuilder ChangeHandler(string changeHandler)
            {
                this.ToComponent().ChangeHandler = changeHandler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class which sets an image to be used as the static icon for this button. This icon will always be displayed regardless of which item is selected in the dropdown list. This overrides the default behavior of changing the button's icon to match the selected item's icon on change.
			/// </summary>
            public virtual TBuilder ForceIcon(string forceIcon)
            {
                this.ToComponent().ForceIcon = forceIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A static string to prepend before the active items's text when displayed as the button's text (only applies when showText = true, defaults to '')
			/// </summary>
            public virtual TBuilder PrependText(string prependText)
            {
                this.ToComponent().PrependText = prependText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the active item's text as the button text. The Button will show its configured text if this config is omitted (defaults to false).
			/// </summary>
            public virtual TBuilder ShowText(bool showText)
            {
                this.ToComponent().ShowText = showText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to prevent change active item after button click (defaults to true).
			/// </summary>
            public virtual TBuilder ToggleOnClick(bool toggleOnClick)
            {
                this.ToComponent().ToggleOnClick = toggleOnClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<CycleButtonListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<CycleButtonDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DirectChangeUrl(string directChangeUrl)
            {
                this.ToComponent().DirectChangeUrl = directChangeUrl;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// This is normally called internally on button click, but can be called externally to advance the button's active item programmatically to the next one in the menu. If the current item is the last one in the menu the active item will be set to the first item in the menu.
			/// </summary>
            public virtual TBuilder ToggleSelected()
            {
                this.ToComponent().ToggleSelected();
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CycleButton.Builder<CycleButton, CycleButton.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CycleButton()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CycleButton component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CycleButton.Config config) : base(new CycleButton(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CycleButton component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CycleButton.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CycleButton(this);
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
        public CycleButton.Builder CycleButton()
        {
#if MVC
			return this.CycleButton(new CycleButton { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CycleButton(new CycleButton());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CycleButton.Builder CycleButton(CycleButton component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CycleButton.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CycleButton.Builder CycleButton(CycleButton.Config config)
        {
#if MVC
			return new CycleButton.Builder(new CycleButton(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CycleButton.Builder(new CycleButton(config));
#endif			
        }
    }
}