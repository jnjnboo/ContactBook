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
        /// <param name="contact">Model.Contact object.</param>
        /// <returns>Async Task, with the number of objects saved to the repository.</returns>
        public async Task<int> AddContact(Contact contact)
        {
            SetCollectionTypeIds(contact);
            context.Contact.Add(contact);
            return await context.SaveChangesAsync();
        }

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
            foreach (var email in contact.Email)
            {
                email.Contact = null;
                email.EmailTypeId = email.EmailType.EmailTypeId;
                email.EmailType = null;
            }

            foreach (var phone in contact.Phone)
            {
                phone.Contact = null;
                phone.PhoneTypeId = phone.PhoneType.PhoneTypeId;
                phone.PhoneType = null;
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
                    .Where(e => e.EmailId == emailModel.EmailId)
                    .SingleOrDefault();
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
                    var newPhone = new Phone
                    {
                        ContactId = existingContact.ContactId,
                        Number = phoneModel.Number,
                        PhoneTypeId = phoneModel.PhoneTypeId
                    };
                    existingContact.Phone.Add(newPhone);
                }
            }
        }
    }
}
