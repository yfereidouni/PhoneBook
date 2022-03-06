using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = "";

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = "";

    }

    public class AddNewUserDisplayViewModel : UserViewModel
    {
        public List<IdentityRole> RolesForDisplay { get; set; } = new List<IdentityRole>();
        //public List<SelectListItem> RolesForDisplay { get; set; } = new List<SelectListItem>();
        
    }

    public class AddNewUserGetViewModel : UserViewModel
    {
        public List<string> SelectedRoles { get; set; } = new List<string>();
        //public List<SelectListItem> SelectedRoles { get; set; } = new List<SelectListItem>();

    }
}
