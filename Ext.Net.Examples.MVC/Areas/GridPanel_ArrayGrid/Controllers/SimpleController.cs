using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ArrayGrid.Simple.Controllers
{
    public class SimpleController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetAllCompanies());
        }
    }
}
