using PhoneBook.Core.Contracts.Common;
using PhoneBook.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Contacts;

public interface IPhoneTypeRepository : IBaseEntityRepository<PhoneType>
{
    List<PhoneType> GetByContactIdWithPhoneType(int contactId);
    List<Phone> Where(Func<Phone, bool> func);
}
