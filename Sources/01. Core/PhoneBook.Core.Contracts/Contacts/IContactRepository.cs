using PB.Core.Contracts.Common;
using PB.Core.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Core.Contracts.Contacts;

public interface IContactRepository : IBaseEntityRepository<Contact>
{

}
