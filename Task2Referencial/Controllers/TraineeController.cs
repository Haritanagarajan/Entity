using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Task2Referencial.Models;

namespace Task2Referencial.Controllers
{
    [Authorize]
    //database   MvcDatabaseEntities1 
    //Model Trainees
    public class TraineeController : Controller
    {
        MvcDatabaseEntities4 MvcDatabaseEntities4 = new MvcDatabaseEntities4();



        public ActionResult View1()
        {
            List<Trainee> trainees = MvcDatabaseEntities4.Trainees.ToList();

            return View(trainees);
        }

        // GET: Trainee

        public ActionResult Index()
        {
            List<Trainee> trainees = MvcDatabaseEntities4.Trainees.ToList();

            return View(trainees);
        }

        [HttpGet]

        public ActionResult Create()
        {
            List<Training> trainings = MvcDatabaseEntities4.Trainings.ToList();
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
                MvcDatabaseEntities4.Trainees.Add(trainee);
                MvcDatabaseEntities4.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            Trainee trainee = MvcDatabaseEntities4.Trainees.Find(id);
            List<Training> trainings = MvcDatabaseEntities4.Trainings.ToList();
            ViewBag.Trainings = new SelectList(trainings, "Did", "Dname");
            return View(trainee);
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase Tprofile, [Bind(Include = "Tid,Tname,TDomainid")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                byte[] profile;

                using (var reader = new BinaryReader(Tprofile.InputStream))
                {
                    profile = reader.ReadBytes(Tprofile.ContentLength);
                }

                trainee.Tprofile = profile;
                MvcDatabaseEntities4.Entry(trainee).State = EntityState.Modified;
                MvcDatabaseEntities4.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }




        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Trainee trainee = MvcDatabaseEntities4.Trainees.Find(id);
            return View(trainee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Trainee tr = MvcDatabaseEntities4.Trainees.Find(id);
            MvcDatabaseEntities4.Trainees.Remove(tr);
            MvcDatabaseEntities4.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            Trainee trainee = MvcDatabaseEntities4.Trainees.Find(id);
            return View(trainee);
        }
        public ActionResult LogoutForm()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginForm", "Login");
        }
    }
}