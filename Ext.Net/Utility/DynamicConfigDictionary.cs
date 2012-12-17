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
#if NET40
using System.Dynamic;
#endif
using System.Collections.Generic;

namespace Ext.Net
{
#if NET40
    public partial class DynamicConfigDictionary : DynamicObject
    {
        private Dictionary<string, object> config;

        public DynamicConfigDictionary()
        {
        }

        private Dictionary<string, object> Config
        {
            get
            {                
                return this.config ?? (this.config = new Dictionary<string, object>());
            }
        }

        // Implementing this function improves the debugging experience as it provides the debugger with the list of all
        // the properties currently defined on the object
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.Config.Keys;
        }

        public virtual object GetDynamicValue(string key)
        {
            return this.Config[key];
        }

        public virtual void SetDynamicValue(string key, object value)
        {
            this.Config[key] = value;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (this.Config.ContainsKey(binder.Name))
            {
                result = this.Config[binder.Name];
            }
            else
            {
                result = null;
            }

            return true;            
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.Config[binder.Name] = value;
            return true;
        }

    }
#else
    public partial class DynamicConfigDictionary 
    { 
    }
#endif
}