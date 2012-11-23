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
    public partial class CategoryAxis
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CategoryAxis.Config Conversion to CategoryAxis
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CategoryAxis(CategoryAxis.Config config)
        {
            return new CategoryAxis(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Axis.Config 
        { 
			/*  Implicit CategoryAxis.Config Conversion to CategoryAxis.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CategoryAxis.Builder(CategoryAxis.Config config)
			{
				return new CategoryAxis.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool calculateCategoryCount = false;

			/// <summary>
			/// Indicates whether or not to calculate the number of categories (ticks and labels) when there is not enough room to display all labels on the axis. If set to true, the axis will determine the number of categories to plot. If not, all categories will be plotted. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CalculateCategoryCount 
			{ 
				get
				{
					return this.calculateCategoryCount;
				}
				set
				{
					this.calculateCategoryCount = value;
				}
			}

			private string[] categoryNames = null;

			/// <summary>
			/// A list of category names to display along this axis.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] CategoryNames 
			{ 
				get
				{
					return this.categoryNames;
				}
				set
				{
					this.categoryNames = value;
				}
			}

        }
    }
}