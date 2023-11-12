using SoyalpCourse.Data.Entities;
using SoyalpCourse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoyalpCourse.Web.Models
{
    public class StudentViewModel
    {
        public List<Student> Students { get; set; }
        public StudentFilter Filter { get; set; }
        public List<Department> Departments { get; set; }
    }
}