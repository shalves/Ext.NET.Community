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
    public partial class CheckboxSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCheckboxSelectionModel, TBuilder> : RowSelectionModel.Builder<TCheckboxSelectionModel, TBuilder>
            where TCheckboxSelectionModel : CheckboxSelectionModel
            where TBuilder : Builder<TCheckboxSelectionModel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCheckboxSelectionModel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true if rows can only be selected by clicking on the checkbox column (defaults to false).
			/// </summary>
            public virtual TBuilder CheckOnly(bool checkOnly)
            {
                this.ToComponent().CheckOnly = checkOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Instructs the SelectionModel whether or not to inject the checkbox header automatically or not. (Note: By not placing the checkbox in manually, the grid view will need to be rendered 2x on initial render.) Supported values are a Number index, false and the strings 'first' and 'last'. Default is 0.
			/// </summary>
            public virtual TBuilder InjectCheckbox(string injectCheckbox)
            {
                this.ToComponent().InjectCheckbox = injectCheckbox;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// RowSpan attribute for the checkbox table cell
			/// </summary>
            public virtual TBuilder RowSpan(int rowSpan)
            {
                this.ToComponent().RowSpan = rowSpan;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// RowSpan attribute for the checkbox table cell
			/// </summary>
            public virtual TBuilder ShowHeaderCheckbox(bool showHeaderCheckbox)
            {
                this.ToComponent().ShowHeaderCheckbox = showHeaderCheckbox;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
			/// </summary>
            public virtual TBuilder Renderer(Renderer renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CheckboxSelectionModel.Builder<CheckboxSelectionModel, CheckboxSelectionModel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CheckboxSelectionModel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CheckboxSelectionModel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CheckboxSelectionModel.Config config) : base(new CheckboxSelectionModel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CheckboxSelectionModel component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CheckboxSelectionModel(this);
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
        public CheckboxSelectionModel.Builder CheckboxSelectionModel()
        {
#if MVC
			return this.CheckboxSelectionModel(new CheckboxSelectionModel { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CheckboxSelectionModel(new CheckboxSelectionModel());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel.Builder CheckboxSelectionModel(CheckboxSelectionModel component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CheckboxSelectionModel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel.Builder CheckboxSelectionModel(CheckboxSelectionModel.Config config)
        {
#if MVC
			return new CheckboxSelectionModel.Builder(new CheckboxSelectionModel(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CheckboxSelectionModel.Builder(new CheckboxSelectionModel(config));
#endif			
        }
    }
}