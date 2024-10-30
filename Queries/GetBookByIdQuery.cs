using MediatR;
using LibApi.Models;

namespace LibApi.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}