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
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;
using Transformer.NET;
using Transformer.NET.Html;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(true)]
    public class ExtNetTransformer : HtmlTransformer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public ExtNetTransformer(string text) : base(text)
        {
            this.InitSelectors();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="config"></param>
        public ExtNetTransformer(string text, TextTransformerConfig config)
            : base(text, config)
        {
            this.InitSelectors();
        }

        private static Regex warningRegex = new Regex("<Ext.Net.InitScript.Warning>.*?</Ext.Net.InitScript.Warning>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        //private static Regex removeViewstateRegex = new Regex("<div>[\\r|\\t|\\s]*<input.*name=\"__EVENTVALIDATION\"[^>].*/>[\\r|\\t|\\s]*</div>|<input(?:[^>]*)name=\"__(VIEWSTATE|VIEWSTATEENCRYPTED)\".*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex removeViewstateRegex = new Regex("<input(?:[^>]*)name=\"__(VIEWSTATE|VIEWSTATEENCRYPTED)\".*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex inputsVSRegex = new Regex("<input(?:[^>]*)name=\"__(VIEWSTATE|VIEWSTATEENCRYPTED|EVENTTARGET|EVENTARGUMENT|LASTFOCUS|EVENTVALIDATION)\".*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex inputsRegex = new Regex("<input(?:[^>]*)name=\"__(EVENTTARGET|EVENTARGUMENT|LASTFOCUS)\".*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex postbackRegex = new Regex("<script(?:(?!</script>).)*function __doPostBack\\(eventTarget, eventArgument\\).*?</script>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //private static Regex removeInputsBlockRegex = new Regex("<div(?:(?!</div>).)*<input(?:[^>]*)name=\"__(EVENTTARGET|EVENTVALIDATION)\".*?</div>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private static Regex removeInputsBlockRegex = new Regex("<input(?:[^>]*)name=\"__(EVENTTARGET|EVENTARGUMENT|EVENTVALIDATION).*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private static Regex titleRegex = new Regex("<title>.*?</title>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private static Regex removeLeadingEmptyLines = new Regex(@"^(\r?\n\s*){2,}", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private static Regex removeLeadingEmptyLinesAfterForm = new Regex(@"(?<=\<form(?:[^>]*)\>\s*)(\r?\n\s*){2,}", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        
        /// <summary>
        /// 
        /// </summary>
        protected virtual void InitSelectors()
        {
            Dictionary<string, TokenSelector> selectors = this.Selectors;
            selectors.Add("warning", new TokenSelector { Regex = warningRegex, Position = SelectorPosition.Replace});
            selectors.Add("viewstate", new TokenSelector { Regex = removeViewstateRegex, Position = SelectorPosition.Replace, Pseudo = "all" });
            selectors.Add("inputsVS", new TokenSelector { Regex = inputsVSRegex, Position = SelectorPosition.After, Pseudo = "all" });
            selectors.Add("inputs", new TokenSelector { Regex = inputsRegex, Position = SelectorPosition.After, Pseudo = "all" });
            selectors.Add("postback", new TokenSelector { Regex = postbackRegex, Position = SelectorPosition.Replace });
            selectors.Add("removeblocks", new TokenSelector { Regex = removeInputsBlockRegex, Position = SelectorPosition.Replace, Pseudo="all" });
            selectors.Add("fixTitle", new TokenSelector { Regex = titleRegex, Position = SelectorPosition.Replace, Pseudo = "first" });
            selectors.Add("removeLeadingEmptyLines", new TokenSelector { Regex = removeLeadingEmptyLines, Position = SelectorPosition.Replace, Pseudo = "first" });
            selectors.Add("removeLeadingEmptyLinesAfterForm", new TokenSelector { Regex = removeLeadingEmptyLinesAfterForm, Position = SelectorPosition.Replace, Pseudo = "first" });
        }

        /// <summary>
        /// 
        /// </summary>
        public override List<Type> StandardTokens
        {
            get
            {
                List<Type> tokens = base.StandardTokens;

                tokens.Add(typeof(InputFieldsTag));

                return tokens;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        new public static string Transform(string text)
        {
            try
            {
                return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform();
            }
            catch(System.Exception e)
            {
                if (e.Message.Contains("Reference token (init_script) was not found"))
                {
                    throw new Exception("Probably ResourceManager is not defined in the View");
                }

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        new public static string Transform(string text, TextTransformerConfig config)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text), config).Transform();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tokensType"></param>
        /// <returns></returns>
        new public static string Transform(string text, List<Type> tokensType)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform(tokensType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        new public static string Transform(string text, Dictionary<string, string> variables)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform(variables);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tokensType"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        new public static string Transform(string text, List<Type> tokensType, Dictionary<string, string> variables)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform(tokensType, variables);
        }

        private static string PrepareText(string text)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            if (ExtNetTransformer.RenderStyles != ResourceLocationType.None)
            {
                ExtNetTransformer.ShareIcons(sb);
                ExtNetTransformer.ShareStyles(sb);
            }

            if (ExtNetTransformer.RenderScripts != ResourceLocationType.None)
            {
                ExtNetTransformer.ShareScripts(sb);
            }

            ExtNetTransformer.ShareBeforeAfterScripts(sb);

            if(HttpContext.Current.Items.Contains(Ext.Net.ResourceManager.GLOBAL_RESOURCES))
            {
                HttpContext.Current.Items.Remove(Ext.Net.ResourceManager.GLOBAL_RESOURCES);
            }

            return sb.ToString();
        }

        private static void ShareStyles(StringBuilder sb)
        {
            if (HttpContext.Current.Items[Ext.Net.ResourceManager.GLOBAL_RESOURCES] != null)            
            {

                bool placeholder = HttpContext.Current.Items["Ext.Net.InitStyle"] != null;
                
                sb.AppendFormat("<#:item {0}='{1}' index='11'>", placeholder ? "ref" : "selector", placeholder ? "ext.net.initstyle" : "headstart");
                
                List<ResourceItem> styles = (List<ResourceItem>)HttpContext.Current.Items[Ext.Net.ResourceManager.GLOBAL_RESOURCES];

                foreach (ResourceItem item in styles)
                {
                    if (item is ClientStyleItem)
                    {
                        if (item.IgnoreResourceMode)
                        {
                            if (item.PathEmbedded.IsNotEmpty())
                            {
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, ExtNetTransformer.GetWebResourceUrl(item.Type, item.PathEmbedded));
                            }
                            else
                            {
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, item.Path.StartsWith("~") ? ExtNetTransformer.ResolveUrl(item.Path) : item.Path);
                            }
                            continue;
                        }

                        ClientStyleItem styleItem = (ClientStyleItem)item;

                        switch (ExtNetTransformer.RenderStyles)
                        {                            
                            case ResourceLocationType.File:
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, styleItem.Path.StartsWith("~") ? ExtNetTransformer.ResolveUrl(styleItem.Path) : ExtNetTransformer.ResourcePath.ConcatWith(styleItem.Path));
                                break;
#if ISPRO                      
                            case ResourceLocationType.CDN:
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, ResourceManager.CDNPath.ConcatWith(styleItem.Path));
                                break;
#endif
                            default :
                            case ResourceLocationType.Embedded:
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, ExtNetTransformer.GetWebResourceUrl(styleItem.Type, styleItem.PathEmbedded));
                                break;
                        }
                    }
                }

                List<ClientResourceItem> gbStyles = (List<ClientResourceItem>)HttpContext.Current.Items[ResourceManager.GLOBAL_CLIENT_RESOURCES];
               
                if (gbStyles != null)
                {
                    foreach (ClientResourceItem item in gbStyles)
                    {
                        if (item.IsCss)
                        {
                            if (item.Path.IsNotEmpty())
                            {
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, item.Path.StartsWith("~") ? ExtNetTransformer.ResolveUrl(item.Path) : item.Path);
                            }
                            else if (item.PathEmbedded.IsNotEmpty())
                            {
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, HttpUtility.HtmlAttributeEncode(CachedPageInstance.ClientScript.GetWebResourceUrl(item.Type, item.PathEmbedded)));
                            }
                        }
                    }
                }

                sb.Append("</#:item>");
            }
        }

        public static string ResolveUrl(string url)
        {            
#if MVC            
            return System.Web.Mvc.UrlHelper.GenerateContentUrl(url, new HttpContextWrapper(HttpContext.Current));
#else
            return VirtualPathUtility.IsAppRelative(url) ? VirtualPathUtility.ToAbsolute(url) : url;
#endif
        }

        private static void ShareScripts(StringBuilder sb)
        {
            if (HttpContext.Current.Items[Ext.Net.ResourceManager.GLOBAL_RESOURCES] != null)            
            {
                bool placeholder = HttpContext.Current.Items["Ext.Net.InitScriptFiles"] != null;
                
                sb.AppendFormat("<#:item {0}='{1}' index='21'>", placeholder ? "ref" : "selector", placeholder ? "ext.net.initscriptfiles" : "headstart");

                List<ResourceItem> scripts = (List<ResourceItem>)HttpContext.Current.Items[Ext.Net.ResourceManager.GLOBAL_RESOURCES];                

                foreach (ResourceItem item in scripts)
                {
                    if (item is ClientScriptItem)
                    {
                        ClientScriptItem scriptItem = (ClientScriptItem)item;

                        if (scriptItem.IgnoreResourceMode)
                        {
                            if (scriptItem.PathEmbedded.IsNotEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, (ExtNetTransformer.ScriptMode == ScriptMode.Release || scriptItem.PathEmbeddedDebug.IsEmpty()) ? scriptItem.PathEmbedded : scriptItem.PathEmbeddedDebug);
                            }
                            else
                            {
                                bool isDebug = !(ExtNetTransformer.ScriptMode == ScriptMode.Release || scriptItem.PathEmbeddedDebug.IsEmpty());
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, (isDebug ? scriptItem.PathDebug : scriptItem.Path).StartsWith("~") ? ExtNetTransformer.ResolveUrl(isDebug ? scriptItem.PathDebug : scriptItem.Path) : (isDebug ? scriptItem.PathDebug : scriptItem.Path));
                            }
                            
                            continue;
                        }

                        if (ExtNetTransformer.RenderScripts == ResourceLocationType.Embedded)
                        {

                            if (ExtNetTransformer.ScriptMode == ScriptMode.Release || scriptItem.PathEmbeddedDebug.IsEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ExtNetTransformer.GetWebResourceUrl(scriptItem.Type, scriptItem.PathEmbedded));
                            }
                            else
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ExtNetTransformer.GetWebResourceUrl(scriptItem.Type, scriptItem.PathEmbeddedDebug));                                
                            }
                        }
                        else if (ExtNetTransformer.RenderScripts == ResourceLocationType.File)
                        {
                            if (ExtNetTransformer.ScriptMode == ScriptMode.Release || scriptItem.PathDebug.IsEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, scriptItem.Path.StartsWith("~") ? ExtNetTransformer.ResolveUrl(scriptItem.Path) : ExtNetTransformer.ResourcePath.ConcatWith(scriptItem.Path));
                            }
                            else
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, scriptItem.PathDebug.StartsWith("~") ? ExtNetTransformer.ResolveUrl(scriptItem.PathDebug) : ExtNetTransformer.ResourcePath.ConcatWith(scriptItem.PathDebug));                             
                            }
                        }
