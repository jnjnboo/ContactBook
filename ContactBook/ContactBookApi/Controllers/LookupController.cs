using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBookApi.Controllers
{
    [Produces("application/json")]
    public class LookupController : Controller
    {
        private ContactBookContext context;

        public LookupController(ContactBookContext cbContext)
        {
            context = cbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAddressTypes()
        {
            var results = await context.AddressType.ToListAsync();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmailTypes()
        {
            var results = await context.EmailType.ToListAsync();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [HttpGet]
        public async Task<IActionResult> GetEventTypes()
        {
            var results = await context.EventType.ToListAsync();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneTypes()
        {
            var results = await context.PhoneType.ToListAsync();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [Route("v1/Lookup/WebsiteTypes")]
        [HttpGet]
        public async Task<IActionResult> GetWebsiteTypes()
        {
            var results = await context.WebsiteType.ToListAsync();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }
    }
}