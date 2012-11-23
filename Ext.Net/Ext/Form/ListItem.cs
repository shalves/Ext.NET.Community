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

using System.ComponentModel;
using System.Linq;
using System.Text;
using Ext.Net.Utilities;
using System;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class ListItem : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public ListItem() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public ListItem(string text)
        {
            this.Text = text;
            this.Value = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public ListItem(string text, string value)
        {
            this.Value = value;
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public ListItem(string text, object value)
        {
            this.Value = JSON.Serialize(value);
            this.Mode = ParameterMode.Raw;
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public ListItem(string text, string value, int index)
        {
            this.Value = value;
            this.Text = text;
            this.Index = index;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Text
        {
            get
            {
                return this.State.Get<string>("Text", null);
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Value
        {
            get
            {
                return this.State.Get<string>("Value", null);
            }
            set
            {
                this.State.Set("Value", value);                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue(null)]
        protected virtual string ValueProxy
        {
            get
            {
                if (this.Value == null)
                {
                    return null;
                }

                return this.Mode == ParameterMode.Value ? JSON.Serialize(this.Value) : this.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("")]
        public int Index
        {
            get
            {
                return this.State.Get<int>("Index", -1);
            }
            set
            {
                this.State.Set("Index", value);
            }
        }

        /// <summary>
        /// Wrap in quotes or not
        /// </summary>
        [Meta]
        [DefaultValue(ParameterMode.Value)]
        [Description("Wrap in quotes or not")]
        public virtual ParameterMode Mode
        {
            get
            {
                return this.State.Get<ParameterMode>("Mode", ParameterMode.Value);
            }
            set
            {
                this.State.Set("Mode", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsDefault
        {
            get
            {
                return this.Text == null && this.Value == null && this.Index < 0;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>    
    public partial class ListItemCollection : BaseItemCollection<ListItem>
    {
        public static ListItemCollection FromEnum(Type enumType)
        {
            ListItemCollection items = new ListItemCollection();
            foreach (var item in Enum.GetValues(enumType))
            {
                var fi = enumType.GetField(item.ToString());
                var attribute = fi.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault();
                var title = attribute == null ? item.ToString() : ((DescriptionAttribute)attribute).Description;
                var value = Convert.ChangeType(item, ((Enum)item).GetTypeCode());
                var listItem = new ListItem
                {
                    Value = value.ToString(),
                    Text = title
                };
                items.Add(listItem);
            }

            return items;
        }
        
        public virtual void Add(object items)
        {
            if (items == null)
            {
                return;
            }

            if (items is ListItem.Builder)
            {
                base.Add(((ListItem.Builder)items).ToComponent());
                return;
            }

            if (items is ListItem)
            {
                base.Add((ListItem)items);
                return;
            }

            var props = items.GetType().GetProperties().Select(x => new ListItem(x.Name.ToLowerCamelCase(), JSON.Serialize(x.GetValue(items, null), new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver())) { Mode = ParameterMode.Raw });
            this.AddRange(props);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string Serialize()
        {
            var comma = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in this)
            {
                if (comma)
                {
                    sb.Append(",");
                }

                var json =  new ClientConfig().Serialize(item);

                if (!ClientConfig.IsEmptyObject(json))
                {
                    comma = true;
                    sb.Append(json);
                }
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
