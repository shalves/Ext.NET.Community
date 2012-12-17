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
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    [Meta]
    [Browsable(false)]
    [ToolboxItem(false)]
    public partial class MvcItem : AbstractComponent, ICustomConfigSerialization, IProxyContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public MvcItem()
        {
        }

        public MvcItem(Func<System.Web.IHtmlString> expression)
        {
            this.Expression = expression;
        }

        [Meta]
        [DefaultValue(null)]
        public Func<System.Web.IHtmlString> Expression
        {
            get;
            set;
        }

        protected virtual string Html
        {
            get;
            set;
        }

        protected virtual List<string> IDS
        {
            get;
            set;
        }

        protected virtual void Build()
        {
            if (this.Expression == null || this.Html != null)
            {
                return;
            }

            IHtmlString result;

            if (BaseControl.HasSections && (this.Parent == null || this.Parent is Page))
            {
                result = this.Expression();
                this.Html = result != null ? result.ToHtmlString() : "";
                return;
            }
            else if (this.IsLazy)
            {
                BaseControl.SectionsStack.Push(new List<string>());
                result = this.Expression();

                if (result != null)
                {
                    this.Html = result.ToHtmlString();
                    this.IDS = BaseControl.SectionsStack.Pop();
                    return;
                }

                BaseControl.SectionsStack.Pop();
                this.Html = "";
                return;
            }

            BaseControl.SectionsStack.Push(null);
            result = this.Expression();
            this.Html = result != null ? result.ToHtmlString() : "";
            BaseControl.SectionsStack.Pop();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            if (!this.DesignMode)
            {
                this.Build();
                writer.Write(this.Html);
            }
        }

        #region IProxyContainer

        List<string> IProxyContainer.GetIDS()
        {
            this.Build();
            return this.IDS;
        }

        #endregion

        #region ICustomConfigSerialization

        string ICustomConfigSerialization.ToScript(Control owner)
        {
            return "";
        }

        #endregion
    }
}