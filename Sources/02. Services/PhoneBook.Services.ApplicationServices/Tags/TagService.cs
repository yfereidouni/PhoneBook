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

    public TagService(ITagRepository tagRepository)
    {
        this.tagRepository = tagRepository;
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

    public void Update(Tag entity)
    {
        throw new NotImplementedException();
    }
}
