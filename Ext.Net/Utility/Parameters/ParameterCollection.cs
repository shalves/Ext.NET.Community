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

using System.ComponentModel;
using System.Linq;
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ParameterCollection : BaseItemCollection<Parameter>
    {
        private readonly bool camelNames;

	    /// <summary>
	    /// 
	    /// </summary>
        protected virtual bool CamelNames
	    {
	        get
	        {
	            return this.camelNames;
	        }
	    }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ParameterCollection() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ParameterCollection(bool camelNames)
        {
            this.camelNames = camelNames;
        }

        public virtual void Add(object parameters)
        {
            if (parameters == null)
            {
                return;
            }

            if (parameters is Parameter.Builder)
            {
                base.Add(((Parameter.Builder)parameters).ToComponent());
                return;
            }

            if (parameters is Parameter)
            {
                base.Add((Parameter)parameters);
                return;
            }

            var props = parameters.GetType().GetProperties().Select(x => new Parameter(x.Name.ToLowerCamelCase(), JSON.Serialize(x.GetValue(parameters, null), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()), ParameterMode.Raw));
            this.AddRange(props);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Parameter GetParameter(string name)
        {
            foreach (Parameter parameter in this)
            {
                if (parameter.Name == name)
                {
                    return parameter;
                }
            }

            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string this[string name]
        {
            get
            {
                foreach (Parameter parameter in this)
                {
                    if (parameter.Name == name)
                    {
                        return parameter.Value;
                    }
                }

                return null;
            }
            set
            {
                foreach (Parameter parameter in this)
                {
                    if (parameter.Name == name)
                    {
                        parameter.Value = value;
                        return;
                    }
                }

                base.Add(new Parameter(name, value));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string ToJson()
        {
            if (this.Count == 0)
            {
                return "{}";
            }

            StringBuilder sb = new StringBuilder(256);
            sb.Append("{");
            bool removeComma = false;

            foreach (Parameter parameter in this)
            {
                sb.AppendFormat("{0},", TokenUtils.ParseTokens(parameter.ToString(camelNames), parameter.Owner));
                removeComma = true;
            }
            
            if (removeComma)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            
            sb.Append("}");

            return sb.ToString();
        }
    }
}