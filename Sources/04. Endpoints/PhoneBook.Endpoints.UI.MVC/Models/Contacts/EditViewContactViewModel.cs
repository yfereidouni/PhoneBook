using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.UI.MVC.Models.Contacts;

public class EditViewContactViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    //[Required(AllowEmptyStrings = true)]
    public string CurrentImage { get; set; }

    public IFormFile? Image { get; set; }
}


