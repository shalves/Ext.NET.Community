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
    public abstract partial class EventWindowBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractWindow.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string titleTextAdd = "Add Event";

			/// <summary>
			/// The title during event adding
			/// </summary>
			[DefaultValue("Add Event")]
			public virtual string TitleTextAdd 
			{ 
				get
				{
					return this.titleTextAdd;
				}
				set
				{
					this.titleTextAdd = value;
				}
			}

			private string titleTextEdit = "Edit Event";

			/// <summary>
			/// The title during event editing
			/// </summary>
			[DefaultValue("Edit Event")]
			public virtual string TitleTextEdit 
			{ 
				get
				{
					return this.titleTextEdit;
				}
				set
				{
					this.titleTextEdit = value;
				}
			}

			private Unit width = Unit.Pixel(600);

			/// <summary>
			/// The width of this component in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(typeof(Unit), "600")]
			public override Unit Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private string deletingMessage = "Deleting event...";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Deleting event...")]
			public virtual string DeletingMessage 
			{ 
				get
				{
					return this.deletingMessage;
				}
				set
				{
					this.deletingMessage = value;
				}
			}

			private string savingMessage = "Saving changes...";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Saving changes...")]
			public virtual string SavingMessage 
			{ 
				get
				{
					return this.savingMessage;
				}
				set
				{
					this.savingMessage = value;
				}
			}

			private bool resizable = false;

			/// <summary>
			/// True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).
			/// </summary>
			[DefaultValue(false)]
			public override bool Resizable 
			{ 
				get
				{
					return this.resizable;
				}
				set
				{
					this.resizable = value;
				}
			}

			private Alignment buttonAlign = Alignment.Left;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(Alignment.Left)]
			public override Alignment ButtonAlign 
			{ 
				get
				{
					return this.buttonAlign;
				}
				set
				{
					this.buttonAlign = value;
				}
			}

			private string calendarStoreID = "";

			/// <summary>
			/// The calendar store ID to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string CalendarStoreID 
			{ 
				get
				{
					return this.calendarStoreID;
				}
				set
				{
					this.calendarStoreID = value;
				}
			}

			private Unit height = Unit.Empty;

			/// <summary>
			/// The height of this component in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Height 
			{ 
				get
				{
					return this.height;
				}
				set
				{
					this.height = value;
				}
			}

        }
    }
}