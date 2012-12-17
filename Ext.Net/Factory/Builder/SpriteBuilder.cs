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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Sprite
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TSprite, TBuilder> : SpriteAttributes.Builder<TSprite, TBuilder>
            where TSprite : Sprite
            where TBuilder : Builder<TSprite, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSprite component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SpriteID(string spriteID)
            {
                this.ToComponent().SpriteID = spriteID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to make the sprite draggable.
			/// </summary>
            public virtual TBuilder Draggable(bool draggable)
            {
                this.ToComponent().Draggable = draggable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Drag config object.
			/// </summary>
            public virtual TBuilder DraggableConfig(DragSource draggableConfig)
            {
                this.ToComponent().DraggableConfig = draggableConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The group that this sprite belongs to, or an array of groups. Only relevant when added to a Ext.draw.Surface
			/// </summary>
            public virtual TBuilder Group(string[] group)
            {
                this.ToComponent().Group = group;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<SpriteListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddCls(string className)
            {
                this.ToComponent().AddCls(className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddCls(string[] className)
            {
                this.ToComponent().AddCls(className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Animate(AnimConfig cfg)
            {
                this.ToComponent().Animate(cfg);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SequenceFx()
            {
                this.ToComponent().SequenceFx();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StopAnimation()
            {
                this.ToComponent().StopAnimation();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SyncFx()
            {
                this.ToComponent().SyncFx();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Destroy()
            {
                this.ToComponent().Destroy();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Hide(bool redraw)
            {
                this.ToComponent().Hide(redraw);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Hide()
            {
                this.ToComponent().Hide();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Redraw()
            {
                this.ToComponent().Redraw();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Remove()
            {
                this.ToComponent().Remove();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveCls(string className)
            {
                this.ToComponent().RemoveCls(className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveCls(string[] className)
            {
                this.ToComponent().RemoveCls(className);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetAttributes(Dictionary<string,object> attrs, bool redraw)
            {
                this.ToComponent().SetAttributes(attrs, redraw);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetAttributes(Dictionary<string, object> attrs)
            {
                this.ToComponent().SetAttributes(attrs);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetAttributes(SpriteAttributes attrs, bool redraw)
            {
                this.ToComponent().SetAttributes(attrs, redraw);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetAttributes(SpriteAttributes attrs)
            {
                this.ToComponent().SetAttributes(attrs);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetStyle(Dictionary<string, string> styles)
            {
                this.ToComponent().SetStyle(styles);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetStyle(string property, string value)
            {
                this.ToComponent().SetStyle(property, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Show(bool redraw)
            {
                this.ToComponent().Show(redraw);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Show()
            {
                this.ToComponent().Show();
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Sprite.Builder<Sprite, Sprite.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Sprite()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Sprite component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Sprite.Config config) : base(new Sprite(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Sprite component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Sprite(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder Sprite()
        {
#if MVC
			return this.Sprite(new Sprite { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Sprite(new Sprite());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder Sprite(Sprite component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Sprite.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Sprite.Builder Sprite(Sprite.Config config)
        {
#if MVC
			return new Sprite.Builder(new Sprite(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Sprite.Builder(new Sprite(config));
#endif			
        }
    }
}