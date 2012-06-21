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
 * @version   : 2.0.0.rc1 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
    public partial class CRUDMethods
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<CRUDMethods, CRUDMethods.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CRUDMethods()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CRUDMethods component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CRUDMethods.Config config) : base(new CRUDMethods(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CRUDMethods component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDMethods.Builder Create(HttpMethod create)
            {
                this.ToComponent().Create = create;
                return this as CRUDMethods.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDMethods.Builder Read(HttpMethod read)
            {
                this.ToComponent().Read = read;
                return this as CRUDMethods.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDMethods.Builder Update(HttpMethod update)
            {
                this.ToComponent().Update = update;
                return this as CRUDMethods.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDMethods.Builder Destroy(HttpMethod destroy)
            {
                this.ToComponent().Destroy = destroy;
                return this as CRUDMethods.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CRUDMethods(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods.Builder CRUDMethods()
        {
            return this.CRUDMethods(new CRUDMethods());
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods.Builder CRUDMethods(CRUDMethods component)
        {
            return new CRUDMethods.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods.Builder CRUDMethods(CRUDMethods.Config config)
        {
            return new CRUDMethods.Builder(new CRUDMethods(config));
        }
    }
}