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
            try
            {
                using (var container = new ModelsContainer())
                {
                    var record = container.RecordSet.FirstOrDefault();
                    if (record == null)
                    {
                        record = new Record()
                        {
                            Address = "address",
                            Both = DateTime.Now,
                            Brands = "brands",
                            City = "City",
                            Gender = true,
                            Lat = 2.0001,
                            Lnt = 3.0002,
                            Model = "Model",
                            Time = DateTime.Now,
                            Zip = "zip"
                        };
                        container.RecordSet.Add(record);
                        container.SaveChanges();
                        return Content("success");
                    }
                    else
                        return Content("not null");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message + " ";
                if (ex.InnerException != null)
                {
                    msg += ex.InnerException.Message;
                }
                return Content(msg);
            }
        }

        public ActionResult GetPersons()
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}
