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
    public partial class BooleanFilter
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public BooleanFilter(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit BooleanFilter.Config Conversion to BooleanFilter
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator BooleanFilter(BooleanFilter.Config config)
        {
            return new BooleanFilter(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridFilter.Config 
        { 
			/*  Implicit BooleanFilter.Config Conversion to BooleanFilter.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator BooleanFilter.Builder(BooleanFilter.Config config)
			{
				return new BooleanFilter.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string yesText = "Yes";

			/// <summary>
			/// The text displayed for the 'Yes' checkbox
			/// </summary>
			[DefaultValue("Yes")]
			public virtual string YesText 
			{ 
				get
				{
					return this.yesText;
				}
				set
				{
					this.yesText = value;
				}
			}

			private string noText = "No";

			/// <summary>
			/// The text displayed for the 'No' checkbox
			/// </summary>
			[DefaultValue("No")]
			public virtual string NoText 
			{ 
				get
				{
					return this.noText;
				}
				set
				{
					this.noText = value;
				}
			}

			private bool defaultValue = false;

			/// <summary>
			/// The default value of this filter (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DefaultValue 
			{ 
				get
				{
					return this.defaultValue;
				}
				set
				{
					this.defaultValue = value;
				}
			}

			private bool? value = null;

			/// <summary>
			/// Predefined filter value
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Value 
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

        }
    }
}