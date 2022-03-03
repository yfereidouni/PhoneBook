using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Endpoints.UI.MVC.Models.AAA;

namespace PhoneBook.Endpoints.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userMgr;
        private readonly SignInManager<AppUser> signInMgr;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr)
        {
            this.userMgr = userMgr;
            this.signInMgr = signInMgr;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new MyLoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(MyLoginModel myLoginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userMgr.FindByNameAsync(myLoginModel.Name);
                if (user == null)
                {
                    user = await userMgr.FindByEmailAsync(myLoginModel.Name);
                }

                if (user != null)
                {
                    await signInMgr.SignOutAsync();
                    if ((await signInMgr.PasswordSignInAsync(user,myLoginModel.Password,false,false)).Succeeded)
                    {
                        return Redirect(myLoginModel?.ReturnUrl ?? "/");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View(myLoginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInMgr.SignOutAsync();
            return Redirect(returnUrl);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
