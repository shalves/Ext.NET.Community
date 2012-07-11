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
 * @version   : 2.0.0.rc2 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System.ComponentModel;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
    /// This is a base class for layouts that contain a single item that automatically expands to fill the layout's container. This class is intended to be extended or created via the layout:'fit' Ext.container.Container.layout config, and should generally not need to be created directly via the new keyword.
    /// Fit layout does not have any direct config options (other than inherited ones). To fit a panel to a container using Fit layout, simply set layout: 'fit' on the container and add a single panel to it.
    /// If the container has multiple items, all of the items will all be equally sized. This is usually not desired, so to avoid this, place only a single item in the container. This sizing of all items can be used to provide a background image that is "behind" another item such as a dataview if you also absolutely position the items.
	/// </summary>
	[Description("")]
    public partial class CheckboxGroupLayoutConfig : LayoutConfig
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "checkboxgroup";
            }
        }

        /// <summary>
        /// By default, CheckboxGroup allocates all available space to the configured columns meaning that column are evenly spaced across the container.
        /// To have each column only be wide enough to fit the container Checkboxes (or Radios), set autoFlex to false. Defaults to: true
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        public virtual bool AutoFlex
        {
            get
            {
                return this.State.Get<bool>("AutoFlex", true);
            }
            set
            {
                this.State.Set("AutoFlex", value);
            }
        }
    }
}