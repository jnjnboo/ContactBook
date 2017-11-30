using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBookApi.Models;

namespace ContactBookApi.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts(int user);
        Task<int> AddContact(Contact contact);
        Task<Contact> GetContact(int id);
        Task<Contact> DeleteContact(int id);
        Task<bool> UpdateContact(Contact contact);
        Task<bool> ContactExists(int id);
    }
}
