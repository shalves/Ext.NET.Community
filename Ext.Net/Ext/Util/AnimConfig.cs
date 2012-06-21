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
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Perform custom animation on this object.
    /// 
    /// This method is applicable to both the Component class and the Element class. It performs animated transitions of certain properties of this object over a specified timeline.
    /// 
    /// The sole parameter is an object which specifies start property values, end property values, and properties which describe the timeline.
    /// 
    /// Animating an Element
    /// When animating an Element, the following properties may be specified in from, to, and keyframe objects:
    /// 
    /// x - The page X position in pixels.
    /// y - The page Y position in pixels
    /// left - The element's CSS left value. Units must be supplied.
    /// top - The element's CSS top value. Units must be supplied.
    /// width - The element's CSS width value. Units must be supplied.
    /// height - The element's CSS height value. Units must be supplied.
    /// scrollLeft - The element's scrollLeft value.
    /// scrollTop - The element's scrollLeft value.
    /// opacity - The element's opacity value. This must be a value between 0 and 1.
    /// Be aware than animating an Element which is being used by an Ext Component without in some way informing the Component about the changed element state will result in incorrect Component behaviour. This is because the Component will be using the old state of the element. To avoid this problem, it is now possible to directly animate certain properties of Components.
    /// 
    /// Animating a Component
    /// When animating a Component, the following properties may be specified in from, to, and keyframe objects:
    /// 
    /// x - The Component's page X position in pixels.
    /// y - The Component's page Y position in pixels
    /// left - The Component's left value in pixels.
    /// top - The Component's top value in pixels.
    /// width - The Component's width value in pixels.
    /// width - The Component's width value in pixels.
    /// dynamic - Specify as true to update the Component's layout (if it is a Container) at every frame of the animation. Use sparingly as laying out on every intermediate size change is an expensive operation.
    /// </summary>
    public partial class AnimConfig : BaseItem
    {
        /// <summary>
        /// Used in conjunction with iterations to reverse the animation each time an iteration completes.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. AnimConfig")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Used in conjunction with iterations to reverse the animation each time an iteration completes.")]
        public virtual bool Alternate
        {
            get
            {
                return this.State.Get<bool>("Alternate", false);
            }
            set
            {
                this.State.Set("Alternate", value);
            }
        }

        /// <summary>
        /// A function to be run after the animation has completed.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. AnimConfig")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A function to be run after the animation has completed.")]
        public virtual string Callback
        {
            get
            {
                return this.State.Get<string>("Callback", "");
            }
            set
            {
                this.State.Set("Callback", value);
            }
        }

        /// <summary>
        /// The scope that the callback function will be called with
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. AnimConfig")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope that the callback function will be called with")]
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
        /// Time to delay before starting the animation. Defaults to 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. AnimConfig")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Time to delay before starting the animation. Defaults to 0.")]
        public virtual int Delay
        {
            get
            {
                return this.State.Get<int>("Delay", 0);
            }
            set
            {
                this.State.Set("Delay", value);
            }
        }

        /// <summary>
        /// Time in milliseconds for the animation to last. Defaults to 250.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. AnimConfig")]
        [DefaultValue(250)]
        [NotifyParentProperty(true)]
        [Description("Time in milliseconds for the animation to last. Defaults to 250.")]
        public virtual int Duration
        {
            get
            {
                return this.State.Get<int>("Duration", 250);
            }
            set
            {
                this.State.Set("Duration", value);
            }
        }

        /// <summary>
        /// Currently only for AbstractComponent Animation: Only set a component's outer element size bypassing layouts. Set to true to do full layouts for every frame of the animation. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. AnimConfig")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Currently only for AbstractComponent Animation: Only set a component's outer element size bypassing layouts. Set to true to do full layouts for every frame of the animation. Defaults to false.")]
        public virtual bool Dynamic
        {
            get
            {
                return this.State.Get<bool>("Dynamic", false);
            }
            set
            {
                this.State.Set("Dynamic", value);
            }
        }

        /// <summary>
        /// This describes how the intermediate values used during a transition will be calculated. It allows for a transition to change speed over its duration.
        /// Note that cubic-bezier will create a custom easing curve following the CSS3 transition-timing-function specification http://www.w3.org/TR/css3-transitions/-transition-timing-function_tag. The four values specify points P1 and P2 of the curve as (x1, y1, x2, y2). All values must be in the range [0, 1] or the definition is invalid
        /// </summary>
        [Meta]
        [Category("2. AnimConfig")]
        [DefaultValue(Easing.Ease)]
        [NotifyParentProperty(true)]
        [Description("This describes how the intermediate values used during a transition will be calculated. It allows for a transition to change speed over its duration.")]
        public virtual Easing Easing
        {
            get
            {
                return this.State.Get<Easing>("Easing", Easing.Ease);
            }
            set
            {
                this.State.Set("Easing", value);
            }
        }

        ///<summary>
        /// Using with Bezier easing only
        /// Note that cubic-bezier will create a custom easing curve following the CSS3 transition-timing-function specification http://www.w3.org/TR/css3-transitions/-transition-timing-function_tag. The four values specify points P1 and P2 of the curve as (x1, y1, x2, y2). All values must be in the range [0, 1] or the definition is invalid
        ///</summary>
        [Meta]
        [Category("2. AnimConfig")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("This describes how the intermediate values used during a transition will be calculated. It allows for a transition to change speed over its duration.")]
        public virtual string EasingArgs
        {
            get
            {
                return this.State.Get<string>("EasingArgs", "");
            }
            set
            {
                this.State.Set("EasingArgs", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("easing")]
        [DefaultValue("")]
        protected virtual string EasingProxy
        {
            get
            {
                if (this.Easing == Easing.EaseNone || this.Easing == Easing.Ease)
                {
                    return "";
                }

                string fn = this.Easing.ToString().ToLowerCamelCase();

                if (this.EasingArgs.IsNotEmpty())
                {
                    if (this.EasingArgs.StartsWith("(") && this.EasingArgs.EndsWith(")"))
                    {
                        fn = fn + this.EasingArgs;
                    }
                    else
                    {
                        fn = fn.ConcatWith("(", this.EasingArgs, ")");
                    }
                }

                return fn;
            }
        }

        private ParameterCollection from;

        ///<summary>
        /// An object containing property/value pairs for the beginning of the animation. If not specified, the current state of the Ext.fx.target will be used.
        /// For example:
        /// 
        /// from : {
        ///     opacity: 0,       // Transparent
        ///     color: '#ffffff', // White
        ///     left: 0
        /// }
        ///</summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("2. AnimConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing property/value pairs for the beginning of the animation. If not specified, the current state of the Ext.fx.target will be used.")]
        public virtual ParameterCollection From
        {
            get
            {
                return this.from ?? (this.from = new ParameterCollection(false));
            }
        }

        ///<summary>
        /// Number of times to execute the animation. Defaults to 1.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("2. AnimConfig")]
        [DefaultValue(1)]
        [NotifyParentProperty(true)]
        [Description("Number of times to execute the animation. Defaults to 1.")]
        public virtual int Iterations
        {
            get
            {
                return this.State.Get<int>("Iterations", 1);
            }
            set
            {
                this.State.Set("Iterations", value);
            }
        }

        ///<summary>
        /// Animation keyframes follow the CSS3 Animation configuration pattern. 'from' is always considered '0%' and 'to' is considered '100%'.Every keyframe declaration must have a keyframe rule for 0% and 100%, possibly defined using "from" or "to". A keyframe declaration without these keyframe selectors is invalid and will not be available for animation. The keyframe declaration for a keyframe rule consists of properties and values. Properties that are unable to be animated are ignored in these rules, with the exception of 'easing' which can be changed at each keyframe.
        /// Example:
        /// keyframes : {
        ///    '0%': {
        ///        left: 100
        ///    },
        ///    '40%': {
        ///        left: 150
        ///    },
        ///    '60%': {
        ///        left: 75
        ///    },
        ///    '100%': {
        ///        left: 100
        ///    }
        /// }
        ///</summary>
        [Meta]
        [Category("2. AnimConfig")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Animation keyframes follow the CSS3 Animation configuration pattern.")]
        public virtual InsertOrderedDictionary<string,ParameterCollection> KeyFrames
        {
            get
            {
                return this.State.Get<InsertOrderedDictionary<string, ParameterCollection>>("KeyFrames", null);
            }
            set
            {
                this.State.Set("KeyFrames", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("keyframes", JsonMode.Raw)]
        [DefaultValue(null)]
        protected virtual string KeyFramesProxy
        {
            get
            {
                if (this.KeyFrames == null || this.KeyFrames.Count == 0)
                {
                    return null;
                }

                var sb = new StringBuilder();
                sb.Append("{");
                foreach (var keyFrame in this.KeyFrames)
                {
                    if (keyFrame.Value != null && keyFrame.Value.Count > 0)
                    {
                        sb.Append(JSON.Serialize(keyFrame.Key));
                        sb.Append(":");
                        sb.Append(keyFrame.Value.ToJson());
                        sb.Append(",");
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");
                
                return sb.Length > 2 ? sb.ToString() : null;
            }
        }

        ///<summary>
        /// Run the animation from the end to the beginning. Defaults to false.
        ///</summary>
        [Meta]
        [ConfigOption]
        [Category("2. AnimConfig")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Run the animation from the end to the beginning. Defaults to false.")]
        public virtual bool Reverse
        {
            get
            {
                return this.State.Get<bool>("Reverse", false);
            }
            set
            {
                this.State.Set("Reverse", value);
            }
        }

        private ParameterCollection to;

        ///<summary>
        /// An object containing property/value pairs for the end of the animation.
        /// For example:
        /// 
        ///  to : {
        ///      opacity: 1,       // Opaque
        ///      color: '#00ff00', // Green
        ///      left: 500
        ///  }
        ///</summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("2. AnimConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing property/value pairs for the end of the animation.")]
        public virtual ParameterCollection To
        {
            get
            {
                return this.to ?? (this.to = new ParameterCollection(false));
            }
        }

        private AnimConfigListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. AnimConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public AnimConfigListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new AnimConfigListeners();
                }

                return this.listeners;
            }
        }
    }
}
