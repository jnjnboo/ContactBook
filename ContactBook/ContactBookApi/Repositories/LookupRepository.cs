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
            return await context.AddressType.Select(at => new LookupModels.AddressTypes { AddressTypeId = at.AddressTypeId, Name = at.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.EmailTypes>> GetEmailTypes()
        {
            return await context.EmailType.Select(et => new LookupModels.EmailTypes { EmailTypeId = et.EmailTypeId, Name = et.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.EventTypes>> GetEventTypes()
        {
            return await context.EventType.Select(at => new LookupModels.EventTypes { EventTypeId = at.EventTypeId, Name = at.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.PhoneTypes>> GetPhoneTypes()
        {
            return await context.PhoneType.Select(at => new LookupModels.PhoneTypes { PhoneTypeId = at.PhoneTypeId, Name = at.Name }).ToListAsync();
        }

        public async Task<IEnumerable<LookupModels.WebsiteTypes>> GetWebsiteTypes()
        {
            return await context.WebsiteType.Select(at => new LookupModels.WebsiteTypes { WebsiteTypeId = at.WebsiteTypeId, Name = at.Name }).ToListAsync();
        }
    }
}
