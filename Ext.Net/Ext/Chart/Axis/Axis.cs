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

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Defines axis for charts. The axis position, type, style can be configured. The axes are defined in an axes array of configuration objects where the type, field, grid and other configuration options can be set. 
    /// </summary>
    [Meta]
    public abstract partial class Axis : AbstractAxis
    {
        /// <summary>
        /// Whether to adjust the label at the end of the axis. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Whether to adjust the label at the end of the axis. Defaults to: true")]
        public virtual bool AdjustEnd
        {
            get
            {
                return this.State.Get<bool>("AdjustEnd", true);
            }
            set
            {
                this.State.Set("AdjustEnd", value);
            }
        }
        
        /// <summary>
        /// The size of the dash marker. Default's 3.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(3)]
        [Description("The size of the dash marker. Default's 3.")]
        public virtual int DashSize
        {
            get
            {
                return this.State.Get<int>("DashSize", 3);
            }
            set
            {
                this.State.Set("DashSize", value);
            }
        }

        /// <summary>
        /// The grid configuration enables you to set a background grid for an axis. If set to true on a vertical axis, vertical lines will be drawn. If set to true on a horizontal axis, horizontal lines will be drawn. If both are set, a proper grid with horizontal and vertical lines will be drawn.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("The grid configuration enables you to set a background grid for an axis. If set to true on a vertical axis, vertical lines will be drawn. If set to true on a horizontal axis, horizontal lines will be drawn. If both are set, a proper grid with horizontal and vertical lines will be drawn.")]
        public virtual bool Grid
        {
            get
            {
                if (this.GridConfig != null)
                {
                    return false;
                }
                return this.State.Get<bool>("Grid", false);
            }
            set
            {
                this.State.Set("Grid", value);
            }
        }

        private AxisGrid gridConfig;

        /// <summary>
        /// The grid configuration enables you to set a background grid for an axis. If set to true on a vertical axis, vertical lines will be drawn. If set to true on a horizontal axis, horizontal lines will be drawn. If both are set, a proper grid with horizontal and vertical lines will be drawn.
        /// You can set specific options for the grid configuration for odd and/or even lines/rows. Since the rows being drawn are rectangle sprites, you can set to an odd or even property all styles that apply to Ext.draw.Sprite. For more information on all the style properties you can set please take a look at Ext.draw.Sprite. Some useful style properties are opacity, fill, stroke, stroke-width, etc.
        /// The possible values for a grid option are then true, false, or an object with { odd, even } properties where each property contains a sprite style descriptor object that is defined in Ext.draw.Sprite.
        /// </summary>
        [Meta]
        [ConfigOption("grid", JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public AxisGrid GridConfig
        {
            get
            {
                return this.gridConfig;
            }
            set
            {
                this.gridConfig = value;
            }
        }

        /// <summary>
        /// Offset axis position. Default's 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Offset axis position. Default's 0.")]
        public virtual int Length
        {
            get
            {
                return this.State.Get<int>("Length", 0);
            }
            set
            {
                this.State.Set("Length", value);
            }
        }

        /// <summary>
        /// If minimum and maximum are specified it forces the number of major ticks to the specified value.  If a number of major ticks is forced, it wont search for pretty numbers at the ticks.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(int.MinValue)]
        [Description("If minimum and maximum are specified it forces the number of major ticks to the specified value.")]
        public virtual int MajorTickSteps
        {
            get
            {
                return this.State.Get<int>("MajorTickSteps", int.MinValue);
            }
            set
            {
                this.State.Set("MajorTickSteps", value);
            }
        }

        /// <summary>
        /// The number of small ticks between two major ticks. Default is zero.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("The number of small ticks between two major ticks. Default is zero.")]
        public virtual int MinorTickSteps
        {
            get
            {
                return this.State.Get<int>("MinorTickSteps", 0);
            }
            set
            {
                this.State.Set("MinorTickSteps", value);
            }
        }

        /// <summary>
        /// Where to set the axis. Available options are left, bottom, right, top. Default's bottom.
        /// </summary>
        [Meta]
        [DefaultValue(Position.Bottom)]
        [Description("Where to set the axis. Available options are left, bottom, right, top. Default's bottom.")]
        public virtual Position Position
        {
            get
            {
                return this.State.Get<Position>("Position", Position.Bottom);
            }
            set
            {
                this.State.Set("Position", value);
            }
        }

        [ConfigOption("position")]
        protected virtual string PositionProxy
        {
            get
            {
                return this.Position.ToString().ToLowerInvariant();
            }
        }

        /// <summary>
        /// The title for the Axis
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The title for the Axis")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", "");
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        /// <summary>
        /// Offset axis width. Default's 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Offset axis width. Default's 0.")]
        public virtual int Width
        {
            get
            {
                return this.State.Get<int>("Width", 0);
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// The fields of model to bind to this axis.
        /// For example if you have a data set of lap times per car, each having the fields: 'carName', 'agvSpeed', 'maxSpeed'. Then you might want to show the data on chart with ['carName'] on Name axis and ['avgSpeed', 'maxSpeed'] on Speed axis.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]        
        [DefaultValue(null)]
        [Description("The fields of model to bind to this axis.")]
        public virtual string[] Fields
        {
            get
            {
                return this.State.Get<string[]>("Fields", null);
            }
            set
            {
                this.State.Set("Fields", value);
            }
        }

        /// <summary>
        /// Updates the title of this axis.
        /// </summary>
        /// <param name="title"></param>
        public virtual void SetTitle(string title)
        {
            var chart = this.Chart;
            var index = chart.Axes.IndexOf(this);
            chart.AddScript("{0}.axes.get({1}).setTitle({2});", chart.ClientID, index, JSON.Serialize(title));
        }
    }
}
