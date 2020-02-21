using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class PayRollController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<PayRoll> PayRollList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPayRoll?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    PayRollList = resp.Content.ReadAsAsync<IEnumerable<PayRoll>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(PayRollList);
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
                return View(new PayRoll());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPayRoll?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var PayRoll = resp.Content.ReadAsAsync<IEnumerable<PayRoll>>().Result;
                    var record = PayRoll.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(PayRoll model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPayRoll", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPayRoll", model).Result;
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
                var staff = StaffList.ToList();
                ViewBag.StaffList = new SelectList(staff, "ItbId", "LastName");
            }

            IEnumerable<Department> DepartmentList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetDepartment?id=" + id + "&taskid=" + taskid).Result;
            DepartmentList = resp2.Content.ReadAsAsync<IEnumerable<Department>>().Result;
            if (!Equals(DepartmentList, null))
            {
                var dept = DepartmentList.ToList();
                ViewBag.DepartmentList = new SelectList(dept, "ItbId", "Dept_Name");
            }


            IEnumerable<Deduction> DeductionList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetDeduction?id=" + id + "&taskid=" + taskid).Result;
            DeductionList = resp5.Content.ReadAsAsync<IEnumerable<Deduction>>().Result;
            if (!Equals(DeductionList, null))
            {
                var dcd = DeductionList.ToList();
                ViewBag.DeductionList = new SelectList(dcd, "ItbId", "Description");
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