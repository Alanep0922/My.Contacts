using Backend.Models;
using Backend.Repository;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/api/contacts")]
    public class ContactController : ControllerBase
    {
        private ContactService service;

        public ContactController(ContactService service)
        {
            this.service = service;
        }

        [HttpPost]
        public void Create([FromBody] Contact contact)
        {
            service.Create(contact);
        }

        [HttpGet]
        public List<Contact> List()
        {
            return service.GetContacts();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return service.GetById(id);
        }


        [HttpPut("{id}")]
        public void Update(Contact contact, int id)
        {
            service.Update(contact, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteById(id);
        }
    }
}