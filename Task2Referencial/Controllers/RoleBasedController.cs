using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2Referencial.Controllers
{
    public class RoleBasedController : Controller
    {
        // GET: RoleBased
        public ActionResult Index()
        {
            return View();
        }

        // GET: RoleBased/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleBased/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleBased/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleBased/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleBased/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleBased/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleBased/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
