using System.ComponentModel.DataAnnotations;

namespace LibApi.Models
{
    public class Author
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}