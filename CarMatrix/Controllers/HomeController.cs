using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarMatrix.Caching;
using CarMatrix.Infrastructure;
using CarMatrixData.Models;
using ModelEntity = CarMatrixData.Models.Models;

namespace CarMatrix.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;
        public ICacheManager CacheManager { get; set; }

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            AddSelectItems();
            return View();
        }

        private void AddSelectItems()
        {
            IEnumerable<BuyTime> buyTimes = this.unitOfWork.GetBuyTimes();
            List<SelectListItem> buyTimesItems = new List<SelectListItem>();
            foreach (var buyTime in buyTimes)
            {
                SelectListItem item = new SelectListItem();
                item.Text = buyTime.Time.ToShortDateString();
                item.Value = buyTime.Id.ToString();
                buyTimesItems.Add(item);
            }
            ViewBag.BuyTime = buyTimesItems;

            IEnumerable<Brands> brands = this.unitOfWork.GetBrands();
            List<SelectListItem> brandsItems = new List<SelectListItem>();
            foreach (var brand in brands)
            {
                SelectListItem item = new SelectListItem();
                item.Text = brand.Name;
                item.Value = brand.Id.ToString();
                brandsItems.Add(item);
            }
            ViewBag.Models = brandsItems;

            IEnumerable<ModelEntity> models = this.unitOfWork.GetModels();
            List<SelectListItem> modelItems = new List<SelectListItem>();
            foreach (var model in models)
            {
                SelectListItem item = new SelectListItem();
                item.Text = model.Name;
                item.Value = model.Id.ToString();
                modelItems.Add(item);
            }
            ViewBag.Brands = modelItems; 
        }

        public ActionResult TempMethod()
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


        public ActionResult GetRecords()
        {
            List<Record> records = new List<Record>();
            return Json(records, JsonRequestBehavior.AllowGet);
        }
    }
}
