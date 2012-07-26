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
 * @version   : 2.0.0 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class TreePanelDirectEvents : TablePanelDirectEvents
    {
        public TreePanelDirectEvents() { }

        public TreePanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent afteritemcollapse;

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
        [ConfigOption("afteritemcollapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an item has been visually collapsed and is no longer visible in the tree.")]
        public virtual ComponentDirectEvent AfterItemCollapse
        {
            get
            {
                return this.afteritemcollapse ?? (this.afteritemcollapse = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent afteritemexpand;

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
        [ConfigOption("afteritemexpand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an item has been visually expanded and is visible in the tree.")]
        public virtual ComponentDirectEvent AfterItemExpand
        {
            get
            {
                return this.afteritemexpand ?? (this.afteritemexpand = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemAppend;

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
        [ConfigOption("beforeitemappend", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is appended, return false to cancel the append.")]
        public virtual ComponentDirectEvent BeforeItemAppend
        {
            get
            {
                return this.beforeItemAppend ?? (this.beforeItemAppend = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemCollapse;

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
        [ConfigOption("beforeitemcollapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed.")]
        public virtual ComponentDirectEvent BeforeItemCollapse
        {
            get
            {
                return this.beforeItemCollapse ?? (this.beforeItemCollapse = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemExpand;

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
        [ConfigOption("beforeitemexpand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed.")]
        public virtual ComponentDirectEvent BeforeItemExpand
        {
            get
            {
                return this.beforeItemExpand ?? (this.beforeItemExpand = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemInsert;

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
        [ConfigOption("beforeiteminsert", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is inserted, return false to cancel the insert.")]
        public virtual ComponentDirectEvent BeforeItemInsert
        {
            get
            {
                return this.beforeItemInsert ?? (this.beforeItemInsert = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemMove;

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
        [ConfigOption("beforeitemmove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is moved to a new location in the tree. Return false to cancel the move.")]
        public virtual ComponentDirectEvent BeforeItemMove
        {
            get
            {
                return this.beforeItemMove ?? (this.beforeItemMove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeItemRemove;

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
        [ConfigOption("beforeitemremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a child is removed, return false to cancel the remove.")]
        public virtual ComponentDirectEvent BeforeItemRemove
        {
            get
            {
                return this.beforeItemRemove ?? (this.beforeItemRemove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeLoad;

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
        [ConfigOption("beforeload", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled.")]
        public virtual ComponentDirectEvent BeforeLoad
        {
            get
            {
                return this.beforeLoad ?? (this.beforeLoad = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent checkChange;

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
        [ConfigOption("checkchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node with a checkbox's checked property changes")]
        public virtual ComponentDirectEvent CheckChange
        {
            get
            {
                return this.checkChange ?? (this.checkChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemAppend;

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
        [ConfigOption("itemappend", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is appended")]
        public virtual ComponentDirectEvent ItemAppend
        {
            get
            {
                return this.itemAppend ?? (this.itemAppend = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemCollapse;

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
        [ConfigOption("itemcollapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is collapsed.")]
        public virtual ComponentDirectEvent ItemCollapse
        {
            get
            {
                return this.itemCollapse ?? (this.itemCollapse = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemExpand;

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
        [ConfigOption("itemexpand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is expanded.")]
        public virtual ComponentDirectEvent ItemExpand
        {
            get
            {
                return this.itemExpand ?? (this.itemExpand = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemInsert;

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
        [ConfigOption("iteminsert", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is inserted.")]
        public virtual ComponentDirectEvent ItemInsert
        {
            get
            {
                return this.itemInsert ?? (this.itemInsert = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemMove;

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
        [ConfigOption("itemmove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is moved to a new location in the tree")]
        public virtual ComponentDirectEvent ItemMove
        {
            get
            {
                return this.itemMove ?? (this.itemMove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent itemRemove;

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
        [ConfigOption("itemremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a child node is removed")]
        public virtual ComponentDirectEvent ItemRemove
        {
            get
            {
                return this.itemRemove ?? (this.itemRemove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent load;

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
        [ListenerArgument(1, "records")]
        [ListenerArgument(2, "successful")]
        [ListenerArgument(3, "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever records have been prefetched")]
        public virtual ComponentDirectEvent Load
        {
            get
            {
                return this.load ?? (this.load = new ComponentDirectEvent(this));
            }
        }


        private ComponentDirectEvent submit;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentDirectEvent Submit
        {
            get
            {
                return this.submit ?? (this.submit = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent submitException;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [ListenerArgument(2, "response")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submitexception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentDirectEvent SubmitException
        {
            get
            {
                return this.submitException ?? (this.submitException = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeRemoteAction;

        /// <summary>
        /// Fires before remote action request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "o")]
        [ListenerArgument(3, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteaction", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote action request")]
        public virtual ComponentDirectEvent BeforeRemoteAction
        {
            get
            {
                return this.beforeRemoteAction ?? (this.beforeRemoteAction = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent remoteActionException;

        /// <summary>
        /// Fires when an remote action exception occurs
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionexception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an remote action exception occurs")]
        public virtual ComponentDirectEvent RemoteActionException
        {
            get
            {
                return this.remoteActionException ?? (this.remoteActionException = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent remoteActionRefusal;

        /// <summary>
        /// Fires when remote action is finished but contains refusal answer
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionrefusal", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action is finished but contains refusal answer")]
        public virtual ComponentDirectEvent RemoteActionRefusal
        {
            get
            {
                return this.remoteActionRefusal ?? (this.remoteActionRefusal = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent remoteActionSuccess;

        /// <summary>
        /// Fires when remote action successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [ListenerArgument(4, "responseParams")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionsuccess", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action successful")]
        public virtual ComponentDirectEvent RemoteActionSuccess
        {
            get
            {
                return this.remoteActionSuccess ?? (this.remoteActionSuccess = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeRemoteMove;

        /// <summary>
        /// Fires before remote move request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "target")]
        [ListenerArgument(3, "e")]
        [ListenerArgument(4, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotemove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote move request")]
        public virtual ComponentDirectEvent BeforeRemoteMove
        {
            get
            {
                return this.beforeRemoteMove ?? (this.beforeRemoteMove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeRemoteRename;

        /// <summary>
        /// Fires before remote rename request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoterename", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote rename request")]
        public virtual ComponentDirectEvent BeforeRemoteRename
        {
            get
            {
                return this.beforeRemoteRename ?? (this.beforeRemoteRename = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeRemoteRemove;

        /// <summary>
        /// Fires before remote remove request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote remove request")]
        public virtual ComponentDirectEvent BeforeRemoteRemove
        {
            get
            {
                return this.beforeRemoteRemove ?? (this.beforeRemoteRemove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeRemoteAppend;

        /// <summary>
        /// Fires before remote insert/append request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [ListenerArgument(3, "insert")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteappend", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote insert/append request")]
        public virtual ComponentDirectEvent BeforeRemoteAppend
        {
            get
            {
                return this.beforeRemoteAppend ?? (this.beforeRemoteAppend = new ComponentDirectEvent(this));
            }
        }
    }
}