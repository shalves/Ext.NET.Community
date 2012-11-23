using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Wilco.SyntaxHighlighting;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net;

namespace Ext.Net.MVC.Examples
{
    [DirectController]
    public class SourceController : System.Web.Mvc.Controller
    {
        [DirectMethod]
        [OutputCache(Duration = 3600, VaryByParam = "url")]
        public ActionResult GetSourceTabs(string id, string url, string windowId)
        {
            var tabs = SourceModel.BuildSourceTabs(id, url);
            tabs.Render(windowId, RenderMode.AddTo);
            return this.Direct();
        }

        [OutputCache(Duration = 3600, VaryByParam = "file")]
        public ActionResult GetSourceFile(string file)
        {
            string path = this.HttpContext.Server.MapPath(file);
            string examplesRoot = this.HttpContext.Server.MapPath(ExamplesModel.ApplicationRoot + "/Areas/");
            var fi = new FileInfo(path);

            if (!path.StartsWith(examplesRoot, true, CultureInfo.CurrentCulture))
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            HighlighterBase hb = null;

            switch (fi.Extension.ToLowerInvariant())
            {
                case ".aspx":
                case ".ascx":
                case ".cshtml":
                case ".master":
                    hb = new ASPXHighlighter();
                    break;
                case ".cs":
                    hb = new CSharpHighlighter();
                    break;
                case ".xml":
                case ".xsl":
                    hb = new XMLHighlighter();
                    break;
                case ".js":
                    hb = new JavaScriptHighlighter();
                    break;
                case ".css":
                    hb = new CSSHighlighter();
                    break;
                default:
                    return Content(System.IO.File.ReadAllText(fi.FullName), "text/plain");                    
            }

            HtmlParser parser = new HtmlParser();
            hb.Parser = parser;

            string source = Regex.Replace(System.IO.File.ReadAllText(fi.FullName), "<%--Start exclude--%>.*?<%--End exclude--%>", "", RegexOptions.Singleline);

            source = hb.Parse(source);

            return this.Content(string.Concat("<pre style='margin: 0px;font-size:14px;'>", source, "</pre>"), "text/html");            
        }

        [DirectMethod]
        [OutputCache(Duration = 3600, VaryByParam = "url")]
        public ActionResult DownloadExample(string url)
        {            
            if (string.IsNullOrEmpty(url))
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }            
            
            string path = this.HttpContext.Server.MapPath("~/Areas" + url);
            string examplesRoot = this.HttpContext.Server.MapPath(ExamplesModel.ApplicationRoot + "/Areas/");

            if (url.ToLowerInvariant() == "all")
            {
                return new ZipResult(examplesRoot, "Ext_Net_MVC_Samples");
            }

            if (!path.StartsWith(examplesRoot, true, CultureInfo.CurrentCulture))
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            return new ZipResult(SourceModel.GetFiles(url, true), new DirectoryInfo(path).Name);
        }
    }
}
