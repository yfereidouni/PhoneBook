using PhoneBook.Core.Entities.Common;
using PhoneBook.Core.Entities.Phones;
using PhoneBook.Core.Entities.Tags;
using PhoneBook.Core.Entities.Contacts;

namespace PhoneBook.Core.Entities.Contacts;

public class Contact : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
    public List<Phone> Phones { get; set; }
    public List<ContactTag> Tags { get; set; }
}