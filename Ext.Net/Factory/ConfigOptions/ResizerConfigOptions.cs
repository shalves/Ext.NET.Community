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
    public partial class Resizer
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
                
                list.Add("constrainToElement", new ConfigOption("constrainToElement", new SerializationOptions("constrainTo"), "", this.ConstrainToElement ));
                list.Add("constrainToRegionProxy", new ConfigOption("constrainToRegionProxy", new SerializationOptions("constrainTo", JsonMode.Raw), null, this.ConstrainToRegionProxy ));
                list.Add("dynamic", new ConfigOption("dynamic", null, null, this.Dynamic ));
                list.Add("handlesSummary", new ConfigOption("handlesSummary", new SerializationOptions("handles"), "", this.HandlesSummary ));
                list.Add("handlesProxy", new ConfigOption("handlesProxy", new SerializationOptions("handles"), "", this.HandlesProxy ));
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));
                list.Add("heightIncrement", new ConfigOption("heightIncrement", null, 0, this.HeightIncrement ));
                list.Add("maxHeight", new ConfigOption("maxHeight", null, 10000, this.MaxHeight ));
                list.Add("maxWidth", new ConfigOption("maxWidth", null, 10000, this.MaxWidth ));
                list.Add("minHeight", new ConfigOption("minHeight", null, 20, this.MinHeight ));
                list.Add("minWidth", new ConfigOption("minWidth", null, 20, this.MinWidth ));
                list.Add("pinned", new ConfigOption("pinned", null, false, this.Pinned ));
                list.Add("preserveRatio", new ConfigOption("preserveRatio", null, false, this.PreserveRatio ));
                list.Add("targetProxy", new ConfigOption("targetProxy", new SerializationOptions("target", JsonMode.Raw), "", this.TargetProxy ));
                list.Add("transparent", new ConfigOption("transparent", null, false, this.Transparent ));
                list.Add("width", new ConfigOption("width", null, Unit.Empty, this.Width ));
                list.Add("widthIncrement", new ConfigOption("widthIncrement", new SerializationOptions(JsonMode.Raw), 0, this.WidthIncrement ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}