using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        IEnumerable<Events> EventsList = null;
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                //IEnumerable<School_Details> SchoolDetailsList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetEvents?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    EventsList = resp.Content.ReadAsAsync<IEnumerable<Events>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(EventsList);
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
                return View(new Events());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetEvents?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var schools = resp.Content.ReadAsAsync<IEnumerable<Events>>().Result;
                    var record = schools.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Events model)
        {
            BindCombo();

            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTEvents", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTEvents", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Session> SessionList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetSession?id=" + id + "&taskid=" + taskid).Result;
            SessionList = resp1.Content.ReadAsAsync<IEnumerable<Session>>().Result;
            if (!Equals(SessionList, null))
            {
                var sessions = SessionList.ToList();
                ViewBag.SessionList = new SelectList(sessions, "ItbId", "Name");
            }

            IEnumerable<Term> TermList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetTerm?id=" + id + "&taskid=" + taskid).Result;
            TermList = resp2.Content.ReadAsAsync<IEnumerable<Term>>().Result;
            if (!Equals(TermList, null))
            {
                var terms = TermList.ToList();
                ViewBag.TermList = new SelectList(terms, "ItbId", "Term_Name");
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
            HttpResponseMessage resp12 = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
            CampusList = resp12.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
            if (!Equals(CampusList, null))
            {
                var camp = CampusList.ToList();
                ViewBag.CampusList = new SelectList(camp, "ItbId", "Name");
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