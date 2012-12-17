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
using System.Web.UI.WebControls;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    [Meta]
    [Description("")]
    public partial class ListFilter : GridFilter
    {
        public ListFilter() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. ListFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.List;
            }
        }

        /// <summary>
        /// Defaults to 'id'.
        /// </summary>
        [Meta]
        [ConfigOption("idField")]
        [Category("3. ListFilter")]
        [DefaultValue("id")]
        [NotifyParentProperty(true)]
        [Description("Defaults to 'id'.")]
        public string IDField
        {
            get
            {
                return this.State.Get<string>("IDField", "id");
            }
            set
            {
                this.State.Set("IDField", value);
            }
        }

        /// <summary>
        /// The loading text displayed when data loading
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ListFilter")]
        [DefaultValue("Loading...")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The loading text displayed when data loading")]
        public string LoadingText
        {
            get
            {
                return this.State.Get<string>("LoadingText", "Loading...");
            }
            set
            {
                this.State.Set("LoadingText", value);
            }
        }

        /// <summary>
        /// If true then the data loading on show
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ListFilter")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("If true then the data loading on show")]
        public bool LoadOnShow
        {
            get
            {
                return this.State.Get<bool>("LoadOnShow", true);
            }
            set
            {
                this.State.Set("LoadOnShow", value);
            }
        }

        /// <summary>
        /// Specify true to group all items in this list into a single-select radio button group. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ListFilter")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Specify true to group all items in this list into a single-select radio button group. Defaults to false.")]
        public bool Single
        {
            get
            {
                return this.State.Get<bool>("Single", false);
            }
            set
            {
                this.State.Set("Single", value);
            }
        }

        /// <summary>
        /// The list of options
        /// </summary>
        [Meta]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of options")]
        public virtual string[] Options
        {
            get
            {
                return this.State.Get<string[]>("Options", null);
            }
            set
            {
                this.State.Set("Options", value);
            }
        }

        /// <summary>
        /// The list of options
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of options")]
        public virtual string[] Value
        {
            get
            {
                return this.State.Get<string[]>("Value", null);
            }
            set
            {
                this.State.Set("Value", value);
            }
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]        
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return this.State.Get<string>("StoreID", "");
            }
            set
            {
                this.State.Set("StoreID", value);
            }
        }

        /// <summary>
        /// Defaults to 'text'.
        /// </summary>
        [Meta]
        [DefaultValue("text")]
        public virtual string LabelField
        {
            get
            {
                return this.State.Get<string>("LabelField", "text");
            }
            set
            {
                this.State.Set("LabelField", value);
            }
        }

        private Menu menuConfig;

        /// <summary>
        /// The config of the ListFilter menu. Defaults to null.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("menuConfig", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("The config of the ListFilter menu. Defaults to null.")]
        public virtual Menu MenuConfig
        {
            get
            {
                return this.menuConfig;
            }
            set
            {
                GridPanel grid = this.ParentGrid;
                
                if (this.menuConfig != null)
                {
                    if (grid != null)
                    {
                        if (!grid.Controls.Contains(this.menuConfig))
                        {
                            grid.Controls.Remove(this.menuConfig);
                        }

                        if (!grid.LazyItems.Contains(this.menuConfig))
                        {
                            grid.LazyItems.Remove(this.menuConfig);
                        }
                    }
                }                                

                if (value != null)
                {
                    value.RenderEmptyMenu = true;
                    if (grid != null)
                    {
                        if (!grid.Controls.Contains(this.menuConfig))
                        {
                            grid.Controls.Add(this.menuConfig);
                        }

                        if (!grid.LazyItems.Contains(this.menuConfig))
                        {
                            grid.LazyItems.Add(this.menuConfig);
                        }
                    }
                }

                this.menuConfig = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("options", JsonMode.Raw)]
        [DefaultValue("")]
        protected internal string OptionsProxy
        {
            get
            {
                if (this.StoreID.IsEmpty() && this.Options != null && this.Options.Length > 0)
                {
                    return JSON.Serialize(this.Options);
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("store", JsonMode.Raw)]
        [DefaultValue("")]
        protected internal string StoreProxy
        {
            get
            {
                if (!this.StoreID.IsEmpty())
                {
                    return ControlUtils.FindControl(this.ParentGrid, this.StoreID).ClientID;
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("labelField")]
        [DefaultValue("text")]
        protected internal string LabelFieldProxy
        {
            get
            {
                if (!this.StoreID.IsEmpty())
                {
                    return this.LabelField;
                }

                return "text";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public void UpdateOptions(string[] options)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}.getFilter({1}).updateOptions({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(options));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(string[] value)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(value));
        }
    }
}