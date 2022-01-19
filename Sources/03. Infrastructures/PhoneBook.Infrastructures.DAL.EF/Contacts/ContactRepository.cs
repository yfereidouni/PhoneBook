using PB.Core.Contracts.Contacts;
using PB.Core.Entities.Contacts;
using PB.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Infrastructures.DAL.EF.Contacts;

public class ContactRepository : BaseEntityRepository<Contact>, IContactRepository
{
    public ContactRepository(PhoneBookDbContext phoneBookDbContext) : base(phoneBookDbContext)
    {
    }
}