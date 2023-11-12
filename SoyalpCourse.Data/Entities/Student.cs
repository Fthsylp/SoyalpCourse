using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyalpCourse.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public int Number { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public string Image { get; set; }
        public virtual Department Department { get; set; }
    }
}
