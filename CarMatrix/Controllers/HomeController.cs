using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarMatrixServices.Persons;

namespace CarMatrix.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonService personService;

        public HomeController()
        {
            this.personService = new PersonService();
        }

        public ActionResult Index()
        {     
            return View();
        }

        public ActionResult GetPersons()
        {
            return Json(this.personService.GetPersons(), JsonRequestBehavior.AllowGet);
        }
    }
}
