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
using System.Web.Mvc;
using System.ComponentModel;
using Ext.Net.MVC;
using Ext.Net.Utilities;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Linq.Expressions;
using System.Collections;

namespace Ext.Net
{
    public partial class FormPanel
    {
        protected override void OnMetadataProcess(ModelMetadata meta, string name, ViewDataDictionary viewData, ControllerContext context)
        {
            base.OnMetadataProcess(meta, name, viewData, context);

            if (meta.Model != null)
            {
                this.InitByObject(meta.Model, this.InitForModelOnly, this.HtmlFieldName, this.AdditionalViewData);
            }
            else
            {
                this.InitByType(meta.ModelType, null, this.InitForModelOnly, this.HtmlFieldName, this.AdditionalViewData);
            }
        }

        [Meta]
        public virtual void InitByObject(object obj, bool modelOnly = false, string htmlFieldName = "", object additionalViewData = null)
        {
            if (obj == null)
            {
                return;
            }

            if (obj is Type)
            {
                this.InitByType((Type)obj, null, modelOnly, htmlFieldName, additionalViewData);
                return;
            }

            this.InitByType(obj.GetType(), obj, modelOnly, htmlFieldName, additionalViewData);
        }

        [Meta]
        public virtual void InitByType(Type type)
        {
            this.InitByType(type, null);
        }

        [Meta]
        public virtual void InitByType(Type type, object data, bool modelOnly = false, string htmlFieldName = "", object additionalViewData = null)
        {
            type = Store.GetEnumerableGenericType(type);

            if (data is IEnumerable)
            {
                data = null;
            }

            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(delegate{return data;}, type);
            if (metadata != null)
            {                
                ResourcesRegistrator registrator = metadata.AdditionalValues.ContainsKey(ClientResourceAttribute.KEY) ? (ResourcesRegistrator)metadata.AdditionalValues[ClientResourceAttribute.KEY] : null;
                
                if (registrator != null)
                {
                    this.Controls.Add(registrator);
                }

                HtmlHelper html = Ext.Net.X.Builder.HtmlHelper;

                ViewDataDictionary viewData = new ViewDataDictionary(html.ViewDataContainer.ViewData)
                {
                    Model = data,
                    ModelMetadata = metadata,
                    TemplateInfo = new TemplateInfo
                    {
                        HtmlFieldPrefix = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)
                    }
                };

                if (additionalViewData != null)
                {
                    foreach (KeyValuePair<string, object> kvp in new RouteValueDictionary(additionalViewData))
                    {
                        viewData[kvp.Key] = kvp.Value;
                    }
                }
                
                HtmlHelper helper = new HtmlHelper(
                    new ViewContext(html.ViewContext, html.ViewContext.View, viewData, html.ViewContext.TempData, html.ViewContext.Writer),
                    new ViewDataContainer(viewData)
                );                

                foreach (ModelMetadata propertyMetadata in metadata.Properties)
                {
                    ModelFieldAttribute modelAttr = propertyMetadata.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY) ? (ModelFieldAttribute)propertyMetadata.AdditionalValues[ModelFieldAttribute.KEY] : null;

                    if (!propertyMetadata.ShowForEdit)
                    {
                        continue;
                    }
                    
                    if (modelAttr == null && this.InitForModelOnly)
                    {
                        continue;
                    }

                    FieldAttribute fieldAttr = propertyMetadata.AdditionalValues.ContainsKey(FieldAttribute.KEY) ? (FieldAttribute)propertyMetadata.AdditionalValues[FieldAttribute.KEY] : null;

                    if ((modelAttr != null && modelAttr.Ignore) || (fieldAttr != null && fieldAttr.Ignore))
                    {
                        continue;
                    }

                    if (propertyMetadata.TemplateHint.IsNotEmpty())
                    {
                        this.Items.Add(new MvcItem(delegate { return EditorExtensions.Editor(helper, propertyMetadata.PropertyName, propertyMetadata.TemplateHint); }));
                    }
                    else
                    {                        
                        Type fieldType = null;

                        if (fieldAttr != null && fieldAttr.FieldType != null)
                        {
                            fieldType = fieldAttr.FieldType;

                            if (!fieldType.IsSubclassOf(typeof(Ext.Net.Field)))
                            {
                                throw new Exception("FieldType must be subclass of Ext.Net.Field");
                            }
                        }
                        else
                        {
                            if (propertyMetadata.IsComplexType)
                            {
                                continue;
                            }

                            if (Store.IsDate(propertyMetadata.ModelType))
                            {
                                fieldType = typeof(Ext.Net.DateField);
                            }
                            else if (Store.IsNumeric(propertyMetadata.ModelType))
                            {
                                fieldType = typeof(Ext.Net.NumberField);
                            }
                            else if (Store.IsBoolean(propertyMetadata.ModelType))
                            {
                                fieldType = typeof(Ext.Net.Checkbox);
                            }
                            else
                            {
                                fieldType = typeof(Ext.Net.TextField);
                            }
                        }

                        Field cmp = (Ext.Net.Field)System.Activator.CreateInstance(fieldType);

                        cmp.ViewContext = helper.ViewContext;
                        cmp.ControlFor = propertyMetadata.PropertyName;                        
                        cmp.SetControlFor(propertyMetadata);

                        this.Items.Add(cmp);
                    }
                }
            }
        }

        [DefaultValue(false)]
        internal virtual bool InitForModelOnly
        {
            get
            {
                return this.State.Get<bool>("InitForModelOnly", false);
            }
            set
            {
                this.State.Set("InitForModelOnly", value);
            }
        }

        [DefaultValue("")]
        internal virtual string HtmlFieldName
        {
            get
            {
                return this.State.Get<string>("HtmlFieldName", "");
            }
            set
            {
                this.State.Set("HtmlFieldName", value);
            }
        }

        [DefaultValue(null)]
        internal object AdditionalViewData
        {
            get
            {
                return this.State.Get<string>("AdditionalViewData", null);
            }
            set
            {
                this.State.Set("AdditionalViewData", value);
            }
        }
    }
}
