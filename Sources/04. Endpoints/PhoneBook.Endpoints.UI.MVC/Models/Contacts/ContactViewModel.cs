using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.UI.MVC.Models.Contacts
{
    public class ContactViewModel
    {
        //[Display(Name = "نام")]
        //[Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        //[StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        //[Display(Name = "نام خانوادگی")]
        //[Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        //[StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        //[Display(Name = "ایمیل")]
        //[Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        //[EmailAddress]
        public string Email { get; set; }

        //[Display(Name = "آدرس")]
        //[StringLength(500)]
        public string Address { get; set; }

        public string Image { get; set; }

    }
}
