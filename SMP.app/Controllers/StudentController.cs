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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Student> StudentList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStudent?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    StudentList = resp.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(StudentList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Student model = new Student();
            if (id == 0)
            {
                return View(new Student());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStudent?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var student = resp.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                    var record = student.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Student model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStudent", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStudent", model).Result;
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
            IEnumerable<School_Details> SchoolList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            SchoolList = resp.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(SchoolList, null))
            {
                var school = SchoolList.ToList();
                ViewBag.SchoolList = new SelectList(school, "ItbId", "Name");
            }

            IEnumerable<Parents> ParentsList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetParents?id=" + id + "&taskid=" + taskid).Result;
            ParentsList = resp1.Content.ReadAsAsync<IEnumerable<Parents>>().Result;
            if (!Equals(ParentsList, null))
            {
                var par = ParentsList.ToList();
                ViewBag.ParentsList = new SelectList(par, "ItbId", "LastName");
            }

            IEnumerable<Country> CountryList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetCountry?id=" + id + "&taskid=" + taskid).Result;
            CountryList = resp2.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            if (!Equals(CountryList, null))
            {
                var cou = CountryList.ToList();
                ViewBag.CountryList = new SelectList(cou, "ItbId", "Country_Name");
            }

            IEnumerable<State> StateList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
            StateList = resp3.Content.ReadAsAsync<IEnumerable<State>>().Result;
            if (!Equals(StateList, null))
            {
                var state = StateList.ToList();
                ViewBag.StateList = new SelectList(state, "ItbId", "State_Name");
            }

            IEnumerable<Arms> ArmsList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetArms?id=" + id + "&taskid=" + taskid).Result;
            ArmsList = resp4.Content.ReadAsAsync<IEnumerable<Arms>>().Result;
            if (!Equals(ArmsList, null))
            {
                var arm = ArmsList.ToList();
                ViewBag.ArmList = new SelectList(arm, "ItbId", "Name");
            }

            IEnumerable<Class> ClassList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
            ClassList = resp5.Content.ReadAsAsync<IEnumerable<Class>>().Result;
            if (!Equals(ClassList, null))
            {
                var classes = ClassList.ToList();
                ViewBag.ClassList = new SelectList(classes, "ItbId", "Name");
            }

            IEnumerable<Prefect> PrefectList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetPrefect?id=" + id + "&taskid=" + taskid).Result;
            PrefectList = resp6.Content.ReadAsAsync<IEnumerable<Prefect>>().Result;
            if (!Equals(PrefectList, null))
            {
                var pre = PrefectList.ToList();
                ViewBag.PrefectList = new SelectList(pre, "ItbId", "Prefect_Role");
            }

            IEnumerable<Prefect_Type> Prefect_TypeList = null;
            HttpResponseMessage resp7 = GlobalVariables.client.GetAsync("GetPrefect_Type?id=" + id + "&taskid=" + taskid).Result;
            Prefect_TypeList = resp7.Content.ReadAsAsync<IEnumerable<Prefect_Type>>().Result;
            if (!Equals(Prefect_TypeList, null))
            {
                var pr = Prefect_TypeList.ToList();
                ViewBag.Prefect_TypeList = new SelectList(pr, "ItbId", "Type");
            }

            IEnumerable<Religion> ReligionList = null;
            HttpResponseMessage resp8 = GlobalVariables.client.GetAsync("GetReligion?id=" + id + "&taskid=" + taskid).Result;
            ReligionList = resp8.Content.ReadAsAsync<IEnumerable<Religion>>().Result;
            if (!Equals(ReligionList, null))
            {
                var religion = ReligionList.ToList();
                ViewBag.ReligionList = new SelectList(religion, "ItbId", "Name");
            }

            IEnumerable<Gender> GenderList = null;
            HttpResponseMessage resp9 = GlobalVariables.client.GetAsync("GetGender?id=" + id + "&taskid=" + taskid).Result;
            GenderList = resp9.Content.ReadAsAsync<IEnumerable<Gender>>().Result;
            if (!Equals(GenderList, null))
            {
                var gender = GenderList.ToList();
                ViewBag.GenderList = new SelectList(gender, "ItbId", "Gender_Name");
            }

            IEnumerable<Program> ProgramList = null;
            HttpResponseMessage resp10 = GlobalVariables.client.GetAsync("GetProgram?id=" + id + "&taskid=" + taskid).Result;
            ProgramList = resp10.Content.ReadAsAsync<IEnumerable<Program>>().Result;
            if (!Equals(ProgramList, null))
            {
                var prog = ProgramList.ToList();
                ViewBag.ProgramList = new SelectList(prog, "ItbId", "Program_Name");
            }

            IEnumerable<Session> SessionList = null;
            HttpResponseMessage resp11 = GlobalVariables.client.GetAsync("GetSession?id=" + id + "&taskid=" + taskid).Result;
            SessionList = resp11.Content.ReadAsAsync<IEnumerable<Session>>().Result;
            if (!Equals(SessionList, null))
            {
                var sess = SessionList.ToList();
                ViewBag.SessionList = new SelectList(sess, "ItbId", "Name");
            }

            IEnumerable<Blood_Group> Blood_GroupList = null;
            HttpResponseMessage resp12 = GlobalVariables.client.GetAsync("GetBlood_Group?id=" + id + "&taskid=" + taskid).Result;
            Blood_GroupList = resp12.Content.ReadAsAsync<IEnumerable<Blood_Group>>().Result;
            if (!Equals(Blood_GroupList, null))
            {
                var bg = Blood_GroupList.ToList();
                ViewBag.Blood_GroupList = new SelectList(bg, "ItbId", "Name");
            }

            IEnumerable<Campus> CampusList = null;
            HttpResponseMessage resp13 = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
            CampusList = resp13.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
            if (!Equals(CampusList, null))
            {
                var camp = CampusList.ToList();
                ViewBag.CampusList = new SelectList(camp, "ItbId", "Name");
            }

            IEnumerable<StudentType> StudentTypeList = null;
            HttpResponseMessage resp14 = GlobalVariables.client.GetAsync("GetStudentType?id=" + id + "&taskid=" + taskid).Result;
            StudentTypeList = resp14.Content.ReadAsAsync<IEnumerable<StudentType>>().Result;
            if (!Equals(StudentTypeList, null))
            {
                var Studenttype = StudentTypeList.ToList();
                ViewBag.StudentTypeList = new SelectList(Studenttype, "ItbId", "Student_Type");
            }
        }
    }
}