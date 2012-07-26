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
    public partial class Grouping
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridFeature.Builder<Grouping, Grouping.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Grouping()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Grouping component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Grouping.Config config) : base(new Grouping(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Grouping component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
            public virtual Grouping.Builder DepthToIndent(int depthToIndent)
            {
                this.ToComponent().DepthToIndent = depthToIndent;
                return this as Grouping.Builder;
            }
             
 			/// <summary>
			/// True to enable the grouping control in the header menu (defaults to true)
			/// </summary>
            public virtual Grouping.Builder EnableGroupingMenu(bool enableGroupingMenu)
            {
                this.ToComponent().EnableGroupingMenu = enableGroupingMenu;
                return this as Grouping.Builder;
            }
             
 			/// <summary>
			/// True to allow the user to turn off grouping (defaults to true)
			/// </summary>
            public virtual Grouping.Builder EnableNoGroups(bool enableNoGroups)
            {
                this.ToComponent().EnableNoGroups = enableNoGroups;
                return this as Grouping.Builder;
            }
             
 			/// <summary>
			/// Text displayed in the grid header menu for grouping by header (defaults to 'Group By This Field').
			/// </summary>
            public virtual Grouping.Builder GroupByText(string groupByText)
            {
                this.ToComponent().GroupByText = groupByText;
                return this as Grouping.Builder;
            }
             
 			/// <summary>
			/// A string Template snippet, an array of strings (optionally followed by an object containing Template methods) to be used to construct a Template, or a Template instance. Defaults to: \"{columnName}: {name}\"
			/// </summary>
            public virtual Grouping.Builder GroupHeaderTplString(string groupHeaderTplString)
            {
                this.ToComponent().GroupHeaderTplString = groupHeaderTplString;
                return this as Grouping.Builder;
            }
             
 			/// <summary>
			/// True to hide the header that is currently grouped (defaults to false)
			/// </summary>
            public virtual Grouping.Builder HideGroupedHeader(bool hideGroupedHeader)
            {
                this.ToComponent().HideGroupedHeader = hideGroupedHeader;
                return this as Grouping.Builder;
            }
             
 			/// <summary>
			/// Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').
			/// </summary>
            public virtual Grouping.Builder ShowGroupsText(string showGroupsText)
            {
                this.ToComponent().ShowGroupsText = showGroupsText;
                return this as Grouping.Builder;
            }
             
 			/// <summary>
			/// True to start all groups collapsed (defaults to false)
			/// </summary>
            public virtual Grouping.Builder StartCollapsed(bool startCollapsed)
            {
                this.ToComponent().StartCollapsed = startCollapsed;
                return this as Grouping.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Grouping.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Grouping(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Grouping.Builder Grouping()
        {
            return this.Grouping(new Grouping());
        }

        /// <summary>
        /// 
        /// </summary>
        public Grouping.Builder Grouping(Grouping component)
        {
            return new Grouping.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Grouping.Builder Grouping(Grouping.Config config)
        {
            return new Grouping.Builder(new Grouping(config));
        }
    }
}