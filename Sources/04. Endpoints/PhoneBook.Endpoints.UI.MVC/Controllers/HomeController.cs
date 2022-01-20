using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Admin Panel";

            return View();
        }
        

    }
}
