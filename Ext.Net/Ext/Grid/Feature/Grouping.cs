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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This feature allows to display the grid rows aggregated into groups as specified by the Ext.data.Store.groupers specified on the Store. The group will show the title for the group name and then the appropriate records for the group underneath. The groups can also be expanded and collapsed.
    /// 
    /// Extra Events
    /// This feature adds several extra events that will be fired on the grid to interact with the groups:
    /// 
    /// groupclick
    /// groupdblclick
    /// groupcontextmenu
    /// groupexpand
    /// groupcollapse
    /// 
    /// Menu Augmentation
    /// This feature adds extra options to the grid column menu to provide the user with functionality to modify the grouping. This can be disabled by setting the enableGroupingMenu option. The option to disallow grouping from being turned off by thew user is enableNoGroups.
    /// 
    /// Controlling Group Text
    /// The groupHeaderTpl is used to control the rendered title for each group. It can modified to customized the default display.
    /// </summary>
    [Meta]
    public partial class Grouping : GridFeature
    {
        /// <summary>
        /// 
        /// </summary>
        public Grouping()
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.feature.Grouping";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ftype")]
        [DefaultValue("")]
        [Description("")]
        protected override string FType
        {
            get
            {
                return "grouping";
            }
        }
        
        /// <summary>
        /// Number of pixels to indent per grouping level
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(17)]
        [Description("True to enable drag and drop reorder of columns.")]
        public virtual int DepthToIndent
        {
            get
            {
                return this.State.Get<int>("DepthToIndent", 17);
            }
            set
            {
                this.State.Set("DepthToIndent", value);
            }
        }

        /// <summary>
        /// True to enable the grouping control in the header menu (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to enable the grouping control in the header menu (defaults to true)")]
        public virtual bool EnableGroupingMenu
        {
            get
            {
                return this.State.Get<bool>("EnableGroupingMenu", true);
            }
            set
            {
                this.State.Set("EnableGroupingMenu", value);
            }
        }

        /// <summary>
        /// True to allow the user to turn off grouping (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to allow the user to turn off grouping (defaults to true)")]
        public virtual bool EnableNoGroups
        {
            get
            {
                return this.State.Get<bool>("EnableNoGroups", true);
            }
            set
            {
                this.State.Set("EnableNoGroups", value);
            }
        }

        /// <summary>
        /// Text displayed in the grid header menu for grouping by header (defaults to 'Group By This Field').
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Text displayed in the grid header menu for grouping by header (defaults to 'Group By This Field').")]
        public virtual string GroupByText
        {
            get
            {
                return this.State.Get<string>("GroupByText", "");
            }
            set
            {
                this.State.Set("GroupByText", value);
            }
        }

        /// <summary>
        /// A string Template snippet, an array of strings (optionally followed by an object containing Template methods) to be used to construct a Template, or a Template instance. Defaults to: "{columnName}: {name}"
        /// </summary>
        [Meta]
        [ConfigOption("groupHeaderTpl")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A string Template snippet, an array of strings (optionally followed by an object containing Template methods) to be used to construct a Template, or a Template instance. Defaults to: \"{columnName}: {name}\"")]
        public virtual string GroupHeaderTplString
        {
            get
            {
                return this.State.Get<string>("GroupHeaderTplString", "");
            }
            set
            {
                this.State.Set("GroupHeaderTplString", value);
            }
        }

        private XTemplate groupHeaderTpl;

        /// <summary>
        /// A string Template snippet, an array of strings (optionally followed by an object containing Template methods) to be used to construct a Template, or a Template instance. Defaults to: "{columnName}: {name}"
        /// groupField : String
        ///     The field name being grouped by.
        /// columnName : String
        ///     The column header associated with the field being grouped by if there is a column for the field, falls back to the groupField name.
        /// groupValue : Mixed
        ///     The value of the groupField for the group header being rendered.
        /// renderedGroupValue : String
        ///     The rendered value of the groupField for the group header being rendered, as produced by the column renderer.
        /// name : String
        ///     An alias for renderedGroupValue
        /// rows : Object[]
        ///     An array of child row data objects as returned by the View's prepareData method.
        /// children : Ext.data.Model[]
        ///     An array containing the child records for the group being rendered.
        /// </summary>
        [Category("3. TemplateColumn")]
        [ConfigOption("groupHeaderTpl", typeof(LazyControlJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A string Template snippet, an array of strings (optionally followed by an object containing Template methods) to be used to construct a Template, or a Template instance. Defaults to: \"{columnName}: {name}\"")]
        public virtual XTemplate GroupHeaderTpl
        {
            get
            {
                return this.groupHeaderTpl;
            }
            set
            {
                if (this.groupHeaderTpl != null && this.FeatureOwner != null)
                {
                    this.FeatureOwner.Controls.Remove(this.groupHeaderTpl);
                    this.FeatureOwner.LazyItems.Remove(this.groupHeaderTpl);
                }

                this.groupHeaderTpl = value;

                if (this.groupHeaderTpl != null && this.FeatureOwner != null)
                {
                    this.groupHeaderTpl.EnableViewState = false;
                    this.FeatureOwner.Controls.Add(this.groupHeaderTpl);
                    this.FeatureOwner.LazyItems.Add(this.groupHeaderTpl);
                }                
            }
        }

        /// <summary>
        /// True to hide the header that is currently grouped (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to hide the header that is currently grouped (defaults to false)")]
        public virtual bool HideGroupedHeader
        {
            get
            {
                return this.State.Get<bool>("HideGroupedHeader", false);
            }
            set
            {
                this.State.Set("HideGroupedHeader", value);
            }
        }

        /// <summary>
        /// Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').")]
        public virtual string ShowGroupsText
        {
            get
            {
                return this.State.Get<string>("ShowGroupsText", "");
            }
            set
            {
                this.State.Set("ShowGroupsText", value);
            }
        }

        /// <summary>
        /// True to start all groups collapsed (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to start all groups collapsed (defaults to false)")]
        public virtual bool StartCollapsed
        {
            get
            {
                return this.State.Get<bool>("StartCollapsed", false);
            }
            set
            {
                this.State.Set("StartCollapsed", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void FeatureAdded()
        {
            base.FeatureAdded();

            if (this.GroupHeaderTpl != null)
            {
                TablePanel panel = this.ParentComponent as TablePanel;

                if (panel != null)
                {
                    this.GroupHeaderTpl.EnableViewState = false;
                    panel.Controls.Add(this.GroupHeaderTpl);
                    panel.LazyItems.Add(this.GroupHeaderTpl);
                }
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal override void FeatureRemoved()
        {
            base.FeatureRemoved();

            if (this.GroupHeaderTpl != null)
            {
                TablePanel panel = this.ParentComponent as TablePanel;

                if (panel != null)
                {
                    panel.Controls.Remove(this.GroupHeaderTpl);
                    panel.LazyItems.Remove(this.GroupHeaderTpl);
                }
            }       
        }

        /// <summary>
        /// Collapse a group
        /// </summary>
        /// <param name="groupName">The group name</param>
        public virtual void Collapse(string groupName)
        {
            this.FeatureOwner.Call("getFeature(\""+this.FType+"\").collapse", groupName);
        }

        /// <summary>
        /// Expand a group
        /// </summary>
        /// <param name="groupName">The group name</param>
        public virtual void Expand(string groupName)
        {
            this.FeatureOwner.Call("getFeature(\"" + this.FType + "\").expand", groupName);
        }

        /// <summary>
        /// Expand all groups
        /// </summary>
        public virtual void ExpandAll()
        {
            this.FeatureOwner.Call("getFeature(\"" + this.FType + "\").expandAll");
        }

        /// <summary>
        /// Collapse all groups
        /// </summary>
        public virtual void CollapseAll()
        {
            this.FeatureOwner.Call("getFeature(\"" + this.FType + "\").collapseAll");
        }
    }
}
