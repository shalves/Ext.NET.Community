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
using System.Collections;
using System.ComponentModel;
using Ext.Net.MVC;
using Ext.Net.Utilities;

namespace Ext.Net
{
    public partial class Store
    {        
        protected override void OnMetadataProcess(ModelMetadata meta, string name, ViewDataDictionary viewData, ControllerContext context)
        {
            base.OnMetadataProcess(meta, name, viewData, context);
            if (meta.Model != null)
            {
                this.InitByObject(meta.Model);
            }
            else
            {
                this.InitByType(meta.ModelType);
            }
        }        

        [Meta]
        public virtual void InitByObject(object obj)
        {
            if (obj is Type)
            {
                this.InitByType((Type)obj);
                return;
            }

            IEnumerable collection = obj as IEnumerable;
            if (collection == null)
            {
                this.InitByType(obj.GetType());
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
                itemType = Store.GetEnumerableGenericType(obj.GetType());
            }

            if (itemType == null)
            {
                throw new InvalidOperationException("Cannot determine an item type of Store data");
            }

            this.InitByType(itemType, false);
            this.DataSource = obj;
        }

        [Meta]
        [DefaultValue(false)]
        public virtual bool InitForModelOnly
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
        
        [Meta]
        public virtual void InitByType(Type type, bool extractGeneric = true)
        {
            if (extractGeneric)
            {
                type = Store.GetEnumerableGenericType(type);
            }
            
            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(null, type);
            if (metadata != null)
            {                
                var storeModel = this.Model.Primary;
                if (storeModel == null)
                {
                    storeModel = new Model();
                    this.Model.Add(storeModel);
                }

                ModelAttribute storeModelAttr = metadata.AdditionalValues.ContainsKey(ModelAttribute.KEY) ? (ModelAttribute)metadata.AdditionalValues[ModelAttribute.KEY] : null;
                if (storeModelAttr != null)
                {
                    storeModelAttr.CopyTo(storeModel);
                }

                if (metadata.AdditionalValues.ContainsKey(AbstractValidationAttribute.KEY))
                {
                    storeModel.Validations.AddRange((ValidationCollection)metadata.AdditionalValues[AbstractValidationAttribute.KEY]);
                }

                if (metadata.AdditionalValues.ContainsKey(AbstractAssociationAttribute.KEY))
                {
                    storeModel.Associations.AddRange((AssociationCollection)metadata.AdditionalValues[AbstractAssociationAttribute.KEY]);
                }

                if (metadata.AdditionalValues.ContainsKey(ProxyAttribute.KEY))
                {
                    this.Proxy.Add((AbstractProxy)metadata.AdditionalValues[ProxyAttribute.KEY]);
                }

                if (metadata.AdditionalValues.ContainsKey(AbstractReaderAttribute.KEY))
                {
                    if (this.Proxy.Primary != null && this.Proxy.Primary is ServerProxy)
                    {
                        ((ServerProxy)this.Proxy.Primary).Reader.Add((AbstractReader)metadata.AdditionalValues[AbstractReaderAttribute.KEY]);
                    }
                    else
                    {
                        this.Reader.Add((AbstractReader)metadata.AdditionalValues[AbstractReaderAttribute.KEY]);
                    }
                }

                if (metadata.AdditionalValues.ContainsKey(AbstractWriterAttribute.KEY))
                {
                    if (this.Proxy.Primary != null && this.Proxy.Primary is ServerProxy)
                    {
                        ((ServerProxy)this.Proxy.Primary).Writer.Add((AbstractWriter)metadata.AdditionalValues[AbstractWriterAttribute.KEY]);
                    }
                    else
                    {
                        this.Writer.Add((AbstractWriter)metadata.AdditionalValues[AbstractWriterAttribute.KEY]);
                    }
                }

                var virtualFieldsAttr = metadata.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY) ? (List<VirtualModelField>)metadata.AdditionalValues[ModelFieldAttribute.KEY] : null;
                if (virtualFieldsAttr != null)
                {
                    foreach (VirtualModelField attr in virtualFieldsAttr)
                    {
                        var modelField = new ModelField();
                        if (storeModel != null)
                        {
                            attr.CopyTo(modelField, storeModel);
                            storeModel.Fields.Add(modelField);
                        }
                    }
                }

                var registrator = metadata.AdditionalValues.ContainsKey(ClientResourceAttribute.KEY) ? (ResourcesRegistrator)metadata.AdditionalValues[ClientResourceAttribute.KEY] : null;
                if (registrator != null)
                {
                    this.Controls.Add(registrator);
                }

                foreach (ModelMetadata propertyMetadata in metadata.Properties)
                {
                    var modelAttr = propertyMetadata.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY) ? (ModelFieldAttribute)propertyMetadata.AdditionalValues[ModelFieldAttribute.KEY] : null;
                    if (modelAttr == null && this.InitForModelOnly)
                    {
                        continue;
                    }

                    if (modelAttr != null && modelAttr.Ignore)
                    {
                        continue;
                    }

                    Store.CreateModelFieldFromMeta(propertyMetadata, storeModel, modelAttr, this.ControllerContext);
                }
            }
        }

        public static Type GetEnumerableGenericType(Type type)
        {
            if (type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                type = type.GetGenericArguments()[0];
            }
            else
            {
                foreach (Type intType in type.GetInterfaces())
                {
                    if (intType.IsGenericType
                        && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        type = intType.GetGenericArguments()[0];
                        break;
                    }
                }
            }
            return type;
        }

        public static ModelField CreateModelFieldFromMeta(ModelMetadata propertyMetadata, Ext.Net.Model storeModel = null, ModelFieldAttribute modelAttr = null, ControllerContext controllerContext = null)
        {
            var modelField = new ModelField();
            if (modelAttr == null)
            {
                modelAttr = propertyMetadata.AdditionalValues.ContainsKey(ModelFieldAttribute.KEY) ? (ModelFieldAttribute)propertyMetadata.AdditionalValues[ModelFieldAttribute.KEY] : null;
            }           

            modelField.Name = propertyMetadata.PropertyName;

            if (Store.IsDate(propertyMetadata.ModelType))
            {
                modelField.Type = ModelFieldType.Date;
            }
            else if (Store.IsInteger(propertyMetadata.ModelType))
            {
                modelField.Type = ModelFieldType.Int;
            }
            else if (Store.IsFloat(propertyMetadata.ModelType))
            {
                modelField.Type = ModelFieldType.Float;
            }
            else if (Store.IsBoolean(propertyMetadata.ModelType))
            {
                modelField.Type = ModelFieldType.Boolean;
            }
            else if (propertyMetadata.ModelType == typeof(string))
            {
                modelField.Type = ModelFieldType.String;
            }

            if (propertyMetadata.IsComplexType && modelAttr != null)
            {
                modelField.IsComplex = true;
            }

            if (modelAttr != null && storeModel != null)
            {
                modelAttr.CopyTo(modelField, storeModel);
            }

            if(storeModel != null)
            {
                storeModel.Fields.Add(modelField);
            }

            ValidationCollection validations = new ValidationCollection();
            if (propertyMetadata.AdditionalValues.ContainsKey(AbstractValidationAttribute.KEY))
            {
                validations = (ValidationCollection)propertyMetadata.AdditionalValues[AbstractValidationAttribute.KEY];                
            }

            foreach (ModelValidator v in propertyMetadata.GetValidators(controllerContext))
            {
                var rule = v.GetClientValidationRules().FirstOrDefault();

                if (rule != null)
                {
                    switch (rule.ValidationType)
                    {
                        case "required":
                            validations.Add(new PresenceValidation { Message = rule.ErrorMessage });
                            break;
                        case "regex":
                            if (rule.ValidationParameters.ContainsKey("pattern"))
                            {
                                validations.Add(new FormatValidation { Matcher = rule.ValidationParameters["pattern"].ToString(), Message = rule.ErrorMessage });
                            }
                            break;                        
                        case "length":
                            int num;
                            LengthValidation length = new LengthValidation();
                            length.Message = rule.ErrorMessage;
                            if (rule.ValidationParameters.ContainsKey("max"))
                            {
                                if (int.TryParse(rule.ValidationParameters["max"].ToString(), out num))
                                {
                                    length.Max = num;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (rule.ValidationParameters.ContainsKey("min"))
                            {
                                if (int.TryParse(rule.ValidationParameters["min"].ToString(), out num))
                                {
                                    length.Min = num;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            validations.Add(length);
                            break;
                    }
                }
            }

            if (controllerContext != null)
            {
                foreach (ModelValidator v in propertyMetadata.GetValidators(controllerContext))
                {
                    var rule = v.GetClientValidationRules().FirstOrDefault();

                    if (rule != null)
                    {
                        switch (rule.ValidationType)
                        {
                            case "required":
                                validations.Add(new PresenceValidation { Field = modelField.Name, Message = rule.ErrorMessage });
                                break;
                            case "regex":
                                if (rule.ValidationParameters.ContainsKey("pattern"))
                                {
                                    validations.Add(new FormatValidation { Field = modelField.Name, Matcher = rule.ValidationParameters["pattern"].ToString(), Message = rule.ErrorMessage });
                                }
                                break;
                            case "length":
                                var lengthVal = new LengthValidation();
                                if (rule.ValidationParameters.ContainsKey("max"))
                                {
                                    lengthVal.Max = (int)Convert.ChangeType(rule.ValidationParameters["max"], typeof(int));
                                }

                                if (rule.ValidationParameters.ContainsKey("min"))
                                {
                                    lengthVal.Min = (int)Convert.ChangeType(rule.ValidationParameters["min"], typeof(int));
                                }

                                lengthVal.Message = rule.ErrorMessage;
                                validations.Add(lengthVal);
                                break;
                        }
                    }
                }
            }

            if (validations.Count > 0)
            {
                if (storeModel != null)
                {
                    storeModel.Validations.AddRange(validations);
                }
                else
                {
                    modelField.Validations = validations;
                }
            }

            return modelField;
        }

        public static bool IsNumeric(Type t)
        {
            var code = Type.GetTypeCode(Store.GetTypeWithoutNullability(t));

            return code == TypeCode.Byte
                || code == TypeCode.Decimal
                || code == TypeCode.Double
                || code == TypeCode.Int16
                || code == TypeCode.Int32
                || code == TypeCode.Int64
                || code == TypeCode.SByte
                || code == TypeCode.Single
                || code == TypeCode.UInt16
                || code == TypeCode.UInt32
                || code == TypeCode.UInt64;
        }

        public static bool IsInteger(Type t)
        {
            var code = Type.GetTypeCode(Store.GetTypeWithoutNullability(t));

            return code == TypeCode.Byte
                || code == TypeCode.Int16
                || code == TypeCode.Int32
                || code == TypeCode.Int64
                || code == TypeCode.SByte
                || code == TypeCode.UInt16
                || code == TypeCode.UInt32
                || code == TypeCode.UInt64;
        }

        public static bool IsFloat(Type t)
        {
            var code = Type.GetTypeCode(Store.GetTypeWithoutNullability(t));

            return code == TypeCode.Decimal
                || code == TypeCode.Double
                || code == TypeCode.Single;
        }

        public static bool IsDate(Type t)
        {
            var code = Type.GetTypeCode(Store.GetTypeWithoutNullability(t));
            return code == TypeCode.DateTime;
        }

        public static bool IsBoolean(Type t)
        {
            var code = Type.GetTypeCode(Store.GetTypeWithoutNullability(t));
            return code == TypeCode.Boolean;
        }

        public static Type GetTypeWithoutNullability(Type t)
        {
            return Store.IsNullable(t) ? new NullableConverter(t).UnderlyingType : t;
        }

        public static bool IsNullable(Type t)
        {
            return t.IsGenericType &&
                   t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}