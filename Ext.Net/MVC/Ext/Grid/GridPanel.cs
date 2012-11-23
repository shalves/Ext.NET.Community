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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

using Ext.Net.MVC;
using Ext.Net.Utilities;

namespace Ext.Net
{
    public partial class GridPanel
    {
        protected override void OnMetadataProcess(ModelMetadata meta, string name, ViewDataDictionary viewData, ControllerContext context)
        {
            base.OnMetadataProcess(meta, name, viewData, context);
            if (meta.Model != null)
            {
                this.InitByObject(meta.Model, this.InitForModelOnly);
            }
            else
            {
                this.InitByType(meta.ModelType, this.InitForModelOnly);
            }
        }

        [Meta]
        public virtual void InitByObject(object obj, bool modelOnly = false)
        {
            if (obj is Type)
            {
                this.InitByType((Type)obj, modelOnly);
                return;
            }

            IEnumerable collection = obj as IEnumerable;
            if (collection == null)
            {
                this.InitByType(obj.GetType(), modelOnly);
                return;
            }

            Type itemType = null;

            IEnumerator enumerator = collection.GetEnumerator();
            if (enumerator.MoveNext())
            {
                if (enumerator.Current != null)
                {
                    itemType = enumerator.Current.GetType();
                }
                enumerator.Reset();
            }

            if (itemType == null)
            {
                itemType = Ext.Net.Store.GetEnumerableGenericType(obj.GetType());
            }

            if (itemType == null)
            {
                throw new InvalidOperationException("Cannot determine an item type");
            }

            this.InitByType(itemType, modelOnly, false);
        }

        [Meta]
        public virtual void InitByType(Type type, bool modelOnly = false, bool extractGeneric = true)
        {
            if(!this.CreateModelColumns)
            {
                return;
            }

            if (extractGeneric)
            {
                type = Ext.Net.Store.GetEnumerableGenericType(type);
            }

            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(null, type);
            if (metadata != null)
            {     
                List<ModelMetadata> list = metadata.Properties.ToList();

                list.Sort((m1, m2)=>{
                    bool order1 = m1.AdditionalValues.ContainsKey(ColumnBaseAttribute.KEY_ORDER);
                    bool order2 = m2.AdditionalValues.ContainsKey(ColumnBaseAttribute.KEY_ORDER);

                    if (order1 && order2)
                    {
                        return ((int)m1.AdditionalValues[ColumnBaseAttribute.KEY_ORDER]).CompareTo((int)m2.AdditionalValues[ColumnBaseAttribute.KEY_ORDER]);
                    }

                    if (!order1 && !order2)
                    {
                        return 0;
                    }

                    if (order1)
                    {
                        return 1;
                    }

                    return -1;
                });

                foreach (ModelMetadata propertyMetadata in list)
                {
                    ColumnBase column = propertyMetadata.AdditionalValues.ContainsKey(ColumnBaseAttribute.KEY) ? (ColumnBase)propertyMetadata.AdditionalValues[ColumnBaseAttribute.KEY] : null;
                    
                    if (column == null && modelOnly)
                    {
                        continue;
                    }

                    if (propertyMetadata.AdditionalValues.ContainsKey(ColumnBaseAttribute.KEY_IGNORE))
                    {
                        continue;
                    }

                    if (column == null)
                    {
                        column = this.CreateColumn(propertyMetadata);
                        column.DataIndex = propertyMetadata.PropertyName;
                        if (propertyMetadata.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY))
                        {
                            string name = ((ModelFieldAttribute)propertyMetadata.AdditionalValues[ModelFieldAttribute.KEY]).Name;
                            if (name.IsNotEmpty())
                            {
                                column.DataIndex = name;
                            }
                        }

                        column.Text = Regex.Replace(propertyMetadata.PropertyName, "([a-z])([A-Z])", "$1 $2");
                    }

                    this.ColumnModel.Columns.Add(column);                    
                }
            }
        }

        protected virtual ColumnBase CreateColumn(ModelMetadata propertyMetadata)
        {
            return new Column();
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

        [DefaultValue(true)]
        internal virtual bool CreateModelColumns
        {
            get
            {
                return this.State.Get<bool>("CreateModelColumns", true);
            }
            set
            {
                this.State.Set("CreateModelColumns", value);
            }
        }
    }
}
