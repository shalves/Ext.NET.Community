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
using System.Web.UI;
using System.Drawing;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Provides a convenient wrapper for normalized keyboard navigation. KeyNav allows you to bind navigation keys to function calls that will get called when the keys are pressed, providing an easy way to implement custom navigation schemes for any UI component.
    /// The following are all of the possible keys that can be implemented: enter, space, left, right, up, down, tab, esc, pageUp, pageDown, del, backspace, home, end.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:KeyNav runat=\"server\"></{0}:KeyNav>")]
    [ToolboxBitmap(typeof(KeyNav), "Build.ToolboxIcons.KeyMap.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Provides a convenient wrapper for normalized keyboard navigation. KeyNav allows you to bind navigation keys to function calls that will get called when the keys are pressed, providing an easy way to implement custom navigation schemes for any UI component.")]
    public partial class KeyNav : Observable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public KeyNav() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.util.KeyNav";
            }
        }

        protected internal bool BelongsToCmp
        {
            get;
            set;
        }

        /// <summary>
        /// True to listen component event instead underlying element
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyNav")]
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
        /// The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation.
        /// If a falsy value is specified, no method is called on the key event.
        /// Defaults to: "stopEvent"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyNav")]
        [DefaultValue(EventAction.StopEvent)]
        [NotifyParentProperty(true)]
        [Description("The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation.")]
        public virtual EventAction DefaultEventAction
        {
            get
            {
                return this.State.Get<EventAction>("DefaultEventAction", EventAction.StopEvent);
            }
            set
            {
                this.State.Set("DefaultEventAction", value);
            }
        }

        /// <summary>
        /// True to disable this KeyNav instance (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyNav")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetDisabled")]
        [Description("True to disable this KeyNav instance (defaults to false)")]
        public virtual bool Disabled
        {
            get
            {
                return this.State.Get<bool>("Disabled", false);
            }
            set
            {
                this.State.Set("Disabled", value);
            }
        }

        /// <summary>
        /// The event to listen for to pick up key events. Defaults to: "keypress"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyMap")]
        [DefaultValue("")]
        [Description("The event to listen for to pick up key events. Defaults to: \"keypress\"")]
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
        /// Handle the keydown event instead of keypress. KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyNav")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Handle the keydown event instead of keypress. KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress. Defaults to: false")]
        public virtual bool ForceKeyDown
        {
            get
            {
                return this.State.Get<bool>("ForceKeyDown", false);
            }
            set
            {
                this.State.Set("ForceKeyDown", value);
            }
        }

        /// <summary>
        /// Element name of target component (can be used if KeyNav belongs to a component)
        /// </summary>
        [Meta]
        [ConfigOption("cmpEl")]
        [Category("3. KeyMap")]
        [DefaultValue("")]
        [Description("Element name of target component (can be used if KeyNav belongs to a component)")]
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
                    this.processEvent = new JFunction { Owner = this };
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
        /// The element to bind to
        /// </summary>
        [Meta]
        [Category("3. KeyNav")]
        [DefaultValue("")]
        [Description("The element to bind to")]
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
                if (this.Target.IsEmpty())
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

        private JFunction space;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Space
        {
            get
            {
                if (this.space == null)
                {
                    this.space = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.space;
            }
        }

        private JFunction left;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Left
        {
            get
            {
                if (this.left == null)
                {
                    this.left = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.left;
            }
        }


        private JFunction right;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Right
        {
            get
            {
                if (this.right == null)
                {
                    this.right = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.right;
            }
        }


        private JFunction up;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Up
        {
            get
            {
                if (this.up == null)
                {
                    this.up = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.up;
            }
        }


        private JFunction down;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Down
        {
            get
            {
                if (this.down == null)
                {
                    this.down = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.down;
            }
        }


        private JFunction pageUp;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction PageUp
        {
            get
            {
                if (this.pageUp == null)
                {
                    this.pageUp = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.pageUp;
            }
        }


        private JFunction pageDown;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction PageDown
        {
            get
            {
                if (this.pageDown == null)
                {
                    this.pageDown = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.pageDown;
            }
        }


        private JFunction del;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Del
        {
            get
            {
                if (this.del == null)
                {
                    this.del = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.del;
            }
        }


        private JFunction home;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Home
        {
            get
            {
                if (this.home == null)
                {
                    this.home = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.home;
            }
        }


        private JFunction end;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction End
        {
            get
            {
                if (this.end == null)
                {
                    this.end = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.end;
            }
        }

        private JFunction enter;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Enter
        {
            get
            {
                if (this.enter == null)
                {
                    this.enter = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.enter;
            }
        }


        private JFunction esc;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Esc
        {
            get
            {
                if (this.esc == null)
                {
                    this.esc = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.esc;
            }
        }


        private JFunction tab;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Tab
        {
            get
            {
                if (this.tab == null)
                {
                    this.tab = new JFunction { Args = new string[] { "e" }, Owner = this };
                }

                return this.tab;
            }
        }

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
    }
}