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
    public partial class MouseDistanceSensor
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TMouseDistanceSensor, TBuilder> : Plugin.Builder<TMouseDistanceSensor, TBuilder>
            where TMouseDistanceSensor : MouseDistanceSensor
            where TBuilder : Builder<TMouseDistanceSensor, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMouseDistanceSensor component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Threshold(int threshold)
            {
                this.ToComponent().Threshold = threshold;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Opacity(bool opacity)
            {
                this.ToComponent().Opacity = opacity;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MinOpacity(decimal minOpacity)
            {
                this.ToComponent().MinOpacity = minOpacity;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MaxOpacity(decimal maxOpacity)
            {
                this.ToComponent().MaxOpacity = maxOpacity;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SensorElement(string sensorElement)
            {
                this.ToComponent().SensorElement = sensorElement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ConstrainElement(string constrainElement)
            {
                this.ToComponent().ConstrainElement = constrainElement;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : MouseDistanceSensor.Builder<MouseDistanceSensor, MouseDistanceSensor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MouseDistanceSensor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MouseDistanceSensor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MouseDistanceSensor.Config config) : base(new MouseDistanceSensor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MouseDistanceSensor component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MouseDistanceSensor(this);
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
        public MouseDistanceSensor.Builder MouseDistanceSensor()
        {
#if MVC
			return this.MouseDistanceSensor(new MouseDistanceSensor { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.MouseDistanceSensor(new MouseDistanceSensor());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor.Builder MouseDistanceSensor(MouseDistanceSensor component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new MouseDistanceSensor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor.Builder MouseDistanceSensor(MouseDistanceSensor.Config config)
        {
#if MVC
			return new MouseDistanceSensor.Builder(new MouseDistanceSensor(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new MouseDistanceSensor.Builder(new MouseDistanceSensor(config));
#endif			
        }
    }
}