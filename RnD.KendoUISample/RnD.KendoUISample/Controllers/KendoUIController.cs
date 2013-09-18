using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KendoUISample.ViewModels;
using RnD.KendoUISample.Models;

namespace RnD.KendoUISample.Controllers
{
    public class KendoUIController : Controller
    {
        //
        // GET: /KendoUI/

        AppDbContext _db = new AppDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dynamicGird()
        {
            return View();
        }

        public ActionResult dynamicMasterDetailsGird()
        {
            return View();
        }

        public ActionResult FinalFilter()
        {
            return View();
        }

        #region Methods

        private List<Ok_Model> GetMasters()
        {
            var ok_Models = new List<Ok_Model>{ 
                                        new Ok_Model{ Ok_ModelId=1, Ok_Name="A00", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=2, Ok_Name="B00", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=1, B_ModelId=0, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=3, Ok_Name="C00", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=2, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=4, Ok_Name="D00", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=3, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=5, Ok_Name="E00", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=0, D_ModelId=4, E_ModelId=0 },

                                        new Ok_Model{ Ok_ModelId=6, Ok_Name="A01", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=8, Ok_Name="B01", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=6, B_ModelId=0, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=10, Ok_Name="C01", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=8, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=12, Ok_Name="D01", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=10, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=14, Ok_Name="E01", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=0, D_ModelId=12, E_ModelId=0 },

                                        new Ok_Model{ Ok_ModelId=7, Ok_Name="A02", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=9, Ok_Name="B02", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=7, B_ModelId=0, C_ModelId=0, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=11, Ok_Name="C02", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=9, C_ModelId=3, D_ModelId=0, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=13, Ok_Name="D02", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=11, D_ModelId=4, E_ModelId=0 },
                                        new Ok_Model{ Ok_ModelId=15, Ok_Name="E02", CommittedAmount=10, DisbursedAmount= 5, A_ModelId=0, B_ModelId=0, C_ModelId=0, D_ModelId=13, E_ModelId=0 },

                                            };

            return ok_Models.ToList();
        }

        private List<Ok_Model> GetDadMasters()
        {
            var ok_Models = GetMasters().Where(x => x.A_ModelId == 0 && x.B_ModelId == 0 && x.C_ModelId == 0 && x.D_ModelId == 0 && x.E_ModelId == 0);

            return ok_Models.ToList();
        }

        private List<Ok_Model> GetDadDetailsOne(int id)
        {
            //B
            var ok_Models = GetMasters().Where(x => x.A_ModelId == id);

            return ok_Models.ToList();
        }

        private List<Ok_Model> GetDadDetailsTwo(int id)
        {
            //C
            var ok_Models = GetMasters().Where(x => x.B_ModelId == id);

            return ok_Models.ToList();
        }

        private List<Ok_Model> GetDadDetailsThree(int id)
        {
            //D
            var ok_Models = GetMasters().Where(x => x.C_ModelId == id);

            return ok_Models.ToList();
        }

        private List<Ok_Model> GetDadDetailsFour(int id)
        {
            //E
            var ok_Models = GetMasters().Where(x => x.E_ModelId == id);

            return ok_Models.ToList();
        }

        #endregion

