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
    public partial class BoxSplitter
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractComponent.Builder<BoxSplitter, BoxSplitter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BoxSplitter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BoxSplitter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BoxSplitter.Config config) : base(new BoxSplitter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BoxSplitter component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to enable dblclick to toggle expand and collapse on the collapseTarget Panel. Defaults to: true
			/// </summary>
            public virtual BoxSplitter.Builder CollapseOnDblClick(bool collapseOnDblClick)
            {
                this.ToComponent().CollapseOnDblClick = collapseOnDblClick;
                return this as BoxSplitter.Builder;
            }
             
 			/// <summary>
			/// A string describing the relative position of the immediate sibling Panel to collapse.
			/// </summary>
            public virtual BoxSplitter.Builder CollapseTarget(CollapseTarget collapseTarget)
            {
                this.ToComponent().CollapseTarget = collapseTarget;
                return this as BoxSplitter.Builder;
            }
             
 			/// <summary>
			/// A string describing the relative position of the immediate sibling Panel to collapse.
			/// </summary>
            public virtual BoxSplitter.Builder CollapseTargetPanel(string collapseTargetPanel)
            {
                this.ToComponent().CollapseTargetPanel = collapseTargetPanel;
                return this as BoxSplitter.Builder;
            }
             
 			/// <summary>
			/// A class to add to the splitter when it is collapsed. See collapsible.
			/// </summary>
            public virtual BoxSplitter.Builder CollapsedCls(string collapsedCls)
            {
                this.ToComponent().CollapsedCls = collapsedCls;
                return this as BoxSplitter.Builder;
            }
             
 			/// <summary>
			/// True to show a mini-collapse tool in the Splitter to toggle expand and collapse on the collapseTarget Panel. Defaults to the collapsible setting of the Panel. Defaults to: false
			/// </summary>
            public virtual BoxSplitter.Builder Collapsible(bool collapsible)
            {
                this.ToComponent().Collapsible = collapsible;
                return this as BoxSplitter.Builder;
            }
             
 			/// <summary>
			/// Provides a default maximum width or height for the two components that the splitter is between. Defaults to: 1000
			/// </summary>
            public virtual BoxSplitter.Builder DefaultSplitMax(int defaultSplitMax)
            {
                this.ToComponent().DefaultSplitMax = defaultSplitMax;
                return this as BoxSplitter.Builder;
            }
             
 			/// <summary>
			/// Provides a default minimum width or height for the two components that the splitter is between. Defaults to: 40
			/// </summary>
            public virtual BoxSplitter.Builder DefaultSplitMin(int defaultSplitMin)
            {
                this.ToComponent().DefaultSplitMin = defaultSplitMin;
                return this as BoxSplitter.Builder;
            }
             
 			/// <summary>
			/// Set to false to prevent this Splitter's mini-collapse tool from managing the collapse state of the collapseTarget.
			/// </summary>
            public virtual BoxSplitter.Builder PerformCollapse(bool performCollapse)
            {
                this.ToComponent().PerformCollapse = performCollapse;
                return this as BoxSplitter.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public BoxSplitter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BoxSplitter(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public BoxSplitter.Builder BoxSplitter()
        {
            return this.BoxSplitter(new BoxSplitter());
        }

        /// <summary>
        /// 
        /// </summary>
        public BoxSplitter.Builder BoxSplitter(BoxSplitter component)
        {
            return new BoxSplitter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BoxSplitter.Builder BoxSplitter(BoxSplitter.Config config)
        {
            return new BoxSplitter.Builder(new BoxSplitter(config));
        }
    }
}