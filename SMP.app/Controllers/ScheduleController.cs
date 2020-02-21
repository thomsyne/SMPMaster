
using SMP.app;
using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class ScheduleController : Controller
    {
        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Class> ClassList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
            ClassList = resp.Content.ReadAsAsync<IEnumerable<Class>>().Result;
            if (!Equals(ClassList, null))
            {
                var Classes = ClassList.ToList();
                ViewBag.ClassList = new SelectList(Classes, "ItbId", "Name");
            }


            IEnumerable<Subject> SubjectList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetSubject?id=" + id + "&taskid=" + taskid).Result;
            SubjectList = resp1.Content.ReadAsAsync<IEnumerable<Subject>>().Result;
            if (!Equals(SubjectList, null))
            {
                var Subjects = SubjectList.ToList();
                ViewBag.SubjectList = new SelectList(Subjects, "ItbId", "Subject_Name");
            }

            IEnumerable<Session> SessionList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetSession?id=" + id + "&taskid=" + taskid).Result;
            SessionList = resp2.Content.ReadAsAsync<IEnumerable<Session>>().Result;
            if (!Equals(SessionList, null))
            {
                var Sessions = SessionList.ToList();
                ViewBag.SessionList = new SelectList(Sessions, "ItbId", "Name");
            }

            IEnumerable<Term> TermList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetTerm?id=" + id + "&taskid=" + taskid).Result;
            TermList = resp3.Content.ReadAsAsync<IEnumerable<Term>>().Result;
            if (!Equals(TermList, null))
            {
                var Terms = TermList.ToList();
                ViewBag.TermList = new SelectList(Terms, "ItbId", "Term_Name");
            }

            IEnumerable<Arms> ArmList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetArms?id=" + id + "&taskid=" + taskid).Result;
            ArmList = resp4.Content.ReadAsAsync<IEnumerable<Arms>>().Result;
            if (!Equals(ArmList, null))
            {
                var Arms = ArmList.ToList();
                ViewBag.ArmList = new SelectList(Arms, "ItbId", "Name");
            }

            IEnumerable<Period> PeriodList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetPeriod?id=" + id + "&taskid=" + taskid).Result;
            PeriodList = resp5.Content.ReadAsAsync<IEnumerable<Period>>().Result;
            if (!Equals(PeriodList, null))
            {
                var Periods = PeriodList.ToList();
                ViewBag.PeriodList = new SelectList(Periods, "ItbId", "Name");
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


        IEnumerable<Schedule_Timetable> Schedule_TimetableList = null;
        // GET: Schedule
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchedule_Timetable?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Schedule_TimetableList = resp.Content.ReadAsAsync<IEnumerable<Schedule_Timetable>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(Schedule_TimetableList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //ScheduleTimetable model = new ScheduleTimetable();
            if (id == 0)
            {
                return View(new Schedule_Timetable());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchedule_Timetable?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Schedule_Timetable = resp.Content.ReadAsAsync<IEnumerable<Schedule_Timetable>>().Result;
                    var record = Schedule_Timetable.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Schedule_Timetable model)
        {
            BindCombo();

            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchedule_Timetable", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchedule_Timetable", model).Result;
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
    }
}