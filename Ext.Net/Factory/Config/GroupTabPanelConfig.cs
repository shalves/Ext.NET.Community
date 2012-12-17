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
    public partial class GroupTabPanel
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GroupTabPanel(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GroupTabPanel.Config Conversion to GroupTabPanel
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GroupTabPanel(GroupTabPanel.Config config)
        {
            return new GroupTabPanel(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractContainer.Config 
        { 
			/*  Implicit GroupTabPanel.Config Conversion to GroupTabPanel.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GroupTabPanel.Builder(GroupTabPanel.Config config)
			{
				return new GroupTabPanel.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool deferredRender = false;

			/// <summary>
			/// Deferred Render
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DeferredRender 
			{ 
				get
				{
					return this.deferredRender;
				}
				set
				{
					this.deferredRender = value;
				}
			}

			private string activeGroup = "";

			/// <summary>
			/// Active group
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveGroup 
			{ 
				get
				{
					return this.activeGroup;
				}
				set
				{
					this.activeGroup = value;
				}
			}

			private int activeGroupIndex = -1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(-1)]
			public virtual int ActiveGroupIndex 
			{ 
				get
				{
					return this.activeGroupIndex;
				}
				set
				{
					this.activeGroupIndex = value;
				}
			}

			private string activeTab = "";

			/// <summary>
			/// Active tab
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveTab 
			{ 
				get
				{
					return this.activeTab;
				}
				set
				{
					this.activeTab = value;
				}
			}

			private int activeTabIndex = -1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(-1)]
			public virtual int ActiveTabIndex 
			{ 
				get
				{
					return this.activeTabIndex;
				}
				set
				{
					this.activeTabIndex = value;
				}
			}

			private Unit tabWidth = Unit.Pixel(120);

			/// <summary>
			/// The initial width in pixels of each new tab (defaults to 120).
			/// </summary>
			[DefaultValue(typeof(Unit), "120")]
			public virtual Unit TabWidth 
			{ 
				get
				{
					return this.tabWidth;
				}
				set
				{
					this.tabWidth = value;
				}
			}
        
			private GroupTabPanelListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public GroupTabPanelListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new GroupTabPanelListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private GroupTabPanelDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public GroupTabPanelDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new GroupTabPanelDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}