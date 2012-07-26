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
 * @version   : 2.0.0 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class GroupingSummary
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Grouping.Builder<GroupingSummary, GroupingSummary.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GroupingSummary()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GroupingSummary component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GroupingSummary.Config config) : base(new GroupingSummary(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GroupingSummary component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
            public virtual GroupingSummary.Builder ShowSummaryRow(bool showSummaryRow)
            {
                this.ToComponent().ShowSummaryRow = showSummaryRow;
                return this as GroupingSummary.Builder;
            }
             
 			/// <summary>
			/// The name of the property which contains the Array of summary objects. Defaults to undefined. It allows to use server-side calculated summaries.
			/// </summary>
            public virtual GroupingSummary.Builder RemoteRoot(string remoteRoot)
            {
                this.ToComponent().RemoteRoot = remoteRoot;
                return this as GroupingSummary.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupingSummary.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GroupingSummary(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GroupingSummary.Builder GroupingSummary()
        {
            return this.GroupingSummary(new GroupingSummary());
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupingSummary.Builder GroupingSummary(GroupingSummary component)
        {
            return new GroupingSummary.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupingSummary.Builder GroupingSummary(GroupingSummary.Config config)
        {
            return new GroupingSummary.Builder(new GroupingSummary(config));
        }
    }
}