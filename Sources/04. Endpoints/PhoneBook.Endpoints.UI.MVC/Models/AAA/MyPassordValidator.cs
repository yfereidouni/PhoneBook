using Microsoft.AspNetCore.Identity;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class MyPassordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
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
