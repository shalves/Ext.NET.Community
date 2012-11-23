using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Controllers
{
    public class FilterController : Controller
    {
        public ActionResult Index()
        {
            SiteMapNode siteNode = SiteMap.RootNode;
            Node root = FilterModel.CreateNode(siteNode);
            root.AllowDrag = false;
            root.Expanded = true;

            return View(root);
        }
    }
}
