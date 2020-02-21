using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class CurrencyController : Controller
    {
        // GET: Currency
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Currency> CurrencyList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetCurrency?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    CurrencyList = resp.Content.ReadAsAsync<IEnumerable<Currency>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(CurrencyList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Currency model = new Currency();
            if (id == 0)
            {
                return View(new Currency());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetCurrency?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var currencies = resp.Content.ReadAsAsync<IEnumerable<Currency>>().Result;
                    var record = currencies.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Currency model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTCurrency", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTCurrency", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Country> CountryList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetCountry?id=" + id + "&taskid=" + taskid).Result;
            CountryList = resp1.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            if (!Equals(CountryList, null))
            {
                var coun = CountryList.ToList();
                ViewBag.CountryList = new SelectList(coun, "ItbId", "Country_Name");
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