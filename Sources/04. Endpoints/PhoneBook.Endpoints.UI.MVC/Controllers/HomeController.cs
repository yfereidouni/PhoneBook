using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.UI.MVC.Models.AAA;
using PhoneBook.Infrastructures.DAL.EF.Phones;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserDbContext userDbContext;

        public HomeController(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "Admin Panel";

            ViewBag.UserCount = userDbContext.Users.Count();
            ViewBag.PhoneCount = 12;
            //ViewBag.PhoneCount = phoneRepository.GetAll().Count();


            return View();
        }
        

    }
}
