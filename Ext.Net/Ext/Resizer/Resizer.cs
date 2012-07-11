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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Applies drag handles to an element or component to make it resizable. The drag handles are inserted into the element (or component's element) and positioned absolute.
    /// 
    /// Textarea and img elements will be wrapped with an additional div because these elements do not support child nodes. The original element can be accessed through the originalTarget property.
    /// 
    /// Here is the list of valid resize handles:
    /// 
    /// Value   Description
    /// ------  -------------------
    ///  'n'     north
    ///  's'     south
    ///  'e'     east
    ///  'w'     west
    ///  'nw'    northwest
    ///  'sw'    southwest
    ///  'se'    southeast
    ///  'ne'    northeast
    ///  'all'   all
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Resizer runat=\"server\" />")]
    [ToolboxBitmap(typeof(Resizer), "Build.ToolboxIcons.Resizable.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Applies drag handles to an element to make it resizable.")]
    public partial class Resizer : Observable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Resizer() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.resizer.Resizer";
            }
        }

        /// <summary>
        /// An element, or a Region into which the resize operation must be constrained.
        /// </summary>
        [Meta]
        [ConfigOption("constrainTo")]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [Description("An element, or a Region into which the resize operation must be constrained.")]
        public virtual string ConstrainToElement
        {
            get
            {
                return this.State.Get<string>("ConstrainToElement", "");
            }
            set
            {
                this.State.Set("ConstrainToElement", value);
            }
        }

        /// <summary>
        /// An element, or a Region into which the resize operation must be constrained.
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An element, or a Region into which the resize operation must be constrained.")]
        public virtual System.Drawing.Rectangle? ConstrainToRegion
        {
            get
            {
                return this.State.Get<System.Drawing.Rectangle?>("ConstrainToRegion", null);
            }
            set
            {
                this.State.Set("ConstrainToRegion", value);
            }
        }

        [ConfigOption("constrainTo", JsonMode.Raw)]
        [DefaultValue(null)]
        protected virtual string ConstrainToRegionProxy
        {
            get
            {
                if (this.ConstrainToRegion == null)
                {
                    return null;
                }

                return string.Format("Ext.util.Region.from({0})", JSON.Serialize(new { top = this.ConstrainToRegion.Value.Top, bottom = this.ConstrainToRegion.Value.Bottom, right = this.ConstrainToRegion.Value.Right, left = this.ConstrainToRegion.Value.Left }));
            }
        }

        /// <summary>
        /// Specify as true to update the target (Element or Component) dynamically during dragging. This is true by default, but the Component class passes false when it is configured as Ext.Component.resizable.
        /// If specified as false, a proxy element is displayed during the resize operation, and the target is updated on mouseup.
        /// Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Specify as true to update the target (Element or Component) dynamically during dragging. This is true by default, but the Component class passes false when it is configured as Ext.Component.resizable.")]
        public virtual bool? Dynamic
        {
            get
            {
                return this.State.Get<bool?>("Dynamic", null);
            }
            set
            {
                this.State.Set("Dynamic", value);
            }
        }

        /// <summary>
        /// String consisting of the resize handles to display. Defaults to 's e se' for Elements and fixed position Components. Defaults to 8 point resizing for floating Components (such as Windows). Specify either 'all' or any of 'n s e w ne nw se sw'. Defaults to: "s e se"
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue(ResizeHandle.Default)]
        [Description("String consisting of the resize handles to display. Defaults to 's e se' for Elements and fixed position Components. Defaults to 8 point resizing for floating Components (such as Windows). Specify either 'all' or any of 'n s e w ne nw se sw'. Defaults to: \"s e se\"")]
        public virtual ResizeHandle Handles
        {
            get
            {
                return this.State.Get<ResizeHandle>("Handles", ResizeHandle.Default);
            }
            set
            {
                this.State.Set("Handles", value);
            }
        }

        /// <summary>
        ///  String consisting of the resize handles to display (defaults to 's e se'). Specify either 'all' or any of 'n s e w ne nw se sw'.
        /// </summary>
        [Meta]
        [ConfigOption("handles")]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("String consisting of the resize handles to display (defaults to 's e se'). Specify either 'all' or any of 'n s e w ne nw se sw'.")]
        public virtual string HandlesSummary
        {
            get
            {
                return this.State.Get<string>("HandlesSummary", "");
            }
            set
            {
                this.State.Set("HandlesSummary", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("handles")]
        [DefaultValue("")]
        [Description("")]
        protected string HandlesProxy
        {
            get
            {
                switch(this.Handles)
                {
                    case ResizeHandle.Default:
                        return "";
                    case ResizeHandle.North:
                        return "n";
                    case ResizeHandle.South:
                        return "s";
                    case ResizeHandle.East:
                        return "e";
                    case ResizeHandle.West:
                        return "w";
                    case ResizeHandle.NorthWest:
                        return "nw";
                    case ResizeHandle.SouthWest:
                        return "sw";
                    case ResizeHandle.SouthEast:
                        return "se";
                    case ResizeHandle.NorthEast:
                        return "ne";
                    case ResizeHandle.All:
                        return "all";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Optional. The height to set target to in pixels. Defaults to: null
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("Optional. The height to set target to in pixels. Defaults to: null")]
        public override Unit Height
        {
            get
            {
                return this.UnitPixelTypeCheck(State["Height"], Unit.Empty, "Height");
            }
            set
            {
                this.State.Set("Height", value);
            }
        }

        /// <summary>
        /// The increment to snap the height resize in pixels. Defaults to: 0
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The increment to snap the height resize in pixels. Defaults to: 0")]
        public virtual int HeightIncrement
        {
            get
            {
                return this.State.Get<int>("HeightIncrement", 0);
            }
            set
            {
                this.State.Set("HeightIncrement", value);
            }
        }

        /// <summary>
        /// The maximum height for the element (defaults to 10000)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(10000)]
        [Description("The maximum height for the element (defaults to 10000)")]
        public virtual int MaxHeight
        {
            get
            {
                return this.State.Get<int>("MaxHeight", 10000);
            }
            set
            {
                this.State.Set("MaxHeight", value);
            }
        }

        /// <summary>
        /// The maximum width for the element (defaults to 10000)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(10000)]
        [Description("The maximum width for the element (defaults to 10000)")]
        public virtual int MaxWidth
        {
            get
            {
                return this.State.Get<int>("MaxWidth", 10000);
            }
            set
            {
                this.State.Set("MaxWidth", value);
            }
        }

        /// <summary>
        /// The minimum height for the element (defaults to 20)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(20)]
        [Description("The minimum height for the element (defaults to 20)")]
        public virtual int MinHeight
        {
            get
            {
                return this.State.Get<int>("MinHeight", 20);
            }
            set
            {
                this.State.Set("MinHeight", value);
            }
        }

        /// <summary>
        /// The minimum width for the element (defaults to 20)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(20)]
        [Description("The minimum width for the element (defaults to 20)")]
        public virtual int MinWidth
        {
            get
            {
                return this.State.Get<int>("MinWidth", 20);
            }
            set
            {
                this.State.Set("MinWidth", value);
            }
        }

        /// <summary>
        /// True to ensure that the resize handles are always visible, false indicates resizing by cursor changes only. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ensure that the resize handles are always visible, false indicates resizing by cursor changes only. Defaults to: false")]
        public virtual bool Pinned
        {
            get
            {
                return this.State.Get<bool>("Pinned", false);
            }
            set
            {
                this.State.Set("Pinned", value);
            }
        }

        /// <summary>
        /// True to preserve the original ratio between height and width during resize (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to preserve the original ratio between height and width during resize (defaults to false)")]
        public virtual bool PreserveRatio
        {
            get
            {
                return this.State.Get<bool>("PreserveRatio", false);
            }
            set
            {
                this.State.Set("PreserveRatio", value);
            }
        }

        /// <summary>
        /// The Element or Component to resize.
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [Description("The Element or Component to resize.")]
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
                if (!string.IsNullOrEmpty(this.Target))
                {
                    string parsedElement = TokenUtils.ParseTokens(this.Target, this);

                    if (TokenUtils.IsRawToken(parsedElement))
                    {
                        return TokenUtils.ReplaceRawToken(parsedElement);
                    }

                    return JSON.Serialize(parsedElement);
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// True for transparent handles. This is only applied at config time. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True for transparent handles. This is only applied at config time. (defaults to false)")]
        public virtual bool Transparent
        {
            get
            {
                return this.State.Get<bool>("Transparent", false);
            }
            set
            {
                this.State.Set("Transparent", value);
            }
        }

        /// <summary>
        /// Optional. The width to set the target to in pixels. Defaults to: null
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("Optional. The width to set the target to in pixels. Defaults to: null")]
        public override Unit Width
        {
            get
            {
                return this.UnitPixelTypeCheck(State["Width"], Unit.Empty, "Width");
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// The increment to snap the width resize in pixels (defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The increment to snap the width resize in pixels (defaults to 0)")]
        public virtual int WidthIncrement
        {
            get
            {
                return this.State.Get<int>("WidthIncrement", 0);
            }
            set
            {
                this.State.Set("WidthIncrement", value);
            }
        }

        private ResizableListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public ResizableListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ResizableListeners();
                }

                return this.listeners;
            }
        }

        private ResizableDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side DirectEventHandlers")]
        public ResizableDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ResizableDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Destroys this resizable
        /// </summary>
        public virtual void Destroy()
        {
            this.Call("destroy");
        }

        /// <summary>
        /// Perform a manual resize and fires the 'resize' event.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public virtual void ResizeTo(int width, int height)
        {
            this.Call("resizeTo", width, height);
        }
    }
}