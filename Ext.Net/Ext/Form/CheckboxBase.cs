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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    [Meta]
    public abstract partial class CheckboxBase : Field
    {
        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        private XTemplate afterBoxLabelTextTpl;

        /// <summary>
        /// An optional string or XTemplate configuration to insert in the field markup after the box label text. If an XTemplate is used, the component's subTpl data serves as the context.       
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Category("6. Checkbox")]
        [ConfigOption("afterBoxLabelTextTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional string or XTemplate configuration to insert in the field markup after the box label text. If an XTemplate is used, the component's subTpl data serves as the context.")]
        public virtual XTemplate AfterBoxLabelTextTpl
        {
            get
            {
                return this.afterBoxLabelTextTpl;
            }
            set
            {
                if (this.afterBoxLabelTextTpl != null)
                {
                    this.Controls.Remove(this.afterBoxLabelTextTpl);
                    this.LazyItems.Remove(this.afterBoxLabelTextTpl);
                }

                this.afterBoxLabelTextTpl = value;

                if (this.afterBoxLabelTextTpl != null)
                {
                    this.afterBoxLabelTextTpl.EnableViewState = false;
                    this.Controls.Add(this.afterBoxLabelTextTpl);
                    this.LazyItems.Add(this.afterBoxLabelTextTpl);
                }
            }
        }

        private XTemplate afterBoxLabelTpl;

        /// <summary>
        /// An optional string or XTemplate configuration to insert in the field markup after the box label element. If an XTemplate is used, the component's subTpl data serves as the context.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Category("6. Checkbox")]
        [ConfigOption("afterBoxLabelTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional string or XTemplate configuration to insert in the field markup after the box label element. If an XTemplate is used, the component's subTpl data serves as the context.")]
        public virtual XTemplate AfterBoxLabelTpl
        {
            get
            {
                return this.afterBoxLabelTpl;
            }
            set
            {
                if (this.afterBoxLabelTpl != null)
                {
                    this.Controls.Remove(this.afterBoxLabelTpl);
                    this.LazyItems.Remove(this.afterBoxLabelTpl);
                }

                this.afterBoxLabelTpl = value;

                if (this.afterBoxLabelTpl != null)
                {
                    this.afterBoxLabelTpl.EnableViewState = false;
                    this.Controls.Add(this.afterBoxLabelTpl);
                    this.LazyItems.Add(this.afterBoxLabelTpl);
                }
            }
        }

        private XTemplate beforeBoxLabelTextTpl;

        /// <summary>
        /// An optional string or XTemplate configuration to insert in the field markup before the box label text. If an XTemplate is used, the component's subTpl data serves as the context.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Category("6. Checkbox")]
        [ConfigOption("beforeBoxLabelTextTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional string or XTemplate configuration to insert in the field markup before the box label text. If an XTemplate is used, the component's subTpl data serves as the context.")]
        public virtual XTemplate BeforeBoxLabelTextTpl
        {
            get
            {
                return this.beforeBoxLabelTextTpl;
            }
            set
            {
                if (this.beforeBoxLabelTextTpl != null)
                {
                    this.Controls.Remove(this.beforeBoxLabelTextTpl);
                    this.LazyItems.Remove(this.beforeBoxLabelTextTpl);
                }

                this.beforeBoxLabelTextTpl = value;

                if (this.beforeBoxLabelTextTpl != null)
                {
                    this.beforeBoxLabelTextTpl.EnableViewState = false;
                    this.Controls.Add(this.beforeBoxLabelTextTpl);
                    this.LazyItems.Add(this.beforeBoxLabelTextTpl);
                }
            }
        }

        private XTemplate beforeBoxLabelTpl;

        /// <summary>
        /// An optional string or XTemplate configuration to insert in the field markup before the box label element. If an XTemplate is used, the component's subTpl data serves as the context.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Category("6. Checkbox")]
        [ConfigOption("beforeBoxLabelTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional string or XTemplate configuration to insert in the field markup before the box label text. If an XTemplate is used, the component's subTpl data serves as the context.")]
        public virtual XTemplate BeforeBoxLabelTpl
        {
            get
            {
                return this.beforeBoxLabelTpl;
            }
            set
            {
                if (this.beforeBoxLabelTpl != null)
                {
                    this.Controls.Remove(this.beforeBoxLabelTpl);
                    this.LazyItems.Remove(this.beforeBoxLabelTpl);
                }

                this.beforeBoxLabelTpl = value;

                if (this.beforeBoxLabelTpl != null)
                {
                    this.beforeBoxLabelTpl.EnableViewState = false;
                    this.Controls.Add(this.beforeBoxLabelTpl);
                    this.LazyItems.Add(this.beforeBoxLabelTpl);
                }
            }
        }

        /// <summary>
        /// An optional text label that will appear next to the checkbox. Whether it appears before or after the checkbox is determined by the boxLabelAlign config (defaults to after).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetBoxLabel")]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("An optional text label that will appear next to the checkbox. Whether it appears before or after the checkbox is determined by the boxLabelAlign config (defaults to after).")]
        public virtual string BoxLabel
        {
            get
            {
                return this.State.Get<string>("BoxLabel", "");
            }
            set
            {
                this.State.Set("BoxLabel", value);
            }
        }

        /// <summary>
        /// The position relative to the checkbox where the boxLabel should appear. Recognized values are 'before' and 'after'. Defaults to 'after'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue(BoxLabelAlign.After)]
        [Description("The position relative to the checkbox where the boxLabel should appear. Recognized values are 'before' and 'after'. Defaults to 'after'.")]
        public virtual BoxLabelAlign BoxLabelAlign
        {
            get
            {
                return this.State.Get<BoxLabelAlign>("BoxLabelAlign", BoxLabelAlign.After);
            }
            set
            {
                this.State.Set("BoxLabelAlign", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetBoxLabelStyle")]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("")]
        public virtual string BoxLabelStyle
        {
            get
            {
                return this.State.Get<string>("BoxLabelStyle", "");
            }
            set
            {
                this.State.Set("BoxLabelStyle", value);
            }
        }

        private XTemplate boxLabelAttrTpl;

        /// <summary>
        /// An optional string or XTemplate configuration to insert in the field markup inside the box label element (as attributes). If an XTemplate is used, the component's subTpl data serves as the context.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Category("6. Checkbox")]
        [ConfigOption("boxLabelAttrTpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An optional string or XTemplate configuration to insert in the field markup inside the box label element (as attributes). If an XTemplate is used, the component's subTpl data serves as the context.")]
        public virtual XTemplate BoxLabelAttrTpl
        {
            get
            {
                return this.boxLabelAttrTpl;
            }
            set
            {
                if (this.boxLabelAttrTpl != null)
                {
                    this.Controls.Remove(this.boxLabelAttrTpl);
                    this.LazyItems.Remove(this.boxLabelAttrTpl);
                }

                this.boxLabelAttrTpl = value;

                if (this.boxLabelAttrTpl != null)
                {
                    this.boxLabelAttrTpl.EnableViewState = false;
                    this.Controls.Add(this.boxLabelAttrTpl);
                    this.LazyItems.Add(this.boxLabelAttrTpl);
                }
            }
        }

        /// <summary>
        /// The CSS class to be applied to the boxLabel element
        /// </summary>
        [Meta]
        [ConfigOption("boxLabelClsExtra")]
        [DirectEventUpdate(MethodName = "SetBoxLabelCls")]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("")]
        public virtual string BoxLabelCls
        {
            get
            {
                return this.State.Get<string>("BoxLabelCls", "");
            }
            set
            {
                this.State.Set("BoxLabelCls", value);
            }
        }

        /// <summary>
        /// True if the the checkbox should render already checked (defaults to false).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetValue")]
        [DefaultValue(false)]
        [Category("6. Checkbox")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("True if the the checkbox should render already checked (defaults to false).")]
        public virtual bool Checked
        {
            get
            {
                object obj = this.Value;
                return obj == null ? false : (bool)obj;
            }
            set
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// The CSS class added to the component's main element when it is in the checked state.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("The CSS class added to the component's main element when it is in the checked state.")]
        public virtual string CheckedCls
        {
            get
            {
                return this.State.Get<string>("CheckedCls", "");
            }
            set
            {
                this.State.Set("CheckedCls", value);
            }
        }

        /// <summary>
        /// A function called when the checked value changes (can be used instead of handling the change event).
        /// Parameters
        /// checkbox : Ext.form.field.Checkbox
        ///     The Checkbox being toggled.
        /// checked : Boolean
        ///     The new checked state of the checkbox.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("A function called when the checked value changes (can be used instead of handling the change event).")]
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
        /// The value that should go into the generated input element's value attribute and should be used as the parameter value when submitting as part of a form. Defaults to "on".
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("The value that should go into the generated input element's value attribute and should be used as the parameter value when submitting as part of a form. Defaults to \"on\".")]
        public virtual string InputValue
        {
            get
            {
                if (this.DesignMode && this.State["InputValue"] == null)
                {
                    return "";
                }

                return this.State.Get<string>("InputValue", this.ClientID);
            }
            set
            {
                this.State.Set("InputValue", value);
            }
        }

        /// <summary>
        /// An object to use as the scope ('this' reference) of the handler function. Defaults to this Checkbox.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. Checkbox")]
        [DefaultValue(null)]
        [Description("An object to use as the scope ('this' reference) of the handler function. Defaults to this Checkbox.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", null);
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// If configured, this will be submitted as the checkbox's value during form submit if the checkbox is unchecked. By default this is undefined, which results in nothing being submitted for the checkbox field when the form is submitted (the default behavior of HTML checkboxes).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue(null)]
        [Description("If configured, this will be submitted as the checkbox's value during form submit if the checkbox is unchecked. By default this is undefined, which results in nothing being submitted for the checkbox field when the form is submitted (the default behavior of HTML checkboxes).")]
        public virtual string UncheckedValue
        {
            get
            {
                return this.State.Get<string>("UncheckedValue", null);
            }
            set
            {
                this.State.Set("UncheckedValue", value);
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DefaultValue("")]
        protected virtual void SetBoxLabel(string value)
        {
            this.Call("setBoxLabel", value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DefaultValue("")]
        protected virtual void SetBoxLabelStyle(string value)
        {
            this.Call("setBoxLabelStyle", value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DefaultValue("")]
        protected virtual void SetBoxLabelCls(string value)
        {
            this.Call("setBoxLabelCls", value);
        }
    }
}