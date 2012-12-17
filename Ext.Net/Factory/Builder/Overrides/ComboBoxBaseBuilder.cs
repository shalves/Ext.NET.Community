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
using System.Linq;
using System.Text;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ComboBoxBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TComboBoxBase, TBuilder> : PickerField.Builder<TComboBoxBase, TBuilder>
            where TComboBoxBase : ComboBoxBase
            where TBuilder : Builder<TComboBoxBase, TBuilder>
        {
            public virtual TBuilder Store(Store store)
            {
                this.ToComponent().Store.Add(store);
                return this as TBuilder;
            }

            public virtual TBuilder Items(IEnumerable<ListItem> items)
            {
                this.ToComponent().Items.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder Items(params ListItem[] items)
            {
                this.ToComponent().Items.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder Items(ListItem item)
            {
                this.ToComponent().Items.Add(item);
                return this as TBuilder;
            }

            public virtual TBuilder Items(object items)
            {
                this.ToComponent().Items.Add(items);
                return this as TBuilder;
            }

            public virtual TBuilder Items(string item)
            {
                this.ToComponent().Items.Add(new ListItem(item));
                return this as TBuilder;
            }

            public virtual TBuilder Items(params string[] items)
            {
                this.ToComponent().Items.AddRange(items.Select(i=>new ListItem(i)));
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(IEnumerable<ListItem> items)
            {
                this.ToComponent().SelectedItems.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(params ListItem[] items)
            {
                this.ToComponent().SelectedItems.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(ListItem item)
            {
                this.ToComponent().SelectedItems.Add(item);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(object items)
            {
                this.ToComponent().SelectedItems.Add(items);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(string item)
            {
                this.ToComponent().SelectedItems.Add(new ListItem(item));
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(params string[] items)
            {
                this.ToComponent().SelectedItems.AddRange(items.Select(i => new ListItem(i)));
                return this as TBuilder;
            }
        }
    }
}