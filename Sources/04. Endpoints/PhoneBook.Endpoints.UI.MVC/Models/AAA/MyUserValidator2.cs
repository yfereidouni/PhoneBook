using Microsoft.AspNetCore.Identity;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class MyUserValidator2 : UserValidator<AppUser>
    {
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {

            var parentErrors = base.ValidateAsync(manager, user).Result;

            List<IdentityError> errors = new List<IdentityError>();

            if (!parentErrors.Succeeded)
            {
                errors = parentErrors.Errors.ToList();
            }

            if (!user.Email.ToLower().EndsWith("@gmail.com"))
            {
                errors.Add(new IdentityError
                {
                    Code = "USR-001",
                    Description = "You can register only with GMAIL.com emails."
                });
            }
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
