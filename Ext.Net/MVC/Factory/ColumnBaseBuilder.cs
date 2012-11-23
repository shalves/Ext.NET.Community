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
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ColumnBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TColumnBase, TBuilder> : ComponentBase.Builder<TColumnBase, TBuilder>
            where TColumnBase : ColumnBase
            where TBuilder : Builder<TColumnBase, TBuilder>
        {
            /// <summary>
            /// Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.
            /// </summary>
            public virtual TBuilder DataIndex<T, TProperty>(IEnumerable<T> model, Expression<Func<T, TProperty>> expression) where T : class
            {
                this.ToComponent().DataIndex = ExpressionHelper.GetExpressionText(expression);
                return this as TBuilder;
            }

            /// <summary>
            /// Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.
            /// </summary>
            public virtual TBuilder DataIndex<T, TProperty>(T model, Expression<Func<T, TProperty>> expression) where T : class
            {
                this.ToComponent().DataIndex = ExpressionHelper.GetExpressionText(expression);
                return this as TBuilder;
            }
        }        
    }
}