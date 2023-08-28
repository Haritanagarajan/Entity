using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2Referencial.Models;

namespace Task2Referencial.Controllers
{
    //database MvcDatabaseEntities1
    //model  Trainees
    public class TrainingController : Controller
    {
        MvcDatabaseEntities1 MvcDatabaseEntities1 = new MvcDatabaseEntities1();

        public ActionResult View1()
        {
            List<Training> training = MvcDatabaseEntities1.Trainings.ToList();

            return View(training);
        }
        // GET: Training
        public ActionResult Index()
        {
            List<Training> training = MvcDatabaseEntities1.Trainings.ToList();

            return View(training);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            Training training = MvcDatabaseEntities1.Trainings.Find(id);
            return View(training);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Did,Dname,IsDeleted")] Training training)
        {
            if (ModelState.IsValid)
            {
                MvcDatabaseEntities1.Trainings.Add(training);
                MvcDatabaseEntities1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Training training = MvcDatabaseEntities1.Trainings.Find(id);
            return View(training);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include ="Did,Dname,IsDeleted")] Training training)
        {
            if (ModelState.IsValid)
            {
                MvcDatabaseEntities1.Entry(training).State = EntityState.Modified;
                MvcDatabaseEntities1.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Training training = MvcDatabaseEntities1.Trainings.Find(id);
            return View(training);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Training tr = MvcDatabaseEntities1.Trainings.Find(id);
            MvcDatabaseEntities1.Trainings.Remove(tr);
            MvcDatabaseEntities1.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            Training training = MvcDatabaseEntities1.Trainings.Find(id);
            return View(training);
        }
    }
}