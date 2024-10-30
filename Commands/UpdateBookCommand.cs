using MediatR;
using LibApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LibApi.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(1000, 9999)]
        public int PublishedYear { get; set; }
        public string? Genre { get; set; }
    }
}