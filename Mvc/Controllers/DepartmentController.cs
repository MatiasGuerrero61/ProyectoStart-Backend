using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            IEnumerable<mvcDepartmentModel> departmentList;
            HttpResponseMessage response = GlobalVariables.wepApiClient.GetAsync("Department").Result;
            departmentList = response.Content.ReadAsAsync<IEnumerable<mvcDepartmentModel>>().Result;
            return View(departmentList);
        }

        public ActionResult AddOrEditDepartment(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcDepartmentModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.GetAsync("Department/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcDepartmentModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEditDepartment(mvcDepartmentModel department)
        {
            if (department.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.PostAsJsonAsync("Department", department).Result;
                TempData["SuccessMessage"] = "Saved Succefully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.wepApiClient.PutAsJsonAsync("Department/"+department.Id, department).Result;
                TempData["SuccessMessage"] = "Updated Succefully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.wepApiClient.DeleteAsync("Department/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Succefully";
            return RedirectToAction("Index");
        }
    }
}