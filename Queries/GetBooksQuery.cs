using MediatR;
using LibApi.Models;

namespace LibApi.Queries
{
    public class GetBooksQuery : IRequest<List<Book>>
    {
    }
}
