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
    public partial class Tool
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTool, TBuilder> : ComponentBase.Builder<TTool, TBuilder>
            where TTool : Tool
            where TBuilder : Builder<TTool, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTool component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The type of tool to create.
			/// </summary>
            public virtual TBuilder Type(ToolType type)
            {
                this.ToComponent().Type = type;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The custom type of tool to create.
			/// </summary>
            public virtual TBuilder CustomType(string customType)
            {
                this.ToComponent().CustomType = customType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The raw JavaScript function to be called when this Listener fires.
			/// </summary>
            public virtual TBuilder Fn(string fn)
            {
                this.ToComponent().Fn = fn;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The function to call when clicked. Arguments passed are 'event', 'toolEl', 'owner' and 'tool'.
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope in which to call the handler.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify as false to allow click event to propagate. Default to true.
			/// </summary>
            public virtual TBuilder StopEvent(bool stopEvent)
            {
                this.ToComponent().StopEvent = stopEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A tip string.
			/// </summary>
            public virtual TBuilder ToolTip(string toolTip)
            {
                this.ToComponent().ToolTip = toolTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A tip string.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TooltipConfig(Action<QTipCfg> action)
            {
                action(this.ToComponent().TooltipConfig);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute. Defaults to: \"qtip\"
			/// </summary>
            public virtual TBuilder ToolTipType(ToolTipType toolTipType)
            {
                this.ToComponent().ToolTipType = toolTipType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ToolListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ToolDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DirectClickUrl(string directClickUrl)
            {
                this.ToComponent().DirectClickUrl = directClickUrl;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Tool.Builder<Tool, Tool.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Tool()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Tool component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Tool.Config config) : base(new Tool(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Tool component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Tool.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Tool(this);
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
        public Tool.Builder Tool()
        {
#if MVC
			return this.Tool(new Tool { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Tool(new Tool());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Tool.Builder Tool(Tool component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Tool.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Tool.Builder Tool(Tool.Config config)
        {
#if MVC
			return new Tool.Builder(new Tool(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Tool.Builder(new Tool(config));
#endif			
        }
    }
}