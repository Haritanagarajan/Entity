using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task2Referencial.Models;

namespace Task2Referencial.Controllers
{
    //database   MvcDatabaseEntities1 
    //Model Trainees
    public class TraineeController : Controller
    {
        MvcDatabaseEntities1 MvcDatabaseEntities1 = new MvcDatabaseEntities1();



        public ActionResult View1()
        {
            List<Trainee> trainees = MvcDatabaseEntities1.Trainees.ToList();

            return View(trainees);
        }

        // GET: Trainee

        public ActionResult Index()
        {
            List<Trainee> trainees = MvcDatabaseEntities1.Trainees.ToList();

            return View(trainees);
        }

        [HttpGet]

        public ActionResult Create()
        {
            List<Training> trainings = MvcDatabaseEntities1.Trainings.ToList();
            ViewBag.Trainings = new SelectList(trainings, "Did", "Dname"); 
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Tprofile, [Bind(Include = "Tid,Tname,TDomainid")] Trainee trainee)
        {
            if (ModelState.IsValid)

            {
                byte[] profile;

                using (var reader = new BinaryReader(Tprofile.InputStream))
                {
                    profile = reader.ReadBytes(Tprofile.ContentLength);
                }
                trainee.Tprofile = profile;
                MvcDatabaseEntities1.Trainees.Add(trainee);
                MvcDatabaseEntities1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            Trainee trainee = MvcDatabaseEntities1.Trainees.Find(id);
            List<Training> trainings = MvcDatabaseEntities1.Trainings.ToList();
            ViewBag.Trainings = new SelectList(trainings, "Did", "Dname");
            return View(trainee);
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase Tprofile,[Bind(Include = "Tid,Tname,TDomainid")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                byte[] profile;

                using (var reader = new BinaryReader(Tprofile.InputStream))
                {
                    profile = reader.ReadBytes(Tprofile.ContentLength);
                }

                trainee.Tprofile = profile;
                MvcDatabaseEntities1.Entry(trainee).State = EntityState.Modified;
                MvcDatabaseEntities1.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }


      

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Trainee trainee = MvcDatabaseEntities1.Trainees.Find(id);
            return View(trainee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Trainee tr = MvcDatabaseEntities1.Trainees.Find(id);
            MvcDatabaseEntities1.Trainees.Remove(tr);
            MvcDatabaseEntities1.SaveChanges();
            return RedirectToAction("Index");
        }







        [HttpGet]
        public ActionResult Details(int? id)
        {
            Trainee trainee = MvcDatabaseEntities1.Trainees.Find(id);
            return View(trainee);
        }
    }
}