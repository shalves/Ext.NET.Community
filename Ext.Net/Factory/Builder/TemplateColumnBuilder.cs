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
    public partial class TemplateColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTemplateColumn, TBuilder> : CellCommandColumn.Builder<TTemplateColumn, TBuilder>
            where TTemplateColumn : TemplateColumn
            where TBuilder : Builder<TTemplateColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTemplateColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Template(Action<XTemplate> action)
            {
                action(this.ToComponent().Template);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.
			/// </summary>
            public virtual TBuilder TemplateString(string templateString)
            {
                this.ToComponent().TemplateString = templateString;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TemplateColumn.Builder<TemplateColumn, TemplateColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TemplateColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TemplateColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TemplateColumn.Config config) : base(new TemplateColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TemplateColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TemplateColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TemplateColumn(this);
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
        public TemplateColumn.Builder TemplateColumn()
        {
#if MVC
			return this.TemplateColumn(new TemplateColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TemplateColumn(new TemplateColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TemplateColumn.Builder TemplateColumn(TemplateColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TemplateColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TemplateColumn.Builder TemplateColumn(TemplateColumn.Config config)
        {
#if MVC
			return new TemplateColumn.Builder(new TemplateColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TemplateColumn.Builder(new TemplateColumn(config));
#endif			
        }
    }
}