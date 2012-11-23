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
    public partial class CRUDMethods
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CRUDMethods.Config Conversion to CRUDMethods
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CRUDMethods(CRUDMethods.Config config)
        {
            return new CRUDMethods(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit CRUDMethods.Config Conversion to CRUDMethods.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CRUDMethods.Builder(CRUDMethods.Config config)
			{
				return new CRUDMethods.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private HttpMethod create = HttpMethod.Default;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Create 
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

			private HttpMethod read = HttpMethod.Default;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Read 
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

			private HttpMethod update = HttpMethod.Default;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Update 
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

			private HttpMethod destroy = HttpMethod.Default;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Destroy 
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