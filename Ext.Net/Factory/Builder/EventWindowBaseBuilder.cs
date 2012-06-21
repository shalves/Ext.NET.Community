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
 * @version   : 2.0.0.rc1 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
        public abstract partial class Builder<TEventWindowBase, TBuilder> : AbstractWindow.Builder<TEventWindowBase, TBuilder>
            where TEventWindowBase : EventWindowBase
            where TBuilder : Builder<TEventWindowBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TEventWindowBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The title during event adding
			/// </summary>
            public virtual TBuilder TitleTextAdd(string titleTextAdd)
            {
                this.ToComponent().TitleTextAdd = titleTextAdd;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The title during event editing
			/// </summary>
            public virtual TBuilder TitleTextEdit(string titleTextEdit)
            {
                this.ToComponent().TitleTextEdit = titleTextEdit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of this component in pixels (defaults to auto).
			/// </summary>
            public virtual TBuilder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DeletingMessage(string deletingMessage)
            {
                this.ToComponent().DeletingMessage = deletingMessage;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SavingMessage(string savingMessage)
            {
                this.ToComponent().SavingMessage = savingMessage;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).
			/// </summary>
            public virtual TBuilder Resizable(bool resizable)
            {
                this.ToComponent().Resizable = resizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ButtonAlign(Alignment buttonAlign)
            {
                this.ToComponent().ButtonAlign = buttonAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The calendar store ID to use.
			/// </summary>
            public virtual TBuilder CalendarStoreID(string calendarStoreID)
            {
                this.ToComponent().CalendarStoreID = calendarStoreID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The height of this component in pixels (defaults to auto).
			/// </summary>
            public virtual TBuilder Height(Unit height)
            {
                this.ToComponent().Height = height;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}