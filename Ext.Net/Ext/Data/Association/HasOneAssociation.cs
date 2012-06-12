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
using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Represents a one to one association with another model. The owner model is expected to have a foreign key which references the primary key of the associated model:
    /// 
    /// Ext.define('Address', {
    ///     extend: 'Ext.data.Model',
    ///     fields: [
    ///         { name: 'id',          type: 'int' },
    ///         { name: 'number', type: 'string' },
    ///         { name: 'street', type: 'string' },
    ///         { name: 'city', type: 'string' },
    ///         { name: 'zip', type: 'string' },
    ///     ]
    /// });
    /// 
    /// Ext.define('Person', {
    ///     extend: 'Ext.data.Model',
    ///     fields: [
    ///         { name: 'id',   type: 'int' },
    ///         { name: 'name', type: 'string' },
    ///         { name: 'address_id', type: 'int'}
    ///     ],
    ///     // we can use the hasOne shortcut on the model to create a hasOne association
    ///     associations: { type: 'hasOne', model: 'Address' }
    /// });
    /// In the example above we have created models for People and Addresses, and linked them together by saying that each Person has a single Address. This automatically links each Person to an Address based on the Persons address_id, and provides new functions on the Person model:
    /// 
    /// Generated getter function
    ///
    /// The first function that is added to the owner model is a getter function:
    /// 
    /// var person = new Person({
    ///     id: 100,
    ///     address_id: 20,
    ///     name: 'John Smith'
    /// });
    /// 
    /// person.getAddress(function(address, operation) {
    ///     // do something with the address object
    ///     alert(address.get('id')); // alerts 20
    /// }, this);
    /// The getAddress function was created on the Person model when we defined the association. This uses the Persons configured proxy to load the Address asynchronously, calling the provided callback when it has loaded.
    ///
    /// The new getAddress function will also accept an object containing success, failure and callback properties - callback will always be called, success will only be called if the associated model was loaded successfully and failure will only be called if the associatied model could not be loaded:
    /// 
    /// person.getAddress({
    ///     reload: true, // force a reload if the owner model is already cached
    ///     callback: function(address, operation) {}, // a function that will always be called
    ///     success : function(address, operation) {}, // a function that will only be called if the load succeeded
    ///     failure : function(address, operation) {}, // a function that will only be called if the load did not succeed
    ///     scope   : this // optionally pass in a scope object to execute the callbacks in
    /// });
    /// In each case above the callbacks are called with two arguments - the associated model instance and the operation object that was executed to load that instance. The Operation object is useful when the instance could not be loaded.
    /// 
    /// Once the getter has been called on the model, it will be cached if the getter is called a second time. To force the model to reload, specify reload: true in the options object.
    /// 
    /// Generated setter function
    /// 
    /// The second generated function sets the associated model instance - if only a single argument is passed to the setter then the following two calls are identical:
    /// 
    /// // this call...
    /// person.setAddress(10);
    /// 
    /// // is equivalent to this call:
    /// person.set('address_id', 10);
    /// An instance of the owner model can also be passed as a parameter.
    /// 
    /// If we pass in a second argument, the model will be automatically saved and the second argument passed to the owner model's save method:
    /// 
    /// person.setAddress(10, function(address, operation) {
    ///     // the address has been saved
    ///     alert(address.get('address_id')); //now alerts 10
    /// });
    /// 
    /// //alternative syntax:
    /// person.setAddress(10, {
    ///     callback: function(address, operation), // a function that will always be called
    ///     success : function(address, operation), // a function that will only be called if the load succeeded
    ///     failure : function(address, operation), // a function that will only be called if the load did not succeed
    ///     scope   : this //optionally pass in a scope object to execute the callbacks in
    /// })
    /// Customisation
    ///
    /// Associations reflect on the models they are linking to automatically set up properties such as the primaryKey and foreignKey. These can alternatively be specified:
    /// 
    /// Ext.define('Person', {
    ///     fields: [...],
    /// 
    ///     associations: [
    ///         { type: 'hasOne', model: 'Address', primaryKey: 'unique_id', foreignKey: 'addr_id' }
    ///     ]
    /// });
    /// Here we replaced the default primary key (defaults to 'id') and foreign key (calculated as 'address_id') with our own settings. Usually this will not be needed.
    /// </summary>
    [Meta]
    public partial class HasOneAssociation : AbstractAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        public HasOneAssociation()
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
                return "hasOne";
            }
        }

        /// <summary>
        /// The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus "_id"
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus \"_id\"")]
        public virtual string ForeignKey
        {
            get
            {
                return this.State.Get<string>("ForeignKey", null);
            }
            set
            {
                this.State.Set("ForeignKey", value);
            }
        }

        /// <summary>
        /// The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getAddress
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getAddress")]
        public virtual string GetterName
        {
            get
            {
                return this.State.Get<string>("GetterName", null);
            }
            set
            {
                this.State.Set("GetterName", value);
            }
        }

        /// <summary>
        /// The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setAddress
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setAddress")]
        public virtual string SetterName
        {
            get
            {
                return this.State.Get<string>("SetterName", null);
            }
            set
            {
                this.State.Set("SetterName", value);
            }
        }
    }
}
