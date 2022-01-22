namespace PhoneBook.Endpoints.UI.MVC.Models.Contacts;

public class ContactDetailsViewModel
{
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public string Image { get; set; }
}
