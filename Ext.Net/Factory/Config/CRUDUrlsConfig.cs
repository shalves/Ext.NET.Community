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
 * @version   : 2.0.0 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class CRUDUrls
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CRUDUrls(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CRUDUrls.Config Conversion to CRUDUrls
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CRUDUrls(CRUDUrls.Config config)
        {
            return new CRUDUrls(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit CRUDUrls.Config Conversion to CRUDUrls.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CRUDUrls.Builder(CRUDUrls.Config config)
			{
				return new CRUDUrls.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string sync = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Sync 
			{ 
				get
				{
					return this.sync;
				}
				set
				{
					this.sync = value;
				}
			}

			private string create = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Create 
			{ 
				get
				{
					return this.create;
				}
				set
				{
					this.create = value;
				}
			}

			private string read = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Read 
			{ 
				get
				{
					return this.read;
				}
				set
				{
					this.read = value;
				}
			}

			private string update = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Update 
			{ 
				get
				{
					return this.update;
				}
				set
				{
					this.update = value;
				}
			}

			private string destroy = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Destroy 
			{ 
				get
				{
					return this.destroy;
				}
				set
				{
					this.destroy = value;
				}
			}

        }
    }
}