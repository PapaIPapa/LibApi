using MediatR;
using Microsoft.EntityFrameworkCore;
using LibApi.Data;
using LibApi.Models;

namespace LibApi.Queries
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Book>>
    {
        private readonly LibraryContext _context;

        public GetBooksQueryHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.ToListAsync(cancellationToken);
        }
    }
}