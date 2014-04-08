using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KendoUISample.Models;

namespace RnD.KendoUISample.Controllers
{
    public class DialogController : Controller
    {
        //
        // GET: /Dialog/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var category = new Category();
            return PartialView("_Add", category);
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Add(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //_db.Categories.Add(category);
                    //_db.SaveChanges();



                    return Content(GetReturnAppWindow(Boolean.TrueString, "success", "Add Successfully."));
                }

                //return View(category);
                //return PartialView("_Create", category);
                return Content(GetReturnAppWindow(Boolean.FalseString, "warn", "Please review your form."));
            }
            catch (Exception ex)
            {
                return Content(GetReturnAppWindow(Boolean.FalseString, "error", "Error Occured!"));
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Json(new { status = Boolean.FalseString, messageType = "success", messageText = "Deleted successfully." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { status = Boolean.FalseString, messageType = "warn", messageText = "Deleted data not found." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = Boolean.FalseString, messageType = "error", messageText = "Error Occured!" }, JsonRequestBehavior.AllowGet);
            }

        }

        public string GetReturnAppWindow(string status, string messageType, string messageText)
        {
            string strReturn = string.Empty;

            strReturn = status + "|" + messageType + "|" + messageText;

            return strReturn;
        }
    }
}
