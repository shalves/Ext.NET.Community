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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// This is a utility class that can be passed into a Ext.grid.column.Column as a column config that provides an automatic row numbering column.
    /// </summary>
    [Meta]
    [Description("")]
    public partial class RowNumbererColumn : ColumnBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RowNumbererColumn() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XType
        {
            get
            {
                return "rownumberer";
            }
        }

        /// <summary>
        /// True to enable drag-drop reordering of this column.
        /// </summary>
        [DefaultValue(false)]
        [Description("True to enable drag-drop reordering of this column.")]
        public override bool Draggable
        {
            get
            {
                return this.State.Get<bool>("Draggable", false);
            }
            set
            {
                this.State.Set("Draggable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption("draggable")]
        protected override bool DraggableProxy
        {
            get
            {
                return !this.Draggable && this.DraggableConfig == null ? false : true;
            }
        }

        /// <summary>
        /// The default width in pixels of the row number column. Defaults to: 23
        /// </summary>
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(typeof(Unit), "23")]
        [Description("The default width in pixels of the row number column. Defaults to: 23")]
        public override Unit Width
        {
            get
            {
                return this.State.Get<Unit>("Width", Unit.Pixel(23));
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// RowSpan attribute for the checkbox table cell
        /// </summary>
        [Meta]
        [ConfigOption("rowspan")]
        [Category("Config Options")]
        [DefaultValue(1)]
        [Description("RowSpan attribute for the checkbox table cell")]
        public override int RowSpan
        {
            get
            {
                return this.State.Get<int>("RowSpan", 1);
            }
            set
            {
                this.State.Set("RowSpan", value);
            }
        }
    }
}
