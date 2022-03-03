using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.UI.MVC.Models.AAA;
using PhoneBook.Infrastructures.DAL.EF.Common;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserDbContext userDbContext;
        private readonly PhoneBookDbContext phoneBookDbContext;

        public HomeController(UserDbContext userDbContext, PhoneBookDbContext phoneBookDbContext)
        {
            this.userDbContext = userDbContext;
            this.phoneBookDbContext = phoneBookDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "Admin Panel";

            ViewBag.ContactCount = phoneBookDbContext.Contacts.Count();
            ViewBag.UserCount = userDbContext.Users.Count();
            ViewBag.PhoneCount = phoneBookDbContext.Phones.Count();


            return View();
        }
        

    }
}
