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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// This class functions between siblings of a VBox or HBox layout to resize both immediate siblings.
    ///
    /// A Splitter will preserve the flex ratio of any flexed siblings it is required to resize. It does this by setting the flex property of all flexed siblings to equal their pixel size. The actual numerical flex property in the Components will change, but the ratio to the total flex value will be preserved.
    ///
    /// A Splitter may be configured to show a centered mini-collapse tool orientated to collapse the collapseTarget. The Splitter will then call that sibling Panel's collapse or expand method to perform the appropriate operation (depending on the sibling collapse state). To create the mini-collapse tool but take care of collapsing yourself, configure the splitter with performCollapse: false.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:BoxSplitter runat=\"server\" />")]
    [ToolboxBitmap(typeof(BoxSplitter), "Build.ToolboxIcons.Resizable.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("This class functions between siblings of a VBox or HBox layout to resize both immediate siblings.")]
    public partial class BoxSplitter : AbstractComponent
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public BoxSplitter() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.resizer.Splitter";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "splitter";
            }
        }

        /// <summary>
        /// True to enable dblclick to toggle expand and collapse on the collapseTarget Panel. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxSplitter")]
        [DefaultValue(true)]
        [Description("True to enable dblclick to toggle expand and collapse on the collapseTarget Panel. Defaults to: true")]
        public virtual bool CollapseOnDblClick
        {
            get
            {
                return this.State.Get<bool>("CollapseOnDblClick", true);
            }
            set
            {
                this.State.Set("CollapseOnDblClick", value);
            }
        }

        /// <summary>
        /// A string describing the relative position of the immediate sibling Panel to collapse. May be 'prev' or 'next'.
        /// Or the immediate sibling Panel to collapse.
        /// The orientation of the mini-collapse tool will be inferred from this setting.
        /// Note that only Panels may be collapsed.
        /// Defaults to: "next"
        /// </summary>
        [Meta]        
        [Category("4. BoxSplitter")]
        [DefaultValue(CollapseTarget.Default)]
        [Description("A string describing the relative position of the immediate sibling Panel to collapse.")]
        public virtual CollapseTarget CollapseTarget
        {
            get
            {
                return this.State.Get<CollapseTarget>("CollapseTarget", CollapseTarget.Default);
            }
            set
            {
                this.State.Set("CollapseTarget", value);
            }
        }

        /// <summary>
        /// A string describing the relative position of the immediate sibling Panel to collapse. May be 'prev' or 'next'.
        /// Or the immediate sibling Panel to collapse.
        /// The orientation of the mini-collapse tool will be inferred from this setting.
        /// Note that only Panels may be collapsed.
        /// Defaults to: "next"
        /// </summary>
        [Meta]
        [Category("4. BoxSplitter")]
        [DefaultValue("")]
        [Description("A string describing the relative position of the immediate sibling Panel to collapse.")]
        public virtual string CollapseTargetPanel
        {
            get
            {
                return this.State.Get<string>("CollapseTargetPanel", "");
            }
            set
            {
                this.State.Set("CollapseTargetPanel", value);
            }
        }

        [ConfigOption("collapseTarget")]
        [DefaultValue("")]
        protected virtual string CollapseTargetProxy
        {
            get
            {
                if (this.CollapseTargetPanel.IsNotEmpty())
                {
                    return this.CollapseTargetPanel;
                }

                return this.CollapseTarget != Ext.Net.CollapseTarget.Default ? this.CollapseTarget.ToString().ToLowerInvariant() : "";
            }
        }

        /// <summary>
        /// A class to add to the splitter when it is collapsed. See collapsible.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxSplitter")]
        [DefaultValue("")]
        [Description("A class to add to the splitter when it is collapsed. See collapsible.")]
        public virtual string CollapsedCls
        {
            get
            {
                return this.State.Get<string>("CollapsedCls", "");
            }
            set
            {
                this.State.Set("CollapsedCls", value);
            }
        }

        /// <summary>
        /// True to show a mini-collapse tool in the Splitter to toggle expand and collapse on the collapseTarget Panel. Defaults to the collapsible setting of the Panel. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxSplitter")]
        [DefaultValue(false)]
        [Description("True to show a mini-collapse tool in the Splitter to toggle expand and collapse on the collapseTarget Panel. Defaults to the collapsible setting of the Panel. Defaults to: false")]
        public virtual bool Collapsible
        {
            get
            {
                return this.State.Get<bool>("Collapsible", false);
            }
            set
            {
                this.State.Set("Collapsible", value);
            }
        }

        /// <summary>
        /// Provides a default maximum width or height for the two components that the splitter is between. Defaults to: 1000
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxSplitter")]
        [DefaultValue(1000)]
        [Description("Provides a default maximum width or height for the two components that the splitter is between. Defaults to: 1000")]
        public virtual int DefaultSplitMax
        {
            get
            {
                return this.State.Get<int>("DefaultSplitMax", 1000);
            }
            set
            {
                this.State.Set("DefaultSplitMax", value);
            }
        }

        /// <summary>
        /// Provides a default minimum width or height for the two components that the splitter is between. Defaults to: 40
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxSplitter")]
        [DefaultValue(40)]
        [Description("Provides a default minimum width or height for the two components that the splitter is between. Defaults to: 40")]
        public virtual int DefaultSplitMin
        {
            get
            {
                return this.State.Get<int>("DefaultSplitMin", 40);
            }
            set
            {
                this.State.Set("DefaultSplitMin", value);
            }
        }

        /// <summary>
        /// Set to false to prevent this Splitter's mini-collapse tool from managing the collapse state of the collapseTarget.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxSplitter")]
        [DefaultValue(true)]
        [Description("Set to false to prevent this Splitter's mini-collapse tool from managing the collapse state of the collapseTarget.")]
        public virtual bool PerformCollapse
        {
            get
            {
                return this.State.Get<bool>("PerformCollapse", true);
            }
            set
            {
                this.State.Set("PerformCollapse", value);
            }
        }
    }
}