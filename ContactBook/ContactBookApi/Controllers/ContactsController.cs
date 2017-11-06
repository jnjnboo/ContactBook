using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Models;
using ContactBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers
{
    [Produces("application/json")]
    [Route("v1/Contacts")]
    public class ContactsController : Microsoft.AspNetCore.Mvc.Controller
    {
        public ContactsController(IContactRepository contactRepository)
        {
            this.ContactRepository = contactRepository;
        }

        public IContactRepository ContactRepository { get; set; }

        // GET: v1/Contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var results = await ContactRepository.GetContacts();
            if (!results.Any())
            {
                return NotFound();
            }

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

        //// PUT: v1/Contacts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutContact([FromRoute] int id, [FromBody] Contact contact)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != contact.ContactId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(contact).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContactExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //POST: v1/Contacts
       [HttpPost]
        public async Task<IActionResult> PostContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numberSaved = await ContactRepository.AddContact(contact);

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