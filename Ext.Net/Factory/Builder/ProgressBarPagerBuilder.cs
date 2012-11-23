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
    public partial class ProgressBarPager
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TProgressBarPager, TBuilder> : Plugin.Builder<TProgressBarPager, TBuilder>
            where TProgressBarPager : ProgressBarPager
            where TBuilder : Builder<TProgressBarPager, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TProgressBarPager component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ProgressBarPager.Builder<ProgressBarPager, ProgressBarPager.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ProgressBarPager()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ProgressBarPager component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ProgressBarPager.Config config) : base(new ProgressBarPager(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ProgressBarPager component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBarPager.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ProgressBarPager(this);
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
        public ProgressBarPager.Builder ProgressBarPager()
        {
#if MVC
			return this.ProgressBarPager(new ProgressBarPager { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ProgressBarPager(new ProgressBarPager());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBarPager.Builder ProgressBarPager(ProgressBarPager component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ProgressBarPager.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBarPager.Builder ProgressBarPager(ProgressBarPager.Config config)
        {
#if MVC
			return new ProgressBarPager.Builder(new ProgressBarPager(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ProgressBarPager.Builder(new ProgressBarPager(config));
#endif			
        }
    }
}