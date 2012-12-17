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
    public partial class NumericAxis
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TNumericAxis, TBuilder> : Axis.Builder<TNumericAxis, TBuilder>
            where TNumericAxis : NumericAxis
            where TBuilder : Builder<TNumericAxis, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TNumericAxis component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If true, the values of the chart will be rendered only if they belong between minimum and maximum If false, all values of the chart will be rendered, regardless of whether they belong between minimum and maximum or not Default's true if maximum and minimum is specified. Defaults to: true
			/// </summary>
            public virtual TBuilder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Where to set the axis. Available options are left, bottom, right, top. Default's left.
			/// </summary>
            public virtual TBuilder Position(Position position)
            {
                this.ToComponent().Position = position;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Indicates whether to extend maximum beyond data's maximum to the nearest majorUnit. Defaults to: false
			/// </summary>
            public virtual TBuilder AdjustMaximumByMajorUnit(bool adjustMaximumByMajorUnit)
            {
                this.ToComponent().AdjustMaximumByMajorUnit = adjustMaximumByMajorUnit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Indicates whether to extend the minimum beyond data's minimum to the nearest majorUnit. Defaults to: false
			/// </summary>
            public virtual TBuilder AdjustMinimumByMajorUnit(bool adjustMinimumByMajorUnit)
            {
                this.ToComponent().AdjustMinimumByMajorUnit = adjustMinimumByMajorUnit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RoundToDecimal(bool roundToDecimal)
            {
                this.ToComponent().RoundToDecimal = roundToDecimal;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of decimals to round the value to. Default's 2.
			/// </summary>
            public virtual TBuilder Decimals(int decimals)
            {
                this.ToComponent().Decimals = decimals;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value drawn by the axis. If not set explicitly, the axis maximum will be calculated automatically.
			/// </summary>
            public virtual TBuilder Maximum(double? maximum)
            {
                this.ToComponent().Maximum = maximum;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value drawn by the axis. If not set explicitly, the axis minimum will be calculated automatically.
			/// </summary>
            public virtual TBuilder Minimum(double? minimum)
            {
                this.ToComponent().Minimum = minimum;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : NumericAxis.Builder<NumericAxis, NumericAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new NumericAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumericAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumericAxis.Config config) : base(new NumericAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(NumericAxis component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.NumericAxis(this);
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
        public NumericAxis.Builder NumericAxis()
        {
#if MVC
			return this.NumericAxis(new NumericAxis { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.NumericAxis(new NumericAxis());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis(NumericAxis component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new NumericAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis(NumericAxis.Config config)
        {
#if MVC
			return new NumericAxis.Builder(new NumericAxis(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new NumericAxis.Builder(new NumericAxis(config));
#endif			
        }
    }
}