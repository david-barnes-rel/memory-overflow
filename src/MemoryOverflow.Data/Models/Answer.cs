using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryOverflow.Data.Models
{
    [Table(nameof(Answer))]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        
        public Post Post { get; set; }

        [MaxLength(255)]
        public string Text { get; set; }
        public int VoteCount { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
