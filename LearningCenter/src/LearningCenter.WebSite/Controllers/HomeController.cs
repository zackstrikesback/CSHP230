using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenter.WebSite.Models;
using LearningCenter.Business;

namespace LearningCenter.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseManager courseManager;
        private readonly IUserManager userManager;

        public HomeController(IUserManager userManager, ICourseManager courseManager)
        {
            this.userManager = userManager;
            this.courseManager = courseManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Classes()
        {
            var classes = courseManager
                                .GetAll()
                                .Select(t =>
                                    new LearningCenter.WebSite.Models.CourseModel
                                    {
                                        Id = t.Id,
                                        Name = t.Name,
                                        Description = t.Description,
                                        Price = t.Price
                                    }).ToArray();

            var model = new CourseViewModel
            {
                Courses = classes
            };
            return View(model);
        }
        public ActionResult Enrolled()
        {
            var classes = courseManager
                                 .GetAll()
                                 .Select(t =>
                                     new LearningCenter.WebSite.Models.CourseModel
                                     {
                                         Id = t.Id,
                                         Name = t.Name,
                                         Description = t.Description,
                                         Price = t.Price
                                     }).ToArray();

            var model = new CourseViewModel
            {
                Courses = classes
            };
            return View(model);
        }
        public ActionResult Enroll()
        {
            var classes = courseManager
                                .GetAll()
                                .Select(t =>
                                    new LearningCenter.WebSite.Models.CourseModel
                                    {
                                        Id = t.Id,
                                        Name = t.Name,
                                        Description = t.Description,
                                        Price = t.Price
                                    }).ToArray();

            var model = new CourseViewModel
            {
                Courses = classes
            };
            return View(model);
        }
        //[HttpPost]
        //public ActionResult Enroll(LoginModel loginModel, Models.CourseModel courseModel)
        //{
        //    // Get the User object from the database

        //    var user = (LearningCenter.WebSite.Models.UserModel)Session["User"];

        //    // Get the Class object from the database

        //    var classToAdd = courseModel;

        //    // Use entity framework to add classes to the user

        //    user.Classes.Add(classToAdd);

        //    // Save the changes to database

        //    databaseAccessor.SubmitChanges();
        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new LearningCenter.WebSite.Models.UserModel { Id = user.Id, Name = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }
        [HttpPost]
        public ActionResult Register(RegisterModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(loginModel.Email, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name is already in use.");
                }
                else
                {
                    Session["User"] = new LearningCenter.WebSite.Models.UserModel { Id = user.Id, Name = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.Email, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }
    }
}