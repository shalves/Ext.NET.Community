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
 * @version   : 2.0.0.rc1 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// A layout that arranges items horizontally across a Container. This layout optionally divides available horizontal space between child items containing a numeric flex configuration.
    /// This layout may also be used to set the heights of child items by configuring it with the align option.
	/// </summary>
	[Description("")]
    public partial class HBoxLayoutConfig : BoxLayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public HBoxLayoutConfig() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "hbox";
            }
        }

        /// <summary>
        /// Controls how the child items of the container are aligned. Acceptable configuration values for this property are:
        ///     top : Default child items are aligned vertically at the top of the container
        ///     middle : child items are aligned vertically in the middle of the container
        ///     stretch : child items are stretched vertically to fill the height of the container
        ///     stretchmax : child items are stretched vertically to the height of the largest item.
        /// Defaults to: "top"
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(HBoxAlign.Top)]
        public HBoxAlign Align
        {
            get
            {
                return this.State.Get<HBoxAlign>("Align", HBoxAlign.Top);
            }
            set
            {
                this.State.Set("Align", value);
            }
        }
    }
}