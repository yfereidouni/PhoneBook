using PB.Core.Contracts.Tags;
using PB.Core.Entities.Tags;
using PB.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Infrastructures.DAL.EF.Tags;

public class TagRepository : BaseEntityRepository<Tag>, ITagRepository
{
    public TagRepository(PhoneBookDbContext pBDB) : base(pBDB)
    {
    }
}
