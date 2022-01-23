using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Entities.Phones;
using PhoneBook.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructures.DAL.EF.Phones;

public class PhoneTypeRepository : BaseEntityRepository<PhoneType>, IPhoneTypeRepository
{
    public PhoneTypeRepository(PhoneBookDbContext phoneBookDbContext) : base(phoneBookDbContext)
    {

    }
    public List<PhoneType> GetByContactIdWithPhoneType(int contactId)
    {
        return phoneBookDbContext.Phones.Where(c => c.ContactId == contactId).Select(c => c.PhoneType).ToList();
    }

    public List<Phone> Where(Func<Phone, bool> func)
    {
        return phoneBookDbContext.Phones.Where(func).ToList();
    }
}