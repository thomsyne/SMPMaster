using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class StaffDeductionController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<StaffDeduction> StaffDeductionList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaffDeduction?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    StaffDeductionList = resp.Content.ReadAsAsync<IEnumerable<StaffDeduction>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(StaffDeductionList);
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
                return View(new StaffDeduction());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaffDeduction?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var StaffDeduction = resp.Content.ReadAsAsync<IEnumerable<StaffDeduction>>().Result;
                    var record = StaffDeduction.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(StaffDeduction model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaffDeduction", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaffDeduction", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Deduction> DeductionList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetDeduction?id=" + id + "&taskid=" + taskid).Result;
            DeductionList = resp1.Content.ReadAsAsync<IEnumerable<Deduction>>().Result;
            if (!Equals(DeductionList, null))
            {
                var ded = DeductionList.ToList();
                ViewBag.DeductionList = new SelectList(ded, "ItbId", "Description");
            }

            IEnumerable<Staff> StaffList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetStaff?id=" + id + "&taskid=" + taskid).Result;
            StaffList = resp2.Content.ReadAsAsync<IEnumerable<Staff>>().Result;
            if (!Equals(StaffList, null))
            {
                var sta = StaffList.ToList();
                ViewBag.StaffList = new SelectList(sta, "ItbId", "LastName");
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