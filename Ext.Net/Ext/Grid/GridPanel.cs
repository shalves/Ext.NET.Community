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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Grids are an excellent way of showing large amounts of tabular data on the client side. Essentially a supercharged table, GridPanel makes it easy to fetch, sort and filter large amounts of data.
    /// 
    /// Grids are composed of two main pieces - a Store full of data and a set of columns to render.
    /// 
    /// By default, each column is sortable and will toggle between ASC and DESC sorting when you click on its header. Each column header is also reorderable by default, and each gains a drop-down menu with options to hide and show columns.
    /// 
    /// As well as customizing columns, it's easy to alter the rendering of individual cells using renderers. A renderer is tied to a particular column and is passed the value that would be rendered into each cell in that column.
    /// 
    /// Sometimes all you want is to render data onto the screen for viewing, but usually it's necessary to interact with or update that data. Grids use a concept called a Selection Model, which is simply a mechanism for selecting some part of the data in the grid. The two main types of Selection Model are RowSelectionModel, where entire rows are selected, and CellSelectionModel, where individual cells are selected. 
    /// Grids use a Row Selection Model by default. Specifying the cellmodel changes a couple of things. Firstly, clicking on a cell now selects just that cell (using a rowmodel will select the entire row), and secondly the keyboard navigation will walk from cell to cell instead of row to row. Cell-based selection models are usually used in conjunction with editing.
    /// 
    /// Grid has built-in support for in-line editing. There are two chief editing modes - cell editing and row editing.
    /// 
    /// Every grid is attached to a Store, which provides multi-sort and filtering capabilities.
    /// 
    /// Grid supports infinite scrolling as an alternative to using a paging toolbar. Your users can scroll through thousands of records without the performance penalties of renderering all the records on screen at once. The grid should be bound to a buffered store with a pageSize specified.
    /// The number of rows rendered outside the visible area, and the buffering of pages of data from the remote server for immediate rendering upon scroll can be controlled by configuring the #verticalScroller.
    /// You can tell it to create a larger table to provide more scrolling before a refresh is needed, and also to keep more pages of records in memory for faster refreshing when scrolling.
    /// 
    /// Grid supports paging through large sets of data via a PagingToolbar or PagingGridScroller (see the Infinite Scrolling section above). To leverage paging via a toolbar or scroller, you need to set a pageSize configuration on the Store.
    /// 
    /// When configured stateful, grids save their column state (order and width) encapsulated within the default Panel state of changed width and height and collapsed/expanded state.
    /// Each column of the grid may be configured with a stateId which identifies that column locally within the grid.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:GridPanel runat=\"server\" Title=\"Title\" Height=\"300\"></{0}:GridPanel>")]
    [ToolboxBitmap(typeof(GridPanel), "Build.ToolboxIcons.GridPanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Grids are an excellent way of showing large amounts of tabular data on the client side.")]
    public partial class GridPanel : GridPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public GridPanel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "grid";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.Panel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }
        }

        private GridPanelListeners listeners;

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
        public GridPanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridPanelListeners();
                }

                return this.listeners;
            }
        }

        private GridPanelDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public GridPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GridPanelDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}