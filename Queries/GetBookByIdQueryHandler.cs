using MediatR;
using Microsoft.EntityFrameworkCore;
using LibApi.Data;
using LibApi.Models;

namespace LibApi.Queries
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly LibraryContext _context;

        public GetBookByIdQueryHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books
                .FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);
        }
    }
}