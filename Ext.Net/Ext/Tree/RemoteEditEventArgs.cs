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

using System.ComponentModel;
using System.Web;

using Ext.Net.Utilities;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public class RemoteEditEventArgs : RemoteActionEventArgs
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RemoteEditEventArgs(string serviceParams, ParameterCollection extraParams)
            : base(serviceParams, extraParams)
        {
        }

        public bool IsRowEditing
        {
            get
            {
                return this.GetValue<bool>("isRow");
            }            
        }

        public string Field
        {
            get
            {
                return this.IsRowEditing ? this.Keys[0] : this.GetValue<string>("field");
            }
        }

        public T Value<T>()
        {
            return this.GetFieldValue<T>("newValue");
        }

        public T Value<T>(string field)
        {
            return this.GetFieldValue<T>(field, "newValues");
        }

        public T OldValue<T>()
        {
            return this.GetFieldValue<T>("oldValue");
        }

        public T OldValue<T>(string field)
        {
            return this.GetFieldValue<T>(field, "oldValues");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected T GetFieldValue<T>(string jName)
        {
            if (this.IsRowEditing)
            {
                throw new Exception("Row editing mode: field name is required to retrieve a value");
            }

            T value = this.GetValue<T>(jName);

            if (value is string && !object.Equals(value, default(T)))
            {
                var s = value.ToString();
                return (T)((object)HttpUtility.HtmlDecode(s));
            }

            return value;           
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected T GetFieldValue<T>(string field, string jName)
        {
            if (!this.IsRowEditing)
            {
                return this.GetFieldValue<T>(jName == "newValues" ? "newValue" : "oldValue");
            }

            if (this.ServiceParams == null)
            {
                return default(T);
            }

            JProperty p = this.ServiceParams.Property(jName);

            if (p == null || p.Value == null)
            {
                return default(T);
            }

            T value = ((JObject)p.Value).Value<T>(field);

            if (value is string && !object.Equals(value, default(T)))
            {
                var s = value.ToString();
                return (T)((object)HttpUtility.HtmlDecode(s));
            }

            return value;
        }

        public List<string> Keys
        {
            get
            {
                if (!this.IsRowEditing)
                {
                    return new List<string> { this.Field };
                }

                if (this.ServiceParams == null)
                {
                    return new List<string>(0);
                }

                JProperty p = this.ServiceParams.Property("newValues");

                if (p == null || p.Value == null)
                {
                    return new List<string>(0);
                }

                var list = new List<string>();
                ((JObject)p.Value).Properties().Each(prop => list.Add(prop.Name));
                return list;
            }
        }

        public string Json
        {
            get
            {
                if (!this.IsRowEditing)
                {
                    return this.Value<string>();
                }

                if (this.ServiceParams == null)
                {
                    return null;
                }

                JProperty p = this.ServiceParams.Property("newValues");

                if (p == null || p.Value == null)
                {
                    return null;
                }

                return p.Value.ToString(Newtonsoft.Json.Formatting.None);
            }
        }

        public List<RowChanges> Changes
        {
            get
            {
                var list = new List<RowChanges>();
                foreach (var key in this.Keys)
                {
                    list.Add(new RowChanges(key, this));
                }

                return list;
            }
        }

        public void SetValue(object value)
        {
            if (this.IsRowEditing)
            {
                throw new Exception("Row editing mode: field name is required to set a new value");
            }
            
            var p = ResourceManager.ExtraParamsResponse.GetParameter("ra_newValue");
            if (p == null)
            {
                p = new Parameter("ra_newValue", "", ParameterMode.Raw);
                ResourceManager.ExtraParamsResponse.Add(p);
            }
            
            ResourceManager.ExtraParamsResponse["ra_newValue"] = JSON.Serialize(value, JSON.ScriptConvertersInternal);            
        }

        private Dictionary<string, object> newValues;
        public void SetValue(string field, object value)
        {
            if (!this.IsRowEditing)
            {
                this.SetValue(value);
                return;
            }
            
            var p = ResourceManager.ExtraParamsResponse.GetParameter("ra_newValues");
            if (p == null)
            {
                p = new Parameter("ra_newValues", "", ParameterMode.Raw);
                ResourceManager.ExtraParamsResponse.Add(p);
                this.newValues = new Dictionary<string, object>();
            }

            this.newValues[field] = value;

            ResourceManager.ExtraParamsResponse["ra_newValues"] = JSON.Serialize(this.newValues, JSON.ScriptConvertersInternal);
        }
    }

    public class RowChanges
    {
        private RemoteEditEventArgs e;

        internal RowChanges(string field, RemoteEditEventArgs e)
        {
            this.Field = field;
            this.e = e;
        }
        
        public string Field
        {
            get;
            private set;
        }

        public T Value<T>()
        {
            return this.e.Value<T>(this.Field);
        }

        public T OldValue<T>()
        {
            return this.e.OldValue<T>(this.Field);
        }

        public void SetValue(object value)
        {
            this.e.SetValue(this.Field, value);
        }

        public bool IsDirty<T>()
        {
            return !Object.Equals(this.Value<T>(), this.OldValue<T>());
        }
    }
}