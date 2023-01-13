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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<mvcCategory> catList;
            HttpResponseMessage response = Globalvariables.webApiClient.GetAsync("Categories").Result;
            catList = response.Content.ReadAsAsync<IEnumerable<mvcCategory>>().Result;
            return View(catList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcCategory());
            else
            {
                HttpResponseMessage response = Globalvariables.webApiClient.GetAsync("Categories/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCategory>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcCategory cat)
        {
            if (cat.catId == 0)
            {
                HttpResponseMessage response = Globalvariables.webApiClient.PostAsJsonAsync("Categories", cat).Result;
                TempData["SuccessMessage"] = " Category Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = Globalvariables.webApiClient.PutAsJsonAsync("Categories/" + cat.catId, cat).Result;
                TempData["SuccessMessage"] = "Category Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Globalvariables.webApiClient.DeleteAsync("Categories/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}