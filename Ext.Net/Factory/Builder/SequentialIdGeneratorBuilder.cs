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
    public partial class SequentialIdGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TSequentialIdGenerator, TBuilder> : ModelIdGenerator.Builder<TSequentialIdGenerator, TBuilder>
            where TSequentialIdGenerator : SequentialIdGenerator
            where TBuilder : Builder<TSequentialIdGenerator, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSequentialIdGenerator component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The string to place in front of the sequential number for each generated id. The default is blank.
			/// </summary>
            public virtual TBuilder Prefix(string prefix)
            {
                this.ToComponent().Prefix = prefix;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number at which to start generating sequential id's. The default is 1.
			/// </summary>
            public virtual TBuilder Seed(int seed)
            {
                this.ToComponent().Seed = seed;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : SequentialIdGenerator.Builder<SequentialIdGenerator, SequentialIdGenerator.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SequentialIdGenerator()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SequentialIdGenerator component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SequentialIdGenerator.Config config) : base(new SequentialIdGenerator(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SequentialIdGenerator component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SequentialIdGenerator.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SequentialIdGenerator(this);
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
        public SequentialIdGenerator.Builder SequentialIdGenerator()
        {
#if MVC
			return this.SequentialIdGenerator(new SequentialIdGenerator { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.SequentialIdGenerator(new SequentialIdGenerator());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public SequentialIdGenerator.Builder SequentialIdGenerator(SequentialIdGenerator component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new SequentialIdGenerator.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SequentialIdGenerator.Builder SequentialIdGenerator(SequentialIdGenerator.Config config)
        {
#if MVC
			return new SequentialIdGenerator.Builder(new SequentialIdGenerator(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new SequentialIdGenerator.Builder(new SequentialIdGenerator(config));
#endif			
        }
    }
}