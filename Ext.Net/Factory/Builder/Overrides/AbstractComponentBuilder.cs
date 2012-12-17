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
using System.Web.UI.WebControls;
using System.Web;
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class AbstractComponent
    {
        new public abstract partial class Builder<TAbstractComponent, TBuilder> : Observable.Builder<TAbstractComponent, TBuilder>
            where TAbstractComponent : AbstractComponent
            where TBuilder : Builder<TAbstractComponent, TBuilder>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="content"></param>
            /// <returns></returns>
            public virtual TBuilder Content(Func<object, object> content)
            {
                BaseControl.SectionsStack.Push(null);
                ResourceManager.ScriptOrderNextRange();
                var result = content(null);
                this.ToComponent().ContentControls.Add(new LiteralControl(result.ToString()));
                ResourceManager.ScriptOrderPrevRange();
                BaseControl.SectionsStack.Pop();
                return this as TBuilder;
            }

            /// <summary>
            /// An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to '')
            /// </summary>
            public virtual TBuilder Html(Func<object, object> html)
            {
                BaseControl.SectionsStack.Push(null);
                ResourceManager.ScriptOrderNextRange();
                var result = html(null);
                this.ToComponent().Html = result.ToString();
                ResourceManager.ScriptOrderPrevRange();
                BaseControl.SectionsStack.Pop();
                return this as TBuilder;
            }

            /// <summary>
            /// The width of this component in pixels.
            /// </summary>
            public virtual TBuilder Width(int width)
            {
                this.ToComponent().Width = Unit.Pixel(width);
                return this as TBuilder;
            }

            /// <summary>
            /// The width of this component in pixels.
            /// </summary>
            public virtual TBuilder Height(int height)
            {
                this.ToComponent().Height = Unit.Pixel(height);
                return this as TBuilder;
            }

            /// <summary>
            /// The page level x coordinate for this component if contained within a positioning container.
            /// </summary>
            public virtual TBuilder PageX(int pageX)
            {
                this.ToComponent().PageX = Unit.Pixel(pageX);
                return this as TBuilder;
            }

            /// <summary>
            /// The page level y coordinate for this component if contained within a positioning container.
            /// </summary>
            public virtual TBuilder PageY(int pageY)
            {
                this.ToComponent().PageY = Unit.Pixel(pageY);
                return this as TBuilder;
            }

            /// <summary>
            /// An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.AbstractComponent. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
            /// </summary>
            /// <param name="plugin">plugin</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Plugins(Plugin plugin)
            {
                this.ToComponent().Plugins.Add(plugin);
                return this as TBuilder;
            }

            /// <summary>
            /// An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.AbstractComponent. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
            /// </summary>
            /// <param name="plugins">plugins</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Plugins(params Plugin[] plugins)
            {
                this.ToComponent().Plugins.AddRange(plugins);
                return this as TBuilder;
            }

            /// <summary>
            /// An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.AbstractComponent. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
            /// </summary>
            /// <param name="plugins">plugins</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Plugins(IEnumerable<Plugin> plugins)
            {
                this.ToComponent().Plugins.AddRange(plugins);
                return this as TBuilder;
            }

            public virtual TBuilder Bin(params Observable[] items)
            {
                this.ToComponent().Bin.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder Bin(IEnumerable<Observable> items)
            {
                this.ToComponent().Bin.AddRange(items);
                return this as TBuilder;
            }
        }
    }
}