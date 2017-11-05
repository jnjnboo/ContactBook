using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBookApi.Models.ViewModels;

namespace ContactBookApi.Repositories
{
    public interface ILookupRepository
    {
        Task<IEnumerable<LookupModels.AddressTypes>> GetAddressTypes();
        Task<IEnumerable<LookupModels.EmailTypes>> GetEmailTypes();
        Task<IEnumerable<LookupModels.EventTypes>> EventTypes();
        Task<IEnumerable<LookupModels.PhoneTypes>> PhoneTypes();
        Task<IEnumerable<LookupModels.WebSiteTypes>> WebsiteTypes();
    }
}
