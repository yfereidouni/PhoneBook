using PhoneBook.Core.Contracts.Common;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Contacts
{
    public interface IContactService : IBaseService<Contact>
    {
        Contact GetContactWithChilds(int contactId);
    }

}
