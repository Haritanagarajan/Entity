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

        // GET: Trainee
        public ActionResult Index()
        {
            List<Trainee> trainees = MvcDatabaseEntities1.Trainees.ToList();

            return View(trainees);
        }

        [HttpGet]

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Tid,Tname,TDomainid,Tprofile")] Trainee trainee, HttpPostedFileBase Tprofile)
        {
           
            if (ModelState.IsValid)
            {
                byte[] profile;

                       using (BinaryReader reader = new BinaryReader(Tprofile.InputStream))
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
            return View(trainee);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Tid,Tname,TDomainid,Tprofile")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                MvcDatabaseEntities1.Entry(trainee).State = EntityState.Modified;
                MvcDatabaseEntities1.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
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