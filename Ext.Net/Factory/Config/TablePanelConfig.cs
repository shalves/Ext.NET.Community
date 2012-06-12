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
        new public abstract partial class Config : AbstractPanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private EditorCollection editor = null;

			/// <summary>
			/// (optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.
			/// </summary>
			public EditorCollection Editor
			{
				get
				{
					if (this.editor == null)
					{
						this.editor = new EditorCollection();
					}
			
					return this.editor;
				}
			}
			        
			private JFunction editorStrategy = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction EditorStrategy
			{
				get
				{
					if (this.editorStrategy == null)
					{
						this.editorStrategy = new JFunction();
					}
			
					return this.editorStrategy;
				}
			}
			        
			private CellEditorOptions editorOptions = null;

			/// <summary>
			/// Editor options
			/// </summary>
			public CellEditorOptions EditorOptions
			{
				get
				{
					if (this.editorOptions == null)
					{
						this.editorOptions = new CellEditorOptions();
					}
			
					return this.editorOptions;
				}
			}
			
			private bool columnLines = false;

			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ColumnLines 
			{ 
				get
				{
					return this.columnLines;
				}
				set
				{
					this.columnLines = value;
				}
			}
        
			private GridHeaderContainer columnModel = null;

			/// <summary>
			/// Column definitions which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
			/// </summary>
			public GridHeaderContainer ColumnModel
			{
				get
				{
					if (this.columnModel == null)
					{
						this.columnModel = new GridHeaderContainer();
					}
			
					return this.columnModel;
				}
			}
			
			private bool deferRowRender = true;

			/// <summary>
			/// Defaults to true to enable deferred row rendering.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferRowRender 
			{ 
				get
				{
					return this.deferRowRender;
				}
				set
				{
					this.deferRowRender = value;
				}
			}

			private bool disableSelection = false;

			/// <summary>
			/// True to disable selection model. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableSelection 
			{ 
				get
				{
					return this.disableSelection;
				}
				set
				{
					this.disableSelection = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// Default text (html tags are accepted) to display in the Panel body when the Store is empty. When specified, and the Store is empty, the text will be rendered inside a DIV with the CSS class \"x-grid-empty\".
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private bool enableColumnHide = true;

			/// <summary>
			/// False to disable column hiding within this grid. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnHide 
			{ 
				get
				{
					return this.enableColumnHide;
				}
				set
				{
					this.enableColumnHide = value;
				}
			}

			private bool enableColumnMove = true;

			/// <summary>
			/// False to disable column dragging within this grid. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnMove 
			{ 
				get
				{
					return this.enableColumnMove;
				}
				set
				{
					this.enableColumnMove = value;
				}
			}

			private bool enableColumnResize = true;

			/// <summary>
			/// False to disable column resizing within this grid. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnResize 
			{ 
				get
				{
					return this.enableColumnResize;
				}
				set
				{
					this.enableColumnResize = value;
				}
			}

			private bool enableLocking = false;

			/// <summary>
			/// True to enable locking support for this grid. Alternatively, locking will also be automatically enabled if any of the columns in the column configuration contain the locked config option. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableLocking 
			{ 
				get
				{
					return this.enableLocking;
				}
				set
				{
					this.enableLocking = value;
				}
			}

			private bool forceFit = false;

			/// <summary>
			/// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceFit 
			{ 
				get
				{
					return this.forceFit;
				}
				set
				{
					this.forceFit = value;
				}
			}

			private bool multiSelect = false;

			/// <summary>
			/// True to enable 'MULTI' selection mode on selection model.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MultiSelect 
			{ 
				get
				{
					return this.multiSelect;
				}
				set
				{
					this.multiSelect = value;
				}
			}

			private bool restrictColumnReorder = false;

			/// <summary>
			/// True to constrain column dragging so that a column cannot be dragged in or out of it's current group. Only relevant while enableColumnMove is enabled. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RestrictColumnReorder 
			{ 
				get
				{
					return this.restrictColumnReorder;
				}
				set
				{
					this.restrictColumnReorder = value;
				}
			}

			private bool rowLines = true;

			/// <summary>
			/// Adds row line styling. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RowLines 
			{ 
				get
				{
					return this.rowLines;
				}
				set
				{
					this.rowLines = value;
				}
			}

			private ScrollMode scroll = ScrollMode.Both;

			/// <summary>
			/// Scrollers configuration. Valid values are 'both', 'horizontal', 'vertical'  or 'none'. Defaults to Both.
			/// </summary>
			[DefaultValue(ScrollMode.Both)]
			public virtual ScrollMode Scroll 
			{ 
				get
				{
					return this.scroll;
				}
				set
				{
					this.scroll = value;
				}
			}

			private int scrollDelta = 40;

			/// <summary>
			/// Number of pixels to scroll when scrolling with mousewheel. Defaults to 40.
			/// </summary>
			[DefaultValue(40)]
			public virtual int ScrollDelta 
			{ 
				get
				{
					return this.scrollDelta;
				}
				set
				{
					this.scrollDelta = value;
				}
			}

			private bool simpleSelect = false;

			/// <summary>
			/// True to enable 'SIMPLE' selection mode on selection model.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SimpleSelect 
			{ 
				get
				{
					return this.simpleSelect;
				}
				set
				{
					this.simpleSelect = value;
				}
			}

			private bool sortableColumns = true;

			/// <summary>
			/// False to disable column sorting via clicking the header and via the Sorting menu items. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SortableColumns 
			{ 
				get
				{
					return this.sortableColumns;
				}
				set
				{
					this.sortableColumns = value;
				}
			}
        
			private SelectionModelCollection selectionModel = null;

			/// <summary>
			/// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
			/// </summary>
			public SelectionModelCollection SelectionModel
			{
				get
				{
					if (this.selectionModel == null)
					{
						this.selectionModel = new SelectionModelCollection();
					}
			
					return this.selectionModel;
				}
			}
			
			private SelectionType? selType = null;

			/// <summary>
			/// Selection model type
			/// </summary>
			[DefaultValue(null)]
			public virtual SelectionType? SelType 
			{ 
				get
				{
					return this.selType;
				}
				set
				{
					this.selType = value;
				}
			}

			private bool allowDeselect = false;

			/// <summary>
			/// Allow users to deselect a record in a DataView, List or Grid. Only applicable when the SelectionModel's mode is 'SINGLE'. Defaults to false. 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowDeselect 
			{ 
				get
				{
					return this.allowDeselect;
				}
				set
				{
					this.allowDeselect = value;
				}
			}

			private bool invalidateScrollerOnRefresh = true;

			/// <summary>
			/// Reset the scrollbar when the view refreshs. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool InvalidateScrollerOnRefresh 
			{ 
				get
				{
					return this.invalidateScrollerOnRefresh;
				}
				set
				{
					this.invalidateScrollerOnRefresh = value;
				}
			}

			private string storeID = "";

			/// <summary>
			/// The data store to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string StoreID 
			{ 
				get
				{
					return this.storeID;
				}
				set
				{
					this.storeID = value;
				}
			}

        }
    }
}