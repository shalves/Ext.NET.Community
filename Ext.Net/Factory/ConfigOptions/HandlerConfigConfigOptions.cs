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
    public partial class HandlerConfig
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
                
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), null, this.Scope ));
                list.Add("delegate", new ConfigOption("delegate", null, null, this.Delegate ));
                list.Add("stopEvent", new ConfigOption("stopEvent", null, false, this.StopEvent ));
                list.Add("preventDefault", new ConfigOption("preventDefault", null, false, this.PreventDefault ));
                list.Add("stopPropagation", new ConfigOption("stopPropagation", null, false, this.StopPropagation ));
                list.Add("normalized", new ConfigOption("normalized", null, false, this.Normalized ));
                list.Add("delay", new ConfigOption("delay", null, 0, this.Delay ));
                list.Add("single", new ConfigOption("single", null, false, this.Single ));
                list.Add("buffer", new ConfigOption("buffer", null, 0, this.Buffer ));
                list.Add("targetID", new ConfigOption("targetID", null, null, this.TargetID ));
                list.Add("element", new ConfigOption("element", null, null, this.Element ));
                list.Add("targetProxy", new ConfigOption("targetProxy", new SerializationOptions("taget"), "", this.TargetProxy ));

                return list;
            }
        }
    }
}