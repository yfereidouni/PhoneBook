using Microsoft.AspNetCore.Mvc;

namespace PB.Endpoints.UI.MVC.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
