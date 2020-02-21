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
    public class TermController : Controller
    {
        // GET: Term
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Term> TermList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetTerm?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    TermList = resp.Content.ReadAsAsync<IEnumerable<Term>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(TermList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Term model = new Term();
            if (id == 0)
            {
                return View(new Term());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetTerm?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var terms = resp.Content.ReadAsAsync<IEnumerable<Term>>().Result;
                    var record = terms.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Term model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTTerm", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTTerm", model).Result;
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
            IEnumerable<Session> SessionList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSession?id=" + id + "&taskid=" + taskid).Result;
            SessionList = resp.Content.ReadAsAsync<IEnumerable<Session>>().Result;
            if (!Equals(SessionList, null))
            {
                var session = SessionList.ToList();
                ViewBag.SessionList = new SelectList(session, "ItbId", "Name");
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
    }
}