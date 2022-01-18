using PB.Core.Entities.Common;

namespace PB.Core.Entities.Phones;

public class Phone : BaseEntity
{
    public string PhoneNumber { get; set; }
    public PhoneType PhoneType { get; set; }
}