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

using System.Collections.Generic;
using System.Web.Mvc;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Returns the component by id and sets the .Value related fields by calling if available from the Request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetCmp<T>(this System.Web.Mvc.Controller controller, string id) where T : BaseControl, new()
        {
            T cmp = X.GetCmp<T>(id);
            cmp.Controller = controller;
            return cmp;
        }

        /// <summary>
        /// Returns the component by id and sets the .Value related fields by calling if available from the Request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <param name="id"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static T GetCmp<T>(this System.Web.Mvc.Controller controller, string id, BaseControl.Config config) where T : BaseControl, new()
        {
            T cmp = X.GetCmp<T>(id, config);
            cmp.Controller = controller;
            return cmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <param name="id"></param>
        /// <param name="ns"></param>
        /// <returns></returns>
        public static T GetCmp<T>(this System.Web.Mvc.Controller controller, string id, string ns) where T : BaseControl, new()
        {
            T cmp = X.GetCmp<T>(id, ns);
            cmp.Controller = controller;
            return cmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static T CreateCmp<T>(this System.Web.Mvc.Controller controller) where T : BaseControl, new()
        {
            T cmp = new T();
            cmp.Controller = controller;
            return cmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static T ComponentQuery<T>(this System.Web.Mvc.Controller controller, string selector) where T : BaseControl, new()
        {
            T cmp = X.ComponentQuery<T>(selector);
            cmp.Controller = controller;
            return cmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller)
        {
            return PartialExtView(controller, null /* viewName */, null /* model */);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, object model)
        {
            return PartialExtView(controller, null /* viewName */, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, string viewName)
        {
            return PartialExtView(controller, viewName, null /* model */);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, string viewName, object model)
        {
            if (model != null)
            {
                controller.ViewData.Model = model;
            }

            return new PartialViewResult
            {
                ViewName = viewName,
                ViewData = controller.ViewData,
                TempData = controller.TempData
            };
        }

        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller,
            string viewName = null,
            ViewDataDictionary viewData = null,
            object model = null,
            TempDataDictionary tempData = null,
            IDMode idMode = IDMode.Static,
            string controlId = null,
            string containerId = null,
            int index = 0,
            string ns = null,
            RenderMode mode = RenderMode.RenderTo,
            bool wrapByScriptTag = true,
            bool singleControl = false,
            bool items = false,
            string controlToRender = null,
            bool clearContainer = false,
            Container.Config containerConfig = null)
        {
            PartialViewResult result = new PartialViewResult();

            if (model != null)
            {
                controller.ViewData.Model = model;
            }
            
            result.ViewName = viewName;
            result.ViewData = viewData ?? controller.ViewData;
            result.TempData = tempData ?? controller.TempData;

            result.IDMode = idMode;
            result.ControlId = controlId;
            result.ContainerId = containerId;
            result.Index = index;
            result.Namespace = ns;
            result.RenderMode = mode;
            result.WrapByScriptTag = wrapByScriptTag;
            result.SingleControl = singleControl;
            result.Items = items;
            result.ControlToRender = controlToRender;
            result.ContainerConfig = containerConfig;
            result.ClearContainer = clearContainer;

            return result;
        }

        public static FormPanelResult FormPanel(this System.Web.Mvc.Controller controller)
        {
            return new FormPanelResult();
        }

        public static FormPanelResult FormPanel(this System.Web.Mvc.Controller controller, ModelStateDictionary modelState)
        {
            return new FormPanelResult(modelState);
        }

        public static FormPanelResult FormPanel(this System.Web.Mvc.Controller controller, bool success)
        {
            return new FormPanelResult
            {
                Success = success
            };
        }

        public static FormPanelResult FormPanel(this System.Web.Mvc.Controller controller, string errorMessage)
        {
            return new FormPanelResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }

        public static FormPanelResult FormPanel(this System.Web.Mvc.Controller controller, FieldErrors errors)
        {
            FormPanelResult result = new FormPanelResult
            {
                Success = false                
            };

            result.Errors.AddRange(errors);

            return result;
        }

        public static FormPanelResult FormPanel(this System.Web.Mvc.Controller controller, string errorMessage, FieldErrors errors)
        {
            FormPanelResult result = new FormPanelResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };

            result.Errors.AddRange(errors);

            return result;
        }

        public static DirectResult Direct(this System.Web.Mvc.Controller controller)
        {
            return new DirectResult();
        }

        public static DirectResult Direct(this System.Web.Mvc.Controller controller, object result)
        {
            return new DirectResult 
            {
                Result = result
            };
        }

        public static StoreResult Store(this System.Web.Mvc.Controller controller, object data)
        {
            return new StoreResult 
            { 
                Data = data
            };
        }

        public static StoreResult Store(this System.Web.Mvc.Controller controller, object data, int totalCount)
        {
            return new StoreResult
            {
                Data = data,
                Total = totalCount
            };
        }

        public static StoreResult Store<T>(this System.Web.Mvc.Controller controller, Paging<T> data)
        {
            return new StoreResult
            {
                Data = data.Data,
                Total = data.TotalRecords
            };
        }

        public static StoreResult Store(this System.Web.Mvc.Controller controller, string errorMessage)
        {
            return new StoreResult
            {
                Success = false,
                Message = errorMessage
            };
        }

        public static ComponentConfigResult ComponentConfig(this System.Web.Mvc.Controller controller, AbstractComponent component)
        {
            return new ComponentConfigResult(component);
        }

        public static ComponentConfigResult ComponentConfig(this System.Web.Mvc.Controller controller, IEnumerable<AbstractComponent> components)
        {
            return new ComponentConfigResult(components);
        }

        public static ComponentConfigResult ComponentConfig(this System.Web.Mvc.Controller controller)
        {
            return new ComponentConfigResult();
        }

        public static ComponentConfigResult ComponentConfig(this System.Web.Mvc.Controller controller, string viewName)
        {
            return new ComponentConfigResult(viewName:viewName);
        }

        public static ComponentConfigResult ComponentConfig(this System.Web.Mvc.Controller controller, string viewName, object model)
        {
            return new ComponentConfigResult(viewName: viewName, model: model);
        }

        public static ComponentConfigResult ComponentConfig(this System.Web.Mvc.Controller controller, string viewName, object model, ViewDataDictionary viewData)
        {
            return new ComponentConfigResult(viewName: viewName, model: model, viewData: viewData);
        }

        public static ComponentConfigResult ComponentConfig(this System.Web.Mvc.Controller controller, string viewName, object model, ViewDataDictionary viewData, TempDataDictionary tempData)
        {
            return new ComponentConfigResult(viewName: viewName, model: model, viewData: viewData, tempData: tempData);
        }

        public static RemoteTreeResult RemoteTree(this System.Web.Mvc.Controller controller)
        {
            return new RemoteTreeResult();
        }

        public static RemoteTreeResult RemoteTree(this System.Web.Mvc.Controller controller, bool accept)
        {
            return new RemoteTreeResult { Accept = accept };
        }

        public static RemoteTreeResult RemoteTree(this System.Web.Mvc.Controller controller, bool accept, string message)
        {
            return new RemoteTreeResult { Accept = accept, RefusalMessage = message };
        }

        public static RemoteTreeResult RemoteTree(this System.Web.Mvc.Controller controller, object value)
        {
            return new RemoteTreeResult { Value = value };
        }

        public static RemoteTreeResult RemoteTree(this System.Web.Mvc.Controller controller, object value, object attributes)
        {
            return new RemoteTreeResult { Value = value, Attributes = attributes };
        }

        public static RemoteTreeResult RemoteTree(this System.Web.Mvc.Controller controller, object value, string id, object attributes)
        {
            return new RemoteTreeResult { Value = value, Attributes = attributes, NodeID = id };
        }
    }
}
