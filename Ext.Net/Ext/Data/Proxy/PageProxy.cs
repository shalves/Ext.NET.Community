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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    [Meta]
    public partial class PageProxy : ServerProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public PageProxy()
        {
        }
        
        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected override string Type
        {
            get
            {
                return "page";
            }
        }

        private CRUDUrls api;

        /// <summary>
        /// Specific direct methods to call on CRUD action methods "read", "create", "update" and "destroy".        
        /// </summary>
        [ConfigOption("api", JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specific direct methods to call on CRUD action methods \"read\", \"create\", \"update\" and \"destroy\".")]
        public override CRUDUrls API
        {
            get
            {
                return this.api ?? (this.api = new CRUDUrls { Owner = this.Owner, SkipUrlResolving = true });
            }
        }
        
        private int total;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(0)]
        [Description("")]
        public int Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DirectFn
        {
            get
            {
                return this.State.Get<string>("DirectFn", "");
            }
            set
            {
                this.State.Set("DirectFn", value);
            }
        }

        private BaseDirectEvent requestConfig;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption(JsonMode.Object)]
        [Description("")]
        public BaseDirectEvent RequestConfig
        {
            get
            {
                if (this.requestConfig == null)
                {
                    this.requestConfig = new BaseDirectEvent();
                }

                return this.requestConfig;
            }
        }
    }
}
