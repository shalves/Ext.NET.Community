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
    public abstract partial class AbstractStore
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractStore, TBuilder> : Observable.Builder<TAbstractStore, TBuilder>
            where TAbstractStore : AbstractStore
            where TBuilder : Builder<TAbstractStore, TBuilder>
        {
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
            /// The Proxy to use for this Store.
            /// </summary>
            /// <param name="proxy">proxy</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Proxy(AbstractProxy proxy)
            {
                this.ToComponent().Proxy.Add(proxy);
                return this as TBuilder;
            }

            /// <summary>
            /// The Proxy to use for reload or sync actions when Memory proxy is used for initial data
            /// </summary>
            /// <param name="proxy">proxy</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ServerProxy(AbstractProxy proxy)
            {
                this.ToComponent().ServerProxy.Add(proxy);
                return this as TBuilder;
            }

            /// <summary>
            /// The collection of Sorters currently applied to this Store
            /// </summary>
            /// <param name="sorter"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Sorters(DataSorter sorter)
            {
                this.ToComponent().Sorters.Add(sorter);
                return this as TBuilder;
            }

            /// <summary>
            /// The collection of Sorters currently applied to this Store
            /// </summary>
            /// <param name="property"></param>
            /// <param name="direction"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Sorters(string property, SortDirection direction)
            {
                this.ToComponent().Sorters.Add(new DataSorter { Property = property, Direction = direction });
                return this as TBuilder;
            }

            /// <summary>
            /// An object containing properties which are to be sent as parameters on auto load HTTP request.
            /// </summary>
            /// <param name="parameters"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder AutoLoadParams(object parameters)
            {
                if (parameters != null)
                {
                    this.ToComponent().AutoLoadParams.Add(parameters);
                }
                return this as TBuilder;
            }

            /// <summary>
            /// An object containing properties which are to be sent as parameters on any HTTP request.
            /// </summary>
            /// <param name="parameters"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Parameters(object parameters)
            {
                if (parameters != null)
                {
                    this.ToComponent().Parameters.Add(parameters);
                }
                return this as TBuilder;
            }

            /// <summary>
            /// An object containing properties which are to be sent as parameters on sync request.
            /// </summary>
            /// <param name="parameters"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SyncParameters(object parameters)
            {
                if (parameters != null)
                {
                    this.ToComponent().SyncParameters.Add(parameters);
                }
                return this as TBuilder;
            }
        }
    }
}