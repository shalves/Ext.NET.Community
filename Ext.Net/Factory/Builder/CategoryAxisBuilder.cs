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
 * @version   : 2.0.0.rc1 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Axis.Builder<CategoryAxis, CategoryAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CategoryAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CategoryAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CategoryAxis.Config config) : base(new CategoryAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CategoryAxis component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Indicates whether or not to calculate the number of categories (ticks and labels) when there is not enough room to display all labels on the axis. If set to true, the axis will determine the number of categories to plot. If not, all categories will be plotted. Defaults to: false
			/// </summary>
            public virtual CategoryAxis.Builder CalculateCategoryCount(bool calculateCategoryCount)
            {
                this.ToComponent().CalculateCategoryCount = calculateCategoryCount;
                return this as CategoryAxis.Builder;
            }
             
 			/// <summary>
			/// A list of category names to display along this axis.
			/// </summary>
            public virtual CategoryAxis.Builder CategoryNames(string[] categoryNames)
            {
                this.ToComponent().CategoryNames = categoryNames;
                return this as CategoryAxis.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CategoryAxis(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder CategoryAxis()
        {
            return this.CategoryAxis(new CategoryAxis());
        }

        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder CategoryAxis(CategoryAxis component)
        {
            return new CategoryAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis.Builder CategoryAxis(CategoryAxis.Config config)
        {
            return new CategoryAxis.Builder(new CategoryAxis(config));
        }
    }
}