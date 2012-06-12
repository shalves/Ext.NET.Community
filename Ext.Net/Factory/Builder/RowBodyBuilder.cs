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
 * @version   : 2.0.0.beta3 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public partial class RowBody
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridFeature.Builder<RowBody, RowBody.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RowBody()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowBody component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowBody.Config config) : base(new RowBody(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RowBody component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowBody.Builder RowBodyHiddenCls(string rowBodyHiddenCls)
            {
                this.ToComponent().RowBodyHiddenCls = rowBodyHiddenCls;
                return this as RowBody.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowBody.Builder RowBodyTrCls(string rowBodyTrCls)
            {
                this.ToComponent().RowBodyTrCls = rowBodyTrCls;
                return this as RowBody.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowBody.Builder RowBodyTdCls(string rowBodyTdCls)
            {
                this.ToComponent().RowBodyTdCls = rowBodyTdCls;
                return this as RowBody.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowBody.Builder RowBodyDivCls(string rowBodyDivCls)
            {
                this.ToComponent().RowBodyDivCls = rowBodyDivCls;
                return this as RowBody.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public RowBody.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RowBody(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public RowBody.Builder RowBody()
        {
            return this.RowBody(new RowBody());
        }

        /// <summary>
        /// 
        /// </summary>
        public RowBody.Builder RowBody(RowBody component)
        {
            return new RowBody.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RowBody.Builder RowBody(RowBody.Config config)
        {
            return new RowBody.Builder(new RowBody(config));
        }
    }
}