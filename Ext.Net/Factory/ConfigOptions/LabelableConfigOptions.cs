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
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Labelable
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("activeError", new ConfigOption("activeError", null, null, this.ActiveError ));
                list.Add("activeErrorsTpl", new ConfigOption("activeErrorsTpl", new SerializationOptions("activeErrorsTpl"), null, this.ActiveErrorsTpl ));
                list.Add("autoFitErrors", new ConfigOption("autoFitErrors", null, true, this.AutoFitErrors ));
                list.Add("baseBodyCls", new ConfigOption("baseBodyCls", null, "x-form-item-body", this.BaseBodyCls ));
                list.Add("clearCls", new ConfigOption("clearCls", null, "x-clear", this.ClearCls ));
                list.Add("dirtyCls", new ConfigOption("dirtyCls", null, "x-form-dirty", this.DirtyCls ));
                list.Add("errorMsgCls", new ConfigOption("errorMsgCls", null, "x-form-error-msg", this.ErrorMsgCls ));
                list.Add("fieldBodyCls", new ConfigOption("fieldBodyCls", null, "", this.FieldBodyCls ));
                list.Add("fieldLabel", new ConfigOption("fieldLabel", null, "", this.FieldLabel ));
                list.Add("focusCls", new ConfigOption("focusCls", null, "x-form-focus", this.FocusCls ));
                list.Add("formItemCls", new ConfigOption("formItemCls", null, "x-form-item", this.FormItemCls ));
                list.Add("hideEmptyLabel", new ConfigOption("hideEmptyLabel", null, true, this.HideEmptyLabel ));
                list.Add("hideLabel", new ConfigOption("hideLabel", null, false, this.HideLabel ));
                list.Add("inputWidth", new ConfigOption("inputWidth", null, 100, this.InputWidth ));
                list.Add("invalidCls", new ConfigOption("invalidCls", null, "x-form-invalid", this.InvalidCls ));
                list.Add("invalidText", new ConfigOption("invalidText", null, "", this.InvalidText ));
                list.Add("labelAlign", new ConfigOption("labelAlign", new SerializationOptions(JsonMode.ToLower), LabelAlign.Left, this.LabelAlign ));
                list.Add("labelCls", new ConfigOption("labelCls", new SerializationOptions("labelClsExtra"), "", this.LabelCls ));
                list.Add("labelPad", new ConfigOption("labelPad", null, 5, this.LabelPad ));
                list.Add("labelSeparator", new ConfigOption("labelSeparator", null, ":", this.LabelSeparator ));
                list.Add("labelStyle", new ConfigOption("labelStyle", null, "", this.LabelStyle ));
                list.Add("labelWidth", new ConfigOption("labelWidth", null, 100, this.LabelWidth ));
                list.Add("msgTarget", new ConfigOption("msgTarget", new SerializationOptions(JsonMode.ToLower), MessageTarget.Qtip, this.MsgTarget ));
                list.Add("msgTargetElement", new ConfigOption("msgTargetElement", new SerializationOptions("msgTarget"), "", this.MsgTargetElement ));
                list.Add("preventMark", new ConfigOption("preventMark", null, false, this.PreventMark ));
                list.Add("readOnly", new ConfigOption("readOnly", null, false, this.ReadOnly ));
                list.Add("readOnlyCls", new ConfigOption("readOnlyCls", null, "", this.ReadOnlyCls ));
                list.Add("submitValue", new ConfigOption("submitValue", null, true, this.SubmitValue ));
                list.Add("preserveIndicatorIcon", new ConfigOption("preserveIndicatorIcon", null, false, this.PreserveIndicatorIcon ));
                list.Add("allowBlank", new ConfigOption("allowBlank", null, true, this.AllowBlank ));
                list.Add("blankText", new ConfigOption("blankText", null, "", this.BlankText ));
                list.Add("disableKeyFilter", new ConfigOption("disableKeyFilter", null, false, this.DisableKeyFilter ));
                list.Add("emptyCls", new ConfigOption("emptyCls", null, "", this.EmptyCls ));
                list.Add("emptyText", new ConfigOption("emptyText", null, "", this.EmptyText ));
                list.Add("enableKeyEvents", new ConfigOption("enableKeyEvents", null, false, this.EnableKeyEvents ));
                list.Add("enforceMaxLength", new ConfigOption("enforceMaxLength", null, false, this.EnforceMaxLength ));
                list.Add("grow", new ConfigOption("grow", null, false, this.Grow ));
                list.Add("growAppend", new ConfigOption("growAppend", null, "W", this.GrowAppend ));
                list.Add("growMax", new ConfigOption("growMax", null, 800, this.GrowMax ));
                list.Add("growMin", new ConfigOption("growMin", null, 30, this.GrowMin ));
                list.Add("maskRe", new ConfigOption("maskRe", new SerializationOptions(typeof(RegexJsonConverter)), "", this.MaskRe ));
                list.Add("maxLength", new ConfigOption("maxLength", null, -1, this.MaxLength ));
                list.Add("maxLengthText", new ConfigOption("maxLengthText", null, "", this.MaxLengthText ));
                list.Add("minLength", new ConfigOption("minLength", null, 0, this.MinLength ));
                list.Add("minLengthText", new ConfigOption("minLengthText", null, "", this.MinLengthText ));
                list.Add("regex", new ConfigOption("regex", new SerializationOptions(typeof(RegexJsonConverter)), "", this.Regex ));
                list.Add("regexText", new ConfigOption("regexText", null, "", this.RegexText ));
                list.Add("selectOnFocus", new ConfigOption("selectOnFocus", null, false, this.SelectOnFocus ));
                list.Add("size", new ConfigOption("size", null, 20, this.Size ));
                list.Add("stripCharsRe", new ConfigOption("stripCharsRe", new SerializationOptions(typeof(RegexJsonConverter)), "", this.StripCharsRe ));
                list.Add("validator", new ConfigOption("validator", new SerializationOptions(JsonMode.Raw), null, this.Validator ));
                list.Add("standardVtype", new ConfigOption("standardVtype", new SerializationOptions("vtype", JsonMode.ToLower), ValidationType.None, this.StandardVtype ));
                list.Add("vtype", new ConfigOption("vtype", null, "", this.Vtype ));
                list.Add("vtypeText", new ConfigOption("vtypeText", null, "", this.VtypeText ));

                return list;
            }
        }
    }
}