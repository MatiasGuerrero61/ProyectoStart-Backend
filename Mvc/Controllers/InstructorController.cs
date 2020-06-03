using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            IEnumerable<mvcInstructorModel> instructortList;
            HttpResponseMessage response = GlobalVariables.wepApiClient.GetAsync("Instructor").Result;
            instructortList = response.Content.ReadAsAsync<IEnumerable<mvcInstructorModel>>().Result;
            return View(instructortList);
        }

        public ActionResult AddOrEditInstructor(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcInstructorModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.GetAsync("Instructor/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcInstructorModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEditInstructor(mvcInstructorModel instructor)
        {
            if (instructor.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.PostAsJsonAsync("Instructor", instructor).Result;
                TempData["SuccessMessage"] = "Saved Succefully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.PutAsJsonAsync("Instructor/" + instructor.Id, instructor).Result;
                TempData["SuccessMessage"] = "Updated Succefully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.wepApiClient.DeleteAsync("Instructor/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Succefully";
            return RedirectToAction("Index");
        }
    }
}