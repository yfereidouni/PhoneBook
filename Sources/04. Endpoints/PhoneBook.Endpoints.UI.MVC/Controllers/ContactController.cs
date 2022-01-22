using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.Contacts;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Core.Entities.Contacts;
using PhoneBook.Endpoints.UI.MVC.Models.Contacts;

namespace PhoneBook.Endpoints.UI.MVC.Controllers;

public class ContactController : Controller
{
    private readonly IContactService contactService;
    private readonly ITagService tagService;

    public ContactController(IContactService contactService, ITagService tagService)
    {
        this.contactService = contactService;
        this.tagService = tagService;
    }

    public IActionResult Index()
    {
        ViewBag.PageTitle = "List of Contacts";

        var contacts = contactService.GetAll().ToList();
        return View(contacts);
    }

    public IActionResult Add()
    {
        ViewBag.PageTitle = "Add Contact";

        AddNewContactDisplayViewModel model = new()
        {
            TagsForDisplay = tagService.GetAll().ToList()
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
            var result = contactService.Add(contact);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
        }

        ViewBag.SelectedItem = model?.SelectedTag;
        
        //ViewBag.ImageFileName = model.Image.FileName;

        AddNewContactDisplayViewModel modelForDisplay = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Address = model.Address,
            Image = model.Image
        };

        modelForDisplay.TagsForDisplay = tagService.GetAll().ToList();

        return View(modelForDisplay);
    }

    public IActionResult Detail(int id)
    {
        ViewBag.PageTitle = "Details of Contact";

        var contact = contactService.FindById(id);
        var model = new ContactDetailsViewModel
        {
            ContactId = contact.Id,
            Address = contact.Address,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            Image = contact.Image
        };
        return View(model);
    }

}
