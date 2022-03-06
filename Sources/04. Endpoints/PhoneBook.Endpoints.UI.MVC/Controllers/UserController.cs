using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBook.Endpoints.UI.MVC.Models.AAA;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
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


            AddNewUserDisplayViewModel model = new AddNewUserDisplayViewModel
            {
                RolesForDisplay = roleManager.Roles.Select(c=> new IdentityRole
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddNewUserGetViewModel model)
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
                    var roles = new List<string>(model.SelectedRoles.ToList());

                    foreach (var item in roles)
                    {
                        var selectedRoleName = roleManager.FindByIdAsync(item).Result;
                        var resultRole = userManager.AddToRoleAsync(user, selectedRoleName.Name).Result;
                    }

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

            //Choose only related role of the user not all of roles stored in DB
            model.RolesForDisplay = roleManager.Roles.ToList();            

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
