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
using System.Web.UI;
using System;
using System.Web.UI.WebControls;
using System.Drawing;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary> 
    /// Base class for all Ext components. All subclasses of Component may participate in the automated Ext component lifecycle of creation, rendering and destruction which is provided by the Container class. Components may be added to a Container through the items config option at the time the Container is created, or they may be added dynamically via the add method.
    /// 
    /// The Component base class has built-in support for basic hide/show and enable/disable and size control behavior.
    /// 
    /// All Components are registered with the Ext.ComponentManager on construction so that they can be referenced at any time via Ext.getCmp, passing the id.
    /// 
    /// All user-developed visual widgets that are required to participate in automated lifecycle and size management should subclass Component.
    /// 
    /// See the Creating new UI controls chapter in [Component Guide][1] for details on how and to either extend or augment Ext JS base classes to create custom Components.
    /// 
    /// Every component has a specific xtype, which is its Ext-specific type name, along with methods for checking the xtype like getXType and isXType. See the [Component Guide][1] for more information on xtypes and the Component hierarchy.
    /// </summary>
    [Meta]
    public abstract partial class ComponentBase : AbstractComponent
    {
        #region Config Options

        /// <summary>
        /// true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetAutoScroll")]
        [Category("3. Component")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).")]
        public virtual bool AutoScroll
        {
            get
            {
                return this.State.Get<bool>("AutoScroll", false);
            }
            set
            {
                this.State.Set("AutoScroll", value);
            }
        }



        /// <summary>
        /// Allows the component to be dragged via the touch event.
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(false)]
        [Description("Allows the component to be dragged via the touch event.")]
        public virtual bool Draggable
        {
            get
            {
                return this.State.Get<bool>("Draggable", false);
            }
            set
            {
                this.State.Set("Draggable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption("draggable")]
        protected virtual bool DraggableProxy
        {
            get
            {
                if (this.DraggableConfig == null)
                {
                    return this.Draggable;
                }
                
                return this.Draggable && this.DraggableConfig == null;
            }
        }

        private ComponentDragger draggableCfg;

        /// <summary>
        /// Specify as true to make a floating AbstractComponent draggable using the AbstractComponent's encapsulating element as the drag handle.
        /// This may also be specified as a config object for the ComponentDragger which is instantiated to perform dragging.
        /// For example to create a AbstractComponent which may only be dragged around using a certain internal element as the drag handle, use the delegate option
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(null)]
        [Description("Specify as true to make a floating AbstractComponent draggable using the AbstractComponent's encapsulating element as the drag handle.")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ComponentDragger DraggableConfig
        {
            get
            {
                return this.draggableCfg;
            }
            set
            {
                if (value != null)
                {
                    value.EnableViewState = this.DesignMode;
                }
                this.draggableCfg = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("draggable", JsonMode.Raw)]
        protected virtual string DraggableConfigProxy
        {
            get
            {
                if (this.DraggableConfig == null)
                {
                    return "";
                }
                string cfg = new ClientConfig().Serialize(this.DraggableConfig, true);
                return cfg != Const.EmptyObject ? cfg : "";
            }
        }
        
        /// <summary>
        /// Only valid when a sibling element of a Splitter within a VBox or HBox layout.
        /// Specifies that if an immediate sibling Splitter is moved, the AbstractComponent on the other side is resized, and this AbstractComponent maintains its configured flex value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Specifies that if an immediate sibling Splitter is moved, the AbstractComponent on the other side is resized, and this AbstractComponent maintains its configured flex value.")]
        public virtual bool MaintainFlex
        {
            get
            {
                return this.State.Get<bool>("MaintainFlex", false);
            }
            set
            {
                this.State.Set("MaintainFlex", value);
            }
        }

        /// <summary>
        /// Possible values are: * 'auto' to enable automatic horizontal scrollbar (overflow-x: 'auto'). * 'scroll' to always enable horizontal scrollbar (overflow-x: 'scroll'). The default is overflow-x: 'hidden'. This should not be combined with autoScroll.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. Component")]
        [DefaultValue(Overflow.Hidden)]
        [Description("Possible values are: * 'auto' to enable automatic horizontal scrollbar (overflow-x: 'auto'). * 'scroll' to always enable horizontal scrollbar (overflow-x: 'scroll'). The default is overflow-x: 'hidden'. This should not be combined with autoScroll.")]
        public virtual Overflow OverflowX
        {
            get
            {
                return this.State.Get<Overflow>("OverflowX", Overflow.Hidden);
            }
            set
            {
                this.State.Set("OverflowX", value);
            }
        }

        /// <summary>
        /// Possible values are: * 'auto' to enable automatic vertical scrollbar (overflow-y: 'auto'). * 'scroll' to always enable vertical scrollbar (overflow-y: 'scroll'). The default is overflow-y: 'hidden'. This should not be combined with autoScroll.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. Component")]
        [DefaultValue(Overflow.Hidden)]
        [Description("Possible values are: * 'auto' to enable automatic vertical scrollbar (overflow-y: 'auto'). * 'scroll' to always enable vertical scrollbar (overflow-y: 'scroll'). The default is overflow-y: 'hidden'. This should not be combined with autoScroll.")]
        public virtual Overflow OverflowY
        {
            get
            {
                return this.State.Get<Overflow>("OverflowY", Overflow.Hidden);
            }
            set
            {
                this.State.Set("OverflowY", value);
            }
        }

        /// <summary>
        /// Specify as true to apply a Resizer to this AbstractComponent after rendering.
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(false)]
        [Description("Specify as true to apply a Resizer to this AbstractComponent after rendering.")]
        public virtual bool Resizable
        {
            get
            {
                return this.State.Get<bool>("Resizable", false);
            }
            set
            {
                this.State.Set("Resizable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption("resizable")]
        protected virtual bool ResizableProxy
        {
            get
            {                
                return this.Resizable && this.ResizableConfig == null ? true : false;
            }
        }

        private Resizer resizableCfg;

        /// <summary>
        /// Specify as a config object to apply a Resizer to this AbstractComponent after rendering.
        /// May also be specified as a config object to be passed to the constructor of Resizer to override any defaults. By default the AbstractComponent passes its minimum and maximum size, and uses Ext.resizer.Resizer-dynamic: false
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(null)]
        [Description("Specify as a config object to apply a Resizer to this AbstractComponent after rendering.")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual Resizer ResizableConfig
        {
            get
            {
                return this.resizableCfg;
            }
            set
            {
                if (value != null)
                {
                    value.EnableViewState = this.DesignMode;
                }
                this.resizableCfg = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("resizable", JsonMode.Raw)]
        protected virtual string ResizableConfigProxy
        {
            get
            {
                if (this.ResizableConfig == null)
                {
                    return "";
                }

                string cfg = new ClientConfig().Serialize(this.ResizableConfig, true);
                return cfg != Const.EmptyObject ? cfg : "";
            }
        }

        /// <summary>
        /// A valid Ext.resizer.Resizer handles config string (defaults to 'all'). Only applies when resizable = true.
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(ResizeHandle.All)]
        [Description("A valid Ext.resizer.Resizer handles config string (defaults to 'all'). Only applies when resizable = true.")]
        public virtual ResizeHandle ResizeHandles
        {
            get
            {
                return this.State.Get<ResizeHandle>("ResizeHandles", ResizeHandle.All);
            }
            set
            {
                this.State.Set("ResizeHandles", value);
            }
        }

        /// <summary>
        /// True to automatically call toFront when the show method is called on an already visible, floating component (default is true).
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(true)]
        [Description("True to automatically call toFront when the show method is called on an already visible, floating component (default is true).")]
        public virtual bool ToFrontOnShow
        {
            get
            {
                return this.State.Get<bool>("ToFrontOnShow", true);
            }
            set
            {
                this.State.Set("ToFrontOnShow", value);
            }
        }

        #endregion Config Options

        #region Client Methods

        /// <summary>
        /// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        /// <param name="function">The function to call</param>
        [Meta]
        public virtual void Bubble(string function)
        {
            this.Call("bubble", new JRawValue(function));
        }

        /// <summary>
        /// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        /// <param name="function">The function to call</param>
        /// <param name="scope">The scope of the function (defaults to current element)</param>
        [Meta]
        public virtual void Bubble(string function, string scope)
        {
            this.Call("bubble", new JRawValue(function), new JRawValue(scope));
        }

        /// <summary>
        /// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        /// <param name="function">The function to call</param>
        /// <param name="scope">The scope of the function (defaults to current element)</param>
        /// <param name="args">The args to call the function with (default to passing the current component)</param>
        [Meta]
        [Description("Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.")]
        public virtual void Bubble(string function, string scope, object[] args)
        {
            this.Call("bubble", new JRawValue(function), new JRawValue(scope), JSON.Serialize(args));
        }

        /// <summary>
        /// Try to focus this component.
        /// </summary>
        [Meta]
        new public virtual void Focus()
        {
            this.Call("focus");
        }

        /// <summary>
        /// Try to focus this component.
        /// </summary>
        /// <param name="selectText">If applicable, true to also select the text in this component</param>
        [Meta]
        public virtual void Focus(bool selectText)
        {
            this.Call("focus", selectText);
        }

        /// <summary>
        /// Try to focus this component.
        /// </summary>
        /// <param name="selectText">If applicable, true to also select the text in this component</param>
        /// <param name="delay">Delay the focus this number of milliseconds.</param>
        [Meta]
        public virtual void Focus(bool selectText, int delay)
        {
            this.Call("focus", selectText, delay);
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        [Meta]
        public virtual void Hide()
        {
            this.Call("hide");
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        [Meta]
        public virtual void Hide(string animateTarget)
        {
            this.Call("hide", animateTarget);
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        [Meta]
        public virtual void Hide(ComponentBase animateTarget)
        {
            this.Call("hide", new JRawValue(animateTarget.ClientID));
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        [Meta]
        public virtual void Hide(ComponentBase animateTarget, string callback)
        {
            this.Call("hide", new JRawValue(animateTarget.ClientID), new JRawValue(callback));
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        [Meta]
        public virtual void Hide(ComponentBase animateTarget, JFunction callback)
        {
            this.Call("hide", new JRawValue(animateTarget.ClientID), callback);
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        public virtual void Hide(string animateTarget, string callback)
        {
            this.Call("hide", animateTarget, new JRawValue(callback));
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        public virtual void Hide(string animateTarget, JFunction callback)
        {
            this.Call("hide", animateTarget, callback);
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        /// <param name="scope">The scope (this reference) in which the callback is executed. Defaults to this Component.</param>
        public virtual void Hide(ComponentBase animateTarget, string callback, string scope)
        {
            this.Call("hide", new JRawValue(animateTarget.ClientID), new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        /// <param name="scope">The scope (this reference) in which the callback is executed. Defaults to this Component.</param>
        public virtual void Hide(ComponentBase animateTarget, JFunction callback, string scope)
        {
            this.Call("hide", new JRawValue(animateTarget.ClientID), callback, new JRawValue(scope));
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        /// <param name="scope">The scope (this reference) in which the callback is executed. Defaults to this Component.</param>
        public virtual void Hide(string animateTarget, string callback, string scope)
        {
            this.Call("hide", animateTarget, new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Hides this Component, setting it to invisible using the configured hideMode.
        /// </summary>
        /// <param name="animateTarget">only valid for floating Components such as Windows or ToolTips, or regular Components which have been configured with floating: true.. The target to which the Component should animate while hiding (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the Component is hidden.</param>
        /// <param name="scope">The scope (this reference) in which the callback is executed. Defaults to this Component.</param>
        public virtual void Hide(string animateTarget, JFunction callback, string scope)
        {
            this.Call("hide", animateTarget, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Sets the overflow on the content element of the component.
        /// </summary>
        protected virtual void SetAutoScroll()
        {
            this.Call("setAutoScroll");
        }

        /// <summary>
        /// Sets the overflow on the content element of the component.
        /// </summary>
        /// <param name="scroll">True to allow the AbstractComponent to auto scroll.</param>
        [Meta]
        public virtual void SetAutoScroll(bool scroll)
        {
            this.Call("setAutoScroll", scroll);
        }

        /// <summary>
        /// Sets the page XY position of the component. To set the left and top instead, use setPosition. This method fires the move event.
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        [Meta]
        public virtual void SetPagePosition(int x, int y)
        {
            this.Call("setPagePosition", x, y);
        }

        /// <summary>
        /// Sets the page XY position of the component. To set the left and top instead, use setPosition. This method fires the move event.
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        /// <param name="animate">If passed, the AbstractComponent is animated into its new position.</param>
        [Meta]
        public virtual void SetPagePosition(int x, int y, AnimConfig animate)
        {
            this.Call("setPagePosition", x, y, new JRawValue(new ClientConfig().Serialize(animate)));
        }

        /// <summary>
        /// Sets the page XY position of the component. To set the left and top instead, use setPosition. This method fires the move event.
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        /// <param name="animate">If passed, the AbstractComponent is animated into its new position (animation duration in milliseconds).</param>
        [Meta]
        public virtual void SetPagePosition(int x, int y, int animate)
        {
            this.Call("setPagePosition", x, y, animate);
        }

        /// <summary>
        /// Sets the left and top of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.
        /// </summary>
        /// <param name="x">The new left</param>
        /// <param name="y">The new top</param>
        [Meta]
        public virtual void SetPosition(int x, int y)
        {
            this.Call("setPosition", x, y);
        }

        /// <summary>
        /// Sets the left and top of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.
        /// </summary>
        /// <param name="x">The new left</param>
        /// <param name="y">The new top</param>
        /// <param name="animate">An animation configuration.</param>
        [Meta]
        public virtual void SetPosition(int x, int y, AnimConfig animate)
        {
            this.Call("setPosition", x, y, new JRawValue(new ClientConfig().Serialize(animate)));
        }

        /// <summary>
        /// Sets the left and top of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.
        /// </summary>
        /// <param name="x">The new left</param>
        /// <param name="y">The new top</param>
        /// <param name="animate">If true, the AbstractComponent is animated into its new position.</param>
        [Meta]
        public virtual void SetPosition(int x, int y, bool animate)
        {
            this.Call("setPosition", x, y, animate);
        }

        /// <summary>
        /// Shows this AbstractComponent, rendering it first if Ext.AbstractComponent-autoRender is true.
        /// For a Window, it activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        public virtual void Show()
        {
            this.Call("show");
        }

        /// <summary>
        /// Shows this AbstractComponent, rendering it first if Ext.AbstractComponent-autoRender is true.
        /// For a Window, it activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="animTarget"> The target element or id from which the AbstractComponent should animate while opening (defaults to null with no animation)</param>
        [Meta]
        public virtual void Show(string animTarget)
        {
            this.Call("show", animTarget);
        }

        /// <summary>
        /// Shows this AbstractComponent, rendering it first if Ext.AbstractComponent-autoRender is true.
        /// For a Window, it activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="animTarget"> The target element or id from which the AbstractComponent should animate while opening (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the window is displayed. Only necessary if animation was specified.</param>
        [Meta]
        public virtual void Show(string animTarget, string callback)
        {
            this.Call("show", animTarget, new JRawValue(callback));
        }

        /// <summary>
        /// Shows this AbstractComponent, rendering it first if Ext.AbstractComponent-autoRender is true.
        /// For a Window, it activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="animTarget"> The target element or id from which the AbstractComponent should animate while opening (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the window is displayed. Only necessary if animation was specified.</param>
        [Meta]
        public virtual void Show(string animTarget, JFunction callback)
        {
            this.Call("show", animTarget, callback);
        }

        /// <summary>
        /// Shows this AbstractComponent, rendering it first if Ext.AbstractComponent-autoRender is true.
        /// For a Window, it activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="animTarget"> The target element or id from which the AbstractComponent should animate while opening (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the window is displayed. Only necessary if animation was specified.</param>
        /// <param name="scope">The scope (this reference) in which the callback is executed. Defaults to this AbstractComponent.</param>
        [Meta]
        public virtual void Show(string animTarget, string callback, string scope)
        {
            this.Call("show", animTarget, new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Shows this AbstractComponent, rendering it first if Ext.AbstractComponent-autoRender is true.
        /// For a Window, it activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="animTarget"> The target element or id from which the AbstractComponent should animate while opening (defaults to null with no animation)</param>
        /// <param name="callback">A callback function to call after the window is displayed. Only necessary if animation was specified.</param>
        /// <param name="scope">The scope (this reference) in which the callback is executed. Defaults to this AbstractComponent.</param>
        public virtual void Show(string animTarget, JFunction callback, string scope)
        {
            this.Call("show", animTarget, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Sets the current box measurements of the component's underlying element.
        /// </summary>
        [Meta]
        public virtual void UpdateBox(Unit x, Unit y, Unit width, Unit height)
        {
            this.UpdateBox(Convert.ToInt32(x.Value), Convert.ToInt32(y.Value), Convert.ToInt32(width.Value), Convert.ToInt32(height.Value));
        }

        /// <summary>
        /// Sets the current box measurements of the component's underlying element.
        /// </summary>
        [Meta]
        public virtual void UpdateBox(int x, int y, int width, int height)
        {
            JsonObject config = new JsonObject
                             {
                                 {"x", x}, 
                                 {"y", y}, 
                                 {"width", width}, 
                                 {"height", height}
                             };

            this.Call("updateBox", config);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask or a config object that will be passed to the LoadMask constructor. False to hide the current LoadMask.</param>
        /// <param name="targetEl">True to mask the targetEl of this AbstractComponent instead of the this.el. For example, setting this to true on a Panel will cause only the body to be masked. (defaults to false)</param>
        [Meta]
        public virtual void SetLoading(LoadMask load, bool targetEl)
        {
            load.ShowMask = true;
            this.Call("setLoading", new JRawValue(new ClientConfig().Serialize(load)), targetEl);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask or a config object that will be passed to the LoadMask constructor. False to hide the current LoadMask.</param>
        [Meta]
        public virtual void SetLoading(LoadMask load)
        {
            load.ShowMask = true;
            this.Call("setLoading", new JRawValue(new ClientConfig().Serialize(load)));
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask. False to hide the current LoadMask.</param>
        public void SetLoading(bool load)
        {
            this.Call("setLoading", load);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="load">True to show the default LoadMask. False to hide the current LoadMask.</param>
        /// <param name="targetEl">True to mask the targetEl of this Component instead of the this.el. For example, setting this to true on a Panel will cause only the body to be masked.</param>
        public void SetLoading(bool load, bool targetEl)
        {
            this.Call("setLoading", load, targetEl);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="message">Message to show</param>
        public void SetLoading(string message)
        {
            this.Call("setLoading", message);
        }

        /// <summary>
        /// This method allows you to show or hide a LoadMask on top of this component.
        /// </summary>
        /// <param name="message">Message to show</param>
        /// <param name="targetEl">True to mask the targetEl of this Component instead of the this.el. For example, setting this to true on a Panel will cause only the body to be masked.</param>
        public void SetLoading(string message, bool targetEl)
        {
            this.Call("setLoading", message, targetEl);
        }

        /// <summary>
        /// Sets the overflow x/y on the content element of the component. The x/y overflow values can be any valid CSS overflow (e.g., 'auto' or 'scroll'). By default, the value is 'hidden'. Passing null for one of the values will erase the inline style. Passing undefined will preserve the current value.
        /// </summary>
        /// <param name="overflowX">The overflow-x value.</param>
        /// <param name="overflowY">The overflow-y value.</param>
        public void SetOverflowXY(Overflow overflowX, Overflow overflowY)
        {
            this.Call("setOverflowXY", overflowX.ToString().ToLowerInvariant(), overflowY.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Displays component at specific xy position. A floating component (like a menu) is positioned relative to its ownerCt if any. Useful for popping up a context menu
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        public void ShowAt(int x, int y)
        {
            this.Call("showAt", x, y);
        }

        /// <summary>
        /// Displays component at specific xy position. A floating component (like a menu) is positioned relative to its ownerCt if any. Useful for popping up a context menu
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        /// <param name="animate">True to animate the Component into its new position</param>
        public void ShowAt(int x, int y, bool animate)
        {
            this.Call("showAt", x, y, animate);
        }

        /// <summary>
        /// Displays component at specific xy position. A floating component (like a menu) is positioned relative to its ownerCt if any. Useful for popping up a context menu
        /// </summary>
        /// <param name="x">The new x position</param>
        /// <param name="y">The new y position</param>
        /// <param name="animate">Animation configuration</param>
        public void ShowAt(int x, int y, AnimConfig animate)
        {
            this.Call("showAt", x, y, new JRawValue(new ClientConfig().Serialize(animate)));
        }

        #endregion Client Methods        
    }
}