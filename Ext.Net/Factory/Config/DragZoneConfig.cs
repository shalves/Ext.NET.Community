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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public partial class DragZone
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DragZone(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DragZone.Config Conversion to DragZone
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DragZone(DragZone.Config config)
        {
            return new DragZone(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DragSource.Config 
        { 
			/*  Implicit DragZone.Config Conversion to DragZone.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DragZone.Builder(DragZone.Config config)
			{
				return new DragZone.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool containerScroll = false;

			/// <summary>
			/// True to register this container with the Scrollmanager for auto scrolling during drag operations.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ContainerScroll 
			{ 
				get
				{
					return this.containerScroll;
				}
				set
				{
					this.containerScroll = value;
				}
			}
        
			private JFunction afterRepair = null;

			/// <summary>
			/// Called after a repair of an invalid drop. By default, highlights this.dragData.ddel
			/// </summary>
			public JFunction AfterRepair
			{
				get
				{
					if (this.afterRepair == null)
					{
						this.afterRepair = new JFunction();
					}
			
					return this.afterRepair;
				}
			}
			        
			private JFunction getRepairXY = null;

			/// <summary>
			/// Called before a repair of an invalid drop to get the XY to animate to. By default returns the XY of this.dragData.ddel
			/// </summary>
			public JFunction GetRepairXY
			{
				get
				{
					if (this.getRepairXY == null)
					{
						this.getRepairXY = new JFunction();
					}
			
					return this.getRepairXY;
				}
			}
			        
			private JFunction onInitDrag = null;

			/// <summary>
			/// Called once drag threshold has been reached to initialize the proxy element. By default, it clones the this.dragData.ddel
			/// </summary>
			public JFunction OnInitDrag
			{
				get
				{
					if (this.onInitDrag == null)
					{
						this.onInitDrag = new JFunction();
					}
			
					return this.onInitDrag;
				}
			}
			
        }
    }
}