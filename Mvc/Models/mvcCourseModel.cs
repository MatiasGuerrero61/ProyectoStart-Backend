using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcCourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> InstructorId { get; set; }
        public Nullable<int> Capacity { get; set; }

        public virtual mvcDepartmentModel Department { get; set; }
        public virtual mvcInstructorModel Instructor { get; set; }
        public virtual ICollection<mvcCourseStudentModel> CourseStudent { get; set; }
    }
}