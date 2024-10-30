using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibApi.Commands;
using LibApi.Queries;
using LibApi.Models;

namespace LibApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(CreateBookCommand command)
        {
            var book = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, UpdateBookCommand command)
        {
            if (id != command.Id) return BadRequest();

            var result = await _mediator.Send(command);
            if (result == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }
}