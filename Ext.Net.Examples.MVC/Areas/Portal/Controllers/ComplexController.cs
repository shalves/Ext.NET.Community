using System.Web.Mvc;

using Ext.Net.MVC.Examples.Areas.Portal.Models;

namespace Ext.Net.MVC.Examples.Areas.Portal.Controllers
{
    public class ComplexController : Controller
    {
        public ActionResult Index()
        {
            return View(Data.GetAllCompanies());
        }

        public ActionResult GetCompanies()
        {
            return this.Direct(Data.GetAllCompanies());
        }

        public ActionResult GetPersons()
        {
            return this.Direct(Data.GetAllPersons());
        }

        public ActionResult GetChartData()
        {
            return this.Direct(Data.GetChartData());
        }
    }
}
