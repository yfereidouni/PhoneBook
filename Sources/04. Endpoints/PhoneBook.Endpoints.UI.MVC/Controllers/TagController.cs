using Microsoft.AspNetCore.Mvc;

namespace PB.Endpoints.UI.MVC.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
