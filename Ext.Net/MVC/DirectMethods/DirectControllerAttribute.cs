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
using System.Linq;
using System.Text;
using System.Web;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectControllerAttribute : Attribute
    {
        public string AreaName
        {
            get;
            set;
        }

        private bool generateProxyForOtherAreas = false;
        public bool GenerateProxyForOtherAreas
        {
            get
            {
                return this.generateProxyForOtherAreas;
            }
            set
            {
                this.generateProxyForOtherAreas = value;
            }
        }

        private bool generateProxyForOtherControllers = true;
        public bool GenerateProxyForOtherControllers
        {
            get
            {
                return this.generateProxyForOtherControllers;
            }
            set
            {
                this.generateProxyForOtherControllers = true;
            }
        }

        private DirectMethodProxyIDMode idMode = DirectMethodProxyIDMode.ClientID;
        private string alias;

        /// <summary>
        /// 
        /// </summary>
        public DirectMethodProxyIDMode IDMode
        {
            get
            {
                return this.idMode;
            }
            set
            {
                this.idMode = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Alias
        {
            get
            {
                return this.alias;
            }
            set
            {
                this.alias = value;
            }
        }
    }
}