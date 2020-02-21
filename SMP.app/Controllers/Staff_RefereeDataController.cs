using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class Staff_RefereeDataController : Controller
    {
        // GET: Arms
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
                {
                IEnumerable<Staff_RefereeData> Staff_RefereeDataList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaff_RefereeData?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Staff_RefereeDataList = resp.Content.ReadAsAsync<IEnumerable<Staff_RefereeData>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(Staff_RefereeDataList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Arm model = new Arm();
            if (id == 0)
            {
                return View(new Staff_RefereeData());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaff_RefereeData?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var refe = resp.Content.ReadAsAsync<IEnumerable<Staff_RefereeData>>().Result;
                    var record = refe.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Staff_RefereeData model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaff_RefereeData", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaff_RefereeData", model).Result;
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
            IEnumerable<Country> CountryList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetCountry?id=" + id + "&taskid=" + taskid).Result;
            CountryList = resp1.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            if (!Equals(CountryList, null))
            {
                var programs = CountryList.ToList();
                ViewBag.CountryList = new SelectList(programs, "ItbId", "Country_Name");
            }

            IEnumerable<State> StateList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
            StateList = resp2.Content.ReadAsAsync<IEnumerable<State>>().Result;
            if (!Equals(StateList, null))
            {
                var classes = StateList.ToList();
                ViewBag.StateList = new SelectList(classes, "ItbId", "State_Name");
            }

            IEnumerable<Staff> StaffList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetStaff?id=" + id + "&taskid=" + taskid).Result;
            StaffList = resp3.Content.ReadAsAsync<IEnumerable<Staff>>().Result;
            if (!Equals(StaffList, null))
            {
                var staffs = StaffList.ToList();
                ViewBag.StaffList = new SelectList(staffs, "ItbId", "LastName");
            }

        }
    }
}