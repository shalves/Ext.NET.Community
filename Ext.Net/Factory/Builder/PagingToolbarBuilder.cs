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
    public partial class PagingToolbar
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TPagingToolbar, TBuilder> : ToolbarBase.Builder<TPagingToolbar, TBuilder>
            where TPagingToolbar : PagingToolbar
            where TBuilder : Builder<TPagingToolbar, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TPagingToolbar component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to display the displayMsg (defaults to false).
			/// </summary>
            public virtual TBuilder DisplayInfo(bool displayInfo)
            {
                this.ToComponent().DisplayInfo = displayInfo;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The paging status message to display. Note that this string is formatted using the braced numbers {0}-{2} as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired. Defaults to: \"Displaying {0} - {1} of {2}\"
			/// </summary>
            public virtual TBuilder DisplayMsg(string displayMsg)
            {
                this.ToComponent().DisplayMsg = displayMsg;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The message to display when no records are found (defaults to 'No data to display').
			/// </summary>
            public virtual TBuilder EmptyMsg(string emptyMsg)
            {
                this.ToComponent().EmptyMsg = emptyMsg;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.data.Store the paging toolbar should use as its data source.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RefreshHandler(string refreshHandler)
            {
                this.ToComponent().RefreshHandler = refreshHandler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text. Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired. Defaults to: \"of {0}\"
			/// </summary>
            public virtual TBuilder AfterPageText(string afterPageText)
            {
                this.ToComponent().AfterPageText = afterPageText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text displayed before the input item. Defaults to: \"Page\"
			/// </summary>
            public virtual TBuilder BeforePageText(string beforePageText)
            {
                this.ToComponent().BeforePageText = beforePageText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the first page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"First Page\"
			/// </summary>
            public virtual TBuilder FirstText(string firstText)
            {
                this.ToComponent().FirstText = firstText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width in pixels of the input field used to display and change the current page number. Defaults to: 30
			/// </summary>
            public virtual TBuilder InputItemWidth(int inputItemWidth)
            {
                this.ToComponent().InputItemWidth = inputItemWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the last page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Last Page\"
			/// </summary>
            public virtual TBuilder LastText(string lastText)
            {
                this.ToComponent().LastText = lastText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the next page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Next Page\"
			/// </summary>
            public virtual TBuilder NextText(string nextText)
            {
                this.ToComponent().NextText = nextText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to insert any configured items before the paging buttons. Defaults to: false
			/// </summary>
            public virtual TBuilder PrependButtons(bool prependButtons)
            {
                this.ToComponent().PrependButtons = prependButtons;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the previous page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Previous Page\"
			/// </summary>
            public virtual TBuilder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The quicktip text displayed for the Refresh button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Refresh\"
			/// </summary>
            public virtual TBuilder RefreshText(string refreshText)
            {
                this.ToComponent().RefreshText = refreshText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Hide refresh button
			/// </summary>
            public virtual TBuilder HideRefresh(bool hideRefresh)
            {
                this.ToComponent().HideRefresh = hideRefresh;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<PagingToolbarListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<PagingToolbarDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : PagingToolbar.Builder<PagingToolbar, PagingToolbar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PagingToolbar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PagingToolbar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PagingToolbar.Config config) : base(new PagingToolbar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PagingToolbar component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PagingToolbar(this);
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
        public PagingToolbar.Builder PagingToolbar()
        {
#if MVC
			return this.PagingToolbar(new PagingToolbar { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.PagingToolbar(new PagingToolbar());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar(PagingToolbar component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new PagingToolbar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar(PagingToolbar.Config config)
        {
#if MVC
			return new PagingToolbar.Builder(new PagingToolbar(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new PagingToolbar.Builder(new PagingToolbar(config));
#endif			
        }
    }
}