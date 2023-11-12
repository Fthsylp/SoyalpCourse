using SoyalpCourse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyalpCourse.Data.Context
{
    public class SoyalpContext : DbContext
    {
        public SoyalpContext() : base("SoyalpConnection")
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
