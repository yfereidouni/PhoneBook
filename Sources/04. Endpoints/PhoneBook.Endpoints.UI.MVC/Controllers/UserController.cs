using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.UI.MVC.Models.AAA;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class UserController : Controller
    {    
        private readonly UserManager<AppUser> userManager;
         
        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "List of Users";

            var users = userManager.Users.ToList();
            return View(users);
        }

        public IActionResult Add()
        {
            ViewBag.PageTitle = "Add User";

            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }    
}        
         