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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public abstract class AbstractReaderAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.storereader";
        private bool implicitIncludes = true;
        private bool readRecordsOnFailure = true;

        /// <summary>
        /// Name of the property within a row object that contains a record identifier value. Defaults to The id of the model. If an idProperty is explicitly specified it will override that of the one specified on the model
        /// </summary>
        [DefaultValue(null)]
        public virtual string IDProperty
        {
            get;
            set;
        }

        /// <summary>
        ///  True to automatically parse models nested within other models in a response object. See the Ext.data.reader.Reader intro docs for full explanation. Defaults to true.
        /// </summary>
        [DefaultValue(true)]
        public virtual bool ImplicitIncludes
        {
            get
            {
                return this.implicitIncludes;
            }
            set
            {
                this.implicitIncludes = value;
            }
        }

        /// <summary>
        /// True to read extract the records from a data packet even if the success property returns false. Defaults to: true
        /// </summary>
        [DefaultValue(true)]
        public virtual bool ReadRecordsOnFailure
        {
            get
            {
                return this.readRecordsOnFailure;
            }
            set
            {
                this.readRecordsOnFailure = value;
            }
        }

        /// <summary>
        /// The name of the property which contains the Array of row objects. For JSON reader it's dot-separated list of property names. For XML reader it's a CSS selector. For array reader it's not applicable.
        /// By default the natural root of the data will be used. The root Json array, the root XML element, or the array.
        /// The data packet value for this property should be an empty array to clear the data or show no data.
        /// Defaults to: ""
        /// </summary>
        [DefaultValue(null)]
        public virtual string Root
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the property from which to retrieve the success attribute. Defaults to success. See Ext.data.proxy.Proxy.exception for additional information.
        /// </summary>
        [DefaultValue(null)]
        public virtual string SuccessProperty
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the property from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server. Defaults to total.
        /// </summary>
        [DefaultValue(null)]
        public virtual string TotalProperty
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the property which contains a response message. This property is optional.
        /// </summary>
        [DefaultValue(null)]
        public virtual string MessageProperty
        {
            get;
            set;
        }

        /// <summary>
        /// The Ext.data.Model associated with this reader
        /// </summary>
        [DefaultValue(null)]
        public virtual string ModelName
        {
            get;
            set;
        }

        protected abstract AbstractReader CreateReader();

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            metadata.AdditionalValues[AbstractReaderAttribute.KEY] = this.CreateReader().Apply(this);
        }   
    }
}