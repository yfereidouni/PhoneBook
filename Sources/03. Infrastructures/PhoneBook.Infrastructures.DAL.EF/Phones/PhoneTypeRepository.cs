using PB.Core.Contracts.Contacts;
using PB.Core.Entities.Phones;
using PB.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Infrastructures.DAL.EF.Phones;

public class PhoneTypeRepository : BaseEntityRepository<PhoneType>, IPhoneTypeRepository
{
    public PhoneTypeRepository(PhoneBookDbContext pBDB) : base(pBDB)
    {
    }
}