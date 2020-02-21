using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class Permission_StaffController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Permission_Staff> Permission_StaffList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPermission_Staff?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Permission_StaffList = resp.Content.ReadAsAsync<IEnumerable<Permission_Staff>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(Permission_StaffList);
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
                return View(new Permission_Staff());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPermission_Staff?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Permission_Staff = resp.Content.ReadAsAsync<IEnumerable<Permission_Staff>>().Result;
                    var record = Permission_Staff.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Permission_Staff model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPermission_Staff", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPermission_Staff", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Staff> StaffList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetStaff?id=" + id + "&taskid=" + taskid).Result;
            StaffList = resp5.Content.ReadAsAsync<IEnumerable<Staff>>().Result;
            if (!Equals(StaffList, null))
            {
                var sta = StaffList.ToList();
                ViewBag.StaffList = new SelectList(sta, "ItbId", "LastName");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp6.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var sch = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(sch, "ItbId", "Name");
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