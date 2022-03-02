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

            if (!user.Email.ToLower().EndsWith("@gmail.com") &&
                !user.Email.ToLower().EndsWith("@yahoo.com") &&
                !user.Email.ToLower().EndsWith("@me.com"))
            {
                errors.Add(new IdentityError
                {
                    Code = "USR-001",
                    Description = "You can register only with GMAIL, YAHOO, OUTLOOK emails."
                });
            }

            if (user.Email.StartsWith("x"))
            {
                errors.Add(new IdentityError
                {
                    Code = "USR-002",
                    Description = "Your email cannot start with X."
                });
            }

            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
