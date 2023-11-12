using SoyalpCourse.Data.Entities;
using SoyalpCourse.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SoyalpCourse.Controllers
{
    public class DepartmentsController : Controller
    {
        private DepartmentManager manager = new DepartmentManager();
        // GET: Department
        public ActionResult Index()
        {
            var departments = manager.GetAll();
            return View(departments);
        }

        public ActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            manager.Add(department);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) 
        {
            var department = manager.Get(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department) 
        {
            manager.Update(department);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) 
        {
            var department = manager.Get(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Delete(Department department)
        {
            manager.Delete(department.Id);
            return RedirectToAction("Index");
        }
    }

}