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
using System.Web.Mvc;
using System.ComponentModel;

namespace Ext.Net.MVC
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
    public partial class ModelAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.model";

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            metadata.AdditionalValues[ModelAttribute.KEY] = this;
        }

        public void CopyTo(Model model)
        {
            model.Apply(this);
        }

        /// <summary>
        /// The model name. Required
        /// </summary>
        [DefaultValue(null)]
        public virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// One or more BelongsTo associationa for this model.
        /// </summary>
        [DefaultValue(null)]
        public virtual string BelongsTo
        {
            get;
            set;
        }

        /// <summary>
        /// One or more HasMany associations for this model.
        /// </summary>
        [DefaultValue(null)]
        public virtual string HasMany
        {
            get;
            set;
        }

        /// <summary>
        /// The name of a property that is used for submitting this Model's unique client-side identifier to the server when multiple phantom records are saved as part of the same Operation. In such a case, the server response should include the client id for each record so that the server response data can be used to update the client-side records if necessary.
        /// This property cannot have the same name as any of this Model's fields. 
        /// </summary>
        [DefaultValue(null)]
        public virtual string ClientIdProperty
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public virtual string Extend
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the field treated as this Model's unique id (defaults to 'id').
        /// </summary>
        [DefaultValue(null)]
        public virtual string IDProperty
        {
            get;
            set;
        }
    }
}