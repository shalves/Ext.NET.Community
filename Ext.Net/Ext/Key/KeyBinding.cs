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
using System.Text;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// The object describing a handling function for a specified key
    /// </summary>
    [Meta]
    [Description("")]
    public partial class KeyBinding : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public KeyBinding() { }

        /// <summary>
        /// True to handle key only when shift is pressed, False to handle the key only when shift is not pressed (defaults to undefined)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to handle key only when shift is pressed, False to handle the key only when shift is not pressed (defaults to undefined)")]
        public virtual bool? Shift
        {
            get
            {
                return this.State.Get<bool?>("Shift", null);
            }
            set
            {
                this.State.Set("Shift", value);
            }
        }

        /// <summary>
        /// True to handle key only when ctrl is pressed, False to handle the key only when ctrl is not pressed (defaults to undefined)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to handle key only when ctrl is pressed, False to handle the key only when ctrl is not pressed (defaults to undefined)")]
        public virtual bool? Ctrl
        {
            get
            {
                return this.State.Get<bool?>("Ctrl", null);
            }
            set
            {
                this.State.Set("Ctrl", value);
            }
        }

        /// <summary>
        /// True to handle key only when alt is pressed, False to handle the key only when alt is not pressed (defaults to undefined)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("True to handle key only when alt is pressed, False to handle the key only when alt is not pressed (defaults to undefined)")]
        public virtual bool? Alt
        {
            get
            {
                return this.State.Get<bool?>("Alt", null);
            }
            set
            {
                this.State.Set("Alt", value);
            }
        }

        /// <summary>
        /// The function to call when KeyMap finds the expected key combination
        /// </summary>
        [Meta]
        [ConfigOption(typeof(FunctionJsonConverter))]        
        [DefaultValue("")]
        [Description("The function to call when KeyMap finds the expected key combination")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// The scope of the callback function
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope of the callback function")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// A default action to apply to the event. Possible values are: stopEvent, stopPropagation, preventDefault. If no value is set no action is performed.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToCamelLower)]
        [Category("Config Options")]
        [DefaultValue(EventAction.None)]
        [NotifyParentProperty(true)]
        [Description("A default action to apply to the event. Possible values are: stopEvent, stopPropagation, preventDefault. If no value is set no action is performed.")]
        public virtual EventAction DefaultEventAction
        {
            get
            {
                return this.State.Get<EventAction>("DefaultEventAction", EventAction.None);
            }
            set
            {
                this.State.Set("DefaultEventAction", value);
            }
        }

        /// <summary>
        /// A single keycode or an array of keycodes to handle
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A single keycode or an array of keycodes to handle")]
        public virtual string KeysString
        {
            get
            {
                return this.State.Get<string>("KeysString", "");
            }
            set
            {
                this.State.Set("KeysString", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("key", JsonMode.Raw)]
        [DefaultValue("")]
        protected string KeysStringProxy
        {
            get
            {
                if (this.KeysString.IsNotEmpty())
                {
                    int intTest;
                    if (int.TryParse(this.KeysString, out intTest) || (this.KeysString.StartsWith("[") && this.KeysString.EndsWith("]")))
                    {
                        return this.KeysString;
                    }

                    return JSON.Serialize(this.KeysString);
                }

                return "";
            }
        }

        private KeyCollection keys;

        /// <summary>
        /// A single keycode or an array of keycodes to handle
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public KeyCollection Keys
        {
            get
            {
                if (this.keys == null)
                {
                    this.keys = new KeyCollection();
                }

                return this.keys;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("key", JsonMode.Raw)]
        [DefaultValue("")]
        protected string KeysProxy
        {
            get
            {
                if (this.Keys.Count > 0 && this.KeysString.IsEmpty())
                {
                    StringBuilder sb = new StringBuilder();
                    bool needComma = false;
                    sb.Append("[");

                    foreach (Key key in this.Keys)
                    {
                        string k = "";
                        if (key.Code == KeyCode.None)
                        {
                            if (key.KeyName.IsNotEmpty())
                            {
                                k = key.KeyName;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else{
                            k = ((int)key.Code).ToString();
                        }

                        if (needComma)
                        {
                            sb.Append(",");
                        }

                        needComma = true;
                        sb.Append(k);
                    }
                    sb.Append("]");

                    return sb.ToString();
                }

                return "";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class KeyBindingCollection : BaseItemCollection<KeyBinding> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class Key : BaseItem
    {
        /// <summary>
        /// Key code
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(KeyCode.None)]
        [NotifyParentProperty(true)]
        [Description("Key code")]
        public virtual KeyCode Code
        {
            get
            {
                return this.State.Get<KeyCode>("Code", KeyCode.None);
            }
            set
            {
                this.State.Set("Code", value);
            }
        }

        /// <summary>
        /// Key name
        /// </summary>
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Key name")]
        public virtual string KeyName
        {
            get
            {
                return this.State.Get<string>("KeyName", "");
            }
            set
            {
                this.State.Set("KeyName", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class KeyCollection : BaseItemCollection<Key> { }
    
}