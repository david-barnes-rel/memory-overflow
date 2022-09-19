using System.ComponentModel.DataAnnotations;

namespace MemoryOverflow.Models
{
    public class Comment
    {
        public Guid? Id { get; set;}
        [Required]
        public string? Message { get; set; }
        public User? User { get; set; }
    }
}
