using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SqzTo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SqzToController : Controller
    {
        [HttpPost, Route("/")]
        public async Task<IActionResult> GetOrCreateFrom([FromBody] string url)
        {
            //FUCKOFF: The Official Site of a Symbolic Behavior Model Modification Suggestion - https://natribu.org/en/
            return Json("TOSSBMMS");
        }

        [HttpGet, Route("/{route}")]
        public async Task<IActionResult> NavigateTo([FromRoute] string route)
        {
            return Json("https://natribu.org/en/");
        }
    }
}
