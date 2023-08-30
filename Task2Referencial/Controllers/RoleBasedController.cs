using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Task2Referencial.Models;

namespace Task2Referencial.Controllers
{
    public class RoleBasedController : Controller
    {

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public new ActionResult Profile()
        {
            return View();
        }

        // GET: RoleBased
     
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UserTable user)
        {
            MvcDatabaseEntities5 usertabledatabase = new MvcDatabaseEntities5();

            Validate_User_Result roleUser = usertabledatabase.Validate_User(user.TUsername, user.TPassword).FirstOrDefault();  
            string message = string.Empty;
            switch (roleUser.TUserid.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Account has not been activated.";
                    break;
                default:
                    
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.TUsername, DateTime.Now, DateTime.Now.AddMinutes(30), user.RememberMe,roleUser.Roles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                
                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Profile");
            }

            ViewBag.Message = message;
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UserDetails()
        {
            MvcDatabaseEntities5 usertabledatabase = new MvcDatabaseEntities5();
            List<UserTable> users = usertabledatabase.UserTables.ToList();
            return View(users);
        }

        //[HttpPost]
        //[Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
