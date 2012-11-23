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
    public partial class InputMask
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TInputMask, TBuilder> : Plugin.Builder<TInputMask, TBuilder>
            where TInputMask : InputMask
            where TBuilder : Builder<TInputMask, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TInputMask component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlwaysShow(bool alwaysShow)
            {
                this.ToComponent().AlwaysShow = alwaysShow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearWhenInvalid(bool clearWhenInvalid)
            {
                this.ToComponent().ClearWhenInvalid = clearWhenInvalid;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AllowInvalid(bool allowInvalid)
            {
                this.ToComponent().AllowInvalid = allowInvalid;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InvalidMaskText(string invalidMaskText)
            {
                this.ToComponent().InvalidMaskText = invalidMaskText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Mask(string mask)
            {
                this.ToComponent().Mask = mask;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder MaskSymbols(Action<MaskSymbolCollection> action)
            {
                action(this.ToComponent().MaskSymbols);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Placeholder(char placeholder)
            {
                this.ToComponent().Placeholder = placeholder;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder UnmaskOnBlur(bool unmaskOnBlur)
            {
                this.ToComponent().UnmaskOnBlur = unmaskOnBlur;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : InputMask.Builder<InputMask, InputMask.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new InputMask()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(InputMask component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(InputMask.Config config) : base(new InputMask(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(InputMask component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public InputMask.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.InputMask(this);
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
        public InputMask.Builder InputMask()
        {
#if MVC
			return this.InputMask(new InputMask { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.InputMask(new InputMask());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public InputMask.Builder InputMask(InputMask component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new InputMask.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public InputMask.Builder InputMask(InputMask.Config config)
        {
#if MVC
			return new InputMask.Builder(new InputMask(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new InputMask.Builder(new InputMask(config));
#endif			
        }
    }
}