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
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Subject> SubjectList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSubject?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    SubjectList = resp.Content.ReadAsAsync<IEnumerable<Subject>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(SubjectList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Subject model = new Subject();
            if (id == 0)
            {
                return View(new Subject());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSubject?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var subjects = resp.Content.ReadAsAsync<IEnumerable<Subject>>().Result;
                    var record = subjects.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Subject model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSubject", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSubject", model).Result;
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
            IEnumerable<Program> ProgramList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetProgram?id=" + id + "&taskid=" + taskid).Result;
            ProgramList = resp1.Content.ReadAsAsync<IEnumerable<Program>>().Result;
            if (!Equals(ProgramList, null))
            {
                var programs = ProgramList.ToList();
                ViewBag.ProgramList = new SelectList(programs, "ItbId", "Program_Name ");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp6.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var sch = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(sch, "ItbId", "Name");
            }

            IEnumerable<Campus> CampusList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
            CampusList = resp3.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
            if (!Equals(CampusList, null))
            {
                var camp = CampusList.ToList();
                ViewBag.CampusList = new SelectList(camp, "ItbId", "Name");
            }
        }
        }
}