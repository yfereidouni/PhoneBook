using PhoneBook.Core.Entities.Common;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Entities.Contacts
{
    public class ContactTag : BaseEntity
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
