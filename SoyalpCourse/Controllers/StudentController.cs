using SoyalpCourse.Data.Entities;
using SoyalpCourse.Data.Models;
using SoyalpCourse.Manager.Managers;
using SoyalpCourse.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoyalpCourse.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager manager = new StudentManager();
        // GET: Student
        public ActionResult Index(StudentFilter filter)
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            if (filter == null)
            {
                filter = new StudentFilter();
            }
            studentViewModel.Filter = filter;
            List<Student> studentlist;
            studentlist = manager.GetAllByFilter(filter);

            DepartmentManager departmentManager = new DepartmentManager();
            studentViewModel.Departments = departmentManager.GetAll();

            studentViewModel.Students = studentlist;
            return View(studentViewModel);
        }

        public ActionResult Add()
        {
            DepartmentManager departmentManager = new DepartmentManager();
            var departmentlist = departmentManager.GetAll();
            ViewBag.Departments = departmentlist;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["Image"];
                if (file != null)
                {
                    student.Image = ImageUpload(file, student.Number);
                }
                manager.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            DepartmentManager departmentManager = new DepartmentManager();
            var departmentlist = departmentManager.GetAll();
            ViewBag.Departments = departmentlist;
            var student = manager.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["Image"];
                if (file != null && file.FileName != "")
                {
                    student.Image = ImageUpload(file, student.Number);
                }
                manager.Update(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            DepartmentManager departmentManager = new DepartmentManager();
            var departmentlist = departmentManager.GetAll();
            ViewBag.Departments = departmentlist;
            var student = manager.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            manager.Delete(student.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var student = manager.Get(id);
            return View(student);
        }

        private string ImageUpload(HttpPostedFileBase file, int number)
        {
            string fileName = number.ToString();
            string filee = "/Uploads";
            var folder = Server.MapPath("~" + filee);
            int index = file.FileName.LastIndexOf('.');
            string extension = file.FileName.Substring(0, index);
            fileName = fileName + "." + extension;
            file.SaveAs(folder + fileName);
            return fileName;
        }
    }
}