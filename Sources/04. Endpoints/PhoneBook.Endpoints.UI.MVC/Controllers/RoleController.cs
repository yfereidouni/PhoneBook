using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "List of Roles";

            var roles = roleManager.Roles.ToList();
            return View(roles);
        }


        public IActionResult Add()
        {
            ViewBag.PageTitle = "Create a Role";


            return View();
        }

        [HttpPost]
        public IActionResult Add(IdentityRole identityRole)
        {
            IdentityRole role = new IdentityRole
            {
                Name = identityRole.Name
            };
            var result = roleManager.CreateAsync(role).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Update(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;

            IdentityRole identityRole = new IdentityRole
            {
                Name = role.Name,
            };

            return View(identityRole);
        }

        [HttpPost]
        public IActionResult Update(IdentityRole model)
        {
            var role = roleManager.FindByIdAsync(model.Id).Result;

            role.Name = model.Name;

            var result = roleManager.UpdateAsync(role).Result;

            return RedirectToAction("Index");
        }


        public IActionResult Delete(string id)
        {
            var user = roleManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                var result = roleManager.DeleteAsync(user).Result;

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

        
    }
}