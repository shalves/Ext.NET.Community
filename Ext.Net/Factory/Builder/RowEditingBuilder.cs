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
    public partial class RowEditing
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TRowEditing, TBuilder> : GridEditing.Builder<TRowEditing, TBuilder>
            where TRowEditing : RowEditing
            where TBuilder : Builder<TRowEditing, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TRowEditing component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true to automatically cancel any pending changes when the row editor begins editing a new row. false to force the user to explicitly cancel the pending changes. Defaults to true.
			/// </summary>
            public virtual TBuilder AutoCancel(bool autoCancel)
            {
                this.ToComponent().AutoCancel = autoCancel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of clicks to move the row editor to a new row while it is visible and actively editing another row. This will default to the same value as clicksToEdit.
			/// </summary>
            public virtual TBuilder ClicksToMoveEditor(int clicksToMoveEditor)
            {
                this.ToComponent().ClicksToMoveEditor = clicksToMoveEditor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to show a tooltip that summarizes all validation errors present in the row editor. Set to false to prevent the tooltip from showing. Defaults to true.
			/// </summary>
            public virtual TBuilder ErrorSummary(bool errorSummary)
            {
                this.ToComponent().ErrorSummary = errorSummary;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SaveBtnText(string saveBtnText)
            {
                this.ToComponent().SaveBtnText = saveBtnText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CancelBtnText(string cancelBtnText)
            {
                this.ToComponent().CancelBtnText = cancelBtnText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ErrorsText(string errorsText)
            {
                this.ToComponent().ErrorsText = errorsText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DirtyText(string dirtyText)
            {
                this.ToComponent().DirtyText = dirtyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function called when the save button is clicked
			/// </summary>
            public virtual TBuilder SaveHandler(string saveHandler)
            {
                this.ToComponent().SaveHandler = saveHandler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<RowEditingListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<RowEditingDirectEvents> action)
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
        public partial class Builder : RowEditing.Builder<RowEditing, RowEditing.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RowEditing()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowEditing component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowEditing.Config config) : base(new RowEditing(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RowEditing component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public RowEditing.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RowEditing(this);
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
        public RowEditing.Builder RowEditing()
        {
#if MVC
			return this.RowEditing(new RowEditing { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.RowEditing(new RowEditing());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public RowEditing.Builder RowEditing(RowEditing component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new RowEditing.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RowEditing.Builder RowEditing(RowEditing.Config config)
        {
#if MVC
			return new RowEditing.Builder(new RowEditing(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new RowEditing.Builder(new RowEditing(config));
#endif			
        }
    }
}