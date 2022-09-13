using System.ComponentModel.DataAnnotations;

namespace MemoryOverflow.Models
{
    public class SlimPost
    {
        public Guid? Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Title { get; set; }
    }
    public class PostDetal : SlimPost
    {
    }

    public class Comment
    {
        public Guid? Id { get; set;}
        [Required]
        public string? Message { get; set; }
        public User? User { get; set; }
    }

    public class User { }

    public class MessageVote
    {
        [Required]
        public int Vote { get; set; }
    }

    public class Answer
    {
        public Guid? Id { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
