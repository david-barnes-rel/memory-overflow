using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOverflow.Data.Models
{
    [Table(nameof(Post))]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        public string Question { get; set; }
        public int VoteCount { get; set; } = 0;
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<PostComment> Comments { get; set; }
    }
}
