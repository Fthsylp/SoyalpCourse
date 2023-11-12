using SoyalpCourse.Data.Context;
using SoyalpCourse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SoyalpCourse.Manager.Managers
{
    public class DepartmentManager
    {
        private SoyalpContext db { get; set; }
        public DepartmentManager()
        {
            db = new SoyalpContext();
        }
        public Department Get(int id) 
        {
            return db.Departments.Find(id);
        }
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public void Add(Department department)
        {
            if (department != null)
            {
                db.Departments.Add(department);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Department department = db.Departments.Find(id);

            if (department != null)
            {
                db.Departments.Remove(department);
                db.SaveChanges();
            }
        }
        public void Update(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
