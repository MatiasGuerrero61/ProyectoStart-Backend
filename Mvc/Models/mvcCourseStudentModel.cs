using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcCourseStudentModel
    {

        public int Id { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> StudentId { get; set; }

        public virtual mvcCourseModel Course { get; set; }
        public virtual mvcStudentModel Student { get; set; }
    }
}