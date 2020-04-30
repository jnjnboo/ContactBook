using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBookApi.Persistence
{
    public class ContactRepository : IContactRepository
    {
        private ContactBookContext context;
        public ContactRepository(ContactBookContext context) => this.context = context;

        public async Task<IEnumerable<Contact>> GetContacts(int id)
        {
            return await context.Contact
                .Where(c => c.UserId == id)
                .Include(c => c.Address)
                .Include(c => c.Email)
                .Include(c => c.Event)
                .Include(c => c.Phone)
                .Include(c => c.Website)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Add a new Contact to the Contact repository.
        /// </summary>
        /// <param name="contact">Model.Contact object to be saved to data store.</param>
        /// <returns>Async Task, with the number of objects saved to the repository.</returns>
        public async Task<int> AddContact(Contact contact)
        {
            SetCollectionTypeIds(contact);
            context.Contact.Add(contact);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a contact with all child elements.
        /// </summary>
        /// <param name="id">Id of contact to be returned.</param>
        /// <returns>Async task, with Contact object result from query on id</returns>
        public async Task<Contact> GetContact(int id)
        {
            return await context.Contact
                .Include(c => c.Address)
                .Include(c => c.Email)
                .Include(c => c.Event)
                .Include(c => c.Phone)
                .Include(c => c.Website)
                .SingleOrDefaultAsync(m => m.ContactId == id);
        }

        /// <summary>
        /// Delete an existing contact with cascade delete in data store.
        /// </summary>
        /// <param name="id">Id of contact to be deleted.</param>
        /// <returns>Async Task, with the Contact that was deleted.</returns>
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
            var existingContact = await GetContact(contact.ContactId);

            try
            {
                UpdateEmailEntries(contact, existingContact);
                UpdatePhoneEntries(contact, existingContact);
                context.Entry(existingContact).CurrentValues.SetValues(contact);

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

        private static void SetCollectionTypeIds(Contact contact)
        {
            foreach (var address in contact.Address)
            {
                address.Contact = null;
                if (address.AddressType != null)
                {
                    address.AddressTypeId = address.AddressType.AddressTypeId;
                    address.AddressType = null;
                }
            }

            foreach (var email in contact.Email)
            {
                email.Contact = null;
                if (email.EmailType != null)
                {
                    email.EmailTypeId = email.EmailType.EmailTypeId;
                    email.EmailType = null;
                }
            }

            foreach (var eventItem in contact.Event)
            {
                eventItem.Contact = null;
                if (eventItem.EventType != null)
                {
                    eventItem.EventId = eventItem.EventType.EventTypeId;
                    eventItem.EventType = null;
                }
            }

            foreach (var phone in contact.Phone)
            {
                phone.Contact = null;
                if (phone.PhoneType != null)
                {
                    phone.PhoneTypeId = phone.PhoneType.PhoneTypeId;
                    phone.PhoneType = null;
                }
            }

            foreach (var webSite in contact.Website)
            {
                webSite.Contact = null;
                if (webSite.WebsiteType != null)
                {
                    webSite.WebsiteTypeId = webSite.WebsiteType.WebsiteTypeId;
                    webSite.WebsiteType = null;
                }
            }
        }

        private void UpdateAddressEntries(Contact contact, Contact existingContact)
        {
            foreach (var existingAddress in existingContact.Address.ToList())
            {
                if (!contact.Address.Any(a => a.AddressId == existingAddress.AddressId))
                {
                    context.Address.Remove(existingAddress);
                }
            }

            foreach (var address in contact.Address)
            {
                if (address.AddressType != null)
                {
                    address.AddressTypeId = address.AddressType.AddressTypeId;
                }

                var existingAddress = existingContact.Address
                    .Where(a => a.AddressId == address.AddressId).SingleOrDefault();

                if (existingAddress != null)
                {
                    context.Entry(existingAddress).CurrentValues.SetValues(address);
                }
                else
                {
                    var newAddress = new Address
                    {
                        ContactId = existingContact.ContactId,
                        Address1 = address.Address1,
                        Address2 = address.Address2,
                        City = address.City,
                        StateProvince = address.StateProvince,
                        PostalCode = address.PostalCode,
                        Country = address.Country,
                        AddressTypeId = address.AddressTypeId
                    };
                    existingContact.Address.Add(newAddress);
                }
            }
        }

        private void UpdateEmailEntries(Contact contact, Contact existingContact)
        {
            foreach (var existingEmail in existingContact.Email.ToList())
            {
                if (!contact.Email.Any(e => e.EmailId == existingEmail.EmailId))
                {
                    context.Email.Remove(existingEmail);
                }
            }

            foreach (var emailModel in contact.Email)
            {
                if (emailModel.EmailType != null)
                {
                    emailModel.EmailTypeId = emailModel.EmailType.EmailTypeId;
                }

                var existingEmail = existingContact.Email
                    .Where(e => e.EmailId == emailModel.EmailId).SingleOrDefault();

                if (existingEmail != null)
                {
                    context.Entry(existingEmail).CurrentValues.SetValues(emailModel);
                }
                else
                {
                    var newEmail = new Email
                    {
                        ContactId = existingContact.ContactId,
                        EmailAddress = emailModel.EmailAddress,
                        EmailTypeId = emailModel.EmailTypeId
                    };
                    existingContact.Email.Add(newEmail);
                }
            }
        }

        private void UpdateEventEntries(Event eventItem, Event existingEvent) { }

        private void UpdatePhoneEntries(Contact contact, Contact existingContact)
        {
            foreach (var existingPhone in existingContact.Phone.ToList())
            {
                if (!contact.Phone.Any(e => e.PhoneId == existingPhone.PhoneId))
                {
                    context.Phone.Remove(existingPhone);
                }
            }

            foreach (var phoneModel in contact.Phone)
            {
                if (phoneModel.PhoneType != null)
                {
                    phoneModel.PhoneTypeId = phoneModel.PhoneType.PhoneTypeId;
                }

                var existingPhone = existingContact.Phone
                    .Where(e => e.PhoneId == phoneModel.PhoneId)
                    .SingleOrDefault();
                if (existingPhone != null)
                {
                    context.Entry(existingPhone).CurrentValues.SetValues(phoneModel);
                }
                else
                {
                    phoneModel.ContactId = contact.ContactId;
                    existingContact.Phone.Add(phoneModel);
                }
            }
        }

        private void UpdateWebsiteEntries(Contact contact, Contact existingContact) { }
    }
}
