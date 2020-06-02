using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcStudentModel
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<mvcCourseStudentModel> CourseStudent { get; set; }
    }
}