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
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TokenSettings
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ID_PATTERN = @"#{\w[^\r;})]+}";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string SELECT_PATTERN = @"\${[^{}]+}";
        
        internal Regex ID_Pattern_RE = new Regex(TokenSettings.ID_PATTERN, RegexOptions.Compiled);
        internal Regex Begin_ID_Pattern_RE = new Regex("^" + TokenSettings.ID_PATTERN, RegexOptions.Compiled);
        internal Regex Select_Pattern_RE = new Regex(TokenSettings.SELECT_PATTERN, RegexOptions.Compiled);
        internal Regex Begin_Select_Pattern_RE = new Regex("^" + TokenSettings.SELECT_PATTERN, RegexOptions.Compiled);
        
        /// <summary>
        /// True to disable any parsing
        /// </summary>
        public bool Disable
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable any parsing during ajax requests only
        /// </summary>
        public bool DisableDuringDirectEvent
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable ID parsing - #{ID}
        /// ID parsing transforms ID to ClientID, if widget with required id is not found then we assume that it is select token
        /// </summary>
        public bool IDParsingDisable
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable select parsing - ${ID}
        /// Select parsing transforms passed ID to Ext.get(ID) - client side search of DOM element
        /// </summary>
        public bool SelectParsingDisable
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable direct methods parsing
        /// This parsing transforms #{DirectMethods} marker to current direct method namespace
        /// </summary>
        public bool DirectMethodsParsingDisable
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable alert parsing
        /// Alert parsing transforms !{title} to alert calling
        /// </summary>
        public bool AlertParsingDisable
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable function parsing
        /// Function parsing transforms #(js_code) to function(){js_code}
        /// </summary>
        public bool FunctionParsingDisable
        {
            get;
            set;
        }

        private string idPatternPrefix = "#";

        /// <summary>
        /// Regex pattern to search ID tokens
        /// By default, ID token is #{ID} and default prefix is #
        /// </summary>
        public string IDPatternPrefix
        {
            get
            {
                return this.idPatternPrefix;
            }
            set
            {
                if (this.idPatternPrefix != value && value.IsNotEmpty())
                {
                    string pattern = value + @"{\w[^\r;})]+}";
                    this.ID_Pattern_RE = new Regex(pattern, RegexOptions.Compiled);
                    this.Begin_ID_Pattern_RE = new Regex("^" + pattern, RegexOptions.Compiled);
                }
            }
        }

        private string selectPatternPrefix = "\\$";

        /// <summary>
        /// Regex pattern to search select tokens
        /// By default, ID token is ${ID} and default prefix is $
        /// </summary>
        public string SelectPatternPrefix
        {
            get
            {
                return this.selectPatternPrefix;
            }
            set
            {
                if (this.selectPatternPrefix != value && value.IsNotEmpty())
                {
                    string pattern = value + @"{[^{}]+}";
                    this.Select_Pattern_RE = new Regex(pattern, RegexOptions.Compiled);
                    this.Begin_Select_Pattern_RE = new Regex("^" + pattern, RegexOptions.Compiled);
                }
            }
        }

        private string directMethodsPattern = "#{DirectMethods}";

        /// <summary>
        /// Regex pattern to search direct methods tokens
        /// Default pattern is #{DirectMethods}
        /// </summary>
        public string DirectMethodsPattern
        {
            get
            {
                return this.directMethodsPattern;
            }
            set
            {
                this.directMethodsPattern = value;
            }
        }

        private string rawPrefix = "=";

        /// <summary>
        /// By default, ={} is raw token
        /// = is defualt raw prefix
        /// </summary>
        public string RawPrefix
        {
            get
            {
                return this.rawPrefix;
            }
            set
            {
                this.rawPrefix = value;
            }
        }

        private string rawMarker = "<raw>";

        /// <summary>
        /// If property values starts with &lt;raw&gt; then such value is rendered as raw
        /// </summary>
        public string RawMarker
        {
            get
            {
                return this.rawMarker;
            }
            set
            {
                this.rawMarker = value;
            }
        }

        private string alertPrefix = "!";

        /// <summary>
        /// By default, !{} is alert token
        /// ! is defualt alert prefix
        /// </summary>
        public string AlertPrefix
        {
            get
            {
                return this.alertPrefix;
            }
            set
            {
                this.alertPrefix = value;
            }
        }

        private string functionPrefix = "#";

        /// <summary>
        /// By default, #() is function token
        /// # is defualt function prefix
        /// </summary>
        public string FunctionPrefix
        {
            get
            {
                return this.functionPrefix;
            }
            set
            {
                this.functionPrefix = value;
            }
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
	[Description("")]
    public partial class TokenUtils
    {
        private static TokenSettings settings = new TokenSettings();

        /// <summary>
        /// 
        /// </summary>
        public static TokenSettings Settings
        {
            get
            {                
                return TokenUtils.settings;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static string RawWrap(string script)
        {
            return string.Format("{0}{{{1}}}", TokenUtils.Settings.RawPrefix, script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string IDWrap(string id)
        {
            return string.Format("{0}{{{1}}}", TokenUtils.Settings.IDPatternPrefix, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string SelectWrap(string id)
        {
            return string.Format("{0}{{{1}}}", TokenUtils.Settings.SelectPatternPrefix, id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
		[Description("")]
        public static bool IsDirectMethodsToken(string script)
        {
            return !TokenUtils.Settings.DirectMethodsParsingDisable && script.IndexOf(TokenUtils.Settings.DirectMethodsPattern) >= 0;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsAlertToken(string script)
        {
            return !TokenUtils.Settings.AlertParsingDisable && (script.IsNotEmpty() ? (script.StartsWith(TokenUtils.Settings.AlertPrefix + "{") && script.EndsWith("}")) : false);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static bool IsRawToken(string script)
        {
            return script.IsNotEmpty() ? ((script.StartsWith(TokenUtils.Settings.RawPrefix + "{") && script.EndsWith("}")) || script.StartsWith(TokenUtils.Settings.RawMarker)) : false;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static bool IsFunction(string script)
        {
            return script.IsNotEmpty() ? ((script.StartsWith("function(") || script.StartsWith("Ext.get") || script.StartsWith("Ext.select"))) : false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIDToken(string script)
        {
            return !TokenUtils.Settings.IDParsingDisable && (script.IsNotEmpty() ? TokenUtils.Settings.Begin_ID_Pattern_RE.Matches(script).Count == 1 : false);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static bool IsSelectToken(string script)
        {
            return !TokenUtils.Settings.SelectParsingDisable && (script.IsNotEmpty() ? TokenUtils.Settings.Begin_Select_Pattern_RE.Matches(script).Count == 1 : false);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static bool IsFunctionToken(string script)
        {
            return !TokenUtils.Settings.FunctionParsingDisable && (script.IsNotEmpty() ? (script.StartsWith(TokenUtils.Settings.FunctionPrefix + "(") && script.EndsWith(")")) : false);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static string ParseTokens(string script)
        {
            return TokenUtils.ParseTokens(script, TokenUtils.Page);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static string ParseTokens(string script, Control seed)
        {
            return TokenUtils.ParseTokens(script, true, seed);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <param name="addRawMarker"></param>
		/// <param name="seed"></param>
		/// <returns></returns>
		[Description("")]
        public static string ParseTokens(string script, bool addRawMarker, Control seed)
        {
            TokenSettings settings = TokenUtils.Settings;

            if (script == null)
            {
                return null;
            }
            
            if (script.ToString().StartsWith("<!token>"))
            {
                return script.ToString().Substring(8);
            }            

            if(settings.Disable || (settings.DisableDuringDirectEvent && X.IsAjaxRequest))
            {
                return script;
            }           

            if (seed == null)
            {
                seed = TokenUtils.Page;
            }

            bool isRaw = (
                TokenUtils.IsAlertToken(script) ||
                TokenUtils.IsRawToken(script) ||
                TokenUtils.IsSelectToken(script));
            
            script = TokenUtils.ReplaceIDTokens(script, seed);
            script = TokenUtils.ReplaceSelectTokens(script);

            script = TokenUtils.ReplaceAlertToken(script);
            script = TokenUtils.ReplaceRawToken(script);
            script = TokenUtils.ReplaceFunctionToken(script);

            return (addRawMarker && (isRaw || TokenUtils.IsFunction(script))) ? TokenUtils.Settings.RawMarker.ConcatWith(script) : script;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <param name="seed"></param>
		/// <returns></returns>
		[Description("")]
        public static string ReplaceDirectMethods(string script, Control seed)
        {
            if (TokenUtils.IsDirectMethodsToken(script))
            {
                string ns = ResourceManager.GlobalNormalizedDirectMethodNamespace;
#if MVC
                if (Ext.Net.MVC.MvcResourceManager.IsMVC || (seed is BaseControl && ((BaseControl)seed).IsMVC))
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"] != null)
                    {
                        return script.Replace(TokenUtils.Settings.DirectMethodsPattern, ns.ConcatWith(".", HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString()));
                    }

                    return script.Replace(TokenUtils.Settings.DirectMethodsPattern, ns);
                }
#endif
                
                UserControl parent = seed as UserControl;

                if (parent == null)
                {
                    parent = ReflectionUtils.GetTypeOfParent(seed, typeof(System.Web.UI.UserControl)) as UserControl;
                }

                ResourceManager sm = null;                

                if (parent != null && !(parent is MasterPage && seed.Parent is System.Web.UI.WebControls.ContentPlaceHolder))
                {
                    string id = ResourceManager.GetControlIdentification(parent, null);

                    if (id.IsNotEmpty())
                    {
                        id = ".".ConcatWith(id);
                    }

                    sm = ResourceManager.GetInstance(HttpContext.Current);

                    if (sm != null)
                    {
                        ns = sm.NormalizedDirectMethodNamespace;
                    }

                    return script.Replace(TokenUtils.Settings.DirectMethodsPattern, ns.ConcatWith(id));
                }
                else
                {
                    Page parentPage = seed as Page;

                    if (parentPage == null)
                    {
                        parentPage = ReflectionUtils.GetTypeOfParent(seed, typeof(System.Web.UI.Page)) as System.Web.UI.Page;
                    }

                    
                    sm = ResourceManager.GetInstance();

                    if (sm != null)
                    {
                        ns = sm.NormalizedDirectMethodNamespace;
                    }

                    return script.Replace(TokenUtils.Settings.DirectMethodsPattern, ns);
                }
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static List<string> ExtractIDs(string script)
        {

            List<string> result = new List<string>();

            if (script.IsNotEmpty())
            {
                MatchCollection matches = TokenUtils.Settings.ID_Pattern_RE.Matches(script);
                string id = "";

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        id = match.Value.Between("{", "}");

                        if (id.IsNotEmpty())
                        {
                            result.Add(id);
                        }
                    }
                }
                else if (!script.EndsWith("}"))
                {
                    result.Add(script);
                }
            }

            return result;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <param name="seed"></param>
		/// <returns></returns>
		[Description("")]
        public static string ReplaceIDTokens(string script, Control seed)
        {
            script = TokenUtils.ReplaceDirectMethods(script, seed);

            Control control = null;

            string[] parts = null;

            if(!TokenUtils.Settings.IDParsingDisable)
            {
                foreach (Match match in TokenUtils.Settings.ID_Pattern_RE.Matches(script))
                {
                    parts = match.Value.Between("{", "}").Split('.');

                    control = ControlUtils.FindControl(seed, parts[0]);

                    if (control != null)
                    {
                        if (parts.Length == 2)
                        {
                            PropertyInfo prop = control.GetType().GetProperty(parts[1]);

                            if (prop != null)
                            {
                                object value = prop.GetValue(control, null);

                                if (value == null)
                                {
                                    value = ReflectionUtils.GetDefaultValue(prop);
                                }

                                if (value is string)
                                {
                                    string val = TokenUtils.ParseTokens(value.ToString(), control);

                                    if (TokenUtils.IsRawToken(val))
                                    {
                                        val = JSON.Serialize(TokenUtils.ReplaceRawToken(val)).Chop();
                                    }
                                    else
                                    {
                                        val = JSON.Serialize(val);
                                    }

                                    script = script.Replace(match.Value, val);
                                }
                                else
                                {
                                    script = script.Replace(match.Value, JSON.Serialize(value));
                                }
                            }
                        }
                        else
                        {
                            if (control is Observable || control is UserControl)
                            {
                                script = script.Replace(match.Value, control.ClientID);
                            }
                            else
                            {
                                script = script.Replace(match.Value, "Ext.get(\"" + control.ClientID + "\")");
                            }
                        }
                    }
                    else
                    {
                        script = script.Replace(match.Value, "Ext.get(\"" + parts[0] + "\")");
                    }
                }
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static string ReplaceAlertToken(string script)
        {
            if (TokenUtils.IsAlertToken(script))
            {
                script = string.Format(ResourceManager.FunctionTemplate, "Ext.Msg.alert(".ConcatWith(script.Substring(0, script.Length - 1).Substring(2), ");"));
            }

            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ReplaceRawToken(string script)
        {
            if (TokenUtils.IsRawToken(script))
            {
                script = script.StartsWith(TokenUtils.Settings.RawMarker) ? script.Substring(5) : script.Between("{", "}");
            }

            return script;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
		[Description("")]
        public static string ReplaceSelectTokens(string script)
        {
            TokenSettings settings = TokenUtils.Settings;
            
            return settings.SelectParsingDisable ? script : settings.Select_Pattern_RE.Replace(script,  new MatchEvaluator(TokenUtils.MatchSelectTokens));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        static string MatchSelectTokens(Match match)
        {
            return "Ext.select(\"".ConcatWith(match.Value.Remove(match.Value.Length - 1).Remove(0, 2), "\")");
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static string ReplaceFunctionToken(string script)
        {
            if (TokenUtils.IsFunctionToken(script))
            {
                script = "function(){".ConcatWith(script.Remove(0, 1).Chop(), "}");
            }

            return script;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
		[Description("")]
        public static string ParseAndNormalize(string script)
        {
            return TokenUtils.ParseAndNormalize(script, null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ParseAndNormalize(string script, Control seed)
        {
            return TokenUtils.NormalizeRawToken(TokenUtils.ParseTokens(script, seed));
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns></returns>
		[Description("")]
        public static string NormalizeRawToken(string script)
        {
            if (TokenUtils.IsRawToken(script))
            {
                return TokenUtils.ReplaceRawToken(script);
            }

            return JSON.Serialize(script, JSON.ScriptConvertersInternal);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static Page Page
        {
            get
            {
                Page page = null;

                if (HttpContext.Current != null && HttpContext.Current.CurrentHandler is Page)
                {
                    page = (Page)HttpContext.Current.CurrentHandler;
                }

                return page;
            }
        }
    }
}