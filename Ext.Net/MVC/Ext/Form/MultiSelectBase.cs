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
using System.ComponentModel;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ext.Net.Utilities;
using Ext.Net.MVC;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class MultiSelectBase
    {
        protected override void SetModelValue(object value)
        {
            if (value != null)
            {
                if (value != null && value.GetType().IsEnum)
                {
                    this.ItemsFromEnum = value.GetType();
                    this.SelectedItems.Add(new ListItem { Value = Convert.ChangeType(value, ((Enum)value).GetTypeCode()).ToString() });
                }
                else if (value is ListItem)
                {
                    this.SelectedItems.Add((ListItem)value);
                }
                else if (value is IEnumerable<ListItem>)
                {
                    this.SelectedItems.AddRange((IEnumerable<ListItem>)value);
                }
                else
                {
                    this.SelectedItems.Add(new ListItem { Value = value.ToString() });
                }
            }
        }

        protected override void SetModelValidationRule(ModelClientValidationRule rule)
        {
            base.SetModelValidationRule(rule);

            switch (rule.ValidationType)
            {
                case "required":
                    this.AllowBlank = false;
                    this.BlankText = rule.ErrorMessage;
                    break;
                case "range":
                    if (rule.ValidationParameters.ContainsKey("max"))
                    {
                        this.MaxSelections = (int)Convert.ChangeType(rule.ValidationParameters["max"], typeof(int));
                        this.MaxSelectionsText = rule.ErrorMessage;
                    }

                    if (rule.ValidationParameters.ContainsKey("min"))
                    {
                        this.MinSelections = (int)Convert.ChangeType(rule.ValidationParameters["min"], typeof(int));
                        this.MinSelectionsText = rule.ErrorMessage;
                    }
                    break;
            }
        }
    }
}