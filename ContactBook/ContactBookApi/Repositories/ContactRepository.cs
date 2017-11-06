using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBookApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private ContactBookContext context;
        public ContactRepository(ContactBookContext context) => this.context = context;

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await context.Contact
                .Include(c => c.Website)
                .Include(c => c.Email)
                .Include(c => c.Phone)
                .ToListAsync();
        }

        public async Task<int> AddContact(Contact contact)
        {
            context.Contact.Add(contact);
            //returns number of objects saved to the database
            return await context.SaveChangesAsync();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await context.Contact
                .Include(c => c.Email)
                .Include(c => c.Phone)
                .Include(c => c.Address)
                .Include(c => c.Event)
                .Include(c => c.Website)
                .SingleOrDefaultAsync(m => m.ContactId == id);
        }

        public async Task<Contact> DeleteContact(int id)
        {
            var contact = await GetContact(id);
            if(contact == null)
            {
                return contact;
            }
            context.Contact.Remove(contact);
            await context.SaveChangesAsync();
            return contact;
        }

        private bool ContactExists(int id)
        {
            return context.Contact.Any(e => e.ContactId == id);
        }
    }
}