        public JsonResult DadMasterRead(FilterViewModel filterModel)
        {
            var models = GetDadMasters();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadDetailOneRead(int id)
        {
            var models = GetDadDetailsOne(id);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadDetailTwoRead(int id)
        {
            var models = GetDadDetailsTwo(id);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadDetailThreeRead(int id)
        {
            var models = GetDadDetailsThree(id);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadDetailFourRead(int id)
        {
            var models = GetDadDetailsFour(id);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult dynamicGirdAjax(GridModifyViewModel model)
        {
            //string demostr = @"<script type='text/javascript' language='javascript'> $(document).ready(function () { //do something... });</script>";

            //string str = @"<script type='text/javascript' language='javascript'> $(document).ready(function () { alert('Hello! I am coming from server. :) '); $('#grid').html('Hello! man...'); });</script>";

            var kendoUIGridScript = @"<script type='text/javascript' language='javascript'> $(document).ready(function () { $('#grid').kendoGrid({dataSource:{transport:{read:'/Home/CategoryRead'},schema:{model:{fields:{CategoryId:{type:'number' },Name:{type:'string' }}}},pageSize:10,serverPaging:false,serverFiltering: false,serverSorting:false},height:250,filterable:true,groupable:true,sortable:true,pageable:{refresh:true,pageSizes:true},columns:[{field:'CategoryId',title:'Category ID',width:50,filterable:false},{field:'Name',title:'Category Name',width:250}]});});</script>";

            //return Content(str);
            return Content(kendoUIGridScript);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult dynamicMasterDetailsGirdAjax(GridModifyViewModel model)
        {
            //string demostr = @"<script type='text/javascript' language='javascript'> $(document).ready(function () { //do something... });</script>";

            //string str = @"<script type='text/javascript' language='javascript'> $(document).ready(function () { alert('Hello! I am coming from server. :) '); $('#grid').html('Hello! man...'); });</script>";

            var kendoUIGridScript = @"<script type='text/javascript' language='javascript'> $(document).ready(function () { $('#grid').kendoGrid({dataSource:{transport:{read:'/Home/CategoryRead'},schema:{model:{fields:{CategoryId:{type:'number' },Name:{type:'string' }}}},pageSize:10,serverPaging:false,serverFiltering: false,serverSorting:false},height:250,filterable:true,groupable:true,sortable:true,pageable:{refresh:true,pageSizes:true},columns:[{field:'CategoryId',title:'Category ID',width:50,filterable:false},{field:'Name',title:'Category Name',width:250}]});});</script>";

            var str1 = @"<script type='text/javascript' language='javascript'> $(document).ready(function () { $('#grid').kendoGrid({dataSource:{transport:{read:{url: '/KendoUI/DadMasterRead',data:GetFilterModel}},schema:{model:{fields:{Ok_ModelId:{type:'number'},Ok_Name:{type:'string'},CommittedAmount:{type:'number'},DisbursedAmount:{type:'number'},ExpendedAmount:{type:'number'},A_ModelId:{type:'number'},B_ModelId:{type:'number'},C_ModelId:{type:'number'},D_ModelId:{type:'number'},E_ModelId:{type:'number'}}}},aggregate:[{field:'CommittedAmount',aggregate:'sum'},{field:'DisbursedAmount',aggregate:'sum'},{field:'ExpendedAmount',aggregate:'sum'}],pageSize:10,serverPaging: false,serverFiltering: false,serverSorting:false},filterable:true,groupable:true,sortable:true,pageable:{refresh:true,pageSizes:true},detailTemplate:kendo.template($('#detailOneTemplate').html()),detailInit: detailOneInit,detailExpand:function(){$('#grid tbody .detailOne thead').hide();},columns:[{field:'Ok_ModelId',title:'Ok_ModelId',hidden:true,filterable:false},{field:'Ok_Name',title:'Funding Source/Funding Agency/Project',footerTemplate:'Grand Total:',width:250},{field:'CommittedAmount',title:'Committed',format:'{0:n}',footerTemplate:'#= sum #',filterable:false,sortable: false, width: 150 },{ field:'DisbursedAmount', title: 'Disbursed', format: '{0:n}', footerTemplate: '#= sum #', filterable: false, sortable: false, width: 150 },{ field: 'ExpendedAmount', title: 'Expended', format: '{0:n}', footerTemplate: '#= sum #', filterable: false, sortable: false, width: 150 },{ field: 'A_ModelId', title: 'A_ModelId', hidden: true, filterable: false },{ field: 'B_ModelId', title: 'B_ModelId', hidden: true, filterable: false },{ field: 'C_ModelId', title: 'C_ModelId', hidden: true, filterable: false },{ field: 'D_ModelId', title: 'D_ModelId', hidden: true, filterable: false },{ field: 'E_ModelId', title: 'E_ModelId', hidden: true, filterable: false }]});function detailOneInit(e) {var detailRow = e.detailRow;var masterId = e.data.Ok_ModelId;detailRow.find('.detailOne').kendoGrid({dataSource: {transport: {read: {url: '/KendoUI/DadDetailOneRead/' + masterId}},serverPaging: false,serverSorting: false,serverFiltering: false},scrollable: false,sortable: false,filterable: false,pageable: false,detailTemplate: kendo.template($('#detailTwoTemplate').html()),detailInit: detailTwoInit,detailExpand: function () {$('#grid tbody .detailTwo thead').hide();},columns: [{ field: 'Ok_ModelId', title: '', hidden: true },{ field: 'Ok_Name', title: '', width: 200 },{ field: 'CommittedAmount', title: '', format: '{0:n}', width: 130 },{ field: 'DibursedAmount', title: '', format: '{0:n}', width: 135 },{ field: 'ExpendedAmount', title: '', format: '{0:n}', width: 135 },{ field: 'A_ModelId', title: '', hidden: true },{ field: 'B_ModelId', title: '', hidden: true },{ field: 'C_ModelId', title: '', hidden: true },{ field: 'D_ModelId', title: '', hidden: true },{ field: 'E_ModelId', title: '', hidden: true }]});}function detailTwoInit(e) {var detailRow = e.detailRow;var detailId = e.data.Ok_ModelId;detailRow.find('.detailTwo').kendoGrid({dataSource: {transport: {read: {url: '/KendoUI/DadDetailTwoRead/' + detailId}},serverPaging: false,serverSorting: false,serverFiltering: false},scrollable: false,sortable: false,filterable: false,pageable: false,columns: [{ field: 'Ok_ModelId', title: '', hidden: true },{ field: 'Ok_Name', title: '', template: " + "\"<a href='/Home/Project/#= Ok_ModelId #' class='lnkProjectName'>#= Ok_Name #</a>" + "\", width: 222 },{ field: 'CommittedAmount', title: '', format: '{0:n}', width: 150 },{ field: 'DisbursedAmount', title: '', format: '{0:n}', width: 150 },{ field: 'ExpendedAmount', title: '', format:'{0:n}', width: 150 },{ field: 'A_ModelId', title: '', hidden: true },{ field: 'B_ModelId', title: '', hidden: true },{ field: 'C_ModelId', title: '', hidden: true },{ field: 'D_ModelId', title: '', hidden: true },{ field: 'E_ModelId', title: '', hidden: true }]});}function GetFilterModel() {var filterModel = {};filterModel.FundSource = 'FundSource';filterModel.FundAgency = 'FundAgency';filterModel.Project = 'Project';filterModel.Sector = 'Sector';filterModel.ProvinceOrArea = 'ProvinceOrArea';filterModel.DistrictOrAgency = 'DistrictOrAgency';filterModel.ReferenceNumber = 'ReferenceNumber';filterModel.FiscalYear = 'FiscalYear';return filterModel;}});</script>";

            string x = @"<document.write(""<SCR""+""IPT TYPE=""'text/javascript' SRC='""+""http""+(window.location.protocol.indexOf('https:')==0?'s':'')+""://""+gDomain+""/""+gDcsId+""/wtid.js""+""'><\/SCR""+""IPT>"");";

            string rstr = GenerateScript();

            //return Content(str);
            //return Content(kendoUIGridScript);
            //return Content(str1);
            return Content(rstr);
        }

        private string GenerateScript()
        {
            string str = string.Empty;

            str += "<script type='text/javascript' language='javascript'> $(document).ready(function () {";
            str += "$('#grid').kendoGrid({dataSource:{transport:{read:{url: '/KendoUI/DadMasterRead',data:GetFilterModel}},schema:{model:{fields:{Ok_ModelId:{type:'number'},Ok_Name:{type:'string'},CommittedAmount:{type:'number'},DisbursedAmount:{type:'number'},ExpendedAmount:{type:'number'},A_ModelId:{type:'number'},B_ModelId:{type:'number'},C_ModelId:{type:'number'},D_ModelId:{type:'number'},E_ModelId:{type:'number'}}}},aggregate:[{field:'CommittedAmount',aggregate:'sum'},{field:'DisbursedAmount',aggregate:'sum'},{field:'ExpendedAmount',aggregate:'sum'}],pageSize:10,serverPaging: false,serverFiltering: false,serverSorting:false},filterable:true,groupable:true,sortable:true,pageable:{refresh:true,pageSizes:true},detailTemplate:kendo.template($('#detailOneTemplate').html()),detailInit: detailOneInit,detailExpand:function(){$('#grid tbody .detailOne thead').hide();},columns:[{field:'Ok_ModelId',title:'Ok_ModelId',hidden:true,filterable:false},{field:'Ok_Name',title:'Funding Source/Funding Agency/Project',footerTemplate:'Grand Total:',width:250},{field:'CommittedAmount',title:'Committed',format:'{0:n}',footerTemplate:'#= sum #',filterable:false,sortable: false, width: 150 },{ field:'DisbursedAmount', title: 'Disbursed', format: '{0:n}', footerTemplate: '#= sum #', filterable: false, sortable: false, width: 150 },{ field: 'ExpendedAmount', title: 'Expended', format: '{0:n}', footerTemplate: '#= sum #', filterable: false, sortable: false, width: 150 },{ field: 'A_ModelId', title: 'A_ModelId', hidden: true, filterable: false },{ field: 'B_ModelId', title: 'B_ModelId', hidden: true, filterable: false },{ field: 'C_ModelId', title: 'C_ModelId', hidden: true, filterable: false },{ field: 'D_ModelId', title: 'D_ModelId', hidden: true, filterable: false },{ field: 'E_ModelId', title: 'E_ModelId', hidden: true, filterable: false }]});";
            str += "function detailOneInit(e) {var detailRow = e.detailRow;var masterId = e.data.Ok_ModelId;detailRow.find('.detailOne').kendoGrid({dataSource: {transport: {read: {url: '/KendoUI/DadDetailOneRead/' + masterId}},serverPaging: false,serverSorting: false,serverFiltering: false},scrollable: false,sortable: false,filterable: false,pageable: false,detailTemplate: kendo.template($('#detailTwoTemplate').html()),detailInit: detailTwoInit,detailExpand: function () {$('#grid tbody .detailTwo thead').hide();},columns: [{ field: 'Ok_ModelId', title: '', hidden: true },{ field: 'Ok_Name', title: '', width: 200 },{ field: 'CommittedAmount', title: '', format: '{0:n}', width: 130 },{ field: 'DibursedAmount', title: '', format: '{0:n}', width: 135 },{ field: 'ExpendedAmount', title: '', format: '{0:n}', width: 135 },{ field: 'A_ModelId', title: '', hidden: true },{ field: 'B_ModelId', title: '', hidden: true },{ field: 'C_ModelId', title: '', hidden: true },{ field: 'D_ModelId', title: '', hidden: true },{ field: 'E_ModelId', title: '', hidden: true }]});}";
            str += "function detailTwoInit(e) {var detailRow = e.detailRow;var detailId = e.data.Ok_ModelId;detailRow.find('.detailTwo').kendoGrid({dataSource: {transport: {read: {url: '/KendoUI/DadDetailTwoRead/' + detailId}},serverPaging: false,serverSorting: false,serverFiltering: false},scrollable: false,sortable: false,filterable: false,pageable: false,columns: [{ field: 'Ok_ModelId', title: '', hidden: true },{ field: 'Ok_Name', title: '', template: " + "\"<a href='/Home/Project/#= Ok_ModelId #' class='lnkProjectName'>#= Ok_Name #</a>" + "\", width: 222 },{ field: 'CommittedAmount', title: '', format: '{0:n}', width: 150 },{ field: 'DisbursedAmount', title: '', format: '{0:n}', width: 150 },{ field: 'ExpendedAmount', title: '', format:'{0:n}', width: 150 },{ field: 'A_ModelId', title: '', hidden: true },{ field: 'B_ModelId', title: '', hidden: true },{ field: 'C_ModelId', title: '', hidden: true },{ field: 'D_ModelId', title: '', hidden: true },{ field: 'E_ModelId', title: '', hidden: true }]});}";
            //str += "function GetFilterModel() {var filterModel = {};filterModel.FundSource = 'FundSource';filterModel.FundAgency = 'FundAgency';filterModel.Project = 'Project';filterModel.Sector = 'Sector';filterModel.ProvinceOrArea = 'ProvinceOrArea';filterModel.DistrictOrAgency = 'DistrictOrAgency';filterModel.ReferenceNumber = 'ReferenceNumber';filterModel.FiscalYear = 'FiscalYear';return filterModel;}";
            str += "});</script>";

            return str;
        }

        public ActionResult FilterDialog(int id)
        {
            return PartialView("_FilterDialog");
        }

        [HttpPost]
        public ActionResult FilterDialog(FilterViewModel model)
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

        public ActionResult ModifyDialog()
        {
            return PartialView("_ModifyDialog");
        }

        [HttpPost]
        public ActionResult ModifyDialog(GridModifyViewModel model)
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

    }
}
