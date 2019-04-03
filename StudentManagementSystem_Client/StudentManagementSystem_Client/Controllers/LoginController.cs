using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem_Client.Models;
namespace StudentManagementSystem_Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }

        [ChildActionOnly]
        public ActionResult Login()
        {
            
            User model = new User();

            return PartialView("LoginView", model);
        }
    }
}