using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class DBAuditController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<DBAudit> DBAuditList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetDBAudit?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    DBAuditList = resp.Content.ReadAsAsync<IEnumerable<DBAudit>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(DBAuditList);
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
                return View(new DBAudit());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetDBAudit?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var DBAudit = resp.Content.ReadAsAsync<IEnumerable<DBAudit>>().Result;
                    var record = DBAudit.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(DBAudit model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTDBAudit", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTDBAudit", model).Result;
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
        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Record> RecordList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetRecord?id=" + id + "&taskid=" + taskid).Result;
            RecordList = resp1.Content.ReadAsAsync<IEnumerable<Record>>().Result;
            if (!Equals(RecordList, null))
            {
                var programs = RecordList.ToList();
                ViewBag.RecordList = new SelectList(programs, "ItbId", "Record_Name");
            }

        }
    }
}