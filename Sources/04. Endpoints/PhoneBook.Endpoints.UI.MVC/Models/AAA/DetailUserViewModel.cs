using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA
{
    public class DetailUserViewModel
    {
        public string Id { get; set; } = "";

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

        public List<IdentityRole> RolesForDisplay { get; set; } = new List<IdentityRole>();

    }
}
