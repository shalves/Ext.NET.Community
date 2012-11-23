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
using System.ComponentModel;

namespace Ext.Net.MVC
{
    public partial class HasManyAssociationAttribute : AbstractAssociationAttribute
    {
        /// <summary>
        /// True to automatically load the related store from a remote source when instantiated. Defaults to false.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool AutoLoad
        {
            get;
            set;
        }

        /// <summary>
        /// Optionally overrides the default filter that is set up on the associated Store. If this is not set, a filter is automatically created which filters the association based on the configured foreignKey. See intro docs for more details. Defaults to undefined
        /// </summary>
        [DefaultValue(null)]
        public virtual string FilterProperty
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the foreign key on the associated model that links it to the owner model. Defaults to the lowercased name of the owner model plus "_id", e.g. an association with a where a model called Group hasMany Users would create 'group_id' as the foreign key.
        /// </summary>
        [DefaultValue(null)]
        public virtual string ForeignKey
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the function to create on the owner model to retrieve the child store. If not specified, the pluralized name of the child model is used.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Name
        {
            get;
            set;
        }
        
        protected override AbstractAssociation CreateAssociation()
        {
            return new HasManyAssociation { ForeignKey = this.ForeignKey, FilterProperty = this.FilterProperty, AutoLoad = this.AutoLoad, Name = this.Name };
        }
    }
}