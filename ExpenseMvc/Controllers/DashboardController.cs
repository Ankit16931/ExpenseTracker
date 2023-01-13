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
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            IEnumerable<mvcCategory> catlist;
            HttpResponseMessage response1 = Globalvariables.webApiClient.GetAsync("Categories").Result;
            catlist = response1.Content.ReadAsAsync<IEnumerable<mvcCategory>>().Result;

            var Categories = catlist.ToList();
            if (Categories != null)
            {
                ViewBag.categories = Categories;
            }

            IEnumerable<mvcTotal> totexplist;
            HttpResponseMessage response2 = Globalvariables.webApiClient.GetAsync("Totals").Result;
            totexplist = response2.Content.ReadAsAsync<IEnumerable<mvcTotal>>().Result;
            var totalexpenses = totexplist.ToList();
            if (totalexpenses != null)
            {
                ViewBag.totalexpenses = totalexpenses;
            }

            IEnumerable<mvcExpense> explist;
            HttpResponseMessage response = Globalvariables.webApiClient.GetAsync("Expenses").Result;
            explist = response.Content.ReadAsAsync<IEnumerable<mvcExpense>>().Result;

            var Expenses = explist.ToList();
            if (Expenses != null)
            {
                ViewBag.expenses = Expenses;
            }
            int kj = 0;
            foreach(var i in explist)
            {
               kj += ((int)i.exAmount);
            }
            ViewBag.kj = kj;
            int jl=0;
            foreach(var j in explist)
            {
                foreach(var i in catlist)
                {
                    if(i.catId==j.catId)
                    {
                        jl += ((int)j.exAmount);
                    }
                }
            }
            int am = 0;
            foreach(var i in totexplist)
            {
                am=((int)i.totEx);
            }            
            if (kj>am) {
                TempData["amount"] = "Expense Amount is greater than TotalExpense";
            }
            ViewBag.jl = jl;
            return View();
        }
    }
    
}