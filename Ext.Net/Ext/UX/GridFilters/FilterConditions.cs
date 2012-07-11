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
 * @version   : 2.0.0.rc2 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

using Ext.Net.Utilities;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class FilterConditions
    {
        private string filtersStr;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FilterConditions(string filtersStr)
        {
            this.filtersStr = filtersStr;
            this.ParseConditions();
        }

        private void ParseConditions()
        {
            var filters = JArray.Parse(this.filtersStr);           
           
            this.conditions = new FilterConditionCollection();
            
            foreach (JObject jObject in filters)
            {                
                FilterCondition condition = new FilterCondition();
                condition.Field = jObject.Value<string>("field");

                string value = jObject.Value<string>("type");
                if (value.IsNotEmpty())
                {
                    condition.Type = (FilterType)Enum.Parse(typeof(FilterType), value, true);
                }

                value = jObject.Value<string>("comparison");
                if (value.IsNotEmpty())
                {
                    condition.Comparison = (Comparison)Enum.Parse(typeof(Comparison), value, true);
                }
                
                condition.Property = jObject.Property("value");

                this.conditions.Add(condition);
            }
        }

        private FilterConditionCollection conditions;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ReadOnlyCollection<FilterCondition> Conditions
        {
            get
            {
                if (conditions == null)
                {
                    conditions = new FilterConditionCollection();
                }

                return conditions.AsReadOnly();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FilterConditionCollection : List<FilterCondition> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FilterCondition
    {
        private Comparison comparison = Comparison.Eq;
        private JProperty property;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public JProperty Property
        {
            get
            {
                return this.property;
            }
            internal set
            {
                this.property = value;
                this.ValueType = this.property.Value.Type;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Field
        {
            get;
            internal set;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FilterType Type
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        public JTokenType ValueType
        {
            get;
            private set;
        }

		/// <summary>
		/// 
		/// </summary>
        public Comparison Comparison
        {
            get 
            { 
                return this.comparison; 
            }
            internal set 
            { 
                this.comparison = value; 
            }
        }

        public T Value<T>()
        {
            return this.Property.Value.Value<T>();
        }

		public List<string> List
        {
            get
            {
                if (this.Type != FilterType.List)
                {
                    throw new Exception("Filter condition value is not a list");
                }

                return new List<string>(((JArray)this.Property.Value).Values<string>());
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum Comparison
    {
        /// <summary>
        /// 
        /// </summary>
        Eq,

        /// <summary>
        /// 
        /// </summary>
        Gt,

        /// <summary>
        /// 
        /// </summary>
        Lt
    }
    
}
