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
 * @version   : 2.0.0.rc2 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RowEditing(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RowEditing.Config Conversion to RowEditing
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RowEditing(RowEditing.Config config)
        {
            return new RowEditing(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridEditing.Config 
        { 
			/*  Implicit RowEditing.Config Conversion to RowEditing.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RowEditing.Builder(RowEditing.Config config)
			{
				return new RowEditing.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoCancel = true;

			/// <summary>
			/// true to automatically cancel any pending changes when the row editor begins editing a new row. false to force the user to explicitly cancel the pending changes. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoCancel 
			{ 
				get
				{
					return this.autoCancel;
				}
				set
				{
					this.autoCancel = value;
				}
			}

			private int clicksToMoveEditor = 0;

			/// <summary>
			/// The number of clicks to move the row editor to a new row while it is visible and actively editing another row. This will default to the same value as clicksToEdit.
			/// </summary>
			[DefaultValue(0)]
			public virtual int ClicksToMoveEditor 
			{ 
				get
				{
					return this.clicksToMoveEditor;
				}
				set
				{
					this.clicksToMoveEditor = value;
				}
			}

			private bool errorSummary = true;

			/// <summary>
			/// true to show a tooltip that summarizes all validation errors present in the row editor. Set to false to prevent the tooltip from showing. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ErrorSummary 
			{ 
				get
				{
					return this.errorSummary;
				}
				set
				{
					this.errorSummary = value;
				}
			}

			private string saveBtnText = "Update";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Update")]
			public virtual string SaveBtnText 
			{ 
				get
				{
					return this.saveBtnText;
				}
				set
				{
					this.saveBtnText = value;
				}
			}

			private string cancelBtnText = "Cancel";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Cancel")]
			public virtual string CancelBtnText 
			{ 
				get
				{
					return this.cancelBtnText;
				}
				set
				{
					this.cancelBtnText = value;
				}
			}

			private string errorsText = "Errors";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Errors")]
			public virtual string ErrorsText 
			{ 
				get
				{
					return this.errorsText;
				}
				set
				{
					this.errorsText = value;
				}
			}

			private string dirtyText = "You need to commit or cancel your changes";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("You need to commit or cancel your changes")]
			public virtual string DirtyText 
			{ 
				get
				{
					return this.dirtyText;
				}
				set
				{
					this.dirtyText = value;
				}
			}

			private string saveHandler = "";

			/// <summary>
			/// A function called when the save button is clicked
			/// </summary>
			[DefaultValue("")]
			public virtual string SaveHandler 
			{ 
				get
				{
					return this.saveHandler;
				}
				set
				{
					this.saveHandler = value;
				}
			}
        
			private RowEditingListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public RowEditingListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new RowEditingListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private RowEditingDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public RowEditingDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new RowEditingDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}