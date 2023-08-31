using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2Referencial.Models;

namespace Task2Referencial.Controllers
{
    [Authorize]
    [AllowAnonymous]

    //database MvcDatabaseEntities1
    //model  Trainees
    public class TrainingController : Controller
    {
        MvcDatabaseEntities4 MvcDatabaseEntities4 = new MvcDatabaseEntities4();

        [Authorize(Roles = "Trainee")]

        public ActionResult View1()
        {
            List<Training> training = MvcDatabaseEntities4.Trainings.ToList();

            return View(training);
        }
        // GET: Training
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Training> training = MvcDatabaseEntities4.Trainings.ToList();

            return View(training);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            Training training = MvcDatabaseEntities4.Trainings.Find(id);
            return View(training);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Did,Dname,IsDeleted")] Training training)
        {
            if (ModelState.IsValid)
            {
                MvcDatabaseEntities4.Trainings.Add(training);
                MvcDatabaseEntities4.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Training training = MvcDatabaseEntities4.Trainings.Find(id);
            return View(training);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Did,Dname,IsDeleted")] Training training)
        {
            if (ModelState.IsValid)
            {
                MvcDatabaseEntities4.Entry(training).State = EntityState.Modified;
                MvcDatabaseEntities4.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Training training = MvcDatabaseEntities4.Trainings.Find(id);
            return View(training);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Training tr = MvcDatabaseEntities4.Trainings.Find(id);
            MvcDatabaseEntities4.Trainings.Remove(tr);
            MvcDatabaseEntities4.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            Training training = MvcDatabaseEntities4.Trainings.Find(id);
            return View(training);
        }
    }
}