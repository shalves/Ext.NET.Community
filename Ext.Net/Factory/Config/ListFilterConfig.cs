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
    public partial class ListFilter
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ListFilter(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ListFilter.Config Conversion to ListFilter
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ListFilter(ListFilter.Config config)
        {
            return new ListFilter(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridFilter.Config 
        { 
			/*  Implicit ListFilter.Config Conversion to ListFilter.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ListFilter.Builder(ListFilter.Config config)
			{
				return new ListFilter.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string iDField = "id";

			/// <summary>
			/// Defaults to 'id'.
			/// </summary>
			[DefaultValue("id")]
			public virtual string IDField 
			{ 
				get
				{
					return this.iDField;
				}
				set
				{
					this.iDField = value;
				}
			}

			private string loadingText = "Loading...";

			/// <summary>
			/// The loading text displayed when data loading
			/// </summary>
			[DefaultValue("Loading...")]
			public virtual string LoadingText 
			{ 
				get
				{
					return this.loadingText;
				}
				set
				{
					this.loadingText = value;
				}
			}

			private bool loadOnShow = true;

			/// <summary>
			/// If true then the data loading on show
			/// </summary>
			[DefaultValue(true)]
			public virtual bool LoadOnShow 
			{ 
				get
				{
					return this.loadOnShow;
				}
				set
				{
					this.loadOnShow = value;
				}
			}

			private bool single = false;

			/// <summary>
			/// Specify true to group all items in this list into a single-select radio button group. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Single 
			{ 
				get
				{
					return this.single;
				}
				set
				{
					this.single = value;
				}
			}

			private string[] options = null;

			/// <summary>
			/// The list of options
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Options 
			{ 
				get
				{
					return this.options;
				}
				set
				{
					this.options = value;
				}
			}

			private string[] value = null;

			/// <summary>
			/// The list of options
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}

			private string storeID = "";

			/// <summary>
			/// The data store to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string StoreID 
			{ 
				get
				{
					return this.storeID;
				}
				set
				{
					this.storeID = value;
				}
			}

			private string labelField = "text";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("text")]
			public virtual string LabelField 
			{ 
				get
				{
					return this.labelField;
				}
				set
				{
					this.labelField = value;
				}
			}

			private Menu menuConfig = null;

			/// <summary>
			/// The config of the ListFilter menu. Defaults to null.
			/// </summary>
			[DefaultValue(null)]
			public virtual Menu MenuConfig 
			{ 
				get
				{
					return this.menuConfig;
				}
				set
				{
					this.menuConfig = value;
				}
			}

        }
    }
}