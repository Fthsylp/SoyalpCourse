using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyalpCourse.Data.Models
{
    public class StudentFilter
    {
        public int DepartmentId { get; set; }
        public int Number {  get; set; }
        public string Name { get; set; }
        public string Surname {  get; set; }
    }
}
