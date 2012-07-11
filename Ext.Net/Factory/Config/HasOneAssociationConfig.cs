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
 * @version   : 2.0.0.rc2 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class HasOneAssociation
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public HasOneAssociation(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit HasOneAssociation.Config Conversion to HasOneAssociation
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator HasOneAssociation(HasOneAssociation.Config config)
        {
            return new HasOneAssociation(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractAssociation.Config 
        { 
			/*  Implicit HasOneAssociation.Config Conversion to HasOneAssociation.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator HasOneAssociation.Builder(HasOneAssociation.Config config)
			{
				return new HasOneAssociation.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string foreignKey = null;

			/// <summary>
			/// The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus \"_id\"
			/// </summary>
			[DefaultValue(null)]
			public virtual string ForeignKey 
			{ 
				get
				{
					return this.foreignKey;
				}
				set
				{
					this.foreignKey = value;
				}
			}

			private string getterName = null;

			/// <summary>
			/// The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getAddress
			/// </summary>
			[DefaultValue(null)]
			public virtual string GetterName 
			{ 
				get
				{
					return this.getterName;
				}
				set
				{
					this.getterName = value;
				}
			}

			private string setterName = null;

			/// <summary>
			/// The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setAddress
			/// </summary>
			[DefaultValue(null)]
			public virtual string SetterName 
			{ 
				get
				{
					return this.setterName;
				}
				set
				{
					this.setterName = value;
				}
			}

        }
    }
}