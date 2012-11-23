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
    public abstract partial class ToolTipBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TToolTipBase, TBuilder> : Tip.Builder<TToolTipBase, TBuilder>
            where TToolTipBase : ToolTipBase
            where TBuilder : Builder<TToolTipBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TToolTipBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ForceRendering(bool forceRendering)
            {
                this.ToComponent().ForceRendering = forceRendering;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If specified, indicates that the tip should be anchored to a particular side of the target element or mouse pointer (\"top\", \"right\", \"bottom\", or \"left\"), with an arrow pointing back at the target or mouse pointer. If constrainPosition is enabled, this will be used as a preferred value only and may be flipped as needed.
			/// </summary>
            public virtual TBuilder Anchor(string anchor)
            {
                this.ToComponent().Anchor = anchor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A numeric pixel value used to offset the default position of the anchor arrow. When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset. Defaults to: 0
			/// </summary>
            public virtual TBuilder AnchorOffset(int anchorOffset)
            {
                this.ToComponent().AnchorOffset = anchorOffset;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to anchor the tooltip to the target element, false to anchor it relative to the mouse coordinates. When anchorToTarget is true, use defaultAlign to control tooltip alignment to the target element. When anchorToTarget is false, use anchor instead to control alignment. Defaults to: true
			/// </summary>
            public virtual TBuilder AnchorToTarget(bool anchorToTarget)
            {
                this.ToComponent().AnchorToTarget = anchorToTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.
			/// </summary>
            public virtual TBuilder AutoHide(bool autoHide)
            {
                this.ToComponent().AutoHide = autoHide;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A DomQuery selector which allows selection of individual elements within the target element to trigger showing and hiding the ToolTip as the mouse moves within the target.
			/// </summary>
            public virtual TBuilder Delegate(string _delegate)
            {
                this.ToComponent().Delegate = _delegate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.
			/// </summary>
            public virtual TBuilder DismissDelay(int dismissDelay)
            {
                this.ToComponent().DismissDelay = dismissDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Delay in milliseconds after the mouse exits the target element but before the tooltip actually hides (defaults to 200). Set to 0 for the tooltip to hide immediately.
			/// </summary>
            public virtual TBuilder HideDelay(int hideDelay)
            {
                this.ToComponent().HideDelay = hideDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An XY offset from the mouse position where the tooltip should be shown (defaults to [15,18]).
			/// </summary>
            public virtual TBuilder MouseOffset(int[] mouseOffset)
            {
                this.ToComponent().MouseOffset = mouseOffset;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Delay in milliseconds before the tooltip displays after the mouse enters the target element (defaults to 500).
			/// </summary>
            public virtual TBuilder ShowDelay(int showDelay)
            {
                this.ToComponent().ShowDelay = showDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TargetControl(Action<Control> action)
            {
                action(this.ToComponent().TargetControl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to have the tooltip follow the mouse as it moves over the target element (defaults to false).
			/// </summary>
            public virtual TBuilder TrackMouse(bool trackMouse)
            {
                this.ToComponent().TrackMouse = trackMouse;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}