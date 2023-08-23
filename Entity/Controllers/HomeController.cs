using Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Entity.MvcApplication;

namespace Entity.Controllers
{
    //TABLE NAME MvcDatabaseEntities2
    //Modal Name student
    public class HomeController : Controller
    {
        MvcDatabaseEntities2 mvc2 = new MvcDatabaseEntities2();

        [MyFilter]
        public ActionResult Index(int id)
        {
            return Content("Hello my name is " + id);
        }

        public ActionResult Display()
        {
            List<student> modeloftable = mvc2.students.ToList();

            return View(modeloftable);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            student student = mvc2.students.Find(id);
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            student stu = mvc2.students.Find(id);
            mvc2.students.Remove(stu);
            mvc2.SaveChanges();
            return RedirectToAction("Display");
        }

        public ActionResult Edit(int? id)
        {
            student student = mvc2.students.Find(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Sid,Sname,Ssec,Sstd")]student ed)
        {
            if(ModelState.IsValid)
            {
                mvc2.Entry(ed).State=EntityState.Modified;
                mvc2.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "Sid,Sname,Ssec,Sstd")] student cr)
        {
            if(ModelState.IsValid)
            {
                mvc2.students.Add(cr);
                mvc2.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }
    }
}
