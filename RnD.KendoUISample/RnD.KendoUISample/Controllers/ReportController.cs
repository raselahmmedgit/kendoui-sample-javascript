using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KendoUISample.ViewModels;

namespace RnD.KendoUISample.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        //GetDonarCriteriaList
        public JsonResult GetDonarCriteriaList()
        {
            var donarCriteriaList = new List<SelectListItem> { 
                new SelectListItem { Text = "World Bank", Value = "1", Selected = false }, 
                new SelectListItem { Text = "ADB", Value = "2", Selected = false }, 
                new SelectListItem { Text = "IDB", Value = "3", Selected = false } 
            };

            return Json(donarCriteriaList, JsonRequestBehavior.AllowGet);
        }

        //GetProjectTitleCriteriaList
        public JsonResult GetProjectTitleCriteriaList()
        {
            var projectTitleCriteriaList = new List<SelectListItem> { 
                new SelectListItem { Text = "Project 001", Value = "1", Selected = false }, 
                new SelectListItem { Text = "Project 002", Value = "2", Selected = false }, 
                new SelectListItem { Text = "Project 003", Value = "3", Selected = false },
                new SelectListItem { Text = "Project 004", Value = "4", Selected = false },
                new SelectListItem { Text = "Project 005", Value = "5", Selected = false }
            };

            return Json(projectTitleCriteriaList, JsonRequestBehavior.AllowGet);
        }

        //GetProjectNumberCriteriaList
        public JsonResult GetProjectNumberCriteriaList()
        {
            var projectTitleCriteriaList = new List<SelectListItem> { 
                new SelectListItem { Text = "P-001", Value = "1", Selected = false }, 
                new SelectListItem { Text = "P-002", Value = "2", Selected = false }, 
                new SelectListItem { Text = "P-003", Value = "3", Selected = false },
                new SelectListItem { Text = "P-004", Value = "4", Selected = false },
                new SelectListItem { Text = "P-005", Value = "5", Selected = false }
            };

            return Json(projectTitleCriteriaList, JsonRequestBehavior.AllowGet);
        }

        //Search
        [HttpPost]
        //public ActionResult Search(List<ReportColumnViewModel> columnList, List<ReportCriteriaViewModel> criteriaList)
        public ActionResult Search(List<ReportViewModel> modelList)
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
