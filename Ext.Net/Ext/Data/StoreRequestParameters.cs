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
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ext.Net.Utilities;
using System.Web;

namespace Ext.Net
{
    public partial class StoreRequestParameters
    {
        Dictionary<string, object> extraParams;

        public StoreRequestParameters() : this(HttpContext.Current)
        {
        }

        public StoreRequestParameters(Dictionary<string, object> extraParams)
        {
            this.extraParams = extraParams;
        }

        public StoreRequestParameters(string extraParams)
        {
            this.extraParams = JSON.Deserialize<Dictionary<string, object>>(extraParams);
        }

        public StoreRequestParameters(HttpContext context)
        {            
            this.extraParams = new Dictionary<string,object>();
            this.extraParams["page"] = context.Request["page"];
            this.extraParams["start"] = context.Request["start"];
            this.extraParams["limit"] = context.Request["limit"];
            this.extraParams["sort"] = context.Request["sort"];
            this.extraParams["filter"] = context.Request["filter"];
        }

        /// <summary>
        /// 
        /// </summary>
        public int Page
        {
            get
            {                
                if (this.ContainsKeyAndNotNull("page"))
                {
                    return Convert.ToInt32(this.extraParams["page"]);
                }

                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Start
        {
            get
            {
                if (this.ContainsKeyAndNotNull("start"))
                {
                    return Convert.ToInt32(this.extraParams["start"]);
                }

                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Limit
        {
            get
            {
                if (this.ContainsKeyAndNotNull("limit"))
                {
                    return Convert.ToInt32(this.extraParams["limit"]);
                }

                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter[] Sort
        {
            get
            {
                string sort = this.ContainsKeyAndNotNull("sort") ? this.extraParams["sort"].ToString() : "";
                if (sort.IsNotEmpty() &&  sort.StartsWith("[") && sort.EndsWith("]"))
                {
                    return JSON.Deserialize<DataSorter[]>(this.extraParams["sort"].ToString(), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
                }

                return new DataSorter[0];
            }
        }

        public string SimpleSort
        {
            get
            {
                var sort = this.Sort;
                if (sort.Length > 0)
                {
                    return sort[0].Property;
                }

                return this.ContainsKeyAndNotNull("sort") ? this.extraParams["sort"].ToString() : null;
            }
        }

        public SortDirection SimpleSortDirection
        {
            get
            {
                var sort = this.Sort;
                if (sort.Length > 0)
                {
                    return sort[0].Direction;
                }

                string dir = this.ContainsKeyAndNotNull("dir") ? this.extraParams["dir"].ToString() : null;
                return dir.IsNotEmpty() ? (SortDirection)Enum.Parse(typeof(SortDirection), dir, true) : SortDirection.Default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataFilter[] Filter
        {
            get
            {
                if (this.ContainsKeyAndNotNull("filter"))
                {
                    return JSON.Deserialize<DataFilter[]>(this.extraParams["filter"].ToString(), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
                }

                return new DataFilter[0];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FilterConditions GridFilters
        {
            get
            {
                if (this.ContainsKeyAndNotNull("filter"))
                {
                    return new FilterConditions(this.extraParams["filter"].ToString());
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSorter[] Group
        {
            get
            {
                string group = this.ContainsKeyAndNotNull("group") ? this.extraParams["group"].ToString() : "";
                if (group.IsNotEmpty() && group.StartsWith("[") && group.EndsWith("]"))
                {
                    return JSON.Deserialize<DataSorter[]>(this.extraParams["group"].ToString(), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
                }

                return new DataSorter[0];
            }
        }

        public string SimpleGroup
        {
            get
            {
                var group = this.Group;
                if (group.Length > 0)
                {
                    return group[0].Property;
                }

                return this.ContainsKeyAndNotNull("group") ? this.extraParams["group"].ToString() : null;
            }
        }

        public SortDirection SimpleGroupDirection
        {
            get
            {
                var group = this.Group;
                if (group.Length > 0)
                {
                    return group[0].Direction;
                }

                string dir = this.ContainsKeyAndNotNull("groupDir") ? this.extraParams["groupDir"].ToString() : null;
                return dir.IsNotEmpty() ? (SortDirection)Enum.Parse(typeof(SortDirection), dir, true) : SortDirection.Default;
            }
        }

        private bool ContainsKeyAndNotNull(string key)
        {
            return this.extraParams.ContainsKey(key) && this.extraParams[key] != null;
        }
    }
}