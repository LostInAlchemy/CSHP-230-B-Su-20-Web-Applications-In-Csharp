using System.Linq;
using TheLearningCenter.WebSite.Models;
using System.Web.Mvc;
using TheLearningCenter.Business;
using System.Web.UI.WebControls;

namespace TheLearningCenter.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassManager classManager;
        private readonly IUserManager userManager;
        private readonly IEnrollmentManager enrollmentManager;

        public HomeController(IClassManager classManager, IUserManager userManager, IEnrollmentManager enrollmentManager)
        {
            this.classManager = classManager;
            this.userManager = userManager;
            this.enrollmentManager = enrollmentManager;
        }

        public ActionResult Index()
        {
            return View();
        }

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

        [HttpGet]
        //[AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            bool userExists = userManager.UserExist(registerModel.Email);

            if (userExists)
            {
                ModelState.AddModelError("", "User name exists");

            }
            else
            {
                var user = userManager.Register(registerModel.Email, registerModel.UserPassword);

                if (ModelState.IsValid)
                {
                    if (user == null)
                    {
                        ModelState.AddModelError("", "User name and password do not match.");
                    }
                    else
                    {
                        Session["User"] = new TheLearningCenter.WebSite.Models.UserModel
                        {
                            UserId = user.Id,
                            UserEmail = user.Name
                        };

                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(registerModel);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.UserPassword);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new TheLearningCenter.WebSite.Models.UserModel
                    {
                        UserId = user.Id,
                        UserEmail = user.Name
                    };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(
                        loginModel.UserName, false);

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

        public ActionResult classlist()
        {
            var classes = classManager.Classes
                                            .Select(t =>
                                            new TheLearningCenter.WebSite.Models.ClassModel
                                            (t.ClassID,
                                            t.ClassName,
                                            t.ClassDescription,
                                            t.ClassPrice
                                            )).ToArray();

            var model = new TheLearningCenter.WebSite.Models.ClassPageModel { Classes = classes };
            return View(model);
        }

        public ActionResult ClassEnrollment()
        {
            var classes = classManager.Classes
                                    .Select(t =>
                                    new TheLearningCenter.WebSite.Models.ClassModel
                                    (t.ClassID,
                                    t.ClassName,
                                    t.ClassDescription,
                                    t.ClassPrice
                                    )).ToList();

            SelectList listItems = new SelectList(classes, "classId", "className");
            ViewBag.classes = listItems;

            return View();
        }

        [HttpPost]
        public ActionResult ClassEnrollment(TheLearningStore.WebSite.Models.ClassEnrollmentViewModel classEnrollmentViewModel)
        {
            var classes = classManager.Classes
                                    .Select(t =>
                                    new TheLearningCenter.WebSite.Models.ClassModel
                                    (
                                        t.ClassID,
                                    t.ClassName,
                                    t.ClassDescription,
                                    t.ClassPrice
                                    )).ToList();

            SelectList listItems = new SelectList(classes, "classId", "className");
            ViewBag.classes = listItems;

            if (Session["User"] == null)
            {
                Response.Redirect("~/Home/LogIn");
            }
            else
            {
                var currentUserId = (TheLearningCenter.WebSite.Models.UserModel)Session["User"];
                var selectedClass = int.Parse(Request.Form["classList"]);
                var Enrolled = enrollmentManager.Add(currentUserId.UserId, selectedClass);

                return RedirectToAction("StudentClasses", "Home", Enrolled);
            }

            return View();
        }

        public ActionResult studentclasses()
        {
            var currentUserId = (TheLearningCenter.WebSite.Models.UserModel)Session["User"];

            if (Session["User"] != null)
            {
                var classes = enrollmentManager.GetAll(currentUserId.UserId)
                                     .Select(t =>
                                     new TheLearningCenter.WebSite.Models.ClassModel
                                     (
                                         t.ClassID,
                                     t.ClassName,
                                     t.ClassDescription,
                                     t.ClassPrice
                                     )).ToArray();

                var model = new TheLearningCenter.WebSite.Models.ClassPageModel { Classes = classes };

                return View(model);
            }

            return RedirectToAction("Login");
        }
    }
}