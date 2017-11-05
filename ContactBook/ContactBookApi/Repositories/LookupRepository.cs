using System;
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

        public Task<IEnumerable<LookupModels.AddressTypes>> GetAddressTypes()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LookupModels.EmailTypes>> GetEmailTypes()
        {
            return await context.EmailType
                .Select(et => new LookupModels.EmailTypes { Id = et.EmailTypeId, Name = et.Name }).ToListAsync();
        }

        public Task<IEnumerable<LookupModels.EventTypes>> EventTypes()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupModels.PhoneTypes>> PhoneTypes()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupModels.WebSiteTypes>> WebsiteTypes()
        {
            throw new NotImplementedException();
        }
    }
}
