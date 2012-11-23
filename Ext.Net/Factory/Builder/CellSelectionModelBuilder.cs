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
    public partial class CellSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCellSelectionModel, TBuilder> : AbstractSelectionModel.Builder<TCellSelectionModel, TBuilder>
            where TCellSelectionModel : CellSelectionModel
            where TBuilder : Builder<TCellSelectionModel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCellSelectionModel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Turns on/off keyboard navigation within the grid. Defaults to true.
			/// </summary>
            public virtual TBuilder EnableKeyNav(bool enableKeyNav)
            {
                this.ToComponent().EnableKeyNav = enableKeyNav;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set this configuration to true to prevent wrapping around of selection as a user navigates to the first or last column. Defaults to false.
			/// </summary>
            public virtual TBuilder PreventWrap(bool preventWrap)
            {
                this.ToComponent().PreventWrap = preventWrap;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<CellSelectionModelListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<CellSelectionModelDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// HiddenField name which submits selected cell
			/// </summary>
            public virtual TBuilder HiddenName(string hiddenName)
            {
                this.ToComponent().HiddenName = hiddenName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Selected cell
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectedCell(Action<SelectedCell> action)
            {
                action(this.ToComponent().SelectedCell);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Clear()
            {
                this.ToComponent().Clear();
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CellSelectionModel.Builder<CellSelectionModel, CellSelectionModel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CellSelectionModel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CellSelectionModel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CellSelectionModel.Config config) : base(new CellSelectionModel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CellSelectionModel component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CellSelectionModel(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder CellSelectionModel()
        {
#if MVC
			return this.CellSelectionModel(new CellSelectionModel { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CellSelectionModel(new CellSelectionModel());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder CellSelectionModel(CellSelectionModel component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CellSelectionModel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CellSelectionModel.Builder CellSelectionModel(CellSelectionModel.Config config)
        {
#if MVC
			return new CellSelectionModel.Builder(new CellSelectionModel(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CellSelectionModel.Builder(new CellSelectionModel(config));
#endif			
        }
    }
}