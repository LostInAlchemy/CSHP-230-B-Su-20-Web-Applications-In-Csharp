using System.Linq;
using TheLearningCenter.WebSite.Models;
using System.Web.Mvc;
using TheLearningCenter.Business;
using Newtonsoft.Json;
using TheLearningStore.WebSite.Models;

namespace TheLearningCenter.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassManager classManager;
        private readonly IUserManager userManager;

        public HomeController(IClassManager classManager, IUserManager userManager)
        {
            this.classManager = classManager;
            this.userManager = userManager;
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
        [AllowAnonymous]
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
                                            (
                                                t.ClassID,
                                            t.ClassName,
                                            t.ClassDescription,
                                            t.ClassPrice
                                            )).ToArray();

            var model = new TheLearningCenter.WebSite.Models.ClassPageModel { Classes = classes };
            return View(model);
        }





























        //public ActionResult studentclasses()
        //{
        //    var userclasses = classes.Where(t => t.)



        //    var classes = classManager.Classes
        //                                    .Select(t =>
        //                                    new TheLearningCenter.WebSite.Models.ClassModel
        //                                    (
        //                                        t.ClassID,
        //                                    t.ClassName,
        //                                    t.ClassDescription,
        //                                    t.ClassPrice
        //                                    )).Where(t => t.)





        //                                    .ToArray();

        //    var userclasses = classes.Where(t => new TheLearningCenter.WebSite.Models.ClassModel.user = Session.SessionID)

        //    var model = new TheLearningCenter.WebSite.Models.ClassPageModel { Classes = classes };
        //    return View(model);
        //}


    }
}