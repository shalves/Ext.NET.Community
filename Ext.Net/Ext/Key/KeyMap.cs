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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Handles mapping key events to handling functions for an element or a Component. One KeyMap can be used for multiple actions.
    /// 
    /// A KeyMap must be configured with a target as an event source which may be an Element or a Component.
    /// 
    /// If the target is an element, then the keydown event will trigger the invocation of bindings.
    /// 
    /// It is possible to configure the KeyMap with a custom eventName to listen for. This may be useful when the target is a Component.
    /// 
    /// The KeyMap's event handling requires that the first parameter passed is a key event. So if the Component's event signature is different, specify a processEvent configuration which accepts the event's parameters and returns a key event.
    /// 
    /// Functions specified in bindings are called with this signature : (String key, Ext.EventObject e) (if the match is a multi-key combination the callback will still be called only once). A KeyMap can also handle a string representation of keys. By default KeyMap starts enabled.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:KeyMap runat=\"server\"></{0}:KeyMap>")]
    [ToolboxBitmap(typeof(KeyMap), "Build.ToolboxIcons.KeyMap.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Handles mapping keys to actions for an element.")]
    public partial class KeyMap : LazyObservable, ICustomConfigSerialization
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public KeyMap() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.util.KeyMap";
            }
        }

        protected internal bool BelongsToCmp
        {
            get;
            set;
        }

        private KeyBindingCollection binding;

        /// <summary>
        /// Either a single object describing a handling function for s specified key (or set of keys), or an array of such objects.
        /// </summary>
        [Meta]        
        [Category("3. KeyMap")]
        [NotifyParentProperty(true)]        
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Either a single object describing a handling function for s specified key (or set of keys), or an array of such objects.")]
        public virtual KeyBindingCollection Binding
        {
            get
            {
                if (this.binding == null)
                {
                    this.binding = new KeyBindingCollection { Owner = this };
                }

                return this.binding;
            }
        }

        [ConfigOption("binding", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string BindingProxy
        {
            get
            {
                if (this.Binding.Count == 0)
                {
                    return "";
                }

                if (this.Binding.Count == 1)
                {
                    return new ClientConfig().SerializeInternal(this.Binding[0], this);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    bool comma = false;
                    sb.Append("[");

                    foreach (KeyBinding keyBinding in this.Binding)
                    {
                        if (comma)
                        {
                            sb.Append(",");
                        }

                        sb.Append(new ClientConfig().SerializeInternal(keyBinding, this));

                        comma = true;
                    }
                    sb.Append("]");

                    return sb.ToString();
                }
            }
        }

        /// <summary>
        /// The event to listen for to pick up key events. Defaults to: "keydown"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyMap")]
        [DefaultValue("")]
        [Description("The event to listen for to pick up key events. Defaults to: \"keydown\"")]
        public virtual string EventName
        {
            get
            {
                return this.State.Get<string>("EventName", "");
            }
            set
            {
                this.State.Set("EventName", value);
            }
        }

        /// <summary>
        /// True to listen component event instead underlying element
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyMap")]
        [DefaultValue(false)]
        [Description("True to listen component event instead underlying element")]
        public virtual bool ComponentEvent
        {
            get
            {
                return this.State.Get<bool>("ComponentEvent", false);
            }
            set
            {
                this.State.Set("ComponentEvent", value);
            }
        }

        /// <summary>
        /// Element name of target component (can be used if KeyMap belongs to a component)
        /// </summary>
        [Meta]
        [ConfigOption("cmpEl")]
        [Category("3. KeyMap")]
        [DefaultValue("")]
        [Description("Element name of target component (can be used if KeyMap belongs to a component)")]
        public virtual string ComponentElement
        {
            get
            {
                return this.State.Get<string>("ComponentElement", "");
            }
            set
            {
                this.State.Set("ComponentElement", value);
            }
        }

        /// <summary>
        /// Configure this as true if there are any input fields within the target, and this KeyNav should not process events from input fields, (&lt;input>, &lt;textarea> and elements withcontentEditable="true"`). Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyMap")]
        [DefaultValue(false)]
        [Description("Configure this as true if there are any input fields within the target, and this KeyNav should not process events from input fields, (&lt;input>, &lt;textarea> and elements withcontentEditable=\"true\"). Defaults to: false")]
        public virtual bool IgnoreInputFields
        {
            get
            {
                return this.State.Get<bool>("IgnoreInputFields", false);
            }
            set
            {
                this.State.Set("IgnoreInputFields", value);
            }
        }

        private JFunction processEvent;

        /// <summary>
        /// An optional event processor function which accepts the argument list provided by the configured event of the target, and returns a keyEvent for processing by the KeyMap.
        ///
        /// This may be useful when the target is a Component with s complex event signature, where the event is not the first parameter. Extra information from the event arguments may be injected into the event for use by the handler functions before returning it.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]        
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction ProcessEvent
        {
            get
            {
                if (this.processEvent == null)
                {
                    this.processEvent = new JFunction();
                }

                return this.processEvent;
            }
        }

        /// <summary>
        /// The scope (this context) in which the processEvent method is executed.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope (this context) in which the processEvent method is executed.")]
        public virtual string ProcessEventScope
        {
            get
            {
                return this.State.Get<string>("ProcessEventScope", "");
            }
            set
            {
                this.State.Set("ProcessEventScope", value);
            }
        }        

        /// <summary>
        /// The object on which to listen for the event specified by the eventName config option.
        /// </summary>
        [Meta]
        [Category("3. KeyMap")]
        [DefaultValue("")]
        [Description("The object on which to listen for the event specified by the eventName config option.")]
        public virtual string Target
        {
            get
            {
                return this.State.Get<string>("Target", "");
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string TargetProxy
        {
            get
            {
                if(this.Target.IsEmpty())
                {
                    return "";
                }

                string parsedTarget = TokenUtils.ParseTokens(this.Target, this);

                if (TokenUtils.IsRawToken(parsedTarget))
                {
                    return TokenUtils.ReplaceRawToken(parsedTarget);
                }

                return "\"".ConcatWith(parsedTarget, "\"");
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Enables this KeyMap
        /// </summary>
        public virtual void Enable()
        {
            this.Call("enable");
        }

        /// <summary>
        /// Disable this KeyMap
        /// </summary>
        public virtual void Disable()
        {
            this.Call("disable");
        }

        /// <summary>
        /// Convenience function for setting disabled/enabled by boolean.
        /// </summary>
        /// <param name="disabled"></param>
        public virtual void SetDisabled(bool disabled)
        {
            this.Call("setDisabled", disabled);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyBinding"></param>
        public virtual void AddKeyBinding(KeyBinding keyBinding)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addBinding", JRawValue.From(new ClientConfig().Serialize(keyBinding, true)));
        }

        /// <summary>
        /// Destroys the KeyMap instance and removes all handlers.
        /// </summary>
        /// <param name="removeTarget">True to also remove the target</param>
        public virtual void Destroy(bool removeTarget)
        {
            this.Call("destroy", removeTarget);
        }

        /// <summary>
        /// Destroys the KeyMap instance and removes all handlers.
        /// </summary>
        public override void Destroy()
        {
            this.Call("destroy");
        }

        public string ToScript(Control owner)
        {
            
            string config = new ClientConfig().Serialize(this, true);

            if(this.BelongsToCmp)
            {
                return config;
            }

            string script;
            if (this.IsIdRequired)
            {
                script = string.Format("window.{0}=Ext.create(\"{1}\",{2})", this.ClientID, this.InstanceOf, config);
            }
            else
            {
                script = string.Format("Ext.create(\"{0}\",{1})", this.InstanceOf, config);
            }

            return this.IsLazy ? script : (script + ";");
        }
    }
}