using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LibApi.Commands
{
    public class DeleteBookCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}