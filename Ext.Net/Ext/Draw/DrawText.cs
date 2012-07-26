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
 ********/using System;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This class encapsulates a drawn text item as rendered by the Ext.draw package within a Component which can be then used anywhere in an ExtJS application just like any other Component.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:DrawText runat=\"server\"></{0}:DrawText>")]
    public partial class DrawText : DrawComponent
    {
        /// <summary>
        /// 
        /// </summary>
        public DrawText()
        {
        }

        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "text";
            }
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
                return "Ext.draw.Text";
            }
        }

        /// <summary>
        /// Turn on autoSize support which will set the bounding div's size to the natural size of the contents. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DrawText")]
        [DefaultValue(true)]
        [Description("Turn on autoSize support which will set the bounding div's size to the natural size of the contents. Defaults to true.")]
        public override bool AutoSize
        {
            get
            {
                return this.State.Get<bool>("AutoSize", true);
            }
            set
            {
                this.State.Set("AutoSize", value);
            }
        }

        /// <summary>
        /// The angle by which to initially rotate the text clockwise. Defaults to zero.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetAngle")]
        [Category("5. DrawText")]
        [DefaultValue(0)]
        [Description("The angle by which to initially rotate the text clockwise. Defaults to zero.")]
        public virtual int Degrees
        {
            get
            {
                return this.State.Get<int>("Degrees", 0);
            }
            set
            {
                this.State.Set("Degrees", value);
            }
        }

        /// <summary>
        /// A CSS selector string which matches a style rule in the document stylesheet from which the text's font properties are read.
        /// Drawn text is not styled by CSS, but by properties set during its construction, so these styles must be programatically read from a stylesheet rule found via a selector at construction time.
        /// The following properties will be applied from the rule:
        ///  - fontFamily
        ///  - fontWeight
        ///  - lineHeight
        ///  - fontSize
        ///  - color
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DrawText")]
        [DefaultValue("")]
        [Description("A CSS selector string which matches a style rule in the document stylesheet from which the text's font properties are read.")]
        public virtual string StyleSelector
        {
            get
            {
                return this.State.Get<string>("StyleSelector", "");
            }
            set
            {
                this.State.Set("StyleSelector", value);
            }
        }

        /// <summary>
        /// The text to display (html tags are not accepted)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName="SetText")]
        [Category("5. DrawText")]
        [DefaultValue("")]
        [Description("The text to display (html tags are not accepted)")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        private SpriteAttributes textStyle;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes TextStyle
        {
            get
            {
                return this.textStyle;
            }
            set
            {
                this.textStyle = value;
            }
        }

        /// <summary>
        /// Sets the clockwise rotation angle relative to the horizontal axis.
        /// </summary>
        /// <param name="text">The clockwise angle (in degrees) from the horizontal axis by which the text should be rotated.</param>
        protected virtual void SetAngle(int angle)
        {
            this.Call("setAngle", angle);
        }

        /// <summary>
        /// Updates this item's text.
        /// </summary>
        /// <param name="text">The text to display (html not accepted).</param>
        protected virtual void SetText(string text)
        {
            this.Call("setText", text);
        }
    }
}