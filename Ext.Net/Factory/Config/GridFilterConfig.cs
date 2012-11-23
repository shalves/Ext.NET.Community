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
    public abstract partial class GridFilter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BaseItem.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool active = false;

			/// <summary>
			/// Indicates the initial status of the filter (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Active 
			{ 
				get
				{
					return this.active;
				}
				set
				{
					this.active = value;
				}
			}

			private string dataIndex = "";

			/// <summary>
			/// The Store data index of the field this filter represents. The dataIndex does not actually have to exist in the store.
			/// </summary>
			[DefaultValue("")]
			public virtual string DataIndex 
			{ 
				get
				{
					return this.dataIndex;
				}
				set
				{
					this.dataIndex = value;
				}
			}
        
			private ItemsCollection<AbstractComponent> menuItems = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<AbstractComponent> MenuItems
			{
				get
				{
					if (this.menuItems == null)
					{
						this.menuItems = new ItemsCollection<AbstractComponent>();
					}
			
					return this.menuItems;
				}
			}
			
			private int updateBuffer = 500;

			/// <summary>
			/// Number of milliseconds to wait after user interaction to fire an update. Only supported by filters: 'list', 'numeric', and 'string'. Defaults to 500.
			/// </summary>
			[DefaultValue(500)]
			public virtual int UpdateBuffer 
			{ 
				get
				{
					return this.updateBuffer;
				}
				set
				{
					this.updateBuffer = value;
				}
			}
        
			private JFunction getValue = null;

			/// <summary>
			/// Template method to be implemented by all subclasses that is to get and return the value of the filter.
			/// </summary>
			public JFunction GetValue
			{
				get
				{
					if (this.getValue == null)
					{
						this.getValue = new JFunction();
					}
			
					return this.getValue;
				}
			}
			        
			private JFunction setValueFunc = null;

			/// <summary>
			/// Template method to be implemented by all subclasses that is to set the value of the filter and fire the 'update' event.
			/// </summary>
			public JFunction SetValueFunc
			{
				get
				{
					if (this.setValueFunc == null)
					{
						this.setValueFunc = new JFunction();
					}
			
					return this.setValueFunc;
				}
			}
			        
			private JFunction getSerialArgs = null;

			/// <summary>
			/// Template method to be implemented by all subclasses that is to get and return serialized filter data for transmission to the server.
			/// </summary>
			public JFunction GetSerialArgs
			{
				get
				{
					if (this.getSerialArgs == null)
					{
						this.getSerialArgs = new JFunction();
					}
			
					return this.getSerialArgs;
				}
			}
			        
			private JFunction validateRecord = null;

			/// <summary>
			/// Template method to be implemented by all subclasses that is to validates the provided Ext.data.Record against the filters configuration.
			/// </summary>
			public JFunction ValidateRecord
			{
				get
				{
					if (this.validateRecord == null)
					{
						this.validateRecord = new JFunction();
					}
			
					return this.validateRecord;
				}
			}
			        
			private GridFilterListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public GridFilterListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new GridFilterListeners();
					}
			
					return this.listeners;
				}
			}
			
        }
    }
}