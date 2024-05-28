using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Employee_Management_System.Controllers
{
    public class UsersController : Controller
    {
        dbOperations dbOperations = null;
        public UsersController() {
            dbOperations= new dbOperations();
        }
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if(user.username==null || user.username==String.Empty || user.username.Length < 3)
            {
                ModelState.AddModelError("","UserName is required and should be minimum 3 characters long");
                return View(user);
            }
            int id = dbOperations.validateUser(user);
            if (id>0)
            {
                FormsAuthentication.SetAuthCookie(user.username, false);
                Session["UserId"] = id;
                return RedirectToAction("Index","Employee");
            }
            ModelState.AddModelError("", "Username or password invalid");
           return View(user);
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserModel user)
        {
            if(ModelState.IsValid)
            {
                int id = dbOperations.AddUser(user);
                if(id>0)
                {
                    ViewBag.condition = true;
                    ModelState.Clear();
                    return View();
                }
                ModelState.Clear();
                return View();
            }
            else
            {
                return View(user);
            }
        }
    }
}
