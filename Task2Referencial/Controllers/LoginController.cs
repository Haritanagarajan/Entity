using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Task2Referencial.Models;

namespace Task2Referencial.Controllers
{
    //database MvcDatabaseEntities2
    //Model UserAuths
   
    public class LoginController : Controller
    {
        private readonly MvcDatabaseEntities2 _mvc2 = new MvcDatabaseEntities2();

        // GET: Login
        [HttpGet]
        public ActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginForm(UserAuth user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _mvc2.UserAuths
                .Any(u => u.UserName.ToLower() == user.UserName.ToLower() && user.UserRole == user.UserRole);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    if (user.UserRole == "Admin")
                    {
                        return RedirectToAction("View1", "Trainee");

                    }
                    else if (user.UserRole == "User")
                    {
                        return RedirectToAction("View1", "Training");

                    }
                    else if (user.UserRole == "TrainingAdmin")
                    {
                        return RedirectToAction("Index", "Training");

                    }
                    else if (user.UserRole == "TraineeAdmin")
                    {
                        return RedirectToAction("Index", "Trainee");

                    }
                }
            }
            ModelState.AddModelError("", "Invalid Username and UserRole");
            return View();
        }
       

        [HttpGet]
        public ActionResult RegisterForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterForm([Bind(Include = "UserId,UserName,UserRole")] UserAuth user)
        {
            if (ModelState.IsValid)
            {
                _mvc2.UserAuths.Add(user);
                _mvc2.SaveChanges();
                return Content("User Registered Successfully :)");
            }
            return View();
        }
    }
}