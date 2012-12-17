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
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Ext.Net
{
    public partial class BuilderFactory<TModel> : BuilderFactory
    {
        public ModelField.Builder ModelFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var field = Ext.Net.Store.CreateModelFieldFromMeta(ModelMetadata.FromLambdaExpression(expression, this.HtmlHelper.ViewData), null, null, this.HtmlHelper.ViewContext.Controller != null ? this.HtmlHelper.ViewContext.Controller.ControllerContext : null);
            return new ModelField.Builder(field);
        }

        public ModelField.Builder ModelField<T, TProperty>(IEnumerable<T> model, Expression<Func<T, TProperty>> expression) where T : class
        {
            var field = Ext.Net.Store.CreateModelFieldFromMeta(ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<T>()), null, null, this.HtmlHelper.ViewContext.Controller != null ? this.HtmlHelper.ViewContext.Controller.ControllerContext : null);
            return new ModelField.Builder(field);
        }

        public ModelField.Builder ModelField<T, TProperty>(T model, Expression<Func<T, TProperty>> expression) where T : class
        {
            var field = Ext.Net.Store.CreateModelFieldFromMeta(ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<T>()), null, null, this.HtmlHelper.ViewContext.Controller != null ? this.HtmlHelper.ViewContext.Controller.ControllerContext : null);
            return new ModelField.Builder(field);
        }

        public ColumnBase ColumnFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var meta = ModelMetadata.FromLambdaExpression(expression, this.HtmlHelper.ViewData);
            var column = TablePanel.CreateColumn(meta, this.HtmlHelper.ViewContext);

            return column;
        }

        public ColumnBase ColumnFor<T, TProperty>(IEnumerable<T> model, Expression<Func<T, TProperty>> expression) where T : class
        {
            var meta = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<T>());
            var column = TablePanel.CreateColumn(meta, this.HtmlHelper.ViewContext);

            return column;
        }

        public ColumnBase ColumnFor<T, TProperty>(T model, Expression<Func<T, TProperty>> expression) where T : class
        {
            var meta = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<T>());
            var column = TablePanel.CreateColumn(meta, this.HtmlHelper.ViewContext);

            return column;
        }        

        public GridPanel.Builder GridPanelFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            var builder = this.CreateWidtgetForBuilder<GridPanel, GridPanel.Builder, TProperty>(expression, b =>
            {
                if (buildStore)
                {
                    b.ToComponent().Store.Add(this.StoreFor(expression, modelOnly));
                }
                b.ToComponent().InitForModelOnly = modelOnly;
                b.ToComponent().CreateModelColumns = createColumns;
            });

            return builder;
        }

        public GridPanel.Builder GridPanelFor(Type type, bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            var cmp = builder.ToComponent();
            if (buildStore)
            {
                cmp.Store.Add(this.StoreFor(type, modelOnly));
            }
            
            cmp.ViewContext = this.HtmlHelper.ViewContext;
            cmp.InitForModelOnly = modelOnly;
            cmp.CreateModelColumns = createColumns;
            cmp.InitByType(type);

            return builder;
        }

        public GridPanel.Builder GridPanelFor(IEnumerable data, bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            var cmp = builder.ToComponent();
            if (buildStore)
            {
                cmp.Store.Add(this.StoreFor(data, modelOnly));
            }

            cmp.ViewContext = this.HtmlHelper.ViewContext;
            cmp.InitForModelOnly = modelOnly;
            cmp.CreateModelColumns = createColumns;
            cmp.InitByObject(data);

            return builder;
        }

        public GridPanel.Builder GridPanelFor<T>(T model, bool modelOnly = false, bool buildStore = true, bool createColumns = true) where T : class
        {
            if (model is IEnumerable)
            {
                return this.GridPanelFor(model as IEnumerable, modelOnly, buildStore, createColumns);
            }
            
            return this.GridPanelFor<T>(modelOnly, buildStore, createColumns);
        }

        public GridPanel.Builder GridPanelFor<T>(bool modelOnly = false, bool buildStore = true, bool createColumns = true) where T : class
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            var cmp = builder.ToComponent();
            if (buildStore)
            {
                cmp.Store.Add(this.StoreFor<T>(modelOnly));
            }

            cmp.ViewContext = this.HtmlHelper.ViewContext;
            cmp.InitForModelOnly = modelOnly;
            cmp.CreateModelColumns = createColumns;
            cmp.InitByType(typeof(T));

            return builder;
        }

        public GridPanel.Builder GridPanelFor<T>(string viewDataKey, bool modelOnly = false, bool buildStore = true, bool createColumns = true) where T : class
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            var cmp = builder.ToComponent();
            if (buildStore)
            {
                cmp.Store.Add(this.StoreFor<T>(viewDataKey, modelOnly));
            }
            cmp.ViewContext = this.HtmlHelper.ViewContext;
            cmp.InitForModelOnly = modelOnly;
            cmp.CreateModelColumns = createColumns;
            cmp.InitByObject(this.HtmlHelper.ViewContext.ViewData.Eval(viewDataKey) as IEnumerable<T>);

            return builder;
        }

        public GridPanel.Builder GridPanelForModel(bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            var cmp = builder.ToComponent();
            if (buildStore)
            {
                cmp.Store.Add(this.StoreForModel(modelOnly));
            }
            cmp.ViewContext = this.HtmlHelper.ViewContext;
            cmp.InitForModelOnly = modelOnly;
            cmp.CreateModelColumns = createColumns;

            var meta = this.HtmlHelper.ViewData.ModelMetadata;

            if (meta.Model != null)
            {
                cmp.InitByObject(meta.Model);
            }
            else
            {
                cmp.InitByType(meta.ModelType);
            }

            return builder;
        }

        public Store.Builder StoreFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool modelOnly = false)
        {
            var builder = this.CreateWidtgetForBuilder<Store, Store.Builder, TProperty>(expression, b=>{
                b.ToComponent().InitForModelOnly = modelOnly;
            });
            
            return builder;
        }

        public Store.Builder StoreFor(IEnumerable data, bool modelOnly = false)
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByObject(data);

            return builder;
        }

        public Store.Builder StoreFor(Type type, bool modelOnly = false)
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByType(type);

            return builder;
        }

        public Store.Builder StoreFor<T>(T model, bool modelOnly = false) where T : class
        {
            if (model is IEnumerable)
            {
                return this.StoreFor(model as IEnumerable, modelOnly);
            }

            return this.StoreFor<T>(modelOnly);
        }

        public Store.Builder StoreFor<T>(bool modelOnly = false) where T:class
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByType(typeof(T));

            return builder;
        }

        public Store.Builder StoreFor<T>(string viewDataKey, bool modelOnly = false) where T : class
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByObject(this.HtmlHelper.ViewContext.ViewData.Eval(viewDataKey) as IEnumerable<T>);

            return builder;
        }

        public Store.Builder StoreForModel(bool modelOnly = false)
        {
            Store.Builder builder = new Store.Builder();
            var cmp = builder.ToComponent();
            cmp.ViewContext = this.HtmlHelper.ViewContext;
            cmp.InitForModelOnly = modelOnly;

            var meta = this.HtmlHelper.ViewData.ModelMetadata;

            if (meta.Model != null)
            {
                cmp.InitByObject(meta.Model);
            }
            else
            {
                cmp.InitByType(meta.ModelType);
            }

            return builder;
        }

        public FormPanel.Builder FormPanelFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool modelOnly = false, string htmlFieldName = "", object additionalViewData = null)
        {
            var builder = this.CreateWidtgetForBuilder<FormPanel, FormPanel.Builder, TProperty>(expression, b =>
            {
                var cmp = b.ToComponent();
                cmp.InitForModelOnly = modelOnly;
                cmp.HtmlFieldName = htmlFieldName;
                cmp.AdditionalViewData = additionalViewData;
            });

            return builder;
        }

        public FormPanel.Builder FormPanelForModel(bool modelOnly = false, string htmlFieldName = "", object additionalViewData = null)
        {
            FormPanel.Builder builder = new FormPanel.Builder();
            var cmp = builder.ToComponent();
            cmp.ViewContext = this.HtmlHelper.ViewContext;
            cmp.InitForModelOnly = modelOnly;
            cmp.HtmlFieldName = htmlFieldName;
            cmp.AdditionalViewData = additionalViewData;

            var meta = this.HtmlHelper.ViewData.ModelMetadata;

            if (meta.Model != null)
            {
                cmp.InitByObject(meta.Model, modelOnly, htmlFieldName, additionalViewData);
            }
            else
            {
                cmp.InitByType(meta.ModelType, null, modelOnly, htmlFieldName, additionalViewData);
            }

            return builder;
        }
        
        private TBuilder CreateWidtgetForBuilder<TControl, TBuilder, TProperty>(Expression<Func<TModel, TProperty>> expression, Action<TBuilder> beforeSet = null)
            where TControl : BaseControl
            where TBuilder : BaseControl.Builder<TControl, TBuilder>, new()
        {
            TBuilder builder = new TBuilder();
            var cmp = builder.ToComponent();
            cmp.ViewContext = this.HtmlHelper.ViewContext;

            builder.ControlFor(ExpressionHelper.GetExpressionText(expression));
            if (beforeSet != null)
            {
                beforeSet(builder);
            }
            cmp.SetControlFor(ModelMetadata.FromLambdaExpression(expression, this.HtmlHelper.ViewData));
            return builder;
        }
    }
}
