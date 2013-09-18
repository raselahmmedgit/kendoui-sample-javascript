using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KendoUISample.ViewModels;
using RnD.KendoUISample.Models;
using RnD.KendoUISample.Helpers;

namespace RnD.KendoUISample.Controllers
{
    public class DemoController : Controller
    {
        AppDbContext _db = new AppDbContext();

        //
        // GET: /Demo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Final()
        {
            return View();
        }

        public ActionResult CustomPagination()
        {
            return View();
        }

        //ServerPaging
        public ActionResult ServerPaging()
        {
            return View();
        }

        //ServerFiltering
        public ActionResult ServerFiltering()
        {
            return View();
        }

        //ServerSorting
        public ActionResult ServerSorting()
        {
            return View();
        }

        //InCellEdit
        public ActionResult InCellEdit()
        {
            return View();
        }

        public JsonResult CategoryRead(KendoUiGridParamViewModel request)
        {
            var categories = GetCategories();
            //List<Category> models = GetCategories();

            //var models = GetCategories();
            var models = categories.Skip(request.PageSize * request.Page).Take(request.PageSize).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CategoryReadWithParam(KendoGridPost request)
        {
            var categories = GetCategories().AsQueryable();
            //List<Category> models = GetCategories();

            //var models = GetCategories();
            var models = KendoUiHelper.ParseGridData<Category>(categories, request);

            return Json(models, JsonRequestBehavior.AllowGet);
            //return Json(models);
        }

        public JsonResult CategoryReadWithParamForFilter(KendoGridPost request)
        {
            var categories = GetCategories().AsQueryable();
            //List<Category> models = GetCategories();

            //var models = GetCategories();
            var models = KendoUiHelper.ParseGridData<Category>(categories, request);

            return Json(models, JsonRequestBehavior.AllowGet);
            //return Json(models);
        }


        public JsonResult PagingCategoryRead(KendoUiGridParamViewModel request)
        {
            var categories = GetCategories();
            //List<Category> models = GetCategories();

            //var models = GetCategories();
            var models = categories.Skip(request.PageSize * request.Page).Take(request.PageSize).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FilteringCategoryRead(KendoUiGridParamViewModel request)
        {
            var categories = GetCategories();
            //List<Category> models = GetCategories();

            //var models = GetCategories();
            var models = categories.Skip(request.PageSize * request.Page).Take(request.PageSize).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SortingCategoryRead(KendoUiGridParamViewModel request)
        {
            var categories = GetCategories();
            //List<Category> models = GetCategories();

            //var models = GetCategories();
            var models = categories.Skip(request.PageSize * request.Page).Take(request.PageSize).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //private IEnumerable<Category> GetCategories()
        private List<Category> GetCategories()
        {
            var categories = _db.Categories.ToList().Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name });

            //return categories.AsQueryable();
            return categories.ToList();
        }


        #region Demo Data

        public JsonResult GridMasterRead(FilterViewModel filterModel)
        {
            var models = GetMasterData();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GridDetailRead(int id)
        {
            var models = GetDetailData();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GridDetailItemRead(int id)
        {
            var models = GetDetailItemData();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        private List<DemoViewModel> GetMasterData()
        {
            var aaa = DemoData().GroupBy(p => p.AId, p => p.AName,
                         (key, g) => new { Id = key, Name = g.ToList() });

            //var test = from m in DemoData()
            //           group m.AId by m.AName into g
            //           select new m;

            //var demoViewModelList = DemoData().GroupBy(x => x.AId);
            var demoViewModelList = DemoData();

            return demoViewModelList;
        }

        private List<DemoViewModel> GetDetailData()
        {
            //var demoViewModelList = DemoData().GroupBy(x => x.AId);
            var demoViewModelList = DemoData();

            return demoViewModelList;
        }

        private List<DemoViewModel> GetDetailItemData()
        {
            //var demoViewModelList = DemoData().GroupBy(x => x.AId);
            var demoViewModelList = DemoData();

            return demoViewModelList;
        }

        private List<DemoViewModel> DemoData()
        {
            var demoViewModelList = new List<DemoViewModel>{ 
                                        new DemoViewModel{ Id=1, CommittedAmount=10, DisbursedAmount= 5, AId=1, AName="A000", BId=1, BName="B000", CId=1, CName="C000", DId=1, DName="D000", EId=1, EName="E000" },
                                        new DemoViewModel{ Id=2, CommittedAmount=10, DisbursedAmount= 5, AId=2, AName="A111", BId=2, BName="B111", CId=2, CName="C111", DId=2, DName="D111", EId=2, EName="E111" },
                                        new DemoViewModel{ Id=3, CommittedAmount=10, DisbursedAmount= 5, AId=3, AName="A222", BId=2, BName="B111", CId=3, CName="C222", DId=3, DName="D222", EId=3, EName="E222" },
                                        new DemoViewModel{ Id=4, CommittedAmount=10, DisbursedAmount= 5, AId=4, AName="A333", BId=3, BName="B222", CId=4, CName="C333", DId=4, DName="D333", EId=4, EName="E333" },
                                        new DemoViewModel{ Id=5, CommittedAmount=10, DisbursedAmount= 5, AId=5, AName="A444", BId=4, BName="B333", CId=5, CName="C444", DId=5, DName="D444", EId=5, EName="E444" },

                                        new DemoViewModel{ Id=6, CommittedAmount=10, DisbursedAmount= 5, AId=1, AName="A000", BId=5, BName="B444", CId=6, CName="C555", DId=6, DName="D555", EId=6, EName="E555" },
                                        new DemoViewModel{ Id=8,  CommittedAmount=10, DisbursedAmount= 5, AId=2, AName="A111", BId=6, BName="B555", CId=7, CName="C666", DId=9, DName="D666", EId=7, EName="E666" },
                                        new DemoViewModel{ Id=10, CommittedAmount=10, DisbursedAmount= 5, AId=3, AName="A222", BId=1, BName="B000", CId=1, CName="C000", DId=1, DName="D000", EId=1, EName="E000" },
                                        new DemoViewModel{ Id=12, CommittedAmount=10, DisbursedAmount= 5, AId=4, AName="A333", BId=2, BName="B111", CId=2, CName="C111", DId=2, DName="D111", EId=2, EName="E111" },
                                        new DemoViewModel{ Id=14, CommittedAmount=10, DisbursedAmount= 5, AId=5, AName="A444", BId=3, BName="B222", CId=3, CName="C222", DId=3, DName="D222", EId=3, EName="E222" },

                                        new DemoViewModel{ Id=7, CommittedAmount=10, DisbursedAmount= 5, AId=1, AName="A000", BId=4, BName="B333", CId=4, CName="C333", DId=4, DName="D333", EId=4, EName="E333" },
                                        new DemoViewModel{ Id=9, CommittedAmount=10, DisbursedAmount= 5, AId=2, AName="A111", BId=5, BName="B444", CId=5, CName="C444", DId=5, DName="D444", EId=5, EName="E444" },
                                        new DemoViewModel{ Id=11, CommittedAmount=10, DisbursedAmount= 5, AId=3, AName="A222", BId=6, BName="B555", CId=6, CName="C555", DId=6, DName="D555", EId=6, EName="E555" },
                                        new DemoViewModel{ Id=13, CommittedAmount=10, DisbursedAmount= 5, AId=4, AName="A333", BId=0, BName="", CId=7, CName="C666", DId=7, DName="D666", EId=7, EName="E666" },
                                        new DemoViewModel{ Id=15, CommittedAmount=10, DisbursedAmount= 5, AId=5, AName="A444", BId=0, BName="", CId=0, CName="", DId=8, DName="D777", EId=8, EName="E777" },
                                        new DemoViewModel{ Id=16, CommittedAmount=10, DisbursedAmount= 5, AId=1, AName="A000", BId=0, BName="", CId=0, CName="", DId=0, DName="", EId=9, EName="E888" },
                                        new DemoViewModel{ Id=17, CommittedAmount=10, DisbursedAmount= 5, AId=2, AName="A111", BId=0, BName="", CId=0, CName="", DId=0, DName="", EId=0, EName="" }

                                            };

            return demoViewModelList;
        }

        #endregion

        #region Others Data

        public JsonResult GridMasterDataRead()
        {
            var models = GetMasterDataList();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GridDetailDataRead(int id)
        {
            var models = GetDetailDataList(id);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GridDetailItemDataRead(int id, int pid)
        {
            var models = GetDetailItemDataList(id, pid);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //private List<DADModel> GetMasterDataList()
        private List<DADModelViewModel> GetMasterDataList()
        {
            //var demoViewModelList = DADModelDataList().GroupBy(x => x.FundSourceId).Select(x => new DADModel { Id = x.Key, FundSourceId = x.Key, FundAgencyId = 0, ProjectId = 0, CommittedAmount = x.Sum(c => c.CommittedAmount), DisbursedAmount = x.Sum(d => d.DisbursedAmount), ExpendedAmount = x.Sum(e => e.ExpendedAmount) });

            //DADModelViewModel
            var demoViewModelList = DADModelDataList().GroupBy(x => x.FundSourceId).Select(x => new DADModelViewModel { Id = x.Key, PId = 0, Title = x.Key.ToString(), CommittedAmount = x.Sum(c => c.CommittedAmount), DisbursedAmount = x.Sum(d => d.DisbursedAmount), ExpendedAmount = x.Sum(e => e.ExpendedAmount) });

            return demoViewModelList.ToList();
        }

        //private List<DADModel> GetDetailDataList(int id)
        private List<DADModelViewModel> GetDetailDataList(int id)
        {
            //var demoViewModelList = DADModelDataList().Where(x => x.FundSourceId == id).GroupBy(x => x.FundAgencyId).Select(x => new DADModel { Id = x.Key, FundSourceId = 0, FundAgencyId = x.Key, ProjectId = 0, CommittedAmount = x.Sum(c => c.CommittedAmount), DisbursedAmount = x.Sum(d => d.DisbursedAmount), ExpendedAmount = x.Sum(e => e.ExpendedAmount) });

            //DADModelViewModel
            var demoViewModelList = DADModelDataList().Where(x => x.FundSourceId == id).GroupBy(x => x.FundAgencyId).Select(x => new DADModelViewModel { Id = x.Key, PId = id, Title = x.Key.ToString(), CommittedAmount = x.Sum(c => c.CommittedAmount), DisbursedAmount = x.Sum(d => d.DisbursedAmount), ExpendedAmount = x.Sum(e => e.ExpendedAmount) });

            return demoViewModelList.ToList();
        }

        //private List<DADModel> GetDetailItemDataList(int id)
        private List<DADModelViewModel> GetDetailItemDataList(int id, int pid)
        {
            //var demoViewModelList = DADModelDataList().Where(x => x.FundAgencyId == id).GroupBy(x => x.ProjectId).Select(x => new DADModel { Id = x.Key, FundSourceId = 0, FundAgencyId = 0, ProjectId = x.Key, CommittedAmount = x.Sum(c => c.CommittedAmount), DisbursedAmount = x.Sum(d => d.DisbursedAmount), ExpendedAmount = x.Sum(e => e.ExpendedAmount) });

            //DADModelViewModel
            var demoViewModelList = DADModelDataList().Where(x => x.FundAgencyId == id && x.FundSourceId == pid).GroupBy(x => x.ProjectId).Select(x => new DADModelViewModel { Id = x.Key, PId = 0, Title = x.Key.ToString(), CommittedAmount = x.Sum(c => c.CommittedAmount), DisbursedAmount = x.Sum(d => d.DisbursedAmount), ExpendedAmount = x.Sum(e => e.ExpendedAmount) });

            return demoViewModelList.ToList();
        }

        private List<DADModel> DADModelDataList()
        {
            var models = _db.DADModels.ToList();

            return models;
        }

        #endregion

    }
}
