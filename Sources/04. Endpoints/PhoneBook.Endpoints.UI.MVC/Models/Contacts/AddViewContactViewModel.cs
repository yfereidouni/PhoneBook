using PhoneBook.Core.Entities.Phones;
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

    [Required]
    [EmailAddress]
    [StringLength(100, MinimumLength = 3)]
    public string Email { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }

    public IFormFile Image { get; set; }

    public string PhoneNumber { get; set; }

}
public class AddNewContactDisplayViewModel : AddNewContactViewModel
{
    public List<Tag> TagsForDisplay { get; set; } = new List<Tag>();
    public List<PhoneType> PhoneTypesForDisplay { get; set; } = new List<PhoneType>();

}
public class AddNewContactGetViewModel : AddNewContactViewModel
{
    public List<int> SelectedTag { get; set; } = new List<int>();
    public List<int> SelectedPhoneType { get; set; } = new List<int>();
}
