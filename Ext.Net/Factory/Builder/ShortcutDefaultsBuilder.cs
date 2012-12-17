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
    public partial class ShortcutDefaults
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TShortcutDefaults, TBuilder> : BaseItem.Builder<TShortcutDefaults, TBuilder>
            where TShortcutDefaults : ShortcutDefaults
            where TBuilder : Builder<TShortcutDefaults, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TShortcutDefaults component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder TextCls(string textCls)
            {
                this.ToComponent().TextCls = textCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder QTitle(string qTitle)
            {
                this.ToComponent().QTitle = qTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder QTip(string qTip)
            {
                this.ToComponent().QTip = qTip;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ShortcutDefaults.Builder<ShortcutDefaults, ShortcutDefaults.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ShortcutDefaults()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ShortcutDefaults component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ShortcutDefaults.Config config) : base(new ShortcutDefaults(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ShortcutDefaults component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ShortcutDefaults.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ShortcutDefaults(this);
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
        public ShortcutDefaults.Builder ShortcutDefaults()
        {
#if MVC
			return this.ShortcutDefaults(new ShortcutDefaults { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ShortcutDefaults(new ShortcutDefaults());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ShortcutDefaults.Builder ShortcutDefaults(ShortcutDefaults component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ShortcutDefaults.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ShortcutDefaults.Builder ShortcutDefaults(ShortcutDefaults.Config config)
        {
#if MVC
			return new ShortcutDefaults.Builder(new ShortcutDefaults(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ShortcutDefaults.Builder(new ShortcutDefaults(config));
#endif			
        }
    }
}