using PhoneBook.Core.Entities.Phones;
using PhoneBook.Core.Entities.Tags;

namespace PhoneBook.Endpoints.UI.MVC.Models.Contacts;

public class ContactDetailsViewModel: ContactViewModel
{
    public int ContactId { get; set; }
    public List<Phone> Phones { get; set; } = new List<Phone>();
    public List<Tag> Tags { get; set; } = new List<Tag>();
    public List<PhoneType> PhoneTypes { get; set; } = new List<PhoneType>();

    //public string FirstName { get; set; }
    //public string LastName { get; set; }
    //public string Email { get; set; }
    //public string? Address { get; set; }
    //public string Image { get; set; }
}
