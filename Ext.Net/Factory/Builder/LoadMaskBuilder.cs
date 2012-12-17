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
    public partial class LoadMask
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TLoadMask, TBuilder> : BaseItem.Builder<TLoadMask, TBuilder>
            where TLoadMask : LoadMask
            where TBuilder : Builder<TLoadMask, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TLoadMask component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.
			/// </summary>
            public virtual TBuilder ShowMask(bool showMask)
            {
                this.ToComponent().ShowMask = showMask;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display in a centered loading message box (defaults to 'Loading...').
			/// </summary>
            public virtual TBuilder Msg(string msg)
            {
                this.ToComponent().Msg = msg;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to apply to the loading message element (defaults to 'x-mask-loading').
			/// </summary>
            public virtual TBuilder MsgCls(string msgCls)
            {
                this.ToComponent().MsgCls = msgCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional Store to which the mask is bound. The mask is displayed when a load request is issued, and hidden on either load success, or load fail.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether or not to use a loading message class or simply mask the bound element. Defaults to: true
			/// </summary>
            public virtual TBuilder UseMsg(bool useMsg)
            {
                this.ToComponent().UseMsg = useMsg;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : LoadMask.Builder<LoadMask, LoadMask.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new LoadMask()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LoadMask component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LoadMask.Config config) : base(new LoadMask(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(LoadMask component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public LoadMask.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.LoadMask(this);
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
        public LoadMask.Builder LoadMask()
        {
#if MVC
			return this.LoadMask(new LoadMask { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.LoadMask(new LoadMask());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public LoadMask.Builder LoadMask(LoadMask component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new LoadMask.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public LoadMask.Builder LoadMask(LoadMask.Config config)
        {
#if MVC
			return new LoadMask.Builder(new LoadMask(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new LoadMask.Builder(new LoadMask(config));
#endif			
        }
    }
}