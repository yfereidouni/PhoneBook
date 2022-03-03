using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.UI.MVC.Models.AAA;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    [Authorize(Roles ="Admin")]
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

        [HttpPost]
        public IActionResult Add(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                };
                var result = userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult Detail(string id)
        {
            ViewBag.PageTitle = "User Details";

            var user = userManager.FindByIdAsync(id).Result;

            DetailUserViewModel model = new DetailUserViewModel
            {
                Id = id,
                Email = user.Email,
                Username = user.UserName,
            };

            return View(model);
        }

        public IActionResult Update(string id)
        {
            ViewBag.PageTitle = "Update User";

            var user = userManager.FindByIdAsync(id).Result;

            UpdateUserViewModel model = new UpdateUserViewModel
            {
                Id = id,
                Email = user.Email,
                Username = user.UserName,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(string id, UpdateUserViewModel model)
        {
            var user = userManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Username;

                var result = userManager.UpdateAsync(user).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Delete(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                var result = userManager.DeleteAsync(user).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }

            return View();
        }

        public IActionResult AddToRole(string id, string roleName)
        {
            var user = userManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                var result = userManager.AddToRoleAsync(user, roleName).Result;
            }

            return RedirectToAction("Index");
        }
    }
}
