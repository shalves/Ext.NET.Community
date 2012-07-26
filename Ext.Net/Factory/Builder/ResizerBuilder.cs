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
 * @version   : 2.0.0 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class Resizer
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Observable.Builder<Resizer, Resizer.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Resizer()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Resizer component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Resizer.Config config) : base(new Resizer(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Resizer component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An element, or a Region into which the resize operation must be constrained.
			/// </summary>
            public virtual Resizer.Builder ConstrainToElement(string constrainToElement)
            {
                this.ToComponent().ConstrainToElement = constrainToElement;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// An element, or a Region into which the resize operation must be constrained.
			/// </summary>
            public virtual Resizer.Builder ConstrainToRegion(System.Drawing.Rectangle? constrainToRegion)
            {
                this.ToComponent().ConstrainToRegion = constrainToRegion;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// Specify as true to update the target (Element or Component) dynamically during dragging. This is true by default, but the Component class passes false when it is configured as Ext.Component.resizable.
			/// </summary>
            public virtual Resizer.Builder Dynamic(bool? dynamic)
            {
                this.ToComponent().Dynamic = dynamic;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// String consisting of the resize handles to display. Defaults to 's e se' for Elements and fixed position Components. Defaults to 8 point resizing for floating Components (such as Windows). Specify either 'all' or any of 'n s e w ne nw se sw'. Defaults to: \"s e se\"
			/// </summary>
            public virtual Resizer.Builder Handles(ResizeHandle handles)
            {
                this.ToComponent().Handles = handles;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// String consisting of the resize handles to display (defaults to 's e se'). Specify either 'all' or any of 'n s e w ne nw se sw'.
			/// </summary>
            public virtual Resizer.Builder HandlesSummary(string handlesSummary)
            {
                this.ToComponent().HandlesSummary = handlesSummary;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// Optional. The height to set target to in pixels. Defaults to: null
			/// </summary>
            public virtual Resizer.Builder Height(Unit height)
            {
                this.ToComponent().Height = height;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// The increment to snap the height resize in pixels. Defaults to: 0
			/// </summary>
            public virtual Resizer.Builder HeightIncrement(int heightIncrement)
            {
                this.ToComponent().HeightIncrement = heightIncrement;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// The maximum height for the element (defaults to 10000)
			/// </summary>
            public virtual Resizer.Builder MaxHeight(int maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// The maximum width for the element (defaults to 10000)
			/// </summary>
            public virtual Resizer.Builder MaxWidth(int maxWidth)
            {
                this.ToComponent().MaxWidth = maxWidth;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// The minimum height for the element (defaults to 20)
			/// </summary>
            public virtual Resizer.Builder MinHeight(int minHeight)
            {
                this.ToComponent().MinHeight = minHeight;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// The minimum width for the element (defaults to 20)
			/// </summary>
            public virtual Resizer.Builder MinWidth(int minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// True to ensure that the resize handles are always visible, false indicates resizing by cursor changes only. Defaults to: false
			/// </summary>
            public virtual Resizer.Builder Pinned(bool pinned)
            {
                this.ToComponent().Pinned = pinned;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// True to preserve the original ratio between height and width during resize (defaults to false)
			/// </summary>
            public virtual Resizer.Builder PreserveRatio(bool preserveRatio)
            {
                this.ToComponent().PreserveRatio = preserveRatio;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// The Element or Component to resize.
			/// </summary>
            public virtual Resizer.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// True for transparent handles. This is only applied at config time. (defaults to false)
			/// </summary>
            public virtual Resizer.Builder Transparent(bool transparent)
            {
                this.ToComponent().Transparent = transparent;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// Optional. The width to set the target to in pixels. Defaults to: null
			/// </summary>
            public virtual Resizer.Builder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// The increment to snap the width resize in pixels (defaults to 0)
			/// </summary>
            public virtual Resizer.Builder WidthIncrement(int widthIncrement)
            {
                this.ToComponent().WidthIncrement = widthIncrement;
                return this as Resizer.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Resizer.Builder</returns>
            public virtual Resizer.Builder Listeners(Action<ResizableListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as Resizer.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Resizer.Builder</returns>
            public virtual Resizer.Builder DirectEvents(Action<ResizableDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as Resizer.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Resizer.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Resizer(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Resizer.Builder Resizer()
        {
            return this.Resizer(new Resizer());
        }

        /// <summary>
        /// 
        /// </summary>
        public Resizer.Builder Resizer(Resizer component)
        {
            return new Resizer.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Resizer.Builder Resizer(Resizer.Config config)
        {
            return new Resizer.Builder(new Resizer(config));
        }
    }
}