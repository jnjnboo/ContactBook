using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Models;
using ContactBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers
{
    [Produces("application/json")]
    [Route("v1/Contacts")]
    public class ContactsController : Controller
    {
        public ContactsController(IContactRepository contactRepository)
        {
            this.ContactRepository = contactRepository;
        }

        public IContactRepository ContactRepository { get; set; }

        // GET: v1/Contacts/user
        [HttpGet("{user}")]
        public async Task<IActionResult> GetContacts([FromRoute] int user)
        {
            var results = await ContactRepository.GetContacts(user);
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        // GET: v1/Contacts/default
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

        // GET: v1/Contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
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

        // PUT: v1/Contacts/5
        [HttpPut("{contactId}")]
        public async Task<IActionResult> PutContact([FromRoute] int contactId, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (contactId != contact.ContactId)
            {
                return BadRequest("ContactId:" + contactId + " and the id of the contact passed in do not match");
            }

            var exists = await ContactRepository.ContactExists(contactId);

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

        // POST: v1/Contacts
        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody] Contact contact)
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

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
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