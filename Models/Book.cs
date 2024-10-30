using System.ComponentModel.DataAnnotations;

namespace LibApi.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public string? Genre { get; set; }
    }
}