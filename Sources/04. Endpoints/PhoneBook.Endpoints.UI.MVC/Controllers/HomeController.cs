using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        

    }
}
