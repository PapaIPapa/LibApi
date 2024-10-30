using MediatR;
using Microsoft.EntityFrameworkCore;
using LibApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibApi.Queries
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<string>>
    {
        private readonly LibraryContext _context;

        public GetAuthorsQueryHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            
            return await _context.Books
                .Select(b => b.Author)
                .Distinct()
                .ToListAsync(cancellationToken);
        }
    }
}