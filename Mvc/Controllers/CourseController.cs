using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<mvcCourseModel> courseList;
            HttpResponseMessage response = GlobalVariables.wepApiClient.GetAsync("Course").Result;
            courseList = response.Content.ReadAsAsync<IEnumerable<mvcCourseModel>>().Result;
            return View(courseList);
        }
        public ActionResult AddOrEditCourse(int id = 0)
        {
            IEnumerable<mvcDepartmentModel> department;
            HttpResponseMessage deplist = GlobalVariables.wepApiClient.GetAsync("Department").Result;
            department = deplist.Content.ReadAsAsync<IEnumerable<mvcDepartmentModel>>().Result;
            ViewBag.Departments = department;

            IEnumerable<mvcInstructorModel> instructor;
            HttpResponseMessage instlist = GlobalVariables.wepApiClient.GetAsync("Instructor").Result;
            instructor = instlist.Content.ReadAsAsync<IEnumerable<mvcInstructorModel>>().Result;
            ViewBag.Instructors = instructor;

            if (id == 0)
            {
                return View(new mvcCourseModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.GetAsync("Course/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCourseModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEditCourse(mvcCourseModel course)
        {
            if (course.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.PostAsJsonAsync("Course", course).Result;
                TempData["SuccessMessage"] = "Saved Succefully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.PutAsJsonAsync("Course/" + course.Id, course).Result;
                TempData["SuccessMessage"] = "Updated Succefully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.wepApiClient.DeleteAsync("Course/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Succefully";
            return RedirectToAction("Index");
        }
    }
}