using HelloWorld.Models;
using System.Linq;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //int x = 1;  // add me
            //x = x / (x - 1); // add me
            return View();
        }



        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        //public ActionResult Product()
        //{
        //    var myProduct = new Product
        //    {
        //        ProductId = 1,
        //        Name = "Kayak",
        //        Description = "A boat for one person",
        //        Category = "water-sports",
        //        Price = 200m,
        //    };

        //    ViewBag.Title = "Single Product";

        //    return View(myProduct);
        //}

        //public ActionResult Products()
        //{
        //    var products = new Product[]
        //    {
        //        new Product{ ProductId = 1, Name = "First One", Price = 1.11m},
        //        new Product{ ProductId = 2, Name="Second One", Price = 2.22m},
        //        new Product{ ProductId = 3, Name="Third One", Price = 3.33m},
        //        new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m},
        //    };

        //    ViewBag.Title = "Multiple Product";

        //    return View(products);
        //}

        public ActionResult Product()
        {
            return View(productRepository.Products.First());
        }

        public ActionResult Products()
        {
            return View(productRepository.Products);
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    base.OnException(filterContext);
        //}

        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

    }
}