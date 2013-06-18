using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarMatrixData.Models;

namespace CarMatrix.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            using (var container = new ModelsContainer())
            {
                var record = container.RecordSet.FirstOrDefault();
                if (record == null)
                    return Content("null");
                else
                    return Content("not null");
            }
        }

        public ActionResult GetPersons()
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}
