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
                if (this.extraParams.ContainsKey("page") && this.extraParams["page"] != null)
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
                if (this.extraParams.ContainsKey("start") && this.extraParams["start"] != null)
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
                if (this.extraParams.ContainsKey("limit") && this.extraParams["limit"] != null)
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
                if (this.extraParams.ContainsKey("sort") && this.extraParams["sort"] != null)
                {
                    return JSON.Deserialize<DataSorter[]>(this.extraParams["sort"].ToString(), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
                }

                return new DataSorter[0];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataFilter[] Filter
        {
            get
            {
                if (this.extraParams.ContainsKey("filter") && this.extraParams["filter"] != null)
                {
                    return JSON.Deserialize<DataFilter[]>(this.extraParams["filter"].ToString(), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
                }

                return new DataFilter[0];
            }
        }
    }
}