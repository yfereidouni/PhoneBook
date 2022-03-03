using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.UI.MVC.Models.AAA;

public class MyLoginModel
{
    [Required]
    [Display(Name ="Username or Email")]
    public string Name { get; set; } = "";

    [Required]
    [UIHint("Password")]
    public string Password { get; set; } = "";

    public string ReturnUrl { get; set; } = "/";
}

