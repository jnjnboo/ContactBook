using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers
{
    [Produces("application/json")]
    public class LookupController : Controller
    {
        public LookupController(ILookupRepository lookupRepository)
        {
            this.LookupRepository = lookupRepository;
        }

        public ILookupRepository LookupRepository { get; set; }

        [Route("v1/Lookup/AddressTypes")]
        [HttpGet]
        public async Task<IActionResult> GetAddressTypes()
        {
            var results = await LookupRepository.GetAddressTypes();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [Route("v1/Lookup/EmailTypes")]
        [HttpGet]
        public async Task<IActionResult> GetEmailTypes()
        {
            var results = await LookupRepository.GetEmailTypes();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [Route("v1/Lookup/EventTypes")]
        [HttpGet]
        public async Task<IActionResult> GetEventTypes()
        {
            var results = await LookupRepository.GetEventTypes();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [Route("v1/Lookup/PhoneTypes")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneTypes()
        {
            var results = await LookupRepository.GetPhoneTypes();
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
            var results = await LookupRepository.GetWebsiteTypes();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }
    }
}