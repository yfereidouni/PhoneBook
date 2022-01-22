using Microsoft.EntityFrameworkCore;
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

    public Contact GetContactWithPhones(int contactId)
    {
        return phoneBookDbContext.Contacts.Where(c => c.Id == contactId).Include(c => c.Phones).FirstOrDefault();
    }
}
