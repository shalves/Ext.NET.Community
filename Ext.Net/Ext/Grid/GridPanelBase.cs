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
using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class GridPanelBase : TablePanel, IStore<Store>, INoneContentable
    {
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool SelectionSubmit
        {
            get
            {
                return this.State.Get<bool>("SelectionSubmit", true);
            }
            set
            {
                this.State.Set("SelectionSubmit", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool SelectionMemory
        {
            get
            {
                return this.State.Get<bool>("SelectionMemory", true);
            }
            set
            {
                this.State.Set("SelectionMemory", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool SelectionMemoryEvents
        {
            get
            {
                return this.State.Get<bool>("SelectionMemoryEvents", true);
            }
            set
            {
                this.State.Set("SelectionMemoryEvents", value);
            }
        }

        /// <summary>
        /// Synchronize rowHeight between the normal and locked grid view. This is turned on by default. If your grid is guaranteed to have rows of all the same height, you should set this to false to optimize performance. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Synchronize rowHeight between the normal and locked grid view. This is turned on by default. If your grid is guaranteed to have rows of all the same height, you should set this to false to optimize performance. ")]
        public virtual bool SyncRowHeight
        {
            get
            {
                return this.State.Get<bool>("SyncRowHeight", true);
            }
            set
            {
                this.State.Set("SyncRowHeight", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("Lock")]
        [Description("")]
        public virtual string LockText
        {
            get
            {
                return this.State.Get<string>("LockText", "Lock");
            }
            set
            {
                this.State.Set("LockText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("Unlock")]
        [Description("")]
        public virtual string UnlockText
        {
            get
            {
                return this.State.Get<string>("UnlockText", "Unlock");
            }
            set
            {
                this.State.Set("UnlockText", value);
            }
        }

        private ViewCollection<GridView> lockedViewConfig;

        /// <summary>
        /// A view configuration to be applied to the locked side of the grid. Any conflicting configurations between lockedViewConfig and viewConfig will be overwritten by the lockedViewConfig. 
        /// </summary>
        [Meta]
        [ConfigOption("lockedViewConfig>View")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A view configuration to be applied to the locked side of the grid. Any conflicting configurations between lockedViewConfig and viewConfig will be overwritten by the lockedViewConfig.")]
        public virtual ViewCollection<GridView> LockedView
        {
            get
            {
                if (this.lockedViewConfig == null)
                {
                    this.lockedViewConfig = new ViewCollection<GridView>();
                    this.lockedViewConfig.AfterItemAdd += this.AfterItemAdd;
                    this.lockedViewConfig.AfterItemRemove += this.AfterItemRemove;
                }

                return this.lockedViewConfig;
            }
        }

        private ViewCollection<GridView> normalViewConfig;

        /// <summary>
        /// A view configuration to be applied to the normal/unlocked side of the grid. Any conflicting configurations between normalViewConfig and viewConfig will be overwritten by the normalViewConfig. 
        /// </summary>
        [Meta]
        [ConfigOption("normalViewConfig>View")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A view configuration to be applied to the normal/unlocked side of the grid. Any conflicting configurations between normalViewConfig and viewConfig will be overwritten by the normalViewConfig. ")]
        public virtual ViewCollection<GridView> NormalView
        {
            get
            {
                if (this.normalViewConfig == null)
                {
                    this.normalViewConfig = new ViewCollection<GridView>();
                    this.normalViewConfig.AfterItemAdd += this.AfterItemAdd;
                    this.normalViewConfig.AfterItemRemove += this.AfterItemRemove;
                }

                return this.normalViewConfig;
            }
        }
        
        private ViewCollection<GridView> view;

        /// <summary>
        /// The Ext.grid.View used by the grid. This can be set before a call to render().
        /// </summary>
        [Meta]
        [ConfigOption("viewConfig>View")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.grid.View used by the grid. This can be set before a call to render().")]
        public virtual ViewCollection<GridView> View
        {
            get
            {
                if (this.view == null)
                {
                    this.view = new ViewCollection<GridView>();
                    this.view.AfterItemAdd += this.AfterItemAdd;
                    this.view.AfterItemRemove += this.AfterItemRemove;
                }

                return this.view;
            }
        }

        private GridScrollerCollection verticalScroller;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("verticalScroller>Scroller")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual GridScrollerCollection VerticalScroller
        {
            get
            {
                if (this.verticalScroller == null)
                {
                    this.verticalScroller = new GridScrollerCollection();
                    this.verticalScroller.AfterItemAdd += this.AfterItemAdd;
                    this.verticalScroller.AfterItemRemove += this.AfterItemRemove;
                }

                return this.verticalScroller;
            }
        }

        /// <summary>
        /// Returns a GridPanel's View
        /// </summary>
        public GridView GetView()
        {
            return this.View.View;
        }

        private StoreCollection<Store> store;

        /// <summary>
        /// The Ext.Net.Store the grid should use as its data source (required).
        /// </summary>
        [Meta]
        [ConfigOption("store>Primary", 1)]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.Net.Store the grid should use as its data source (required).")]
        public virtual StoreCollection<Store> Store
        {
            get
            {
                if (this.store == null)
                {
                    this.store = new StoreCollection<Store>();
                    this.store.AfterItemAdd += this.AfterStoreAdd;
                    this.store.AfterItemRemove += this.AfterItemRemove;
                }

                return this.store;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterStoreAdd(Store item)
        {
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Store GetStore()
        {
            if (this.Store.Primary != null)
            {
                return this.Store.Primary;
            }

            if (this.StoreID.IsNotEmpty())
            {
                return ControlUtils.FindControl<Store>(this, this.StoreID, true);
            }

            return null;
        }

        ItemsCollection<GridFeature> features;

        /// <summary>
        /// An array of grid features
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ItemCollectionJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of grid features")]
        public virtual ItemsCollection<GridFeature> Features
        {
            get
            {
                if (this.features == null)
                {
                    this.features = new ItemsCollection<GridFeature>();
                    this.features.AfterItemAdd += this.AfterFeatureAdd;
                    this.features.AfterItemRemove += this.AfterFeatureRemove;
                }

                return this.features;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        protected virtual void AfterFeatureAdd(GridFeature feature)
        {
            this.Controls.Add(feature);
            this.LazyItems.Add(feature);
            feature.FeatureAdded();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        protected virtual void AfterFeatureRemove(GridFeature feature)
        {
            this.Controls.Remove(feature);
            this.LazyItems.Remove(feature);
            feature.FeatureRemoved();
        }      
    }
}