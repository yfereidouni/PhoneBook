using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.ApplicationServices.Phones
{
    public class PhoneTypeService : IPhoneTypeService
    {
        private readonly IPhoneTypeRepository phoneTypeRepository;

        public PhoneTypeService(IPhoneTypeRepository phoneTypeRepository)
        {
            this.phoneTypeRepository = phoneTypeRepository;
        }

        public PhoneType Add(PhoneType entity)
        {
            return phoneTypeRepository.Add(entity);
        }

        public void Delete(PhoneType entity)
        {
            phoneTypeRepository.Delete(entity);
        }

        public PhoneType FindById(int id)
        {
            return phoneTypeRepository.FindById(id);
        }

        public IQueryable<PhoneType> GetAll()
        {
            return phoneTypeRepository.GetAll();
        }

        public List<PhoneType> GetAllContactPhoneTypes(List<Phone> tags)
        {
            List<PhoneType> resultTags = new List<PhoneType>();
            for (int i = 0; i < tags.Count; i++)
            {
                resultTags.Add(phoneTypeRepository.FindById(tags[i].PhoneTypeId));
            }
            return resultTags;
        }

        public List<PhoneType> GetContactPhoneTypesByContactId(int contactId)
        {
            return GetAllContactPhoneTypes(phoneTypeRepository.Where(c => c.ContactId == contactId));
        }

        public void Update(PhoneType entity)
        {
            phoneTypeRepository.Update(entity);
        }
    }
}
