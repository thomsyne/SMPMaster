using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class Staff_AcademicController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Staff_Academic> Staff_AcademicList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaff_Academic?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Staff_AcademicList = resp.Content.ReadAsAsync<IEnumerable<Staff_Academic>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(Staff_AcademicList);
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
                return View(new Staff_Academic());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaff_Academic?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Staff_Academic = resp.Content.ReadAsAsync<IEnumerable<Staff_Academic>>().Result;
                    var record = Staff_Academic.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Staff_Academic model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaff_Academic", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaff_Academic", model).Result;
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
        }

            //public ActionResult Delete(int id)
            //{
            //    HttpResponseMessage resp = GlobalVariables.client.DeleteAsync("http://localhost/schoolwebapi/" + id.ToString()).Result;
            //    TempData["SuccessMessage"] = "Record Deleted Successfully";
            //    return RedirectToAction("Index");
            //}

        }
}