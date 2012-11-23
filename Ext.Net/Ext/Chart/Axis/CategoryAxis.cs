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
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// A type of axis that displays items in categories. This axis is generally used to display categorical information like names of items, month names, quarters, etc. but no quantitative values. For that other type of information Number axis are more suitable.
    /// </summary>
    [Meta]
    public partial class CategoryAxis : Axis
    {
        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]        
        public virtual string Type
        {
            get
            {
                return "Category";
            }
        }

        /// <summary>
        /// Indicates whether or not to calculate the number of categories (ticks and labels) when there is not enough room to display all labels on the axis. If set to true, the axis will determine the number of categories to plot. If not, all categories will be plotted. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Indicates whether or not to calculate the number of categories (ticks and labels) when there is not enough room to display all labels on the axis. If set to true, the axis will determine the number of categories to plot. If not, all categories will be plotted. Defaults to: false")]
        public virtual bool CalculateCategoryCount
        {
            get
            {
                return this.State.Get<bool>("CalculateCategoryCount", false);
            }
            set
            {
                this.State.Set("CalculateCategoryCount", value);
            }
        }

        /// <summary>
        /// A list of category names to display along this axis.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]        
        [DefaultValue(null)]
        [Description("A list of category names to display along this axis.")]
        public virtual string[] CategoryNames
        {
            get
            {
                return this.State.Get<string[]>("CategoryNames", null);
            }
            set
            {
                this.State.Set("CategoryNames", value);
            }
        }
    }
}
