using MediatR;
using LibApi.Data;
using LibApi.Models;

namespace LibApi.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly LibraryContext _context;

        public CreateBookCommandHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                PublishedYear = request.PublishedYear,
                Genre = request.Genre
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);

            return book;
        }
    }
}