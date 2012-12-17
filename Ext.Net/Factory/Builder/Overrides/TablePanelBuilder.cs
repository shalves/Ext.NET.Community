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
            /// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ColumnModel(IEnumerable<ColumnBase> columns)
            {
                this.ToComponent().ColumnModel.Columns.AddRange(columns);
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            public virtual TBuilder ColumnModel(params ColumnBase[] columns)
            {
                this.ToComponent().ColumnModel.Columns.AddRange(columns);
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            public virtual TBuilder ColumnModel(ColumnBase column)
            {
                this.ToComponent().ColumnModel.Columns.Add(column);
                return this as TBuilder;
            }

            /// <summary>
            /// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
            /// </summary>
            /// <param name="sm">sm</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectionModel(AbstractSelectionModel sm)
            {
                this.ToComponent().SelectionModel.Add(sm);
                return this as TBuilder;
            }

            /// <summary>
            /// (optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.
            /// </summary>
            /// <param name="editors"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(params Field[] editors)
            {
                this.ToComponent().Editor.AddRange(editors);
                return this as TBuilder;
            }

            /// <summary>
            /// (optional) The Ext.form.Field to use when editing values in columns if editing is supported by the grid.
            /// </summary>
            /// <param name="editors"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(IEnumerable<Field> editors)
            {
                this.ToComponent().Editor.AddRange(editors);
                return this as TBuilder;
            }
        }        
    }
}