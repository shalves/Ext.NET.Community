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
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public abstract class AbstractWriterAttribute : Attribute, IMetadataAware
    {
        public const string KEY = "__ext.net.storewriter";
        private bool writeAllFields = true;
        private bool skipIdForPhantomRecords = true;

        /// <summary>
        /// This property is used to read the key for each value that will be sent to the server. For example:
        /// 
        /// Ext.regModel('Person', {
        ///     fields: [{
        ///         name: 'first',
        ///         mapping: 'firstName'
        ///     }, {
        ///         name: 'last',
        ///         mapping: 'lastName'
        ///     }, {
        ///         name: 'age'
        ///     }]
        /// });
        /// new Ext.data.writer.Writer({
        ///     writeAllFields: true,
        ///     nameProperty: 'mapping'
        /// });
        ///
        /// // This will be sent to the server
        /// {
        ///     firstName: 'first name value',
        ///     lastName: 'last name value',
        ///     age: 1
        /// }
        ///
        /// Defaults to name. If the value is not present, the field name will always be used.
        /// </summary>
        [DefaultValue(null)]
        public virtual string NameProperty
        {
            get;
            set;
        }

        /// <summary>
        /// True to write all fields from the record to the server. If set to false it will only send the fields that were modified. Defaults to true.
        /// </summary>
        [DefaultValue(true)]
        public virtual bool WriteAllFields
        {
            get
            {
                return this.writeAllFields;
            }
            set
            {
                this.writeAllFields = value;
            }
        }

        /// <summary>
        /// Formats the data for each record before sending it to the server. This method should be overridden to format the data in a way that differs from the default.
        /// Parameters
        /// record : Object
        ///     The record that we are writing to the server.
        /// Returns
        ///   An object literal of name/value keys to be written to the server. By default this method returns the data property on the record.
        /// </summary>
        [DefaultValue(null)]
        public virtual string GetRecordDataHandler
        {
            get;
            set;
        }

        [DefaultValue(null)]
        public virtual string FilterRecordHandler
        {
            get;
            set;
        }

        [DefaultValue(null)]
        public virtual string FilterFieldHandler
        {
            get;
            set;
        }

        [DefaultValue(null)]
        public virtual string PrepareHandler
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public virtual bool ExcludeId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        public virtual bool SkipIdForPhantomRecords
        {
            get
            {
                return this.skipIdForPhantomRecords;
            }
            set
            {
                this.skipIdForPhantomRecords = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public virtual bool SkipPhantomId
        {
            get;
            set;
        }

        protected abstract AbstractWriter CreateWriter();

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            var writer = (AbstractWriter)this.CreateWriter().Apply(this);

            if (this.GetRecordDataHandler != null)
            {
                if (JFunction.IsFunctionName(this.GetRecordDataHandler))
                {
                    writer.GetRecordData.Fn = this.GetRecordDataHandler;
                }
                else
                {
                    writer.GetRecordData.Handler = this.GetRecordDataHandler;
                }                
            }

            if (this.FilterRecordHandler != null)
            {
                if (JFunction.IsFunctionName(this.FilterRecordHandler))
                {
                    writer.FilterRecord.Fn = this.FilterRecordHandler;
                }
                else
                {
                    writer.FilterRecord.Handler = this.FilterRecordHandler;
                }
            }

            if (this.FilterFieldHandler != null)
            {
                if (JFunction.IsFunctionName(this.FilterFieldHandler))
                {
                    writer.FilterField.Fn = this.FilterFieldHandler;
                }
                else
                {
                    writer.FilterField.Handler = this.FilterFieldHandler;
                }
            }

            if (this.PrepareHandler != null)
            {
                if (JFunction.IsFunctionName(this.PrepareHandler))
                {
                    writer.Prepare.Fn = this.PrepareHandler;
                }
                else
                {
                    writer.Prepare.Handler = this.PrepareHandler;
                }
            }

            metadata.AdditionalValues[AbstractWriterAttribute.KEY] = writer;
        }   
    }
}