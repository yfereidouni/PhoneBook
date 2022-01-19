using PB.Core.Entities.Tags;
using System.ComponentModel.DataAnnotations;

namespace PB.Endpoints.UI.MVC.Models.Contacts;

public abstract class AddNewContactViewModel
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string MiddleName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; set; }

    [StringLength(100)]
    public string Address { get; set; }

    public string Image { get; set; }

}
public class AddNewContactDisplayViewModel : AddNewContactViewModel
{
    public List<Tag> TagsForDisplay { get; set; }
}
public class AddNewContactGetViewModel : AddNewContactViewModel
{
    public List<int> SelectedTag { get; set; }
}
