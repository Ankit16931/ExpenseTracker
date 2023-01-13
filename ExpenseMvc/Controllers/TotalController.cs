using ExpenseMvc.Models;
using ExpenseMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpenseMvc.Controllers
{
    public class TotalController : Controller
    {
        // GET: Total
        public ActionResult Index()
        {
            IEnumerable<mvcTotal> totList;
            HttpResponseMessage response = Globalvariables.webApiClient.GetAsync("Totals").Result;
            totList = response.Content.ReadAsAsync<IEnumerable<mvcTotal>>().Result;
            return View(totList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcTotal());
            else
            {
                HttpResponseMessage response = Globalvariables.webApiClient.GetAsync("Totals/" + id.ToString()).Result;
                TempData["SuccessMessage"] = " Total Expense Inserted Successfully";
                return View(response.Content.ReadAsAsync<mvcTotal>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcTotal totalexp)
        {
            if (totalexp.totId == 0)
            {
                HttpResponseMessage response = Globalvariables.webApiClient.PostAsJsonAsync("Totals", totalexp).Result;
                TempData["SuccessMessage"] = " Total Expance Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = Globalvariables.webApiClient.PutAsJsonAsync("Totals/" + totalexp.totId, totalexp).Result;
                TempData["SuccessMessage"] = " Total Expance Updated Successfully";
            }
            return RedirectToAction("Index");
        }

    }
}