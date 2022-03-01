using Microsoft.AspNetCore.Identity;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class MyPassordValidator2 : PasswordValidator<AppUser>
    {
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var parentErrors = base.ValidateAsync(manager, user, password).Result;

            List<IdentityError> errors = new List<IdentityError>();

            if (!parentErrors.Succeeded)
            {
                errors = parentErrors.Errors.ToList();
            }

            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "PWD-001",
                    Description = "Username is equal to Passwprd"
                });
            }
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
