using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class Club_MembershipController : Controller
    {
        // GET: ClubMembership
            IEnumerable<Club_Membership> ClubMembershipList = null;
            // GET: School
            public ActionResult Index(int id = 0, int taskid = 7)
            {
                try
                {
                    //IEnumerable<School_Details> SchoolDetailsList = null;

                    HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetClub_Membership?id=" + id + "&taskid=" + taskid).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                    ClubMembershipList = resp.Content.ReadAsAsync<IEnumerable<Club_Membership>>().Result;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                    return View(ClubMembershipList);
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
                    return View(new Club_Membership());
                }
                else
                {
                    taskid = 6;
                    HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetClub_Membership?id=" + id + "&taskid=" + taskid).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        var schools = resp.Content.ReadAsAsync<IEnumerable<Club_Membership>>().Result;
                        var record = schools.FirstOrDefault();
                        return View(record);
                    }
                    return View();
                }
            }

            [HttpPost]
            public ActionResult AddOrEdit(Club_Membership model)
            {
            BindCombo();

                if (model.ItbId == 0)
                {
                    model.taskid = 2;
                    HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTClub_Membership", model).Result;
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                }
                else
                {
                    model.taskid = 4;
                    HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTClub_Membership", model).Result;
                    TempData["SuccessMessage"] = "Record Updated Successfully";
                }
                return RedirectToAction("Index");
            }

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Student> StudentList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetStudent?id=" + id + "&taskid=" + taskid).Result;
            StudentList = resp6.Content.ReadAsAsync<IEnumerable<Student>>().Result;
            if (!Equals(StudentList, null))
            {
                var students = StudentList.ToList();
                ViewBag.StudentList = new SelectList(students, "ItbId", "Student_Code");
            }

            IEnumerable<Clubs> ClubsList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetClubs?id=" + id + "&taskid=" + taskid).Result;
            ClubsList = resp4.Content.ReadAsAsync<IEnumerable<Clubs>>().Result;
            if (!Equals(ClubsList, null))
            {
                var clubs = ClubsList.ToList();
                ViewBag.ClubsList = new SelectList(clubs, "ItbId", "Club_Name");
            }

            IEnumerable<Class> ClassList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
            ClassList = resp5.Content.ReadAsAsync<IEnumerable<Class>>().Result;
            if (!Equals(ClassList, null))
            {
                var classes = ClassList.ToList();
                ViewBag.ClassList = new SelectList(classes, "ItbId", "Name");
            }

            IEnumerable<Arms> ArmsList = null;
            HttpResponseMessage resp7 = GlobalVariables.client.GetAsync("GetArms?id=" + id + "&taskid=" + taskid).Result;
            ArmsList = resp7.Content.ReadAsAsync<IEnumerable<Arms>>().Result;
            if (!Equals(ArmsList, null))
            {
                var arms = ArmsList.ToList();
                ViewBag.ArmsList = new SelectList(arms, "ItbId", "Name");
            }

            IEnumerable<Term> TermList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetTerm?id=" + id + "&taskid=" + taskid).Result;
            TermList = resp2.Content.ReadAsAsync<IEnumerable<Term>>().Result;
            if (!Equals(TermList, null))
            {
                var terms = TermList.ToList();
                ViewBag.TermList = new SelectList(terms, "ItbId", "Term_Name");
            }

            IEnumerable<Session> SessionList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetSession?id=" + id + "&taskid=" + taskid).Result;
            SessionList = resp1.Content.ReadAsAsync<IEnumerable<Session>>().Result;
            if (!Equals(SessionList, null))
            {
                var sessions = SessionList.ToList();
                ViewBag.SessionList = new SelectList(sessions, "ItbId", "Name");
            }


            IEnumerable<Program> ProgramList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetProgram?id=" + id + "&taskid=" + taskid).Result;
            ProgramList = resp3.Content.ReadAsAsync<IEnumerable<Program>>().Result;
            if (!Equals(ProgramList, null))
            {
                var programs = ProgramList.ToList();
                ViewBag.ProgramList = new SelectList(programs, "ItbId", "Program_Name");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp9 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp9.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
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