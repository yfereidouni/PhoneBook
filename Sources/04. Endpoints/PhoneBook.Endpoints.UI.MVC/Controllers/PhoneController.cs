using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
