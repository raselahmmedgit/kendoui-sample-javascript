using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RnD.KendoUISample.Models;
using RnD.KendoUISample.ViewModels;
using RnD.KendoUISample.Helpers;
using System.IO;

namespace RnD.KendoUISample.Controllers
{
    public class GridController : Controller
    {
        AppDbContext _db = new AppDbContext();

        //
        // GET: /Grid/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OneLevel()
        {
            return View();
        }

        public ActionResult TwoLevel()
        {
            return View();
        }

        public ActionResult ThreeLevel()
        {
            return View();
        }

        //ServerPageSortFilter
        public ActionResult ServerPageSortFilter()
        {
            return View();
        }

        //VCardExport
        public ActionResult VCardExport()
        {
            return View();
        }

        //[HttpPost]
        [HttpGet]
        public ActionResult ExportToVCardOnClick(int id)
        //public void ExportToVCardOnClick(int id)
        {
            ////Export To vCard 
            //MemoryStream output = new MemoryStream();
            //StreamWriter writer = new StreamWriter(output, Encoding.UTF8);

            //writer.Write("BEGIN:VCARD");
            //writer.Write("VERSION:2.1");

            //writer.Write("N:" + "Rasel" + ";" + "Bappi");
            //writer.Write("FN:" + "Md. Toffazal Hossain");
            //writer.Write("EMAIL;PREF;INTERNET:" + "rasel.bappi@gmail.com");
            //writer.WriteLine();

            //writer.Write("END:VCARD");
            //writer.Flush();
            //output.Position = 0;

            //File(output, "text/x-vcard", "raselbappi.vcf");

            //return Json(Boolean.TrueString);

            var card = new VCardViewModel
            {
                FirstName = "FirstName",
                LastName = "LastName",
                StreetAddress = "StreetAddress",
                City = "City",
                CountryName = "CountryName",

                Mobile = "Mobile",
                Phone = "Phone",
                Email = "Email",
            };

            var models = card;
            string title = "card";
            Session[title] = models;

            return Json(Boolean.TrueString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportToVCard(string title)
        {
            ////Export To vCard 
            // Get the vCard from seession.

            var card = (VCardViewModel)Session[title];

            return new VCardResultHelper(card);
        }

        #region CRUD Master

        [HttpPost]
        public ActionResult MasterCreate(MasterViewModel model)
        //public ActionResult MasterCreate(IEnumerable<MasterViewModel> models)
        //public ActionResult MasterCreate([Bind(Prefix = "models")]IEnumerable<MasterViewModel> models)
        {
            //if (models != null && ModelState.IsValid)
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        [HttpPost]
        public ActionResult MasterUpdate(MasterViewModel model)
        //public ActionResult MasterUpdate(IEnumerable<MasterViewModel> models)
        //public ActionResult MasterUpdate([Bind(Prefix = "models")]IEnumerable<MasterViewModel> models)
        {
            //if (models != null && ModelState.IsValid)
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        [HttpPost]
        public ActionResult MasterDestroy(MasterViewModel model)
        //public ActionResult MasterDestroy(IEnumerable<MasterViewModel> models)
        //public ActionResult MasterDestroy([Bind(Prefix = "models")]IEnumerable<MasterViewModel> models)
        {
            //if (models != null && models.Any())
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        #endregion

        #region CRUD Details

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DetailsCreate(DetailsViewModel model)
        //public ActionResult DetailsCreate(IEnumerable<DetailsViewModel> models)
        {
            //if (models != null && ModelState.IsValid)
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DetailsUpdate(DetailsViewModel model)
        //public ActionResult DetailsUpdate(IEnumerable<DetailsViewModel> models)
        {
            //if (models != null && ModelState.IsValid)
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DetailsDestroy(DetailsViewModel model)
        //public ActionResult DetailsDestroy(IEnumerable<DetailsViewModel> models)
        {
            //if (models != null && models.Any())
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        #endregion

        #region CRUD Item

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ItemCreate(ItemViewModel model)
        //public ActionResult ItemCreate(IEnumerable<ItemViewModel> models)
        {
            //if (models != null && ModelState.IsValid)
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ItemUpdate(ItemViewModel model)
        //public ActionResult ItemUpdate(IEnumerable<ItemViewModel> models)
        {
            //if (models != null && ModelState.IsValid)
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ItemDestroy(ItemViewModel model)
        //public ActionResult ItemDestroy(IEnumerable<ItemViewModel> models)
        {
            //if (models != null && models.Any())
            //{
            //    foreach (var model in models)
            //    {

            //    }
            //}

            //return Json(null);
            return Json(Boolean.TrueString);
        }

        #endregion

        #region 3 level Gird

        public JsonResult MasterRead()
        {
            var models = GetMasterData();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DetailsRead()
        {
            var models = GetDetailsData();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ItemRead()
        {
            var models = GetItemData();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        private List<MasterViewModel> GetMasterData()
        {
            var masterViewModel = new List<MasterViewModel>()
                                      {
                                          new MasterViewModel{ MasterId = 1, MasterName = "Master 1" },
                                          new MasterViewModel{ MasterId = 2, MasterName = "Master 2" },
                                          new MasterViewModel{ MasterId = 3, MasterName = "Master 3" },
                                          new MasterViewModel{ MasterId = 4, MasterName = "Master 4" },
                                          new MasterViewModel{ MasterId = 5, MasterName = "Master 5" }
                                      };
            //return masterViewModel.AsQueryable();
            return masterViewModel.ToList();
        }

        private List<DetailsViewModel> GetDetailsData()
        {
            var detailsViewModel = new List<DetailsViewModel>()
                                      {
                                          new DetailsViewModel{ MasterId = 1, DetailsId = 1, DetailsName = "Details 1" },
                                          new DetailsViewModel{ MasterId = 1, DetailsId = 2, DetailsName = "Details 2" },
                                          new DetailsViewModel{ MasterId = 1, DetailsId = 3, DetailsName = "Details 3" },
                                          new DetailsViewModel{ MasterId = 2, DetailsId = 4, DetailsName = "Details 4" },
                                          new DetailsViewModel{ MasterId = 2, DetailsId = 5, DetailsName = "Details 5" },
                                          new DetailsViewModel{ MasterId = 2, DetailsId = 6, DetailsName = "Details 6" },
                                          new DetailsViewModel{ MasterId = 3, DetailsId = 7, DetailsName = "Details 7" },
                                          new DetailsViewModel{ MasterId = 3, DetailsId = 8, DetailsName = "Details 8" },
                                          new DetailsViewModel{ MasterId = 4, DetailsId = 9, DetailsName = "Details 9" },
                                          new DetailsViewModel{ MasterId = 4, DetailsId = 10, DetailsName = "Details 10" }
                                      };
            //return detailsViewModel.AsQueryable();
            return detailsViewModel.ToList();
        }

        private List<ItemViewModel> GetItemData()
        {
            var itemViewModel = new List<ItemViewModel>()
                                      {
                                          new ItemViewModel{ MasterId = 1, DetailsId = 1, ItemId = 1, ItemName = "Item 1" },
                                          new ItemViewModel{ MasterId = 1, DetailsId = 1, ItemId = 2, ItemName = "Item 2" },
                                          new ItemViewModel{ MasterId = 1, DetailsId = 1, ItemId = 3, ItemName = "Item 3" },
                                          new ItemViewModel{ MasterId = 2, DetailsId = 2, ItemId = 4, ItemName = "Item 4" },
                                          new ItemViewModel{ MasterId = 2, DetailsId = 2, ItemId = 5, ItemName = "Item 5" },
                                          new ItemViewModel{ MasterId = 2, DetailsId = 2, ItemId = 6, ItemName = "Item 6" },
                                          new ItemViewModel{ MasterId = 3, DetailsId = 3, ItemId = 7, ItemName = "Item 7" },
                                          new ItemViewModel{ MasterId = 3, DetailsId = 3, ItemId = 8, ItemName = "Item 8" },
                                          new ItemViewModel{ MasterId = 4, DetailsId = 4, ItemId = 9, ItemName = "Item 9" },
                                          new ItemViewModel{ MasterId = 4, DetailsId = 4, ItemId = 10, ItemName = "Item 10" }
                                      };
            //return itemViewModel.AsQueryable();
            return itemViewModel.ToList();
        }

        #endregion

        #region Server Side Page Sort Filter Gird

        public JsonResult CategoryReadWithParam(KendoGridPost request)
        {
            request.BuildSorterCollection(Request);
            request.BuildFilterCollection(Request);

            var categories = GetCategories().AsQueryable();
            //List<Category> models = GetCategories();

            //var models = GetCategories();
            var models = KendoUiHelper.ParseGridData<Category>(categories, request);

            return Json(models, JsonRequestBehavior.AllowGet);
            //return Json(models);
        }

        //private IEnumerable<Category> GetCategories()
        private List<Category> GetCategories()
        {
            var categories = _db.Categories.ToList().Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name });

            //return categories.AsQueryable();
            return categories.ToList();
        }

        #endregion

    }
}
