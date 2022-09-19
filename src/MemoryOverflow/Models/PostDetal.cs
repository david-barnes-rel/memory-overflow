namespace MemoryOverflow.Models
{
    public class PostDetal : SlimPost
    {
        public IReadOnlyList<Comment> Comments { get; set; } = new List<Comment>();
        public IReadOnlyList<Answer> Answers { get; set; } = new List<Answer>();
    }
}
