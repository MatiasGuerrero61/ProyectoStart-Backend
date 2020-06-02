using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcInstructorModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }

        public virtual ICollection<mvcCourseModel> Course { get; set; }
    }
}