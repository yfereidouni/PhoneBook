using PhoneBook.Core.Entities.Tags;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.UI.MVC.Models.Contacts;

public abstract class AddNewContactViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string LastName { get; set; }

    [EmailAddress]
    [StringLength(100, MinimumLength = 3)]
    public string Email { get; set; }

    [StringLength(500)]
    public string Address { get; set; }

    public IFormFile Image { get; set; }

}
public class AddNewContactDisplayViewModel : AddNewContactViewModel
{
    public List<Tag> TagsForDisplay { get; set; }
}
public class AddNewContactGetViewModel : AddNewContactViewModel
{
    public List<int> SelectedTag { get; set; }
}