#if ISPRO                        
                        else if (ExtNetTransformer.RenderScripts == ResourceLocationType.CDN)
                        {
                            if (ExtNetTransformer.ScriptMode == ScriptMode.Release || scriptItem.PathDebug.IsEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ResourceManager.CDNPath.ConcatWith(scriptItem.Path));
                            }
                            else
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ResourceManager.CDNPath.ConcatWith(scriptItem.PathDebug));
                            }
                        }
#endif
                    }
                }

                List<ClientResourceItem> gbScripts = (List<ClientResourceItem>)HttpContext.Current.Items[ResourceManager.GLOBAL_CLIENT_RESOURCES];
                
                if (gbScripts != null)
                {
                    foreach (ClientResourceItem item in gbScripts)
                    {
                        if (!item.IsCss)
                        {
                            if (item.Path.IsNotEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, item.Path.StartsWith("~") ? ExtNetTransformer.ResolveUrl(item.Path) : item.Path);
                            }
                            else if (item.PathEmbedded.IsNotEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, HttpUtility.HtmlAttributeEncode(CachedPageInstance.ClientScript.GetWebResourceUrl(item.Type, item.PathEmbedded)));
                            }
                        }
                    }
                }

                sb.Append("</#:item>");
            }
        }

        private static Page cachedPage = null;
        private static object syncLock = new object();

        /// <summary>
        /// 
        /// </summary>
        protected static Page CachedPageInstance
        {
            get
            {
                if (cachedPage == null)
                {
                    lock (syncLock)
                    {
                        if (cachedPage == null)
                            cachedPage = new Page();
                    }
                }
                return cachedPage;
            }
        }

        private static bool CleanResourceUrl
        {
            get
            {
#if MVC
                return MVC.MvcResourceManager.SharedConfig.CleanResourceUrl;
#else
                return GlobalConfig.Settings.CleanResourceUrl;
#endif
            }
        }

        private static ScriptMode ScriptMode
        {
            get
            {
#if MVC
                return MVC.MvcResourceManager.SharedConfig.ScriptMode;
#else
                return GlobalConfig.Settings.ScriptMode;
#endif
            }
        }

        private static ResourceLocationType RenderStyles
        {
            get
            {
#if MVC
                return MVC.MvcResourceManager.SharedConfig.RenderStyles;
#else
                return GlobalConfig.Settings.RenderStyles;
#endif
            }
        }

        private static ResourceLocationType RenderScripts
        {
            get
            {
#if MVC
                return MVC.MvcResourceManager.SharedConfig.RenderScripts;
#else
                return GlobalConfig.Settings.RenderScripts;
#endif
            }
        }

        private static string ResourcePath
        {
            get
            {
#if MVC
                return MVC.MvcResourceManager.SharedConfig.ResourcePath;
#else
                return GlobalConfig.Settings.ResourcePath;
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetWebResourceUrl(Type type, string resourceName)
        {
            if (resourceName.StartsWith(ResourceManager.ASSEMBLYSLUG) && ExtNetTransformer.CleanResourceUrl && ResourceHandler.HasHandler())
            {
                string buster = (resourceName.EndsWith(".js") || resourceName.EndsWith(".css")) ? "?v=".ConcatWith(ResourceManager.CacheBuster) : "";

                string url = "~{0}/ext.axd{1}".FormatWith(resourceName.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", "-"), buster);                
                
                return ExtNetTransformer.ResolveUrl(url);
            }

            return HttpUtility.HtmlAttributeEncode(CachedPageInstance.ClientScript.GetWebResourceUrl(type, resourceName));
        }

        private static void ShareIcons(StringBuilder sb)
        {
            if (HttpContext.Current.Items["Ext.Net.GlobalIcons"] != null)
            {
                List<Icon> icons = (List<Icon>)HttpContext.Current.Items["Ext.Net.GlobalIcons"];
                HttpContext.Current.Items.Remove("Ext.Net.GlobalIcons");
                if (icons.Count > 0)
                {
                    string[] arr = new string[icons.Count];
                    for (int i = 0; i < icons.Count; i++)
                    {
                        arr[i] = icons[i].ToString();
                    }

                    sb.Append("<#:item ref='ext.net.global.icons'>Ext.net.ResourceMgr.registerIcon(");
                    sb.Append(JSON.Serialize(arr));
                    sb.Append(");</#:item>");
                }
            }
        }

        private static void ShareBeforeAfterScripts(StringBuilder sb)
        {
            if (HttpContext.Current.Items["Ext.Net.GlobalScriptBeforeClientInit"] != null)
            {
                List<string> scripts = (List<string>)HttpContext.Current.Items["Ext.Net.GlobalScriptBeforeClientInit"];
                HttpContext.Current.Items.Remove("Ext.Net.GlobalScriptBeforeClientInit");

                if (scripts.Count > 0)
                {
                    sb.Append("<#:item ref='ext.net.global.script.before'>");
                
                    foreach (string item in scripts)
                    {
                        sb.Append(item);
                    }                  
                    
                    sb.Append("</#:item>");
                }
            }

            if (HttpContext.Current.Items["Ext.Net.GlobalScriptAfterClientInit"] != null)
            {
                List<string> scripts = (List<string>)HttpContext.Current.Items["Ext.Net.GlobalScriptAfterClientInit"];
                HttpContext.Current.Items.Remove("Ext.Net.GlobalScriptAfterClientInit");

                if (scripts.Count > 0)
                {
                    sb.Append("<#:item ref='ext.net.global.script.after'>");

                    foreach (string item in scripts)
                    {
                        sb.Append(item);
                    }
                    
                    sb.Append("</#:item>");
                }
            }
        }

        protected override Token CreateToken(string tagName, Match match)
        {
            if (tagName == "item")
            {
                string attrsStr = match.Groups["attrs"].Value;

                if (attrsStr != null && attrsStr.Contains("key="))
                {
                    return new LinkedScriptTag(match);
                }
            }

            return base.CreateToken(tagName, match);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [TagName("item")]
    [CLSCompliant(true)]
    public class LinkedScriptTag : ItemTag
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        public LinkedScriptTag(Match match)
            : base(match)
        {
        }

        public override string Output
        {
            get
            {                
                HttpContext.Current.Application[this.GetAttribute("key")] = this.Value;
                return ResourceManager.ScriptIncludeTemplate.FormatWith(this.GetAttribute("url"));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [TagName("inputs")]
    [CLSCompliant(true)]
    public class InputFieldsTag : ItemTag
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        public InputFieldsTag(Match match)
            : base(match)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IncludeViewState
        {
            get
            {
                string vs = this.GetAttribute("viewstate");
                return vs != null && vs.Length > 0 ? bool.Parse(vs) : false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Template
        {
            get
            {
                return "inputs";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Selector
        {
            get
            {
                return this.IncludeViewState ? "inputsVS" : "inputs";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Output
        {
            get
            {
                TokenSelector selector = TokenSelector.ToTokenSelector(this.Transformer, this.Selector);
                List<string> list = selector.Matches(this.Transformer.Text, this);

                if (list.Count <= 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder("Ext.net.ResourceMgr.initAspInputs({");
                
                bool presented = false;

                foreach (string match in list)
                {
                    if (match != null && match.Length > 0)
                    {
                        Dictionary<string, string> attrs = this.BuildAttributes(match);

                        if (!(attrs["value"].IsEmpty() && (attrs["name"] == "__EVENTTARGET" || attrs["name"] == "__EVENTARGUMENT")))
                        {
                            sb.Append(JSON.Serialize(attrs["name"])).Append(":").Append(JSON.Serialize(attrs["value"])).Append(",");
                            presented = true;
                        }
                    }
                }

                if (!presented)
                {
                    return "";
                }

                sb.Remove(sb.Length - 1, 1);
                
                sb.Append("});");

                return sb.ToString();
            }
        }
    }
}
