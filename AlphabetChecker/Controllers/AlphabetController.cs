using Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
namespace AlphabetChecker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlphabetController : Controller
    {
        private readonly IAlphabetService AlphabetService;
        public AlphabetController(IAlphabetService alphabetService) 
        {
            this.AlphabetService = alphabetService;
        }
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> CheckAlphabet([FromBody] AlphabetCheck request)
        {
            if (request == null)
            {
                return BadRequest("Input cannot be null or empty.");
            }

            var output = this.AlphabetService.CheckAlphabet(request.Input);

            return Ok(output);
        }
    }
}
