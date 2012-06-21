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
    public partial class CRUDUrls
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<CRUDUrls, CRUDUrls.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CRUDUrls()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CRUDUrls component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CRUDUrls.Config config) : base(new CRUDUrls(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CRUDUrls component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDUrls.Builder Sync(string sync)
            {
                this.ToComponent().Sync = sync;
                return this as CRUDUrls.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDUrls.Builder Create(string create)
            {
                this.ToComponent().Create = create;
                return this as CRUDUrls.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDUrls.Builder Read(string read)
            {
                this.ToComponent().Read = read;
                return this as CRUDUrls.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDUrls.Builder Update(string update)
            {
                this.ToComponent().Update = update;
                return this as CRUDUrls.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CRUDUrls.Builder Destroy(string destroy)
            {
                this.ToComponent().Destroy = destroy;
                return this as CRUDUrls.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDUrls.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CRUDUrls(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CRUDUrls.Builder CRUDUrls()
        {
            return this.CRUDUrls(new CRUDUrls());
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDUrls.Builder CRUDUrls(CRUDUrls component)
        {
            return new CRUDUrls.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDUrls.Builder CRUDUrls(CRUDUrls.Config config)
        {
            return new CRUDUrls.Builder(new CRUDUrls(config));
        }
    }
}