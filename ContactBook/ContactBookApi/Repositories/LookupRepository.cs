using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Models;
using ContactBookApi.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ContactBookApi.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private ContactBookContext context;
        public LookupRepository(ContactBookContext context) => this.context = context;

        public async Task<IEnumerable<LookupModels.AddressTypes>> GetAddressTypes()
        {
            return await context.AddressType.Select(at => new LookupModels.AddressTypes { Id = at.AddressTypeId, Name = at.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.EmailTypes>> GetEmailTypes()
        {
            return await context.EmailType.Select(et => new LookupModels.EmailTypes { Id = et.EmailTypeId, Name = et.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.EventTypes>> GetEventTypes()
        {
            return await context.EventType.Select(at => new LookupModels.EventTypes { Id = at.EventTypeId, Name = at.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.PhoneTypes>> GetPhoneTypes()
        {
            return await context.PhoneType.Select(at => new LookupModels.PhoneTypes { Id = at.PhoneTypeId, Name = at.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.WebsiteTypes>> GetWebsiteTypes()
        {
            return await context.WebsiteType.Select(at => new LookupModels.WebsiteTypes { Id = at.WebsiteTypeId, Name = at.Name }).ToListAsync();
        }
    }
}
