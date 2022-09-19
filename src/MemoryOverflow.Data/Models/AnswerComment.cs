using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryOverflow.Data.Models
{
    [Table(nameof(AnswerComment))]
    public class AnswerComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public Guid AnswerId { get; set; }
        [ForeignKey(nameof(AnswerId))]
        public Answer Answer { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
