using PhoneBook.Core.Contracts.Common;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Tags;

namespace PhoneBook.Core.Contracts.Contacts;

public interface IContactTagRepository : IBaseEntityRepository<ContactTag>
{
    List<Tag> GetByPersonIdWithTags(int contactId);
    List<ContactTag> Where(Func<ContactTag, bool> func);
}