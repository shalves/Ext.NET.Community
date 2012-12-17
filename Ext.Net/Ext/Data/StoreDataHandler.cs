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
using System.IO;
using System.Web;
using System.Xml;
using System.Linq;
using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class StoreDataHandler
    {
        private string jsonData;
        private StoreAction? action;
        private XmlDocument xmlData;
        private readonly HttpContext context;
        private bool? isBatch;
        private StoreRequestParameters prms;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StoreDataHandler(HttpContext context)
        {
            this.context = context ?? HttpContext.Current;
        }

        public StoreDataHandler()
        {
            this.context = HttpContext.Current;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StoreDataHandler(string jsonData) : this()
        {
            if (jsonData == null)
            {
                throw new ArgumentNullException("jsonData");
            }
            this.jsonData = jsonData;            
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string JsonData
        {
            get
            {
                if (this.jsonData == null)
                {
                    if (this.context.Request["data"] != null)
                    {
                        this.jsonData = this.context.Request["data"];
                    }
                    else
                    {
                        if (this.IsJsonRequest)
                        {
                            using (StreamReader sr = new StreamReader(context.Request.InputStream))
                            {
                                this.jsonData = sr.ReadToEnd();
                            }
                        }
                    }
                }

                return this.jsonData;
            }
        }

        private bool IsJsonRequest
        {
            get
            {
                return context.Request.ContentType.Split(';').Any(t => t.Equals("application/json", StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public StoreAction Action
        {
            get
            {
                if (this.action == null)
                {
                    string _action = this.context.Request["action"];
                    this.action = _action.IsNotEmpty() ? Store.Action(_action) : StoreAction.Read;
                }

                return this.action.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public StoreRequestParameters Parameters
        {
            get
            {
                if (this.prms == null)
                {
                    this.prms = new StoreRequestParameters(this.context);
                }

                return this.prms;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsBatch
        {
            get
            {
                if (!this.isBatch.HasValue)
                {
                    string data = this.JsonData;

                    this.isBatch = data.IsNotEmpty() && data[0] == '{' && data[data.Length - 1] == '}';
                }

                return this.isBatch.Value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public XmlDocument XmlData
        {
            get
            {
                if (xmlData == null)
                {
                    if (this.IsBatch)
                    {
                        RecordsToXmlConverter converter = new RecordsToXmlConverter();
                        xmlData = (XmlDocument)JsonConvert.DeserializeObject(JsonData, typeof(XmlDocument), converter);
                    }
                    else
                    {
                        xmlData = JsonConvert.DeserializeXmlNode("{records:{record:" + JsonData + "}}");
                    }
                }

                return xmlData;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ChangeRecords<T> BatchObjectData<T>()
        {
            if (!this.IsBatch)
            {
                throw new Exception("The data is not batch");
            }
            JsonSerializer serializer = new JsonSerializer();
            serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            StringReader sr = new StringReader(JsonData);
            ChangeRecords<T> data = (ChangeRecords<T>)serializer.Deserialize(sr, typeof(ChangeRecords<T>));

            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public List<T> ObjectData<T>()
        {
            if (this.IsBatch)
            {
                throw new Exception("The data is batch");
            }
            JsonSerializer serializer = new JsonSerializer();
            serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            StringReader sr = new StringReader(JsonData);
            List<T> data = (List<T>)serializer.Deserialize(sr, typeof(List<T>));

            return data;
        }
    }
}
