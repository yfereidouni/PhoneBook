using Microsoft.AspNetCore.Identity;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class MyUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();

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

            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
