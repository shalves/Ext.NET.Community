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
    public partial class ImageCommandColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TImageCommandColumn, TBuilder> : CellCommandColumn.Builder<TImageCommandColumn, TBuilder>
            where TImageCommandColumn : ImageCommandColumn
            where TBuilder : Builder<TImageCommandColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TImageCommandColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to disabled the column header menu containing sort/hide options. Defaults to false.
			/// </summary>
            public virtual TBuilder MenuDisabled(bool menuDisabled)
            {
                this.ToComponent().MenuDisabled = menuDisabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GroupCommands(Action<GroupImageCommandCollection> action)
            {
                action(this.ToComponent().GroupCommands);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PrepareGroupCommand(Action<JFunction> action)
            {
                action(this.ToComponent().PrepareGroupCommand);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PrepareGroupCommands(Action<JFunction> action)
            {
                action(this.ToComponent().PrepareGroupCommands);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ImageCommandColumnListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ImageCommandColumnDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ImageCommandColumn.Builder<ImageCommandColumn, ImageCommandColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ImageCommandColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ImageCommandColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ImageCommandColumn.Config config) : base(new ImageCommandColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ImageCommandColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ImageCommandColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ImageCommandColumn(this);
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
        public ImageCommandColumn.Builder ImageCommandColumn()
        {
#if MVC
			return this.ImageCommandColumn(new ImageCommandColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ImageCommandColumn(new ImageCommandColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ImageCommandColumn.Builder ImageCommandColumn(ImageCommandColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ImageCommandColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ImageCommandColumn.Builder ImageCommandColumn(ImageCommandColumn.Config config)
        {
#if MVC
			return new ImageCommandColumn.Builder(new ImageCommandColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ImageCommandColumn.Builder(new ImageCommandColumn(config));
#endif			
        }
    }
}