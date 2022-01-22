using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Tags;
using PhoneBook.Infrastructures.DAL.EF.Common;

namespace PhoneBook.Infrastructures.DAL.EF.Contacts;

public class ContactTagRepository : BaseEntityRepository<ContactTag>, IContactTagRepository
{
    public ContactTagRepository(PhoneBookDbContext phoneBookDbContext) : base(phoneBookDbContext)
    {
    }

    public List<Tag> GetByPersonIdWithTags(int contactId)
    {
        return phoneBookDbContext.ContactTags.Where(c => c.ContactId == contactId).Select(c => c.Tag).ToList();
    }

    public List<ContactTag> Where(Func<ContactTag, bool> func)
    {
        return phoneBookDbContext.ContactTags.Where(func).ToList();
    }
}