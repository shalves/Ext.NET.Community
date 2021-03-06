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
    public partial class DataView
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DataView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DataView.Config Conversion to DataView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DataView(DataView.Config config)
        {
            return new DataView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractDataView.Config 
        { 
			/*  Implicit DataView.Config Conversion to DataView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DataView.Builder(DataView.Config config)
			{
				return new DataView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool deselectOnContainerClick = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeselectOnContainerClick 
			{ 
				get
				{
					return this.deselectOnContainerClick;
				}
				set
				{
					this.deselectOnContainerClick = value;
				}
			}

			private bool enableKeyNav = true;

			/// <summary>
			/// Turns on/off keyboard navigation within the DataView. 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableKeyNav 
			{ 
				get
				{
					return this.enableKeyNav;
				}
				set
				{
					this.enableKeyNav = value;
				}
			}
        
			private DataViewListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public DataViewListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new DataViewListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private DataViewDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public DataViewDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new DataViewDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			        
			private SelectedRowCollection selectedRows = null;

			/// <summary>
			/// 
			/// </summary>
			public SelectedRowCollection SelectedRows
			{
				get
				{
					if (this.selectedRows == null)
					{
						this.selectedRows = new SelectedRowCollection();
					}
			
					return this.selectedRows;
				}
			}
			
        }
    }
}