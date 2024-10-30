using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibApi.Queries;
using LibApi.Models;

namespace LibApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _mediator.Send(new GetAuthorsQuery());
            return Ok(authors);
        }
    }
}
