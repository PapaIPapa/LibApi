using MediatR;
using LibApi.Models;
using System.Collections.Generic;

namespace LibApi.Queries
{
    public class GetAuthorsQuery : IRequest<List<string>>
    {
    }
}
