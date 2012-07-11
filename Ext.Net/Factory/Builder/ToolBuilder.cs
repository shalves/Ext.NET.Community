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
    public partial class Tool
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentBase.Builder<Tool, Tool.Builder>
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
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Specify as false to allow click event to propagate. Default to true.
			/// </summary>
            public virtual Tool.Builder StopEvent(bool stopEvent)
            {
                this.ToComponent().StopEvent = stopEvent;
                return this as Tool.Builder;
            }
             
 			/// <summary>
			/// A tip string.
			/// </summary>
            public virtual Tool.Builder ToolTip(string toolTip)
            {
                this.ToComponent().ToolTip = toolTip;
                return this as Tool.Builder;
            }
             
 			/// <summary>
			/// A tip string.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Tool.Builder</returns>
            public virtual Tool.Builder TooltipConfig(Action<QTipCfg> action)
            {
                action(this.ToComponent().TooltipConfig);
                return this as Tool.Builder;
            }
			 
 			/// <summary>
			/// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute. Defaults to: \"qtip\"
			/// </summary>
            public virtual Tool.Builder ToolTipType(ToolTipType toolTipType)
            {
                this.ToComponent().ToolTipType = toolTipType;
                return this as Tool.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Tool.Builder</returns>
            public virtual Tool.Builder Listeners(Action<ToolListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as Tool.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Tool.Builder</returns>
            public virtual Tool.Builder DirectEvents(Action<ToolDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as Tool.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Tool.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Tool(this);
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
            return this.Tool(new Tool());
        }

        /// <summary>
        /// 
        /// </summary>
        public Tool.Builder Tool(Tool component)
        {
            return new Tool.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Tool.Builder Tool(Tool.Config config)
        {
            return new Tool.Builder(new Tool(config));
        }
    }
}