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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RatingColumn
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RatingColumn(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RatingColumn.Config Conversion to RatingColumn
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RatingColumn(RatingColumn.Config config)
        {
            return new RatingColumn(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ColumnBase.Config 
        { 
			/*  Implicit RatingColumn.Config Conversion to RatingColumn.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RatingColumn.Builder(RatingColumn.Config config)
			{
				return new RatingColumn.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string dataIndex = "rating";

			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.
			/// </summary>
			[DefaultValue("rating")]
			public override string DataIndex 
			{ 
				get
				{
					return this.dataIndex;
				}
				set
				{
					this.dataIndex = value;
				}
			}

			private bool editable = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Editable 
			{ 
				get
				{
					return this.editable;
				}
				set
				{
					this.editable = value;
				}
			}

			private bool allowChange = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowChange 
			{ 
				get
				{
					return this.allowChange;
				}
				set
				{
					this.allowChange = value;
				}
			}

			private string selectedCls = "rating-selected";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("rating-selected")]
			public virtual string SelectedCls 
			{ 
				get
				{
					return this.selectedCls;
				}
				set
				{
					this.selectedCls = value;
				}
			}

			private string unselectedCls = "rating-unselected";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("rating-unselected")]
			public virtual string UnselectedCls 
			{ 
				get
				{
					return this.unselectedCls;
				}
				set
				{
					this.unselectedCls = value;
				}
			}

			private int maxRating = 5;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(5)]
			public virtual int MaxRating 
			{ 
				get
				{
					return this.maxRating;
				}
				set
				{
					this.maxRating = value;
				}
			}

			private int tickSize = 16;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(16)]
			public virtual int TickSize 
			{ 
				get
				{
					return this.tickSize;
				}
				set
				{
					this.tickSize = value;
				}
			}

			private bool roundToTick = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RoundToTick 
			{ 
				get
				{
					return this.roundToTick;
				}
				set
				{
					this.roundToTick = value;
				}
			}

        }
    }
}