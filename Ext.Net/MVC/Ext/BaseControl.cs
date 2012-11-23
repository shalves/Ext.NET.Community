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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual bool IsMVC
        {
            get
            {
                return Ext.Net.MVC.MvcResourceManager.IsMVC || this.Page is System.Web.Mvc.ViewPage;
            }
        }

        private System.Web.Mvc.ViewContext viewContext;
        public System.Web.Mvc.ViewContext ViewContext
        {
            get
            {
                if (this.viewContext == null)
                {
                    if (this.Page is System.Web.Mvc.ViewPage)
                    {
                        this.viewContext = ((System.Web.Mvc.ViewPage)this.Page).ViewContext;
                    }
                    else
                    {
                        BaseControl control = this.ParentWebControl;

                        if (control != null)
                        {
                            this.viewContext = control.ViewContext;
                        }
                    }
                }

                return this.viewContext;
            }
            set
            {
                this.viewContext = value;
            }
        }

        private System.Web.Mvc.ControllerBase controller;
        public System.Web.Mvc.ControllerBase Controller
        {
            get
            {
                if (this.controller == null)
                {
                    if (this.Page is System.Web.Mvc.ViewPage)
                    {
                        this.controller = ((System.Web.Mvc.ViewPage)this.Page).ViewContext.Controller;
                    }

                    BaseControl control = this.ParentWebControl;

                    if (control != null)
                    {
                        this.controller = control.Controller;
                    }
                }

                return this.controller;
            }
            set
            {
                this.controller = value;
            }
        }

        public virtual ViewDataDictionary ViewData
        {
            get
            {
                if (this.Page is System.Web.Mvc.ViewPage)
                {
                    return ((System.Web.Mvc.ViewPage)this.Page).ViewData;
                }
                else
                {
                    if (this.ViewContext != null)
                    {
                        return this.ViewContext.ViewData;
                    }

                    if (this.Controller != null)
                    {
                        return this.Controller.ViewData;
                    }

                    return null;
                }
            }
        }

        public virtual ControllerContext ControllerContext
        {
            get
            {
                if (this.Page is System.Web.Mvc.ViewPage)
                {
                    return ((System.Web.Mvc.ViewPage)this.Page).ViewContext.Controller.ControllerContext;
                }
                else
                {
                    if (this.ViewContext != null)
                    {
                        return this.ViewContext.Controller.ControllerContext;
                    }

                    if (this.Controller != null)
                    {
                        return this.Controller.ControllerContext;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Description("")]
        public virtual string ControlFor
        {
            get
            {
                return this.State.Get<string>("ControlFor", null);
            }
            set
            {
                this.State.Set("ControlFor", value);
                if (this.onMvcInit)
                {
                    this.SetControlFor(null);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool IDFromControlFor
        {
            get
            {
                return this.State.Get<bool>("IDFromControlFor", false);
            }
            set
            {
                this.State.Set("IDFromControlFor", value);
            }
        }

        private bool onMvcInit = false;
        private bool setControlForOnInit = true;
        partial void OnMvcInit()
        {            
            if (this.ControlFor != null && this.setControlForOnInit)
            {
                this.SetControlFor(null);
            }
            this.onMvcInit = true;
        }

        [Meta]
        [DefaultValue(null)]
        public string FormatControlForValue
        {
            get;
            set;
        }

        [Meta]
        [DefaultValue(null)]
        public Func<object, object> ConvertControlForValue
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual void SetControlFor(ModelMetadata meta)
        {
            string controlFor = this.ControlFor;

            if (controlFor == null)
            {
                return;
            }

            ViewDataDictionary viewData = this.ViewData;
            ControllerContext controllerContext = this.ControllerContext;

            if (viewData == null || controllerContext == null)
            {
                return;
            }

            this.SuspendScripting();
            this.setControlForOnInit = false;

            string fullName = viewData.TemplateInfo.GetFullHtmlFieldName(controlFor);            

            ModelMetadata metadata = meta ?? ModelMetadata.FromStringExpression(controlFor, viewData);            

            this.OnMetadataProcess(metadata, fullName, viewData, controllerContext);
            
            object value = metadata.Model;
            
            if (this.ConvertControlForValue != null)
            {
                value = this.ConvertControlForValue(value);
            }
            
            this.SetModelValue(this.FormatControlForValue.IsEmpty() ? value : this.FormatValue(value, this.FormatControlForValue));
            
            if (this.IDFromControlFor)
            {
                this.ID = TagBuilder.CreateSanitizedId(fullName, System.Web.WebPages.Html.HtmlHelper.IdAttributeDotReplacement);
            }                        

            foreach (KeyValuePair<string, object> adValue in metadata.AdditionalValues)
            {
                this.SetModelAdditionalValue(adValue);   
            }

            foreach (ModelValidator v in metadata.GetValidators(controllerContext))
            {
                ModelClientValidationRule rule = v.GetClientValidationRules().FirstOrDefault();

                if (rule != null)
                {
                    this.SetModelValidationRule(rule);
                }
            }
            this.ResumeScripting();
        }

        protected virtual string FormatValue(object value, string format)
        {
            if (value == null)
            {
                return String.Empty;
            }

            if (String.IsNullOrEmpty(format))
            {
                return Convert.ToString(value, CultureInfo.CurrentCulture);
            }
            else
            {
                return String.Format(CultureInfo.CurrentCulture, format, value);
            }
        }

        protected virtual void OnMetadataProcess(ModelMetadata meta, string name, ViewDataDictionary viewData, ControllerContext context)
        {
            if (meta.EditFormatString.IsNotEmpty())
            {
                this.FormatControlForValue = meta.EditFormatString;
            }
            else if (meta.DisplayFormatString.IsNotEmpty())
            {
                this.FormatControlForValue = meta.DisplayFormatString;
            }
        }

        protected virtual void SetModelAdditionalValue(KeyValuePair<string, object> value)
        {
        }

        protected virtual void SetModelValidationRule(ModelClientValidationRule rule)
        {            
        }

        protected virtual void SetModelValue(object value)
        {
        }
    }
}