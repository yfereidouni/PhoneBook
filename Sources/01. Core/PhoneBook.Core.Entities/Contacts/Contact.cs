using PB.Core.Entities.Common;
using PB.Core.Entities.Phones;
using PB.Core.Entities.Tags;
using PhoneBook.Core.Entities.Contacts;

namespace PB.Core.Entities.Contacts;

public class Contact : BaseEntity
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
    public List<Phone> Phones { get; set; }
    public List<ContactTag> Tags { get; set; }
}