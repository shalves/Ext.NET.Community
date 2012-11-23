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
 ********/using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ext.Net.Utilities;

namespace Ext.Net
{
    [Meta]
    public partial class StartupMask : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(250)]
        public virtual int HideDelay
        {
            get
            {
                return this.State.Get<int>("HideDelay", 250);
            }
            set
            {
                this.State.Set("HideDelay", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(1000)]
        public virtual int FadeOutDuration
        {
            get
            {
                return this.State.Get<int>("FadeOutDuration", 1000);
            }
            set
            {
                this.State.Set("FadeOutDuration", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]        
        [DefaultValue("")]        
        public virtual string ImageUrl
        {
            get
            {
                return this.State.Get<string>("ImageUrl", "");
            }
            set
            {
                this.State.Set("ImageUrl", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("Loading, please wait...")]
        public virtual string Message
        {
            get
            {
                return this.State.Get<string>("Message", "Loading, please wait...");
            }
            set
            {
                this.State.Set("Message", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string LoadingMaskCls
        {
            get
            {
                return this.State.Get<string>("LoadingMaskCls", "");
            }
            set
            {
                this.State.Set("LoadingMaskCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string LoadingMaskStyle
        {
            get
            {
                return this.State.Get<string>("LoadingMaskStyle", "");
            }
            set
            {
                this.State.Set("LoadingMaskStyle", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string LoadingContainerCls
        {
            get
            {
                return this.State.Get<string>("LoadingContainerCls", "");
            }
            set
            {
                this.State.Set("LoadingContainerCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string LoadingContainerStyle
        {
            get
            {
                return this.State.Get<string>("LoadingContainerStyle", "");
            }
            set
            {
                this.State.Set("LoadingContainerStyle", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string LoadingIndicatorCls
        {
            get
            {
                return this.State.Get<string>("LoadingIndicatorCls", "");
            }
            set
            {
                this.State.Set("LoadingIndicatorCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string LoadingIndicatorStyle
        {
            get
            {
                return this.State.Get<string>("LoadingIndicatorStyle", "");
            }
            set
            {
                this.State.Set("LoadingIndicatorStyle", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string ImageCls
        {
            get
            {
                return this.State.Get<string>("ImageCls", "");
            }
            set
            {
                this.State.Set("ImageCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string ImageStyle
        {
            get
            {
                return this.State.Get<string>("ImageStyle", "");
            }
            set
            {
                this.State.Set("ImageStyle", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string MessageCls
        {
            get
            {
                return this.State.Get<string>("MessageCls", "");
            }
            set
            {
                this.State.Set("MessageCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        public virtual string MessageStyle
        {
            get
            {
                return this.State.Get<string>("MessageStyle", "");
            }
            set
            {
                this.State.Set("MessageStyle", value);
            }
        }

        public virtual string BuildHtml()
        {
            string html = "<div class=\"start-loading-mask mask-el{0}\"{1}></div><div class=\"start-loading mask-el{2}\"{3}><div class=\"loading-indicator{4}\"{5}><img {6}{7} src=\"{10}\" align=\"middle\" /><p{8}{9}>{11}</p></div></div>";

            return string.Format(html, 
                this.LoadingMaskCls.IsNotEmpty() ? " " + this.LoadingMaskCls : "",
                this.LoadingMaskStyle.IsNotEmpty() ? " style=\"" + this.LoadingMaskStyle + "\"" : "",
                this.LoadingContainerCls.IsNotEmpty() ? " " + this.LoadingContainerCls : "",
                this.LoadingContainerStyle.IsNotEmpty() ? " style=\"" + this.LoadingContainerStyle + "\"" : "",
                this.LoadingIndicatorCls.IsNotEmpty() ? " " + this.LoadingIndicatorCls : "",
                this.LoadingIndicatorStyle.IsNotEmpty() ? " style=\"" + this.LoadingIndicatorStyle + "\"" : "",
                this.ImageCls.IsNotEmpty() ? " class=\"" + this.ImageCls + "\"" : "",
                this.ImageStyle.IsNotEmpty() ? " style=\"" + this.ImageStyle + "\"" : "",
                this.MessageCls.IsNotEmpty() ? " class=\"" + this.MessageCls + "\"" : "",
                this.MessageStyle.IsNotEmpty() ? " style=\"" + this.MessageStyle + "\"" : "",
                this.ImageUrl.IsNotEmpty() ? ExtNetTransformer.ResolveUrl(this.ImageUrl) : ExtNetTransformer.GetWebResourceUrl(typeof(ResourceManager), "Ext.Net.Build.Ext.Net.extnet.resources.images.start-loading.gif"),
                this.Message
           );
        }

        public virtual string BuildCss()
        {
            return ".start-loading-mask{position:absolute;left:0;top:0;width:100%;height:100%;z-index:20000;background-color:#fff}.start-loading{position:absolute;left:50%;top:50%;width:140px;height:120px;margin:-60px 0 0 -70px;z-index:20001}.start-loading img{margin-left:20px;width:100px;height:100px}.start-loading .loading-indicator p{color:#555;font:700 13px tahoma,arial,helvetica;padding:10px;margin:0;text-align:center;height:auto}";
        }

        public virtual string BuildScript()
        {
            return string.Format("Ext.onReady(function(){{setTimeout(function(){{Ext.select('.mask-el').fadeOut({{remove:true, duration: {0}}});}}, {1});}});", this.FadeOutDuration, this.HideDelay);
        }
    }
}