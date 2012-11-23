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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DropTarget
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDropTarget, TBuilder> : DDTarget.Builder<TDropTarget, TBuilder>
            where TDropTarget : DropTarget
            where TBuilder : Builder<TDropTarget, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDropTarget component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).
			/// </summary>
            public virtual TBuilder Group(string group)
            {
                this.ToComponent().Group = group;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class returned to the drag source when drop is allowed (defaults to \"x-dd-drop-ok\").
			/// </summary>
            public virtual TBuilder DropAllowed(string dropAllowed)
            {
                this.ToComponent().DropAllowed = dropAllowed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class returned to the drag source when drop is not allowed (defaults to \"x-dd-drop-nodrop\").
			/// </summary>
            public virtual TBuilder DropNotAllowed(string dropNotAllowed)
            {
                this.ToComponent().DropNotAllowed = dropNotAllowed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class applied to the drop target element while the drag source is over it (defaults to \"\").
			/// </summary>
            public virtual TBuilder OverClass(string overClass)
            {
                this.ToComponent().OverClass = overClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to register this container with the Scrollmanager for auto scrolling during drag operations.
			/// </summary>
            public virtual TBuilder ContainerScroll(bool containerScroll)
            {
                this.ToComponent().ContainerScroll = containerScroll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the dragged item has been dropped on it. This method has no default implementation and returns false, so you must provide an implementation that does something to process the drop event and returns true so that the drag source's repair action does not run.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder NotifyDrop(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyDrop);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the source is now over the target. This default implementation adds the CSS class specified by overClass (if any) to the drop element and returns the dropAllowed config value. This method should be overridden if drop validation is required.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder NotifyEnter(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyEnter);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the source has been dragged out of the target without dropping. This default implementation simply removes the CSS class specified by overClass (if any) from the drop element.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder NotifyOut(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyOut);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The function a Ext.dd.DragSource calls continuously while it is being dragged over the target. This method will be called on every mouse movement while the drag source is over the drop target. This default implementation simply returns the dropAllowed config value.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder NotifyOver(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyOver);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DropTarget.Builder<DropTarget, DropTarget.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DropTarget()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DropTarget component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DropTarget.Config config) : base(new DropTarget(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DropTarget component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DropTarget(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder DropTarget()
        {
#if MVC
			return this.DropTarget(new DropTarget { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DropTarget(new DropTarget());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder DropTarget(DropTarget component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DropTarget.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder DropTarget(DropTarget.Config config)
        {
#if MVC
			return new DropTarget.Builder(new DropTarget(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DropTarget.Builder(new DropTarget(config));
#endif			
        }
    }
}