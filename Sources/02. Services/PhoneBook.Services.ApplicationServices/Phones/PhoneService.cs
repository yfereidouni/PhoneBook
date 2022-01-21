using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.ApplicationServices.Phones;

public class PhoneService : IPhoneService
{
    private readonly IPhoneRepository phoneRepository;

    public PhoneService(IPhoneRepository phoneRepository)
    {
        this.phoneRepository = phoneRepository;
    }

    public Phone Add(Phone entity)
    {
        return phoneRepository.Add(entity);
    }

    public void Delete(Phone entity)
    {
        phoneRepository.Delete(entity);
    }

    public Phone FindById(int id)
    {
        return phoneRepository.FindById(id);
    }

    public IQueryable<Phone> GetAll()
    {
        return phoneRepository.GetAll();
    }

    public void Update(Phone entity)
    {
        phoneRepository.Update(entity);
    }
}
