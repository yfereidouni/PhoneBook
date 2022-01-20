using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
