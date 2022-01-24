using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.ApplicationServices.Contacts;

public class ContactService : IContactService
{
    private readonly IContactRepository contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        this.contactRepository = contactRepository;
    }

    public Contact Add(Contact entity)
    {
        return contactRepository.Add(entity);
    }

    public void Delete(Contact entity)
    {
        contactRepository.Delete(entity);
    }

    public Contact FindById(int id)
    {
        return contactRepository.FindById(id);
    }

    public IQueryable<Contact> GetAll()
    {
        return contactRepository.GetAll();
    }

    public void Update(Contact entity)
    {
        contactRepository.Update(entity);
    }
    
    public Contact GetContactWithChilds(int contactId)
    {
        return contactRepository.GetContactWithPhones(contactId);
    }
}
