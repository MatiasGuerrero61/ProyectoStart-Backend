using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<mvcStudentModel> studentList;
            HttpResponseMessage response = GlobalVariables.wepApiClient.GetAsync("Student").Result;
            studentList = response.Content.ReadAsAsync<IEnumerable<mvcStudentModel>>().Result;
            return View(studentList);
        }

        public ActionResult AddOrEditStudent(int id = 0)
        {
            return View(new mvcStudentModel());
        }
        [HttpPost]
        public ActionResult AddOrEditStudent()
        {
            return View();
        }
    }
}