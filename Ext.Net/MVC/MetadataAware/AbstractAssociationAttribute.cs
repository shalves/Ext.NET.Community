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
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class AbstractAssociationAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.storeassociation";

        /// <summary>
        /// The name of the property in the data to read the association from. Defaults to the name of the associated model.
        /// </summary>
        [DefaultValue(null)]
        public virtual string AssociationKey
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the primary key on the associated model. In general this will be the Ext.data.Model.idProperty of the Model. Defaults to 'id'
        /// </summary>
        [DefaultValue(null)]
        public virtual string PrimaryKey
        {
            get;
            set;
        }

        /// <summary>
        /// The string name of the model that is being associated with. Required
        /// </summary>
        [DefaultValue(null)]
        public virtual string Model
        {
            get;
            set;
        }

        protected abstract AbstractAssociation CreateAssociation();

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            var association = this.CreateAssociation();
            association.AssociationKey = this.AssociationKey;
            association.PrimaryKey = this.PrimaryKey;
            association.Model = this.Model;

            if (!metadata.AdditionalValues.ContainsKey(AbstractAssociationAttribute.KEY))
            {
                metadata.AdditionalValues[AbstractAssociationAttribute.KEY] = new AssociationCollection();
            }

            var collection = (AssociationCollection)metadata.AdditionalValues[AbstractAssociationAttribute.KEY];
            collection.Add(association);
        }   
    }
}