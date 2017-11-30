using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Models;
using ContactBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers
{
    [Produces("application/json")]
    [Route("v1/{userId}/Contacts")]
    public class ContactsController : Controller
    {
        public ContactsController(IContactRepository contactRepository)
        {
            this.ContactRepository = contactRepository;
        }

        public IContactRepository ContactRepository { get; set; }

        [HttpGet]
        public async Task<IActionResult> GetContacts([FromRoute] int userId)
        {
            var results = await ContactRepository.GetContacts(userId);
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [Route("Default")]
        [HttpGet]
        public IActionResult GetDefault()
        {
            var results = new Contact
            {
                Address = new Address[] { new Address() },
                Email = new Email[] { new Email() },
                Event = new Event[] { new Event() },
                Phone = new Phone[] { new Phone() },
                Website = new Website[] { new Website() },
            };

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact([FromRoute] int userId, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await ContactRepository.GetContact(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact([FromRoute] int userId, [FromRoute] int id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest("ContactId:" + id + " and the id of the contact passed in do not match");
            }

            var exists = await ContactRepository.ContactExists(id);

            if (!exists)
            {
                return NotFound();
            }

            var isSaved = await ContactRepository.UpdateContact(contact);

            if (!isSaved)
            {
                var message = "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.";
                return StatusCode(500, message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostContact([FromRoute] int userId, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numberSaved = await ContactRepository.AddContact(contact);

            if (numberSaved < 1)
            {
                var message = "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.";
                return StatusCode(500, message);
            }

            return CreatedAtAction("GetContact", new { id = contact.ContactId }, contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int userId, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await ContactRepository.DeleteContact(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }
    }
}