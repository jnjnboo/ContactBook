﻿using System;
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

        /// <summary>
        /// Add a new Contact to the Contact repository.
        /// </summary>
        /// <param name="contact">Model.Contact object.</param>
        /// <returns>Async Task, with the number of objects saved to the repository.</returns>
        public async Task<int> AddContact(Contact contact)
        {
            CleanContact(contact);
            context.Contact.Add(contact);
            return await context.SaveChangesAsync();
        }

        private void CleanContact(Contact contact)
        {
            
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
            if (contact == null)
            {
                return contact;
            }

            context.Contact.Remove(contact);
            await context.SaveChangesAsync();
            return contact;
        }

        /// <summary>
        /// Update Contact information only in Contact repository.
        /// </summary>
        /// <param name="contact">Model.Contact object.</param>
        /// <returns>Async Task, Returns boolean indicating if it was a successful save.</returns>
        public async Task<bool> UpdateContact(Contact contact)
        {
            var isSaved = false;
            context.Entry(contact).State = EntityState.Modified;
            var currentContact = await GetContact(contact.ContactId);
            try
            {
                context.Entry(currentContact).CurrentValues.SetValues(contact);
                await context.SaveChangesAsync();
                isSaved = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                isSaved = false;
            }

            return isSaved;
        }

        public async Task<bool> ContactExists(int id)
        {
            return await context.Contact.AnyAsync(e => e.ContactId == id);
        }
    }
}
