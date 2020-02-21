using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class CampusController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Campus> CampusList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    CampusList = resp.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(CampusList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Campus model = new Campus();
            if (id == 0)
            {
                return View(new Campus());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var campuses = resp.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
                    var record = campuses.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Campus model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTCampus", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTCampus", model).Result;
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
            ////IEnumerable<School_Details> SchoolList = null;
            ////HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            ////SchoolList = resp.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            ////if (!Equals(SchoolList, null))
            ////{
            ////    var school = SchoolList.ToList();
            ////    ViewBag.SchoolList = new SelectList(school, "ItbId", "Name");
            ////}

            IEnumerable<Division> DivisionList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetDivision?id=" + id + "&taskid=" + taskid).Result;
            DivisionList = resp1.Content.ReadAsAsync<IEnumerable<Division>>().Result;
            if (!Equals(DivisionList, null))
            {
                var div = DivisionList.ToList();
                ViewBag.DivisionList = new SelectList(div, "ItbId", "Division_Name");
            }
        }
    }
}