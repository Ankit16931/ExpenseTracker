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
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            IEnumerable<mvcExpense> exList;
            HttpResponseMessage response = Globalvariables.webApiClient.GetAsync("Expenses").Result;
            exList = response.Content.ReadAsAsync<IEnumerable<mvcExpense>>().Result;
            return View(exList);

           
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            IEnumerable<mvcCategory> catlist;
            HttpResponseMessage response1 = Globalvariables.webApiClient.GetAsync("Categories").Result;
            catlist = response1.Content.ReadAsAsync<IEnumerable<mvcCategory>>().Result;

            var Categories = catlist.ToList();
            if (Categories != null)
            {
                ViewBag.data = Categories;
            };
            if (id == 0)
                return View(new mvcExpense());
            else
            {
                HttpResponseMessage response = Globalvariables.webApiClient.GetAsync("Expenses/" + id.ToString()).Result;
                TempData["SuccessMessage"] = " Expense Inserted Successfully";
                return View(response.Content.ReadAsAsync<mvcExpense>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcExpense exp)
        {
            IEnumerable<mvcCategory> catlist;
            HttpResponseMessage response1 = Globalvariables.webApiClient.GetAsync("Categories").Result;
            catlist = response1.Content.ReadAsAsync<IEnumerable<mvcCategory>>().Result;

            var Categories = catlist.ToList();
            if (Categories != null)
            {
                ViewBag.data = Categories;
            }

            if (exp.exId == 0)
            {
                HttpResponseMessage response = Globalvariables.webApiClient.PostAsJsonAsync("Expenses", exp).Result;
                TempData["SuccessMessage"] = " Expense Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = Globalvariables.webApiClient.PutAsJsonAsync("Expenses/" + exp.exId, exp).Result;
                TempData["SuccessMessage"] = " Expences Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Globalvariables.webApiClient.DeleteAsync("Expenses/" + id.ToString()).Result;
            TempData["SuccessMessage"] = " Expense Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
