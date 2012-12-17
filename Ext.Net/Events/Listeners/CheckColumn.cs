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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CheckColumnListeners : ColumnListeners
    {
        private ComponentListener beforeCheckChange;

        /// <summary>
        /// Fires when before checked state of a row changes.
        /// The change may be vetoed by returning `false` from a listener.
        /// Parameters:
        ///     - item
        ///     - rowIndex
        ///         The row index
        ///     - record
        ///         The record
        ///     - checked
        ///         True if the box is checked
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "record")]
        [ListenerArgument(3, "checked")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecheckchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when before checked state of a row changes. The change may be vetoed by returning `false` from a listener.")]
        public virtual ComponentListener BeforeCheckChange
        {
            get
            {
                return this.beforeCheckChange ?? (this.beforeCheckChange = new ComponentListener());
            }
        }

        private ComponentListener checkChange;

        /// <summary>
        /// Fires when the checked state of a row changes.
        /// Parameters:
        ///     - item
        ///     - rowIndex
        ///         The row index
        ///     - record
        ///         The record
        ///     - checked
        ///         True if the box is checked
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "record")]
        [ListenerArgument(3, "checked")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("checkchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the checked state of a row changes.")]
        public virtual ComponentListener CheckChange
        {
            get
            {
                return this.checkChange ?? (this.checkChange = new ComponentListener());
            }
        }
    }
}
