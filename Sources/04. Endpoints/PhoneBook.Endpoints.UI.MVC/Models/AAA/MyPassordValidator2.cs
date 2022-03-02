using Microsoft.AspNetCore.Identity;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class MyPassordValidator2 : PasswordValidator<AppUser>
    {
        private readonly UserDbContext userDbContext;

        public MyPassordValidator2(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var parentErrors = base.ValidateAsync(manager, user, password).Result;

            List<IdentityError> errors = new List<IdentityError>();

            if (!parentErrors.Succeeded)
            {
                errors = parentErrors.Errors.ToList();
            }

            if (userDbContext.BadPasswords.Any(c => c.Password == password))
            {
                errors.Add(new IdentityError
                {
                    Code = "PWD-001",
                    Description = "Your password is weak and listed in BadPasswords table!"
                });
            }

            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "PWD-002",
                    Description = "Username is equal to Passwprd"
                });
            }
            
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
