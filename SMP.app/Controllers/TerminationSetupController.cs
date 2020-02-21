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
    public class TerminationSetupController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<TerminationSetup> TerminationSetupList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetTerminationSetup?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    TerminationSetupList = resp.Content.ReadAsAsync<IEnumerable<TerminationSetup>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(TerminationSetupList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Permission_Staff model = new Permission_Staff();
            if (id == 0)
            {
                return View(new TerminationSetup());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetTerminationSetup?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var TerminationSetup = resp.Content.ReadAsAsync<IEnumerable<TerminationSetup>>().Result;
                    var record = TerminationSetup.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(TerminationSetup model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTTerminationSetup", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTTerminationSetup", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Staff> StaffList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetStaff?id=" + id + "&taskid=" + taskid).Result;
            StaffList = resp1.Content.ReadAsAsync<IEnumerable<Staff>>().Result;
            if (!Equals(StaffList, null))
            {
                var sta = StaffList.ToList();
                ViewBag.StaffList = new SelectList(sta, "ItbId", "LastName");
            }

            IEnumerable<TerminationTypeSetup> TerminationTypeSetupList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetTerminationTypeSetup?id=" + id + "&taskid=" + taskid).Result;
            TerminationTypeSetupList = resp2.Content.ReadAsAsync<IEnumerable<TerminationTypeSetup>>().Result;
            if (!Equals(TerminationTypeSetupList, null))
            {
                var sta = TerminationTypeSetupList.ToList();
                ViewBag.TerminationTypeSetupList = new SelectList(sta, "ItbId", "TerminationName");
            }
        }

        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage resp = GlobalVariables.client.DeleteAsync("http://localhost/schoolwebapi/" + id.ToString()).Result;
        //    TempData["SuccessMessage"] = "Record Deleted Successfully";
        //    return RedirectToAction("Index");
        //}

    }
}