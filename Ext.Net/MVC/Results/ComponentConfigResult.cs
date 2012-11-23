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
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    public class ComponentConfigResult : ActionResult
    {
        private AbstractComponent component;
        private IEnumerable<AbstractComponent> components;
        private object model;
        private string viewName;
        private ViewDataDictionary viewData;
        private TempDataDictionary tempData;

        public ComponentConfigResult()
        {
        }

        public ComponentConfigResult(AbstractComponent component)
        {
            this.component = component;
        }

        public ComponentConfigResult(IEnumerable<AbstractComponent> components)
        {
            this.components = components;
        }

        public ComponentConfigResult(
            string viewName = null,
            ViewDataDictionary viewData = null,
            object model = null,
            TempDataDictionary tempData = null)
        {
            this.model = model;
            this.viewName = viewName;
            this.viewData = viewData;
            this.tempData = tempData;
        }
        
        public override void ExecuteResult(ControllerContext context)
        {
            if(this.component != null)
            {
                context.HttpContext.Response.Write(ComponentLoader.ToConfig(this.component));
            }
            else if (this.components != null)
            {
                context.HttpContext.Response.Write(ComponentLoader.ToConfig(this.components));
            }
            else
            {
                PartialViewResult result = new PartialViewResult();
                result.RenderMode = RenderMode.AddTo;
                result.Config = true;

                if (this.viewName.IsNotEmpty())
                {
                    result.ViewName = this.viewName;
                }

                if (this.model != null)
                {
                    result.Model = this.model;
                }

                if (this.viewData != null)
                {
                    result.ViewData = this.viewData;
                }

                if (this.tempData != null)
                {
                    result.TempData = this.tempData;
                }

                result.ExecuteResult(context);

                context.HttpContext.Response.Write(result.Output);
            }
        }
    }
}