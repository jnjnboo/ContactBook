using System.Linq;
using System.Threading.Tasks;
using ContactBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers
{
    [Produces("application/json")]
    [Route("v1/EmailTypes")]
    public class EmailTypesController : Controller
    {
        public EmailTypesController(ILookupRepository lookupRepository)
        {
            this.LookupRepository = lookupRepository;
        }

        public ILookupRepository LookupRepository { get; set; }

        // GET: v1/EmailTypes
        [HttpGet]
        public async Task<IActionResult> GetEmailType()
        {
            var results = await LookupRepository.GetEmailTypes();
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }
    }
}