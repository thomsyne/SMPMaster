using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<School_Details> SchoolDetailsList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    SchoolDetailsList = resp.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(SchoolDetailsList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //School_Details model = new School_Details();
            if (id == 0)
            {
                return View(new School_Details());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var schools = resp.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
                    var record = schools.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(School_Details model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchool_Details", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchool_Details", model).Result;
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
            HttpResponseMessage resp0 = GlobalVariables.client.GetAsync("GetCountry?id=" + id + "&taskid=" + taskid).Result;
            CountryList = resp0.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            if (!Equals(CountryList, null))
            {
                var countries = CountryList.ToList();
                ViewBag.CountryList = new SelectList(countries, "ItbId", "Country_Name");
            }

            IEnumerable<State> StateList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
            StateList = resp.Content.ReadAsAsync<IEnumerable<State>>().Result;
            if (!Equals(StateList, null))
            {
                var state = StateList.ToList();
                ViewBag.StateList = new SelectList(state, "ItbId", "State_Name");
            }

            IEnumerable<LGA> LGAList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetLGA?id=" + id + "&taskid=" + taskid).Result;
            LGAList = resp1.Content.ReadAsAsync<IEnumerable<LGA>>().Result;
            if (!Equals(LGAList, null))
            {
                var lgas = LGAList.ToList();
                ViewBag.LGAList = new SelectList(lgas, "ItbId", "Name");
            }

        }

    }
}