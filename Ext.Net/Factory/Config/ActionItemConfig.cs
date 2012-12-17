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
    public partial class ActionItem
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ActionItem(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ActionItem.Config Conversion to ActionItem
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ActionItem(ActionItem.Config config)
        {
            return new ActionItem(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit ActionItem.Config Conversion to ActionItem.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ActionItem.Builder(ActionItem.Config config)
			{
				return new ActionItem.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private Icon icon = Icon.None;

			/// <summary>
			/// An icon to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A CSS class to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private string iconUrl = "";

			/// <summary>
			/// The url of an image to display as the clickable element in the column.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconUrl 
			{ 
				get
				{
					return this.iconUrl;
				}
				set
				{
					this.iconUrl = value;
				}
			}
        
			private JFunction getClass = null;

			/// <summary>
			/// A function which returns the CSS class to apply to the icon image.
			/// </summary>
			public JFunction GetClass
			{
				get
				{
					if (this.getClass == null)
					{
						this.getClass = new JFunction();
					}
			
					return this.getClass;
				}
			}
			        
			private JFunction getTip = null;

			/// <summary>
			/// A function which returns the tooltip string for any row.
			/// </summary>
			public JFunction GetTip
			{
				get
				{
					if (this.getTip == null)
					{
						this.getTip = new JFunction();
					}
			
					return this.getTip;
				}
			}
			        
			private JFunction isDisabled = null;

			/// <summary>
			/// A function which determines whether the action item for any row is disabled and returns true or false.
			/// </summary>
			public JFunction IsDisabled
			{
				get
				{
					if (this.isDisabled == null)
					{
						this.isDisabled = new JFunction();
					}
			
					return this.isDisabled;
				}
			}
			
			private string handler = "";

			/// <summary>
			/// A function called when the icon is clicked.
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

			private string scope = null;

			/// <summary>
			/// The scope (this reference) in which the handler, getClass, isDisabled and getTip fuctions are executed. Defaults to this Column.
			/// </summary>
			[DefaultValue(null)]
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

			private string tooltip = null;

			/// <summary>
			/// A tooltip message to be displayed on hover. Ext.tip.QuickTipManager must have been initialized.
			/// </summary>
			[DefaultValue(null)]
			public virtual string Tooltip 
			{ 
				get
				{
					return this.tooltip;
				}
				set
				{
					this.tooltip = value;
				}
			}

			private bool disabled = false;

			/// <summary>
			/// If true, the action will not respond to click events, and will be displayed semi-opaque.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Disabled 
			{ 
				get
				{
					return this.disabled;
				}
				set
				{
					this.disabled = value;
				}
			}

        }
    }
}