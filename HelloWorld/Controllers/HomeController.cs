using HelloWorld.Models;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
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

        public ActionResult Product()
        {
            var myProduct = new Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "water-sports",
                Price = 200m,
            };

            return View(myProduct);
        }

        public ActionResult Products()
        {
            var products = new Product[]
            {
                new Product{ ProductId = 1, Name = "First One", Price = 1.11m},
                new Product{ ProductId = 2, Name="Second One", Price = 2.22m},
                new Product{ ProductId = 3, Name="Third One", Price = 3.33m},
                new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m},
            };

            return View(products);
        }




    }
}