using CRUDinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDinMVC.Controllers
{
    public class StudentController : Controller
    {
        //Retrieves all student details
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandle dbHandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dbHandle.GetStudent());
        }

        //Add new student
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentDBHandle sdb = new StudentDBHandle();
                    if (sdb.AddStudent(smodel))
                    {
                        ViewBag.Message = "Student details added successfully";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        //Edit Student
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDBHandle sdb = new StudentDBHandle();
            return View(sdb.GetStudent().Find(smodel => smodel.Id ==id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel smodel)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                if (sdb.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student deleted successfully";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

     
    }
}
