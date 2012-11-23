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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Tool(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Tool.Config Conversion to Tool
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Tool(Tool.Config config)
        {
            return new Tool(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComponentBase.Config 
        { 
			/*  Implicit Tool.Config Conversion to Tool.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Tool.Builder(Tool.Config config)
			{
				return new Tool.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private ToolType type = ToolType.None;

			/// <summary>
			/// The type of tool to create.
			/// </summary>
			[DefaultValue(ToolType.None)]
			public virtual ToolType Type 
			{ 
				get
				{
					return this.type;
				}
				set
				{
					this.type = value;
				}
			}

			private string customType = "";

			/// <summary>
			/// The custom type of tool to create.
			/// </summary>
			[DefaultValue("")]
			public virtual string CustomType 
			{ 
				get
				{
					return this.customType;
				}
				set
				{
					this.customType = value;
				}
			}

			private string fn = "";

			/// <summary>
			/// The raw JavaScript function to be called when this Listener fires.
			/// </summary>
			[DefaultValue("")]
			public virtual string Fn 
			{ 
				get
				{
					return this.fn;
				}
				set
				{
					this.fn = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// The function to call when clicked. Arguments passed are 'event', 'toolEl', 'owner' and 'tool'.
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private string scope = "this";

			/// <summary>
			/// The scope in which to call the handler.
			/// </summary>
			[DefaultValue("this")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private bool stopEvent = true;

			/// <summary>
			/// Specify as false to allow click event to propagate. Default to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool StopEvent 
			{ 
				get
				{
					return this.stopEvent;
				}
				set
				{
					this.stopEvent = value;
				}
			}

			private string toolTip = "";

			/// <summary>
			/// A tip string.
			/// </summary>
			[DefaultValue("")]
			public virtual string ToolTip 
			{ 
				get
				{
					return this.toolTip;
				}
				set
				{
					this.toolTip = value;
				}
			}
        
			private QTipCfg tooltipConfig = null;

			/// <summary>
			/// A tip string.
			/// </summary>
			public QTipCfg TooltipConfig
			{
				get
				{
					if (this.tooltipConfig == null)
					{
						this.tooltipConfig = new QTipCfg();
					}
			
					return this.tooltipConfig;
				}
			}
			
			private ToolTipType toolTipType = ToolTipType.Qtip;

			/// <summary>
			/// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute. Defaults to: \"qtip\"
			/// </summary>
			[DefaultValue(ToolTipType.Qtip)]
			public virtual ToolTipType ToolTipType 
			{ 
				get
				{
					return this.toolTipType;
				}
				set
				{
					this.toolTipType = value;
				}
			}
        
			private ToolListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ToolListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ToolListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ToolDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ToolDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ToolDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
			private string directClickUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DirectClickUrl 
			{ 
				get
				{
					return this.directClickUrl;
				}
				set
				{
					this.directClickUrl = value;
				}
			}

        }
    }
}