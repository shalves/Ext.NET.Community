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

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// This class monitors scrolling of the TableView within a GridPanel which is using a buffered store to only cache and render a small section of a very large dataset.
    /// </summary>
    [Meta]
    public partial class GridPagingScroller : GridScroller
    {
        /// <summary>
        /// 
        /// </summary>
        public GridPagingScroller() { }
        
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "paginggridscroller";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.PagingScroller";
            }
        }

        /// <summary>
        /// This is the time in milliseconds to buffer load requests when scrolling the PagingScrollbar. Defaults to: 200
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. GridPagingScroller")]
        [DefaultValue(200)]
        [Description("This is the time in milliseconds to buffer load requests when scrolling the PagingScrollbar. Defaults to: 200")]
        public virtual int ScrollToLoadBuffer
        {
            get
            {
                return this.State.Get<int>("ScrollToLoadBuffer", 200);
            }
            set
            {
                this.State.Set("ScrollToLoadBuffer", value);
            }
        }

        /// <summary>
        /// The zone which causes a refresh of the rendered viewport. As soon as the edge of the rendered grid is this number of rows from the edge of the viewport, the view is moved.
        /// </summary>
        [Meta]
        [ConfigOption("numFromEdge")]
        [Category("5. GridPagingScroller")]
        [DefaultValue(2)]
        [Description("The zone which causes a refresh of the rendered viewport. As soon as the edge of the rendered grid is this number of rows from the edge of the viewport, the view is moved.")]
        public virtual int NumberFromEdge
        {
            get
            {
                return this.State.Get<int>("NumberFromEdge", 2);
            }
            set
            {
                this.State.Set("NumberFromEdge", value);
            }
        }

        /// <summary>
        /// The number of extra rows to render on the trailing side of scrolling outside the NumberFromEdge buffer as scrolling proceeds.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. GridPagingScroller")]
        [DefaultValue(5)]
        [Description("The number of extra rows to render on the trailing side of scrolling outside the NumberFromEdge buffer as scrolling proceeds.")]
        public virtual int TrailingBufferZone
        {
            get
            {
                return this.State.Get<int>("TrailingBufferZone", 5);
            }
            set
            {
                this.State.Set("TrailingBufferZone", value);
            }
        }

        /// <summary>
        /// The number of extra rows to render on the leading side of scrolling outside the NumberFromEdge buffer as scrolling proceeds.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. GridPagingScroller")]
        [DefaultValue(15)]
        [Description("The number of extra rows to render on the leading side of scrolling outside the NumberFromEdge buffer as scrolling proceeds.")]
        public virtual int LeadingBufferZone
        {
            get
            {
                return this.State.Get<int>("LeadingBufferZone", 15);
            }
            set
            {
                this.State.Set("LeadingBufferZone", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. GridPagingScroller")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool VariableRowHeight
        {
            get
            {
                return this.State.Get<bool>("VariableRowHeight", false);
            }
            set
            {
                this.State.Set("VariableRowHeight", value);
            }
        }
    }
}
