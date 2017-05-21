using ComputerScienceTsu.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerScienceTsu.Services;
using System.Web.Security;

namespace ComputerScienceTsu.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Registration(string firstname, string lastname, string username, string email, string pass)
        {
            bool emailExists = UserService.EmailExists(email);

            if (!emailExists)
            {
                var user = UserService.SetUser(firstname, lastname, username, email, UserService.Hash(pass));
                using (TsuModel db = new TsuModel())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return View("RegistrationSuccessful");
                }
            }

            return View();
        }

        [HttpPost]

        public ActionResult Login(string email, string pass, string remember)
        {
            using (TsuModel db = new TsuModel())
            {
                var user = db.Users.Where(e => e.Email == email).FirstOrDefault();
                if (user != null)
                {
                    if (string.Compare(UserService.Hash(pass), user.Pass) == 0)
                    {
                        var RememberChecked = remember == "on" ? true : false;
                        int timeout = RememberChecked ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(email, RememberChecked, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                        Session["UserID"] = user.ID.ToString();
                        Session["Username"] = user.Username;
                        return View("LoginSuccessful");
                    }

                    else
                        ModelState.AddModelError("LoginError", "Username or password is wrong.");
                   }
                else
                {
                    ModelState.AddModelError("LoginError", "Username or password is wrong.");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Remove("Username");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}