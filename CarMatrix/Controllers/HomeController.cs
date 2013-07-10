using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using CarMatrixCore.Extensions;
using CarMatrix.Infrastructure;
using CarMatrix.Models;
using CarMatrixData.Models;
using ModelEntity = CarMatrixData.Models.Models;
using System.Threading;


namespace CarMatrix.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            AddSelectItems();
            return View();
        }

        public ActionResult LbsMap()
        {
            return View();
        }

        public JsonResult GetRecords(string buyTime, string brands, string model)
        {
            ResponseContent rc = new ResponseContent();
            try
            {
                List<Expression<Func<Record, bool>>> expressions = new List<Expression<Func<Record, bool>>>();
                if (!string.IsNullOrEmpty(buyTime))
                {
                    int buyYearId = Convert.ToInt32(buyTime);
                    if (buyYearId != -1)
                        expressions.Add(r => r.BuyYear != null && r.BuyYear.Id == buyYearId);
                }

                if (!string.IsNullOrEmpty(brands))
                {
                    int brandsId = Convert.ToInt32(brands);
                    if (brandsId != -1)
                        expressions.Add(r => r.Brands != null && r.Brands.Id == brandsId);
                }

                if (!string.IsNullOrEmpty(model))
                {
                    int modelsId = Convert.ToInt32(model);
                    if (modelsId != -1)
                        expressions.Add(r => r.Models != null && r.Models.Id == modelsId);
                }

                var records = (from r in this.unitOfWork.GetRecordsFilter(expressions.ToArray())
                               select new
                               {
                                   Lat = r.Lat,
                                   Lnt = r.Lnt
                               }).ToList();
                if (records != null)
                {
                    rc.Result = 1;
                    rc.Message = "Get Data success!";
                    rc.Data = records;
                }
            }
            catch (Exception ex)
            {
                rc.Message = ex.OutputMessage();
            }

            return Json(rc, JsonRequestBehavior.AllowGet);
        }

        private void AddSelectItems()
        {
            #region add select items
            SelectListItem defaultItem = new SelectListItem() { Text = "全部", Value = "-1", Selected = true };

            IEnumerable<BuyYear> buyTimes = this.unitOfWork.GetBuyTimes();
            List<SelectListItem> buyTimesItems = new List<SelectListItem>();
            buyTimesItems.Add(defaultItem);
            foreach (var buyTime in buyTimes)
            {
                SelectListItem item = new SelectListItem();
                item.Text = buyTime.Time.ToShortDateString();
                item.Value = buyTime.Id.ToString();
                buyTimesItems.Add(item);
            }
            ViewData["BuyYear"] = buyTimesItems;

            IEnumerable<Brands> brands = this.unitOfWork.GetBrands();
            List<SelectListItem> brandsItems = new List<SelectListItem>();
            brandsItems.Add(defaultItem);
            foreach (var brand in brands)
            {
                SelectListItem item = new SelectListItem();
                item.Text = brand.Name;
                item.Value = brand.Id.ToString();
                brandsItems.Add(item);
            }
            ViewData["Models"] = brandsItems;

            IEnumerable<ModelEntity> models = this.unitOfWork.GetModels();
            List<SelectListItem> modelItems = new List<SelectListItem>();
            modelItems.Add(defaultItem);
            foreach (var model in models)
            {
                SelectListItem item = new SelectListItem();
                item.Text = model.Name;
                item.Value = model.Id.ToString();
                modelItems.Add(item);
            }
            ViewData["Brands"] = modelItems;
            #endregion
        }
    }
}
