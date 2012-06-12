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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public partial class PanelHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractContainer.Builder<PanelHeader, PanelHeader.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PanelHeader()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PanelHeader component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PanelHeader.Config config) : base(new PanelHeader(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PanelHeader component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual PanelHeader.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as PanelHeader.Builder;
            }
             
 			/// <summary>
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
			/// </summary>
            public virtual PanelHeader.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as PanelHeader.Builder;
            }
             
 			/// <summary>
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
			/// </summary>
            public virtual PanelHeader.Builder IconPath(string iconPath)
            {
                this.ToComponent().IconPath = iconPath;
                return this as PanelHeader.Builder;
            }
             
 			/// <summary>
			/// Set a title for the panel's header. See Ext.panel.Header.title.
			/// </summary>
            public virtual PanelHeader.Builder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as PanelHeader.Builder;
            }
             
 			/// <summary>
			/// May be \"left\", \"right\" or \"center\". The alignment of the title text within the available space between the icon and the tools. Defaults to: \"left\"
			/// </summary>
            public virtual PanelHeader.Builder TitleAlign(TitleAlign titleAlign)
            {
                this.ToComponent().TitleAlign = titleAlign;
                return this as PanelHeader.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of PanelHeader.Builder</returns>
            public virtual PanelHeader.Builder Listeners(Action<PanelHeaderListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as PanelHeader.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of PanelHeader.Builder</returns>
            public virtual PanelHeader.Builder DirectEvents(Action<PanelHeaderDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as PanelHeader.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public PanelHeader.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PanelHeader(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public PanelHeader.Builder PanelHeader()
        {
            return this.PanelHeader(new PanelHeader());
        }

        /// <summary>
        /// 
        /// </summary>
        public PanelHeader.Builder PanelHeader(PanelHeader component)
        {
            return new PanelHeader.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PanelHeader.Builder PanelHeader(PanelHeader.Config config)
        {
            return new PanelHeader.Builder(new PanelHeader(config));
        }
    }
}