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
using System.ComponentModel;
using System.Web.UI;
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [NonVisualControl]
    [ToolboxData("<{0}:ResourcesRegistrator runat=\"server\" />")]
    [Description("")]
    [ParseChildren(true, "ResourceItems")]
    public partial class ResourcesRegistrator : Observable, ICustomConfigSerialization, IVirtual
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ResourcesRegistrator() { }

        protected override System.Collections.Generic.List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> list = base.Resources;

                foreach (ClientResourceItem item in this.ResourceItems)
	            {
                    ResourceItem resItem = null;

                    if (!item.IsCss)
                    {
                        resItem = new ClientScriptItem(item.Type, item.PathEmbedded, item.Path);                        
                    }
                    else
                    {
                        resItem = new ClientStyleItem(item.Type, item.PathEmbedded, item.Path); 
                    }

                    resItem.IgnoreResourceMode = true;
                    list.Add(resItem);
	            }

                return list;
            }
        }        

        private List<ClientResourceItem> resources;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual List<ClientResourceItem> ResourceItems
        {
            get
            {
                if (this.resources == null)
                {
                    this.resources = new List<ClientResourceItem>();
                }

                return this.resources;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string ToScript(Control owner)
        {
            return "";
        }

        public override void AddScript(string script)
        {
            // do not remove
        }
    }
}