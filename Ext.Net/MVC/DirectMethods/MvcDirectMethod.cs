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
using System.Web.Compilation;
using System.Reflection;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    internal class MvcDirectMethod : DirectMethod
    {
        private static bool IsDebugging
        {
            get
            {
                bool result = false;

                if (HttpContext.Current != null)
                {
                    result = HttpContext.Current.IsDebuggingEnabled;
                }

                return result;
            }
        }

        public static MvcDirectMethod[] GetMethods()
        {
            string cacheKey = "Ext.Net.MVC.DirectMethods";
            List<MvcDirectMethod> list = null;
            var context = HttpContext.Current;

            if (!MvcDirectMethod.IsDebugging)
            {
                list = context.Cache[cacheKey] as List<MvcDirectMethod>;
            }

            if (list == null)
            {
                list = new List<MvcDirectMethod>();
                var assemblies = BuildManager.GetReferencedAssemblies();
                foreach (Assembly assembly in assemblies)
                {
                    try
                    {
                        if (!assembly.IsDynamic)
                        {
                            var types = assembly.GetTypes().Where(type =>
                                type.IsPublic &&
                                type.IsSubclassOf(typeof(System.Web.Mvc.Controller)) &&
                                System.Attribute.IsDefined(type, typeof(Ext.Net.MVC.DirectControllerAttribute))
                            );

                            foreach (Type type in types)
                            {
                                MvcDirectMethod.GetControllerMethods(type, list);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }

                if (!MvcDirectMethod.IsDebugging)
                {
                    context.Cache.Insert(cacheKey, list);
                }
            }

            return list.ToArray();
        }

        private static void GetControllerMethods(Type type, List<MvcDirectMethod> list)
        {
            var methods = type.GetMethods().Where(method =>
                method.IsPublic &&
                (method.ReturnType == typeof(ActionResult) || method.ReturnType.IsSubclassOf(typeof(ActionResult))) &&
                System.Attribute.IsDefined(method, typeof(Ext.Net.DirectMethodAttribute))
            );

            object[] attrs = type.GetCustomAttributes(typeof (DirectControllerAttribute), true);
            DirectControllerAttribute dcAttr = (DirectControllerAttribute)attrs[0];

            foreach (MethodInfo method in methods)
            {
                attrs = method.GetCustomAttributes(typeof(DirectMethodAttribute), true);
                DirectMethodAttribute dmAttr = (DirectMethodAttribute)attrs[0];

                list.Add(new MvcDirectMethod(type.Name, method, dcAttr, dmAttr));
            }
        }

        public static Dictionary<string, Dictionary<string, List<MvcDirectMethod>>> GetGroupedMethods(ViewContext viewContext)
        {
            Dictionary<string, Dictionary<string, List<MvcDirectMethod>>> methods = new Dictionary<string, Dictionary<string, List<MvcDirectMethod>>>();            
            var dm = MvcDirectMethod.GetMethods();

            if(dm.Length == 0)
            {
                return methods;
            }

            var context = HttpContext.Current;
            string area = null;
            string controller = null;
            
            if(viewContext.RouteData.DataTokens["area"] != null)
            {
                area = viewContext.RouteData.DataTokens["area"].ToString();
            }

            if (viewContext.RouteData.DataTokens["controller"] != null)
            {
                controller = viewContext.RouteData.DataTokens["controller"].ToString();
            }            

            foreach (MvcDirectMethod method in dm)
            {
                if (method.Attribute.ClientProxy == ClientProxy.Ignore)
                {
                    continue;
                }

                if (!method.DirectControlerAttr.GenerateProxyForOtherAreas && method.DirectControlerAttr.AreaName != area)
                {
                    continue;
                }

                if (!method.DirectControlerAttr.GenerateProxyForOtherControllers)
                {
                    if (method.DirectControlerAttr.AreaName != area || method.Controller != controller)
                    {
                        continue;
                    }                    
                }

                string ns = method.Attribute.Namespace;

                if (!methods.ContainsKey(ns))
                {
                    methods[ns] = new Dictionary<string, List<MvcDirectMethod>>();
                }

                string name = MvcDirectMethod.GetControlIdentification(method) ?? "";

                if (!methods[ns].ContainsKey(name))
                {
                    methods[ns][name] = new List<MvcDirectMethod>();
                }
                
                methods[ns][name].Add(method);
            }

            return methods;
        }

        private static string GetControlIdentification(MvcDirectMethod method)
        {
            DirectMethodProxyIDMode _idMode = method.Attribute.IDMode;
            string alias = method.Attribute.IDAlias ?? "";

            if (_idMode == DirectMethodProxyIDMode.Default)
            {
                _idMode = method.DirectControlerAttr.IDMode;
                alias = method.DirectControlerAttr.Alias;
            }
            
            if (alias.IsNotEmpty() && (_idMode == DirectMethodProxyIDMode.Default || _idMode == DirectMethodProxyIDMode.ClientID))
            {
                _idMode = DirectMethodProxyIDMode.Alias;
            }

            switch (_idMode)
            {
                case DirectMethodProxyIDMode.None:
                    return null;
                case DirectMethodProxyIDMode.ClientID:
                case DirectMethodProxyIDMode.ID:
                    return method.DirectControlerAttr.AreaName;                
                case DirectMethodProxyIDMode.Alias:
                    return alias;
                case DirectMethodProxyIDMode.AliasPlusID:
                    return alias + method.DirectControlerAttr.AreaName;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string BuildProxy(ViewContext viewContext)
        {
            Dictionary<string, Dictionary<string, List<MvcDirectMethod>>> methods = MvcDirectMethod.GetGroupedMethods(viewContext);
            StringBuilder sb = new StringBuilder(256);

            UrlHelper urlHelper = new UrlHelper(viewContext.RequestContext, RouteTable.Routes);

            foreach (KeyValuePair<string, Dictionary<string, List<MvcDirectMethod>>> ns in methods)
            {
                string nsName = ns.Key;

                sb.AppendFormat("Ext.ns(\"{0}\");", nsName);

                Dictionary<string, List<MvcDirectMethod>> scopes = ns.Value;

                sb.Append("Ext.apply(".ConcatWith(nsName, ", { "));

                foreach (KeyValuePair<string, List<MvcDirectMethod>> scope in scopes)
                {
                    string scopeName = scope.Key;
                    List<MvcDirectMethod> directMethods = scope.Value;

                    if (scopeName.IsNotEmpty())
                    {
                        sb.Append(scopeName);
                        sb.Append(":{");
                    }

                    bool needComma = false;

                    foreach (MvcDirectMethod method in directMethods)
                    {
                        if (needComma)
                        {
                            sb.Append(",");
                        }
                        method.UrlHelper = urlHelper;
                        method.GenerateProxy(sb, null, null);
                        needComma = true;
                    }

                    if (scopeName.IsNotEmpty())
                    {
                        sb.Append("}");
                    }

                    sb.Append(",");
                }

                if (sb[sb.Length - 1] == ',')
                {
                    sb.Remove(sb.Length - 1, 1);
                }

                sb.Append(" });");
            }

            return sb.ToString();
        }

        public MvcDirectMethod(string controller, MethodInfo method, DirectControllerAttribute dcAttribute, DirectMethodAttribute dmAttribute) : base(method, dmAttribute)
        {
            this.Controller = controller;
            if (this.Controller.EndsWith("Controller"))
            {
                this.Controller = this.Controller.Substring(0, this.Controller.IndexOf("Controller", StringComparison.InvariantCultureIgnoreCase));
            }
            this.DirectControlerAttr = dcAttribute;
        }

        public string Controller 
        { 
            get; 
            set; 
        }

        public DirectControllerAttribute DirectControlerAttr 
        { 
            get; 
            set; 
        }

        protected override ParameterInfo[] PrepareParams(ParameterInfo[] parameters)
        {
            return parameters.Where(p => p.ParameterType != typeof(System.Web.Mvc.FormCollection) && !p.ParameterType.IsSubclassOf(typeof(System.Web.Mvc.FormCollection))).ToArray();
        }

        public UrlHelper UrlHelper
        {
            get;
            set;
        }

        protected virtual string ActionUrl
        {
            get
            {
                return this.UrlHelper.Action(this.Name, this.Controller, new { area = this.DirectControlerAttr.AreaName });
            }
        }

        protected override void AppendParams(StringBuilder sb, bool needComma)
        {
            sb.Append(needComma ? "," : "");
            sb.AppendFormat("url:{0}", JSON.Serialize(this.ActionUrl));
        }
    }
}