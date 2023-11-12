using SoyalpCourse.Data.Context;
using SoyalpCourse.Data.Entities;
using SoyalpCourse.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SoyalpCourse.Manager.Managers
{
    public class StudentManager
    {
        private SoyalpContext db { get; set; }
        public StudentManager()
        {
            db = new SoyalpContext();
        }
        public Student Get(int id)
        {
            return db.Students.Find(id);
        }
        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }
        public void Add(Student student)
        {
            if (student != null)
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Student student = db.Students.Find(id);

            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
        public void Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<Student> GetAllByFilter(StudentFilter filter)
        {
            var query = db.Students.AsQueryable();

            if (filter.DepartmentId > 0)
            {
                query = query.Where(x => x.DepartmentId == filter.DepartmentId);
            }
            if (filter.Number > 0)
            {
                query = query.Where(x => x.Number == filter.Number);
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Surname))
            {
                query = query.Where(x => x.Surname.Contains(filter.Surname));
            }
            return query.ToList();
        }
    }
}
