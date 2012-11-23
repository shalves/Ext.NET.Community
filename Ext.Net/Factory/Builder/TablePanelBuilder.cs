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
    public abstract partial class TablePanel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTablePanel, TBuilder> : AbstractPanel.Builder<TTablePanel, TBuilder>
            where TTablePanel : TablePanel
            where TBuilder : Builder<TTablePanel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTablePanel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// (optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(Action<EditorCollection> action)
            {
                action(this.ToComponent().Editor);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EditorStrategy(Action<JFunction> action)
            {
                action(this.ToComponent().EditorStrategy);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Editor options
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EditorOptions(Action<CellEditorOptions> action)
            {
                action(this.ToComponent().EditorOptions);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
            public virtual TBuilder ColumnLines(bool columnLines)
            {
                this.ToComponent().ColumnLines = columnLines;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ColumnModel(Action<GridHeaderContainer> action)
            {
                action(this.ToComponent().ColumnModel);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Defaults to true to enable deferred row rendering.
			/// </summary>
            public virtual TBuilder DeferRowRender(bool deferRowRender)
            {
                this.ToComponent().DeferRowRender = deferRowRender;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable selection model. Defaults to: false
			/// </summary>
            public virtual TBuilder DisableSelection(bool disableSelection)
            {
                this.ToComponent().DisableSelection = disableSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Default text (html tags are accepted) to display in the Panel body when the Store is empty. When specified, and the Store is empty, the text will be rendered inside a DIV with the CSS class \"x-grid-empty\".
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable column hiding within this grid. Defaults to: true
			/// </summary>
            public virtual TBuilder EnableColumnHide(bool enableColumnHide)
            {
                this.ToComponent().EnableColumnHide = enableColumnHide;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable column dragging within this grid. Defaults to: true
			/// </summary>
            public virtual TBuilder EnableColumnMove(bool enableColumnMove)
            {
                this.ToComponent().EnableColumnMove = enableColumnMove;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable column resizing within this grid. Defaults to: true
			/// </summary>
            public virtual TBuilder EnableColumnResize(bool enableColumnResize)
            {
                this.ToComponent().EnableColumnResize = enableColumnResize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable locking support for this grid. Alternatively, locking will also be automatically enabled if any of the columns in the column configuration contain the locked config option. Defaults to: false
			/// </summary>
            public virtual TBuilder EnableLocking(bool enableLocking)
            {
                this.ToComponent().EnableLocking = enableLocking;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
			/// </summary>
            public virtual TBuilder ForceFit(bool forceFit)
            {
                this.ToComponent().ForceFit = forceFit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable 'MULTI' selection mode on selection model.
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to constrain column dragging so that a column cannot be dragged in or out of it's current group. Only relevant while enableColumnMove is enabled.
			/// </summary>
            public virtual TBuilder SealedColumns(bool sealedColumns)
            {
                this.ToComponent().SealedColumns = sealedColumns;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Adds row line styling. Defaults to: true
			/// </summary>
            public virtual TBuilder RowLines(bool rowLines)
            {
                this.ToComponent().RowLines = rowLines;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Scrollers configuration. Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.
			/// </summary>
            public virtual TBuilder Scroll(ScrollMode scroll)
            {
                this.ToComponent().Scroll = scroll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.
			/// </summary>
            public virtual TBuilder ScrollDelta(int scrollDelta)
            {
                this.ToComponent().ScrollDelta = scrollDelta;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable 'SIMPLE' selection mode on selection model.
			/// </summary>
            public virtual TBuilder SimpleSelect(bool simpleSelect)
            {
                this.ToComponent().SimpleSelect = simpleSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable column sorting via clicking the header and via the Sorting menu items. Defaults to: true
			/// </summary>
            public virtual TBuilder SortableColumns(bool sortableColumns)
            {
                this.ToComponent().SortableColumns = sortableColumns;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectionModel(Action<SelectionModelCollection> action)
            {
                action(this.ToComponent().SelectionModel);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Selection model type
			/// </summary>
            public virtual TBuilder SelType(SelectionType? selType)
            {
                this.ToComponent().SelType = selType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. 
			/// </summary>
            public virtual TBuilder AllowDeselect(bool allowDeselect)
            {
                this.ToComponent().AllowDeselect = allowDeselect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Reset the scrollbar when the view refreshs. Defaults to true
			/// </summary>
            public virtual TBuilder InvalidateScrollerOnRefresh(bool invalidateScrollerOnRefresh)
            {
                this.ToComponent().InvalidateScrollerOnRefresh = invalidateScrollerOnRefresh;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddColumn(ColumnBase column, bool doLayout)
            {
                this.ToComponent().AddColumn(column, doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddColumn(ColumnBase column)
            {
                this.ToComponent().AddColumn(column);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InsertColumn(int index, ColumnBase column, bool doLayout)
            {
                this.ToComponent().InsertColumn(index, column, doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InsertColumn(int index, ColumnBase column)
            {
                this.ToComponent().InsertColumn(index, column);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveColumn(int index, bool doLayout)
            {
                this.ToComponent().RemoveColumn(index, doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveColumn(int index)
            {
                this.ToComponent().RemoveColumn(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveAllColumns(bool doLayout)
            {
                this.ToComponent().RemoveAllColumns(doLayout);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveAllColumns()
            {
                this.ToComponent().RemoveAllColumns();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reconfigure(string storeId)
            {
                this.ToComponent().Reconfigure(storeId);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reconfigure()
            {
                this.ToComponent().Reconfigure();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reconfigure(AbstractStore store, IEnumerable<ColumnBase> columns)
            {
                this.ToComponent().Reconfigure(store, columns);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reconfigure(IEnumerable<ColumnBase> columns)
            {
                this.ToComponent().Reconfigure(columns);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Refresh()
            {
                this.ToComponent().Refresh();
                return this as TBuilder;
            }
            
        }        
    }
}