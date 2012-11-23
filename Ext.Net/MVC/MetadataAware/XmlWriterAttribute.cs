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
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;

namespace Ext.Net.MVC
{
    public partial class XmlWriterAttribute : AbstractWriterAttribute
    {
        /// <summary>
        /// The root to be used if documentRoot is empty and a root is required to form a valid XML document.
        /// </summary>
        [DefaultValue(null)]
        public virtual string DefaultDocumentRoot
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the root element of the document. Defaults to 'xmlData'. If there is more than 1 record and the root is not specified, the default document root will still be used to ensure a valid XML document is created.
        /// </summary>
        [DefaultValue(null)]
        public virtual string DocumentRoot
        {
            get;
            set;
        }

        /// <summary>
        /// A header to use in the XML document (such as setting the encoding or version). Defaults to ''.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Header
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the node to use for each record. Defaults to 'record'.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Record
        {
            get;
            set;
        }

        protected override AbstractWriter CreateWriter()
        {
            return new XmlWriter();
        }
    }
}