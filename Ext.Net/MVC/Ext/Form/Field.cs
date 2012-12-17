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
using System.ComponentModel;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ext.Net.Utilities;
using Ext.Net.MVC;
using System.Text.RegularExpressions;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class Field
    {
        protected override void OnMetadataProcess(ModelMetadata meta, string name, ViewDataDictionary viewData, ControllerContext context)
        {
            base.OnMetadataProcess(meta, name, viewData, context);

            if (name.IsEmpty())
            {
                throw new Exception("Name from ControlFor is empty");
            }

            this.Name = name;

            if (meta.IsReadOnly)
            {
                this.ReadOnly = true;
            }

            if (this.FieldLabel.IsEmpty())
            {
                this.FieldLabel = meta.GetDisplayName();
            }

            if (this.Note.IsEmpty() && meta.Description.IsNotEmpty())
            {
                this.Note = meta.Description;
            }

            ModelState modelState;
            if (viewData.ModelState.TryGetValue(name, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    this.CustomConfig.Add(new ConfigItem("activeError", JSON.Serialize(modelState.Errors.Select(e => e.ErrorMessage)), ParameterMode.Raw));
                }
            }
        }

        private static Regex vtypeRuleRe = new Regex("^vtype\\[(.+)\\]$", RegexOptions.Compiled);
        private static Regex validatorRuleRe = new Regex("^validator\\[(.+)\\]$", RegexOptions.Compiled);

        protected override void SetModelValidationRule(ModelClientValidationRule rule)
        {
            base.SetModelValidationRule(rule);

            Match match = Field.vtypeRuleRe.Match(rule.ValidationType ?? "");
            
            if (match.Success)
            {
                this.Vtype = match.Groups[1].Value;
                this.VtypeText = rule.ErrorMessage;
                if(rule.ValidationParameters.Count > 0)
                {
                    this.VTypeParams.AddRange(rule.ValidationParameters.Select(pair=>new Parameter(pair.Key, JSON.Serialize(pair.Value), ParameterMode.Raw)));
                }
            }
            else
            {
                match = Field.validatorRuleRe.Match(rule.ValidationType ?? "");
                if (match.Success)
                {
                    this.Validator.Fn = match.Groups[1].Value;
                    this.ValidatorText = rule.ErrorMessage;
                    if (rule.ValidationParameters.Count > 0)
                    {
                        this.VTypeParams.AddRange(rule.ValidationParameters.Select(pair => new Parameter(pair.Key, JSON.Serialize(pair.Value), ParameterMode.Raw)));
                    }

                    return;
                }

                switch (rule.ValidationType)
                {
                    case "remote":
                        this.IsRemoteValidation = true;
                        RemoteValidationDirectEvent evt = this.RemoteValidation;
                        evt.ErrorMessage = rule.ErrorMessage;
                    
                        if (rule.ValidationParameters.ContainsKey("url"))
                        {
                            evt.Url = rule.ValidationParameters["url"].ToString();
                        }

                        if (rule.ValidationParameters.ContainsKey("type"))
                        {
                            evt.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), rule.ValidationParameters["type"].ToString(), true);
                        }

                        if (rule.ValidationParameters.ContainsKey("additionalfields"))
                        {
                            string fields = rule.ValidationParameters["additionalfields"].ToString();
                        
                            foreach (string field in fields.Split(','))
                            {
                                string fieldName = field;

                                if (fieldName.StartsWith("*."))
                                {
                                    fieldName = fieldName.Substring(2);
                                }

                                evt.ExtraParams.Add(new Parameter(fieldName, "function(){return Ext.net.findField("+JSON.Serialize(fieldName)+",this).getValue();}", ParameterMode.Raw));
                            }
                        }
                        break;
                }
            }
        }

        protected override void SetModelValue(object value)
        {
            base.SetModelValue(value);
            this.Value = value;
        }

        protected override void SetModelAdditionalValue(KeyValuePair<string, object> value)
        {
            if (value.Key == FieldAttribute.KEY)
            {
                ((FieldAttribute)value.Value).CopyTo(this);
            }
            else
            {
                base.SetModelAdditionalValue(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [Description("")]
        public override bool IDFromControlFor
        {
            get
            {
                return this.State.Get<bool>("IDFromControlFor", true);
            }
            set
            {
                this.State.Set("IDFromControlFor", value);
            }
        }
    }
}