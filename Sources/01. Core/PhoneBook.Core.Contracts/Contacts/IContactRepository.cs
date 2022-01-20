using PhoneBook.Core.Contracts.Common;
using PhoneBook.Core.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Contacts;

public interface IContactRepository : IBaseEntityRepository<Contact>
{

}
