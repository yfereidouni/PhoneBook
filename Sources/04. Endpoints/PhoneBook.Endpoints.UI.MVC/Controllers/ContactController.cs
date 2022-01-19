using Microsoft.AspNetCore.Mvc;
using PB.Core.Contracts.Contacts;
using PB.Core.Contracts.Tags;
using PB.Core.Entities.Contacts;
using PB.Endpoints.UI.MVC.Models.Contacts;

namespace PB.Endpoints.UI.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository contactRepository;
        private readonly ITagRepository tagRepository;

        public ContactController(IContactRepository contactRepository , ITagRepository tagRepository)
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
            //contactRepository.Add(new Contact
            //{
            //    FirstName = model.FirstName,
            //    MiddleName = model.MiddleName,
            //    LastName = model.LastName,
            //    Address = model.Address,
            //    Image = model.Image,
            //    Tags = model.SelectedTag

            //}); ;

            return RedirectToAction("Index");
        }

    }
}
