using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Core.Entities.Tags;
using PhoneBook.Infrastructures.DAL.EF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructures.DAL.EF.Tags;

public class TagRepository : BaseEntityRepository<Tag>, ITagRepository
{
    public TagRepository(PhoneBookDbContext phoneBookDbContext) : base(phoneBookDbContext)
    {
    }
}
