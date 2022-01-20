using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Core.Entities.Phones;
using PhoneBook.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructures.DAL.EF.Phones;

public class PhoneRepository : BaseEntityRepository<Phone>, IPhoneRepository
{
    public PhoneRepository(PhoneBookDbContext phoneBookDbContext) : base(phoneBookDbContext)
    {
    }
}
