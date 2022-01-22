using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.ApplicationServices.Tags;

public class TagService : ITagService
{
    private readonly ITagRepository tagRepository;
    private readonly IContactTagRepository contactTagRepository;

    public TagService(ITagRepository tagRepository, IContactTagRepository contactTagRepository)
    {
        this.tagRepository = tagRepository;
        this.contactTagRepository = contactTagRepository;
    }

    public Tag Add(Tag entity)
    {
        return tagRepository.Add(entity);
    }

    public void Delete(Tag entity)
    {
        tagRepository.Delete(entity);
    }

    public Tag FindById(int id)
    {
        return tagRepository.FindById(id);
    }

    public IQueryable<Tag> GetAll()
    {
        return tagRepository.GetAll();
    }

    public List<Tag> GetAllContactTags(List<ContactTag> tags)
    {
        List<Tag> resultTags = new List<Tag>();
        for (int i = 0; i < tags.Count; i++)
        {
            resultTags.Add(tagRepository.FindById(tags[i].TagId));
        }
        return resultTags;
    }

    public List<Tag> GetContactTagsByContactId(int contactId)
    {
        return GetAllContactTags(contactTagRepository.Where(c => c.ContactId == contactId));
    }

    public void Update(Tag entity)
    {
        throw new NotImplementedException();
    }


}
