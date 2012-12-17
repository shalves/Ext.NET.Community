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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public SequentialIdGenerator(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit SequentialIdGenerator.Config Conversion to SequentialIdGenerator
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator SequentialIdGenerator(SequentialIdGenerator.Config config)
        {
            return new SequentialIdGenerator(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ModelIdGenerator.Config 
        { 
			/*  Implicit SequentialIdGenerator.Config Conversion to SequentialIdGenerator.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator SequentialIdGenerator.Builder(SequentialIdGenerator.Config config)
			{
				return new SequentialIdGenerator.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string prefix = "";

			/// <summary>
			/// The string to place in front of the sequential number for each generated id. The default is blank.
			/// </summary>
			[DefaultValue("")]
			public virtual string Prefix 
			{ 
				get
				{
					return this.prefix;
				}
				set
				{
					this.prefix = value;
				}
			}

			private int seed = 1;

			/// <summary>
			/// The number at which to start generating sequential id's. The default is 1.
			/// </summary>
			[DefaultValue(1)]
			public virtual int Seed 
			{ 
				get
				{
					return this.seed;
				}
				set
				{
					this.seed = value;
				}
			}

        }
    }
}