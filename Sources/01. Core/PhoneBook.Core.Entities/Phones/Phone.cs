using PhoneBook.Core.Entities.Common;

namespace PhoneBook.Core.Entities.Phones;

public class Phone : BaseEntity
{
    public string PhoneNumber { get; set; }
    public PhoneType PhoneType { get; set; }
}