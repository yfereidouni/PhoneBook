using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Core.Entities.Tags;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Endpoints.UI.MVC.Models.Contacts;

namespace PhoneBook.Endpoints.UI.MVC.Controllers;

public class ContactController : Controller
{
    private readonly IContactRepository contactRepository;
    private readonly ITagRepository tagRepository;

    public ContactController(IContactRepository contactRepository, ITagRepository tagRepository)
    {
        this.contactRepository = contactRepository;
        this.tagRepository = tagRepository;
    }

    public IActionResult Index()
    {
        ViewBag.PageTitle = "List of Contacts";

        var contacts = contactRepository.GetAll().ToList();
        return View(contacts);
    }

    public IActionResult Add()
    {
        ViewBag.PageTitle = "Add Contact";

        AddNewContactDisplayViewModel model = new()
        {
            TagsForDisplay = tagRepository.GetAll().ToList()
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(AddNewContactGetViewModel model)
    {
        if (ModelState.IsValid)
        {
            Contact contact = new Contact
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                Tags = new List<ContactTag>(model.SelectedTag.Select(c => new ContactTag
                {
                    TagId = c
                }).ToList())
            };
            if (model.Image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    model.Image.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    contact.Image = Convert.ToBase64String(fileBytes);
                }
            }
            var result = contactRepository.Add(contact);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
        }

        ViewBag.SelectedItem = model.SelectedTag;
        
        //ViewBag.ImageFileName = model.Image.FileName;

        AddNewContactDisplayViewModel modelForDisplay = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Address = model.Address,
            Image = model.Image
        };

        modelForDisplay.TagsForDisplay = tagRepository.GetAll().ToList();

        return View(modelForDisplay);
    }

}
