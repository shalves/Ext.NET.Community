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
 ********/using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public partial class ImageCommandColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TImageCommandColumn, TBuilder> : CellCommandColumn.Builder<TImageCommandColumn, TBuilder>
            where TImageCommandColumn : ImageCommandColumn
            where TBuilder : Builder<TImageCommandColumn, TBuilder>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="commands"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GroupCommands(params GroupImageCommand[] commands)
            {
                this.ToComponent().GroupCommands.AddRange(commands);
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="commands"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GroupCommands(IEnumerable<GroupImageCommand> commands)
            {
                this.ToComponent().GroupCommands.AddRange(commands);
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="handler"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PrepareGroupCommand(string handler)
            {
                if (JFunction.IsFunctionName(handler))
                {
                    this.ToComponent().PrepareGroupCommand.Fn = handler;
                }
                else
                {
                    this.ToComponent().PrepareGroupCommand.Handler = handler;
                }

                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="handler"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PrepareGroupCommands(string handler)
            {
                if (JFunction.IsFunctionName(handler))
                {
                    this.ToComponent().PrepareGroupCommands.Fn = handler;
                }
                else
                {
                    this.ToComponent().PrepareGroupCommands.Handler = handler;
                }

                return this as TBuilder;
            }
        }
    }
}