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

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// This is a layout that inherits the anchoring of Ext.layout.container.Anchor and adds the ability for x/y positioning using the standard x and y component config options.
    /// This class is intended to be extended or created via the layout configuration property. See Ext.container.Container.layout for additional details.
    /// </summary>
    public partial class AbsoluteLayoutConfig : AnchorLayoutConfig
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AbsoluteLayoutConfig() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "absolute";
            }
        }

        /// <summary>
        /// True indicates that changes to one item in this layout do not effect the layout in general. This may need to be set to false if Ext.AbstractComponent.autoScroll is enabled for the container. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True indicates that changes to one item in this layout do not effect the layout in general. This may need to be set to false if Ext.AbstractComponent.autoScroll is enabled for the container. Defaults to: true")]
        public virtual bool IgnoreOnContentChange
        {
            get
            {
                return this.State.Get<bool>("IgnoreOnContentChange", true);
            }
            set
            {
                this.State.Set("IgnoreOnContentChange", value);
            }
        }
    }
}
