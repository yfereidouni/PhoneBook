using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructures.DAL.EF.Contacts;

public class ContactRepository : BaseEntityRepository<Contact>, IContactRepository
{
    public ContactRepository(PhoneBookDbContext phoneBookDbContext) : base(phoneBookDbContext)
    {
    }
}