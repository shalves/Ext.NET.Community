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
    public partial class InputMask
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public InputMask(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit InputMask.Config Conversion to InputMask
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator InputMask(InputMask.Config config)
        {
            return new InputMask(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit InputMask.Config Conversion to InputMask.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator InputMask.Builder(InputMask.Config config)
			{
				return new InputMask.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool alwaysShow = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AlwaysShow 
			{ 
				get
				{
					return this.alwaysShow;
				}
				set
				{
					this.alwaysShow = value;
				}
			}

			private bool clearWhenInvalid = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClearWhenInvalid 
			{ 
				get
				{
					return this.clearWhenInvalid;
				}
				set
				{
					this.clearWhenInvalid = value;
				}
			}

			private bool allowInvalid = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowInvalid 
			{ 
				get
				{
					return this.allowInvalid;
				}
				set
				{
					this.allowInvalid = value;
				}
			}

			private string invalidMaskText = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string InvalidMaskText 
			{ 
				get
				{
					return this.invalidMaskText;
				}
				set
				{
					this.invalidMaskText = value;
				}
			}

			private string mask = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Mask 
			{ 
				get
				{
					return this.mask;
				}
				set
				{
					this.mask = value;
				}
			}
        
			private MaskSymbolCollection maskSymbols = null;

			/// <summary>
			/// 
			/// </summary>
			public MaskSymbolCollection MaskSymbols
			{
				get
				{
					if (this.maskSymbols == null)
					{
						this.maskSymbols = new MaskSymbolCollection();
					}
			
					return this.maskSymbols;
				}
			}
			
			private char placeholder = '_';

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue('_')]
			public virtual char Placeholder 
			{ 
				get
				{
					return this.placeholder;
				}
				set
				{
					this.placeholder = value;
				}
			}

			private bool unmaskOnBlur = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UnmaskOnBlur 
			{ 
				get
				{
					return this.unmaskOnBlur;
				}
				set
				{
					this.unmaskOnBlur = value;
				}
			}

        }
    }
}