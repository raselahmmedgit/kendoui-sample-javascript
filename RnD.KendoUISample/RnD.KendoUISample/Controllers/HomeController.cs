using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KendoUISample.Models;
using RnD.KendoUISample.ViewModels;

namespace RnD.KendoUISample.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db = new AppDbContext();

        public ActionResult Index()
        {
            var models = GetDadMasters();

            return View();
        }

        public ActionResult Basic()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult dadIndex()
        {
            return View();
        }

        public ActionResult dadFilter()
        {
            return View();
        }

        public ActionResult FilterDialog(int id)
        {
            return PartialView("_FilterDialog");
        }

        [HttpPost]
        public ActionResult FilterDialog(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Content(Boolean.TrueString);
                }

                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        #region Like DAD Filter

        public JsonResult DadDataListRead(FilterViewModel filterModel)
        {
            var models = GetDadMasters();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Like DAD

        public JsonResult DadMasterRead()
        {
            var models = GetDadMasters();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadDetailRead(int id)
        {
            var models = GetDadDetails(id);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadDetailItemRead(int id)
        {
            var models = GetDadDetailItems(id);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region DAD like Methods

        private List<DADMasterViewModel> GetDadMasters()
        {
            var test = from qq in _db.DADDetailItems.ToList()
                       select qq;

            var DADDetailItemViewModels = _db.DADDetailItems.ToList().Select(c => new DADDetailItemViewModel { DADDetailItemId = c.DADDetailItemId, Project = c.Project, CommittedAmount = c.CommittedAmount, DisbursedAmount = c.DisbursedAmount, DADDetailViewModelId = c.DADDetailId }).GroupBy(x => x.DADDetailViewModelId);

            var DADDetailViewModels = _db.DADDetails.ToList().Select(c => new DADDetailViewModel { DADDetailId = c.DADDetailId, FundAgency = c.FundAgency, DADMasterViewModelId = c.DADMasterId }).GroupBy(x => x.DADMasterViewModelId);

            var DADMasterViewModels = _db.DADMasters.ToList().Select(c => new DADMasterViewModel { DADMasterId = c.DADMasterId, FundSource = c.FundSource, CommittedAmount = 00f, DisbursedAmount = 00f });

            return DADMasterViewModels.ToList();
        }

        private List<DADDetailViewModel> GetDadDetails(int id)
        {
            var DADDetailViewModels = _db.DADDetails.ToList().Where(x => x.DADMasterId == id).Select(c => new DADDetailViewModel { DADDetailId = c.DADDetailId, FundAgency = c.FundAgency, CommittedAmount = 00f, DisbursedAmount = 00f, DADMasterViewModelId = c.DADMasterId });

            return DADDetailViewModels.ToList();
        }

        private List<DADDetailItemViewModel> GetDadDetailItems(int id)
        {
            var DADDetailItemViewModels = _db.DADDetailItems.ToList().Where(x => x.DADDetailId == id).Select(c => new DADDetailItemViewModel { DADDetailItemId = c.DADDetailItemId, Project = c.Project, CommittedAmount = c.CommittedAmount, DisbursedAmount = c.DisbursedAmount, ExpendedAmount = c.CommittedAmount - c.DisbursedAmount, DADDetailViewModelId = c.DADDetailId });

            return DADDetailItemViewModels.ToList();
        }

        #endregion

        #region My Methods

        public JsonResult CategoryRead()
        {
            var models = GetCategories();
            //List<Category> models = GetCategories();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CategoryDetailsRead()
        {
            //var models = GetCategoryWithDetails();
            var models = GetCategories();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts(int id)
        {
            int catId = Convert.ToInt32(id);

            var products = _db.Products.ToList().Where(x => x.CategoryId == catId).Select(p => new Product { ProductId = p.ProductId, Name = p.Name, Price = p.Price });

            var models = products.ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //private IEnumerable<Category> GetCategories()
        private List<Category> GetCategories()
        {
            var categories = _db.Categories.ToList().Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name });

            //return categories.AsQueryable();
            return categories.ToList();
        }

        //private IEnumerable<Category> GetCategoryWithDetails()
        private List<Category> GetCategoryWithDetails()
        {
            var categories = _db.Categories.ToList().Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name, Products = c.Products.ToList() });

            // Create some products.
            var products = _db.Products.ToList();

            var models = categories.Select(x => new Category { CategoryId = x.CategoryId, Name = x.Name, Products = products.Where(p => p.CategoryId == x.CategoryId).ToList() }).ToList();

            //return models.AsQueryable();
            //return models;
            return categories.ToList();
        }

        #endregion

    }
}
