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
    public partial class ValidationStatus
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TValidationStatus, TBuilder> : Plugin.Builder<TValidationStatus, TBuilder>
            where TValidationStatus : ValidationStatus
            where TBuilder : Builder<TValidationStatus, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TValidationStatus component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The FormPanel to use.
			/// </summary>
            public virtual TBuilder FormPanelID(string formPanelID)
            {
                this.ToComponent().FormPanelID = formPanelID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error icon
			/// </summary>
            public virtual TBuilder ErrorIcon(Icon errorIcon)
            {
                this.ToComponent().ErrorIcon = errorIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error icon css class
			/// </summary>
            public virtual TBuilder ErrorIconCls(string errorIconCls)
            {
                this.ToComponent().ErrorIconCls = errorIconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error list css class
			/// </summary>
            public virtual TBuilder ErrorListCls(string errorListCls)
            {
                this.ToComponent().ErrorListCls = errorListCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The valid icon
			/// </summary>
            public virtual TBuilder ValidIcon(Icon validIcon)
            {
                this.ToComponent().ValidIcon = validIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The valid icon css class
			/// </summary>
            public virtual TBuilder ValidIconCls(string validIconCls)
            {
                this.ToComponent().ValidIconCls = validIconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text which shown when errors exist
			/// </summary>
            public virtual TBuilder ShowText(string showText)
            {
                this.ToComponent().ShowText = showText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text which hide error list when click on it
			/// </summary>
            public virtual TBuilder HideText(string hideText)
            {
                this.ToComponent().HideText = hideText;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ValidationStatus.Builder<ValidationStatus, ValidationStatus.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ValidationStatus()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ValidationStatus component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ValidationStatus.Config config) : base(new ValidationStatus(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ValidationStatus component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ValidationStatus(this);
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
        public ValidationStatus.Builder ValidationStatus()
        {
#if MVC
			return this.ValidationStatus(new ValidationStatus { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ValidationStatus(new ValidationStatus());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus.Builder ValidationStatus(ValidationStatus component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ValidationStatus.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus.Builder ValidationStatus(ValidationStatus.Config config)
        {
#if MVC
			return new ValidationStatus.Builder(new ValidationStatus(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ValidationStatus.Builder(new ValidationStatus(config));
#endif			
        }
    }
}