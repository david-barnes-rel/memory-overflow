using System.ComponentModel.DataAnnotations;

namespace MemoryOverflow.Models
{
    public class Answer
    {
        public Guid? Id { get; set; }
        [Required]
        public string? Message { get; set; }
        public IReadOnlyList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
