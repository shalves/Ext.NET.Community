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
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ext.Net
{
    public abstract partial class TreePanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TTreePanelBase, TBuilder> : TablePanel.Builder<TTreePanelBase, TBuilder>
            where TTreePanelBase : TreePanelBase
            where TBuilder : Builder<TTreePanelBase, TBuilder>
        {
            public virtual TBuilder Store(TreeStore store)
            {
                this.ToComponent().Store.Add(store);
                return this as TBuilder;
            }

            /// <summary>
            /// Allows you to not specify a store on this TreePanel. This is useful for creating a simple tree with preloaded data without having to specify a TreeStore and Model. A store and model will be created and root will be passed to that store.
            /// </summary>
            /// <param name="root"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Root(Node root)
            {
                this.ToComponent().Root.Add(root);
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="model"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Model(Model model)
            {
                this.ToComponent().Model.Add(model);
                return this as TBuilder;
            }

            /// <summary>
            /// The Ext.grid.View used by the grid. This can be set before a call to render().
            /// </summary>
            /// <param name="view"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder View(TreeView view)
            {
                this.ToComponent().View.Add(view);
                return this as TBuilder;
            }

            /// <summary>
            /// An array of fields definition objects
            /// </summary>
            /// <param name="fields"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Fields(params ModelField[] fields)
            {
                this.ToComponent().Fields.AddRange(fields);
                return this as TBuilder;
            }

            /// <summary>
            /// An array of fields definition objects
            /// </summary>
            /// <param name="fields"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Fields(IEnumerable<ModelField> fields)
            {
                this.ToComponent().Fields.AddRange(fields);
                return this as TBuilder;
            }
        }
    }
}