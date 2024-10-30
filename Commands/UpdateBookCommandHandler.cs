using MediatR;
using Microsoft.EntityFrameworkCore;
using LibApi.Data;
using LibApi.Models;

namespace LibApi.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly LibraryContext _context;

        public UpdateBookCommandHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id, cancellationToken);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.PublishedYear = request.PublishedYear;
            book.Genre = request.Genre;

            await _context.SaveChangesAsync(cancellationToken);

            return book;
        }
    }
}