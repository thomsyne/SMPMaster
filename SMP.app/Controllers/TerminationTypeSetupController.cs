using SMP.app;
using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class TerminationTypeSetupController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<TerminationTypeSetup> TerminationTypeSetupList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetTerminationTypeSetup?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    TerminationTypeSetupList = resp.Content.ReadAsAsync<IEnumerable<TerminationTypeSetup>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(TerminationTypeSetupList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            //BindCombo();
            //Permission_Staff model = new Permission_Staff();
            if (id == 0)
            {
                return View(new TerminationTypeSetup());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetTerminationTypeSetup?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var TerminationTypeSetup = resp.Content.ReadAsAsync<IEnumerable<TerminationTypeSetup>>().Result;
                    var record = TerminationTypeSetup.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(TerminationTypeSetup model)
        {
            //BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTTerminationTypeSetup", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTTerminationTypeSetup", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage resp = GlobalVariables.client.DeleteAsync("http://localhost/schoolwebapi/" + id.ToString()).Result;
        //    TempData["SuccessMessage"] = "Record Deleted Successfully";
        //    return RedirectToAction("Index");
        //}

    }
}