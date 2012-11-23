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
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TreePanelListeners : TablePanelListeners
    {
        private ComponentListener afteritemcollapse;

        /// <summary>
        /// Fires after an item has been visually collapsed and is no longer visible in the tree.
        /// 
        /// Parameters
        /// node : Ext.data.NodeInterface
        ///     The node that was collapsed
        /// index : Number
        ///     The index of the node
        /// el : HTMLElement
        ///     The HTML element for the node that was collapsed
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "index")]
        [ListenerArgument(2, "el")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteritemcollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an item has been visually collapsed and is no longer visible in the tree.")]
        public virtual ComponentListener AfterItemCollapse
        {
            get
            {
                return this.afteritemcollapse ?? (this.afteritemcollapse = new ComponentListener());
            }
        }

        private ComponentListener afteritemexpand;

        /// <summary>
        /// Fires after an item has been visually expanded and is visible in the tree.
        /// 
        /// Parameters
        /// node : Ext.data.NodeInterface
        ///     The node that was expanded
        /// index : Number
        ///     The index of the node
        /// item : HTMLElement
        ///     The HTML element for the node that was expanded
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "index")]
        [ListenerArgument(2, "el")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteritemexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an item has been visually expanded and is visible in the tree.")]
        public virtual ComponentListener AfterItemExpand
        {
            get
            {
                return this.afteritemexpand ?? (this.afteritemexpand = new ComponentListener());
            }
        }

        private ComponentListener beforeItemAppend;

        /// <summary>
        /// Fires before a new child is appended, return false to cancel the append.
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The child node to be appended
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is appended, return false to cancel the append.")]
        public virtual ComponentListener BeforeItemAppend
        {
            get
            {
                return this.beforeItemAppend ?? (this.beforeItemAppend = new ComponentListener());
            }
        }

        private ComponentListener beforeItemCollapse;

        /// <summary>
        /// Fires before this node is collapsed.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node        
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemcollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed.")]
        public virtual ComponentListener BeforeItemCollapse
        {
            get
            {
                return this.beforeItemCollapse ?? (this.beforeItemCollapse = new ComponentListener());
            }
        }

        private ComponentListener beforeItemExpand;

        /// <summary>
        /// Fires before this node is collapsed.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node        
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed.")]
        public virtual ComponentListener BeforeItemExpand
        {
            get
            {
                return this.beforeItemExpand ?? (this.beforeItemExpand = new ComponentListener());
            }
        }

        private ComponentListener beforeItemInsert;

        /// <summary>
        /// Fires before a new child is inserted, return false to cancel the insert.
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The child node to be inserted
        /// refNode : Node
        ///     The child node the node is being inserted before
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "refNode")]
        [ListenerArgument(3, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeiteminsert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is inserted, return false to cancel the insert.")]
        public virtual ComponentListener BeforeItemInsert
        {
            get
            {                
                return this.beforeItemInsert ?? (this.beforeItemInsert = new ComponentListener());
            }
        }

        private ComponentListener beforeItemMove;

        /// <summary>
        /// Fires before this node is moved to a new location in the tree. Return false to cancel the move.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node  
        /// oldParent : Node
        ///     The parent of this node
        /// newParent : Node
        ///     The new parent this node is moving to
        /// index : Number
        ///     The index it is being moved to
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "oldParent")]
        [ListenerArgument(2, "newParent")]
        [ListenerArgument(3, "index")]
        [ListenerArgument(4, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is moved to a new location in the tree. Return false to cancel the move.")]
        public virtual ComponentListener BeforeItemMove
        {
            get
            {
                return this.beforeItemMove ?? (this.beforeItemMove = new ComponentListener());
            }
        }

        private ComponentListener beforeItemRemove;

        /// <summary>
        /// Fires before a child is removed, return false to cancel the remove.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node  
        /// node : Node
        ///     The child node to be removed
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeitemremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a child is removed, return false to cancel the remove.")]
        public virtual ComponentListener BeforeItemRemove
        {
            get
            {
                return this.beforeItemRemove ?? (this.beforeItemRemove = new ComponentListener());
            }
        }

        private ComponentListener beforeLoad;

        /// <summary>
        /// Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled.
        /// 
        /// Parameters
        /// item : Ext.data.Store
        ///     This Store
        /// operation : Ext.data.Operation
        ///     The Ext.data.Operation object that will be passed to the Proxy to load the Store
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "operation")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled.")]
        public virtual ComponentListener BeforeLoad
        {
            get
            {
                return this.beforeLoad ?? (this.beforeLoad = new ComponentListener());
            }
        }

        private ComponentListener checkChange;

        /// <summary>
        /// Fires when a node with a checkbox's checked property changes
        /// 
        /// Parameters
        /// item : Ext.data.Model
        ///     The node who's checked property was changed
        /// checked : Boolean
        ///     The node's new checked state
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "checked")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("checkchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node with a checkbox's checked property changes")]
        public virtual ComponentListener CheckChange
        {
            get
            {
                return this.checkChange ?? (this.checkChange = new ComponentListener());
            }
        }

        private ComponentListener itemAppend;

        /// <summary>
        /// Fires when a new child node is appended
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The newly appended node
        /// index : Number
        ///     The index of the newly appended node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "index")]
        [ListenerArgument(3, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is appended")]
        public virtual ComponentListener ItemAppend
        {
            get
            {
                return this.itemAppend ?? (this.itemAppend = new ComponentListener());
            }
        }

        private ComponentListener itemCollapse;

        /// <summary>
        /// Fires when this node is collapsed.
        /// 
        /// Parameters
        /// item : Node
        ///     The collapsing node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]        
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemcollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is collapsed.")]
        public virtual ComponentListener ItemCollapse
        {
            get
            {
                return this.itemCollapse ?? (this.itemCollapse = new ComponentListener());
            }
        }

        private ComponentListener itemExpand;

        /// <summary>
        /// Fires when this node is expanded.
        /// 
        /// Parameters
        /// item : Node
        ///     The expanding node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is expanded.")]
        public virtual ComponentListener ItemExpand
        {
            get
            {
                return this.itemExpand ?? (this.itemExpand = new ComponentListener());
            }
        }

        private ComponentListener itemInsert;

        /// <summary>
        /// Fires when a new child node is inserted.
        /// 
        /// Parameters
        /// item : Node
        ///     The expanding node
        /// node : Node
        ///     The child node inserted
        /// refNode : Node
        ///     The child node the node was inserted before
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "refNode")]
        [ListenerArgument(3, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iteminsert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is inserted.")]
        public virtual ComponentListener ItemInsert
        {
            get
            {
                return this.itemInsert ?? (this.itemInsert = new ComponentListener());
            }
        }

        private ComponentListener itemMove;

        /// <summary>
        /// Fires when this node is moved to a new location in the tree
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// oldParent : Node
        ///     The old parent of this node
        /// newParent : Node
        ///     The new parent of this node
        /// index : Number
        ///     The index it was moved to
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "oldParent")]
        [ListenerArgument(2, "newParent")]
        [ListenerArgument(3, "index")]
        [ListenerArgument(4, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is moved to a new location in the tree")]
        public virtual ComponentListener ItemMove
        {
            get
            {
                return this.itemMove ?? (this.itemMove = new ComponentListener());
            }
        }

        private ComponentListener itemRemove;

        /// <summary>
        /// Fires when a child node is removed
        /// 
        /// Parameters
        /// item : Node
        ///     This node
        /// node : Node
        ///     The removed node
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a child node is removed")]
        public virtual ComponentListener ItemRemove
        {
            get
            {
                return this.itemRemove ?? (this.itemRemove = new ComponentListener());
            }
        }

        private ComponentListener load;

        /// <summary>
        /// Fires whenever records have been prefetched
        /// 
        /// Parameters
        /// item : Ext.data.store
        /// records : Array
        ///     An array of records
        /// successful : Boolean
        ///     True if the operation was successful.
        /// options : Object
        ///     The options object passed to Ext.util.Observable.addListener.
        /// </summary>
        
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "records")]
        [ListenerArgument(3, "successful")]
        [ListenerArgument(4, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever records have been prefetched")]
        public virtual ComponentListener Load
        {
            get
            {
                return this.load ?? (this.load = new ComponentListener());
            }
        }


        private ComponentListener submit;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentListener Submit
        {
            get
            {
                return this.submit ?? (this.submit = new ComponentListener());
            }
        }

        private ComponentListener submitException;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [ListenerArgument(2, "response")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submitexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentListener SubmitException
        {
            get
            {
                return this.submitException ?? (this.submitException = new ComponentListener());
            }
        }

        private ComponentListener beforeRemoteAction;

        /// <summary>
        /// Fires before remote action request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "o")]
        [ListenerArgument(3, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteaction", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote action request")]
        public virtual ComponentListener BeforeRemoteAction
        {
            get
            {
                return this.beforeRemoteAction ?? (this.beforeRemoteAction = new ComponentListener());
            }
        }

        private ComponentListener remoteActionException;

        /// <summary>
        /// Fires when an remote action exception occurs
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an remote action exception occurs")]
        public virtual ComponentListener RemoteActionException
        {
            get
            {
                return this.remoteActionException ?? (this.remoteActionException = new ComponentListener());
            }
        }

        private ComponentListener remoteActionRefusal;

        /// <summary>
        /// Fires when remote action is finished but contains refusal answer
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionrefusal", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action is finished but contains refusal answer")]
        public virtual ComponentListener RemoteActionRefusal
        {
            get
            {
                return this.remoteActionRefusal ?? (this.remoteActionRefusal = new ComponentListener());
            }
        }

        private ComponentListener remoteActionSuccess;

        /// <summary>
        /// Fires when remote action successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionsuccess", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action successful")]
        public virtual ComponentListener RemoteActionSuccess
        {
            get
            {
                return this.remoteActionSuccess ?? (this.remoteActionSuccess = new ComponentListener());
            }
        }

        private ComponentListener beforeRemoteMove;

        /// <summary>
        /// Fires before remote move request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "target")]
        [ListenerArgument(3, "e")]
        [ListenerArgument(4, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotemove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote move request")]
        public virtual ComponentListener BeforeRemoteMove
        {
            get
            {
                return this.beforeRemoteMove ?? (this.beforeRemoteMove = new ComponentListener());
            }
        }

        private ComponentListener beforeRemoteRename;

        /// <summary>
        /// Fires before remote rename request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoterename", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote rename request")]
        public virtual ComponentListener BeforeRemoteRename
        {
            get
            {
                return this.beforeRemoteRename ?? (this.beforeRemoteRename = new ComponentListener());
            }
        }

        private ComponentListener beforeRemoteRemove;

        /// <summary>
        /// Fires before remote remove request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote remove request")]
        public virtual ComponentListener BeforeRemoteRemove
        {
            get
            {
                return this.beforeRemoteRemove ?? (this.beforeRemoteRemove = new ComponentListener());
            }
        }

        private ComponentListener beforeRemoteAppend;

        /// <summary>
        /// Fires before remote insert/append request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [ListenerArgument(3, "insert")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote insert/append request")]
        public virtual ComponentListener BeforeRemoteAppend
        {
            get
            {
                return this.beforeRemoteAppend ?? (this.beforeRemoteAppend = new ComponentListener());
            }
        }

        private ComponentListener remoteEditSuccess;

        /// <summary>
        /// Fires when remote edit successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteeditsuccess", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote edit successful")]
        public virtual ComponentListener RemoteEditSuccess
        {
            get
            {
                return this.remoteEditSuccess ?? (this.remoteEditSuccess = new ComponentListener());
            }
        }

        private ComponentListener remoteRemoveSuccess;

        /// <summary>
        /// Fires when remote remove successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteremovesuccess", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote remove successful")]
        public virtual ComponentListener RemoteRemoveSuccess
        {
            get
            {
                return this.remoteRemoveSuccess ?? (this.remoteRemoveSuccess = new ComponentListener());
            }
        }

        private ComponentListener remoteMoveSuccess;

        /// <summary>
        /// Fires when remote move successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotemovesuccess", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote move successful")]
        public virtual ComponentListener RemoteMoveSuccess
        {
            get
            {
                return this.remoteMoveSuccess ?? (this.remoteMoveSuccess = new ComponentListener());
            }
        }

        private ComponentListener remoteAppendSuccess;

        /// <summary>
        /// Fires when remote append/insert successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteappendsuccess", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote append/insert successful")]
        public virtual ComponentListener RemoteAppendSuccess
        {
            get
            {
                return this.remoteAppendSuccess ?? (this.remoteAppendSuccess = new ComponentListener());
            }
        }

        private ComponentListener nodedragover;

        /// <summary>
        /// Fires when a tree node is being targeted for a drag drop, return false to signal drop not allowed.
        /// Parameters
        /// targetNode : Ext.data.NodeInterface
        ///     The target node
        /// position : String
        ///     The drop position, "before", "after" or "append",
        /// dragData : Object
        ///     Data relating to the drag operation
        /// e : Ext.EventObject
        ///     The event object for the drag
        /// </summary>
        [ListenerArgument(0, "targetNode")]
        [ListenerArgument(1, "position")]
        [ListenerArgument(2, "dragData")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("nodedragover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a tree node is being targeted for a drag drop, return false to signal drop not allowed.")]
        public virtual ComponentListener NodeDragOver
        {
            get
            {
                return this.nodedragover ?? (this.nodedragover = new ComponentListener());
            }
        }
    }
}