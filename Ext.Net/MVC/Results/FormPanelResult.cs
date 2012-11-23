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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormPanelResult : ActionResult, IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        public FormPanelResult() { }

        public FormPanelResult(ModelStateDictionary modelState) 
        {
            this.Success = modelState.IsValid;

            foreach (var state in modelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    if (state.Key.IsEmpty())
                    {
                        this.ErrorMessage = state.Value.Errors[0].ErrorMessage;
                    }                    
                    else if (state.Value.Errors.Count > 1)
                    {
                        this.Errors.Add(new FieldError(state.Key, state.Value.Errors.Select(e => e.ErrorMessage).ToArray()));
                    }
                    else
                    {
                        this.Errors.Add(new FieldError(state.Key, state.Value.Errors[0].ErrorMessage));
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        public string Script 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUpload 
        { 
            get; 
            set; 
        }

        private bool success = true;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        public bool Success
        {
            get 
            { 
                return this.success; 
            }
            set 
            { 
                this.success = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        public string ErrorMessage
        {
            get;
            set;
        }

        private List<FieldError> errors;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        public List<FieldError> Errors
        {
            get
            {
                if(this.errors == null)
                {
                    this.errors = new List<FieldError>();
                }

                return this.errors;
            }
        }

        private ParameterCollection extraParams;

        /// <summary>
        /// 
        /// </summary>
        public ParameterCollection ExtraParams
        {
            get
            {
                if (this.extraParams == null)
                {
                    this.extraParams = new ParameterCollection();
                }

                return this.extraParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("extraParams", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ExtraParamsProxy
        {
            get
            {
                if (this.ExtraParams.Count > 0)
                {
                   return ExtraParams.ToJson();
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (HttpContext.Current != null)
            {
                var instanceScript = HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT];
                if (instanceScript != null)
                {
                    this.Script = instanceScript.ToString() + (this.Script ?? "");
                }
            }

            if (!string.IsNullOrEmpty(this.Script))
            {
                this.Script = string.Concat("<string>", this.Script);
            }

            if (this.IsUpload)
            {
                context.HttpContext.Response.Write("<textarea>{0}</textarea>".FormatWith(new ClientConfig().Serialize(this)));
            }
            else
            {
                CompressionUtils.GZipAndSend(new ClientConfig().Serialize(this));
            }
        }

        #region IXObject

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("script", new ConfigOption("script", null, null, this.Script));                
                list.Add("success", new ConfigOption("success", null, null, this.Success));
                list.Add("errorMessage", new ConfigOption("errorMessage", null, null, this.ErrorMessage));
                list.Add("errors", new ConfigOption("errors", new SerializationOptions(JsonMode.AlwaysArray), null, this.Errors));
                list.Add("extraParamsProxy", new ConfigOption("extraParamsProxy", new SerializationOptions("extraParams", JsonMode.Raw), "", this.ExtraParamsProxy));

                return list;
            }
        }

        public ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get 
            {
                return Ext.Net.ConfigOptionsExtraction.List;
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class FieldError: IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldID"></param>
        /// <param name="errorMessage"></param>
        public FieldError(string fieldID, string errorMessage)
        {
            if(string.IsNullOrEmpty(fieldID))
            {
                throw new ArgumentNullException("fieldID", "Field ID can not be empty");
            }

            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException("errorMessage", "Error message can not be empty");
            }

            this.FieldID = fieldID;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldID"></param>
        /// <param name="errorMessage"></param>
        public FieldError(string fieldID, string[] errorMessages)
        {
            if (string.IsNullOrEmpty(fieldID))
            {
                throw new ArgumentNullException("fieldID", "Field ID can not be empty");
            }

            if (errorMessages == null)
            {
                throw new ArgumentNullException("errorMessage", "Error messages can not be null");
            }

            this.FieldID = fieldID;
            this.ErrorMessages = errorMessages;
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("id")]
        [DefaultValue("")]
        public string FieldID 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("msg")]
        [DefaultValue("")]
        public string ErrorMessage 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("msg", JsonMode.AlwaysArray)]
        [DefaultValue(null)]
        public string[] ErrorMessages
        {
            get;
            set;
        }

        #region Члены IXObject

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("fieldID", new ConfigOption("fieldID", new SerializationOptions("id"), "", this.FieldID));
                list.Add("errorMessage", new ConfigOption("errorMessage", new SerializationOptions("msg"), "", this.ErrorMessage));
                list.Add("errorMessages", new ConfigOption("errorMessages", new SerializationOptions("msg", JsonMode.AlwaysArray), null, this.ErrorMessages));

                return list;
            }
        }

        public ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get 
            {
                return Ext.Net.ConfigOptionsExtraction.List;
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class FieldErrors : Collection<FieldError> { }
}
