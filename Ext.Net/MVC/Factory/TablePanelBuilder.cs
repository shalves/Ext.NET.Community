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
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Ext.Net.MVC;
using Ext.Net.Utilities;

namespace Ext.Net
{
    public class GenericColumnBuilder<T> where T : class
    {
        private HtmlHelper helper;
        private ColumnCollection columns = new ColumnCollection();

        public GenericColumnBuilder(HtmlHelper helper)
        {
            this.helper = helper;
        }

        public ColumnCollection Columns
        {
            get
            {
                return this.columns;
            }
        }

        public ColumnBase For<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var meta = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<T>());
            var column = TablePanel.CreateColumn(meta, this.helper.ViewContext);

            this.columns.Add(column);

            return column;
        }
    }

    public partial class TablePanel
    {
        internal static ColumnBase CreateColumn(ModelMetadata meta, ViewContext viewContext)
        {
            if (meta == null)
            {
                throw new ArgumentNullException("meta", "ModelMetadata is null");
            }
            var column = meta.AdditionalValues.ContainsKey(ColumnBaseAttribute.KEY) ? (ColumnBase)meta.AdditionalValues[ColumnBaseAttribute.KEY] : null;

            if (column == null)
            {
                column = new Column();
                column.DataIndex = meta.PropertyName;
                if (meta.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY))
                {
                    string name = ((ModelFieldAttribute)meta.AdditionalValues[ModelFieldAttribute.KEY]).Name;
                    if (name.IsNotEmpty())
                    {
                        column.DataIndex = name;
                    }
                }

                column.Text = Regex.Replace(meta.PropertyName, "([a-z])([A-Z])", "$1 $2");
            }

            if (viewContext != null)
            {
                column.ViewContext = viewContext;
            }

            return column;
        }

        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTablePanel, TBuilder> : AbstractPanel.Builder<TTablePanel, TBuilder>
            where TTablePanel : TablePanel
            where TBuilder : Builder<TTablePanel, TBuilder>
        {
            public TBuilder ColumnFor<T>(Action<GenericColumnBuilder<T>> columns) where T : class
            {
                var _columns = new GenericColumnBuilder<T>(Ext.Net.X.Builder.HtmlHelper);
                columns(_columns);

                this.ToComponent().ColumnModel.Columns.AddRange(_columns.Columns);

                return this as TBuilder;
            }

            public TBuilder ColumnFor<T, TProperty>(IEnumerable<T> model, Expression<Func<T, TProperty>> expression) where T : class
            {
                var viewContext = Ext.Net.X.Builder.HtmlHelper.ViewContext;
                var column = TablePanel.CreateColumn(ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<T>()), Ext.Net.X.Builder.HtmlHelper.ViewContext);
                this.ToComponent().ColumnModel.Columns.Add(column);

                return this as TBuilder;
            }

            public TBuilder ColumnFor<T, TProperty>(T model, Expression<Func<T, TProperty>> expression) where T : class
            {
                var viewContext = Ext.Net.X.Builder.HtmlHelper.ViewContext;
                var column = TablePanel.CreateColumn(ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<T>()), Ext.Net.X.Builder.HtmlHelper.ViewContext);
                this.ToComponent().ColumnModel.Columns.Add(column);

                return this as TBuilder;
            }
        }
    }
}