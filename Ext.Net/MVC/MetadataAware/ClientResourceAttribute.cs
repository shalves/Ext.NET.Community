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
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ClientResourceAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.clientresource";

        /// <summary>
        /// 
        /// </summary>
        public Type Type
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string PathEmbedded
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get;
            set;
        }

        public bool IsCss
        {
            get;
            set;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            ClientResourceItem item;
            if (this.PathEmbedded.IsNotEmpty())
            {
                if(this.Type == null)
                {
                    throw new Exception("Type cannot be null if PathEmbedded is defined");
                }
                item = new ClientResourceItem(this.Type, this.PathEmbedded, this.IsCss);
            }
            else
            {
                item = new ClientResourceItem(this.Path, this.IsCss);                
            }

            if (!metadata.AdditionalValues.ContainsKey(ClientResourceAttribute.KEY))
            {
                metadata.AdditionalValues[ClientResourceAttribute.KEY] = new ResourcesRegistrator();
            }

            var rr = (ResourcesRegistrator)metadata.AdditionalValues[ClientResourceAttribute.KEY];
            rr.ResourceItems.Add(item);
        }
    }
}