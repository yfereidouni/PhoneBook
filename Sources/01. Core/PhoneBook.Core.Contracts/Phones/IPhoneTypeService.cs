using PhoneBook.Core.Contracts.Common;
using PhoneBook.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Phones;

public interface IPhoneTypeService : IBaseService<PhoneType>
{
    List<PhoneType> GetAllContactPhoneTypes(List<Phone> tags);
    List<PhoneType> GetContactPhoneTypesByContactId(int contactId);
}
