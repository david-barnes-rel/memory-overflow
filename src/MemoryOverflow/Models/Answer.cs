using System.ComponentModel.DataAnnotations;

namespace MemoryOverflow.Models
{
    public class Answer
    {
        public Guid? Id { get; set; }
        [Required]
        public string? Text { get; set; }

        public int VoteCount { get; set; }
        public IReadOnlyList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
